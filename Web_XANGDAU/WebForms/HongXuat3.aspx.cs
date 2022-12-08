using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S7.Net;   //Thư viện kết nối với PLC
using S7.Net.Types;
using Web_XANGDAU;  //Thư mục chứa PLC_Command

namespace Web_XANGDAU.WebForms
{
    public partial class HongXuat3 : System.Web.UI.Page
    {
        GlobalFunction globalFunction = new GlobalFunction();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Load thông tin mã đơn cần thực hiện
            txt_MaDonXuat.Text = Web_XANGDAU.MasterPage_Scada.ThongTin.MaDon_Hong3;
            globalFunction.LoadThongTinDon(txt_MaDonXuat.Text);
            txt_TheTichCanXuat.Text = globalFunction.TheTichYeuCau;
            txt_SanPham.Text = globalFunction.SanPham;
            txt_DonGia.Text = globalFunction.DonGia;
            txt_ThanhTien.Text = globalFunction.ThanhTien;
            txt_TrangThai.Text = globalFunction.TrangThaiDon;

            PLC_Command.RON92Tank1.LoadTank();

            //Mở kết nối với PLC
            if (PLC_Command.plc.Open() == ErrorCode.NoError)
            {
                lbl_KetNoi.Text = "Đã kết nối";
                lbl_KetNoi.ForeColor = System.Drawing.Color.Black;

                PLC_Command.RON92Tank1.ReadData();
            }
        }

        protected void Timer_Hong3_Tick(object sender, EventArgs e)
        {
            txt_Muc.Text = PLC_Command.RON92Tank1.Level + PLC_Command.RON92Tank1.unitLevel;
            txt_NhietDo.Text = PLC_Command.RON92Tank1.Temp + PLC_Command.RON92Tank1.unitTemp;
            txt_VanXuat.Text = PLC_Command.RON92Tank1.throat1.Ctrlvalue.ToString() + PLC_Command.RON92Tank1.unitOpenValve;
            txt_LuuLuongXuat.Text = PLC_Command.RON92Tank1.throat1.Flow.ToString() + PLC_Command.RON92Tank1.unitFlow;
            txt_TheTichDaXuat.Text = PLC_Command.RON92Tank1.throat1.Vout.ToString();

            pn_MucPer.Attributes["style"] = "width:" + PLC_Command.RON92Tank1.LevelPer + "%";
            lbl_MucPer.Text = PLC_Command.RON92Tank1.LevelPer.ToString() + "%";

            StatusSymbol();

            
        }

        private void StatusSymbol()
        {
            //Trạng thái van xuất
            //Khi van đóng
            if (PLC_Command.RON92Tank1.throat1.Ctrlvalue == 0)
            {
                SVanXuat_1.Visible = false;
                SVanXuat_2.Visible = false;
            }
            //Khi van mở
            else if (PLC_Command.RON92Tank1.throat1.Ctrlvalue > 0 && PLC_Command.RON92Tank1.throat1.Ctrlvalue <= 100)
            {
                SVanXuat_1.Visible = true;
                SVanXuat_2.Visible = false;
            }
            //Khi van lỗi
            else
            {
                SVanXuat_1.Visible = false;
                SVanXuat_2.Visible = true;

                txt_VanXuat.ForeColor = System.Drawing.Color.Red;
            }

            //Trạng thái bơm xuất
            //Khi bơm chạy
            if (PLC_Command.RON92Tank1.throat1.Running == 1)
            {
                SBomXuat_1.Visible = true;
                SBomXuat_2.Visible = false;
            }
            //Khi bơm dừng
            else
            {
                SBomXuat_1.Visible = false;
                SBomXuat_2.Visible = false;
            }

            //Trạng thái cảnh báo mức
            //Trên mức HH
            if (PLC_Command.RON92Tank1.Level >= PLC_Command.RON92Tank1.LevelVeryHigh)
            {
                SMucHH_2.Visible = true;
                SMucH_2.Visible = true;

                SMucLL_1.Visible = true;
                SMucL_1.Visible = true;
                SMucLL_2.Visible = false;
                SMucL_2.Visible = false;

                lbl_Muc.Text = "Quá cao";
                lbl_Muc.ForeColor = System.Drawing.Color.Red;
            }
            //Trên mức H
            else if (PLC_Command.RON92Tank1.Level >= PLC_Command.RON92Tank1.LevelHigh)
            {
                SMucHH_2.Visible = false;
                SMucH_2.Visible = true;

                SMucLL_1.Visible = true;
                SMucL_1.Visible = true;
                SMucLL_2.Visible = false;
                SMucL_2.Visible = false;

                lbl_Muc.Text = "Cao";
                lbl_Muc.ForeColor = System.Drawing.Color.Red;
            }
            //Trên mức L
            else if (PLC_Command.RON92Tank1.Level > PLC_Command.RON92Tank1.LevelLow)
            {
                SMucHH_2.Visible = false;
                SMucH_2.Visible = false;

                SMucLL_1.Visible = true;
                SMucL_1.Visible = true;
                SMucLL_2.Visible = false;
                SMucL_2.Visible = false;

                lbl_Muc.Text = "Bình thường";
                lbl_Muc.ForeColor = System.Drawing.Color.Black;

                txt_Muc.ForeColor = System.Drawing.Color.Black;
            }
            //Trên mức LL
            else if (PLC_Command.RON92Tank1.Level > PLC_Command.RON92Tank1.LevelVeryLow)
            {
                SMucHH_2.Visible = false;
                SMucH_2.Visible = false;

                SMucLL_1.Visible = true;
                SMucL_1.Visible = false;
                SMucLL_2.Visible = false;
                SMucL_2.Visible = true;

                lbl_Muc.Text = "Thấp";
                lbl_Muc.ForeColor = System.Drawing.Color.Red;
            }
            //Từ mức LL trở xuống
            else if (PLC_Command.RON92Tank1.Level <= PLC_Command.RON92Tank1.LevelVeryLow)
            {
                SMucHH_2.Visible = false;
                SMucH_2.Visible = false;

                SMucLL_1.Visible = false;
                SMucL_1.Visible = false;
                SMucLL_2.Visible = true;
                SMucL_2.Visible = false;

                lbl_Muc.Text = "Rất thấp";
                lbl_Muc.ForeColor = System.Drawing.Color.Red;
            }

            //Trạng thái cảnh báo nhiệt
            //Trên mức HH
            if (PLC_Command.RON92Tank1.Temp >= PLC_Command.RON92Tank1.TempVeryHigh)
            {
                lbl_NhietDo.Text = "Quá cao";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Red;
            }
            //Trên mức H
            else if (PLC_Command.RON92Tank1.Temp >= PLC_Command.RON92Tank1.TempHigh)
            {
                lbl_NhietDo.Text = "Cao";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Red;
            }
            //Trên mức L
            else if (PLC_Command.RON92Tank1.Temp > PLC_Command.RON92Tank1.TempLow)
            {
                lbl_NhietDo.Text = "Bình thường";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Black;
            }
            //Trên mức LL
            else if (PLC_Command.RON92Tank1.Temp > PLC_Command.RON92Tank1.TempVeryLow)
            {
                lbl_NhietDo.Text = "Thấp";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Red;
            }
            //Dưới mức LL
            else if (PLC_Command.RON92Tank1.Temp <= PLC_Command.RON92Tank1.TempVeryLow)
            {
                lbl_NhietDo.Text = "Rất thấp";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}