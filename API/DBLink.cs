using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace API
{
    public static class DBLink
    {
        public static string connetStr = "server=34.92.92.208;port=3306;user=kP3LRb;password=dZnzbK67hfzt7Lma; database=Employee;";
        public static MySqlConnection con = new MySqlConnection(connetStr);

        //返回MySqlCommand方法
        public static MySqlCommand mySqlLink(string sql)
        {
            MySqlCommand mySql = new MySqlCommand(sql, con);
            return mySql;
        }

        //开启数据库连接
        public static void mySqlOpen()
        {
            con.Open();
        }

        //关闭数据库连接
        public static void mySqlClose()
        {
            con.Close();
        }
        
    }
}
