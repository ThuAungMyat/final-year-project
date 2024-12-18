<%@ Page Title="Ads" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Ads.aspx.cs" Inherits="Ads" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <style type="text/css">
        .style2
        {
            font-family: "Segoe UI";
        }
        .style3
        {
            font-family: "Segoe UI";
            font-size: 14px;
        }
        .style4
        {
            font-size: 15px;
        }
        .style5
        {
            font-family: "Segoe UI";
            font-size: 20px;
        }
    </style>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title> Ads </title>
</head>
<body>
    <form>
    <div>
    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");
        }
</script>

<div style="border:0px solid #e5ebf4;height:30px;-moz-border-radius:5px 5px 0 0;">

</div>
<div style="margin:-27px 0px 0px 0px;position:absolute;color:#474747;font-weight:bold;font-size:14pt;color:#777777;">
	<span class="style5">Ads</span>
</div>
<hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;"/>

<fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;width:800px;">
	<legend class="style2"><b style="color:#777777;" class="style4">Ads</b></legend>
	<div>
	<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
            Font-Names="Segoe UI" Font-Size="14px" />
		<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" 
            Font-Names="Segoe UI" Font-Size="14px"></asp:Label>
		<table>
			<tr>
				<td class="style3">
					Ads Package
				</td>
				<td>
					:
				</td>
				<td>
					<asp:DropDownList ID="ddlAdsPackage" runat="server" Width="180px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlAdsPackage_SelectedIndexChanged" 
                        Font-Names="Segoe UI" Font-Size="14px"></asp:DropDownList>
					<asp:RequiredFieldValidator ID="rfvAdsPackage" runat="server" ErrorMessage="Require AdsPackage." ControlToValidate="ddlAdsPackage" ForeColor="Red">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="style3">
					Ads Name
				</td>
				<td>
					:
				</td>
				<td>
					<asp:TextBox CssClass="textbox" ID="txtAdsName" runat="server" 
                        Font-Names="Segoe UI" Font-Size="14px" Width="180px"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfvAdsName" runat="server" ErrorMessage="Require AdsName." ControlToValidate="txtAdsName" ForeColor="Red">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<span class="style3">Ads Description</span>
				</td>
				<td>
					:
				</td>
				<td>
					<asp:TextBox CssClass="textbox" ID="txtAdsDescription" runat="server" 
                        Font-Names="Segoe UI" Font-Size="14px" Width="180px"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfvAdsDescription" runat="server" ErrorMessage="Require AdsDescription." ControlToValidate="txtAdsDescription" ForeColor="Red">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="style3">
					AdsURL
				</td>
				<td>
					:
				</td>
				<td>
					<asp:TextBox CssClass="textbox" ID="txtAdsURL" runat="server" 
                        Font-Names="Segoe UI" Font-Size="14px" Width="180px">http://www.</asp:TextBox>
					<asp:RequiredFieldValidator ID="rfvAdsURL" runat="server" ErrorMessage="Require AdsURL." ControlToValidate="txtAdsURL" ForeColor="Red">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="style3">
					Ads Clicks Left
				</td>
				<td>
					:
				</td>
				<td>
					<asp:TextBox CssClass="textbox" ID="txtAdsClicksLeft" runat="server" 
                        Enabled="False" Font-Names="Segoe UI" Font-Size="14px" Width="180px"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfvAdsClicksLeft" runat="server" ErrorMessage="Require AdsClicksLeft." ControlToValidate="txtAdsClicksLeft" ForeColor="Red">*</asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
				</td>
				<td>
				</td>
				<td>
					<asp:Button ID="butSave" CssClass="button" runat="server" Text="Save" 
                        onclick="butSave_Click" Font-Names="Segoe UI" Font-Size="15px" />&nbsp;
					<asp:Button ID="butCancel" CssClass="button" runat="server" Text="Cancel" 
                        onclick="butCancel_Click"  CausesValidation="False" Font-Names="Segoe UI" 
                        Font-Size="15px" />
				</td>
			</tr>
		</table>
	</div>

	<div style="width:780px;">
		<asp:GridView ID="gvAds" runat="server" Width="100%" DataKeyNames="AdsID"
		AutoGenerateColumns="False" CellPadding="4" ForeColor="#454545"
		GridLines="None" onrowcommand="gvAds_RowCommand"  AllowPaging="True" BorderStyle="Solid"
		BorderColor="#DDDDDD" BorderWidth="1px" 
            onpageindexchanging="gvAds_PageIndexChanging" Font-Names="Segoe UI" 
            Font-Size="14px">

		<AlternatingRowStyle BackColor="White" ForeColor="#454545" />
			<Columns>
				<asp:TemplateField HeaderText="Ads Package">
					<ItemTemplate>
                        &nbsp;&nbsp;
						<asp:Label ID="lblAdsPackage" runat="server" Text='<%# Eval("Clicks") %>'></asp:Label>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Ads Name">
					<ItemTemplate>
                        &nbsp;
						<asp:Label ID="lblAdsName" runat="server" Text='<%# Eval("AdsName")%>'></asp:Label>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Ads Description">
					<ItemTemplate>
                        &nbsp;
						<asp:Label ID="lblAdsDescription" runat="server" Text='<%# Eval("AdsDescription")%>'></asp:Label>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Ads URL">
					<ItemTemplate>
                        &nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("AdsURL") %>'
                            Text='<%# Eval("AdsURL") %>'></asp:HyperLink>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Ads Clicks Left">
					<ItemTemplate>
                        &nbsp;
						<asp:Label ID="lblAdsClicksLeft" runat="server" Text='<%# Eval("AdsClicksLeft")%>'></asp:Label>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Actions">
					<ItemTemplate>
						<asp:ImageButton ID="ibutSelect" runat="server" CommandName="DataSelect" ImageUrl="~/Images/edit.png" CommandArgument='<%# Bind("AdsID") %>' CausesValidation="false"/>&nbsp;&nbsp;
						<asp:ImageButton ID="ibutDelete" runat="server" OnClientClick="return isDelete();" CommandName="DataDelete" ImageUrl="~/Images/delete.png" CommandArgument='<%# Bind("AdsID") %>' CausesValidation="false"/>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
			</Columns>
			<FooterStyle Font-Bold="True" ForeColor="#454545" CssClass="GridView_Footer"/>
			<HeaderStyle Font-Bold="True" ForeColor="#454545" CssClass="GridView_Header"/>
			<PagerStyle ForeColor="#454545" HorizontalAlign="Center" CssClass="GridView_Pager" />
			<RowStyle BackColor="#F9F9F9" ForeColor="#454545" CssClass="GridView_Row" />
			<SelectedRowStyle CssClass="GridView_Select" Font-Bold="True" ForeColor="#454545" />
		</asp:GridView>

	</div>
</fieldset>

    </div>
    </form>
</body>
</html>

</asp:Content>



