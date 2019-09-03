using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //试一试最小堆
            MinHeap minHeap = new MinHeap();
            minHeap.elements = new List<HeapNode>() { new HeapNode() {Data= 3 }, new HeapNode() { Data = 6 }, new HeapNode() { Data = 19}
                , new HeapNode() { Data = 11 }, new HeapNode() { Data = 15 }};
            Console.WriteLine("最小堆的节点数量为：{0}", minHeap.Count);
            string s = string.Empty;
            minHeap.Insert(new HeapNode() { Data = 10 });
            showNow(minHeap);
            //HeapNode node = new HeapNode() { Data=6};
            //minHeap.Delete(node);
            //showNow(minHeap);
            //HeapNode node01 = new HeapNode() { Data = 3 };
            //HeapNode node02 = new HeapNode() { Data = 6 };
            //List<HeapNode> list = new List<HeapNode>() { node01, node02};
            //Console.WriteLine(list.IndexOf(node02)); 
            minHeap.ExtractMin();
            showNow(minHeap);
           HeapNode node= minHeap.FindMin();
            Console.WriteLine(node.Data);
            showNow(minHeap);
            List<HeapNode> nodes = minHeap.GetChildren(1);
            for (int i = 0; i < nodes.Count; i++)
            {
            Console.WriteLine(nodes[i].Data);
            }
            HeapNode nodep = minHeap.GetParent(4);
            Console.WriteLine(nodep.Data);
            Console.ReadKey();
        }

        private static void showNow(MinHeap minHeap )
        {
            string s = string.Empty;
            for (int i = 0; i < minHeap.Count; i++)
            {
                s += minHeap.elements[i].Data + " ";
            }
            Console.WriteLine("此次操作的结果为：{0}", s);
        }
    }
}
