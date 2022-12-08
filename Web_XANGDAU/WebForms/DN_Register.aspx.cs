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
    public partial class Register : System.Web.UI.Page
    {
        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string LoaiTaiKhoan = "Operater";

        protected void Page_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
        }

        protected void KiemTra(string ThongTin1,string ThongTin2,string ThongTin3)
        {
            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();
            string con = @"Select *from Login Where "+ThongTin2+"="+ThongTin3+"";
            SqlCommand com = new SqlCommand(con, ketnoi);
            docdulieu = com.ExecuteReader();
            if(docdulieu.Read())
            {
                Response.Write("<script>alert('"+ThongTin1+" đã được sử dụng')</script>");
                ThongTin3 = "";
                return;
            }
            ketnoi.Close();
        }

        protected void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (txt_ConPass.Text != txt_NewPass.Text)
            {
                Response.Write("<script>alert('Mật khẩu xác nhận không trùng khớp')</script>");
                txt_ConPass.Focus();
                return;
            }

            KiemTra("Tài khoản","TaiKhoan",txt_TaiKhoan.Text);
            KiemTra("Họ Tên","HoTen",txt_HoTen.Text);
            KiemTra("Email","Email",txt_Email.Text);
            KiemTra("Số điện thoại","DienThoai",txt_Phone.Text);

            if (ketnoi.State != ConnectionState.Open) 
                ketnoi.Open();
            sql = @"Insert Into Login(TaiKhoan, HoTen, Email, DienThoai, MatKhau, LoaiTaiKhoan) 
                    values ('"+txt_TaiKhoan.Text+"','"+txt_HoTen.Text+"','"+txt_Email.Text+ "','" + txt_Phone.Text + "','" + txt_NewPass.Text + "','" + LoaiTaiKhoan + "')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            Response.Redirect("DN_Login.aspx");
        }
    }
}