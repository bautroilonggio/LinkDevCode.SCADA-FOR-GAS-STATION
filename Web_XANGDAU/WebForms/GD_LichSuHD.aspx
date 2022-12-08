<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GD_LichSuHD.aspx.cs" Inherits="Web_XANGDAU.WebForms.BaoCao" %>
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
                    <h3>Lịch sử hoạt động</h3>
                    <div style="display:flex;padding-bottom:6px;align-items:center;" >
                        <label style="margin-top:5px;font-size:18px;">Data</label>
                        <i style="margin: 0 3px 0 3px;" class="bi bi-chevron-right"></i>
                        <asp:DropDownList ID="ddl_LichSuHD" runat="server">
                            <asp:ListItem Value="1">Toàn bộ</asp:ListItem>
                            <asp:ListItem Value="2">Đăng nhập</asp:ListItem>
                            <asp:ListItem Value="3">SCADA</asp:ListItem>
                            <asp:ListItem Value="3">Cảnh báo</asp:ListItem>
                        </asp:DropDownList>

                        <label style="margin:0 3px 0 10px;font-size:18px;">Thời gian:</label>
                        <asp:DropDownList ID="ddl_ThoiGian" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ThoiGian_SelectedIndexChanged">
                            <asp:ListItem Value="1">Toàn bộ</asp:ListItem>
                            <asp:ListItem Value="2">Tùy chỉnh</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Panel ID="pn_ThoiGian" runat="server">
                            <i style="margin-left:3px;" class="bi bi-chevron-right"></i>
                            <asp:TextBox ID="txt_TimeStart" style="width:200px;" CssClass="text-center" TextMode="DateTimeLocal" runat="server" required></asp:TextBox>
                            <label style="margin: 0 3px;font-size:16px;">đến</label>
                            <asp:TextBox ID="txt_TimeEnd" style="width:200px;" CssClass="text-center" TextMode="DateTimeLocal" runat="server" required></asp:TextBox>
                        </asp:Panel>

                        <asp:Button ID="btn_LichSuHD" style="height: 30px; margin-left: 8px;" class="btn-sm btn-primary" runat="server" Text="Hiển thị dữ liệu" OnClick="btn_LichSuHD_Click" />

                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <div style="margin-left:10px;" class="spinner-border text-info"></div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                <div class="Data">
                    <div class="Data_title" style="padding-bottom: 8px;"><asp:Label ID="lbl_Data" runat="server" Text="Dữ liệu lịch sử"></asp:Label></div>
                    <asp:Panel ID="pn_ThongBao" runat="server">
                        Không tìm thấy dữ liệu...
                    </asp:Panel>
                    <div class="X">
                        <asp:GridView ID="GridView300" CssClass="Data_table table-sm table-bordered table-hover" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                <asp:BoundField DataField="SuKien" HeaderText="Sự kiện" />
                                <asp:BoundField DataField="ChiTiet" HeaderText="Chi tiết" />
                                <asp:BoundField DataField="ThoiGian" HeaderText="Thời gian" />
                            </Columns>
                            <headerStyle HorizontalAlign="center" CssClass="table table-primary" />
                        </asp:GridView>
                    </div>
                </div>
            </main>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $("#LichSuHD").addClass('active');
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
                "order": [[0, 'desc']], //sắp xếp giảm dần theo cột thứ 1
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
</asp:Content>
