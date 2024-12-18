<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Account_ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script type="text/javascript">
    function isDelete() {
        return confirm("Do you want to delete this User?");
    }

    function ShowProcessImage() {
        var autocomplete = document.getElementById('txtSearchText');
        autocomplete.style.backgroundImage = 'url(~/AutoCompleteLoading.gif)';
        autocomplete.style.backgroundRepeat = 'no-repeat';
        autocomplete.style.backgroundPosition = 'right';
    }

    function HideProcessImage() {
        var autocomplete = document.getElementById('txtSearchText');
     autocomplete.style.backgroundImage  ='none';
     }
</script>

<div style="border:0px solid #e5ebf4;height:30px;-moz-border-radius:5px 5px 0 0;">

</div>
<div style="margin:-27px 0px 0px 0px;position:absolute;color:#474747;font-weight:700; font-size:14pt;color:#777777;">
	Account Management
</div>
<hr style="border:1px solid #F1F1F1;margin:-3px 0px 9px 0px;"/>

<fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;">
	<legend><b>Manage Users Account</b></legend>
	<div>
        <br />
        Total Users : <b><asp:Label ID="lblTotalUsers" runat="server" Text=""></asp:Label></b>
        <br />
        Online Users : <b><asp:Label ID="lblOnlineUsers" runat="server" Text=""></asp:Label></b>
        <br />
        Current User Name : <b><asp:Label ID="lblCurrentUser" runat="server" Text=""></asp:Label></b>
        <br /><br />
        <asp:Repeater runat="server" ID="rptAlphabet" 
            onitemcommand="rptAlphabet_ItemCommand" >
            <ItemTemplate><b><asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Container.DataItem %>'
                CommandArgument='<%# Container.DataItem %>' /></b>&nbsp;&nbsp;
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <br />
        <asp:DropDownList runat="server" ID="ddlSearchTypes" CssClass="dropdownlist">
            <asp:ListItem Text="UserName" Selected="true" />
            <asp:ListItem Text="E-mail" />
        </asp:DropDownList> 
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        contains 
        <asp:AutoCompleteExtender runat="server" ID="autoComplete1" BehaviorID="AutoCompleteEx" TargetControlID="txtSearchText" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetUserNames"
                MinimumPrefixLength="1" CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" 
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
                DelimiterCharacters=";, :" ShowOnlyCurrentWordInCompletionListItem="true">  
                <Animations>
                    <OnShow>
                        <Sequence>
                            <%-- Make the completion list transparent and then show it --%>
                            <OpacityAction Opacity="0" />
                            <HideAction Visible="true" />
                            
                            <%--Cache the original size of the completion list the first time
                                the animation is played and then set it to zero --%>
                            <ScriptAction Script="
                                // Cache the size and setup the initial size
                                var behavior = $find('AutoCompleteEx');
                                if (!behavior._height) {
                                    var target = behavior.get_completionList();
                                    behavior._height = target.offsetHeight - 2;
                                    target.style.height = '0px';
                                }" />
                            
                            <%-- Expand from 0px to the appropriate size while fading in --%>
                            <Parallel Duration=".4">
                                <FadeIn />
                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                            </Parallel>
                        </Sequence>
                    </OnShow>
                    <OnHide>
                        <%-- Collapse down to 0px and fade out --%>
                        <Parallel Duration=".4">
                            <FadeOut />
                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                        </Parallel>
                    </OnHide>
                </Animations>             
            </asp:AutoCompleteExtender>
        <asp:TextBox runat="server" ID="txtSearchText" CssClass="textbox" />
        <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="button" 
            onclick="btnSearch_Click"/>
        <br /><br />
    </div>
    <div style="width:100%;">
		<asp:GridView ID="gvUsers" runat="server" Width="100%" DataKeyNames="UserName"
		AutoGenerateColumns="False" CellPadding="4" ForeColor="#454545"  PageSize="10"
		GridLines="None"  AllowPaging="true" BorderStyle="Solid" ShowFooter="true"
		BorderColor="#dddddd" BorderWidth="1px" onrowdeleting="gvUsers_RowDeleting" 
            onrowdatabound="gvUsers_RowDataBound" 
            onpageindexchanging="gvUsers_PageIndexChanging" >

		<AlternatingRowStyle BackColor="White" ForeColor="#454545" />
			<Columns>
				<asp:TemplateField HeaderText="User Name">
					<ItemTemplate>
						<asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName")%>'></asp:Label>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Email">
					<ItemTemplate>
                        <asp:HyperLink runat="server" Text='<%# Eval("Email")%>' DataNavigateUrlFormatString="mailto:{0}" DataNavigateUrlFields="Email"></asp:HyperLink>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Created Date">
					<ItemTemplate>
						<asp:Label ID="lblCreationDate" runat="server" Text='<%# Eval("CreationDate")%>' DataFormatString="{0:MM/dd/yy h:mm tt}"></asp:Label>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
                <asp:TemplateField HeaderText="Last activity">
					<ItemTemplate>
						<asp:Label ID="lblLastActivity" runat="server" Text='<%# Eval("LastActivityDate")%>' DataFormatString="{0:MM/dd/yy h:mm tt}"></asp:Label>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
                <asp:CheckBoxField HeaderText="Approved" DataField="IsApproved" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
				<asp:TemplateField HeaderText="User Image">
					<ItemTemplate>
						<asp:Image ID="UsersImages" runat="server" ImageUrl='<%# "~/AlbumAndPhotosHandler.ashx?UserName="+ Eval("UserName") %>' class="photo_198" style="border:4px solid white;width:50px;height:50px;"/>
					</ItemTemplate>
					<ItemStyle Width=""  HorizontalAlign="Left"  />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Actions">
					<ItemTemplate>
						<asp:ImageButton ID="ibutSelect" runat="server" PostBackUrl='<%# "EditUser.aspx?UserName="+ Eval("UserName") %>' CommandName="DataSelect" ImageUrl="~/Images/edit.png" CommandArgument='<%# Bind("UserName") %>' CausesValidation="false"/>&nbsp;&nbsp;
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

