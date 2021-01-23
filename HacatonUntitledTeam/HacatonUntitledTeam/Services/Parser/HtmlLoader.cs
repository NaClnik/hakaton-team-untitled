using System.Net.Http;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Services.Parser
{
    public abstract class HtmlLoader
    {
        // Поля класса.
        protected readonly HttpClient _client;
        protected readonly IParserSettings _parserSettings;

        // Свойства класса.
        public string Url { get; set; }

        protected HtmlLoader(HttpClient client, IParserSettings parserSettings)
        {
            _client = client;
            _parserSettings = parserSettings;
        } // ctor.

        // Абстрактные методы.
        public abstract Task<string> GetSourceByPageIdAsync(int id);

    } // IHtmlLoader.
}
