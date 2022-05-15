using HospitalModels.Models;
using HospitalSchedulerApplication.Abstract.DataAccessInterfaces;
using HospitalSchedulerApplication.Abstract.ServiceInterfaces;
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
        public Schedule AddSchedule(Schedule schedule)
        {
            if(_scheduleRepo.AddSchedule(schedule))
            {
                //ToDo: Return the inserted schedule row with correct
                //schedule ID instead of the request model received.
                return schedule;
            }
            return null;
        }

        public List<Schedule> GetAllSchedules()
        {
            throw new NotImplementedException();
        }

        public Schedule GetSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public int RemoveSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public Schedule UpdateSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
