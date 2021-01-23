using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HacatonUntitledTeam.Entities.Models;

namespace HacatonUntitledTeam.Services.Parser
{
    // TODO: Подумать над переименованием этого интерфейса.
    public interface IParserBySearchString
    {
        Task<List<Goods>> GetGoodsesBySearchStringAsync(string searchString);
    } // IParserBySearchString.
}
