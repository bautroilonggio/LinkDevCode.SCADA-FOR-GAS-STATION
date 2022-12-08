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

namespace Web_XANGDAU.WebForms
{
    public partial class Home : System.Web.UI.Page
    {
        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        protected string check;

        protected void Page_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            //Không cho sửa thông số bể nếu không phải quyền Admin
            if(Web_XANGDAU.webforms.Login.ThongTin.LoaiTaiKhoan != "Admin")
            {
                btn_ThongSoDiezel_1.Attributes["disabled"] = "disabled";
                btn_ThongSoDiezel_2.Attributes["disabled"] = "disabled";
                btn_ThongSoRON92_1.Attributes["disabled"] = "disabled";
                btn_ThongSoRON92_2.Attributes["disabled"] = "disabled";
                btn_ThongSoRON95_1.Attributes["disabled"] = "disabled";
                btn_ThongSoRON95_2.Attributes["disabled"] = "disabled";
                btn_ThongSoE100_1.Attributes["disabled"] = "disabled";
                btn_ThongSoE100_2.Attributes["disabled"] = "disabled";
            }

            //Load thông tin chung về đơn hàng theo sản phẩm
            LoadDonXuat("Diezel", lbl_DonXuat_Diezel, lbl_TienThu_Diezel);
            LoadDonXuat("RON 92", lbl_DonXuat_RON92, lbl_TienThu_RON92);
            LoadDonXuat("RON 95", lbl_DonXuat_RON95, lbl_TienThu_RON95);
            LoadDonXuat("E5", lbl_DonXuat_E5, lbl_TienThu_E5);

            //Xóa dữ liệu bảng chi tiết đơn hàng
            GridView200.DataSource = null;
            GridView200.DataBind();

            //Load Top 10 đơn hàng gần nhất
            if ((ddl_DonHang.SelectedItem.Value == "1") & (ddl_ThoiGian.SelectedItem.Value == "1"))
            {
                GetData(@"Select Top 10 * From DonHang");
                btn_Data.Visible = false;
            }
            else
                btn_Data.Visible = true;

            //Load kiểu thời gian xem đã chọn
            changedTime();

            //Ẩn thông báo không tìm thấy dữ liệu
            pn_ThongBao.Visible = false;
        }

        //Load thông số tank được chọn
        void LoadThongSoTank(string Tank)
        {
            lbl_setting_tank.Text = Tank;
            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();
            sql = @"Select *from ThongSoTank Where Tank = N'"+Tank+"' ";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if(docdulieu.Read())
            {
                txt_NhietThap.Text = docdulieu["NhietThap"].ToString();
                txt_NhietCao.Text = docdulieu["NhietCao"].ToString();
                txt_NhietQuaCao.Text = docdulieu["NhietQuaCao"].ToString();
                txt_MucCao.Text = docdulieu["MucCao"].ToString();
                txt_MucQuaCao.Text = docdulieu["MucQuaCao"].ToString();
                txt_MucThap.Text = docdulieu["MucThap"].ToString();
                txt_MucQuaThap.Text = docdulieu["MucQuaThap"].ToString();
                txt_ChieuCao.Text = docdulieu["ChieuCao"].ToString();
                txt_DienTichDay.Text = docdulieu["DienTichDay"].ToString();
            }
            ketnoi.Close();
            check = "1";
        }

        protected void btn_ThongSoDiezel_1_Click(object sender, EventArgs e)
        {
            LoadThongSoTank("Diezel Tank 1");
        }

        protected void btn_ThongSoDiezel_2_Click(object sender, EventArgs e)
        {
            LoadThongSoTank("Diezel Tank 2");
        }

        protected void btn_ThongSoRON92_1_Click(object sender, EventArgs e)
        {
            LoadThongSoTank("RON92 Tank 1");
        }

        protected void btn_ThongSoRON92_2_Click(object sender, EventArgs e)
        {
            LoadThongSoTank("RON92 Tank 2");
        }

        protected void btn_ThongSoRON95_1_Click(object sender, EventArgs e)
        {
            LoadThongSoTank("RON95 Tank 1");
        }

        protected void btn_ThongSoRON95_2_Click(object sender, EventArgs e)
        {
            LoadThongSoTank("RON95 Tank 2");
        }

        protected void btn_ThongSoE100_1_Click(object sender, EventArgs e)
        {
            LoadThongSoTank("E100 Tank 1");
        }

        protected void btn_ThongSoE100_2_Click(object sender, EventArgs e)
        {
            LoadThongSoTank("E100 Tank 2");
        }

