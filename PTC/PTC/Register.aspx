<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div>
        <div style="border:0px solid #e5ebf4;background:#fff url('');height:30px;-moz-border-radius:5px 5px 0 0;">
       
        </div>
        <div style="margin:-27px 0px 0px 0px;position:absolute;color:#474747;font-weight:bold;font-size:14pt;color:#777777;">
           Account Registration
        </div> 
        <hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;"/>

        <div style="margin:0px 0px 6px 0px;">
            Already have an account? <asp:HyperLink ID="HyperLink1" CssClass="hyperlink" runat="server" NavigateUrl="~/Login.aspx" SkinID="LNK_NORMAL">Login</asp:HyperLink>
        </div>

        <fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;">
            <legend><b>User Details</b></legend>
            <asp:Label ID="lblIP" runat="server" Text="Label" Visible="False"></asp:Label><br />
            <asp:Label id="CreateAccountResults" runat="server" ForeColor="Red"></asp:Label>
             <div>
                <table style="margin:0px 0px 0px 20px;">
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessage" ForeColor="red" runat="server"></asp:Label>
                            <div style="margin-left:50px;"><asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                ValidationGroup="Group1" /></div>
                                <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 142px; text-align: right;">
                            User Name 
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtUserName" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                                ControlToValidate="txtUserName" ErrorMessage="User Name is required?" 
                            ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Password 
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" CssClass="textbox" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                                ControlToValidate="txtPassword" ErrorMessage="Password is required?" 
                            ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Confirm Password 
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" CssClass="textbox" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" 
                                ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required?" 
                                ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                                ErrorMessage="Confirm Password do not match?" ForeColor="Red" 
                                ValidationGroup="Group1">*</asp:CompareValidator>
                        </td>
                    </tr>
                     <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Date Of Birth 
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" 
                                ControlToValidate="txtDateOfBirth" ErrorMessage="Date Of Birth is required?" 
                            ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateOfBirth" CssClass= " cal_Theme1" Format="d" TodaysDateFormat="d MMMM, yyyy" >
                            </asp:CalendarExtender>
                            <%--<asp:DropDownList ID="ddlDays" runat="server" CssClass="dropdownlist">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlMonths_SelectedIndexChanged" CssClass="dropdownlist"> 
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlYears" runat="server" CssClass="dropdownlist">
                            </asp:DropDownList>--%>
                    
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Gender
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:RadioButton ID="rdoMale" runat="server" GroupName="Gender" Text="Male" Checked="True" />
                            <asp:RadioButton ID="rdoFemale" runat="server" GroupName="Gender" Text="Female" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            IP Address</td>
                        <td valign="top">
                            :</td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtIP" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Email
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtEmail" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                ControlToValidate="txtEmail" ErrorMessage="Email is required?" 
                                ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                ControlToValidate="txtEmail" ErrorMessage="Invalid Email Address?" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="Group1" ForeColor="Red">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Paypal Email</td>
                        <td valign="top">
                            :</td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtPaypalEmail" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPaypalEmail" runat="server" 
                                ControlToValidate="txtPaypalEmail" ErrorMessage="Email is required?" 
                                ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPaypalEmail" runat="server" 
                                ControlToValidate="txtPaypalEmail" ErrorMessage="Invalid Email Address?" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="Group1" ForeColor="Red">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Security Question 
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtSecurityQuestion" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSecurityQuestion" runat="server" 
                                ControlToValidate="txtSecurityQuestion" ErrorMessage="Security Question is required?" 
                            ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Security Answer
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtSecurityAnswer" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSecurityAnswer" runat="server" 
                                ControlToValidate="txtSecurityAnswer" ErrorMessage="Security Answer is required?" 
                            ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Phone No 
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtPhoneNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Address
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtAddress" runat="server"  Width="250px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                                ControlToValidate="txtAddress" ErrorMessage="Address Is required?" 
                            ValidationGroup="Group1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 142px; text-align: right;">
                            Photo
                        </td>
                        <td valign="top">
                            :
                        </td>
                        <td>
                            <asp:FileUpload ID="UploadUserImage" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div  style="margin-left:155px;">
                                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button"  ValidationGroup="Group1" OnClick="btnRegister_Click"/>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"
                                    onclick="btnCancel_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
 
        </fieldset>
    </div>
</asp:Content>

