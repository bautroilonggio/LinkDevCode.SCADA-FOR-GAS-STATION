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
    public partial class Login : System.Web.UI.Page
    {

        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString ;
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        public class ThongTin
        {
            static public string LoaiTaiKhoan;
            static public string HoTen;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
        }

        private void ThemDuLieuDangNhap(string LoaiTaiKhoan)
        {
            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();

            string ChiTiet = ""+txt_TaiKhoan.Text+" đã đăng nhập với quyền "+LoaiTaiKhoan+"";
            string ThoiGian = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");

            sql = @"Insert into LichSuHD (SuKien,ChiTiet,ThoiGian) Values (N'Đăng nhập',N'"+ChiTiet+"',N'"+ThoiGian+"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();
        }

        protected void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();
            sql = @"Select *from Login Where TaiKhoan='" + txt_TaiKhoan.Text + "'and MatKhau=N'" + txt_MatKhau.Text + "'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if(docdulieu.Read() ==  false)
            {
                Response.Write("<script>alert('Tài khoản hoặc mật khẩu chưa chính xác')</script>");
                txt_TaiKhoan.Text = "";
                txt_MatKhau.Text = "";
                txt_TaiKhoan.Focus();
            }    
            else
            {
                ThongTin.LoaiTaiKhoan = docdulieu["LoaiTaiKhoan"].ToString();
                ThongTin.HoTen = docdulieu["HoTen"].ToString();
                ketnoi.Close();
                ThemDuLieuDangNhap(ThongTin.LoaiTaiKhoan);
                Response.Redirect("GD_Home.aspx");
            }    
        }
    }
}