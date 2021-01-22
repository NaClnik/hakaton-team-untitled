using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Entities.Models
{
    // Класс для описания меры
    public class GoodsMeasure
    {
        //Ид меры
        [Key]
        public int Id { get; set; }

        //Мера
        [Required]
        [MaxLength(30)]
        public string Measure { get; set; }

    }//class GoodsMeasure
}
