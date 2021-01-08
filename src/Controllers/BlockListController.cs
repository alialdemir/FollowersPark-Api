using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.BlockList;
using FollowersPark.Models.BlockList;
using FollowersPark.Models.PagedList;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace FollowersPark.Controllers
{
    public class BlockListController : ControllerBase
    {
        private readonly IBlockListRepository _blockListRepository;
        private readonly IMapper _mapper;

        public BlockListController(IBlockListRepository blockListRepository,
                                   IMapper mapper)
        {
            _blockListRepository = blockListRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Engellenen kullanıcı listesi
        /// </summary>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Engellenen kullanıcı listesi</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPagedList<BlockListModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get([FromQuery] Pageable pageable)
        {
            var result = _blockListRepository.GetBlockListByUserId(UserId, pageable);

            return Ok(result);
        }

        /// <summary>
        /// Engellenen kullanıcı listesi ekle
        /// </summary>
        /// <param name="model">Kullanıcı bilgisi</param>
        /// <returns>Engellenen kullanıcı</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BlockListModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Post([FromBody] BlockListModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var blockList = _mapper.Map<DataAccess.Tables.BlockList>(model);

            blockList.UserId = UserId;

            var result = _blockListRepository.Insert(blockList);

            blockList.BlockListId = result.BlockListId;

            return Ok(_mapper.Map<BlockListModel>(result));
        }

        /// <summary>
        /// Engellenen kullanıcı listesi güncelle
        /// </summary>
        /// <param name="model">Kullanıcı bilgisi</param>
        /// <returns>Engellenen kullanıcı </returns>
        [HttpPut("{blockListId}")]
        [ProducesResponseType(typeof(BlockListModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Put([FromRoute] int blockListId, [FromBody] BlockListModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_blockListRepository.Find(x => x.UserId == UserId && x.BlockListId == model.BlockListId).Any())
                return Forbid();

            var blockList = _mapper.Map<DataAccess.Tables.BlockList>(model);

            blockList.UserId = UserId;

            var result = _blockListRepository.Update(blockList);

            blockList.BlockListId = result.BlockListId;

            return Ok(_mapper.Map<BlockListModel>(result));
        }

        /// <summary>
        /// Engellenen kullanıcı listesi sil
        /// </summary>
        /// <param name="blockListId">Kullanıcı listesi id</param>
        [HttpDelete("{blockListId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete([FromRoute] int blockListId)
        {
            if (!_blockListRepository.Find(x => x.UserId == UserId && x.BlockListId == blockListId).Any())
                return Forbid();

            _blockListRepository.Delete(blockListId);

            return Ok();
        }
    }
}