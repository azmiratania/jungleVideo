<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SuspendAccount.aspx.vb"
    Inherits="Member_SuspendAccount" %>

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
        .style2
        {
            text-align: center;
        }
        .style5
        {
            float: right;
        }
        .style6
        {
            text-align: center;
            font-size: x-large;
        }
        .style7
        {
            font-size: medium;
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
    <div>
        <table border="2" style="background-color: black; width: 100%; color: White;">
            <tr>
                <td class="style1">
                    <b>Welcome
                        <asp:Label ID="lblUserEmail" runat="server" Text=""></asp:Label></b>
                </td>
                <td class="style1">
                    <b>Request Movies</b>
                </td>
                <td class="style1">
                    <b>Your Movie Queue</b>
                </td>
                <td class="style1">
                    <b><a href="frmMemberAccountInfo.aspx">Account Info</a></b>
                </td>
            </tr>
        </table>
        <div class="style5">
            <a href="../logout.aspx">Signout</a></div>
    </div>
    <br />
    <br />
    <br />
    <h2>
        Suspend Account Confirmation</h2>
    <hr style="width: 90%;" />
    <br />
    <br />
    <br />
    <table style="width: 100%;" align="center">
        <tr>
            <td class="style6" colspan="2">
                Are you sure you wish you suspend your account with Jungle Video?<br />
                <span class="style7">By suspending your account, you will not be able to access you
                    member account. To reactivate your account, please contact the administrator.</span>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Button ID="btnSuspend" runat="server" Text="Suspend" Width="128px" BackColor="Blue"
                    Style="color: White;" />
            </td>
            <td class="style2">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="128px" BackColor="Blue"
                    Style="color: White;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
