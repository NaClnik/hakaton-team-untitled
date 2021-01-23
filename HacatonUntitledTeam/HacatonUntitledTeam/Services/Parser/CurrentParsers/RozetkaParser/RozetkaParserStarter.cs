using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace HacatonUntitledTeam.Services.Parser.CurrentParsers.RozetkaParser
{
    // Тут вместо закрытия List<string> нужно закрыть моделью, но её у нас пока ещё нет.
    public class RozetkaParserStarter : IParserStarter<List<string>>
    {
        public readonly string Url = "https://rozetka.com.ua/";

        public async Task<List<string>> StartParseAsync()
        {
            // Получаем документ для парсинга.
            var document = await GetDocumentFromUrlAsync(Url);

            // Получаем ссылки на все подкатегории, чтобы вытащить все товары.
            var allSubCategoriesUrls = await GetAllSubCategoriesUrlsAsync(document);


            foreach (var url in allSubCategoriesUrls)
            {
                // TODO: Код по запуску ParserWorker'a - здесь, но сначала написать реализации HtmlLoader, IParser, IParserSettings.
            } // foreach.

            // TODO: Убрать заглушку и вернуть результаты.
            return new List<string>();
        } // Parse.

        // Получаем HTML страницу.
        public async Task<IDocument> GetDocumentFromUrlAsync(string url)
        {
            WebClient webClient = new WebClient();

            string html = await webClient.DownloadStringTaskAsync(url);

            var context = BrowsingContext.New(Configuration.Default);

            var document = await context.OpenAsync(req => req.Content(html));

            return document;
        } // GetHtml.

        // Получаем категории.
        public List<string> GetCategoriesUrls(IDocument document, string className)
        {
            // Получаем все тэги <a></a>, в которых содержится атрибут href, который отсылает на страницу с подкатегориями.
            var links = document.GetElementsByClassName(className);

            var urls = new List<string>(); 

            foreach (var item in links)
            {
                urls.Add(item.GetAttribute("href"));
            } // foreach.

            return urls;
        } // GetCategoriesUrls.

        // Метод для получения всех подкатегорий.
        public async Task<List<string>> GetAllSubCategoriesUrlsAsync(IDocument document)
        {
            var categoriesUrls = GetCategoriesUrls(document, "menu-categories__link");

            var allSubcategories = new List<string>();

            foreach (var categoriesUrl in categoriesUrls)
            {
                var categoryDocument = await GetDocumentFromUrlAsync(categoriesUrl);

                var subCategoriesUrls = GetCategoriesUrls(categoryDocument, "tile-cats__picture");

                allSubcategories.AddRange(subCategoriesUrls);
            } // foreach.

            return allSubcategories;
        } // GetAllSubcategoriesUrl.
    } // RozetkaParserStarter.
}
