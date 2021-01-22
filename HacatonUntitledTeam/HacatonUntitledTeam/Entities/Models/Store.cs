using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Entities.Models
{
    //Класс для описания магазина
    public class Store
    {
        //Ссылка на магазин
        [Key]
        public Uri Uri { get; set; }

        //Название магазина
        [Required]
        [MaxLength(60)]
        public string StoreName { get; set; }

        //Товары магазина
        public virtual ICollection<Goods> Goods { get; set; }

        //Конструктор по умолчанию
        public Store()
        {
            Goods = new HashSet<Goods>();
        }//Store

    }//class Store
}
