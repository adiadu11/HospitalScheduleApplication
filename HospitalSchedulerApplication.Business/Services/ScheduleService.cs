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
        public Schedule AddSchedule(Schedule schedule)
        {
            if(_scheduleRepo.AddSchedule(schedule))
            {
                //ToDo: Return the inserted schedule row with correct
                //schedule ID instead of the request model received.
                return schedule;
            }
            return new Schedule() { ScheduleId = -1};
        }

        public ScheduleList GetAllSchedules()
        {
            return _scheduleRepo.GetAllSchedules();
        }

        public Schedule GetSchedule(int id)
        {
            return _scheduleRepo.GetSchedule(id);
        }

        public int RemoveSchedule(int id)
        {
            if (_scheduleRepo.RemoveSchedule(id))
            {
                return id;
            }
            return -1;
        }

        public Schedule UpdateSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
