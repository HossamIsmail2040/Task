using System.Collections.Generic;
using System;

namespace Task.Application.UserCases.Login
{
    public class AccessTokenResponse
    {
        public string AccessToken { get; set; }
        public string Scope { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public List<string> Roles { get; set; }

        public string Email { get; set; }
        public string Message { get; set; }
    }
}
