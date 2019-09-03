using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //复习DataTable和DataSet的创建
            //创建DataSet
            DataSet ds = new DataSet("School");
            //创建DataTable
            DataTable dt = new DataTable("Student");
            ds.Tables.Add(dt);
            //创建DataColumn
            DataColumn dc1 = new DataColumn("AutoID", typeof(int));
            dc1.AutoIncrement = true;
            dc1.AutoIncrementStep = 1;
            dt.Columns.Add(dc1);
            //再创建1列
            DataColumn dc2 = dt.Columns.Add("Name", typeof(string));
            dc2.AllowDBNull = false;
            //再给dt增加数据
            DataRow dr1 = dt.NewRow();
            dr1["Name"] = "张三";
            DataRow dr2 = dt.NewRow();
            dr2["Name"] = "李四";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            Console.WriteLine("OK");
            //输出表数据
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                //每个表
                Console.WriteLine("表的名称：{0}", ds.Tables[i].TableName);
                for (int r = 0; r < ds.Tables[i].Rows.Count; r++)
                {
                    //每一行
                    DataRow dr = ds.Tables[i].Rows[r];
                    for (int c = 0; c < ds.Tables[i].Columns.Count; c++)
                    {
                        Console.Write(dr[c].ToString() + "\t|\t");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
