using Client调用WCF服务.你的名字服务;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client调用WCF服务
{
    class Program
    {
        static void Main(string[] args)
        {
            Client调用WCF服务.你的名字服务.Service1Client service1 = new 你的名字服务.Service1Client();
            //要传入的值
            Person p = new Person() { CardId = 123, Name = "张艺腾" };
            Person p2= service1.PersonString(p);
            Console.WriteLine(p2.CardId+p2.Name);
            Console.WriteLine(service1.YourName("ZXY"));
            Console.ReadKey();
        }
    }
}
