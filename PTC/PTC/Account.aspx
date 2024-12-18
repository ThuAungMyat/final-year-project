<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            width: 7px;
        }
        .style5
        {
            font-family: "Segoe UI";
        }
        .style7
        {
            width: 122px;
            font-family: "Segoe UI";
            text-align: right;
            font-size: 14px;
        }
        .style11
        {
            width: 9px;
        }
        .style13
        {
            font-family: "Segoe UI";
            font-size: 14px;
        }
        .style14
        {
            width: 123px;
            text-align: right;
            font-size: 14px;
        }
        .style15
        {
            font-family: "Segoe UI";
            text-align: right;
            font-size: 14px;
        }
        .style16
        {
            width: 183px;
        }
        .style17
        {
            width: 195px;
        }
    </style>    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

  <script type="text/javascript">
      function toggleVisibility(controlId) 
      {
          var control = document.getElementById(controlId);
          if (control.style.visibility == "visible" || control.style.visibility == "")
              control.style.visibility = "hidden";
          else
              control.style.visibility = "visible";
      }
</script>

<div style="border:0px solid #e5ebf4;height:30px;-moz-border-radius:5px 5px 0 0;">

    
</div>
<div style="margin:-27px 0px 0px 0px;position:absolute;color:#474747;font-weight:bold;font-size:14pt;color:#777777;">
    <div class=".navbar-inner" style="width: 836px">
	    <table id="topMenu" cellpadding="0" cellspacing="0" style="width: 800px">
        
        </table>
    </div>

    <div class="navbar-inner">
         <tbody>
        <tr>
        <td class="style16">
            <asp:LinkButton ID="lbtnAccount" runat="server" CssClass="hyperlinkmenu" 
                onclick="lbtnAccount_Click" Width="100px" Font-Size="15px" 
              ForeColor="White" Font-Names="Segoe UI" Font-Bold="False"><span class="down">Account</span></asp:LinkButton>
        </td>
        <td class="style17">
            <asp:LinkButton ID="lbtnStats" runat="server" CssClass="hyperlinkmenu" 
                onclick="lbtnStats_Click" Width="100px" Font-Size="15px" 
              ForeColor="White" Font-Names="Segoe UI" Font-Bold="False"><span class="down">Stats</span></asp:LinkButton>
        </td>
        <td class="top">
        <asp:HyperLink ID="hlEarningArea" CssClass="hyperlinkmenu" runat="server" 
                NavigateUrl="~/ViewAds.aspx" Width="100px" Font-Size="15px" 
              ForeColor="White" Font-Names="Segoe UI" Font-Bold="False"><span class="down">Earning Area</span></asp:HyperLink>
        </td>
        <td class="top">

        </td>


        </tr>
        </tbody>
               
        </div>
        </div>


<fieldset  style="border:4px solid #F1F1F1;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;width:800px;">
	<legend class="style5"><b style="font-size:10pt;color:#777777;">Your Account 
        Information </b></legend>
	<div>
		<table>

			<tr>
				<td>
                    &nbsp;</td>
				<td>
                    <asp:Panel ID="AccountInfo" runat="server">
                        <asp:FormView ID="fvUserImage" runat="server" borderstyle="none" 
                        borderwidth="0" CellPadding="0" cellspacing="0" EnableViewState="false" 
                        Width="200px">
                            <itemtemplate>
                                <table border="0" cellpadding="0" cellspacing="0" width="300px">
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" 
                                            ImageUrl='<%# "~/AlbumAndPhotosHandler.ashx?UserID="+ Eval("UserID") %>' 
                                            style="border:4px solid white;width:60px;height:60px" />
                                        </td>
                                    </tr>
                                </table>
                            </itemtemplate>
                        </asp:FormView>
                        <table style="width:100%;">
                            <tr>
                                <td class="style7">
                                    User Name
                                </td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" Width="180px" 
                                        Enabled="False" Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    IP Address</td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtIP" runat="server" CssClass="textbox" Width="180px" 
                                        Enabled="False" Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    <span class="style5">Gender </span>
                                </td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtGender" runat="server" CssClass="textbox" Width="180px" 
                                        Enabled="False" EnableTheming="True" Font-Names="Segoe UI" 
                                        Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Date Of Birth
                                </td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="textbox" 
                                        Width="180px" Enabled="False" Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Current Email
                                </td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="180px" 
                                        Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    New Email:</td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtNewEmail" runat="server" CssClass="textbox" Width="180px" 
                                        Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Password
                                </td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" 
                                        TextMode="Password" Width="180px" Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Paypal Email
                                </td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtPaypalEmail" runat="server" CssClass="textbox" 
                                        Width="180px" Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Password Question
                                </td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtPasswordQuestion" runat="server" CssClass="textbox" 
                                        TextMode="MultiLine" Width="180px" Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Password Answer</td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtPasswordAnswer" runat="server" CssClass="textbox" 
                                        TextMode="MultiLine" Width="180px" Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Phone
                                </td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox" Width="180px" 
                                        Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Address</td>
                                <td class="style4">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" 
                                        TextMode="MultiLine" Width="180px" Font-Names="Segoe UI" Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </asp:Panel>
                </td>
			</tr>
			<tr>
				<td>
					&nbsp;</td>
				<td>
					<asp:Panel ID="Stats" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td class="style13" colspan="3">
                                    Cash Balance Stats</td>
                            </tr>
                            <tr>
                                <td class="style15">
                                    Balance</td>
                                <td class="style11">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtBalance" runat="server" style="text-align:right;" 
                                        CssClass="textbox" Width="180px" Enabled="False" Font-Names="Segoe UI" 
                                        Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    <span class="style5">Ads Clicked</span>
                                </td>
                                <td class="style11">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtAdsClicked" runat="server" style="text-align:right;" 
                                        CssClass="textbox" Width="180px" Enabled="False" Font-Names="Segoe UI" 
                                        Font-Size="14px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    Pending Withdrawls</td>
                                <td class="style11">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtPendingWithdrawl" runat="server" style="text-align:right;" CssClass="textbox" 
                                        Enabled="False" Font-Names="Segoe UI" Width="180px" Font-Size="14px">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    &nbsp;Payments Received</td>
                                <td class="style11">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtPaymentsReceived" runat="server" style="text-align:right;" CssClass="textbox" 
                                        Enabled="False" Font-Names="Segoe UI" Width="180px" Font-Size="14px">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    Payments Cancelled</td>
                                <td class="style11">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtPaymentsCancelled" runat="server" style="text-align:right;" CssClass="textbox" 
                                        Enabled="False" Font-Names="Segoe UI" Width="180px" Font-Size="14px">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    &nbsp;</td>
                                <td class="style11">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
				</td>
			</tr>
			
		</table>
	</div>

</fieldset>

</asp:Content>
