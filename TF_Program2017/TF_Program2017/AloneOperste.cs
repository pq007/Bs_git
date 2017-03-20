using System.Collections.Generic;
using System.Drawing;

namespace TF_Program2017
{
    class AloneOperste
    {
        /// <summary>
        /// 设备的单独操作实现
        /// </summary>
        /// <param name="EquipmentList"></param>
        /// <param name="p"></param>
        /// <param name="state"></param>
        public static void AloneOp(List<BaseShape> EquipmentList, Point p, string state)
        {
            foreach (BaseShape item in EquipmentList)
            {
                if (item.IsEnter(p))
                {
                    switch (item.M_Type)
                    {
                        case 1: Semaphore se = (Semaphore)item; se.JudgeState(state); break;
                        case 2: Turnout tn = (Turnout)item; tn.JudgeState(state); break;
                        case 3: TrackCircuit tc = (TrackCircuit)item; tc.JudgeState(state); break;
                        case 4: Reducer re = (Reducer)item; re.JudgeState(state); break;
                    }
                }
            }
        }
    }
}
