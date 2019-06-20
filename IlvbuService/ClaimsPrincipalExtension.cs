using Ilvbu;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;

namespace IlvbuService
{
    public static class ClaimsPrincipalExtension
    {
        public static T ToAuthInfo<T>(this ClaimsPrincipal claimsPrincipal, Token token) where T : AuthInfo
        {
            if (claimsPrincipal == null) return null;
            Type type = typeof(T);
            return claimsPrincipal.Claims.ToAuthInfo<T>(token);
        }

        public static T ToAuthInfo<T>(this IEnumerable<Claim> claims, Token token) where T : AuthInfo
        {
            if (claims == null) return null;
            Type type = typeof(T);
            Dictionary<string, string> map = new Dictionary<string, string>();
            foreach (Claim claim in claims)
            {
                if (map.ContainsKey(claim.Type))
                {
                    map[claim.Type] += claim.Value;
                }
                else
                {
                    map.Add(claim.Type, claim.Value);
                }
            }

            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(Dictionary<string, string>), typeof(Token) });
            return (T)ctor.Invoke(new object[] { map, token });
        }

        public static T ToAuthInfo<T>(this Dictionary<string, string> map, Token token) where T : AuthInfo
        {
            if (map == null) return null;
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(Dictionary<string, string>), typeof(Token) });
            return (T)ctor.Invoke(new object[] { map, token });
        }

    }

}
 
