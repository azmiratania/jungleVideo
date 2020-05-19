Partial Class Member_SuspendAccount
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

    Protected Sub btnSuspend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSuspend.Click

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

        objUserInfo.EmailUS = email

        objCDBUserInfo.suspendAccount(objUserInfo)

        Response.Redirect("../logout.aspx")

    End Sub

  
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("frmMemberAccountInfo.aspx")

    End Sub
End Class
