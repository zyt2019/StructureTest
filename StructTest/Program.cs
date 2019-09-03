using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructTest
{
    class Program
    {
        //结构体的练习
        static void Main(string[] args)
        {
            #region 小小的索引器练习
            IndexClass ic = new IndexClass(10);
            //for (int i = 0; i < ic.Capacity; i++)
            //{
            //    ic.AddItem($"我是{Convert.ToString(i)}");
            //}
            //Console.WriteLine("添加完毕");
            //for (int i = 0; i < ic.Capacity; i++)
            //{
            //    Console.WriteLine("按照索引值输出：：：：");
            //    Console.WriteLine(ic[i]);
            //} 
            #endregion
            #region 正式结构体练习

            #endregion
            Console.ReadKey();
        }
    }
    //写一个小小的带索引器的类
    public class IndexClass
    {
        private List<string> list;
        public int Capacity { get; set; }
        public IndexClass(int capacity)
        {
            list = new List<string>(capacity);
            Capacity = capacity;
        }
         public string  this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }
        public void  AddItem(string s)
        {
            list.Add(s);
        }
        public void RemoveItem(string s)
        {
            if (list.Contains(s))
            {
                list.Remove(s);
            } 
        }
    }
    //把第三章的WayPoint类转换成结构体：
    public struct Waypoint
    {
        public readonly int lat;
        public readonly int lon;
        public bool Active { get; private set; }
        public Waypoint(int latitude,int longitude)
        {
            this.lat = latitude;
            this.lon = longitude;
            this.Active = true;
        }
        public void DeactiveWaypoint()
        {
            this.Active = false;
        }
        public void ReactiveWaypoint()
        {
            this.Active = true;
        }
    }

}
