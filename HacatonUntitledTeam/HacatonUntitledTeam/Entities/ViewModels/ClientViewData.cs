using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HacatonUntitledTeam.Entities.Models;

namespace HacatonUntitledTeam.Entities.ViewModels
{
    public class ClientViewData
    {
        // uri товара
        public Uri GoodsUri { get; set; }

        // название товара
        public string GoodsName { get; set; }

        // мера товара
        public string Measure { get; set; }

        // Коллекция изменения цен товара
        public ICollection<GoodsPrice> GoodsPrices { get; set; }

        // Ссылка на магазин
        public Uri SiteUri { get; set; }

        // Название магазина
        public string SiteName { get; set; }

        public ClientViewData() { }
        public ClientViewData(Store store, Goods goods)
        {
            GoodsUri = goods.Uri;
            GoodsName = goods.GoodsName;
            Measure = goods.GoodsMeasure.Measure;
            GoodsPrices = goods.Prices;
            SiteUri = store.Uri;
            SiteName = store.StoreName;
        }//ClientViewData

    }
}
