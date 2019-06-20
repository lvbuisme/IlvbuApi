using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ilvbu.DataBase.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(64)]
        public string OpenId  { get; set; }
        [MaxLength(128)]
        public string Password { get; set; }
        [MaxLength(128)]
        public string UserName { get; set; }
    }
}
