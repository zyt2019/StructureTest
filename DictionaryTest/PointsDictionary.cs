using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryTest
{
    class PointsDictionary
    {
        private Dictionary<string, int> _points;
        public PointsDictionary()
        {
            _points = new Dictionary<string, int>();
        }
        //更新的私有方法
        private int UpdateCustomerPoints(string customerName, int points)
        {
            if (this.CustomerExists(customerName))
            {
                _points[customerName] += points;
                return _points[customerName];
            }
            return 0;
        }
        //更新顾客代币状态
        public void RegisterCustomer(string customerName)
        {
            this.RegisterCustomer(customerName, 0);
        }

        public void RegisterCustomer(string customerName, int previousBalance)
        {
            _points.Add(customerName, previousBalance);
        }
        //获取顾客代币状态
        public int GetCustomerPoints(string customerName)
        {
            int points;
            _points.TryGetValue(customerName, out points);//这样不会报错，如果没有Key值，返回的是Value默认值，此处为int.
            return points;
        }
        //更新的共有方法
        //充值游戏币
        public int AddCustomerPoints(string customerName, int points)
        {
            return this.UpdateCustomerPoints(customerName, points);
        }
        //消费游戏币
        public int RemoveCustomerPoints(string customerName,int points)
        {
            return this.UpdateCustomerPoints(customerName, -points);
        }
        //赎回游戏币
        public int RedeemCustomerPoints(string customerName,int points)
        {
            return this.UpdateCustomerPoints(customerName, -points);
        }
        //删除
        public int CustomerCheckOut(string customerName)
        {
            int point = this.GetCustomerPoints(customerName);
            _points.Remove(customerName);
            return point;
        }
        //判断当前字典是否已存在指定键
        private bool CustomerExists(string customerName)
        {
            //判断是否存在顾客名字
            return _points.ContainsKey(customerName);
        }
        //计数
        public int CustomerOnPremises()
        {
            return _points.Count;
        }
        public void ClosingTime()
        {
            _points.Clear();
        }
    }
}
