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
    public partial class QuanLyNguoiDung : System.Web.UI.Page
    {
        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataAdapter sda;
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Web_XANGDAU.webforms.Login.ThongTin.LoaiTaiKhoan == "Admin")
            //{
            pn_ThongBao.Visible = false;
                ketnoi = new SqlConnection(chuoiketnoi);
                GetData();
            //}
            //else
            //    pn_ThongBao.Visible = true;

        }

        private void GetData()
        {
            if (ketnoi.State != ConnectionState.Closed)
                ketnoi.Open();

            sql = @"Select Id,TaiKhoan,HoTen,Email,DienThoai,LoaiTaiKhoan From Login";

            thuchien = new SqlCommand(sql, ketnoi);
            sda = new SqlDataAdapter(thuchien);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //Thêm dữ liệu vào gridview
                GridView150.DataSource = dt;
                GridView150.DataBind();

                //Thay thế <td> bằng <th>
                GridView150.UseAccessibleHeader = true;
                //Thêm các phần tử <thead> và <tbody>
                GridView150.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            ketnoi.Close();
        }

        protected void GridView150_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[1].Text;
                foreach(LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                {
                    if(button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Bạn muốn xóa tài khoản " + item + "?')){ return false; };";
                    }    
                }    
            }    
        }

        protected void GridView150_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string TaiKhoan = GridView150.Rows[e.RowIndex].Cells[1].Text;
            ketnoi.Open();
            sql = @"Delete From Login Where TaiKhoan = '" + TaiKhoan + "'";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            GridView150.DataSource = null;
            GridView150.DataBind();
            ketnoi.Close();

            //Reload trang
            Response.Redirect("GD_QuanLyNguoiDung.aspx");
        }
    }
}