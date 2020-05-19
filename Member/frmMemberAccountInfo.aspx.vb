
Partial Class Register_step4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim role As Integer
        Dim email As String = ""

        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("userdata") Is Nothing) Then

            objUserDataCookie = Request.Cookies("userdata")
            email = objUserDataCookie.Values("email")
            lblUserEmail.Text = email
            role = objUserDataCookie.Values("role")

            If Not (role = 2) Then
                Response.Redirect("../login.aspx")
            End If

        Else
            Response.Redirect("../login.aspx")
        End If



        Dim objCDBUserInfo As New CDBUserInfo
        Dim objUserInfo As New CUserInfo


        objUserInfo = objCDBUserInfo.getMemberInfo(email)

        lblMemberSince.Text = objUserInfo.RegistrationDateUS
        lblEmail.Text = objUserInfo.EmailUS
        lblMemberName.Text = objUserInfo.FullNameUS
        lblMailingAddress.Text = objUserInfo.AddressUS
        lblTelephone.Text = objUserInfo.ContactUS
        lblNRIC.Text = objUserInfo.NricUS






    End Sub
End Class
