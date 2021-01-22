using System.Net.Http;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Services.Parser
{
    public abstract class HtmlLoader
    {
        // Поля класса.
        protected readonly HttpClient _client;
        protected readonly IParserSettings _parserSettings;

        protected HtmlLoader(HttpClient client, IParserSettings parserSettings)
        {
            _client = client;
            _parserSettings = parserSettings;
        } // ctor.

        // Абстрактные методы.
        public abstract int Url { get; }
        public abstract Task<string> GetSourceByPageId(int id);

    } // IHtmlLoader.
}
