<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetPaid.aspx.cs" Inherits="GetPaid" %>

<%@ Register src="UserControls/NextPage.ascx" tagname="NextPage" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
   
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="head" runat="server">
    <link href="App_Themes/Template/css.css" rel="stylesheet" type="text/css" />
    <title></title>
        <script type="text/javascript" src="Scripts/jquery.min.js">
        </script>
        <script src="Scripts/jquery.countdown.js" type="text/javascript"></script>
                
        <script type="text/javascript">
            $(function () {

                $('#counter').countdown({
                    image: 'digits.png',
                    startTime: '30'
                });

                $('#counter_2').countdown({
                    startTime: '30',
                    format: 'ss',
                    digitImages: 6,
                    digitWidth: 53,
                    digitHeight: 77,
                    //  timerEnd: function() { alert('end!'); },
                    image: 'digits.png'
                });
            });
    </script>

        <style type="text/css">
      br { clear: both; }
      .cntSeparator {
        font-size: 54px;
        margin: 10px 7px;
        color: #000;
      }
      .desc { margin: 7px 3px; }
      .desc div {
        float: left;
        font-family: Arial;
        width: 70px;
        margin-right: 65px;
        font-size: 13px;
        font-weight: bold;
        color: #000;
      }
    </style>
</head>

<body id="body" runat="server">
    <form id="form1" runat="server">
    <uc1:NextPage ID="NextPage1" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
    <div class="navbar navbar-fixed-top">
    <div class="navbar-header"></div>
    <div class="navbar-inner">
        <div class="container">
                <table>
            <tr>
                <td>
                <div id="counter"></div>
            <div class="desc">
            <div>Seconds</div>
                </div>
                </td>
                <td>
                 <div>
     <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="30000">
     </asp:Timer>                      
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
           <ContentTemplate>          
           <asp:Panel ID="Panel1" runat="server">
           <table>
                <caption>
                    <IMG style="WIDTH: 178px; HEIGHT: 51px" alt="" src=Captcha.aspx />
                    <br />
                    <br />
                    <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SUBMIT" />
                    <br />
                </caption>
              </table>
              </asp:Panel>
           </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
               </Triggers>
     </asp:UpdatePanel>
 </div>
                </td>
            </tr>
        </table>
          
           
        </div>
     </div>
    </div>
    <div>
		<div style="Height:700px;">
				<div><iframe id="frame" runat="server" width="100%" height="1000px"></iframe></div>
		</div>
    </div>
    </form>
</body>
</html>
