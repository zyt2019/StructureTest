using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTest
{
    /// <summary>
    /// 二叉树的定义
    /// </summary>
    public class Node
    {
        //爱啊爱啊
        //两个基本组件构成：包括节点存储的数据以及当前节点指向其子节点的引用集
        public int Data;
        public Node Left;
        public Node Right;
        /// <summary>
        /// 返回当前节点的子节点集合
        /// </summary>
        public List<Node> Children
        {
            get
            {
                List<Node> children = new List<Node>();
                if (this.Left!=null)
                {
                    children.Add(this.Left);
                }
                if (this.Right!=null)
                {
                    children.Add(this.Right);
                }
                return children;
            }
        }
        /// <summary>
        /// 构造函数定义节点存储的数据，因为子节点是可选字段，因此无需在构造函数中进行赋值。
        /// </summary>
        /// <param name="data"></param>
        public Node(int data)
        {
            Data = data;
        }
        public bool InsertData(int data)
        {
            Node node = new Node(data);
            return this.InserNode(node);
        }

        public bool InserNode(Node node)
        {
            if (node==null || node.Data==this.Data)
            {
                return false;
            }
            else if (node.Data<this.Data)
            {
                if (this.Left==null)
                {
                    this.Left = node;
                    return true;
                }
                else
                {
                    return this.Left.InserNode(node);
                }
            }
            else
            {
                if (this.Right==null)
                {
                    this.Right = node;
                    return true;
                }
                else
                {
                    return this.Right.InserNode(node);
                }
            }
             
        }
        /// <summary>
        /// 嫁接树
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Graft(Node node)
        {
            if (node==null)
            {
                return false;
            }
            List<Node> nodes = node.ListTree();
            foreach (var n in nodes)
            {
                this.InserNode(n);
            }
            return true;
        }
        //提供删除节点的两种方法 一是根据原始数据，二是根据节点
        public Node RemoveData(int data)
        {
            Node node = new Node(data);
            return this.RemoveNode(node);
        }

        private Node RemoveNode(Node node)
        {
            if (node==null)
            {
                return null;
            }
            Node retNode;//用于存放将被返回的节点
            Node modNode;//用于存放为删除节点而需进行相应修改的节点
            List<Node> treeList = new List<Node>();//用于对已删除节点的树进行重排序
            if (this.Data==node.Data)
            {
                //找到了匹配的根节点
                retNode = new Node(this.Data);
                modNode = this;
                if (this.Children.Count==0)
                {
                    return this;//节点没有子节点 为单节点树
                }
            }
            else if (this.Left.Data==node.Data)
            {
                retNode = new Node(this.Left.Data);//存放要删除的左节点的子节点
                modNode = this.Left;
            }
            else if (this.Right.Data==node.Data)
            {
                retNode = new Node(this.Right.Data);
                modNode = this.Right;
            }
            else
            {
                //不是根节点，也不是根左节点，也不是根右节点的情况 对每个节点进行遍历
                foreach (Node child in this.Children)
                {
                    if (child.RemoveNode(node)!=null)
                    {
                        return child;
                    }
                }
                return null;//树中没有匹配的节点
            }
            //----------------------------------------------------------上一步是先找到要删除的子节点 然后第二步是删除节点并把它的子节点
            //赋给当前节点。
            //对树进行重排序
            if (modNode.Left!=null)
            {
                modNode.Data = modNode.Left.Data;
                treeList.AddRange(modNode.Left.ListTree());
                modNode.Left = null;
            }
            else if (modNode.Right!=null)
            {
                modNode.Data = modNode.Right.Data;
                treeList.AddRange(modNode.Right.ListTree());
                modNode.Right = null;
            }
            else
            {
                //如果找到的节点的左右两个节点都是null 代表当前节点为叶节点 -单节点树 它不存在需要进行排序的子孙节点。
                modNode = null;
            }
            foreach (Node n in treeList)
            {
                modNode.InserNode(n);
            }
            //操作完成
            return retNode;
        }
        //修剪
        public Node Prune(Node root)
        {
            Node matchNode;
            if (this.Data==root.Data)
            {
                Node b = this.CopyTree();
                this.Left = null;
                this.Right = null;
                return b;
            }
            else if (this.Left.Data==root.Data)
            {
                matchNode = this.Left;
            }
            else if (this.Right.Data == root.Data)
            {
                matchNode = this.Right;
            }
            else
            {
                foreach (Node child in this.Children)
                {
                    if (child.Prune(root)!=null)
                    {
                        return child;
                    }
                }
                return null;//树中没有匹配的节点
            }
            Node branch = matchNode.CopyTree();
            matchNode = null;
            return branch;
        }
        public Node FindData(int data)
        {
            Node node = new Node(data);
            return this.FindNode(node);
        }

        private Node FindNode(Node node)
        {
            if (node.Data==this.Data)
            {
                return this;
            }
            foreach (Node child in this.Children)
            {
                Node result = child.FindNode(node);
            }
            return null;
        }

        /// <summary>
        /// 复制树
        /// </summary>
        /// <returns></returns>
        private Node CopyTree()
        {
            Node n = new Node(this.Data);
            if (this.Left!=null)
            {
                n.Left = this.Left.CopyTree();
            }
            if (this.Right!=null)
            {
                n.Right = this.Right.CopyTree();
            }
            return n;
        }

        /// <summary>
        /// 为Node类提供枚举功能
        /// </summary>
        /// <returns></returns>
        private List<Node> ListTree()
        {
            List<Node> result = new List<Node>();
            result.Add(new Node(this.Data));
            foreach (Node child in this.Children)
            {
                result.AddRange(child.ListTree());
            }
            return result;
        }
    }
}
