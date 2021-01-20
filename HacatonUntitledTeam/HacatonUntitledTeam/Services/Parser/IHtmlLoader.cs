using System.Net.Http;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Services.Parser
{
    public abstract class HtmlLoader
    {
        // Поля класса.
        protected readonly HttpClient _client;
        protected readonly string _url;

        protected HtmlLoader(HttpClient client, IParserSettings settings)
        {
            // TODO: Подумать, куда это всунуть.
            _client = client;
        } // ctor.

        public abstract Task<string> GetSourceByPageId(int id);
    } // IHtmlLoader.
}
