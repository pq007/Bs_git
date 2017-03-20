using System;
using System.Drawing;

namespace TF_Program2017
{
    class Turnout : BaseShape
    {
        private int m_Direction;//岔尖方向
        private bool m_State;//定反位状态
        private int b_state;//圆圈的性质
        public bool State
        {
            get
            {
                return m_State;
            }

            set
            {
                m_State = value;
            }
        }
        public Turnout(string name, int type, int subtype, int colorflag, Point paintpoint, int direction, bool state, int fstate)
            : base(name, type, subtype, colorflag, paintpoint)
        {
            this.m_Direction = direction;
            this.State = state;
            this.b_state = fstate;
            this.M_RightShuXing = new string[] { "定位", "反位", "四开", "复原", "单锁", "单锁解锁", "故障占用", "故障解锁" };
        }
        Pen pn = null;
        int size = 3;
        Pen pnwhite = new Pen(Color.Black, 3);
        Pen pnEclipe = null;//画图圆圈
        Font font = new Font("粗体", 6);
        Brush b = new SolidBrush(Color.Black);//画刷
        Rectangle rc = new Rectangle(1, 1, 1, 1);//单动道岔的
        Rectangle rc1 = new Rectangle(1, 1, 1, 1);
        Rectangle rc2 = new Rectangle(1, 1, 1, 1);
        public override void Draw(Graphics g)
        {
           
            switch (M_ColorFlag)
            {
                case 0: pn = new Pen(Color.Gray, size); break;//线-常态
                case 1: pn = new Pen(Color.White, size); break;//线-锁闭
                case 2: pn = new Pen(Color.Red, size); break;//线-占用
                case 3: pn = new Pen(Color.Blue, size); break;//线-四开
                case 4: pn = new Pen(Color.Purple, size); break;//线-单锁
            }
            switch (b_state)//画圆圈
            {
                case 1: pnEclipe = new Pen(Color.Purple, 4); break;//圆圈-单锁
                case 2: pnEclipe = new Pen(Color.Blue, 4); break;//圆圈-四开
                case 3: pnEclipe = new Pen(Color.Red, 4); break;//圆圈-故障占用
            }
            switch (M_SubType)
            {
                case 1://单动道岔
                    g.DrawString(M_Name, font, Brushes.Gray, new Point(M_PaintPoint.X - 5, M_PaintPoint.Y - 10));
                    if (State)//定位
                    {
                        g.DrawLine(pn, new Point(M_PaintPoint.X - 30, M_PaintPoint.Y), new Point(M_PaintPoint.X + 20, M_PaintPoint.Y));
                        switch (m_Direction)
                        {
                            case 1://双边岔开右上
                                g.DrawLine(pnwhite, M_PaintPoint, new Point(M_PaintPoint.X + 20, M_PaintPoint.Y - 20));
                                rc = new Rectangle(new Point(M_PaintPoint.X + 18, M_PaintPoint.Y - 10), new Size(4, 4));
                                break;
                            case 2://岔开方向右下
                                g.DrawLine(pnwhite, M_PaintPoint, new Point(M_PaintPoint.X + 20, M_PaintPoint.Y + 20));

                                rc = new Rectangle(new Point(M_PaintPoint.X + 18, M_PaintPoint.Y + 8), new Size(4, 4));
                                break;
                        }
                        if (b_state > 0) g.DrawEllipse(pnEclipe, rc);
                        else
                            g.DrawEllipse(new Pen(Brushes.Green, 4), rc);
                    }
                    else
                    {
                        g.DrawLine(pnwhite, M_PaintPoint, new Point(M_PaintPoint.X + 20, M_PaintPoint.Y));
                        switch (m_Direction)
                        {
                            case 1://岔开方向you上
                                g.DrawLines(pn, new Point[3] { new Point(M_PaintPoint.X - 30, M_PaintPoint.Y), M_PaintPoint, new Point(M_PaintPoint.X + 20, M_PaintPoint.Y - 20) });
                                rc = new Rectangle(new Point(M_PaintPoint.X + 18, M_PaintPoint.Y - 10), new Size(4, 4));
                                break;
                            case 2://岔开方向右下
                                g.DrawLines(pn, new Point[3] { new Point(M_PaintPoint.X - 30, M_PaintPoint.Y), M_PaintPoint, new Point(M_PaintPoint.X + 20, M_PaintPoint.Y + 20) });
                                rc = new Rectangle(new Point(M_PaintPoint.X + 18, M_PaintPoint.Y + 8), new Size(4, 4));
                                break;
                        }
                        if (b_state > 0) g.DrawEllipse(pnEclipe, rc);
                        else
                            g.DrawEllipse(new Pen(Brushes.Yellow, 4), rc);
                    }
                    break;
                case 2://双动道岔
                    string sf = M_Name.Split('0')[0];
                    string sl = M_Name.Split('0')[1];
                    if (State)
                    {
                        switch (m_Direction)
                        {
                            case 1:
                                g.DrawString(sf, font, Brushes.Gray, new Point(M_PaintPoint.X - 5, M_PaintPoint.Y - 10));
                                g.DrawString(sl, font, Brushes.Gray, new Point(M_PaintPoint.X - 5 + 78, M_PaintPoint.Y - 10 + 93));
                                g.DrawLine(pn, new Point(M_PaintPoint.X - 30, M_PaintPoint.Y), new Point(M_PaintPoint.X + 20, M_PaintPoint.Y));
                                g.DrawLine(pn, new Point(M_PaintPoint.X + 60, M_PaintPoint.Y + 80), new Point(M_PaintPoint.X + 110, M_PaintPoint.Y + 80));
                                g.DrawLine(pnwhite, M_PaintPoint, new Point(M_PaintPoint.X + 20, M_PaintPoint.Y + 20));
                                g.DrawLine(new Pen(Brushes.Gray, 4), new Point(M_PaintPoint.X + 10, M_PaintPoint.Y + 10), new Point(M_PaintPoint.X + 70, M_PaintPoint.Y + 70));
                                rc1 = new Rectangle(new Point(M_PaintPoint.X + 18, M_PaintPoint.Y + 6), new Size(4, 4));
                                rc2 = new Rectangle(new Point(M_PaintPoint.X + 58, M_PaintPoint.Y + 70), new Size(4, 4));
                                break;
                            case 2:
                                g.DrawString(sf, font, Brushes.Gray, new Point(M_PaintPoint.X - 5, M_PaintPoint.Y - 10));
                                g.DrawString(sl, font, Brushes.Gray, new Point(M_PaintPoint.X - 5 - 75, M_PaintPoint.Y - 10 + 93));
                                g.DrawLine(pn, new Point(M_PaintPoint.X - 20, M_PaintPoint.Y), new Point(M_PaintPoint.X + 30, M_PaintPoint.Y));
                                g.DrawLine(pn, new Point(M_PaintPoint.X - 110, M_PaintPoint.Y + 80), new Point(M_PaintPoint.X - 60, M_PaintPoint.Y + 80));
                                g.DrawLine(pnwhite, M_PaintPoint, new Point(M_PaintPoint.X - 20, M_PaintPoint.Y + 20));
                                g.DrawLine(new Pen(Brushes.Gray, 4), new Point(M_PaintPoint.X - 10, M_PaintPoint.Y + 10), new Point(M_PaintPoint.X - 70, M_PaintPoint.Y + 70));
                                rc1 = new Rectangle(new Point(M_PaintPoint.X - 22, M_PaintPoint.Y + 6), new Size(4, 4));
                                rc2 = new Rectangle(new Point(M_PaintPoint.X - 64, M_PaintPoint.Y + 70), new Size(4, 4));
                                break;
                            default: break;
                        }
                        if (b_state > 0) { g.DrawEllipse(pnEclipe, rc1); g.DrawEllipse(pnEclipe, rc2); }
                        else { g.DrawEllipse(new Pen(Brushes.Green, 4), rc1); g.DrawEllipse(new Pen(Brushes.Green, 4), rc2); }
                    }
                    else
                    {
                        switch (m_Direction)
                        {
                            case 1:
                                g.DrawString(sf, font, Brushes.Gray, new Point(M_PaintPoint.X - 5, M_PaintPoint.Y - 10));
                                g.DrawString(sl, font, Brushes.Gray, new Point(M_PaintPoint.X - 5 + 78, M_PaintPoint.Y - 10 + 93));
                                g.DrawLines(pn, new Point[4] { new Point(M_PaintPoint.X - 30, M_PaintPoint.Y), M_PaintPoint, new Point(M_PaintPoint.X + 80, M_PaintPoint.Y + 80), new Point(M_PaintPoint.X + 110, M_PaintPoint.Y + 80) });
                                g.DrawLine(pnwhite, new Point(M_PaintPoint.X + 20, M_PaintPoint.Y), M_PaintPoint);
                                g.DrawLine(pnwhite, new Point(M_PaintPoint.X + 80, M_PaintPoint.Y + 80), new Point(M_PaintPoint.X + 60, M_PaintPoint.Y + 80));
                                rc1 = new Rectangle(new Point(M_PaintPoint.X + 18, M_PaintPoint.Y + 6), new Size(4, 4));
                                rc2 = new Rectangle(new Point(M_PaintPoint.X + 58, M_PaintPoint.Y + 70), new Size(4, 4));
                                break;
                            case 2:
                                g.DrawString(sf, font, Brushes.Gray, new Point(M_PaintPoint.X - 5, M_PaintPoint.Y - 10));
                                g.DrawString(sl, font, Brushes.Gray, new Point(M_PaintPoint.X - 5 - 75, M_PaintPoint.Y - 10 + 93));
                                g.DrawLines(pn, new Point[4] { new Point(M_PaintPoint.X + 30, M_PaintPoint.Y), M_PaintPoint, new Point(M_PaintPoint.X - 80, M_PaintPoint.Y + 80), new Point(M_PaintPoint.X - 110, M_PaintPoint.Y + 80) });
                                g.DrawLine(pnwhite, new Point(M_PaintPoint.X - 30, M_PaintPoint.Y), M_PaintPoint);
                                g.DrawLine(pnwhite, new Point(M_PaintPoint.X - 80, M_PaintPoint.Y + 80), new Point(M_PaintPoint.X - 60, M_PaintPoint.Y + 80));
                                rc1 = new Rectangle(new Point(M_PaintPoint.X - 22, M_PaintPoint.Y + 6), new Size(4, 4));
                                rc2 = new Rectangle(new Point(M_PaintPoint.X - 64, M_PaintPoint.Y + 70), new Size(4, 4));
                                break;
                            default: break;
                        }
                        if (b_state > 0) { g.DrawEllipse(pnEclipe, rc1); g.DrawEllipse(pnEclipe, rc2); }
                        else { g.DrawEllipse(new Pen(Brushes.Yellow, 4), rc1); g.DrawEllipse(new Pen(Brushes.Yellow, 4), rc2); }
                    }
                    break;
                default: break;
            }
        }
        /// <summary>
        /// 点击圆圈来改变性质
        /// </summary>
        /// <param name="mouse_point"></param>
        /// <returns></returns>
        public override bool IsEnter(Point mouse_point)
        {
            if (mouse_point.X > rc.Location.X && mouse_point.X < rc.Location.X + 13 && mouse_point.Y > rc.Location.Y && mouse_point.Y < rc.Location.Y + 13)
                return true;
            else
                return false;
        }

