using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TF_Program2017
{
    /// <summary>
    /// 1-------主驼峰信号机
    /// 2，3----调车信号机
    /// 4-------线路表示器
    /// </summary>
    public class Semaphore:BaseShape
    {
        private bool m_Direction;//信号机方向
        private bool m_height;//信号机高柱矮柱 
        private string m_FirTrackCircuit;//信号机始处的接近区段
        public bool enableclick;//按钮继电器的功能
        public bool openflag = false;//信号继电器的功能

        Pen pn = new Pen(Color.White, 2);//画笔
        Font font = new Font("粗体", 7);
        Brush br = null;
        public Semaphore(string name, int type, int subtype,int colorflag, Point paintpoint, bool direction, bool height, string firtrackcircuit,bool enableclick0)
            :base(name,type,subtype,colorflag,paintpoint)
        {
            this.m_Direction = direction;
            this.m_height = height;
            this.m_FirTrackCircuit = firtrackcircuit;
            this.enableclick= enableclick0;
            if (M_SubType == 1) M_RightShuXing = new string[] { "常速", "减速", "加速", "灭灯", "重开信号", "取消进路", "人工解锁", "故障复原" };
            else if (M_SubType != 4) M_RightShuXing = new string[] { "灭灯", "故障复原","模拟行车" };
        }
        public override void Draw(Graphics g)
        {
            Rectangle r1 = new Rectangle(1, 1, 1, 1);
            switch (M_SubType)
            {
                case 1://驼峰主信号机
                    g.DrawString(M_Name, font, Brushes.Gray, new Point(M_PaintPoint.X - 15, M_PaintPoint.Y + 5));
                    r1 = new Rectangle(M_PaintPoint.X + 6, M_PaintPoint.Y + 3, 12, 12);
                    g.DrawEllipse(pn, r1);
                    g.DrawLine(pn, new Point(M_PaintPoint.X, M_PaintPoint.Y + 4), new Point(M_PaintPoint.X, M_PaintPoint.Y + 15));
                    g.DrawLine(pn, new Point(M_PaintPoint.X, M_PaintPoint.Y + 9), new Point(M_PaintPoint.X + 6, M_PaintPoint.Y + 9));
                    switch (M_ColorFlag)//根据不同的信号状态显示不同的颜色
                    {
                        case 0://平时状态--红色
                            br = Brushes.Red;
                            break;
                        case 1://常速
                            br = Brushes.Green;
                            break;
                        case 111://灭灯--黑色
                            br = Brushes.Black;
                            break;
                        default: break;
                    }
                    g.FillEllipse(br, r1);
                    break;
                case 2://正放的驼峰调车信号机
                    if (m_Direction)
                    {
                        g.DrawString(M_Name, font, Brushes.Gray, new Point(M_PaintPoint.X - 22, M_PaintPoint.Y - 15));
                        r1 = new Rectangle(M_PaintPoint.X, M_PaintPoint.Y - 18, 12, 12);
                        g.DrawLine(pn, new Point(M_PaintPoint.X, M_PaintPoint.Y - 3), new Point(M_PaintPoint.X, M_PaintPoint.Y - 19));
                    }
                    else
                    {
                        g.DrawString(M_Name, font, Brushes.Gray, new PointF(M_PaintPoint.X + 2, M_PaintPoint.Y + 5));
                        r1 = new Rectangle(M_PaintPoint.X - 13, M_PaintPoint.Y + 5, 12, 12);
                        g.DrawLine(pn, new Point(M_PaintPoint.X, M_PaintPoint.Y + 3), new Point(M_PaintPoint.X, M_PaintPoint.Y + 19));
                    }
                    paint(g,br,pn,r1);
                    break;
                case 3://斜放的驼峰调车信号机
                    if (m_Direction)
                    {
                        g.DrawString(M_Name, font, Brushes.Gray, new Point(M_PaintPoint.X + 10, M_PaintPoint.Y - 5));
                        r1 = new Rectangle(M_PaintPoint.X - 4, M_PaintPoint.Y + 7, 12, 12);
                        g.DrawLine(pn, new Point(M_PaintPoint.X + 2, M_PaintPoint.Y + 2), new Point(M_PaintPoint.X + 13, M_PaintPoint.Y + 13));
                    }
                    else
                    {
                        g.DrawString(M_Name, font, Brushes.Gray, new Point(M_PaintPoint.X - 10, M_PaintPoint.Y + 8));
                        r1 = new Rectangle(M_PaintPoint.X - 20, M_PaintPoint.Y - 2, 12, 12);
                        g.DrawLine(pn, new Point(M_PaintPoint.X - 2, M_PaintPoint.Y + 2), new Point(M_PaintPoint.X - 15, M_PaintPoint.Y + 15));
                    }
                    paint(g,br, pn ,r1);
                    break;
                case 4://假线路选择器
                    Rectangle r = new Rectangle(M_PaintPoint.X, M_PaintPoint.Y - 26, 12, 12);
                    pn = new Pen(Color.White, 2);
                    g.DrawString(M_Name, font, Brushes.Gray, new Point(M_PaintPoint.X + 30, M_PaintPoint.Y - 20));
                    switch (M_ColorFlag)//根据不同的状态显示不同的颜色
                    {
                        case 0://平时状态--可按压
                            br = Brushes.Gray;
                            break;
                        case 1://禁止使用
                            br = Brushes.Red;
                            break;
                        case 111://闪光用
                            br = Brushes.Black;
                            break;
                        case 2://互锁
                            br = Brushes.Purple;
                            break;
                        default: break;
                    }
                    g.DrawEllipse(pn, r);
                    g.FillEllipse(br, r);
                    break;
                default: break;
            }
        }
        /// <summary>
        /// 调车信号机的颜色分布
        /// </summary>
        /// <param name="g"></param>
        /// <param name="br"></param>
        /// <param name="pn"></param>
        /// <param name="r1"></param>
        public void paint(Graphics g,Brush br, Pen pn, Rectangle r1)
        { 
            g.DrawEllipse(pn, r1);
            switch (M_ColorFlag)//根据不同的信号状态显示不同的颜色
            {
                case 0://平时状态--禁止
                    br = Brushes.Blue;
                    break;
                case 1://调车
                    br = Brushes.White;
                    break;
                case 111://灭灯
                    br = Brushes.Black;
                    break;
                default: break;
            }
            g.FillEllipse(br, r1);
        }
        public override bool IsEnter(Point mouse_point)
        {
                switch (M_SubType)
                {
                    case 1://主驼峰信号机
                        if (m_Direction)//正向-从左向右
                        {
                            if (mouse_point.X > M_PaintPoint.X + 8 && mouse_point.X < M_PaintPoint.X + 25 && mouse_point.Y > M_PaintPoint.Y + 3 && mouse_point.Y < M_PaintPoint.Y + 15)//基点周围的一个正方形
                                return true;
                            else
                                return false;
                        }
                        else//反向
                        {
                            if (mouse_point.X > M_PaintPoint.X + 12 && mouse_point.X < M_PaintPoint.X + 27 && mouse_point.Y > M_PaintPoint.Y + 5 && mouse_point.Y < M_PaintPoint.Y + 18)//基点周围的一个正方形
                                return true;
                            else
                                return false;
                        }
                    case 2://正调车信号机
                        if (m_Direction)//正向-从左向右
                        {
                            if (mouse_point.X + 3 > M_PaintPoint.X && mouse_point.X < M_PaintPoint.X + 20 && mouse_point.Y > M_PaintPoint.Y - 20 && mouse_point.Y < M_PaintPoint.Y)//基点周围的一个正方形
                                return true;
                            else
                                return false;
                        }
                        else//反向
                        {
                            if (mouse_point.X > M_PaintPoint.X - 10 && mouse_point.X < M_PaintPoint.X + 5 && mouse_point.Y > M_PaintPoint.Y && mouse_point.Y < M_PaintPoint.Y + 15)//基点周围的一个正方形
                                return true;
                            else
                                return false;
                        }
                    case 3://斜放调车信号机
                        if (m_Direction)//正向
                        {
                            if (mouse_point.X > M_PaintPoint.X - 7 && mouse_point.X < M_PaintPoint.X + 9 && mouse_point.Y > M_PaintPoint.Y + 9 && mouse_point.Y < M_PaintPoint.Y + 25)//基点周围的一个正方形
                                return true;
                            else
                                return false;
                        }
                        else//反向
                        {
                            if (mouse_point.X > M_PaintPoint.X - 23 && mouse_point.X < M_PaintPoint.X - 7 && mouse_point.Y > M_PaintPoint.Y - 6 && mouse_point.Y < M_PaintPoint.Y + 10)//基点周围的一个正方形
                                return true;
                            else
                                return false;
                        }
                    case 4:
                        {
                            if (mouse_point.X > M_PaintPoint.X && mouse_point.X < M_PaintPoint.X + 24 && mouse_point.Y > M_PaintPoint.Y - 26 && mouse_point.Y < M_PaintPoint.Y - 16)//基点周围的一个正方形
                                return true;
                            else
                                return false;
                        }
                    default: return false;
                }
        }
        public int F_state = -1;
        public override void JudgeState(string state)//判断完成之后自动重绘
        {
            switch (state)
            {
                case "灭灯": F_state = M_ColorFlag; M_ColorFlag = 111; break;
                case "故障复原":if (F_state != -1)
                    { M_ColorFlag = F_state; }
                    break;
            }
        }
    }
}
