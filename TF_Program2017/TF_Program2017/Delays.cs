using System;
using System.Windows.Forms;

namespace TF_Program2017
{
    public class Delays
    {
        /// <summary>
        /// //延迟系统时间，但系统又能同时能执行其它任务；
        /// </summary>
        /// <param name="毫秒"></param>
        static public void Delay(int Millisecond)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权            
            }
            return;
        }
    }
}
