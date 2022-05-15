using HospitalModels.Models;
using HospitalSchedulerApplication.Abstract.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalSchedulerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        // GET: api/<ScheduleController>
        [HttpGet]
        public List<Schedule> Get()
        {
            return _scheduleService.GetAllSchedules();
        }

        // GET api/<ScheduleController>/5
        [HttpGet("{id}")]
        public Schedule Get(int id)
        {
            return _scheduleService.GetSchedule(id);
        }

        // POST api/<ScheduleController>
        [HttpPost]
        public Schedule Post([FromBody] Schedule schedule)
        {
            return _scheduleService.AddSchedule(schedule);
        }

        // PUT api/<ScheduleController>/5
        [HttpPut("{id}")]
        public Schedule Put(int id, [FromBody] Schedule schedule)
        {
            return _scheduleService.UpdateSchedule(schedule);
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _scheduleService.RemoveSchedule(id);
        }
    }
}
