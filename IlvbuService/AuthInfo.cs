using System;
using System.Collections.Generic;
using System.Text;

namespace IlvbuService
{
    public class AuthInfo
    {
        private int _userId;
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get { return _userId; } }

        private Token _token;
        /// <summary>
        /// 令牌
        /// </summary>
        public Token Token
        {
            get { return _token; }
            set { _token = value; }
        }


        protected AuthInfo(int userId,Token token)
        {
            _userId = userId;
            _token = token;
        }
    }
}
