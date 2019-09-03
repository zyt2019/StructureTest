using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //字典在游戏代币统计的使用
            PointsDictionary pd = new PointsDictionary();
            //来一位顾客
            pd.RegisterCustomer("J1");
            //充钱100🖊
            pd.AddCustomerPoints("J1", 100);
            //查询当前用户🖊
            int bi01= pd.GetCustomerPoints("J1");
            Console.WriteLine($"用户J1的用户游戏币当前值为：{ bi01}");
            //J1消费20🖊
            int bi02= pd.RemoveCustomerPoints("J1", 20);
            Console.WriteLine($"用户J1的用户游戏币当前值为：{ bi02}");


            Console.ReadKey();
          
        }
    }
}
