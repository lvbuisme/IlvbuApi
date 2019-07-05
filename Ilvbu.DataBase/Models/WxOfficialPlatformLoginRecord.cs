using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ilvbu.DataBase.Models
{
    public class WxOfficialPlatformLoginRecord
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128)]
        public string Signature { get; set; }
        [MaxLength(128)]
        public string Timestamp { get; set; }
        [MaxLength(128)]
        public string Nonce { get; set; }
        [MaxLength(128)]
        public string Echostr { get; set; }


        [MaxLength(1000)]
        public string PostData { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