        protected void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();
            sql = @"Update ThongSoTank set NhietCao = '"+txt_NhietCao.Text+"',NhietQuaCao = '"+txt_NhietQuaCao.Text+"'," +
                "MucCao = '"+txt_MucCao.Text+"',MucQuaCao = '"+txt_MucQuaCao.Text+"',MucThap = '"+txt_MucThap.Text+"'," +
                "MucQuaThap = '"+txt_MucQuaThap.Text+"',ChieuCao = '"+txt_ChieuCao.Text+"',DienTichDay = '"+txt_DienTichDay.Text+"'" +
                "Where Tank = '"+lbl_setting_tank.Text+"'";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            LoadThongSoTank(lbl_setting_tank.Text);
            check = "0";
        }

        protected void btn_close_setting_Click(object sender, EventArgs e)
        {
            check = "0";
        }

        protected void ddl_ThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedTime();
        }

        private void changedTime()
        {
            if (ddl_ThoiGian.SelectedItem.Value == "1"|ddl_ThoiGian.SelectedItem.Value == "2")
            {
                Panel2.Visible = false;
            }
            if (ddl_ThoiGian.SelectedItem.Value == "3")
            {
                Panel2.Visible = true;
            }
        }

        //Hàm lấy dữ liệu đơn hàng
        private void GetData(string sqlstring)
        {
            if (ketnoi.State != ConnectionState.Closed)
                ketnoi.Open();

            thuchien = new SqlCommand(sqlstring, ketnoi);
            sda = new SqlDataAdapter(thuchien);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //Thêm dữ liệu vào gridview
                GridView200.DataSource = dt;
                GridView200.DataBind();

                //Thay thế <td> bằng <th>
                GridView200.UseAccessibleHeader = true;
                //Thêm các phần tử <thead> và <tbody>
                GridView200.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            else pn_ThongBao.Visible = true; 

            ketnoi.Close();

        }

        //Load dữ liệu đơn hàng
        protected void btn_Data_Click(object sender, EventArgs e)
        {  
            //Tất cả đơn
            if (ddl_DonHang.SelectedItem.Value == "1")
            {
                if (ddl_ThoiGian.SelectedItem.Value == "1")
                    GetData(@"Select Top 10 * From DonHang");
                if (ddl_ThoiGian.SelectedItem.Value == "2")
                    GetData(@"Select * From DonHang");
                if (ddl_ThoiGian.SelectedItem.Value == "3")
                {
                    string TimeStart = DateTime.Parse(txt_TimeStart.Text).ToString("yyyy/MM/dd hh:mm:ss tt");
                    string TimeEnd = DateTime.Parse(txt_TimeEnd.Text).ToString("yyyy/MM/dd hh:mm:ss tt");

                    GetData(@"Select * From DonHang Where ThoiGian Between '" + TimeStart + "' And '" + TimeEnd + "'");
                }
            }

            //Tất cả đơn đã hoàn thành
            else if (ddl_DonHang.SelectedItem.Value == "2")
            {
                if (ddl_ThoiGian.SelectedItem.Value == "1")
                    GetData(@"Select Top 10 * From DonHang Where TrangThai = N'Đã hoàn thành'");
                if (ddl_ThoiGian.SelectedItem.Value == "2")
                    GetData(@"Select * From DonHang Where TrangThai = N'Đã hoàn thành'");
                if (ddl_ThoiGian.SelectedItem.Value == "3")
                {
                    string TimeStart = DateTime.Parse(txt_TimeStart.Text).ToString("yyyy/MM/dd hh:mm:ss tt");
                    string TimeEnd = DateTime.Parse(txt_TimeEnd.Text).ToString("yyyy/MM/dd hh:mm:ss tt");
                    GetData(@"Select * From DonHang Where (TrangThai = N'Đã hoàn thành') AND (ThoiGian Between '" + TimeStart + "' And '" + TimeEnd + "')");
                }
            }

            //Tất cả đơn chưa hoàn thành
            else if (ddl_DonHang.SelectedItem.Value == "3")
            {
                 GetData(@"Select * From DonHang Where TrangThai = N'Chưa hoàn thành'");
            }

            System.Threading.Thread.Sleep(1000);
        }

        //Load dữ liệu nhập xuất
        private void LoadDonXuat(string sanPham, Label lbl_Don, Label lbl_Tien)
        {
            if (ketnoi.State == ConnectionState.Closed)
                ketnoi.Open();
            sql = @"Select SanPham,ThanhTien From DonHang Where SanPham = N'"+sanPham+"' And TrangThai = N'Đã hoàn thành'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            int SoDon = 0;
            long Tong = 0;
            while (docdulieu.Read())
            {
                SoDon++;
                Tong = Tong + long.Parse(docdulieu["ThanhTien"].ToString());
            }
            ketnoi.Close();
            lbl_Don.Text = SoDon.ToString();
            lbl_Tien.Text = Tong.ToString();
        }
    }
}