using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建自行车路径
            WayPointList wayPointList = new WayPointList();
            //增加路径点
            wayPointList.AddWayPoints(new List<WayPoint>() { new WayPoint(1, "我"), new WayPoint(2, "你"), new WayPoint(3, "它"), new WayPoint(4, "子鼠丑牛"),
                new WayPoint(5, "寅虎卯兔"),new WayPoint(5, "申酉戌亥")
            });
            wayPointList.StartRoute();
            //查看当前路径走到哪个点了
            int a = wayPointList.CurrentPosition().Value.ID;
            wayPointList.MoveToNextWaypoint();
            int b= wayPointList.CurrentPosition().Value.ID;
            wayPointList.MoveToNextWaypoint();
            int c = wayPointList.CurrentPosition().Value.ID;
            wayPointList.MoveToNextWaypoint();
            int d = wayPointList.CurrentPosition().Value.ID;
            wayPointList.MoveToNextWaypoint();//这里已经得到false 证明已经走到了队尾
            int e = wayPointList.CurrentPosition().Value.ID;
            //有个想法 可以根据这种路径特性 做一个winform显示路径点 可以用Graphic画也很有意思 有时间做一下。
        }
    }
}
