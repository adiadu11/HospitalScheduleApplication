using HospitalSchedulerApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.Abstract.ServiceInterfaces
{
    public interface IScheduleService
    {
        Task<Schedule> AddSchedule(Schedule schedule);
        Task<int> RemoveSchedule(int id);
        Task<int> RemoveSchedule(DateTime date);
        Task<Schedule> UpdateSchedule(Schedule schedule);
        Task<Schedule> GetSchedule(int id);
        Task<ScheduleList> GetAllSchedules();
    }
}
