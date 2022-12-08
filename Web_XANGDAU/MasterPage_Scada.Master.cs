using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Configuration;
using S7.Net;
using S7.Net.Types;

namespace Web_XANGDAU
{
    public partial class MasterPage_Scada : System.Web.UI.MasterPage
    {
        GlobalFunction globalFunction = new GlobalFunction();

        protected void Page_Load(object sender, EventArgs e)
        {
            //lbl_Quyen.Text = Web_XANGDAU.webforms.Login.ThongTin.LoaiTaiKhoan;
            //lbl_HoTen.Text = Web_XANGDAU.webforms.Login.ThongTin.HoTen;

            lbl_Quyen.Text = "Admin";
            lbl_HoTen.Text = "Nguyễn Khắc Linh";
        }

        public class ThongTin
        {
            static public string MaDon_Hong1;
            static public string MaDon_Hong2;
            static public string MaDon_Hong3;
            static public string MaDon_Hong4;
            static public string MaDon_Hong5;
            static public string MaDon_Hong6;
            static public string MaDon_Hong7;
            static public string MaDon_Hong8;
        }

        protected void btn_Enter_MaDon_Click(object sender, EventArgs e)
        {
            string MaDon = txt_MaDon.Text;

            globalFunction.LoadThongTinDon(MaDon);

            if (globalFunction.checkDonHang == false)
            {
                Response.Write("<script>alert('Mã đơn hàng không hợp lệ')</script>");
                txt_MaDon.Text = "";
                txt_MaDon.Focus();
            }
            else
            {
                globalFunction.KiemTraHongXuat(globalFunction.HongXuat);

                if (globalFunction.checkHongXuat == true)
                {
                    Response.Write("<script>alert('Họng xuất bạn yêu cầu đang bận. Vui lòng chờ trong giây lát!')</script>");
                }
                else
                {
                    if (globalFunction.TrangThaiDon == "Đã hoàn thành")
                    {
                        Response.Write("<script>alert('Đơn hàng đã được hoàn thành')</script>");
                    }
                    else if (globalFunction.TrangThaiDon == "Đang thực hiện")
                    {
                        Response.Write("<script>alert('Đơn hàng đang được thực hiện ở " + globalFunction.HongXuat + "')</script>");
                    }
                    else if (globalFunction.TrangThaiDon == "Chưa hoàn thành")
                    {
                        if (globalFunction.HongXuat == "Họng 1")
                        {
                            //Cập nhật trạng thái đơn
                            globalFunction.UpdateTrangThaiDon("Đang thực hiện", MaDon);

                            ThongTin.MaDon_Hong1 = MaDon;
                            Response.Redirect("HongXuat1.aspx");
                        }
                        else if (globalFunction.HongXuat == "Họng 2")
                        {
                            //Cập nhật trạng thái đơn
                            globalFunction.UpdateTrangThaiDon("Đang thực hiện", MaDon);

                            ThongTin.MaDon_Hong2 = MaDon;
                            Response.Redirect("HongXuat2.aspx");
                        }
                        else if (globalFunction.HongXuat == "Họng 3")
                        {
                            //Cập nhật trạng thái đơn
                            globalFunction.UpdateTrangThaiDon("Đang thực hiện", MaDon);

                            ThongTin.MaDon_Hong3 = MaDon;
                            Response.Redirect("HongXuat3.aspx");
                        }
                        else if (globalFunction.HongXuat == "Họng 4")
                        {
                            //Cập nhật trạng thái đơn
                            globalFunction.UpdateTrangThaiDon("Đang thực hiện", MaDon);

                            ThongTin.MaDon_Hong4 = MaDon;
                            Response.Redirect("HongXuat4.aspx");
                        }
                        else if (globalFunction.HongXuat == "Họng 5")
                        {
                            //Cập nhật trạng thái đơn
                            globalFunction.UpdateTrangThaiDon("Đang thực hiện", MaDon);

                            ThongTin.MaDon_Hong5 = MaDon;
                            Response.Redirect("HongXuat5.aspx");
                        }
                        else if (globalFunction.HongXuat == "Họng 6")
                        {
                            //Cập nhật trạng thái đơn
                            globalFunction.UpdateTrangThaiDon("Đang thực hiện", MaDon);

                            ThongTin.MaDon_Hong6 = MaDon;
                            Response.Redirect("HongXuat6.aspx");
                        }
                        else if (globalFunction.HongXuat == "Họng 7")
                        {
                            //Cập nhật trạng thái đơn
                            globalFunction.UpdateTrangThaiDon("Đang thực hiện", MaDon);

                            ThongTin.MaDon_Hong7 = MaDon;
                            Response.Redirect("HongXuat7.aspx");
                        }
                        else if (globalFunction.HongXuat == "Họng 8")
                        {
                            //Cập nhật trạng thái đơn
                            globalFunction.UpdateTrangThaiDon("Đang thực hiện", MaDon);

                            ThongTin.MaDon_Hong8 = MaDon;
                            Response.Redirect("HongXuat8.aspx");
                        }
                    }
                }
            }
        }
    }
}