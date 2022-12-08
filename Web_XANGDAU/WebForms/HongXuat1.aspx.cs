using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S7.Net;   //Thư viện kết nối với PLC
using S7.Net.Types;
using Web_XANGDAU;  //Thư mục chứa PLC_Command
using System.Data;
using System.Data.SqlClient;

namespace Web_XANGDAU.WebForms
{
    public partial class HongXuat1 : System.Web.UI.Page
    {
        GlobalFunction globalFunction = new GlobalFunction();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Load thông tin mã đơn cần thực hiện
            //txt_MaDonXuat.Text = Web_XANGDAU.MasterPage_Scada.ThongTin.MaDon_Hong1;
            //globalFunction.LoadThongTinDon(txt_MaDonXuat.Text);
            //txt_TheTichCanXuat.Text = globalFunction.TheTichYeuCau;
            //txt_SanPham.Text = globalFunction.SanPham;
            //txt_DonGia.Text = globalFunction.DonGia;
            //txt_ThanhTien.Text = globalFunction.ThanhTien;
            //txt_TrangThai.Text = globalFunction.TrangThaiDon;

            //PLC_Command.DiezelTank1.LoadTank();

            ////Mở kết nối với PLC
            //if (PLC_Command.plc.Open() == ErrorCode.NoError)
            //{
            //    lbl_KetNoi.Text = "Đã kết nối";
            //    lbl_KetNoi.ForeColor = System.Drawing.Color.Black;

            //    PLC_Command.DiezelTank1.ReadData();
            //}

            Timer_Hong1.Enabled = false;
            fake();
        }

        private void StatusSymbol()
        {
            //Trạng thái van xuất
            //Khi van đóng
            if (PLC_Command.DiezelTank1.throat1.Ctrlvalue == 0)
            {
                SVanXuat_1.Visible = false;
                SVanXuat_2.Visible = false;
            }
            //Khi van mở
            else if (PLC_Command.DiezelTank1.throat1.Ctrlvalue > 0 && PLC_Command.DiezelTank1.throat1.Ctrlvalue <= 100)
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
            if (PLC_Command.DiezelTank1.throat1.Running == 1)
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
            if(PLC_Command.DiezelTank1.Level >= PLC_Command.DiezelTank1.LevelVeryHigh)
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
            else if(PLC_Command.DiezelTank1.Level >= PLC_Command.DiezelTank1.LevelHigh)
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
            else if (PLC_Command.DiezelTank1.Level > PLC_Command.DiezelTank1.LevelLow)
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
            else if (PLC_Command.DiezelTank1.Level > PLC_Command.DiezelTank1.LevelVeryLow)
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
            else if (PLC_Command.DiezelTank1.Level <= PLC_Command.DiezelTank1.LevelVeryLow)
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
            if(PLC_Command.DiezelTank1.Temp >= PLC_Command.DiezelTank1.TempVeryHigh)
            {
                lbl_NhietDo.Text = "Quá cao";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Red;
                txt_NhietDo.ForeColor = System.Drawing.Color.Red;
            }
            //Trên mức H
            else if (PLC_Command.DiezelTank1.Temp >= PLC_Command.DiezelTank1.TempHigh)
            {
                lbl_NhietDo.Text = "Cao";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Red;
                txt_NhietDo.ForeColor = System.Drawing.Color.Red;
            }
            //Trên mức L
            else if (PLC_Command.DiezelTank1.Temp > PLC_Command.DiezelTank1.TempLow)
            {
                lbl_NhietDo.Text = "Bình thường";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Black;
                txt_NhietDo.ForeColor = System.Drawing.Color.Black;
            }
            //Trên mức LL
            else if (PLC_Command.DiezelTank1.Temp > PLC_Command.DiezelTank1.TempVeryLow)
            {
                lbl_NhietDo.Text = "Thấp";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Red;
                txt_NhietDo.ForeColor = System.Drawing.Color.Red;
            }
            //Dưới mức LL
            else if (PLC_Command.DiezelTank1.Temp <= PLC_Command.DiezelTank1.TempVeryLow)
            {
                lbl_NhietDo.Text = "Rất thấp";
                lbl_NhietDo.ForeColor = System.Drawing.Color.Red;
                txt_NhietDo.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Timer_Hong1_Tick(object sender, EventArgs e)
        {
            txt_Muc.Text = PLC_Command.DiezelTank1.Level + PLC_Command.DiezelTank1.unitLevel;
            txt_NhietDo.Text = PLC_Command.DiezelTank1.Temp + PLC_Command.DiezelTank1.unitTemp;
            txt_VanXuat.Text = PLC_Command.DiezelTank1.throat1.Ctrlvalue.ToString() + PLC_Command.DiezelTank1.unitOpenValve;
            txt_LuuLuongXuat.Text = PLC_Command.DiezelTank1.throat1.Flow.ToString() + PLC_Command.DiezelTank1.unitFlow;
            txt_TheTichDaXuat.Text = PLC_Command.DiezelTank1.throat1.Vout.ToString();

            pn_MucPer.Attributes["style"] = "width:" + PLC_Command.DiezelTank1.LevelPer + "%";
            lbl_MucPer.Text = PLC_Command.DiezelTank1.LevelPer.ToString() + "%";

            StatusSymbol();

            
        }

        private void fake()
        {
            txt_SanPham.Text = "Diezel";
            txt_DonGia.Text = "15210";
            txt_ThanhTien.Text = "152.1";
            txt_TrangThai.Text = "Đang thực hiện";
            txt_MaDonXuat.Text = "XH1000";
            txt_TheTichCanXuat.Text = "10";
            txt_TheTichDaXuat.Text = "3.8";

            lbl_KetNoi.Text = "Đã kết nối";
            lbl_KetNoi.ForeColor = System.Drawing.Color.Black;

            lbl_TiepDia.Text = "Đã đảm bảo";
            lbl_TiepDia.ForeColor = System.Drawing.Color.Black;

            lbl_NhietDo.Text = "Bình thường";
            lbl_NhietDo.ForeColor = System.Drawing.Color.Black;

            lbl_Muc.Text = "Bình thường";
            lbl_Muc.ForeColor = System.Drawing.Color.Black;

            lbl_DauXuat.Text = "Đã gắn chặt";
            lbl_DauXuat.ForeColor = System.Drawing.Color.Black;

            txt_Muc.Text = "10 (m)";
            txt_Muc.ForeColor = System.Drawing.Color.Black;

            txt_NhietDo.Text = "25 (°C)";
            txt_NhietDo.ForeColor = System.Drawing.Color.Black;

            txt_VanXuat.Text = "100 (%)";
            txt_VanXuat.ForeColor = System.Drawing.Color.Black;

            txt_LuuLuongXuat.Text = "3 (m3/h)";
            txt_LuuLuongXuat.ForeColor = System.Drawing.Color.Black;

            SVanXuat_1.Visible = true;
            SVanXuat_2.Visible = false;
            SBomXuat_1.Visible = true;
            SBomXuat_2.Visible = false;
            SXe.Visible = true;
            SMucHH_2.Visible = false;
            SMucH_2.Visible = false;
            SMucLL_1.Visible = true;
            SMucLL_2.Visible = false;
            SMucL_1.Visible = true;
            SMucL_2.Visible = false;
            pn_MucPer.Attributes["style"] = "width: 50%";
            lbl_MucPer.Text = "50%";
        }
    }
}