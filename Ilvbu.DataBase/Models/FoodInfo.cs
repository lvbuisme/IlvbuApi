using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ilvbu.DataBase.Models
{
    public class FoodInfo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(64)]
        public string FoodName { get; set; }
        [MaxLength(500)]
        public string ImagePath { get; set; }
    }
}
