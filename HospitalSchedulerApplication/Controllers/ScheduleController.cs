using HospitalSchedulerApplication.Abstract.ServiceInterfaces;
using HospitalSchedulerApplication.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalSchedulerApplication.Controllers
{
    //ToDo: Add validations.

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
        public IActionResult Get()
        {
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ScheduleList schedules = _scheduleService.GetAllSchedules();
            watch.Stop();
            schedules.TimeTaken = watch.ElapsedMilliseconds;
            return Ok(schedules);
        }

        // GET api/<ScheduleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Schedule schedule = _scheduleService.GetSchedule(id);
            watch.Stop();
            schedule.TimeTaken = watch.ElapsedMilliseconds;
            if (schedule == null || schedule.ScheduleId == -1)
            {
                return NotFound(schedule);
            }
            return Ok(schedule);
        }

        // POST api/<ScheduleConroller>
        [HttpPost]
        public IActionResult Post([FromBody] Schedule schedule)
        {
            if (string.IsNullOrWhiteSpace(schedule.DutyName) || string.IsNullOrWhiteSpace(schedule.EmployeeName))
            {
                return BadRequest();
            }
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Schedule addedSchedule = _scheduleService.AddSchedule(schedule);
            watch.Stop();
            addedSchedule.TimeTaken = watch.ElapsedMilliseconds;
            if (addedSchedule.ScheduleId == -1)
            {
                return StatusCode(500, addedSchedule);
            }
            //ToDo: Get URL from SessionContext object and add it here and append the created record ID.
            return Created("", addedSchedule);
        }

        // PUT api/<ScheduleController>/5
        [HttpPut("{id}")]
        public Schedule Put(int id, [FromBody] Schedule schedule)
        {
            //Not Implemented.
            throw new NotImplementedException();
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int removedId = _scheduleService.RemoveSchedule(id);
            watch.Stop();
            Schedule schedule = new Schedule() { ScheduleId = removedId, TimeTaken = watch.ElapsedMilliseconds };
            if (removedId == -1)
            {
                return StatusCode(500, schedule);
            }
            return Ok(schedule);
        }
    }
}
