using Microsoft.Extensions.Configuration;
using MyWeatherTelegramBot;
using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;


var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");
var config = builder.Build();
string connectionString = config.GetConnectionString("GeographyConnection");
GeographyContext geographyContext = new GeographyContext(connectionString);
CityRepository repository = new CityRepository(geographyContext);

Settings settings = config.GetRequiredSection("Settings").Get<Settings>();
IWeatherClient weatherClient = new YandexWeatherClient(settings.YandexBaseUrl, settings.YandexKey);

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Message is Message message)
    {

        var city = repository.GetСoordinatesByName(message.Text);
        if (city != null)
        {
            var forecast = await weatherClient.GetForecastByCity(city);
            await botClient.SendTextMessageAsync(message.Chat, $"Сейчас темрепатура в городе {city.Name} - {forecast.fact.temp}C, ощущается как - {forecast.fact.feels_like}C");
        }
        else
        {
            await botClient.SendTextMessageAsync(message.Chat, "Такого города нет");
        }
    }
}

async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    if (exception is ApiRequestException apiRequestException)
    {
        await botClient.SendTextMessageAsync(123, apiRequestException.ToString());
    }
}

ITelegramBotClient bot = new TelegramBotClient(settings.TelegramKey);

var cts = new CancellationTokenSource();
var cancellationToken = cts.Token;
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { } // receive all update types
};
try
{
    await bot.ReceiveAsync(
        HandleUpdateAsync,
        HandleErrorAsync,
        receiverOptions,
        cancellationToken
   );
}
catch (OperationCanceledException exception)
{
}