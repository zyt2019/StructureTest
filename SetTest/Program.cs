using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetTest
{
    class Program
    {
        //集合练习 集合是不包含重复项的简单数据集
        static void Main(string[] args)
        {
            #region 集合定义练习
            HashSet<string> mySet = new HashSet<string>();
            bool b1 = mySet.Add("Green");
           Console.WriteLine(mySet.Count);
            Console.WriteLine(b1);
            bool b2=mySet.Add("Red");
            Console.WriteLine(mySet.Count);
            Console.WriteLine(b2);
            bool b3=mySet.Add("Red");
            Console.WriteLine(mySet.Count);
            Console.WriteLine(b3);
            Console.ReadKey();
            #endregion
        }
    }
}
