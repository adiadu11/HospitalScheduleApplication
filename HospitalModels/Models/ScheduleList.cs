using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.Models.Models
{
    public class ScheduleList
    {
        public List<Schedule> schedules { get; set; }

        //ToDo: Ideally, this should be in logs. Remove this property when logs are added.
        public long TimeTaken { get; set; }
    }
}
