<%@ Page Language="VB" AutoEventWireup="false" CodeFile="step1.aspx.vb" Inherits="Register_step1" %>

<%--This web form allow the user to register using their email address.--%>
<%--asp.net controls used in this form--%>
<%--#############################################################--%>
<%--txtEmail--%>
<%--txtCreatePassword--%>
<%--txtConfirmPassword--%>
<%--lblErrorMessage--%>
<%--#############################################################--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Step 1</title>
    <style type="text/css">
        .style1
        {
            width: 25%;
            text-align: center;
        }
        .style6
        {
            color: #6600CC;
            font-size: x-small;
        }
    </style>

    <script language="javascript" type="text/javascript">

        function verify() {

            var email = trimData(document.getElementById("txtEmail").value);
            var pass1 = trimData(document.getElementById("txtCreatePassword").value);
            var pass2 = trimData(document.getElementById("txtConfirmPassword").value);
            var objlblMessage = document.getElementById("lblErrorMessage");

            objlblMessage.innerHTML = "";

            var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
            if ((email == "") || (pass1 == "") || (pass2 == "") || (email.search(emailRegEx) == -1) || (pass1 != pass2) || (pass1.length < 4) || (pass1.length > 12)) {

                if (email.search(emailRegEx) == -1) {
                    objlblMessage.innerHTML += "Email format is incorrect.<br/>";
                }

                if (email == "") {
                    objlblMessage.innerHTML += "Email cannot be empty.<br/>";
                }

                if (pass1 == "") {
                    objlblMessage.innerHTML += "Create password cannot be empty.<br/>";
                }

                if (pass2 == "") {
                    objlblMessage.innerHTML += "Confirm password cannot be empty.<br/>";
                }

                if (pass1 != pass2) {
                    objlblMessage.innerHTML += "Passwords do not match.<br/>";
                }

                if ((pass1.length < 4) || (pass1.length > 12)) {
                    objlblMessage.innerHTML += "Password must be 4 to 12 characters long.<br/>";
                }





                document.getElementById("txtEmail").value = "";
                document.getElementById("txtCreatePassword").value = "";
                document.getElementById("txtConfirmPassword").value = "";




                return false;

            } else {

                document.getElementById("txtEmail").value = email;
                document.getElementById("txtCreatePassword").value = pass1;
                document.getElementById("txtConfirmPassword").value = pass2;

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
    <%-- This is the code for the header which is standard across all forms.--%>
    <div>
        <table border="2" style="background-color: black; width: 100%; color: White;">
            <tr>
                <td>
                    <a href="../login.aspx">
                        <img alt="" src="../img/head.png" width="787px" style="border-width: 0px" /></a>
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
        <br />
        <%--  Do not include the header table inside the form.--%>
        <form id="frmStep1" runat="server">
        <br />
        <br />
        <h4>
            Registration - Create Email/Password</h4>
        <hr style="width: 100%;" />
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        Email :
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <br />
                        <span class="style6">eg. yourname@hotmail.com</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        Create Password :
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreatePassword" TextMode="password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm Password :
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" TextMode="password" runat="server"></asp:TextBox>
                        <br />
                        <span class="style6">(4 to 12 characters only) </span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <br />
                        <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClientClick="return verify();" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <br />
                        <hr />
                        <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>
</body>
</html>
