<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DN_Login.aspx.cs" Inherits="Web_XANGDAU.webforms.Login" %>

<%--
    Author: Nguyen Khac Linh
    Anthor URL: https://www.facebook.com/link.hust
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TRẠM XĂNG DẦU</title>
    <link href="../css/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="frm_Login" runat="server" class="Login_form">
        <div>
            <p class="Login_heading">Đăng nhập tài khoản</p>
            <div class="form_text">
                <asp:TextBox ID="txt_TaiKhoan" runat="server" class="input" type="text" required></asp:TextBox>
                <label>Tài khoản</label>
            </div>    
            <div class="form_text">             
                <asp:TextBox ID="txt_MatKhau" runat="server" class="input" type="password" required></asp:TextBox>
                <label>Mật khẩu</label>
            </div>   
            <asp:Button ID="btn_DangNhap" runat="server" Text="Đăng nhập" type="submit" class="form_submit" OnClick="btn_DangNhap_Click"/>
            <asp:LinkButton ID="lb_QuenMatKhau" runat="server" class="Format_link" href="DN_Format_Pass.aspx">Quên mật khẩu?</asp:LinkButton>
            <div class="prevent"></div>
            <label class="Register">Bạn chưa có tài khoản?</label>
            <asp:LinkButton ID="lb_DangKy" runat="server" class="Register_link" href="DN_Register.aspx">Đăng ký</asp:LinkButton>
        </div>
    </form>
    </body>
        <script type = "text/javascript" >
            window.onload = window.history.forward(0);
        </script>
</html>
