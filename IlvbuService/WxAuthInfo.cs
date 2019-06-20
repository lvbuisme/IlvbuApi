using System;
using System.Collections.Generic;
using System.Text;

namespace IlvbuService
{
    public class WxAuthInfo :AuthInfo
    {
        protected WxAuthInfo(int userId,Token token)
        : base(userId, token)
        {

        }

        public string OpenId { get; set; }
    }
}
