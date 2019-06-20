using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.Interface.DbModels
{
    public class FoodRecordData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FoodName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
