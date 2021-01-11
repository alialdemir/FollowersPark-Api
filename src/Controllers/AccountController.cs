using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.InstagramAccount;
using FollowersPark.DataAccess.EntityFramework.Repositories.Order;
using FollowersPark.DataAccess.Tables;
using FollowersPark.Models;
using FollowersPark.Models.InstagramAccount;
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
        private readonly IOrderRepository _orderRepository;
        private readonly IInstagramAccountRepository _instagramAccountRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly AppSettings _appSettings;

        public AccountController(UserManager<User> userManager,
                                 IMapper mapper,
                                 IOrderRepository orderRepository,
                                 IInstagramAccountRepository instagramAccountRepository,
                                 SignInManager<User> signInManager,
                                 IOptions<AppSettings> options)
        {
            _userManager = userManager;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _instagramAccountRepository = instagramAccountRepository;
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

            _orderRepository.Insert(new Order
            {
                UserId = user.Id,
                PricingId = 5,// free
                FinishDate = DateTime.UtcNow.AddDays(_appSettings.FreeDays),
                AccountsLimit = 1,
            });

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

        /// <summary>
        /// Instagram hesabı ekle/güncelle
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("instagram")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] InstagramAccountModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var account = _instagramAccountRepository.Find(x => x.InstagramId == model.InstagramId).FirstOrDefault();
            if (account == null)
            {
                var instagramAccount = _mapper.Map<InstagramAccount>(model);

                instagramAccount.UserId = UserId;

                _instagramAccountRepository.Insert(instagramAccount);
            }
            else
            {
                var updateInstagramAccount = _mapper.Map(model, account);

                _instagramAccountRepository.Update(updateInstagramAccount);
            }

            return Ok();
        }
    }
}