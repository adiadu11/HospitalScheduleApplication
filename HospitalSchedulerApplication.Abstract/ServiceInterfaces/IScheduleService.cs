using HospitalModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.Abstract.ServiceInterfaces
{
    public interface IScheduleService
    {
        Schedule AddSchedule(Schedule schedule);
        bool RemoveSchedule(int id);
        Schedule UpdateSchedule(Schedule schedule);
        Schedule GetSchedule(int id);
    }
}
