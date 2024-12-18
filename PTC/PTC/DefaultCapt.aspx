<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DefaultCapt.aspx.cs" Inherits="DefaultCapt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Human Recognition Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
    <div>
    <IMG style="WIDTH: 180px; HEIGHT: 51px" alt="" src=Captcha.aspx /> 
        <br />
        <br />
        <asp:TextBox ID="txtCaptcha" runat="server" CssClass="textbox" 
            Font-Names="Segoe UI"></asp:TextBox><br /><br />
        
        <asp:Button ID="Button1" runat="server" Text="SUBMIT" OnClick="Button1_Click" 
            CssClass="button" Font-Names="Segoe UI" Font-Size="15px" />
        
    </div>
    </center>
    </form>
</body>
</html>
