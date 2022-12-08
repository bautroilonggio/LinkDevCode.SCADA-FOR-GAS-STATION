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
    public partial class HongXuat7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fake();
        }

        protected void Timer_Hong7_Tick(object sender, EventArgs e)
        {
            
        }

        private void fake()
        {
            txt_SanPham.Text = "E5";
            txt_DonGia.Text = "25.070";
            txt_ThanhTien.Text = "250.7";
            txt_TrangThai.Text = "Đang thực hiện";
            txt_MaDonXuat.Text = "XH1010";
            txt_TheTichCanXuat.Text = "10";
            txt_TheTichDaXuat.Text = "0";

            lbl_KetNoi.Text = "Đã kết nối";
            lbl_KetNoi.ForeColor = System.Drawing.Color.Black;

            lbl_TiepDia.Text = "Chưa đảm bảo";
            lbl_TiepDia.ForeColor = System.Drawing.Color.Red;

            lbl_NhietDo.Text = "Bình thường";
            lbl_NhietDo.ForeColor = System.Drawing.Color.Black;

            lbl_Muc.Text = "Bình thường";
            lbl_Muc.ForeColor = System.Drawing.Color.Black;

            lbl_DauXuat.Text = "Chưa gắn chặt";
            lbl_DauXuat.ForeColor = System.Drawing.Color.Red;

            txt_MucE100.Text = "10 (m)";
            txt_MucE100.ForeColor = System.Drawing.Color.Black;
            txt_MucRON92.Text = "12 (m)";
            txt_MucRON92.ForeColor = System.Drawing.Color.Black;

            txt_NhietDoE100.Text = "25 (°C)";
            txt_NhietDoE100.ForeColor = System.Drawing.Color.Black;
            txt_NhietDoRON92.Text = "26 (°C)";
            txt_NhietDoRON92.ForeColor = System.Drawing.Color.Black;

            txt_VanXuatE100.Text = "0 (%)";
            txt_VanXuatE100.ForeColor = System.Drawing.Color.Black;
            txt_VanXuatRON92.Text = "0 (%)";
            txt_VanXuatRON92.ForeColor = System.Drawing.Color.Black;
            txt_VanXuatE5.Text = "0 (%)";
            txt_VanXuatE5.ForeColor = System.Drawing.Color.Black;

            txt_LuuLuongXuatE100.Text = "0(m3/h)";
            txt_LuuLuongXuatE100.ForeColor = System.Drawing.Color.Black;
            txt_LuuLuongXuatRON92.Text = "0(m3/h)";
            txt_LuuLuongXuatRON92.ForeColor = System.Drawing.Color.Black;

            SVanXuat_E100_1.Visible = false;
            SVanXuat_E100_2.Visible = false;
            SBomXuat_E100_1.Visible = false;
            SBomXuat_E100_2.Visible = false;
            SMucHH_E100_2.Visible = false;
            SMucH_E100_2.Visible = false;
            SMucLL_E100_1.Visible = true;
            SMucLL_E100_2.Visible = false;
            SMucL_E100_1.Visible = true;
            SMucL_E100_2.Visible = false;
            pn_MucPerE100.Attributes["style"] = "width: 50%";
            lbl_MucPerE100.Text = "50%";

            SVanXuat_RON92_1.Visible = false;
            SVanXuat_RON92_2.Visible = false;
            SBomXuat_RON92_1.Visible = false;
            SBomXuat_RON92_2.Visible = false;
            SMucHH_RON92_2.Visible = false;
            SMucH_RON92_2.Visible = false;
            SMucLL_RON92_1.Visible = true;
            SMucLL_RON92_2.Visible = false;
            SMucL_RON92_1.Visible = true;
            SMucL_RON92_2.Visible = false;
            pn_MucPerRON92.Attributes["style"] = "width: 60%";
            lbl_MucPerRON92.Text = "60%";

            SVanXuat_E5_1.Visible = false;
            SVanXuat_E5_2.Visible = false;
            SXe_E5.Visible = true;
        }

    }
}