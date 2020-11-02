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
        
        ////获取所有员工信息
        //[HttpGet]
        //public object Get()
        //{
        //    //打开数据库连接
        //    DBLink.mySqlOpen();

        //    string sql = "SELECT * FROM Employee_Table";
        //    MySqlCommand cmd =  DBLink.MySqlLink(sql);

        //    //创建Employees类集合
        //    List< Employees > employees = new List<Employees>();
        //    MySqlDataReader reader = cmd.ExecuteReader();

        //    //将数据库的数据存放到集合中
        //    while (reader.Read())
        //    {
        //        employees.Add(new Employees()
        //        {
        //            staffId = (int)reader["StaffId"],
        //            name = (string)reader["Name"],
        //            sex = (int)reader["Sex"],
        //            phone = (string)reader["Phone"],
        //            idCard = (string)reader["IdCard"],
        //            position = (int)reader["Position"]
        //        });
        //    }
        //    DBLink.mySqlClose();
        //    return employees;
        //}

        //获取单个员工信息
        [HttpGet]
        public object Get(string StaffId)
        {
            string sql;
            switch (StaffId)
            {
                case "all": 
                     sql = "SELECT * FROM Employee_Table";
                    break;
                default:
                    sql = $"SELECT * FROM Employee_Table WHERE StaffId={StaffId}";
                    break;
            }


            //打开数据库连接
            DBLink.mySqlOpen();

            MySqlCommand cmd = DBLink.MySqlLink(sql);

            //创建Employees类集合
            List<Employees> employees = new List<Employees>();
            MySqlDataReader reader = cmd.ExecuteReader();

            //将数据库的数据存放到集合中
            while (reader.Read())
            {
                employees.Add(new Employees()
                {
                    staffId = (int)reader["StaffId"],
                    name = (string)reader["Name"],
                    sex = (int)reader["Sex"],
                    phone = (string)reader["Phone"],
                    idCard = (string)reader["IdCard"],
                    sector= (string)reader["Sector"],
                    position = (string)reader["Position"]
                });
            }
            DBLink.mySqlClose();
            return employees;
        }
    }
}
