using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;


namespace Web_XANGDAU.webforms
{
    public partial class Format_Pass : System.Web.UI.Page
    {
        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;

        protected void Page_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
        }

        protected void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (txt_ConPass.Text != txt_NewPass.Text)
            {
                Response.Write("<script>alert('Mật khẩu xác nhận không trùng khớp')</script>");
                txt_ConPass.Focus();
                return;
            }

            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();
            sql = @"Update Login set MatKhau = '"+txt_NewPass.Text+"' " +
                "Where (TaiKhoan='"+txt_TaiKhoan.Text+"'and HoTen='"+txt_HoTen.Text+"'and Email='"+txt_Email.Text+"'and DienThoai='"+txt_Phone.Text+"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            Response.Write("<script>alert('Đã thay đổi mật khẩu')</script>");
            Response.Redirect("DN_Login.aspx");
        }
    }
}