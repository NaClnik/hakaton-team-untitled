using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Entities.Models
{
    // Класс описывающий товар
    public class Goods
    {

        //Ссылка на товар и одновременно ключ
        [Key]
        public Uri Uri { get; set; }

        //Название
        [Required]
        [MaxLength(200)]
        public string GoodsName { get; set; }

        //Мера
        public int MeasureId { get; set; }
        public virtual GoodsMeasure GoodsMeasure { get; set; }

        //Коллекция цен на товар
        public virtual ICollection<GoodsPrice> Prices { get; set; }

        //Конструктор по умолчаниюю
        public Goods()
        {
            Prices = new HashSet<GoodsPrice>();
        }//Goods

    }//class Goods
}
