using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using HacatonUntitledTeam.Entities.Models;
using HacatonUntitledTeam.Services.Parser;
using HacatonUntitledTeam.Services.Parser.CurrentParsers.RozetkaParser;

namespace HacatonUntitledTeam.Services
{
    // Провайдер для предоставления распаршеных товаров.
    public class GoodsDataProvider
    {
        public async Task<List<Goods>> GetGoodsFromRozetka(string searchString)
        {
            IParserBySearchString parser = new RozetkaParserBySearchString();

            return await parser.GetGoodsesBySearchStringAsync(searchString);
        } // GetGoods.
    } // GoodsDataProvider.
}
