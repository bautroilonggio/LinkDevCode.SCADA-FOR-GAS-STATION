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
    public partial class GD_DataTram : System.Web.UI.Page
    {
        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            changedKieuXem();
            changedTime();
            GridView100.DataSource = null;
            GridView100.DataBind();
            pn_ThongBao.Visible = false;
        }

        private void changedKieuXem()
        {
            //Xem tất cả dữ liệu
            if (ddl_KieuXem.SelectedItem.Value == "1")
            {
                pn_TheoTank.Visible = false;
                pn_TheoHangMuc.Visible = false;
            }

            //Xem theo tank
            if (ddl_KieuXem.SelectedItem.Value == "2")
            {
                pn_TheoTank.Visible = true;
                pn_TheoHangMuc.Visible = false;
            }

            //Xem theo hạng mục
            if (ddl_KieuXem.SelectedItem.Value == "3")
            {
                pn_TheoTank.Visible = false;
                pn_TheoHangMuc.Visible = true;
            }
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

        protected void ddl_KieuXem_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedKieuXem();
            
        }

        protected void ddl_ThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedTime();
        }

        private void GetDataAll()
        {
            lbl_Data.Text = "Tất cả dữ liệu";

            if (ketnoi.State != ConnectionState.Closed) 
                ketnoi.Open();

            //Xem toàn bộ thời gian
            if (ddl_ThoiGian.SelectedItem.Value == "1")
                sql = @"Select * From DuLieuTram";
            //Xem theo khoảng thời gian
            else
                sql = @"Select * From DuLieuTram Where ThoiGian Between '" + DateTime.Parse(txt_TimeStart.Text).ToString("yyyy/MM/dd hh:mm:ss tt") + "' And '" + DateTime.Parse(txt_TimeEnd.Text).ToString("yyyy/MM/dd hh:mm:ss tt") + "'";
            
            thuchien = new SqlCommand(sql, ketnoi);
            sda = new SqlDataAdapter(thuchien);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                #region ThemCot
                BoundField Tank = new BoundField();
                Tank.DataField = "HongXuat"; Tank.HeaderText = "Họng Xuất";
                GridView100.Columns.Add(Tank);

                BoundField VanXuat = new BoundField();
                VanXuat.DataField = "VanXuat"; VanXuat.HeaderText = "Độ mở van xuất (%)";
                GridView100.Columns.Add(VanXuat);

                BoundField LuuLuongXuat = new BoundField();
                LuuLuongXuat.DataField = "LuuLuongXuat"; LuuLuongXuat.HeaderText = "Lưu lượng xuất (m3/h)";
                GridView100.Columns.Add(LuuLuongXuat);

                BoundField Muc = new BoundField();
                Muc.DataField = "Muc"; Muc.HeaderText = "Mức chất lỏng (%)";
                GridView100.Columns.Add(Muc);

                BoundField NhietDo = new BoundField();
                NhietDo.DataField = "NhietDo"; NhietDo.HeaderText = "Nhiệt độ (độ C)";
                GridView100.Columns.Add(NhietDo);

                BoundField BomXuat = new BoundField();
                BomXuat.DataField = "BomXuat"; BomXuat.HeaderText = "Trạng thái bơm xuất";
                GridView100.Columns.Add(BomXuat);

                BoundField ThoiGian = new BoundField();
                ThoiGian.DataField = "ThoiGian"; ThoiGian.HeaderText = "Thời gian";
                GridView100.Columns.Add(ThoiGian);
                #endregion

                //Thêm dữ liệu vào gridview
                GridView100.DataSource = dt;
                GridView100.DataBind();

                ////Thay thế <td> bằng <th>
                GridView100.UseAccessibleHeader = true;
                //Thêm các phần tử <thead> và <tbody>
                GridView100.HeaderRow.TableSection = TableRowSection.TableHeader;

                #region XoaCot
                GridView100.Columns.Remove(Tank);
                GridView100.Columns.Remove(VanXuat);
                GridView100.Columns.Remove(LuuLuongXuat);
                GridView100.Columns.Remove(Muc);
                GridView100.Columns.Remove(NhietDo);
                GridView100.Columns.Remove(BomXuat);
                GridView100.Columns.Remove(ThoiGian);
                #endregion
            }
            else pn_ThongBao.Visible = true;

            ketnoi.Close();
        }

        private void GetDataTank(string tank)
        {
            lbl_Data.Text = "Dữ liệu " + tank + "";

            if (ketnoi.State != ConnectionState.Closed)
                ketnoi.Open();

            //Xem toàn bộ thời gian
            if(ddl_ThoiGian.SelectedItem.Value == "1")
                sql = @"Select VanXuat,LuuLuongXuat,Muc,NhietDo,BomXuat,ThoiGian From DuLieuTram Where Tank='"+tank+"'";
            //Xem theo khoảng thời gian
            else
                sql = @"Select VanXuat,LuuLuongXuat,Muc,NhietDo,BomXuat,ThoiGian From DuLieuTram Where (Tank='"+tank+"') AND (ThoiGian BETWEEN '"+DateTime.Parse(txt_TimeStart.Text).ToString("yyyy/MM/dd hh:mm:ss tt")+ "' AND '" + DateTime.Parse(txt_TimeStart.Text).ToString("yyyy/MM/dd hh:mm:ss tt") + "')";

            thuchien = new SqlCommand(sql, ketnoi);
            sda = new SqlDataAdapter(thuchien);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                #region ThemCot

                BoundField VanXuat = new BoundField();
                VanXuat.DataField = "VanXuat"; VanXuat.HeaderText = "Độ mở van xuất (%)";
                GridView100.Columns.Add(VanXuat);

                BoundField LuuLuongXuat = new BoundField();
                LuuLuongXuat.DataField = "LuuLuongXuat"; LuuLuongXuat.HeaderText = "Lưu lượng xuất (m3/h)";
                GridView100.Columns.Add(LuuLuongXuat);

                BoundField Muc = new BoundField();
                Muc.DataField = "Muc"; Muc.HeaderText = "Mức chất lỏng (%)";
                GridView100.Columns.Add(Muc);

                BoundField NhietDo = new BoundField();
                NhietDo.DataField = "NhietDo"; NhietDo.HeaderText = "Nhiệt độ (độ C)";
                GridView100.Columns.Add(NhietDo);

                BoundField BomXuat = new BoundField();
                BomXuat.DataField = "BomXuat"; BomXuat.HeaderText = "Trạng thái bơm xuất";
                GridView100.Columns.Add(BomXuat);

                BoundField ThoiGian = new BoundField();
                ThoiGian.DataField = "ThoiGian"; ThoiGian.HeaderText = "Thời gian";
                GridView100.Columns.Add(ThoiGian);
                #endregion

                //Thêm dữ liệu vào gridview
                GridView100.DataSource = dt;
                GridView100.DataBind();

                ////Thay thế <td> bằng <th>
                GridView100.UseAccessibleHeader = true;
                //Thêm các phần tử <thead> và <tbody>
                GridView100.HeaderRow.TableSection = TableRowSection.TableHeader;

                #region XoaCot
                GridView100.Columns.Remove(VanXuat);
                GridView100.Columns.Remove(LuuLuongXuat);
                GridView100.Columns.Remove(Muc);
                GridView100.Columns.Remove(NhietDo);
                GridView100.Columns.Remove(BomXuat);
                GridView100.Columns.Remove(ThoiGian);
                #endregion
            }
            else pn_ThongBao.Visible = true;

            ketnoi.Close();
        }

        private void GetDataPart(string DataText, string part, string headertext)
        {
            lbl_Data.Text = "Dữ liệu "+DataText+"";

            if (ketnoi.State != ConnectionState.Closed)
                ketnoi.Open();

            //Xem toàn bộ thời gian
            if(ddl_ThoiGian.SelectedItem.Value == "1")
                sql = @"Select Tank,"+part+",ThoiGian From DuLieuTram";
            //Xem theo khoảng thời gian
            else
                sql = @"Select Tank," + part + ",ThoiGian From DuLieuTram Where ThoiGian Between '" + DateTime.Parse(txt_TimeStart.Text).ToString("yyyy/MM/dd hh:mm:ss tt") + "' And '" + DateTime.Parse(txt_TimeEnd.Text).ToString("yyyy/MM/dd hh:mm:ss tt") + "'";
            
            thuchien = new SqlCommand(sql, ketnoi);
            sda = new SqlDataAdapter(thuchien);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                #region ThemCot
                BoundField Tank = new BoundField();
                Tank.DataField = "Tank"; Tank.HeaderText = "Tank";
                GridView100.Columns.Add(Tank);

                BoundField Part = new BoundField();
                Part.DataField = part; Part.HeaderText = headertext;
                GridView100.Columns.Add(Part);

                BoundField ThoiGian = new BoundField();
                ThoiGian.DataField = "ThoiGian"; ThoiGian.HeaderText = "Thời gian";
                GridView100.Columns.Add(ThoiGian);
                #endregion

                //Thêm dữ liệu vào gridview
                GridView100.DataSource = dt;
                GridView100.DataBind();

                ////Thay thế <td> bằng <th>
                GridView100.UseAccessibleHeader = true;
                //Thêm các phần tử <thead> và <tbody>
                GridView100.HeaderRow.TableSection = TableRowSection.TableHeader;

                #region XoaCot
                GridView100.Columns.Remove(Tank);
                GridView100.Columns.Remove(Part);
                GridView100.Columns.Remove(ThoiGian);
                #endregion
            }
            else pn_ThongBao.Visible = true;

            ketnoi.Close();
        }

        protected void btn_Data_Click(object sender, EventArgs e)
        {
            //Xem tất cả dữ liệu
            if (ddl_KieuXem.SelectedItem.Value == "1")
                GetDataAll();

            //Xem theo tank
            if (ddl_KieuXem.SelectedItem.Value == "2")
            {
                //Tank Diezel
                if (ddl_TheoTank.SelectedItem.Value == "1")
                    GetDataTank("Diezel");
                //Tank RON 92
                if (ddl_TheoTank.SelectedItem.Value == "2")
                    GetDataTank("RON 92");
                //Tank RON 95
                if (ddl_TheoTank.SelectedItem.Value == "3")
                    GetDataTank("RON 95");
                //Tank E100
                if (ddl_TheoTank.SelectedItem.Value == "4")
                    GetDataTank("E100");
            }

            //Xem theo hạng mục
            if (ddl_KieuXem.SelectedItem.Value == "3")
            {
                //Van xuất
                if (ddl_TheoHangMuc.SelectedItem.Value == "1")
                    GetDataPart("van xuất","VanXuat","Độ mở van xuất (%)");
                //Lưu lượng xuất
                if (ddl_TheoHangMuc.SelectedItem.Value == "2")
                    GetDataPart("lưu lượng xuất","LuuLuongXuat", "Lưu lượng xuất (m3/h)");
                //Mức chất lỏng
                if (ddl_TheoHangMuc.SelectedItem.Value == "3")
                    GetDataPart("mức chất lỏng","Muc", "Mức chất lỏng (%)");
                //Nhiệt độ
                if (ddl_TheoHangMuc.SelectedItem.Value == "4")
                    GetDataPart("nhiệt độ","NhietDo", "Nhiệt độ (độ C)");
                //Bơm xuất
                if (ddl_TheoHangMuc.SelectedItem.Value == "5")
                    GetDataPart("bơm xuất","BomXuat", "Trạng thái bơm xuất");
            }

            System.Threading.Thread.Sleep(1000);
        }

        
    }
}