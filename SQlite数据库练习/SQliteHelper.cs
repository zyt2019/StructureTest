using System.Data;
using System.Data.SQLite;

namespace SQlite数据库练习
{
    internal  class SQliteHelper
    {
        //定义连接字符串  readonly static
        private readonly static string SQLiteConnectString = "Data Source=wde.db;Version=3;";
        public  SQliteHelper()
        {

        }
        //增
        //删
        //改
        //查
        //无返回值 只返回受影响行数
        public static int ExecuteNonQuery(string sql,params SQLiteParameter[] pms)
        {
            using (SQLiteConnection conn=new SQLiteConnection(SQLiteConnectString))
            {
                using (SQLiteCommand command=new SQLiteCommand(sql,conn))
                {
                    if (pms!=null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    conn.SetPassword("1234");
                    conn.Open();
                   return  command.ExecuteNonQuery();
                }
            }
        }
        //单个值返回的方法
        public static object ExecuteScalar(string sql,SQLiteParameter[] pms)
        {
            using (SQLiteConnection conn=new SQLiteConnection(SQLiteConnectString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    if (pms!=null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    conn.Open();
                    return command.ExecuteScalar();
                }
            }
        }
        //返回dataReader的方法
        public static SQLiteDataReader ExecuteDataReader(string sql,params SQLiteParameter[] pms)
        {
            SQLiteConnection conn = new SQLiteConnection(SQLiteConnectString);
            try
            {
                conn.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    if (pms != null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch 
            {
                conn.Close();
                conn.Dispose();
                throw;
            }
        }
        //返回datatable方法
        public static DataTable ExecuteDataTable(string sql,params SQLiteParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, SQLiteConnectString))
            {
                if (pms!=null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }


    }
}