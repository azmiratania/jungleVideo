<%@ Page Language="VB" AutoEventWireup="false" CodeFile="step3.aspx.vb" Inherits="Register_step3" %>

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

    <script language="javascript" type="text/javascript">

        function verify() {

            var holderName = trimData(document.getElementById("txtHolderName").value);
            var cardNo = trimData(document.getElementById("txtCardNo").value);

            var objlblMessage = document.getElementById("lblErrorMessage");

            objlblMessage.innerHTML = "";


            if ((holderName == "") || (cardNo == "")) {


                if (holderName == "") {
                    objlblMessage.innerHTML += "Card Holder's Name cannot be empty.<br/>";
                }

                if (cardNo == "") {
                    objlblMessage.innerHTML += "Credit Card Number cannot be empty.<br/>";
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
    <form id="form1" runat="server">
    <div>
    
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
        
        <div class="style5">
            <a href="../login.aspx">Member Login</a>
        </div>
        <br />
        <br />
        <br />
          <h4>Registration - Credit Card Details</h4>
        <hr style="width: 100%;" />
        <br />
        
        <br />
        <br />
        <table style="width: 100%;" align="center">
            <tr>
                <td class="style2">
                    Card Holder&#39;s Name
                </td>
                <td>
                    <asp:TextBox ID="txtHolderName" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Credit Card Type
                </td>
                <td>
                    <img alt="" src="../img/mcard.gif" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Credit Card Number
                </td>
                <td>
                    <asp:TextBox ID="txtCardNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Expiration Date
                </td>
                <td>
                    <asp:DropDownList ID="lstMonth" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="lstYear" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td>
                    <br />
                    <asp:Button ID="btnContinue" runat="server" Text="Continue" Width="128px" BackColor="Blue" OnClientClick="return verify();" Style="color: White;" />
                     &nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="128px" BackColor="Blue"
                        Style="color: White;" />
                     
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
</body>
</html>
