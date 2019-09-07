using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQlite数据库练习
{
    public partial class Form1 : Form
    {
        SQliteHelper helper = new SQliteHelper();
        public Form1()
        {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            helper.CreateSQlite();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            helper.CreateTable();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            helper.InsertData();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = helper.ShowData();
        }
    }
}
