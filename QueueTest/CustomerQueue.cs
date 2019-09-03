using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTest
{
    class CustomerQueue
    {
        Queue<Customer> _custQueue;
        int _cap;
        public CustomerQueue(int capacity)
        {
            _custQueue = new Queue<Customer>();
            _cap = capacity;
        }
        private bool CanCheckinCustomer()
        {
            return this._custQueue.Count < this._cap;
        }
        public void CustomerCheckin(Customer c)
        {
            if (this.CanCheckinCustomer())
            {
                this._custQueue.Enqueue(c);
            }
        }
        /// <summary>
        /// 正在服务的客户 队列中第一个客户
        /// </summary>
        /// <returns></returns>
        public Customer CustomerConsulation()
        {
            return this._custQueue.Peek();
        }
        /// <summary>
        /// 移除当前队列第一个
        /// </summary>
        public void CustomerCheckOut()
        {
            this._custQueue.Dequeue();
        }
        public void ClearCustomers()
        {
            this._custQueue.Clear();
        }
        public void CustomerCancel(Customer c)
        {
            //客户取消操作:新建一个队列，把除了该用户外所有用户重新排列后重新生成队列。
            Queue<Customer> tempQueue = new Queue<Customer>();
            foreach (Customer cust in this._custQueue)
            {
                if (cust.Equals(c))
                {
                    continue;
                }
                tempQueue.Enqueue(c);
            }
            this._custQueue = tempQueue;
        }
        public int CustomerPosition(Customer c)
        {
            if (this._custQueue.Contains(c))
            {
                int i=0;
                foreach (Customer cust in this._custQueue)
                {
                    if (cust.Equals(c))
                    {
                        return i;
                    }
                    i++;
                }
            }
            return -1;
        }
        public int CustomersInLine()
        {
            return this._custQueue.Count;
        }
        public bool IsLineEmpty()
        {
            return this._custQueue.Count == 0;
        }
        public bool IsLineFull()
        {
            return this._custQueue.Count == this._cap;
        }
    }

    internal class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Destnation { get; set; }
    }
}
