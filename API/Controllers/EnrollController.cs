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

    public class EnrollController : ControllerBase
    {
        // GET enroll
        [HttpGet]
        public ActionResult<int> Get(string user, string pwd)
        {
            string selectId = $"select count(*) from tb_users where phone ={user}";
            string sql = $"INSERT INTO tb_users (phone,pwd) VALUES ({user},{pwd})";
            MySqlCommand mySql = DBLink.mySqlLink(sql);
            DBLink.mySqlOpen();
            try
            {
                int x = int.Parse(mySql.ExecuteNonQuery().ToString());
                DBLink.mySqlClose();
                return x;
            }
            catch
            {
                DBLink.mySqlClose();
                return 0;
            }
        }
    }
}
