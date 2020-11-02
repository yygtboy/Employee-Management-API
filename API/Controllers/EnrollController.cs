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
        public ActionResult<int> Get(int StaffId,string UserId, string pwd)
        {
            string selectId = $"select count(*) from WeiXinUsers_Table where StaffId ={StaffId}";
            string sql = $"INSERT INTO tb_users (StaffId,UserId,pwd) VALUES ({StaffId},'{UserId}','{pwd}')";
            MySqlCommand mySql = DBLink.MySqlLink(selectId);
            DBLink.mySqlOpen();
            try
            {
                //判断用户是否注册过
                int x = int.Parse(mySql.ExecuteNonQuery().ToString());
                if (x == 0)
                {
                    //添加用户
                    mySql.CommandText = sql;
                    x = int.Parse(mySql.ExecuteNonQuery().ToString());
                    DBLink.mySqlClose();
                    return x;//注册成功
                }
                else
                {
                    DBLink.mySqlClose();
                    return 201;//用户已经注册过

                }
            }
            catch
            {
                DBLink.mySqlClose();
                return 101;//数据库建立链接失败
            }
        }
    }
}
