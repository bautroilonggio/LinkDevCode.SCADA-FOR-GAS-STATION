<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GD_Home.aspx.cs" Inherits="Web_XANGDAU.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<%--
    Author: Nguyen Khac Linh
    Anthor URL: https://www.facebook.com/link.hust
--%>

    <link href="../css/Home.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!------------------------ MAIN --------------------------->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <main> 
        <div class="background_setting hide_setting"></div>
        <div class="tank_setting">
            <div class="tank_setting_title">
                <span>
                    Cài đặt tank <asp:Label ID="lbl_setting_tank" runat="server" Text=""></asp:Label>
                </span>
                <asp:Button ID="btn_close_setting" class="btn btn-primary hide_setting" runat="server" Text="X" OnClick="btn_close_setting_Click" />    
            </div>
            <div class="tank_setting_info">
                <div class="tank_safety">
                    <lable style="font-size: 1.1rem; font-weight: bold;">Thông số an toàn</lable>
                    <table class="table-sm">
                        <tbody>
                          <tr>
                            <td>Nhiệt thấp:</td>
                            <td><asp:TextBox ID="txt_NhietThap" runat="server" type="number" min="0" max="100" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(độ C)</td>
                          </tr>
                          <tr>
                            <td>Nhiệt cao:</td>
                            <td><asp:TextBox ID="txt_NhietCao" runat="server" type="number" min="0" max="100" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(độ C)</td>
                          </tr>
                          <tr>
                            <td>Nhiệt quá cao:</td>
                            <td><asp:TextBox ID="txt_NhietQuaCao" runat="server" type="number" min="0" max="100" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(độ C)</td>
                          </tr>
                          <tr>
                            <td>Mức cao:</td>
                            <td><asp:TextBox ID="txt_MucCao" runat="server" type="number" min="0" max="100" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(m)</td>
                           </tr>
                          <tr>
                            <td>Mức quá cao:</td>
                            <td><asp:TextBox ID="txt_MucQuaCao" runat="server" type="number" min="0" max="100" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(m)</td>
                          </tr>
                          <tr>
                            <td>Mức thấp:</td>
                            <td><asp:TextBox ID="txt_MucThap" runat="server" type="number" min="0" max="100" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(m)</td>
                          </tr>
                          <tr>
                            <td>Mức quá thấp:</td>
                            <td><asp:TextBox ID="txt_MucQuaThap" runat="server" type="number" min="0" max="100" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(m)</td>
                          </tr>
                        </tbody>
                      </table>
                </div>
                <div class="prevent"></div>
                <div class="tank_size">
                    <lable style="font-size: 1.1rem; font-weight: bold;">Thông số tank</lable>
                    <table class="table-sm">
                        <tbody>
                          <tr>
                            <td>Chiều cao:</td>
                            <td><asp:TextBox ID="txt_ChieuCao" runat="server" type="number" min="0" max="100" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(m)</td>
                          </tr>
                          <tr>
                            <td>Diện tích đáy:</td>
                            <td><asp:TextBox ID="txt_DienTichDay" runat="server" type="number" min="0" max="900" class="form-control form-control-sm"></asp:TextBox></td>
                            <td>(m2)</td>
                          </tr>
                        </tbody>
                      </table>
                </div>
            </div>
            <div class="tank_setting_OK">
                <asp:Button ID="btn_XacNhan" runat="server" Text="Xác nhận" class="btn btn-primary" OnClick="btn_XacNhan_Click" />
            </div>
        </div>
        <h3 class="title_page">Trang chủ</h3>
        <ul class="tank_list">
                <li>
                    <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background: #7380ec;"></i>
                        <span class="title_Tank">Diezel Tank 1</span>
                    </div>
                    <div class="tank" id="">
                        <div class="tank_img">
                            <img src="../Images/Tank_TrangChu.png" />
                            <div class="progress" style="height: 26px;background: #11101d;">
                                <div class="progress-bar" style="width:50%;">50%</div>
                            </div>
                        </div>
                        <div class="tank_info">
                            <div class="tank_water">
                                <table>  
                                    <tr>
                                        <td><label>Mức dầu:</label></td>
                                        <td><asp:Label ID="lbl_MucDiezel_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-7px);"><label>(m)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Thể tích:</label></td>
                                        <td><asp:Label ID="lbl_TheTichDiezel_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-4px);"><label>(m3)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Nhiệt độ:</label></td>
                                        <td><asp:Label ID="lbl_NhietDoDiezel_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;"><label>(độ C)</label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="btn_setting">
                                <asp:Button ID="btn_ThongSoDiezel_1" class="btn_ThongSo" runat="server" Text="Cài đặt thông số bể" OnClick="btn_ThongSoDiezel_1_Click" data-toggle="tooltip" data-placement="right" title="Quyền Admin" />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background: #7380ec;"></i>
                        <span class="title_Tank">Diezel Tank 2</span>
                    </div>
                    <div class="tank" id="">
                        <div class="tank_img">
                            <img src="../Images/Tank_TrangChu.png" />
                            <div class="progress" style="height: 26px;background: #11101d;">
                                <div class="progress-bar" style="width:50%;">50%</div>
                            </div>
                        </div>
                        <div class="tank_info">
                            <div class="tank_water">
                                <table>  
                                    <tr>
                                        <td><label>Mức dầu:</label></td>
                                        <td><asp:Label ID="lbl_MucDiezel_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-7px);"><label>(m)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Thể tích:</label></td>
                                        <td><asp:Label ID="lbl_TheTichDiezel_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-4px);"><label>(m3)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Nhiệt độ:</label></td>
                                        <td><asp:Label ID="lbl_NhietDoDiezel_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;"><label>(độ C)</label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="btn_setting">
                                <asp:Button ID="btn_ThongSoDiezel_2" class="btn_ThongSo" runat="server" Text="Cài đặt thông số bể" OnClick="btn_ThongSoDiezel_2_Click" data-toggle="tooltip" data-placement="right" title="Quyền Admin" />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background: #ffbb55"></i>
                        <span class="title_Tank">RON92 Tank 1</span>
                    </div>
                    <div class="tank">
                        <div class="tank_img">
                            <img src="../Images/Tank_TrangChu.png" />
                            <div class="progress" style="height: 26px;background: #11101d;">
                                <div class="progress-bar" style="width:80%;">80%</div>
                            </div>
                            
                        </div>
                        <div class="tank_info">
                            <div class="tank_water">
                                <table>  
                                    <tr>
                                        <td><label>Mức xăng:</label></td>
                                        <td><asp:Label ID="lbl_MucRON92_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-7px);"><label>(m)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Thể tích:</label></td>
                                        <td><asp:Label ID="lbl_TheTichRON92_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-4px);"><label>(m3)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Nhiệt độ:</label></td>
                                        <td><asp:Label ID="lbl_NhietDoRON92_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;"><label>(độ C)</label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="btn_setting">
                                <asp:Button ID="btn_ThongSoRON92_1" class="btn_ThongSo" runat="server" Text="Cài đặt thông số bể" OnClick="btn_ThongSoRON92_1_Click" data-toggle="tooltip" data-placement="right" title="Quyền Admin" />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background: #ffbb55"></i>
                        <span class="title_Tank">RON92 Tank 2</span>
                    </div>
                    <div class="tank">
                        <div class="tank_img">
                            <img src="../Images/Tank_TrangChu.png" />
                            <div class="progress" style="height: 26px;background: #11101d;">
                                <div class="progress-bar" style="width:80%;">80%</div>
                            </div>
                            
                        </div>
                        <div class="tank_info">
                            <div class="tank_water">
                                <table>  
                                    <tr>
                                        <td><label>Mức xăng:</label></td>
                                        <td><asp:Label ID="lbl_MucRON92_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-7px);"><label>(m)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Thể tích:</label></td>
                                        <td><asp:Label ID="lbl_TheTichRON92_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-4px);"><label>(m3)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Nhiệt độ:</label></td>
                                        <td><asp:Label ID="lbl_NhietDoRON92_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;"><label>(độ C)</label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="btn_setting">
                                <asp:Button ID="btn_ThongSoRON92_2" class="btn_ThongSo" runat="server" Text="Cài đặt thông số bể" OnClick="btn_ThongSoRON92_2_Click" data-toggle="tooltip" data-placement="right" title="Quyền Admin" />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background:brown;"></i>
                        <span class="title_Tank">RON95 Tank 1</span>
                    </div>
                    <div class="tank">
                        <div class="tank_img">
                            <img src="../Images/Tank_TrangChu.png" />
                            <div class="progress" style="height: 26px;background: #11101d;">
                                <div class="progress-bar" style="width:60%;">60%</div>
                            </div>
                            
                        </div>
                        <div class="tank_info">
                            <div class="tank_water">
                                <table>  
                                    <tr>
                                        <td><label>Mức xăng:</label></td>
                                        <td><asp:Label ID="lbl_MucRON95_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-7px);"><label>(m)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Thể tích:</label></td>
                                        <td><asp:Label ID="lbl_TheTichRON95_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-4px);"><label>(m3)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Nhiệt độ:</label></td>
                                        <td><asp:Label ID="lbl_NhietDoRON95_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;"><label>(độ C)</label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="btn_setting">
                                <asp:Button ID="btn_ThongSoRON95_1" class="btn_ThongSo" runat="server" Text="Cài đặt thông số bể" OnClick="btn_ThongSoRON95_1_Click" data-toggle="tooltip" data-placement="right" title="Quyền Admin" />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background:brown;"></i>
                        <span class="title_Tank">RON95 Tank 2</span>
                    </div>
                    <div class="tank">
                        <div class="tank_img">
                            <img src="../Images/Tank_TrangChu.png" />
                            <div class="progress" style="height: 26px;background: #11101d;">
                                <div class="progress-bar" style="width:60%;">60%</div>
                            </div>
                            
                        </div>
                        <div class="tank_info">
                            <div class="tank_water">
                                <table>  
                                    <tr>
                                        <td><label>Mức xăng:</label></td>
                                        <td><asp:Label ID="lbl_MucRON95_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-7px);"><label>(m)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Thể tích:</label></td>
                                        <td><asp:Label ID="lbl_TheTichRON95_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-4px);"><label>(m3)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Nhiệt độ:</label></td>
                                        <td><asp:Label ID="lbl_NhietDoRON95_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;"><label>(độ C)</label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="btn_setting">
                                <asp:Button ID="btn_ThongSoRON95_2" class="btn_ThongSo" runat="server" Text="Cài đặt thông số bể" OnClick="btn_ThongSoRON95_2_Click" data-toggle="tooltip" data-placement="right" title="Quyền Admin" />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background:#41f1b6;"></i>
                        <span class="title_Tank">E100 Tank 1</span>
                    </div>
                    <div class="tank">
                        <div class="tank_img">
                            <img src="../Images/Tank_TrangChu.png" />
                            <div class="progress" style="height: 26px;background: #11101d;">
                                <div class="progress-bar" style="width:60%;">60%</div>
                            </div>
                            
                        </div>
                        <div class="tank_info">
                            <div class="tank_water">
                                <table>  
                                    <tr>
                                        <td><label>Mức Ethanol:</label></td>
                                        <td><asp:Label ID="lbl_MucE100_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-7px);"><label>(m)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Thể tích:</label></td>
                                        <td><asp:Label ID="lbl_TheTichE100_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-4px);"><label>(m3)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Nhiệt độ:</label></td>
                                        <td><asp:Label ID="lbl_NhietDoE100_1" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;"><label>(độ C)</label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="btn_setting">
                                <asp:Button ID="btn_ThongSoE100_1" class="btn_ThongSo" runat="server" Text="Cài đặt thông số bể" OnClick="btn_ThongSoE100_1_Click" data-toggle="tooltip" data-placement="right" title="Quyền Admin" />
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background:#41f1b6;"></i>
                        <span class="title_Tank">E100 Tank 2</span>
                    </div>
                    <div class="tank">
                        <div class="tank_img">
                            <img src="../Images/Tank_TrangChu.png" />
                            <div class="progress" style="height: 26px;background: #11101d;">
                                <div class="progress-bar" style="width:60%;">60%</div>
                            </div>
                            
                        </div>
                        <div class="tank_info">
                            <div class="tank_water">
                                <table>  
                                    <tr>
                                        <td><label>Mức Ethanol:</label></td>
                                        <td><asp:Label ID="lbl_MucE100_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-7px);"><label>(m)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Thể tích:</label></td>
                                        <td><asp:Label ID="lbl_TheTichE100_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;transform: translateX(-4px);"><label>(m3)</label></td>
                                    </tr>
                                    <tr>
                                        <td><label>Nhiệt độ:</label></td>
                                        <td><asp:Label ID="lbl_NhietDoE100_2" runat="server" Text="---"></asp:Label></td>
                                        <td style="text-align: center;"><label>(độ C)</label></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="btn_setting">
                                <asp:Button ID="btn_ThongSoE100_2" class="btn_ThongSo" runat="server" Text="Cài đặt thông số bể" OnClick="btn_ThongSoE100_2_Click" data-toggle="tooltip" data-placement="right" title="Quyền Admin" />
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="DonXuat">
                        <div>
                            <div>
                                <label class="top">Diezel</label>
                            </div>
                            <div class="out">
                                <div class="the">
                                    <div>
                                        <div class="number"><asp:Label ID="lbl_DonXuat_Diezel" runat="server" Text="---"></asp:Label></div>
                                        <div class="name">Đơn</div>
                                    </div>
                                    <div class="icon">
                                        <i class="bi bi-cart"></i>
                                    </div>
                                </div>
                                <div class="the">
                                    <div>
                                        <div class="number"><asp:Label ID="lbl_TienThu_Diezel" runat="server" Text="---"></asp:Label></div>
                                        <div class="name">Thu (trVND)</div>
                                    </div>
                                    <div class="icon">
                                        <i class="bi bi-cash-stack"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div>
                                <label class="top">RON92</label>
                            </div>
                            <div class="out">
                                <div class="the">
                                    <div>
                                        <div class="number"><asp:Label ID="lbl_DonXuat_RON92" runat="server" Text="---"></asp:Label></div>
                                        <div class="name">Đơn</div>
                                    </div>
                                    <div class="icon">
                                        <i class="bi bi-cart"></i>
                                    </div>
                                </div>
                                <div class="the">
                                    <div>
                                        <div class="number"><asp:Label ID="lbl_TienThu_RON92" runat="server" Text="---"></asp:Label></div>
                                        <div class="name">Thu (trVND)</div>
                                    </div>
                                     <div class="icon">
                                         <i class="bi bi-cash-stack"></i>
                                     </div>
                                </div>
                            </div>
                        </div>
                        <div>
                             <div>
                                 <label class="top">RON95</label>
                             </div>
                            <div class="out">
                                 <div class="the">
                                     <div>
                                         <div class="number"><asp:Label ID="lbl_DonXuat_RON95" runat="server" Text="---"></asp:Label></div>
                                         <div class="name">Đơn</div>
                                     </div>
                                     <div class="icon">
                                         <i class="bi bi-cart"></i>
                                     </div>
                                 </div>
                                 <div class="the">
                                     <div>
                                         <div class="number"><asp:Label ID="lbl_TienThu_RON95" runat="server" Text="---"></asp:Label></div>
                                         <div class="name">Thu (trVND)</div>
                                     </div>
                                     <div class="icon">
                                         <i class="bi bi-cash-stack"></i>
                                     </div>
                                 </div>
                             </div>
                        </div>
                        <div>
                             <div>
                                 <label class="top">E5</label>
                             </div>
                            <div class="out">
                                 <div class="the">
                                     <div>
                                         <div class="number"><asp:Label ID="lbl_DonXuat_E5" runat="server" Text="---"></asp:Label></div>
                                         <div class="name">Đơn</div>
                                     </div>
                                     <div class="icon">
                                         <i class="bi bi-cart"></i>
                                     </div>
                                 </div>
                                 <div class="the">
                                     <div>
                                         <div class="number"><asp:Label ID="lbl_TienThu_E5" runat="server" Text="---"></asp:Label></div>
                                         <div class="name">Thu (trVND)</div>
                                     </div>
                                     <div class="icon">
                                         <i class="bi bi-cash-stack"></i>
                                     </div>
                                 </div>
                             </div>
                        </div>
                    </div>
                    <div class="DonHang">
                        <label class="top">Đơn hàng</label>
                        <div style="background:white;border-radius:8px;padding:10px">
                            <div style="display:flex;padding-bottom:6px;align-items:center;" >
                                <label style="margin-top:5px;font-size:18px;">Data</label>
                                <i style="margin-left: 3px;" class="bi bi-chevron-right"></i>
                                <asp:DropDownList ID="ddl_DonHang" CssClass="form-control-sm" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="1">Tất cả đơn</asp:ListItem>
                                    <asp:ListItem Value="2">Đã hoàn thành</asp:ListItem>
                                    <asp:ListItem Value="3">Chưa hoàn thành</asp:ListItem>
                                </asp:DropDownList>

                                <asp:Label ID="Label2" style="margin:0 3px 0 10px;font-size:18px;" runat="server" Text="Thời gian"></asp:Label>
                                <asp:DropDownList ID="ddl_ThoiGian" CssClass="form-control-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ThoiGian_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Gần đây</asp:ListItem>
                                    <asp:ListItem Value="2">Toàn bộ</asp:ListItem>
                                    <asp:ListItem Value="3">Tùy chỉnh</asp:ListItem>
                                </asp:DropDownList>

                                <asp:Panel ID="Panel2" runat="server">
                                    <i style="margin-left: 3px;" class="bi bi-chevron-right"></i>
                                    <asp:TextBox ID="txt_TimeStart" style="width:210px" CssClass="text-center" TextMode="DateTimeLocal" runat="server" required></asp:TextBox>
                                    <label style="margin: 0 3px;font-size:16px;">đến</label>
                                    <asp:TextBox ID="txt_TimeEnd" style="width:210px" CssClass="text-center" TextMode="DateTimeLocal" runat="server" required></asp:TextBox>
                                </asp:Panel>
                                <asp:Button ID="btn_Data" style="height: 30px; margin-left: 8px;" class="btn-sm btn-primary" runat="server" Text="Hiển thị dữ liệu" OnClick="btn_Data_Click" />
                       
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div style="margin-left:10px;" class="spinner-border text-info"></div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div class="Data">
                                <asp:Panel ID="pn_ThongBao" runat="server">
                                    Không tìm thấy dữ liệu...
                                </asp:Panel>
                                <asp:GridView ID="GridView200" CssClass="Data_table table-sm table-bordered table-hover text-center table-responsive-md" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="ID" />
                                        <asp:BoundField DataField="MaDon" HeaderText="Mã đơn" />
                                        <asp:BoundField DataField="SanPham" HeaderText="Sản phẩm" />
                                        <asp:BoundField DataField="TheTich" HeaderText="Thể tích (m3)" />
                                        <asp:BoundField DataField="DonGia" HeaderText="Đơn giá (VND/l)" />
                                        <asp:BoundField DataField="ThanhTien" HeaderText="Thành tiền (trVND)" />
                                        <asp:BoundField DataField="TrangThai" HeaderText="Trạng thái" />
                                        <asp:BoundField DataField="ThoiGian" HeaderText="Thời gian" />
                                    </Columns>
                                    <headerStyle HorizontalAlign="center" CssClass="table table-primary" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </main>
        <script>
            $("#Home").addClass('active');

            var kt = new String('<%= check %>')

            if (kt == "1") {
                $(".background_setting").show();
                $(".tank_setting").show();
            }
            if(kt == "0") {
                $(".background_setting").hide();
                $(".tank_setting").hide();
            }

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function () {
                createDataTable();
            });

            createDataTable();

            function createDataTable() {
                //Phân trang cho Table
                $(".Data_table").dataTable({
                    "language": {
                        "sProcessing": "Đang xử lý...",
                        "sLengthMenu": "Xem _MENU_ mục",
                        "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
                        "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
                        "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
                        "sInfoFiltered": "(được lọc từ _MAX_ mục)",
                        "sInfoPostFix": "",
                        "sSearch": "Tìm:",
                        "sUrl": "",
                        "oPaginate": {
                            "sFirst": "Đầu",
                            "sPrevious": "Trước",
                            "sNext": "Tiếp",
                            "sLast": "Cuối"
                        }
                    },
                    "processing": true, // tiền xử lý trước
                    "order": [[7, 'desc']], //sắp xếp giảm dần theo cột thứ 8
                    "dom": 'lBfrtip',
                    buttons: [
                        {
                            extend: 'copyHtml5',
                            text: '<i class="bi bi-journals"></i> Copy',
                            titleAttr: 'Copy',
                        },
                        {
                            extend: 'excelHtml5',
                            text: '<i class="bi bi-file-earmark-excel"></i> Excel',
                            titleAttr: 'Excel'
                        },
                        {
                            extend: 'csvHtml5',
                            text: '<i class="bi bi-filetype-csv"></i> CSV',
                            titleAttr: 'CSV'
                        },
                        {
                            extend: 'pdfHtml5',
                            text: '<i class="bi bi-file-earmark-pdf"></i> PDF',
                            titleAttr: 'PDF'
                        },
                        {
                            extend: 'print',
                            text: '<i class="bi bi-printer"></i> Print',
                            titleAttr: 'Print'
                        }
                    ],
                });
            }
            
        </script>
        
        <!------------------------ END OF MAIN --------------------------->
</asp:Content>
