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
        public async Task<IActionResult> Get()
        {
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ScheduleList schedules = await _scheduleService.GetAllSchedules();
            watch.Stop();
            schedules.TimeTaken = watch.ElapsedMilliseconds;
            return Ok(schedules);
        }

        // GET api/<ScheduleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Schedule schedule = await _scheduleService.GetSchedule(id);
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
        public async Task<IActionResult> Post([FromBody] Schedule schedule)
        {
            if (string.IsNullOrWhiteSpace(schedule.DutyName) || string.IsNullOrWhiteSpace(schedule.EmployeeName))
            {
                return BadRequest();
            }
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Schedule addedSchedule = await _scheduleService.AddSchedule(schedule);
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
        public async Task<IActionResult> Put(int id, [FromBody] Schedule schedule)
        {
            if (id < 0)
            {
                return BadRequest("Id cannot be less than 0.");
            }
            //ToDo: Validate the id first, return bad request/not found if Id doesn't exist.

            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int recordsUpdated = await _scheduleService.UpdateSchedule(id, schedule);
            watch.Stop();
            schedule.TimeTaken = watch.ElapsedMilliseconds;
            return Ok(schedule);
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int removedId = await _scheduleService.RemoveSchedule(id);
            watch.Stop();
            Schedule schedule = new Schedule() { ScheduleId = removedId, TimeTaken = watch.ElapsedMilliseconds };
            if (removedId == -1)
            {
                return StatusCode(500, schedule);
            }
            return Ok(schedule);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteByDate([FromBody] DateTime date)
        {
            //ToDo: Instead of adding the stopwatch code at every endpoint, add an
            //MVC filter and add the stopwatch code there along with exception handling.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int removedRecords = await _scheduleService.RemoveSchedule(date);
            watch.Stop();
            Schedule schedule = new Schedule() { ScheduleId = removedRecords, TimeTaken = watch.ElapsedMilliseconds };//Adding number of removed rows in ScheduleId as a workaround. Ideally this should be in logs
            return Ok(schedule);
        }
    }
}
