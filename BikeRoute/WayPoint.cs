using System;

namespace BikeRoute
{
    public class WayPoint
    {
        public bool  Enable { get; private set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public WayPoint()
        {

        }
        public WayPoint(int id,string name)
        {
            ID = id;
            Name = name;
        }
        /// <summary>
        /// 路径点不可用
        /// </summary>
        internal void DeactivateWaypoint()
        {
           //对Enable属性进行了封装 只能是内部方法调用改变Enable的值。
            Enable = false;
        }
        /// <summary>
        /// 路径点可用
        /// </summary>
        internal void ReactiveWaypoint()
        {
            Enable = true;
        }
    }
}