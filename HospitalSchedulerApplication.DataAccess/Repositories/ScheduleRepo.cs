﻿using HospitalSchedulerApplication.Abstract.DataAccessInterfaces;
using HospitalSchedulerApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.DataAccess.Repositories
{
    public class ScheduleRepo : IScheduleRepository
    {
        private readonly IDBCrudRepo _dBCrudRepo;
        private readonly string[] fields;
        public ScheduleRepo(IDBCrudRepo dBCrudRepo)
        {
            _dBCrudRepo = dBCrudRepo;
            fields = new string[] { "scheduleId", "dutyName", "employeeName", "dateOfDuty" };
        }
        public bool AddSchedule(Schedule schedule)
        {
            try
            {
                string query = "insert into schedule (dutyName, employeeName, dateOfDuty) values('" + schedule.DutyName + "','" + schedule.EmployeeName + "','" + schedule.DateOfDuty.ToString("yyyy-MM-dd") + "');";
                return _dBCrudRepo.ExecuteQuery(query) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ScheduleList GetAllSchedules()
        {
            try
            {
                string query = "select * from schedule;";
                DataTable table = _dBCrudRepo.ExecuteQuery(query, fields);
                List<Schedule> schedules = GetListFromDataTable(table);
                return new ScheduleList() { schedules = schedules };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Schedule GetSchedule(int id)
        {
            try
            {
                string query =  $"select * from schedule where scheduleId = {id};";
                DataTable table = _dBCrudRepo.ExecuteQuery(query, fields);
                List<Schedule> schedules = GetListFromDataTable(table);
                return schedules.Count > 0 ? schedules.First() : new Schedule() { ScheduleId = -1 };
            }
            catch (Exception ex)
            {
                return new Schedule() { ScheduleId = -1};
            }
        }

        public bool RemoveSchedule(int id)
        {
            try
            {
                string query = $"delete from schedule where scheduleId = {id};";
                return _dBCrudRepo.ExecuteQuery(query) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public Schedule UpdateSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        private List<Schedule> GetListFromDataTable(DataTable table)
        {
            List<Schedule> schedules = new List<Schedule>();
            foreach (DataRow row in table.Rows)
            {
                Schedule schedule = new Schedule();
                schedule.ScheduleId = int.Parse(row.Field<string>("scheduleId"));
                schedule.DutyName = row.Field<string>("dutyName");
                schedule.EmployeeName = row.Field<string>("employeeName");
                schedule.DateOfDuty = DateTime.Parse(row.Field<string>("dateOfDuty"));

                schedules.Add(schedule);
            }
            return schedules;
        }
    }
}
