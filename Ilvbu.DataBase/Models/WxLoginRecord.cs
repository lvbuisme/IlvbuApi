﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ilvbu.DataBase.Models
{
    public class WxLoginRecord
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [MaxLength(64)]
        public string SessionKey { get; set; }
        [MaxLength(64)]
        public string ExpiresIn { get; set; }
        [MaxLength(128)]
        public string Guid { get; set; }

        [ForeignKey("UserId")]
        public UserInfo UserInfo { get; set; }
    }
}
