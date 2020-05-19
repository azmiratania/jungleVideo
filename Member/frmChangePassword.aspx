<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmChangePassword.aspx.vb"
    Inherits="Member_frmChangePassword" %>

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
        .style5
        {
            float: right;
        }
    </style>

    <script language="javascript" type="text/javascript">

        function verify() {

            var pass1 = trimData(document.getElementById("txtCurrentPassword").value);
            var pass2 = trimData(document.getElementById("txtNewPassword").value);
            var pass3 = trimData(document.getElementById("txtConfirmPassword").value);
            
            
            var objlblMessage = document.getElementById("lblErrorMessage");

            objlblMessage.innerHTML = "";


            if ((pass1 == "") || (pass2 == "") || (pass3 == "") || (pass2 != pass3) || (pass2.length < 4) || (pass2.length > 12)) {


                if (pass1 == "") {
                    objlblMessage.innerHTML += "Current password cannot be empty.<br/>";
                }

                if (pass2 == "") {
                    objlblMessage.innerHTML += "New Password cannot be empty.<br/>";
                }

                if (pass3 == "") {
                    objlblMessage.innerHTML += "Confirm Password cannot be empty.<br/>";
                }

                if (pass2 != pass3) {
                    objlblMessage.innerHTML += "Passwords do not match.<br/>";
                }

                if ((pass2.length < 4) || (pass2.length > 12)) {
                    objlblMessage.innerHTML += "Password must be 4 to 12 characters long.<br/>";
                }

                return false;

            } else {

                return true;
            }

        } //end of function verify




        function trimData(pstrData) {
            str = pstrData.replace(/^\s+/, '');
            for (var i = str.length - 1; i >= 0; i--) {
                if (/\S/.test(str.charAt(i))) {
                    str = str.substring(0, i + 1);
                    break;
                }
            }
            return str;
        }

        
    </script>

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
        Edit Password</h2>
    <p>
        To change your password, provide your current password.</p>
    <hr style="width: 90%;" />
    <br />
    <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <table style="width: 100%;" align="center">
        <tr>
            <td class="style2">
                Current Password
            </td>
            <td>
                <asp:TextBox ID="txtCurrentPassword" TextMode="password" runat="server"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                New Password
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" TextMode="password" runat="server"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                Confirm Password
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" TextMode="password" runat="server"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            </td>
            <td>
                <br />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="128px" BackColor="Blue"
                    OnClientClick="return verify();" Style="color: White;" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="128px" BackColor="Blue"
                    Style="color: White;" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
