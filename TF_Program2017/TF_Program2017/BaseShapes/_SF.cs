using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_Program2017
{
    /// <summary>
    /// 尽头线标志
    /// </summary>
    class _SF : BaseShape
    {
        public _SF(string name, int type, int subtype, int colorflag, Point paintpoint)
            :base(name,type,subtype,colorflag,paintpoint)
        {

        }
        public override void Draw(Graphics g)
        {
            g.DrawLines(new Pen(Brushes.Gray, 2),
                new Point[4] {new Point(M_PaintPoint.X+7, M_PaintPoint.Y+5), new Point(M_PaintPoint.X, M_PaintPoint.Y + 5) ,
                new Point(M_PaintPoint.X , M_PaintPoint.Y - 5) , new Point(M_PaintPoint.X + 7, M_PaintPoint.Y - 5) });
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
