<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ManageSingleRole.aspx.cs" Inherits="Account_ManageSingleRole" %>

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
	Manage Single Roles
</div>
<hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;"/>


<fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;">
	<legend><b>Create New Roles</b></legend>
	<div>
	<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
		<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
	Manage Single Role <b>[ <asp:Label ID="lblRoleName" runat="server" Text=""></asp:Label> ]</b>
    <br />
    <br />
    <div>
        <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:Button ID="btnAddUserToRole" CssClass="button" runat="server" 
            Text="Add User To Role" onclick="btnAddUserToRole_Click"  />
    </div>
	</div>
	<br />
    
    <div style="width:100%;">
		<asp:GridView ID="gvRolesUserList" runat="server" Width="100%"
		AutoGenerateColumns="False" CellPadding="4" ForeColor="#454545"  PageSize="10"
		GridLines="None"  AllowPaging="true" BorderStyle="Solid"
		BorderColor="#dddddd" BorderWidth="1px" onrowdeleting="gvRolesUserList_RowDeleting" 
            onrowcreated="gvRolesUserList_RowCreated">

		<AlternatingRowStyle BackColor="White" ForeColor="#454545" />
			<Columns>
				<asp:TemplateField HeaderText="User Name">
					<ItemTemplate>
						<asp:Label ID="UserNameLabel" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
                <asp:ButtonField CommandName="Delete" ButtonType="Image" ImageUrl="~/Images/delete.png" /> 
			</Columns>
			<EditRowStyle BackColor="" />
			<FooterStyle BackColor="" Font-Bold="True" ForeColor="#454545" CssClass="GridView_Footer"/>
			<HeaderStyle BackColor="" Font-Bold="True" ForeColor="#454545" CssClass="GridView_Header"/>
			<PagerStyle BackColor="" ForeColor="#454545" HorizontalAlign="Center" CssClass="GridView_Pager" />
			<RowStyle BackColor="#f9f9f9" ForeColor="#454545" CssClass="GridView_Row" />
			<SelectedRowStyle BackColor="" CssClass="GridView_Select" Font-Bold="true" ForeColor="#454545" />
			<SortedAscendingCellStyle BackColor="" />
			<SortedAscendingHeaderStyle BackColor="" />
			<SortedDescendingCellStyle BackColor="" />
			<SortedDescendingHeaderStyle BackColor="" />
		</asp:GridView>

	</div>
</fieldset>
</asp:Content>

