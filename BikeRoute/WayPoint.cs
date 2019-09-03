using System;

namespace BikeRoute
{
    public class WayPoint
    {
        public bool  Enable { get; private set; }
        private WayPointItem item;
        public class WayPointItem
        {
            public int ID { get; set; }
        }
        public WayPoint()
        {

        }
        internal void DeactivateWaypoint()
        {
            Enable = false;

        }

        internal void ReactiveWaypoint()
        {
            Enable = true;
        }
    }
}