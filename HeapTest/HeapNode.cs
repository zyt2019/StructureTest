using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapTest
{
    /// <summary>
    /// 表示堆节点的类
    /// </summary>
    public class HeapNode
    {
        public int Data;
    }
    /// <summary>
    /// 最小堆 父节点的值比子节点要小 最小值是elements[0]  算法复杂度为O(1)
    /// </summary>
    public class MinHeap
    {
        public  List<HeapNode> elements;
        public int Count
        {
            get => elements.Count;
        }
        public MinHeap()
        {
            elements = new List<HeapNode>();
        }
        public void Insert(HeapNode item)
        {
            elements.Add(item);
            OrderHeap();
        }
        public void Delete(HeapNode item)
        {
            int i = elements.IndexOf(item);
            int last = elements.Count - 1;
            //删除堆里面的元素 首先要和最后一个节点进行交换
            elements[i] = elements[last];
            elements.RemoveAt(last);
            OrderHeap();
        }
        public HeapNode ExtractMin()
        {
            if (elements.Count>0)
            {
                HeapNode item = elements[0];
                Delete(item);
                return item;
            }
            return null;
        }
        public HeapNode FindMin()
        {
            if (elements.Count>0)
            {
                return elements[0];
            }
            return null;
        }
        private void OrderHeap()
        {
            //从后往前找父节点 如果父节点的值比子节点大，这是个最小堆 就得交换把子节点往前放 最小嘛
            for (int i = elements.Count - 1; i >0; i--)
            {
                int parentPosition = (i - 1) / 2;
                if (elements[parentPosition].Data>elements[i].Data)
                {
                    SwapElements(parentPosition, i);
                }
            }
        }

        private void SwapElements(int firstIndex, int secondIndex)
        {
            HeapNode tmp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = tmp;
        }
        public List<HeapNode> GetChildren(int parentIndex)
        {
            if (parentIndex>=0)
            {
                List<HeapNode> children = new List<HeapNode>();
                int childIndexOne = (2 * parentIndex) / 2 + 1;
                int childIndexTwo = (2 * parentIndex) / 2 + 2;
                children.Add(elements[childIndexOne]);
                children.Add(elements[childIndexTwo]);
                return children;
            }
            return null;
        }
        public HeapNode GetParent(int childIndex)
        {
            if (childIndex>0 && elements.Count>childIndex)
            {
                int parentIndex = (childIndex - 1) / 2;
                return elements[parentIndex];
            }
            return null;
        }
    }
}
