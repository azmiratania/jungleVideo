
Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim email As String
        Dim password As String
        Dim objCDBCookie As New CDBCookie
        Dim role As Integer

        email = txtEmail.Text.Trim
        password = txtPassword.Text.Trim
        role = objCDBCookie.CheckEmailAndPassWord(email, password)

        Dim objUserDataCookie As HttpCookie
        objUserDataCookie = New HttpCookie("userdata")

       
        If (role = 1) Then

            objUserDataCookie.Values.Add("email", email)
            objUserDataCookie.Values.Add("role", role)
            Response.Cookies.Add(objUserDataCookie)

            Response.Redirect("Admin/admin.aspx")

        ElseIf (role = 2) Then

            objUserDataCookie.Values.Add("email", email)
            objUserDataCookie.Values.Add("role", role)
            Response.Cookies.Add(objUserDataCookie)

            Response.Redirect("Member/ViewMovies.aspx")

        ElseIf (role = 3) Then
            lblMessage.Text = "Account Suspended." & vbCrLf & "Please contact administrator."

        Else
            lblMessage.Text = "Invalid email/password!"

        End If



    End Sub
End Class
