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
    public class LoginController : ControllerBase
    {
        // GET login
        [HttpGet]
        public ActionResult<int> Get(string user, string pwd)
        {
            string sql = $"SELECT COUNT(*) FROM tb_users WHERE phone={user} AND pwd={pwd}";
            MySqlCommand mySql = DBLink.mySqlLink(sql);
            DBLink.mySqlOpen();
            int x = int.Parse(mySql.ExecuteScalar().ToString());
            DBLink.mySqlClose();
            return x;
        }
    }
}
