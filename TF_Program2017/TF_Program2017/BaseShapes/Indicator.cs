using System;
using System.Drawing;

namespace TF_Program2017
{
    class Indicator : BaseShape
    {
        public Indicator(string name, int type, int subtype, int colorflag, Point paintpoint)
        {
            M_Name = name;
            M_Type = type;
            M_SubType = subtype;
            M_ColorFlag = colorflag;
            M_PaintPoint = paintpoint;
        }
        public override void Draw(Graphics g)
        {
            Pen pn = new Pen(Color.White, 2);//画笔
            Brush br = null;
            Rectangle r = new Rectangle(M_PaintPoint.X, M_PaintPoint.Y - 26, 12, 12);
            g.DrawEllipse(pn, r);
            switch (M_ColorFlag)//根据不同的状态显示不同的颜色
            {
                case 0://平时状态--可按压
                    br = Brushes.Gray;
                    break;
                case 1://禁止按压
                    br = Brushes.Red;
                    break;
                case 2://损坏
                    br = Brushes.Purple;
                    break;
                default: break;
            }
            g.FillEllipse(br, r);
        }

        public override bool IsEnter(Point mouse_point)
        {
            if (mouse_point.X > M_PaintPoint.X && mouse_point.X < M_PaintPoint.X + 24 && mouse_point.Y > M_PaintPoint.Y - 26 && mouse_point.Y < M_PaintPoint.Y - 16)//基点周围的一个正方形
                return true;
            else
                return false;
        }

        public override void JudgeState(string state)
        {

        }
    }
}
