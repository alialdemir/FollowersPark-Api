using FollowersPark.Models.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace FollowersPark.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
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

        public BadRequestObjectResult BadRequest(object error)
        {
            if (error is string)
            {
                return base.BadRequest(new ErrorModel(error.ToString()));
            }
            else if (error is IEnumerable<string>)
            {
                return base.BadRequest(new ErrorModel((IEnumerable<string>)error));
            }

            return base.BadRequest(error);
        }
    }
}