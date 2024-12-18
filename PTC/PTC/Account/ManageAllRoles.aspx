<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ManageAllRoles.aspx.cs" Inherits="Account_ManageAllRoles" %>

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
	Manage All Roles
</div>
<hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;"/>

<fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;">
	<legend><b>Create New Roles</b></legend>
	<div>
	<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
		<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
		<table>
			<tr>
				<td>
					Role Name
				</td>
				<td>
					:
				</td>
				<td>
					<asp:TextBox CssClass="textbox" ID="txtRoleName" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ErrorMessage="Require RoleName." ControlToValidate="txtRoleName" ForeColor="Red">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
				</td>
				<td>
				</td>
				<td>
					<asp:Button ID="butSave" CssClass="button" runat="server" Text="Save" onclick="butSave_Click" />&nbsp;
					<asp:Button ID="butCancel" CssClass="button" runat="server" Text="Cancel" onclick="butCancel_Click"  CausesValidation="False" />
				</td>
			</tr>
		</table>
	</div>
	<br />
	<div style="width:100%;">
		<asp:GridView ID="gvRoles" runat="server" Width="100%"
		AutoGenerateColumns="False" CellPadding="4" ForeColor="#454545"  PageSize="10"
		GridLines="None" onrowcommand="gvRoles_RowCommand"  AllowPaging="true" BorderStyle="Solid"
		BorderColor="#dddddd" BorderWidth="1px" 
            onpageindexchanging="gvRoles_PageIndexChanging" onrowdeleting="gvRoles_RowDeleting">

		<AlternatingRowStyle BackColor="White" ForeColor="#454545" />
			<Columns>
				<asp:TemplateField HeaderText="RoleName">
					<ItemTemplate>
						<asp:Label ID="lblRoleName" runat="server" Text="<%# Container.DataItem.ToString() %>"></asp:Label>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
                <asp:TemplateField HeaderText="Add/Remove Users">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnManageRole" runat="server" Text="Manage" commandName="ManageRole" ToolTip="<%# Container.DataItem.ToString() %>" CausesValidation="false"></asp:LinkButton>                    
                    </ItemTemplate>
                </asp:TemplateField>
				<asp:TemplateField HeaderText="Actions">
					<ItemTemplate>
						<asp:ImageButton ID="ibutDelete" runat="server" OnClientClick="return isDelete();" CommandName="Delete" ImageUrl="~/Images/delete.png" CausesValidation="false"/>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
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

