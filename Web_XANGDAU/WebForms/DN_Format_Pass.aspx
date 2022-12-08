<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DN_Format_Pass.aspx.cs" Inherits="Web_XANGDAU.webforms.Format_Pass" %>

<%--
    Author: Nguyen Khac Linh
    Anthor URL: https://www.facebook.com/link.hust
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TRAM XĂNG DẦU</title>
    <link href="../css/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="frm_Register" runat="server" class="Login_form" style="height:85%">
        <div>
            <p class="Login_heading">Đổi mật khẩu</p>
            <div class="form_text">
                <asp:TextBox ID="txt_TaiKhoan" runat="server" class="textbox" type="text" required></asp:TextBox>
                <label>Tài khoản</label>            
            </div>    
            <div class="form_text">               
                <asp:TextBox ID="txt_HoTen" runat="server" class="textbox" type="text" required></asp:TextBox>
                <label>Họ tên</label>
            </div>          
            <div class="form_text">
                <asp:TextBox ID="txt_Email" runat="server" class="textbox" type="email" required></asp:TextBox>
                <label>Email</label>
            </div>  
            <div class="form_text">              
                <asp:TextBox ID="txt_Phone" runat="server" class="textbox" type="text" required></asp:TextBox>
                <label>Số điện thoại</label>
            </div>  
            <div class="form_text">
                <asp:TextBox ID="txt_NewPass" runat="server" class="textbox" type="password" required></asp:TextBox>
                <label>Mật khẩu mới</label>
            </div>
            <div class="form_text">              
                <asp:TextBox ID="txt_ConPass" runat="server" class="textbox" type="password" required></asp:TextBox>
                <label>Xác nhận</label>
            </div> 
            <asp:Button ID="btn_XacNhan" runat="server" Text="Đăng ký" class="form_submit" OnClick="btn_XacNhan_Click"/>        
        </div>
    </form>
</body>
</html>
