using Ilvbu;
using Ilvbu.Auth;
using Ilvbu.DataBase;
using Ilvbu.DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IlvbuService
{
    public class WxAccountController : Controller
    {
        //private WxAuthInfo _wxAuthInfo;
        //public WxAuthInfo WxAuthInfo
        //{
        //    get {

        //        return _wxAuthInfo;
        //    }
        //    set
        //    {
        //        if (_wxAuthInfo== null)
        //        {
        //            _wxAuthInfo = this.User.ToAuthInfo<WxAuthInfo>(null);
        //        }
        //    }
        //}
        private MyDbContext _context;
        public WxAccountController(MyDbContext context)
        {
            _context = context;
        }
        private string _token;
        private User _user;
        public string Token
        {
            get
            {
                if (string.IsNullOrEmpty(_token))
                {
                    _token = HttpContext.GetToken();
                   
                }
                return _token;
            }
        }
        public User User
        {
            get
            {
                return null;
                if (_user == null)
                {
                    _user = _context.WxLoginRecord.Include(c => c.UserInfo).Where(c => c.Guid.Equals(Token)).Select(c => new User()
                    {
                        OpendId = c.UserInfo.OpenId,
                        UserId = c.UserInfo.Id,
                        UserName = c.UserInfo.UserName

                    }).FirstOrDefault();
                }
                return _user;
            }
        }


    }
}
