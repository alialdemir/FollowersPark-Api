using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.Order;
using FollowersPark.DataAccess.EntityFramework.Repositories.Task;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.Task;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace FollowersPark.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository,
                              IOrderRepository orderRepository,
                              IMapper mapper)
        {
            _taskRepository = taskRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Task listesi
        /// </summary>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Task listesi</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPagedList<TaskModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get([FromQuery] Pageable pageable)
        {
            var result = _taskRepository.GetTaskUserId(UserId, pageable);

            if (!_orderRepository.IsActive(UserId) && result.Items.Any(x => x.Status))
            {
                result
                    .Items
                    .Where(x => x.Status)
                    .ToList()
                    .ForEach(item =>
                    {
                        item.Status = false;

                        TaskStartStop(item.TaskId, item.Status);
                    });
            }

            return Ok(result);
        }

        /// <summary>
        /// Task listesi ekle
        /// </summary>
        /// <param name="model">Task bilgisi</param>
        /// <returns>Task</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TaskModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Post([FromBody] TaskModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_orderRepository.IsActive(UserId))
                return BadRequest("You do not have active accounts.");

            var task = _mapper.Map<DataAccess.Tables.Task>(model);

            task.UserId = UserId;

            var result = _taskRepository.Insert(task);

            task.TaskId = result.TaskId;

            return Ok(_mapper.Map<TaskModel>(task));
        }

        [HttpPut("{taskId}")]
        [ProducesResponseType(typeof(TaskModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update([FromRoute] int taskId, TaskUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_orderRepository.IsActive(UserId))
                return BadRequest("You do not have active accounts.");

            if (!_taskRepository.Find(x => x.UserId == UserId && x.TaskId == taskId).Any())
                return Forbid();

            var task = _taskRepository.Find(x => x.TaskId == taskId).FirstOrDefault();
            if (task == null)
                return NotFound();

            task.NumberTransactions = model.NumberTransactions;

            var result = _taskRepository.Update(task);

            return Ok(_mapper.Map<TaskModel>(result));
        }

        /// <summary>
        /// Task başlat
        /// </summary>
        /// <param name="taskId">Task id</param>
        [HttpPut("{taskId}/start")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult TaskStart([FromRoute] int taskId)
        {
            if (!_orderRepository.IsActive(UserId))
                return BadRequest("You do not have active accounts.");

            return TaskStartStop(taskId, true);
        }

        /// <summary>
        /// Task stop
        /// </summary>
        /// <param name="taskId">Task id</param>
        [HttpPut("{taskId}/stop")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult TaskStop([FromRoute] int taskId)
        {
            return TaskStartStop(taskId, false);
        }

        /// <summary>
        /// Task id'ye göre status true false yapar
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="status">Task status</param>
        /// <returns>Action result
        /// </returns>
        private IActionResult TaskStartStop(int taskId, bool status)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_taskRepository.Find(x => x.UserId == UserId && x.TaskId == taskId).Any())
                return Forbid();

            var task = _taskRepository.Find(x => x.TaskId == taskId).FirstOrDefault();
            if (task == null)
                return NotFound();

            task.Status = status;

            var result = _taskRepository.Update(task);

            return Ok();
        }

        /// <summary>
        /// Task listesi sil
        /// </summary>
        /// <param name="taskId">Task id</param>
        [HttpDelete("{taskId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete([FromRoute] int taskId)
        {
            if (!_taskRepository.Find(x => x.UserId == UserId && x.TaskId == taskId).Any())
                return Forbid();

            _taskRepository.Delete(taskId);

            return Ok();
        }
    }
}