using System;
using System.Drawing;

namespace TF_Program2017
{
    public class TrackCircuit : BaseShape
    {
        private Point m_Midpoint;//中间点
        private Point m_Rightpoint;//右侧坐标
        private int m_Length;//轨道电路长度//未使用
        public TrackCircuit(string name, int type, int subtype, int colorflag, Point paintpoint, Point midpoint, Point rightpoint, int length)
            : base(name, type, subtype, colorflag, paintpoint)
        {
            this.m_Midpoint = midpoint;
            this.m_Rightpoint = rightpoint;
            this.m_Length = length;
            this.M_RightShuXing = new string[] { "分路不良", "故障占用", "故障解锁" };
        }
        public override void Draw(Graphics g)
        {
            Pen pn = null;
            int size = 3;
            Font font = new Font("粗体", 8);
            Brush b = new SolidBrush(Color.White);
            switch (M_ColorFlag)
            {
                case 0://常态
                    pn = new Pen(Color.Gray, size);
                    break;
                case 1://锁闭
                    pn = new Pen(Color.White, size);
                    break;
                case 2://占用
                    pn = new Pen(Color.Red, size);
                    break;
                case 3://分路不良
                    pn = new Pen(Color.Blue, size);
                    break;
                default: break;
            }
            switch (M_SubType)
            {
                case 1: g.DrawLine(pn, M_PaintPoint, m_Rightpoint); break;
                case 2: g.DrawLines(pn, new Point[3] { M_PaintPoint, m_Midpoint, m_Rightpoint }); break;
                case 3: g.DrawLine(pn, M_PaintPoint, m_Rightpoint); break;
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
            else if (M_SubType != 2 && M_PaintPoint.Y != m_Rightpoint.Y)//斜线两点
            {
                if (mouse_point.X > (M_PaintPoint.X + m_Rightpoint.X) / 2 && mouse_point.X < (M_PaintPoint.X + m_Rightpoint.X) / 2 + 8 && mouse_point.Y > (M_PaintPoint.Y + m_Rightpoint.Y) / 2 - 10 && mouse_point.Y < (M_PaintPoint.Y + m_Rightpoint.Y) / 2 + 10)//基点周围的一个正方形
                    return true;
                else
                    return false;
            }
            else if (M_SubType == 2)//三点
            {
                if (mouse_point.X > m_Midpoint.X + 2 && mouse_point.X < m_Midpoint.X + 10 && mouse_point.Y > m_Midpoint.Y - 8 && mouse_point.Y < m_Midpoint.Y + 8)//基点周围的一个正方形
                    return true;
                else
                    return false;
            }

            return false;
        }
        int F_state = -1;
        public override void JudgeState(string state)
        {
            switch (state)
            {
                case "分路不良": F_state = M_ColorFlag; M_ColorFlag = 3; break;//临时性故障
                case "故障占用": F_state = M_ColorFlag; M_ColorFlag = 2; break;
                case "故障解锁": if (F_state != -1) M_ColorFlag = F_state; break;
            }
        }
    }
}
