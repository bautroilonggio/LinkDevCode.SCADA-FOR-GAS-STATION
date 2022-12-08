using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S7.Net;
using S7.Net.Types;
using System.Data;
using System.Data.SqlClient;

namespace Web_XANGDAU
{
    public class PLC_Command
    {
        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;

        static public PLC_Command DiezelTank1 = new PLC_Command("Diezel Tank 1", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public PLC_Command DiezelTank2 = new PLC_Command("Diezel Tank 2", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public PLC_Command RON95Tank1 = new PLC_Command("RON95 Tank 1", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public PLC_Command RON95Tank2 = new PLC_Command("RON95 Tank 2", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public PLC_Command RON92Tank1 = new PLC_Command("RON92 Tank 1", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public PLC_Command RON92Tank2 = new PLC_Command("RON92 Tank 2", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public PLC_Command E100Tank1 = new PLC_Command("E100 Tank 1", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public PLC_Command E100Tank2 = new PLC_Command("E100 Tank 2", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public PLC_Command E5 = new PLC_Command("E5", "DB5", "DB1", "DB2", "DB7", "DB6");
        static public int TankIndex = 0;    //diezel

        //Các biến thông số họng
        public struct throat_t
        {
            public string DB_send;
            public string DB_recv;
            public double Start;
            public double Stop;
            public double Enable;
            public double PS;
            public double Setpoint;
            public double Ready;
            public double Running;
            public double Vout;
            public double Ctrlvalue;
            public double Flow;
        }

        //Các biến thông số Tank
        public string TankName;
        public string DB;
        public double TankHeight;
        public double TankBaseArea;
        public double InitialLevel;
        public double Level;
        public double LevelLow;
        public double LevelVeryLow;
        public double LevelHigh;
        public double LevelVeryHigh;
        public double Temp;
        public double TempLow;
        public double TempVeryLow;
        public double TempHigh;
        public double TempVeryHigh;
        public double VCurr;
        public double Price;
        public double PriceTotal;
        public int LevelStt;            //     0:verylow   1:low   2: normal    3:high    4:veryhigh
        public string LevelSttMessage;
        public int TempStt;             //    0:verylow   1:low   2: normal   3:high    4:veryhigh
        public string TempSttMessage;
        public throat_t throat1, throat2;
        public double LevelPer;

        //Biến tank E5
        public double FlowOutRON92;                     //Lưu lượng xuất RON92
        public double FlowOutE100;                      //Lưu lượng xuất E100
        public double BatchValRON92;                    //Độ mở van xuất RON92
        public double BatchValE100;                     //Dộ mở van xuất E100               

        //Đơn vị của dữ liệu
        public string unitOpenValve = " (%)";       //Độ mở van
        public string unitFlow = " (m3/h)";         //Lưu lượng
        public string unitLevel = " (m)";           //Mức
        public string unitTemp = " (°C)";           //Nhiệt độ


        //Biến kết nối với plc
        static public Plc plc = new Plc(CpuType.S71500, "192.168.0.1", 0, 0);
        static public bool plcConnectd = false;
        static public string plcIP = "";

        //Đọc dữ liệu từ PLC
        public double ReadDataFromPLC(string _DB, string _addr)
        {
            if (_addr[2] == 'X')    //bool var
                return Convert.ToDouble(plc.Read(_DB + "." + _addr));
            else   //real var
                return ((uint)plc.Read(_DB + "." + _addr)).ConvertToDouble();
        }

        public PLC_Command(string _tank_name,string DB_name, string DB_name_throat1_send, string DB_name_throat1_recv, string DB_name_throat2_send, string DB_name_throat2_recv)
        {
            TankName = _tank_name;
            DB = DB_name;
            throat1.DB_send = DB_name_throat1_send;
            throat1.DB_recv = DB_name_throat1_recv;
            throat2.DB_send = DB_name_throat2_send;
            throat2.DB_recv = DB_name_throat2_recv;
        }

        public void ReadData()
        {
            Temp = ReadDataFromPLC(DB, "DBD0");
            Level = ReadDataFromPLC(DB, "DBD4");
            InitialLevel = ReadDataFromPLC(DB, "DBD8");
            TankBaseArea = ReadDataFromPLC(DB, "DBD12");
            VCurr = ReadDataFromPLC(DB, "DBD16");
            throat1.Flow = ReadDataFromPLC(DB, "DBD24");
            throat2.Flow = ReadDataFromPLC(DB, "DBD28");
            throat1.Enable = ReadDataFromPLC(throat1.DB_send, "DBX0.2");
            throat2.Enable = ReadDataFromPLC(throat2.DB_send, "DBX0.2");
            throat1.Ready = ReadDataFromPLC(throat1.DB_recv, "DBX0.0");
            throat1.Running = ReadDataFromPLC(throat1.DB_recv, "DBX0.1");
            throat1.Vout = ReadDataFromPLC(throat1.DB_recv, "DBD4");
            throat1.Ctrlvalue = ReadDataFromPLC(throat1.DB_recv, "DBD8");
            throat2.Ready = ReadDataFromPLC(throat2.DB_recv, "DBX0.0");
            throat2.Running = ReadDataFromPLC(throat2.DB_recv, "DBX0.1");
            throat2.Vout = ReadDataFromPLC(throat2.DB_recv, "DBD4");
            throat2.Ctrlvalue = ReadDataFromPLC(throat2.DB_recv, "DBD8");
            LevelPer = Math.Round(100*(Level / TankHeight),2);
        }

        //Load thông số cài đặt tank
        public void LoadTank()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();

            sql = @"Select *From ThongSoTank Where Tank = N'" + TankName + "'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                LevelVeryHigh = double.Parse(docdulieu["MucQuaCao"].ToString());
                LevelHigh = double.Parse(docdulieu["MucCao"].ToString());
                LevelLow = double.Parse(docdulieu["MucThap"].ToString());
                LevelVeryLow = double.Parse(docdulieu["MucQuaThap"].ToString());

                TempVeryHigh = double.Parse(docdulieu["NhietQuaCao"].ToString());
                TempHigh = double.Parse(docdulieu["NhietCao"].ToString());
                TempLow = double.Parse(docdulieu["NhietThap"].ToString());
                TempVeryLow = double.Parse(docdulieu["NhietQuaThap"].ToString());

                TankHeight = double.Parse(docdulieu["ChieuCao"].ToString());
                TankBaseArea = double.Parse(docdulieu["DienTichDay"].ToString());
            }

            ketnoi.Close();
        }
    }
}