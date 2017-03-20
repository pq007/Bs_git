using System;
using System.Drawing;

namespace TF_Program2017
{
    abstract public class BaseShape
    {
        public string M_Name;//设备名称
        public int M_Type;//类型码
        public int M_SubType;//子类型码
        public int M_ColorFlag;//颜色标志
        public Point M_PaintPoint;//画图基点
        public string[] M_RightShuXing;//鼠标右键的属性
        public BaseShape(string name,int type,int subtype,int colorflag,Point paintpoint)
        {
            this.M_Name = name;
            this.M_Type = type;
            this.M_SubType = subtype;
            this.M_ColorFlag = colorflag;
            this.M_PaintPoint = paintpoint;
        }
        public abstract void Draw(Graphics g);//绘图方法
        public abstract bool IsEnter(Point mouse_point);//设备点击
        public abstract void JudgeState(string state);//单独操作用
    }
}
