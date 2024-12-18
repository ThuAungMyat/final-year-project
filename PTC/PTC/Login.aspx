<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:330px;margin:180px 50px 50px 460px;">
        <div style="border:0px solid #e5ebf4;background:#fff url('');height:30px;-moz-border-radius:5px 5px 0 0;">
       
        </div>
        <div style="margin:-27px 0px 0px 0px;position:absolute;color:#474747;font-weight:bold;font-size:14pt;color:#777777;">
            Login Here?
        </div> 
        <hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;width:320px;"/>

        <div style="margin:0px 0px 6px 0px;">
            Not a member? 
            <asp:HyperLink ID="RegisterHyperLink" runat="server" CssClass="hyperlink" 
                EnableViewState="False" NavigateUrl="~/Register.aspx" SkinID="LNK_NORMAL">Create an account now</asp:HyperLink>
        </div>

        <fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;width:320px;">
            <legend><b style="font-size:12pt;color:#777777;">User Login</b></legend>

            <div>
            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" 
                    RenderOuterTable="false" onloggedin="LoginUser_LoggedIn">
                <LayoutTemplate>
                    <span style="color:Red;">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
           
                    <div>
                        <table cellpadding="0" cellspacing="0">
                            <tr style="height:40px;">
                                <td style="width:100px;">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                        ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                           <tr style="height:40px;">
                                <td>
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                    ErrorMessage="Password is required." ToolTip="Password is required." 
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height:40px;">
                                <td>
                                
                                </td>
                                <td>
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Keep me signed in."/>
                                    <asp:Button ID="LoginButton" CssClass="button" runat="server" CommandName="Login" Text="Log In"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                </LayoutTemplate>
            </asp:Login>
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
