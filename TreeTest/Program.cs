using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTest
{
    class Program
    {
        //树： 非线性数据结构
        static void Main(string[] args)
        {
            #region 测试if else
            //int a = 1;
            //if (a==1)
            //{
            //    a = 2;
            //}
            //else if(a==2)
            //{
            //    a = 3;
            //}
            //else if (a==3)
            //{
            //    a = 4;
            //}
            //else
            //{
            //    a = 5;
            //}
            //Console.WriteLine(a); 
            #endregion
            #region 斐波那契数列
            while (true)
            {
                Console.WriteLine("请输入斐波那契数列的基数：");
                int.TryParse(Console.ReadLine(), out int Ba);
                Console.WriteLine("计算得出：");
                Console.WriteLine(Fibonacci(Ba));
            }
            #endregion
        }
        public static int Fibonacci(int n)
        {
            if (n==0)
            {
                return 0;
            }
            if (n==1)
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n -2);
        }
    }
}
