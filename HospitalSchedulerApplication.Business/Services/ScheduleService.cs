using HospitalSchedulerApplication.Abstract.DataAccessInterfaces;
using HospitalSchedulerApplication.Abstract.ServiceInterfaces;
using HospitalSchedulerApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.Business.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepo;
        public ScheduleService(IScheduleRepository scheduleRepo)
        {
            _scheduleRepo = scheduleRepo;
        }
        public async Task<Schedule> AddSchedule(Schedule schedule)
        {
            if(await _scheduleRepo.AddSchedule(schedule))
            {
                //ToDo: Return the inserted schedule row with correct
                //schedule ID instead of the request model received.
                return schedule;
            }
            return new Schedule() { ScheduleId = -1};
        }

        public async Task<ScheduleList> GetAllSchedules()
        {
            return await _scheduleRepo.GetAllSchedules();
        }

        public async Task<Schedule> GetSchedule(int id)
        {
            return await _scheduleRepo.GetSchedule(id);
        }

        public async Task<int> RemoveSchedule(int id)
        {
            if (await _scheduleRepo.RemoveSchedule(id))
            {
                return id;
            }
            return -1;
        }

        public async Task<int> RemoveSchedule(DateTime date)
        {
            return await _scheduleRepo.RemoveSchedule(date);
        }

        public Task<Schedule> UpdateSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
