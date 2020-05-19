<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmEditParticulars.aspx.vb"
    Inherits="Member_frmEditParticulars" %>

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

            var givenName = trimData(document.getElementById("txtFullName").value);
            var NRIC = trimData(document.getElementById("txtNRIC").value);
            var address = trimData(document.getElementById("txtAddress").value);
            var postalCode = trimData(document.getElementById("txtPostCode").value);
            var telephone = trimData(document.getElementById("txtTelephone").value);
            var objlblMessage = document.getElementById("lblErrorMessage");

            objlblMessage.innerHTML = "";

            var checkTelephone = mobileFormat(telephone);

            if ((givenName == "") || (NRIC == "") || (NRIC.length != 9) || (address == "") || (postalCode == "") || (telephone == "") || (checkTelephone == false)) {


                if (givenName == "") {
                    objlblMessage.innerHTML += "GivenName cannot be empty.<br/>";
                }


                if (NRIC == "") {
                    objlblMessage.innerHTML += "NRIC cannot be empty.<br/>";
                }

                if (NRIC.length != 9) {
                    objlblMessage.innerHTML += "Invalid NRIC format.<br/>";
                }

                if (address == "") {
                    objlblMessage.innerHTML += "Address cannot be empty.<br/>";
                }

                if (postalCode == "") {
                    objlblMessage.innerHTML += "Postal code cannot be empty.<br/>";
                }

                if (telephone == "") {
                    objlblMessage.innerHTML += "Telephone cannot be empty.<br/>";
                }

                if (checkTelephone == false) {
                    objlblMessage.innerHTML += "Telephone Number should not contain any alphabets.<br/>";
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

        function mobileFormat(strMobilePhone) {
            var strAlphabets = new String("abcdefghijklmnopqrstuvwxyz"); //comparing string of alphabets
            var output = true;
            for (intIndex = 0; intIndex < strMobilePhone.length; intIndex++) {
                var strNumber = strMobilePhone.charAt(intIndex); //for example '987654321asdd' will extract 9
                if (strAlphabets.indexOf(strNumber) != -1) {
                    output = false;
                    break;

                } //end of if condition

            } //end of for loop
            return output;
        } //end of function mobileFormat

        
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
        Edit Particulars</h2>
    <hr style="width: 90%;" />
    <br />
    <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <table style="width: 100%;" align="center">
        <tr>
            <td class="style2">
                Salutation
            </td>
            <td>
                <asp:DropDownList ID="lstSalutation" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Full Name
            </td>
            <td>
                <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                NRIC
            </td>
            <td>
                <asp:TextBox ID="txtNRIC" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Address
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Postal Code
            </td>
            <td>
                <asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Telephone
            </td>
            <td>
                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
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
