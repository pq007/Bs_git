using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TF_Program2017
{
    public partial class Form1 : Form
    {
        public static List<BaseShape> EquipmentList = new List<BaseShape>();//设备数据
        public static Dictionary<string, BaseShape> EquipmentDic = new Dictionary<string, BaseShape>();//设备数据
        public static List<string> ALLAccessRoad = new List<string>();//存储所有联锁表进路信息
        public static List<BaseShape> RoadList = new List<BaseShape>();//正在运行的进路
        public static List<Train> TrainList = new List<Train>();//所有正在运行的车
        public static Dictionary<Train, List<BaseShape>> CarRoadDic = new Dictionary<Train, List<BaseShape>>();//车与相对应的进路
        Point P_you;
        Point p;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Form1()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//打开双缓冲绘图
            InitializeComponent();
        }
        /// <summary>
        /// 加载函数，并在加载过程中初始化设备信息和联锁表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            IniData.IniEquipmentData();
            IniData.IniLinkData();
            Control.CheckForIllegalCrossThreadCalls = false;//允许线程中调用控件进行操作
        }
        /// <summary>
        /// 图形重新绘制，每次重绘都会调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Paint_string.PaintAgain(EquipmentList, g);
        }
        /// <summary>
        /// 由始端通过联锁表告知可以按压的终端，返回所有终端string[]
        /// </summary>
        /// <param name="始端信号设备"></param>
        /// <returns>手动选排进路</returns>
        public static string[] SearchSema(string firstequipment)
        {
            string[] r = new string[10];
            int i = 0; Semaphore se = null;
            foreach (string item in ALLAccessRoad)
            {
                string[] strtArray = item.Split(',');
                foreach (BaseShape item0 in EquipmentList)
                {
                    if (strtArray[1].Equals(item0.M_Name))
                    {
                        se = (Semaphore)item0;
                    }
                }
                if (strtArray[0].Equals(firstequipment) && se.enableclick)//终端要可以按压
                { r[i++] = strtArray[1]; }
            }
            return r;
        }
        /// <summary>
        /// 手动溜放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//左键单击
            {
                p = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y - 30);
                foreach (BaseShape item in EquipmentList)
                {
                    if (item.IsEnter(p) && (item.M_Type == 1))//只能点击信号机
                    {
                        Anya((Semaphore)item);
                    }
                }
            }
        }
        /// <summary>
        /// 闪光的线程函数
        /// </summary>
        /// <param name="item"></param>
        public void SemaFlush(object item)
        {
            Semaphore se = (Semaphore)item;
            while (true)
            {
                se.M_ColorFlag = 0;
                Invalidate();
                Delays.Delay(300);
                se.M_ColorFlag = 111;
                Invalidate();
                Delays.Delay(300);
            }
        }
        Thread[] th = new Thread[10];//信号机闪光的线程
        public int clickcount = 1;
        Semaphore[] SEtemp = new Semaphore[10];//用于第二次点击时还原信号机的显示正常
        /// <summary>
        /// 按压得到进路
        /// </summary>
        /// <param name="fs"></param>
        public void Anya(Semaphore fs)
        {
            if (fs.enableclick && clickcount == 1)//第一次按压
            {
                fs.enableclick = false;
                th[0] = new Thread(SemaFlush);
                th[0].Start(fs);
                th[0].IsBackground = true;
                string[] last = SearchSema(fs.M_Name);//可以按压的终端的提示
                int i = 1;
                SEtemp[0] = fs;
                foreach (string item in last)
                {
                    try
                    {
                        if (EquipmentDic.ContainsKey(item))
                        {
                            th[i] = new Thread(SemaFlush);
                            th[i].Start(EquipmentDic[item]);
                            th[i].IsBackground = true;
                            SEtemp[i++] = (Semaphore)EquipmentDic[item];
                        }
                    }
                    catch { }
                }
                clickcount = 2;
            }
            else //第二次按压
            {
                int i = 0;
                foreach (Semaphore item in SEtemp)
                {
                    if (item.M_Name != fs.M_Name) break;
                }//没有按压提示的信号机，按压无效
                while (!Thread.Equals(th[i], null))//取消闪光
                { th[i].Abort(); i++; }
                i = 0;
                while (!Semaphore.Equals(SEtemp[i], null))//信号复原
                { SEtemp[i].M_ColorFlag = 0; SEtemp[i].enableclick = true; i++; }
                if (fs.M_SubType == 4) { fs.M_ColorFlag = 1; }
                Invalidate();
                clickcount = 1;
                //将对应的进路上的所有设备写入进路表
                foreach (string item in ALLAccessRoad)
                {
                    string[] strtArray = item.Split(',');
                    if (strtArray[0].Equals(SEtemp[0].M_Name) && strtArray[1].Equals(fs.M_Name))
                    {
                        for (int na = 4; na < strtArray.Length; na += 2)
                        {
                            //MessageBox.Show(strtArray[na]);
                           // RoadList.Add(EquipmentDic[strtArray[na]]);
                        }
                    }
                }
                Train t0= new Train();
                TrainList.Add(t0);
                CarRoadDic.Add(t0, RoadList);
                t0.CountSpeed();
                Thread s = new Thread(RunCar);
                s.Start(t0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        void RunCar(object t0)
        {

            g1_EnterV.Text = ((Train)t0)._length.ToString();

        }
        /// <summary>
        /// 鼠标变手型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            p = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y - 30);
            foreach (BaseShape item in EquipmentList)
            {
                if (item.IsEnter(p)) Cursor = Cursors.Hand;
            }
        }
        /// <summary>
        /// 设备右键属性框的显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y - 30);
            P_you = p;
            try
            {
                if (e.Button == MouseButtons.Right)//右键菜单
                {
                    foreach (BaseShape item in EquipmentList)
                    {
                        if (item.IsEnter(p))
                        {
                            contextMenuStrip1.Visible = true;
                            contextMenuStrip1.Items.Clear();
                            for (int i = 0; i < item.M_RightShuXing.Length; i++)
                                contextMenuStrip1.Items.Add(item.M_RightShuXing[i]);
                            contextMenuStrip1.Show(this, e.Location);
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// 窗口关闭，强制关闭所有线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }
        /// <summary>
        /// 设备的单独操作实现，点击右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            AloneOperste.AloneOp(EquipmentList, P_you, e.ClickedItem.Text);
            Invalidate();
        }
        /// <summary>
        /// 制定调车勾计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 调车计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 系统还原初始化设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 系统还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
