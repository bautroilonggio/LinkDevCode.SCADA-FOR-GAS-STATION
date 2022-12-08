<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GD_Data.aspx.cs" Inherits="Web_XANGDAU.WebForms.GD_DataTram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/DuLieuTram.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <main>
                <div class="head_title">
                    <h3>Dữ liệu trạm xăng dầu</h3>
                    <div style="display:flex;padding-bottom:6px;align-items:center;" >
                        <label style="margin-top:5px;font-size:18px;">Data</label>
                        <i style="margin: 0 3px 0 3px;" class="bi bi-chevron-right"></i>
                        <asp:DropDownList ID="ddl_KieuXem" CssClass="text-primary" runat="server" OnSelectedIndexChanged="ddl_KieuXem_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="1">Tất cả dữ liệu</asp:ListItem>
                            <asp:ListItem Value="2">Theo tank</asp:ListItem>
                            <asp:ListItem Value="3">Theo hạng mục</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Panel ID="pn_TheoTank" runat="server">
                            <i style="margin-left:3px;" class="bi bi-chevron-right"></i>
                            <asp:DropDownList ID="ddl_TheoTank" CssClass="text-primary" runat="server">
                                <asp:ListItem Value="1">Diezel</asp:ListItem>
                                <asp:ListItem Value="2">RON 92</asp:ListItem>
                                <asp:ListItem Value="3">RON 95</asp:ListItem>
                                <asp:ListItem Value="4">E100</asp:ListItem>
                            </asp:DropDownList>
                        </asp:Panel>
                        <asp:Panel ID="pn_TheoHangMuc" runat="server">
                            <i style="margin-left:3px;" class="bi bi-chevron-right"></i>
                            <asp:DropDownList ID="ddl_TheoHangMuc" CssClass="text-primary" runat="server">
                                <asp:ListItem Value="1">Van xuất</asp:ListItem>
                                <asp:ListItem Value="2">Lưu lượng xuất</asp:ListItem>
                                <asp:ListItem Value="3">Mức chất lỏng</asp:ListItem>
                                <asp:ListItem Value="4">Nhiệt độ</asp:ListItem>
                                <asp:ListItem Value="5">Bơm xuất</asp:ListItem>
                            </asp:DropDownList>
                        </asp:Panel>

                        <label style="margin:0 3px 0 10px;font-size:18px;">Thời gian:</label>
                        <asp:DropDownList ID="ddl_ThoiGian" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ThoiGian_SelectedIndexChanged">
                            <asp:ListItem Value="1">Toàn bộ</asp:ListItem>
                            <asp:ListItem Value="2">Tùy chỉnh</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Panel ID="pn_ThoiGian" runat="server">
                            <i style="margin-left:3px;" class="bi bi-chevron-right"></i>
                            <asp:TextBox ID="txt_TimeStart" style="height:27px;width:135px;" CssClass="text-center" TextMode="DateTimeLocal" runat="server" required></asp:TextBox>
                            <label style="margin: 0 3px;font-size:16px;">đến</label>
                            <asp:TextBox ID="txt_TimeEnd" style="height:27px;width:135px;" CssClass="text-center" TextMode="DateTimeLocal" runat="server" required></asp:TextBox>
                        </asp:Panel>

                        <asp:Button ID="btn_Data" style="height: 30px; margin-left: 8px;" class="btn-sm btn-primary" runat="server" Text="Hiển thị dữ liệu" OnClick="btn_Data_Click" />
                
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <div style="margin-left:10px;" class="spinner-border text-info"></div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                <div class="Data">
                    <div class="Data_title" style="padding-bottom: 8px;"><asp:Label ID="lbl_Data" runat="server" Text="Dữ liệu"></asp:Label></div>
                    <asp:Panel ID="pn_ThongBao" runat="server">
                        Không tìm thấy dữ liệu...
                    </asp:Panel>
                    <div class="X">
                        <asp:GridView ID="GridView100" CssClass="Data_table table-sm table-bordered table-hover text-center" runat="server" AutoGenerateColumns="False">
                            <headerStyle HorizontalAlign="center" CssClass="table table-primary" />
                        </asp:GridView>
                    </div>
                </div>
            </main>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $("#DuLieuTram").addClass('active');
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
                "aLengthMenu": [[5, 10, 20, 50], [5, 10, 20, 50]], // danh sách số trang trên 1 lần hiển thị bảng
                "order": [[$('thead tr th').length - 1, 'desc']], //sắp xếp giảm dần theo cột cuối cùng
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
