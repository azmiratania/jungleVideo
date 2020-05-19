<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .style1
        {
            width: 25%;
            text-align: center;
        }
    </style>
    
    
    
    <%--#### Javascript Validation ####--%>
    <%-----------------------------------------------------------------------------------------------------%>
    <%--The user enters a valid email format for the User Id textbox.--%>
    <%--The user enters a string(no space in password)for the Password textbox.--%>
    <%--The user will be prompted if either of the textbox is left empty.--%>
    
    <script language="javascript" type="text/javascript">

        function verifyEmail() {


            var objtxtEmail = document.getElementById("txtEmail");
            var objtxtPassword = document.getElementById("txtPassword");
            var objlblMessage = document.getElementById("lblMessage");
            objlblMessage.innerHTML = "";

            var email = new String();
            var password = new String();

            email = trimData(objtxtEmail.value);
            password = trimData(objtxtPassword.value);

           
            var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
            if ((email == "") || (password == "") || (email.search(emailRegEx) == -1)) {

                if (email == "") {
                    objlblMessage.innerHTML += "Email cannot be empty.<br/>";
                }

                if (password == "") {
                    objlblMessage.innerHTML += "Password cannot be empty.<br/>";
                }

                if (email.search(emailRegEx) == -1) {
                    objlblMessage.innerHTML += "Email format is incorrect.";
                }
                objtxtEmail.value = "";
                objtxtPassword.value = "";

                return false;
            } else {

                return true;
            }

        }


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
  
  <%--This is the code for the logo.--%>
  <%--This should be included on top of every form in the program.--%>
    <table border="2" style="background-color: black; width: 100%; color: White;">
        <tr>
            <td>
                <a href="login.aspx">
                <img alt="" src="img/head.png" width="787px" style="border-width: 0px" /></a>
            </td>
        </tr>
    </table>
    <%--####################################################################################################--%>
    
    
    
    <table border="2" style="background-color: black; width: 100%; color: White;">
        <tr>
            <td class="style1">
                <b><a href="login.aspx">Home</a></b>
            </td>
            <td class="style1">
                <a href="login.aspx"><b>Member Login</b></a>
            </td>
            <td class="style1">
                <a href="Register/step1.aspx"><b>Register</b> </a>
            </td>
            <td class="style1">
                <b><a href="#">Contact Us</a></b>
            </td>
        </tr>
    </table>
    <br />
         
    
    <%--This form contains all the server tags.--%>
    <form id="frmLogin" runat="server">
    <h2>
        Jungle Video Login
    </h2>
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
                </td>
            </tr>
            <tr>
                <td>
                    Password :
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="return verifyEmail();" />
                   
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <br />
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                    <hr />
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New to Jungle Video?</b><br />
                    <a href="Register/step1.aspx">
                        <img alt="" src="img/create.png" style="border-width: 0px" /></a><hr />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
