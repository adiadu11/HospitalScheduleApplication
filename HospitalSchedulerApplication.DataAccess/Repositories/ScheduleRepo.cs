using HospitalModels.Models;
using HospitalSchedulerApplication.Abstract.DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.DataAccess.Repositories
{
    public class ScheduleRepo : IScheduleRepository
    {
        private readonly IDBCrudRepo _dBCrudRepo;
        public ScheduleRepo(IDBCrudRepo dBCrudRepo)
        {
            _dBCrudRepo = dBCrudRepo;
        }
        public bool AddSchedule(Schedule schedule)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                
                //This is my insert query in which i am taking input from the user through windows forms
                string query = "insert into schedule (dutyName, employeeName, dateOfDuty) values('" + schedule.DutyName + "','" + schedule.EmployeeName + "','" + schedule.DateOfDuty.ToString("yyyy-MM-dd") + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                return _dBCrudRepo.ExecuteQuery(query) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Schedule GetSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveSchedule(int id)
        {
            throw new NotImplementedException();
        }
        
        public Schedule UpdateSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
