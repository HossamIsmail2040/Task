using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Task.Common
{
    public static class Helpers
    {
        public static string GetUserId(string token)
        {
            //var token = Request.Headers["UserId"].ToString();
            var userId = GetValue(token, "id");
            return userId;
        }

        private static string GetValue(string token, string propertyType)
        {
            if (string.IsNullOrEmpty(token))
                return null;
            string splitted = token.Split(" ")[1];
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken tokenS = handler.ReadToken(splitted) as JwtSecurityToken;
            string propertyValue = tokenS.Claims.FirstOrDefault(a => a.Type.Contains(propertyType))?.Value;
            return propertyValue;
        }
    }
}
