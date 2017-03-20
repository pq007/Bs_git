using System.Drawing;

namespace TF_Program2017
{
    /// <summary>
    /// 子类型
    /// </summary>
    class Reducer : BaseShape
    {
        private float Enter_velocity;//入口速度
        private float Out_velocity;//出口速度

        public Reducer(string name, int type, int subtype, int colorflag, Point paintpoint)
            :base(name,type,subtype,colorflag,paintpoint)
        {
            this.M_RightShuXing = new string[] { "半台减速", "全台减速","维修或故障","设备还原"};
            this.Enter_velocity1 = 0;
            this.Out_velocity1 = 0;
    }
        public override void Draw(Graphics g)
        {
            Pen pn1 = null;
            Pen pn2 = null;
            Font font = new Font("粗体", 8);
            Brush b = new SolidBrush(Color.White);
            switch (M_ColorFlag)
            {
                case 0://常态
                    pn1 = new Pen(Color.Gray, 2);
                    pn2 = new Pen(Color.Gray, 2);
                    break;
                case 1://半台减速
                    pn1 = new Pen(Color.White, 2);
                    pn2 = new Pen(Color.Gray, 2);
                    break;
                case 2://全台减速
                    pn1 = new Pen(Color.White, 2);
                    pn2 = new Pen(Color.White, 2);
                    break;
                case 3://设备维修或故障
                    pn1 = new Pen(Color.Red, 2);
                    pn2 = new Pen(Color.Red, 2);
                    break;
                default: break;
            }
            g.DrawString(M_Name, font, Brushes.Gray, new Point(M_PaintPoint.X + 10, M_PaintPoint.Y - 22));
            g.DrawRectangle(pn1, new Rectangle(M_PaintPoint.X, M_PaintPoint.Y - 7, 20, 12));
            g.DrawRectangle(pn2, new Rectangle(M_PaintPoint.X + 20, M_PaintPoint.Y - 7, 20, 12));
        }
        public override bool IsEnter(Point mouse_point)
        {
            if (mouse_point.X > M_PaintPoint.X && mouse_point.X < M_PaintPoint.X + 40 && mouse_point.Y > M_PaintPoint.Y - 7 && mouse_point.Y < M_PaintPoint.Y + 6)//基点周围的一个正方形
                return true;
            else
                return false;
        }
        public float Enter_velocity1
        {
            get
            {
                return Enter_velocity;
            }

            set
            {
                Enter_velocity = value;
            }
        }

        public float Out_velocity1
        {
            get
            {
                return Out_velocity;
            }

            set
            {
                Out_velocity = value;
            }
        }

        public override void JudgeState(string state)
        {
            switch (state)
            {
                case "半台减速":M_ColorFlag = 1;break;
                case "全台减速": M_ColorFlag = 2; break;
                case "维修或故障":M_ColorFlag = 3; break;
                case "设备还原": M_ColorFlag =0; break;

            }

        }
    }
}
