using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TF_Program2017
{
    //声明一个委托
    public delegate void DelTest();
    public partial class Order : Form
    {
        DelTest mytest;
        List<string> t = new List<string>();
        public Order(DelTest del)
        {
            this.mytest = del;
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            string sd="";
            foreach (string item in Form1.ALLAccessRoad)//将联锁表所有始端添加
            {
                string[] strtArray = item.Split(',');
                if (!sd.Equals(strtArray[0]))
                { shiduan.Items.Add(strtArray[0]); sd = strtArray[0]; }
            }
        }

        private void shiduan_TextChanged(object sender, EventArgs e)
        {
            
            zhongduan.Text = "终端";
            zhongduan.Items.Clear();
            string[] d= Road.SearchFroad(shiduan.Text);
            foreach (string item in d)
            {
                if (!String.Equals(null, item)) zhongduan.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!shiduan.Text.Equals("始端")&&!(zhongduan.Text.Equals("终端")))
            listBox1.Items.Add(shiduan.Text+"至"+zhongduan.Text);
        }

        private void button2_Click(object sender, EventArgs e)//执行选中的计划
        {
            Form1.firstEname = listBox1.Text.Split('至')[0];
            Form1.lastEname = listBox1.Text.Split('至')[1];
            mytest();//自动执行计划
        }

        private void button4_Click(object sender, EventArgs e)//删除所选计划
        {
            if (String.Equals(null, listBox1.Text)) MessageBox.Show("请选择一个计划");
            else
            listBox1.Items.Remove(listBox1.Text);
           
        }
       

        private void button2_Click_1(object sender, EventArgs e)//执行全部计划
        {
            foreach (string item in listBox1.Items)
            {
                Form1.firstEname = item.Split('至')[0];
                Form1.lastEname = item.Split('至')[1];
                //clickcount = 1;
                mytest();//自动执行计划 
               
            }
        }
    }
}
