using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_XANGDAU.WebForms;

namespace Web_XANGDAU
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Web_XANGDAU.webforms.Login.ThongTin.LoaiTaiKhoan == null)
                Response.Redirect("DN_Login.aspx");
            else
            {
                lbl_Quyen.Text = Web_XANGDAU.webforms.Login.ThongTin.LoaiTaiKhoan;
                lbl_HoTen.Text = Web_XANGDAU.webforms.Login.ThongTin.HoTen;
            }

        }
    }
}