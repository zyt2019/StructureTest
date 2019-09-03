using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRoute
{
    public class WayPointList
    {
        LinkedList<WayPoint> route;
        private LinkedListNode<WayPoint> current;
        public WayPointList()
        {
            this.route = new LinkedList<WayPoint>();
        }
        public void AddWayPoints(List<WayPoint> wayPoints)
        {
            foreach (WayPoint w in wayPoints)
            {
                this.route.AddLast(w);
            }
        }
        public bool RemoveWaypoint(WayPoint wayPoint)
        {
            return this.route.Remove(wayPoint);
        }
        /// <summary>
        /// 在某个点前面加路径点
        /// </summary>
        /// <param name="wayPoints"></param>
        /// <param name="before"></param>
        public void InsertWaypointsBefore(List<WayPoint> wayPoints,WayPoint before)
        {
            LinkedListNode<WayPoint> node = this.route.Find(before);
            if (node!=null)
            {
                foreach (WayPoint w in wayPoints)
                {
                    this.route.AddBefore(node, w);
                }
            }
            else
            {
                this.AddWayPoints(wayPoints);
            }
        }
        /// <summary>
        /// 开始方法
        /// </summary>
        /// <returns></returns>
        public bool StartRoute()
        {
            if (this.route.Count>1)
            {
                this.current = this.StartingLine();
                return this.MoveToNextWaypoint();
            }
            return false;
        }

        public bool MoveToNextWaypoint()
        {
            if (this.current!=null)
            {
                this.current.Value.DeactivateWaypoint();
                if (this.current!=this.FinnishLine())
                {
                    this.current = this.current.Next;
                    return true;
                }
                return false;
            }
            return false;

        }
        public bool MoveToPreviousWaypoint()
        {
            if (this.current!=null && this.current!=this.StartingLine())
            {
                this.current = this.current.Previous;
                this.current.Value.ReactiveWaypoint();
                return true;
            }
            return false;
        }




        //描述位置的三个方法
        public LinkedListNode<WayPoint> StartingLine()
        {
            return this.route.First;
        }
        public LinkedListNode<WayPoint> FinnishLine()
        {
            return this.route.Last;
        }
        public LinkedListNode<WayPoint> CurrentPosition()
        {
            return this.current;
        }
        
    }
}
