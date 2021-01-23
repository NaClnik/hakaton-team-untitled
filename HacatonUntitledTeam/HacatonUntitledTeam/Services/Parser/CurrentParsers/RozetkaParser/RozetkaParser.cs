using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;
using HacatonUntitledTeam.Entities.Models;

namespace HacatonUntitledTeam.Services.Parser.CurrentParsers.RozetkaParser
{
    public class RozetkaParser : IParser<List<Goods>>
    {
        public List<Goods> Parse(IDocument document)
        {
            // Коллекция, в которую будем записывать все распаршеные товары.
            List<Goods> goodses = new List<Goods>();

            // Получаем все карточки товаров.
            var goodsesCards = document.GetElementsByClassName("goods-tile");

            foreach (var card in goodsesCards)
            {
                // Получаем заголовок карточки.
                var cardHeader = card.GetElementsByClassName("goods-tile__heading")[0];

                // Достаём URI на товар.
                var href = cardHeader.GetAttribute("href");

                // Достаём название товара.
                var title = cardHeader.GetAttribute("title");

                // Получаем цену товара в строке.
                var priceString = card.GetElementsByClassName("goods-tile__price-value")[0]
                    .TextContent;

                // Преобразуем строку в int.
                var price = int.Parse(string.Join("", priceString.Where(char.IsDigit)));

                // TODO: Придумать, как распарсить меру.
                // Создаём новый товар.
                Goods goods = new Goods
                {
                    Uri = new Uri(href),
                    GoodsMeasure = new GoodsMeasure(),
                    GoodsName = title,
                    Prices = new List<GoodsPrice>() {new GoodsPrice() {DateTime = DateTime.Now, Price = price}}
                }; // goods.

                // Добавляем в коллекцию.
                goodses.Add(goods);
            } // foreach.

            return goodses;
        } // Parse.
    }
}
