using System.Collections.Generic;
using System.Drawing;

namespace TF_Program2017
{
    public class Road
    {
        public static string XLerror;
        public static string[] Accessroad;//当前联锁表所表示的进路信息字符串
        /// <summary>
        /// 由始端通过联锁表告知可以按压的终端，返回所有终端string[]
        /// </summary>
        /// <param name="始端信号设备"></param>
        /// <returns></returns>
        public static string[] SearchFroad(string firstequipment)
        {
            string[] r = new string[10];
            int i = 0; Semaphore se = null;
            foreach (string item in Form1.ALLAccessRoad)
            {
                string[] strtArray = item.Split(',');
                foreach (BaseShape item0 in Form1.EquipmentList)
                {
                    if (strtArray[1].Equals(item0.M_Name))
                    {
                        se = (Semaphore)item0;
                    }
                }
                if (strtArray[0].Equals(firstequipment) && se.enableclick)//终端要可以按压
                { r[i++] = strtArray[1]; }
            }
            return r;
        }
        /// <summary>
        /// 是否能成功选路，能则返回true，不能返回false
        /// </summary>
        /// <param name="始端设备名称"></param>
        /// <param name="终端设备名称"></param>
        /// <returns></returns>
        public static bool RoadIsOk(string m_fname,string m_lname)
        {
            Semaphore se=null;
            foreach (BaseShape item in Form1.EquipmentList)
            {
                if (item.M_Name.Equals(m_fname) && item.M_ColorFlag == 0) { se = (Semaphore)item; se.RoadEList1.Add(se); }//始端
               
            }
            //存储信息进列表
            foreach (string item in Form1.ALLAccessRoad)
            {
                string[] strtArray = item.Split(',');
                if (strtArray[0].Equals(m_fname) && strtArray[1].Equals(m_lname))
                {
                    Accessroad = strtArray;
                    foreach (BaseShape itemd in Form1.EquipmentList)
                    {
                        if (itemd.M_Name.Equals(Accessroad[2]))
                        {
                            if (itemd.M_Type==3) se.RoadEList1.Add((TrackCircuit)itemd);
                            else if (itemd.M_Type == 2)  se.RoadEList1.Add((Turnout)itemd);
                        }//接近区段
                    }
                    for (int i = 4; i < Accessroad.Length; i += 2)
                    {
                        foreach (BaseShape temp1 in Form1.EquipmentList)//验证进路所有设备是否出于正常未锁闭状态
                        {
                            if (temp1.M_Name.Equals(Accessroad[i]))
                            {
                                if (temp1.M_ColorFlag != 0)
                                {
                                    XLerror = temp1.M_Name;
                                    foreach (BaseShape item2 in se.RoadEList1)
                                    {
                                        if (item2.M_Type == 1)
                                        {
                                            Semaphore se0 = (Semaphore)item2;
                                            se0.enableclick = true;
                                        }
                                    }
                                    se.RoadEList1.Clear();
                                    return false;
                                }//选不出，直接退出
                                else//选出，加入始端信号机进路列表，进路内所有的信号机不能再次按压
                                {
                                    se.RoadEList1.Add(temp1);
                                    if (temp1.M_Type == 1)
                                    { Semaphore s = (Semaphore)temp1; s.enableclick = false;
                                        if (s.M_SubType == 4) s.M_ColorFlag = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static bool RoadLockIsOk(Semaphore se)
        {
            if (se.RoadEList1[0].M_ColorFlag != 0) { XLerror = se.RoadEList1[0].M_Name; return false; }
            for (int i = 2; i < se.RoadEList1.Count; i++)
            {
                if ((se.RoadEList1[i].M_Type!=1&& se.RoadEList1[i].M_ColorFlag != 1&& se.RoadEList1[i].M_Type != 4) ||
                    ( se.RoadEList1[i].M_Type == 1 && se.RoadEList1[i].M_ColorFlag != 0&& se.RoadEList1[i].M_SubType!=4)||
                    (se.RoadEList1[i].M_Type == 4 && se.RoadEList1[i].M_ColorFlag != 0))
                {
                    XLerror = se.RoadEList1[i].M_Name; return false;
                }
            }
            return true;
        }

    }
}
