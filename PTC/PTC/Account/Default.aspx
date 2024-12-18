<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <div style="border:0px solid #e5ebf4;height:30px;-moz-border-radius:5px 5px 0 0;">

    </div>
    <div style="margin:-27px 0px 0px 0px;position:absolute;color:#474747;font-weight:bold;font-size:14pt;color:#777777;">
	    Administration
    </div>
    <hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;"/>
    <asp:Panel ID="PanelAdmin" runat="server">
        <fieldset id="Admin"  style="border:4px solid #F1F1F1;margin-bottom:10px;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;">
	        <legend><b>Actions for Administrators</b></legend>
	        <div style="margin-left:30px;">
                <br />
                <ul  style="list-style-type: square">
                    <li>
                        <asp:HyperLink ID="ManageUsers" CssClass="hyperlink" NavigateUrl="~/Account/ManageUsers.aspx" runat="server">Manage Users:</asp:HyperLink> search for users by username or e-mail address, read and modify thier profile, roles, and approved status.
                    </li>
                    <br />
                    <li>
                        <asp:HyperLink ID="HyperLink5" CssClass="hyperlink" NavigateUrl="~/Account/Register.aspx" runat="server">Register Users:</asp:HyperLink> search for users by username or e-mail address, read and modify thier profile, roles, and approved status.
                    </li>
                </ul>
            </div>
        </fieldset>
    </asp:Panel>
    
    <fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;">
	    <legend><b>Actions for Members</b></legend>
	    <div style="margin-left:30px;">
            <br />
            <ul  style="list-style-type: square">
                <li>
                    <asp:HyperLink ID="HyperLink2" CssClass="hyperlink" NavigateUrl="~/Membership/ManageAllAlbums.aspx" runat="server">Manage Albums:</asp:HyperLink> search for users by username or e-mail address, read and modify thier profile, roles, and approved status.
                </li>
            </ul>
            <br />
             <ul  style="list-style-type: square">
                <li>
                    <asp:HyperLink ID="HyperLink1" CssClass="hyperlink" NavigateUrl="~/Membership/ManageAllPoems.aspx" runat="server">Manage Poems:</asp:HyperLink> search for users by username or e-mail address, read and modify thier profile, roles, and approved status.
                </li>
            </ul>
            <br />
            <ul  style="list-style-type: square">
                <li>
                    <asp:HyperLink ID="HyperLink3" CssClass="hyperlink" NavigateUrl="~/Membership/ManageAllPoems.aspx" runat="server">Manage Musics:</asp:HyperLink> search for users by username or e-mail address, read and modify thier profile, roles, and approved status.
                </li>
            </ul>
            <br />
            <ul  style="list-style-type: square">
                <li>
                    <asp:HyperLink ID="HyperLink4" CssClass="hyperlink" NavigateUrl="~/Membership/ManageAllMovies.aspx" runat="server">Manage Movies:</asp:HyperLink> search for users by username or e-mail address, read and modify thier profile, roles, and approved status.
                </li>
            </ul>
        </div>
    </fieldset>
   
</div>
</asp:Content>

