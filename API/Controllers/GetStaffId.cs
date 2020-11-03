using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetStaffId : ControllerBase
    {
        [HttpGet]
        public object Get(String UserId, string pwd)
        {
            string sql = $"SELECT StaffId FROM WeiXinUsers_Table WHERE UserId='{UserId}' AND Pwd='{pwd}'";

            object x;
            MySqlCommand mySql = DBLink.MySqlLink(sql);
            DBLink.mySqlOpen();
            try
            {
                x = mySql.ExecuteScalar();
                DBLink.mySqlClose();
                return x;
            }
            catch
            {
                DBLink.mySqlClose();
                return "1010";//数据库建立链接失败
            }
        }
    }
}
