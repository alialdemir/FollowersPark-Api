using AutoMapper;
using FollowersPark.DataAccess.Tables;
using FollowersPark.Models;
using FollowersPark.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FollowersPark.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly AppSettings _appSettings;

        public AccountController(UserManager<User> userManager,
                                 IMapper mapper,
                                 SignInManager<User> signInManager,
                                 IOptions<AppSettings> options)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _appSettings = options.Value;
        }

        /// <summary>
        /// Yeni kullanıcı ekle
        /// </summary>
        /// <param name="model">Üye olan kullanıcı bilgileri</param>
        /// <returns>Kayıt edilen kullanıcı bilgileri</returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            var user = _mapper.Map<User>(model);

            user.UserName = model.Email;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = result
                                .Errors
                                .Select(x => x.Description)
                                .ToList();

                return BadRequest(errors);
            }

            return Ok();
        }

        /// <summary>
        /// Giriş yap
        /// </summary>
        /// <param name="model">Giriş bilgileri</param>
        /// <returns>Token bilgisi</returns>
        [AllowAnonymous]
        [HttpPost("token")]
        [ProducesResponseType(typeof(TokenModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Token([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
                return BadRequest("UsernameOrPasswordIsIncorrect");

            var appUser = _userManager.Users.SingleOrDefault(r => r.NormalizedEmail == model.Email.ToUpperInvariant());
            if (appUser == null || !appUser.LockoutEnabled)
                return BadRequest("TheUsernameYouEnteredBoesntBelongtoAnAccountPleaseCheckYourUsernameAndTryAgain");

            var token = GenerateJwtToken(appUser);
            return Ok(token);
        }

        /// <summary>
        /// Jwt token oluştur
        /// </summary>
        /// <param name="user">Giriş yapan kullanıcı</param>
        /// <returns>Token bilgisi</returns>
        private TokenModel GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var expires = DateTime.Now.AddDays(Convert.ToDouble(_appSettings.JwtExpireDays));

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtKey));
            var signInCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(issuer: _appSettings.JwtIssuer,
                                           audience: _appSettings.JwtIssuer,
                                           claims: claims,
                                           signingCredentials: signInCredentials,
                                           expires: expires);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenModel
            {
                Token = encodedJwt,
                ExpiresIn = expires,
                Email = user.Email,
            };
        }
    }
}