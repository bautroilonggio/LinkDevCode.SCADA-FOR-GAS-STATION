<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Scada.Master" AutoEventWireup="true" CodeBehind="GD_Online_Scada.aspx.cs" Inherits="Web_XANGDAU.WebForms.GD_Online_Scada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Online_Scada.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Vui lòng chọn họng xuất để giám sát hoặc nhập mã đơn để thực hiện việc xuất xăng/dầu !!!
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        $("#Scada").addClass('active');
    </script>
</asp:Content>
