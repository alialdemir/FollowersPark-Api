using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.Log;
using FollowersPark.Models.Log;
using FollowersPark.Models.PagedList;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace FollowersPark.Controllers
{
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public LogController(ILogRepository logRepository,
                             IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Log listesi
        /// </summary>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Log listesi</returns>
        [HttpGet("Task/{taskId}")]
        [ProducesResponseType(typeof(IPagedList<LogModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get([FromRoute] int taskId, [FromQuery] Pageable pageable)
        {
            var result = _logRepository.GetLogByUserId(UserId, taskId, pageable);

            return Ok(result);
        }

        /// <summary>
        /// Log listesi ekle
        /// </summary>
        /// <param name="model">Log bilgisi</param>
        /// <returns>Log</returns>
        [HttpPost]
        [ProducesResponseType(typeof(LogModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Post([FromBody] LogModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var log = _mapper.Map<DataAccess.Tables.Log>(model);

            log.UserId = UserId;

            var result = _logRepository.Insert(log);

            return Ok(_mapper.Map<LogModel>(result));
        }

        /// <summary>
        /// Log listesi sil
        /// </summary>
        /// <param name="logId">Log id</param>
        [HttpDelete("{logId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete([FromRoute] int logId)
        {
            if (!_logRepository.Find(x => x.UserId == UserId && x.LogId == logId).Any())
                return Forbid();

            _logRepository.Delete(logId);

            return Ok();
        }
    }
}