<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMemberAccountInfo.aspx.vb"
    Inherits="Register_step4" %>

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
            text-align: right;
            width: 40%;
        }
        .style3
        {
            font-weight: bold;
            color: #0000FF;
            width: 60%;
        }
        .style4
        {
            color: #0000FF;
        }
        .style5
        {
            float: right;
        }
        .style6
        {
            width: 25%;
            text-align: center;
            font-weight: bold;
        }
        .style7
        {
            font-size: small;
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
            <td class="style6">
                Welcome,<asp:Label ID="lblUserEmail" runat="server" Text=""></asp:Label>
            </td>
            <td class="style1">
                <b><a href="ViewMovies.aspx">Request Movies </a></b>
            </td>
            <td class="style6">
                Your Movie Queue
            </td>
            <td class="style6">
                <a href="frmMemberAccountInfo.aspx">Account Info</a>
            </td>
        </tr>
    </table>
    <div class="style5">
        <a href="../logout.aspx">Signout</a>
    </div>
    <br />
    <br />
    <h1>
        Account Info</h1>
    <hr style="width: 100%;" />
    <h2>
        Membership Details</h2>
    <p>
        Member Since :
        <asp:Label ID="lblMemberSince" runat="server" Text=""></asp:Label>
    </p>
    <h2>
        Particulars</h2>
    <table style="width: 100%;" align="center">
        <tr>
            <td class="style2">
                Email
            </td>
            <td class="style3">
                <div class="style4">
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Member Name
            </td>
            <td class="style3">
                <div class="style4">
                    <asp:Label ID="lblMemberName" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;Mailing Address
            </td>
            <td class="style3">
                <div class="style4">
                    <asp:Label ID="lblMailingAddress" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Telephone
            </td>
            <td class="style3">
                <div class="style4">
                    <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td class="style2">
                NRIC
            </td>
            <td class="style3">
                <div class="style4">
                    <asp:Label ID="lblNRIC" runat="server" Text=""></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td>
                <a href="frmEditParticulars.aspx">Edit Here
            </td>
        </tr>
    </table>
    <h2>
        Manage Account</h2>
    <hr style="width: 100%;" />
    <table style="width: 100%;" align="center">
        <tr>
            <td class="style2">
                Credit card Details
            </td>
            <td class="style3">
                <a href="frmEditCreditCardDetails.aspx">Edit here </a>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Password
            </td>
            <td class="style3">
                <a href="frmChangePassword.aspx">Change</a>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;Suspend
            </td>
            <td class="style3">
                <div class="style4">
                    <a href="SuspendAccount.aspx">Suspend</a><br />
                    <span class="style7">(ie going on vacation, too busy right now, etc) </span>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Cancel
            </td>
            <td class="style3">
                <div class="style4">
                    <a href="ViewMovies.aspx">Cancel</a></div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
