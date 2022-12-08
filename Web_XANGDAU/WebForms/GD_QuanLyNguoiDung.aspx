<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GD_QuanLyNguoiDung.aspx.cs" Inherits="Web_XANGDAU.WebForms.QuanLyNguoiDung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--
    Author: Nguyen Khac Linh
    Anthor URL: https://www.facebook.com/link.hust
--%>
    <link href="../css/DuLieuTram.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <main>
                <div class="head_title">
                    <h3>Quản lý người dùng</h3>
                    <div>
                        <label>Data</label>
                        <i class="bi bi-chevron-right"></i>
                        <label>Người dùng</label>
                    </div>
                </div>
                <div class="Data" style="height:calc(100vh - 158px);border-radius:8px">
                    <div class="Data_title" style="padding-bottom: 8px;">Danh sách người dùng</div>
                    <asp:Panel ID="pn_ThongBao" runat="server">
                            Bạn cần đăng nhập với quyền Admin...Đăng nhập lại đi bạn ơi :V
                    </asp:Panel>
                    <div class="X">
                        <asp:GridView ID="GridView150" CssClass="Data_table table-sm table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView150_RowDataBound" DataKeyNames="ID" OnRowDeleting="GridView150_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                <asp:BoundField DataField="TaiKhoan" HeaderText="Tài khoản"></asp:BoundField>
                                <asp:BoundField DataField="HoTen" HeaderText="Họ tên"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                <asp:BoundField DataField="DienThoai" HeaderText="Điện thoại"></asp:BoundField>
                                <asp:BoundField DataField="LoaiTaiKhoan" HeaderText="Quyền"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete">Xóa tài khoản</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="center" CssClass="table table-primary" />
                        </asp:GridView>
                    </div>
                </div>
            </main>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $("#QuanLyNguoiDung").addClass(' active');
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
                "order": [[5, 'desc']], //sắp xếp giảm dần theo cột thứ 6
            });
        }
    </script>
</asp:Content>
