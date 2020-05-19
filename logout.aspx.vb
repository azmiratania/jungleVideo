
Partial Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objCookie As HttpCookie
        Dim intIndex As Integer
        Dim strCookieName As String

        Dim intMaxIndex As Integer = Request.Cookies.Count - 1

        For intIndex = 0 To intMaxIndex
            strCookieName = Request.Cookies(intIndex).Name
            objCookie = New HttpCookie(strCookieName)
            objCookie.Expires = DateTime.Now.AddDays(-1)
            Response.Cookies.Add(objCookie)
        Next


        Response.Redirect("login.aspx")



    End Sub
End Class