        static int flag;
        public override void JudgeState(string state)
        {
            switch (state)
            {
                case "定位":
                    if (b_state > 0) { }//道岔，不能转换
                    else { m_State = true; M_ColorFlag = 0; }
                    break;
                case "反位":
                    if (b_state > 0) { }//道岔，不能转换
                    else { m_State = false; M_ColorFlag = 0; }
                    break;
                case "四开":
                    if (b_state != 1 && M_ColorFlag != 1 && b_state != 3)//锁闭,单锁之后不会出现四开
                    { b_state = 2; flag = M_ColorFlag; M_ColorFlag = 3; }
                    break;
                case "单锁":
                    if (b_state != 2 && M_ColorFlag != 1 && b_state != 3)//四开,选路锁闭之后时不能单锁
                    { b_state = 1; flag = M_ColorFlag; M_ColorFlag = 4; }
                    break;
                case "故障占用":
                    if (b_state != 1 && b_state != 2)//单锁，四开时不故障占用
                    { b_state = 3; flag = M_ColorFlag; M_ColorFlag = 2; }
                    break;
                case "复原"://复原四开状态
                    if (b_state == 2) { b_state = 0; M_ColorFlag = flag; }
                    break;
                case "单锁解锁":
                    if (b_state == 1) { b_state = 0; M_ColorFlag = flag; }
                    break;
                case "故障解锁"://解故障占用
                    if (b_state == 3) { b_state = 0; M_ColorFlag = flag; }
                    break;

            }
        }
    }
}
