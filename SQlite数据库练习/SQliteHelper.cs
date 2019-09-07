using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace SQlite数据库练习
{
    /// <summary>
    /// SQlite帮助类
    /// </summary>
    public class SQliteHelper
    {
        public void CreateSQlite()
        {
            SQLiteConnection.CreateFile("wde01.db");
            //如果再次创建 会删除之前同名文件，再创建一个
        }
        public void CreateTable()
        {
            //创建连接字符串
            SQLiteConnection conn = new SQLiteConnection("Data Source=wde.db;Version=3;");
            ////这是数据库登录密码   设置密码用changePassword 带密码查询数据库用setPassword
            conn.SetPassword("1234");
            //打开数据库
            conn.Open();
            string query = "create table table1 (id INTEGER, name VARCHAR)";
            //创建命令
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            //执行命令
            cmd.ExecuteNonQuery();
            //释放资源
            conn.Close();
        }
        public void InsertData()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=wde.db;Version=3;"))
            {
                conn.SetPassword("1234");
                conn.Open();
                string query = "insert into table1 (id,name) values(2,'小红')";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public DataTable ShowData()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=wde01.db;Version=3;"))
            {
                conn.Open();
                string query = "select * from table1";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
