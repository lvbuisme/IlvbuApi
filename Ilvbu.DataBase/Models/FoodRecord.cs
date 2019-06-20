using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ilvbu.DataBase.Models
{
    public class FoodRecord
    {
        [Key]
        public int Id { get; set; }
        public int UserId  { get; set; }
        [MaxLength(64)]
        public string FoodName { get; set; }
        public DateTime CreateTime { get; set; }

        [ForeignKey("UserId")]
        public UserInfo UserInfo { get; set; }
    }
}
