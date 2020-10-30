using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Employee : ControllerBase
    {
        
        //获取所有员工信息
        [HttpGet]
        public ActionResult<Employee> Get()
        {
           
            string sql = "SELECT * FROM Employee_Table";
            MySqlCommand mySql = new MySqlCommand(sql);

            MySqlDataReader reader = null;
            DBLink.mySqlOpen();

            reader = mySql.ExecuteReader();

            Employee employee = new Employee();
            DBLink.mySqlClose();
            return employee;

        }
    }
}
