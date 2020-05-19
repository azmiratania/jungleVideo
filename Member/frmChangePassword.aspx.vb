
Partial Class Member_frmChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim role As Integer
        Dim email As String

        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("userdata") Is Nothing) Then

            objUserDataCookie = Request.Cookies("userdata")
            email = objUserDataCookie.Values("email")
            role = objUserDataCookie.Values("role")

            lblUserEmail.Text = email

            If Not (role = 2) Then
                Response.Redirect("../login.aspx")
            End If

        Else
            Response.Redirect("../login.aspx")
        End If


    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim role As Integer
        Dim email As String = ""

        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("userdata") Is Nothing) Then

            objUserDataCookie = Request.Cookies("userdata")
            email = objUserDataCookie.Values("email")
            role = objUserDataCookie.Values("role")

            lblUserEmail.Text = email

            If Not (role = 2) Then
                Response.Redirect("../login.aspx")
            End If

        Else
            Response.Redirect("../login.aspx")
        End If



        Dim objUserInfo As New CUserInfo
        Dim objCDBUserInfo As New CDBUserInfo


        Dim DBPassword As String
        Dim currentPassword As String
        Dim newPassword As String
        Dim confirmPassword As String

        objUserInfo = objCDBUserInfo.getMemberInfo(email)

        DBPassword = objUserInfo.PasswordUS
        currentPassword = txtCurrentPassword.Text
        newPassword = txtNewPassword.Text
        confirmPassword = txtConfirmPassword.Text

        If currentPassword.Equals(DBPassword) Then

            If newPassword.Equals(confirmPassword) Then



                Dim objUserInfoUpdate As New CUserInfo

                With objUserInfoUpdate

                    .EmailUS = email
                    .PasswordUS = txtNewPassword.Text

                End With

                objCDBUserInfo.editPassword(objUserInfoUpdate)

                Response.Redirect("frmMemberAccountInfo.aspx")

            Else
                lblErrorMessage.Text = "The two password does not match. "
                txtCurrentPassword.Text = ""
                txtNewPassword.Text = ""
                txtConfirmPassword.Text = ""



            End If

        Else
            lblErrorMessage.Text = "Incorrect password. "
            txtCurrentPassword.Text = ""
            txtNewPassword.Text = ""
            txtConfirmPassword.Text = ""

        End If



    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("frmMemberAccountInfo.aspx")
    End Sub
End Class
