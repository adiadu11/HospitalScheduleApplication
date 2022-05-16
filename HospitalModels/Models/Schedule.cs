using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.Models.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        //ToDo: Create Duty Table and introduce this field
        //public int DutyId { get; set; }+
        public string DutyName { get; set; }
        //ToDo: Create Employee Table and introduce this field
        //public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfDuty { get; set; }

        //ToDo: Ideally, this should be in logs. Remove this property when logs are added.
        public long TimeTaken { get; set; }

        //ToDo: Add these fields later.
        //public TimeOnly DutyStartTime { get; set; }
        //public TimeOnly DutyEndTime { get; set; }
    }
}
