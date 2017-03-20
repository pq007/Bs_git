using System;
using System.Drawing;

namespace TF_Program2017
{
    /// <summary>
    /// 绝缘结
    /// </summary>
    class InsulationJoint : BaseShape
    {
        public InsulationJoint(string name, int type, int subtype, int colorflag, Point paintpoint)
            :base(name,type,subtype,colorflag,paintpoint)
        {

        }
        public override void Draw(Graphics g)
        {
            Pen pn = new Pen(Color.White, 1);//画笔
            g.DrawLine(new Pen(Color.White, 2), new Point(M_PaintPoint.X, M_PaintPoint.Y - 2), new Point(M_PaintPoint.X, M_PaintPoint.Y + 3));
        }

        public override bool IsEnter(Point mouse_point)
        {
            return false;
        }

        public override void JudgeState(string state)
        {

        }
    }
}
