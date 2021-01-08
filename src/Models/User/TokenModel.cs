using System;

namespace FollowersPark.Models.User
{
    public class TokenModel
    {
        public string Email { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string Token { get; set; }
        public string Type { get; } = "Bearer";
    }
}