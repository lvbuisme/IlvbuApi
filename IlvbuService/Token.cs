﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IlvbuService
{
    public class Token
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
    }
}
