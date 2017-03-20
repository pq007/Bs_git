using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TF_Program2017
{
    public class Train
    {
        public float _speed = 1;
        public float _length = 0;
        public TrackCircuit temptc;//占据的是哪个轨道电路
        float s;

        public void CountSpeed()
        {
            Thread th = new Thread(get);
            th.Start();
        }
        public void get()
        {
            while (true)
            {
                Delays.Delay(500);
                s = _speed * 2;
                _length += s;
            }
        }
    }
}
