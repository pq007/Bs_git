using System.Drawing;
using System.IO;

namespace TF_Program2017
{
    static public class IniData
    {
        static public void IniEquipmentData()
        {
            //初始化设备信息
            FileStream fs = new FileStream("...\\AllData.csv", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936));
            string str = "";
            str = sr.ReadLine();//第一行说明性文字，非数据
            str = sr.ReadLine();
            while (str != null)
            {
                string[] strtArray = str.Split(',');
                int typeflag = int.Parse(strtArray[1]);
                switch (typeflag)
                {
                    case 1://信号机（驼峰信号机，调车信号机，线路表示器）
                        Semaphore se = new Semaphore(strtArray[0], int.Parse(strtArray[1]), int.Parse(strtArray[2]),
                        int.Parse(strtArray[3]),
                        new Point(int.Parse(strtArray[4]), int.Parse(strtArray[5])),
                        bool.Parse(strtArray[6]), bool.Parse(strtArray[7]), strtArray[8],
                        bool.Parse(strtArray[9]));

                        Form1.EquipmentList.Add(se);
                        Form1.EquipmentDic.Add(se.M_Name, se);

                        break;
                    case 2://道岔（单动道岔，双动道岔）
                        Turnout tn = new Turnout(strtArray[0], int.Parse(strtArray[1]), int.Parse(strtArray[2]),
                        int.Parse(strtArray[3]),
                        new Point(int.Parse(strtArray[4]), int.Parse(strtArray[5])),
                        int.Parse(strtArray[6]), bool.Parse(strtArray[7]), int.Parse(strtArray[8]));

                        Form1.EquipmentList.Add(tn);
                        Form1.EquipmentDic.Add(tn.M_Name, tn);

                        break;
                    case 3://轨道电路---无道岔区段
                        TrackCircuit tc = new TrackCircuit(strtArray[0], int.Parse(strtArray[1]), int.Parse(strtArray[2]),
                        int.Parse(strtArray[3]),
                        new Point(int.Parse(strtArray[4]), int.Parse(strtArray[5])),
                        new Point(int.Parse(strtArray[6]), int.Parse(strtArray[7])),
                        new Point(int.Parse(strtArray[8]), int.Parse(strtArray[9])),
                        int.Parse(strtArray[10]));

                        Form1.EquipmentList.Add(tc);
                        Form1.EquipmentDic.Add(tc.M_Name, tc);

                        break;
                    case 4://减速器
                        Reducer rd = new Reducer(strtArray[0], int.Parse(strtArray[1]), int.Parse(strtArray[2]),
                        int.Parse(strtArray[3]),
                        new Point(int.Parse(strtArray[4]), int.Parse(strtArray[5])));

                        Form1.EquipmentList.Add(rd);
                        Form1.EquipmentDic.Add(rd.M_Name, rd);

                        break;
                    case 5://绝缘节
                        InsulationJoint ij = new InsulationJoint(strtArray[0], int.Parse(strtArray[1]), int.Parse(strtArray[2]),
                        int.Parse(strtArray[3]),
                        new Point(int.Parse(strtArray[4]), int.Parse(strtArray[5])));

                        Form1.EquipmentList.Add(ij);
                        //Form1.EquipmentDic.Add(ij.M_Name,ij);

                        break;
                    case 6://调车场轨道电路
                        EndtracCrircute el = new EndtracCrircute(strtArray[0], int.Parse(strtArray[1]), int.Parse(strtArray[2]),
                        int.Parse(strtArray[3]),
                        new Point(int.Parse(strtArray[4]), int.Parse(strtArray[5])),
                        new Point(int.Parse(strtArray[6]), int.Parse(strtArray[7])),
                        int.Parse(strtArray[8]));

                        Form1.EquipmentList.Add(el);
                        Form1.EquipmentDic.Add(el.M_Name, el);
                        break;
                    case 7://尽头线标志
                        _SF sd = new _SF(strtArray[0], int.Parse(strtArray[1]), int.Parse(strtArray[2]),
                        int.Parse(strtArray[3]),
                        new Point(int.Parse(strtArray[4]), int.Parse(strtArray[5])));
                        Form1.EquipmentList.Add(sd);
                        break;
                    default: break;
                }
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void IniLinkData()
        {
            //初始化联锁表信息
            FileStream fs = new FileStream("...\\liansuo.csv", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936));
            string str = "";
            str = sr.ReadLine();
            while (str != null)
            {
                Form1.ALLAccessRoad.Add(str);
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
    }
}
