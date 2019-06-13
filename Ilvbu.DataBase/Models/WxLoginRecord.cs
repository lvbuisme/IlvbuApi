using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ilvbu.DataBase.Models
{
    public class WxLoginRecord
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(64)]
        public string OpenId { get; set; }
        [MaxLength(64)]
        public string SessionKey { get; set; }
        [MaxLength(64)]
        public string ExpiresIn { get; set; }
        [MaxLength(128)]
        public string Guid { get; set; }
    }
}
