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
    public partial class BaoCao : System.Web.UI.Page
    {
        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            changedTime();
            GridView300.DataSource = null;
            GridView300.DataBind();
            pn_ThongBao.Visible = false;
        }

        private void changedTime()
        {
            //Xem toàn bộ thời gian
            if (ddl_ThoiGian.SelectedItem.Value == "1")
                pn_ThoiGian.Visible = false;
            //Xem theo khoảng thời gian
            if (ddl_ThoiGian.SelectedItem.Value == "2")
                pn_ThoiGian.Visible = true;
        }

        private void GetData(string sql)
        {
            if (ketnoi.State != ConnectionState.Closed)
                ketnoi.Open();

            thuchien = new SqlCommand(sql, ketnoi);
            sda = new SqlDataAdapter(thuchien);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //Thêm dữ liệu vào gridview
                GridView300.DataSource = dt;
                GridView300.DataBind();

                //Thay thế <td> bằng <th>
                GridView300.UseAccessibleHeader = true;
                //Thêm các phần tử <thead> và <tbody>
                GridView300.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else pn_ThongBao.Visible = true;

            ketnoi.Close();
        }

        protected void ddl_ThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedTime();
        }

        protected void btn_LichSuHD_Click(object sender, EventArgs e)
        {
            //Xem toàn bộ thời gian
            if(ddl_ThoiGian.SelectedItem.Value == "1")
            {
                if (ddl_LichSuHD.SelectedItem.Value == "1")
                {
                    lbl_Data.Text = "Tất cả lịch sử";
                    GetData(@"Select * From LichSuHD");
                }    
                else if (ddl_LichSuHD.SelectedItem.Value == "2")
                {
                    lbl_Data.Text = "Lịch sử đăng nhập";
                    GetData(@"Select * From LichSuHD Where (SuKien = N'Đăng nhập')");
                }    
                else if (ddl_LichSuHD.SelectedItem.Value == "3")
                {
                    lbl_Data.Text = "Lịch sử hoạt động SCADA";
                    GetData(@"Select * From LichSuHD Where (SuKien = N'SCADA')");
                }    
                else if (ddl_LichSuHD.SelectedItem.Value == "4")
                {
                    lbl_Data.Text = "Lịch sử cảnh báo";
                    GetData(@"Select * From LichSuHD Where (SuKien = N'Cảnh báo')");
                }    
            }  
            //Xem theo khoảng thời gian
            else if(ddl_ThoiGian.SelectedItem.Value == "2")
            {
                string TimeStart = DateTime.Parse(txt_TimeStart.Text).ToString("yyyy/MM/dd hh:mm:ss tt");
                string TimeEnd = DateTime.Parse(txt_TimeEnd.Text).ToString("yyyy/MM/dd hh:mm:ss tt");

                if (ddl_LichSuHD.SelectedItem.Value == "1")
                {
                    lbl_Data.Text = "Tất cả lịch sử";
                    GetData(@"Select * From LichSuHD");
                }
                else if (ddl_LichSuHD.SelectedItem.Value == "2")
                {
                    lbl_Data.Text = "Lịch sử đăng nhập";
                    GetData(@"Select * From LichSuHD Where (SuKien = N'Đăng nhập') AND (ThoiGian Between '" + TimeStart + "' And '" + TimeEnd + "')");
                }
                else if (ddl_LichSuHD.SelectedItem.Value == "3")
                {
                    lbl_Data.Text = "Lịch sử hoạt động SCADA";
                    GetData(@"Select * From LichSuHD Where (SuKien = N'SCADA') AND (ThoiGian Between '" + TimeStart + "' And '" + TimeEnd + "')");
                }
                else if (ddl_LichSuHD.SelectedItem.Value == "4")
                {
                    lbl_Data.Text = "Lịch sử cảnh báo";
                    GetData(@"Select * From LichSuHD Where (SuKien = N'Cảnh báo') AND (ThoiGian Between '" + TimeStart + "' And '" + TimeEnd + "')");
                }
            }    

            System.Threading.Thread.Sleep(1000);
        }
    }
}