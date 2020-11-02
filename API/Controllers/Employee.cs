using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Employee : ControllerBase
    {
        
        //获取所有员工信息
        [HttpPost]
        public Employees Post()
        {
           
            //string sql = "SELECT * FROM Employee_Table";
            //MySqlCommand mySql = new MySqlCommand(sql);

            //MySqlDataReader reader = null;
            //DBLink.mySqlOpen();
                
            //reader = mySql.ExecuteReader();
            //DBLink.mySqlClose();

            Employees employees = new Employees ();

            employees.staffId = 001;
            employees.name = "AA";
            employees.sex = 1;
            employees.phone = "123123123";
            employees.idCard = "1651313";
            employees.position = 101;


            
            return employees;

        }
    }
}
