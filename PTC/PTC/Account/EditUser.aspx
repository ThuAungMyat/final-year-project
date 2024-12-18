<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Account_EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
    function isDelete() {
        return confirm("Do you want to delete this row ?");
    }
</script>

<div style="border:0px solid #e5ebf4;height:30px;-moz-border-radius:5px 5px 0 0;">

</div>
<div style="margin:-27px 0px 0px 0px;position:absolute;color:#474747;font-weight:bold;font-size:14pt;color:#777777;">
	General User Information
</div>
<hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;"/>

<fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;">
	<legend><b>Edit User</b></legend>
	<div>
        <table cellpadding="2">
          <tr>
             <td style="width: 110px;" class="fieldname">UserName:</td>
             <td style="width: 300px;"><asp:Literal runat="server" ID="lblUserName" /></td>
          </tr>
          <tr>
             <td class="fieldname">E-mail:</td>
             <td><asp:HyperLink runat="server" ID="lnkEmail" /></td>
          </tr>
          <tr>
             <td class="fieldname">Registered:</td>
             <td><asp:Literal runat="server" ID="lblRegistered" /></td>
          </tr>
          <tr>
             <td class="fieldname">Last Login:</td>
             <td><asp:Literal runat="server" ID="lblLastLogin" /></td>
          </tr>
          <tr>
             <td class="fieldname">Last Activity:</td>
             <td><asp:Literal runat="server" ID="lblLastActivity" /></td>
          </tr>
          <tr>
             <td class="fieldname"><asp:Label runat="server" ID="lblOnlineNow" AssociatedControlID="chkOnlineNow" Text="Online Now:" /></td>
             <td><asp:CheckBox runat="server" ID="chkOnlineNow" Enabled="false" /></td>
          </tr>
          <tr>
             <td class="fieldname"><asp:Label runat="server" ID="lblApproved" AssociatedControlID="chkApproved" Text="Approved:" /></td>
             <td><asp:CheckBox runat="server" ID="chkApproved" AutoPostBack="true" OnCheckedChanged="chkApproved_CheckedChanged" /></td>
          </tr>
          <tr>
             <td class="fieldname"><asp:Label runat="server" ID="lblLockedOut" AssociatedControlID="chkLockedOut" Text="Locked Out:" /></td>
             <td><asp:CheckBox runat="server" ID="chkLockedOut" AutoPostBack="true" OnCheckedChanged="chkLockedOut_CheckedChanged" /></td>
          </tr>
       </table>
       <div style="float:left;width:200px;padding:0px 0px 10px 25px;margin-left:0px;border:1px solid #e5ebf4;background-color:#f9f9f9;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;">
        <p><b>Edit User's Roles</b></p>
           <asp:CheckBoxList ID="chklRoles" runat="server" AutoPostBack="True" 
               onselectedindexchanged="chklRoles_SelectedIndexChanged">
           </asp:CheckBoxList>
       <//div>
    </div>
</fieldset>
</asp:Content>

