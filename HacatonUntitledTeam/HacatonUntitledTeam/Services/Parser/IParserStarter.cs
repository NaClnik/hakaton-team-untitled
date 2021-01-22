using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Services.Parser
{
    public interface IParserStarter<T> where T : class
    {
        // Этот метод должен полностью парсить сайт.
        Task<T> StartParseAsync();
    }
}
