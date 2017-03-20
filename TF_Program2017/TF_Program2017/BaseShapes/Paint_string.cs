using System.Collections.Generic;
using System.Drawing;

namespace TF_Program2017
{
    public class Paint_string
    {
        public static void PaintAgain(List<BaseShape> list, Graphics g)
        {
            g.Clear(Color.Black);
            g.DrawString("虚拟驼峰编组站", new Font("宋体", 18), Brushes.White, new PointF(50, 80));
            g.DrawString("禁溜1", new Font("宋体", 10), Brushes.White, new Point(470, 135));
            g.DrawString("禁溜2", new Font("宋体", 10), Brushes.White, new Point(470, 535));
            g.DrawString("迂 回 1", new Font("宋体", 10), Brushes.White, new Point(500, 46));
            g.DrawString("迂 回 2", new Font("宋体", 10), Brushes.White, new Point(500, 606));
            foreach (BaseShape item in list)
            {
                item.Draw(g);
            }
        }
    }
}
