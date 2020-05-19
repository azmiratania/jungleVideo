
Partial Class Register_step1
    Inherits System.Web.UI.Page

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click


        Dim objUserDataCookie As HttpCookie
        objUserDataCookie = New HttpCookie("step1")

        Dim email As String
        Dim password As String

        email = txtEmail.Text.Trim
        password = txtCreatePassword.Text.Trim

        objUserDataCookie.Values.Add("email", email)
        objUserDataCookie.Values.Add("password", password)
        Response.Cookies.Add(objUserDataCookie)

        If (Request.Cookies("step1") Is Nothing) Then
            Response.Redirect("step1.aspx") 'if cookie is disabled on browser - then stay on this page.

        ElseIf (Request.Cookies("step2") Is Nothing) Then
            Response.Redirect("step2.aspx")

        ElseIf (Request.Cookies("step3") Is Nothing) Then
            Response.Redirect("step3.aspx")
        Else
            Response.Redirect("step4.aspx")

        End If

    End Sub
End Class
