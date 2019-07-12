using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ilvbu.DataBase.Models
{
    public class Rubbish
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(64)]
        public string RubbishName { get; set; }
        public int RubbishTypeId { get; set; }
        [ForeignKey("RubbishTypeId")]
        public RubbishType RubbishType { get; set; }

    }
}
