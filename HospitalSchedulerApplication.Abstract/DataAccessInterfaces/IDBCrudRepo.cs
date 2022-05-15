using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.Abstract.DataAccessInterfaces
{
    public interface IDBCrudRepo
    {
        int ExecuteQuery(string query);
        DataTable ExecuteQuery(string query, string[] fields);
    }
}
