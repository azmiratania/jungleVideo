<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewMovies.aspx.vb" Inherits="Member_Functions_ViewMovies" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 25%;
            text-align: center;
        }
        #content
        {
            width: 70%;
            padding: 10px 10px 10px 10px;
            vertical-align: top;
        }
        #sidebar
        {
            width: 30%;
            padding: 10px 5px 10px 5px;
            vertical-align: top;
        }
        .style3
        {
            text-align: center;
            font-size: xx-small;
        }
        .style4
        {
            font-size: x-small;
        }
        .movie
        {
            width: 25%;
            text-align: center;
        }
    </style>
</head>
<body style="width: 60%; border: 2px solid; margin: 0 auto; padding: 40px 20px 40px 20px;">
    <table border="2" style="background-color: black; width: 100%; color: White;">
        <tr>
            <td>
                <img alt="" src="../img/head.png" width="787px" />
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
    <table border="2" style="background-color: black; width: 100%; color: White;">
        <tr>
            <td class="style1">
                <b>Welcome
                    <asp:Label ID="lblUserEmail" runat="server" Text=""></asp:Label></b>
            </td>
            <td class="style1">
                <b><a href="ViewMovies.aspx">Request Movies </a></b>
            </td>
            <td class="style1">
                <b>Your Movie Queue</b>
            </td>
            <td class="style1">
                <b><a href="frmMemberAccountInfo.aspx">Account Info</a></b>
            </td>
        </tr>
    </table>
    <div style="float: right;">
        <a href="../logout.aspx">Signout</a></div>
    <asp:Label ID="lblCurrentCategory" runat="server" Text=""></asp:Label>
    <hr />
    <table style="width: 100%;">
        <tr>
            <td id="content">
                <div id="displayMovies" runat="server">
                </div>
            </td>
            <%-- end tag for #content --%>
            <td id="sidebar">
                <div>
                    <form action="#">
                    <table>
                        <tr>
                            <td>
                                Search
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox><br />
                            </td>
                            <td>
                                <asp:Button ID="btnGo" runat="server" Text="Go" />
                            </td>
                        </tr>
                    </table>
                    <div class="style3">
                        <span class="style4">Search By Title,Actor,Director.</span>
                    </div>
                    </form>
                </div>
                <br />
                <br />
                <asp:Label ID="lblSearchCategory" runat="server" Text="Label"></asp:Label>
            </td>
            <%-- end tag for #sidebar --%>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ajaxControl:AutoCompleteExtender runat="server" ID="acMemberFullName" TargetControlID="txtSearch"
        ServiceMethod="getCategoryList" ServicePath="../AutoCompleteWebServices.asmx"
        CompletionSetCount="1">
    </ajaxControl:AutoCompleteExtender>
    </form>
</body>
</html>
