using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.UserList;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace FollowersPark.Controllers
{
    public class UserListController : ControllerBase
    {
        private readonly IUserListRepository _userListRepository;
        private readonly IMapper _mapper;

        public UserListController(IUserListRepository userListRepository,
                                  IMapper mapper)
        {
            _userListRepository = userListRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Kullanıcı listesi
        /// </summary>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Kullanıcı listesi</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPagedList<UserListModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get([FromQuery] Pageable pageable)
        {
            var result = _userListRepository.GetUserListByUserId(UserId, pageable);

            return Ok(result);
        }

        /// <summary>
        /// Kullanıcı listesi ekle
        /// </summary>
        /// <param name="model">Kullanıcı bilgisi</param>
        /// <returns>Kullanıcı </returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserListModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Post([FromBody] UserListModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userList = _mapper.Map<DataAccess.Tables.UserList>(model);

            userList.UserId = UserId;

            var result = _userListRepository.Insert(userList);

            return Ok(_mapper.Map<UserListModel>(result));
        }

        /// <summary>
        /// Kullanıcı listesi güncelle
        /// </summary>
        /// <param name="model">Kullanıcı bilgisi</param>
        /// <returns>Kullanıcı </returns>
        [HttpPut("{userListId}")]
        [ProducesResponseType(typeof(UserListModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Put([FromRoute] int userListId, [FromBody] UserListModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_userListRepository.Find(x => x.UserId == UserId && x.UserListId == model.UserListId).Any())
                return Forbid();

            var userList = _mapper.Map<DataAccess.Tables.UserList>(model);

            userList.UserId = UserId;

            var result = _userListRepository.Update(userList);

            return Ok(_mapper.Map<UserListModel>(result));
        }

        /// <summary>
        /// Kullanıcı listesi sil
        /// </summary>
        /// <param name="userListId">Kullanıcı listesi id</param>
        [HttpDelete("{userListId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete([FromRoute] int userListId)
        {
            if (!_userListRepository.Find(x => x.UserId == UserId && x.UserListId == userListId).Any())
                return Forbid();

            _userListRepository.Delete(userListId);

            return Ok();
        }
    }
}