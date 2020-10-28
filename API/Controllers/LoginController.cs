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
        public ActionResult<int> Get(string num, string pwd)
        {
            String connetStr = "server=34.92.92.208;port=3306;user=hms;password=WKz65wNzeRKzTFiw; database=hms;";
            string sql = "SELECT COUNT(*)  FROM tb_users WHERE phone=" + num + " AND pwd=" + pwd;

            MySqlConnection con = new MySqlConnection(connetStr);
            MySqlCommand mySql = new MySqlCommand(sql, con);

            con.Open();
            int x = int.Parse(mySql.ExecuteScalar().ToString());
            con.Close();
            return x;
        }
    }
}
