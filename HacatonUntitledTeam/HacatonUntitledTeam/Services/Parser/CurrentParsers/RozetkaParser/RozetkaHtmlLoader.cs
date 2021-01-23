using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Services.Parser.CurrentParsers.RozetkaParser
{
    public class RozetkaHtmlLoader : HtmlLoader
    {
        public RozetkaHtmlLoader(HttpClient client, IParserSettings parserSettings) : base(client, parserSettings)
        {
            string baseUrl = parserSettings.BaseUrl;

            Url = $"{baseUrl}{parserSettings.Prefix}";
        }

        public override async Task<string> GetSourceByPageIdAsync(int id)
        {
            // Получаем новый URI для перехода на другую страницу.
            var currentUrl = Url.Replace("{CurrentId}", id.ToString());

            // Получаем response.
            var response = await _client.GetAsync(currentUrl);
            string source = string.Empty;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                // Получаем html страницу.
                source = await response.Content.ReadAsStringAsync();
            } // if.

            return source;
        } // GetSourceByPageIdAsync.
    } // RozetkaHtmlLoader.
}
