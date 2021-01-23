using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using HacatonUntitledTeam.Entities.Models;
using Newtonsoft.Json.Linq;

namespace HacatonUntitledTeam.Services.Parser.CurrentParsers.RozetkaParser
{
    public class RozetkaParserBySearchString : IParserBySearchString
    {
        // Ссылка на API, которое возвращает новый маршрут.
        public readonly string RedirectApiUrl = "https://search.rozetka.com.ua/ua/search/api/v4/?front-type=xl&text";

        // TODO: Возможно стоит переименовать этот метод.
        public async Task<string> GetRedirectUrlAsync(string searchString)
        {
            // Загружаем страницу.
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"{RedirectApiUrl}={searchString}");

            // Парсим json, полученный из API и достаём новый маршрут.
            var json = await response.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(json);

            var data = (JObject)jObject["data"];

            var meta = (JObject)data["meta"];

            var navigateTo = (JObject)meta["navigateTo"];

            var url = (string)navigateTo["url"];

            // Розетка немного странно устроена, поэтому для перехода по страницам
            // приходится убирать из маршрута этот параметр.
            return url.Replace($"#search_text={searchString}", "");
        } // GetRedirectUrlAsync.

        // TODO: Разбить на методы.
        public async Task<int> GetNumberOfEndPage(string searchString)
        {
            // Создаём объект клиента.
            var client = new HttpClient();

            // Получаем новый маршрут, на который нас редиректили.
            string redirectUrl = await GetRedirectUrlAsync(searchString);

            // Получаем html разметку.
            var html = await client.GetStringAsync(redirectUrl);

            // Открываем html страницу для парсинга.
            var context = BrowsingContext.New(Configuration.Default);

            var document = await context.OpenAsync(req => req.Content(html));

            // Получаем количество страниц.
            var stringNumber = document.GetElementsByClassName("pagination__item").Last().GetElementsByClassName("pagination__link")[0]
                .TextContent.Replace("\"", "");

            int intNumber = int.Parse(stringNumber);

            return intNumber;
        } // GetNumberOfEndPage.

        public async Task<List<Goods>> GetGoodsesBySearchStringAsync(string searchString)
        {
            // Создаём воркера для розетки.
            ParserWorker<List<Goods>> worker =
                new ParserWorker<List<Goods>>(new RozetkaParser(),
                    new RozetkaParserSettings(await GetRedirectUrlAsync(searchString), 1, await GetNumberOfEndPage(searchString)));

            // Список, в который будут записываться результаты.
            List<Goods> goods = new List<Goods>();

            // Флаг, завершился ли парсинг данных.
            bool complete = false;

            // Каждый раз, когда распаршены новые данные, добавляем их в коллекцию.
            worker.NewData += (o, list) => goods.AddRange(list);

            // Когда вся страничка распарсилась, ставим флаг в true.
            worker.Completed += o => complete = true;

            // Запускаем воркера.
            worker.Start();

            // Пока complete == false, мы не сможем вернуться из метода.
            while (!complete) { }

            return goods;
        } // GetGoodsesBySearchStringAsync.
    } // RozetkaParserBySearchString.
}
