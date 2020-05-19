
Partial Class Register_step4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblEmail.Text = ""
        lblMemberName.Text = ""
        lblMailingAddress.Text = ""
        lblTelephone.Text = ""
        lblCardHolderName.Text = ""
        lblCardNumber.Text = ""
        lblExpirationDate.Text = ""


        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("step1") Is Nothing) Then

            objUserDataCookie = Request.Cookies("step1")
            lblEmail.Text = objUserDataCookie.Values("email")
        Else
            Response.Redirect("step1.aspx")

        End If


        If Not (Request.Cookies("step2") Is Nothing) Then

            objUserDataCookie = Request.Cookies("step2")
            lblMemberName.Text = objUserDataCookie.Values("salutation") & " " & _
                                  objUserDataCookie.Values("name") & " " & _
                                  objUserDataCookie.Values("familyName")
            lblMailingAddress.Text = objUserDataCookie.Values("address")
            lblTelephone.Text = objUserDataCookie.Values("telephone")
        Else
            Response.Redirect("step2.aspx")

        End If


        If Not (Request.Cookies("step3") Is Nothing) Then

            objUserDataCookie = Request.Cookies("step3")
            lblCardHolderName.Text = objUserDataCookie.Values("cardHolderName")
            lblCardNumber.Text = objUserDataCookie.Values("cardNumber")
            lblExpirationDate.Text = objUserDataCookie.Values("expirationDate")
        Else
            Response.Redirect("step3.aspx")

        End If





    End Sub


    Protected Sub btnStartMembership_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartMembership.Click

        Dim email As String = ""
        Dim password As String = ""
        Dim address As String = ""
        Dim postalCode As String = ""
        Dim salutationId As Integer
        Dim fullname As String = ""
        Dim nric As String = ""
        Dim contact As String = ""
        Dim rightNow As Date = Now
        Dim creditCard As String = ""


        Dim objNewMember As New CUserInfo
        Dim objDBUserInfo As New CDBUserInfo


        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("step1") Is Nothing) Then

            objUserDataCookie = Request.Cookies("step1")
            email = objUserDataCookie.Values("email")
            password = objUserDataCookie.Values("password")
        End If


        If Not (Request.Cookies("step2") Is Nothing) Then

            objUserDataCookie = Request.Cookies("step2")


            address = objUserDataCookie.Values("address")
            postalCode = objUserDataCookie.Values("postalCode")
            salutationId = objUserDataCookie.Values("salutationId")
            fullname = objUserDataCookie.Values("name") + " " + objUserDataCookie.Values("familyName")
            nric = objUserDataCookie.Values("NRIC")
            contact = objUserDataCookie.Values("telephone")
       

        End If


        If Not (Request.Cookies("step3") Is Nothing) Then

            objUserDataCookie = Request.Cookies("step3")

            creditCard = objUserDataCookie.Values("cardNumber")

        End If


        With objNewMember

            .EmailUS = email
            .PasswordUS = password
            .AddressUS = address
            .PostalCodeUS = postalCode
            .SalutationIdUS = salutationId
            .FullNameUS = fullName
            .NricUS = nric
            .ContactUS = contact
            .RegistrationDateUS = rightNow.ToShortDateString
            .CreditCardUS = creditCard
            .RoleIdUS = 2

        End With


        Dim intNumOfRecordsAffected As Integer
        intNumOfRecordsAffected = objDBUserInfo.addOneMember(objNewMember)

        If intNumOfRecordsAffected <> 0 Then
            lblRegisrationDone.Text = "<br/><br/><br/><br/><b>Registration Complete!" & _
            "<br/>Please login with your email address and start adding movies into your cart! </b><br/><br/><br/><br/>"

        End If



    End Sub
End Class
