using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueTest
{
    class Program
    {
       static CustomerQueue cq;
        static void Main(string[] args)
        {
            //一个营业厅最多招待100人
             cq = new CustomerQueue(100);

            //新开一个线程 每隔100ms服务一个客户
            for (int i = 0; i < 50; i++)
            {
                Customer customer = new Customer() { ID = i };//每个人拿号排队
                if (!cq.IsLineFull())
                {
                cq.CustomerCheckin(customer);
                    Console.WriteLine("顾客编号为{0}进入排队队列",i);
                } 
            }
            Thread thread = new Thread(new ThreadStart(ServiceTime));
            thread.IsBackground = true;
            thread.Start();

            Console.ReadKey();
        }

        private static void ServiceTime()
        {
            while (!cq.IsLineEmpty())
            {
            Customer customerConsulation = cq.CustomerConsulation();//正在服务的客户
            Console.WriteLine("正在服务的顾客编号为：{0}", customerConsulation.ID);
            Thread.Sleep(100);
                //服务完毕后，将顾客移除队列。
            cq.CustomerCheckOut();
            }
        }
    }
}
