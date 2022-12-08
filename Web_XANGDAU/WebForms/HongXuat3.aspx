<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Scada.Master" AutoEventWireup="true" CodeBehind="HongXuat3.aspx.cs" Inherits="Web_XANGDAU.WebForms.HongXuat3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Online_Scada.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer_Hong3" Interval="1000" runat="server" OnTick="Timer_Hong3_Tick"></asp:Timer>
            <div class="tank_title">
                        <i class="bi bi-droplet-half" style="background: #ffbb55"></i>
                        <span class="title_Tank">Họng 3 - RON92 Tank 1</span>
                    </div>
                    <div class="tank">
                        <img src="../Images/Scada_OneTank.PNG" alt="" class="box">
                        <div class="symbol">
                            <asp:Image ID="SVanXuat_1" src="../Images/Symbol/Van_1.png" class="box SVanXuat" runat="server" />
                            <asp:Image ID="SVanXuat_2" src="../Images/Symbol/Van_2.png" class="box SVanXuat" runat="server" />
                            <asp:Image ID="SBomXuat_1" src="../Images/Symbol/Bom_1.png" class="box SBomXuat" runat="server" />
                            <asp:Image ID="SBomXuat_2" src="../Images/Symbol/Bom_2.png" class="box SBomXuat" runat="server" />
                            <asp:Image ID="SMucHH_2" src="../Images/Symbol/Muc_2.png" class="box SMucHH" runat="server" />
                            <asp:Image ID="SMucH_2" src="../Images/Symbol/Muc_2.png" class="box SMucH" runat="server" />
                            <asp:Image ID="SMucL_1" src="../Images/Symbol/Muc_1.png" class="box SMucL" runat="server" />
                            <asp:Image ID="SMucL_2" src="../Images/Symbol/Muc_2.png" class="box SMucL" runat="server" />
                            <asp:Image ID="SMucLL_1" src="../Images/Symbol/Muc_1.png" class="box SMucLL" runat="server" />
                            <asp:Image ID="SMucLL_2" src="../Images/Symbol/Muc_2.png" class="box SMucLL" runat="server" />
                            <asp:Image ID="SXe" src="../Images/Symbol/Xe.png" class="box SXe" runat="server" />   
                        </div>
                        <div class="box progress" style="height: 38px;background: #11101d;">
                            <asp:Panel ID="pn_MucPer" class="progress-bar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width:60%;" runat="server">
                                 <asp:Label ID="lbl_MucPer" runat="server" Text="---" ForeColor="White"></asp:Label>
                             </asp:Panel>
                        </div>
                        <div class="box output">
                            <asp:TextBox ID="txt_VanXuat" type="number" min="0" max="100" class="form-control-sm textbox VanXuat" runat="server" ReadOnly="True" ToolTip="Độ mở van xuất"></asp:TextBox>
                            <asp:TextBox ID="txt_LuuLuongXuat" type="number" min="0" max="100" class="form-control-sm textbox LuuLuongXuat" runat="server" ReadOnly="True" ToolTip="Lưu lượng xuất"></asp:TextBox>
                            <asp:TextBox ID="txt_Muc" type="number" min="0" max="100" class="form-control-sm textbox Muc" runat="server" ReadOnly="True" ToolTip="Mức xăng"></asp:TextBox>
                            <asp:TextBox ID="txt_NhietDo" type="number" min="0" max="100" class="form-control-sm textbox NhietDo" runat="server" ReadOnly="True" ToolTip="Nhiệt độ bể xăng"></asp:TextBox>
                        </div>
                        <div class="box GiamSat">
                            <table class="table-sm table-hover">
                                <thead>
                                  <tr>
                                    <th>Thông số</th>
                                    <th>Trạng thái</th>
                                  </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Kết nối</td>
                                        <td><asp:Label ID="lbl_KetNoi" runat="server" Text="Chưa kết nối" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Tiếp địa</td>
                                        <td><asp:Label ID="lbl_TiepDia" runat="server" Text="Chưa đảm bảo" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Nhiệt độ</td>
                                        <td><asp:Label ID="lbl_NhietDo" runat="server" Text="---"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Mức</td>
                                        <td><asp:Label ID="lbl_Muc" runat="server" Text="---"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Đầu xuất</td>
                                        <td><asp:Label ID="lbl_DauXuat" runat="server" Text="Chưa gắn chặt" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="box DonXuat">
                            <div>
                                <label>Mã đơn xuất:</label>
                                <asp:TextBox ID="txt_MaDonXuat" type="text" class="form-control-sm txt_MaDon" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div>
                                <label>Cần xuất:</label>
                                <asp:TextBox ID="txt_TheTichCanXuat" type="text" class="form-control-sm text-center txt_TheTichCan" runat="server" ReadOnly="True"></asp:TextBox>
                                <labe>(m3)</labe>
                            </div>
                            <div>
                                <label>Đã xuất:</label>
                                <asp:TextBox ID="txt_TheTichDaXuat" type="text" class="form-control-sm text-center txt_TheTichDaBom" runat="server" ReadOnly="True"></asp:TextBox>
                                <label>(m3)</label>
                            </div>
                            <div>
                                <asp:Button ID="btn_XuatLieu" type="button" class="btn btn-success btn_Bom" runat="server" Text="Nhập liệu" />
                                <asp:Button ID="btn_DungXuat" type="button" class="btn btn-danger btn_DungBom" runat="server" Text="Dừng nhập" />
                            </div>
                        </div>   
                        <div class="box DonGia">
                            <div>
                                <label>Sản phẩm:</label>
                                <asp:TextBox ID="txt_SanPham" type="text" class="form-control-sm text-center txt_SanPham" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div>
                                <label>Đơn giá:</label>
                                <asp:TextBox ID="txt_DonGia" type="text" class="form-control-sm text-center txt_DonGia" runat="server" ReadOnly="True"></asp:TextBox>
                                <label>(VND/l)</label>
                            </div>
                            <div>
                                <label>Thành tiền:</label>
                                <asp:TextBox ID="txt_ThanhTien" type="text" class="form-control-sm text-center txt_ThanhTien" runat="server" ReadOnly="True"></asp:TextBox>
                                <label>(trVND)</label>
                            </div>
                            <div>
                                <label>Trạng thái:</label>
                                <asp:TextBox ID="txt_TrangThai" type="text" class="form-control-sm text-center txt_TrangThai" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="box Dem"></div>
                    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $("#Scada").addClass('active');
    </script>
</asp:Content>
