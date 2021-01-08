using FollowersPark.DataAccess.EntityFramework.Repositories.Pricing;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.Pricing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace FollowersPark.Controllers
{
    public class PricingController : ControllerBase
    {
        private readonly IPricingRepository _pricingRepository;

        public PricingController(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        /// <summary>
        /// Fiyat listesi
        /// </summary>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Fiyat listesi</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPagedList<PricingModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] Pageable pageable)
        {
            var result = _pricingRepository.GetPricing(pageable);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Post([FromBody] OrderModel order)
        {
            string password = "Secret Passphrase";
            string fullName = Decrypt(order.Fullname);
            string cardNumber = Decrypt(order.CardNumber);
            string year = Decrypt(order.Year);
            string month = Decrypt(order.Month);
            string securityCode = Decrypt(order.SecurityCode);

            return Ok();
        }

        public static string Decrypt(string cipherText)
        {
            Aes encryptor = Aes.Create();
            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;
            // Set key and IV
            encryptor.Key = System.Convert.FromBase64String("6fa979f20126cb08aa645a8f495f6d85");
            encryptor.IV = System.Convert.FromBase64String("1");

            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            string plainText = String.Empty;

            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] plainBytes = memoryStream.ToArray();
                plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }
            return plainText;
        }
    }
}