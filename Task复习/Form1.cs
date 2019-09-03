using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task复习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //Task
            this.Text = await GetUserInfo();
            ThreadTest tt = new ThreadTest();
            tt.CreateThread(10);
            
            label2.Text = tt.ID.ToString();
        }
        //当使用Task进行等待式操作时，每个都得加Task<>或者返回值为void
        public async Task<string> GetUserInfo()
        {
           return  await Method();
        }

        private async Task<string> Method()
        {
            bool b = await Method1();
            if (b)
            {
                return "adc";
            }
            else
            {
                return "bbb";
            }
        }
        private async Task<bool> Method1()
        {
          string s=  await Method2();
            if (s=="adc")
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        private async Task<string> Method2()
        {
            return await Task.Run(() => { Thread.Sleep(5999); return "adc";  });
        }
        int number = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            number++;
            label1.Text = number.ToString();
        }
    }
    public class ThreadTest
    {
        public int ID { get; set; }
        //线程练习
        public Thread CreateThread(int id)
        {         
            ThreadStart start = new ThreadStart(method2);
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(method1);
            Thread t1 = new Thread(start);
            t1.IsBackground = true;
            t1.Start();
            return t1;
        }

        private void method1(object id)
        {
            ID = (int)id + 5;
        }
        private void method2()
        {
            ID++;
        }
    }
}
