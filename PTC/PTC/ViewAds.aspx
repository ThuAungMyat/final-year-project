<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAds.aspx.cs" Inherits="ViewAds" %>
<%--<%@ Register src="UserControls/NextPage.ascx" tagname="NextPage" tagprefix="uc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--    <uc1:NextPage ID="NextPage1" runat="server" />--%>

<asp:GridView ID="gvAds" runat="server" Width="100%" DataKeyNames="AdsID"
		AutoGenerateColumns="False" CellPadding="4" ForeColor="#454545"
		GridLines="None" AllowPaging="True" BorderStyle="Solid"
		BorderColor="#DDDDDD" BorderWidth="1px" 
        onpageindexchanging="gvAds_PageIndexChanging" 
        EmptyDataText="No Ads available to view!">

		<AlternatingRowStyle BackColor="White" ForeColor="#454545" />
			<Columns>
				<asp:TemplateField HeaderText="AdsName">
					<ItemTemplate>
                        &nbsp;
						<asp:Label ID="lblAdsName" runat="server" Text='<%# Eval("AdsName")%>'></asp:Label>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="AdsDescription">
					<ItemTemplate>
                        &nbsp;
						<asp:Label ID="lblAdsDescription" runat="server" Text='<%# Eval("AdsDescription")%>'></asp:Label>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="AdsURL">
					<ItemTemplate>
                        &nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "GetPaid.aspx?adsid=" + Eval("AdsID") + "&adsurl=" + Server.UrlEncode(Eval("AdsURL").ToString())%>' 
                            Text='<%# Eval("AdsURL") %>'></asp:HyperLink>
					</ItemTemplate>
					<ItemStyle  HorizontalAlign="Left"  />
				</asp:TemplateField>
			    <asp:TemplateField HeaderText="Per Click ">
                    <ItemTemplate>
                        <asp:Label ID="lblPerClick" runat="server" Text='<%# Eval("PerClick") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
			</Columns>
			<FooterStyle Font-Bold="True" ForeColor="#454545" CssClass="GridView_Footer"/>
			<HeaderStyle Font-Bold="True" ForeColor="#454545" CssClass="GridView_Header"/>
			<PagerStyle ForeColor="#454545" HorizontalAlign="Center" CssClass="GridView_Pager" />
			<RowStyle BackColor="#F9F9F9" ForeColor="#454545" CssClass="GridView_Row" />
			<SelectedRowStyle CssClass="GridView_Select" Font-Bold="True" ForeColor="#454545" />
		</asp:GridView>

</asp:Content>
