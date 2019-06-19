using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Contexts;

namespace Ilvbu.Service
{
    public class AuthTokenFilter : IApiActionFilter
    {
        private string _tokenName = "Authorization";
        public string TokenName
        {
            get { return _tokenName; }
            set { _tokenName = value; }
        }

        private string _tokenString;

        public AuthTokenFilter(string tokenString)
        {
            _tokenString = tokenString;
        }

        public Task OnBeginRequestAsync(ApiActionContext context)
        {
            if (!string.IsNullOrEmpty(_tokenString))
            {
                context.RequestMessage.Headers.Add(_tokenName, _tokenString);
            }
            return Task.FromResult<object>(null);
        }

        public Task OnEndRequestAsync(ApiActionContext context)
        {
            return Task.FromResult<object>(null);
        }
    }
}
