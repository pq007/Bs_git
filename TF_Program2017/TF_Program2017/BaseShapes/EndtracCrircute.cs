using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_Program2017
{
    class EndtracCrircute : BaseShape
    {
        private Point m_Rightpoint;//右侧坐标
        private int m_Length;//调车场股道长度
        public EndtracCrircute(string name, int type, int subtype, int colorflag, Point paintpoint, Point rightpoint, int leng)
            : base(name, type, subtype, colorflag, paintpoint)
        {
            this.m_Rightpoint = rightpoint;
            this.m_Length = leng;
        }
        public override void Draw(Graphics g)
        {
            Pen pn = null;
            int size = 3;
            Font font = new Font("粗体", 8);
            Brush b = new SolidBrush(Color.White);
            switch (M_ColorFlag)
            {
                case 0://常态有车
                    pn = new Pen(Color.Red, size);
                    g.DrawLine(new Pen(Color.Gray, size), M_PaintPoint, new Point(M_PaintPoint.X + 50, M_PaintPoint.Y));
                    g.DrawLine(pn, new Point(M_PaintPoint.X + 50, M_PaintPoint.Y), m_Rightpoint);
                    break;
                case 1://锁闭有车
                    pn = new Pen(Color.Red, size);
                    g.DrawLine(new Pen(Color.White, size), M_PaintPoint, new Point(M_PaintPoint.X + 50, M_PaintPoint.Y));
                    g.DrawLine(pn, new Point(M_PaintPoint.X + 50, M_PaintPoint.Y), m_Rightpoint);
                    break;
                case 2://占用有车
                    pn = new Pen(Color.Red, size);
                    g.DrawLine(new Pen(Color.Red, size), M_PaintPoint, new Point(M_PaintPoint.X + 50, M_PaintPoint.Y));
                    g.DrawLine(pn, new Point(M_PaintPoint.X + 50, M_PaintPoint.Y), m_Rightpoint);
                    break;
                default: break;
            }

        }

        public override bool IsEnter(Point mouse_point)
        {
            if (M_SubType != 2 && M_PaintPoint.Y == m_Rightpoint.Y)//直线两点
            {
                if (mouse_point.X > M_PaintPoint.X + 5 && mouse_point.X < m_Rightpoint.X + 5 && mouse_point.Y > m_Rightpoint.Y - 4 && mouse_point.Y < m_Rightpoint.Y + 6)//基点周围的一个正方形
                    return true;
                else
                    return false;
            }
            return false;
        }
        public override void JudgeState(string state)
        {
        }
    }
}
