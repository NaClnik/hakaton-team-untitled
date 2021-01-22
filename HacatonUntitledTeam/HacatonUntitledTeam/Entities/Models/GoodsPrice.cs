using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Entities.Models
{
    //Класс для описания изменения цена на определенный товар
    public class GoodsPrice
    {
        // Ид цены
        [Key]
        public int Id { get; set; }

        //Цена за дату
        [Required]
        public double Price { get; set; }

        //Дата обновления цены
        [Required]
        public DateTime DateTime { get; set; }

        //Ссылка на товар
        public int GoodsId { get; set; }
        public virtual Goods Goods { get; set; }
    }//class GoodsPrice
}
