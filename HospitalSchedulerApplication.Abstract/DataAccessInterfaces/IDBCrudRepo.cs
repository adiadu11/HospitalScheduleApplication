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
        Task<int> ExecuteQuery(string query);
        Task<DataTable> ExecuteQuery(string query, string[] fields);
    }
}
