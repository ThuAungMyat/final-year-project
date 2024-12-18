<%@ Page Title="Ads Package" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="AdsPackage.aspx.cs" Inherits="AdsPackage" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            font-family: "Segoe UI";
            font-size: 20px;
        }
        .style3
        {
            font-family: "Segoe UI";
        }
        .style4
        {
            font-size: 14px;
        }
        .style5
        {
            font-family: "Segoe UI";
            font-size: 14px;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1">
    <div>
    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");
        }
</script>

<div style="border:0px solid #e5ebf4;height:30px;-moz-border-radius:5px 5px 0 0;">

</div>
<div style="margin:-27px 0px 0px 0px;position:absolute;color:#474747;font-weight:bold;font-size:14pt;color:#777777;">
	<span class="style2">Ads Package</span>
</div>
<hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;"/>

<fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;width:800px;">
	<legend class="style3"><b style="color:#777777;" class="style4">AdsPackage</b></legend>
	<div>
	<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
            Font-Names="Segoe UI" Font-Size="14px" />
		<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" 
            Font-Names="Segoe UI" Font-Size="14px"></asp:Label>
		<table>
			<tr>
				<td class="style5">
					Clicks
				</td>
				<td>
					:
				</td>
				<td>
					<asp:TextBox CssClass="textbox" ID="txtClicks" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfvClicks" runat="server" ErrorMessage="Require Clicks." ControlToValidate="txtClicks" ForeColor="Red">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="style5">
					Price
				</td>
				<td>
					:
				</td>
				<td>
					<asp:TextBox CssClass="textbox" ID="txtPrice" runat="server" 
                        AutoPostBack="True" ontextchanged="txtPrice_TextChanged"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Require Price." ControlToValidate="txtPrice" ForeColor="Red">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="style5">
				    Per Click</td>
				<td>
				    :</td>
				<td>
					<asp:TextBox CssClass="textbox" ID="txtPerClick" runat="server" Enabled="False"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
				</td>
				<td>
				</td>
				<td>
					<asp:Button ID="butSave" CssClass="button" runat="server" Text="Save" 
                        onclick="butSave_Click" Font-Names="Segoe UI" Font-Size="14px" />&nbsp;
					<asp:Button ID="butCancel" CssClass="button" runat="server" Text="Cancel" 
                        onclick="butCancel_Click"  CausesValidation="False" Font-Names="Segoe UI" 
                        Font-Size="14px" />
				</td>
			</tr>
		</table>
	</div>

	<div style="width:780px;">
        <asp:GridView ID="gvAdsPackage" runat="server" Width="100%" DataKeyNames="AdsPackageID"
		AutoGenerateColumns="False" CellPadding="4" ForeColor="#454545"
		GridLines="None" onrowcommand="gvAdsPackage_RowCommand"  AllowPaging="True" BorderStyle="Solid"
		BorderColor="#DDDDDD" BorderWidth="1px" 
            onpageindexchanging="gvAdsPackage_PageIndexChanging" Font-Names="Segoe UI" 
            Font-Size="14px">

		<AlternatingRowStyle BackColor="White" ForeColor="#454545" />
			<Columns>
				<asp:TemplateField HeaderText="Clicks">
					<ItemTemplate>
						<asp:Label ID="lblClicks" runat="server" Text='<%# Eval("Clicks")%>'></asp:Label>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Price">
					<ItemTemplate>
						<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Per Click">
                    <ItemTemplate>
                        <asp:Label ID="lblPerClick" runat="server" Text='<%# Eval("PerClick") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
				<asp:TemplateField HeaderText="Actions">
					<ItemTemplate>
						<asp:ImageButton ID="ibutSelect" runat="server" CommandName="DataSelect" ImageUrl="~/Images/edit.png" CommandArgument='<%# Bind("AdsPackageID") %>' CausesValidation="false"/>&nbsp;&nbsp;
						<asp:ImageButton ID="ibutDelete" runat="server" OnClientClick="return isDelete();" CommandName="DataDelete" ImageUrl="~/Images/delete.png" CommandArgument='<%# Bind("AdsPackageID") %>' CausesValidation="false"/>
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
			
		</asp:GridView>

	</div>
</fieldset>

    </div>
    </form>
</body>
</html>

</asp:Content>



