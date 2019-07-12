using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ilvbu.DataBase.Models
{
    public class RubbishType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(64)]
        public string RubbishTypeName { get; set; }

    }
}
