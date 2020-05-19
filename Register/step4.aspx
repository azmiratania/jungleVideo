<%@ Page Language="VB" AutoEventWireup="false" CodeFile="step4.aspx.vb" Inherits="Register_step4" %>

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
    <table border="2" style="background-color: black; width: 100%; color: White;">
        <tr>
            <td class="style1">
                <a href="../Member/ViewMovies.aspx"><b>Home</b> </a>
            </td>
            <td class="style1">
                <a href="../login.aspx"><b>Member Login</b>
            </td>
            <td class="style1">
                <a href="step1.aspx"><b>Register</b> </a>
            </td>
            <td class="style1">
                <a href="#"><b>Contact Us</b> </a>
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
    
    <br />
    <asp:Label ID="lblRegisrationDone" runat="server" Text=""></asp:Label>
    <br />
    <h2>
        Particulars</h2>
    <hr style="width: 100%;" />
    <div id="divInstruction" runat="server">
        Please look over your details carefully,especially the mailing address.
        <br />
        <br />
        If you&#39;d like to make any correction,please click edit.Otherwise,clcik the Start
        Membership button.</div>
    <br />
    <br />
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
            </td>
            <td>
                <a href="step2.aspx">Edit Particulars
            </td>
        </tr>
    </table>
    <h2>
        Credit Card Details</h2>
    <hr style="width: 100%;" />
    <table style="width: 100%;" align="center">
        <tr>
            <td class="style2">
                Cardholder&#39;s Name
            </td>
            <td class="style3">
                <div class="style4">
                    <asp:Label ID="lblCardHolderName" runat="server" Text=""></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Credit Card Type
            </td>
            <td class="style3">
                MasterCard
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;Credit Card Number
            </td>
            <td class="style3">
                <div class="style4">
                    <asp:Label ID="lblCardNumber" runat="server" Text=""></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Expiration Date
            </td>
            <td class="style3">
                <div class="style4">
                    <asp:Label ID="lblExpirationDate" runat="server" Text=""></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td>
                <a href="step3.aspx">Edit Credit Card Details</a>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                <br />
                <asp:Button ID="btnStartMembership" runat="server" Text="Start Membership" Width="145px"
                    BackColor="Blue" ForeColor="White" />
                <br />
                <br />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
