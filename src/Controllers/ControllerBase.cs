using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FollowersPark.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private string userId = string.Empty;

        /// <summary>
        /// Current user id
        /// </summary>
        public string UserId
        {
            get
            {
                if (string.IsNullOrEmpty(userId))
                    userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

                return userId;
            }
        }
    }
}