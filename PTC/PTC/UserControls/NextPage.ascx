﻿    <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NextPage.ascx.cs" Inherits="PTC.NextPage" %>
<script language="javascript" type="text/javascript">
    //If this window name not equal to sessions,will be goto InvalidPage
    if (window.name != "<%=GetWindowName()%>") {
        window.name = "InvalidPage";
        window.open("InvalidPage.aspx","_self");      
    }
</script>
