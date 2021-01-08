using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.DirectMessage;
using FollowersPark.Models.DirectMessage;
using FollowersPark.Models.PagedList;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace FollowersPark.Controllers
{
    public class DirectMessageController : ControllerBase
    {
        private readonly IDirectMessageRepository _directMessageRepository;
        private readonly IMapper _mapper;

        public DirectMessageController(IDirectMessageRepository directMessageRepository,
                                       IMapper mapper)
        {
            _directMessageRepository = directMessageRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Direct message list
        /// </summary>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Direct message list</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPagedList<DirectMessageModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get([FromQuery] Pageable pageable)
        {
            var result = _directMessageRepository.GetDirectMessageByUserId(UserId, pageable);

            return Ok(result);
        }

        /// <summary>
        /// Direct message list ekle
        /// </summary>
        /// <param name="model">Direct message info</param>
        /// <returns>Direct message</returns>
        [HttpPost]
        [ProducesResponseType(typeof(DirectMessageModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Post([FromBody] DirectMessageModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var directMessage = _mapper.Map<DataAccess.Tables.DirectMessage>(model);

            directMessage.UserId = UserId;

            var result = _directMessageRepository.Insert(directMessage);

            return Ok(_mapper.Map<DirectMessageModel>(result));
        }

        /// <summary>
        /// Direct message list güncelle
        /// </summary>
        /// <param name="model">Direct message list info</param>
        /// <returns>Direct message </returns>
        [HttpPut("{directMessageId}")]
        [ProducesResponseType(typeof(DirectMessageModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Put([FromRoute] int directMessageId, [FromBody] DirectMessageModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_directMessageRepository.Find(x => x.UserId == UserId && x.DirectMessageId == model.DirectMessageId).Any())
                return Forbid();

            var directMessage = _mapper.Map<DataAccess.Tables.DirectMessage>(model);

            directMessage.UserId = UserId;

            var result = _directMessageRepository.Update(directMessage);

            return Ok(_mapper.Map<DirectMessageModel>(result));
        }

        /// <summary>
        /// Direct message list sil
        /// </summary>
        /// <param name="directMessageId">Direct message list id</param>
        [HttpDelete("{directMessageId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Delete([FromRoute] int directMessageId)
        {
            if (!_directMessageRepository.Find(x => x.UserId == UserId && x.DirectMessageId == directMessageId).Any())
                return Forbid();

            _directMessageRepository.Delete(directMessageId);

            return Ok();
        }
    }
}