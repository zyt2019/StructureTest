using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 函数式编程初解
{
    class Program
    {
        //书不能白买 练习一下函数式编程/(ㄒoㄒ)/~~
        static void Main(string[] args)
        {
            HanShuShi hss = new HanShuShi();
            //string ss= hss.Method01(hss.Method02);
            //Console.WriteLine("方法2传 过来的值是：{0}",ss);

            //string s= hss.Method03(hss.Method04,"w de 1 er");

            //char a = 'a';
            //string s = hss.Method03((_e) => 
            //{
            //    string ss = _e.Replace('e', a);
            //    return ss;

            //}, "w de 1 er");
            //Console.WriteLine(s);

            //Try Catch 只能捕捉第一个exception
            try
            {
                int i = 10, j = 20;
                int k = i + j;
                throw new Exception(i.ToString());
                throw new Exception(k.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }
    public class HanShuShi
    {
        //定义函数式方法 Func用于函数间传值   发现两个函数式编程的好处：
        //                                                1、共用生命周期
        //                                                  2、传值特别方便
        //                                                 3、调用变量很方便 不关注方法的处理过程 只关心参数和返回值就可以了。
        public string Method01(Func<string> func)
        {
            return func();
        }
        public string Method02()
        {
            return "w de ai";
        }
        public string Method03(Func<string,string> func,string paramss)//可以传方法进去
        {
            return func?.Invoke(paramss);
        }
        public string Method04(string paramss)
        {
            string ss = paramss.Split(new char[]{'1'})[0];
            return ss;
        }
    }
}
