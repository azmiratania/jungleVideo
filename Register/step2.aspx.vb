
Partial Class Register_step2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '-----------------------------------------------------------
        'Bind the dropdownlist for salutation
        '-----------------------------------------------------------

        Dim objSalutation As New CDBDropDownLists
        Dim objArrayList As New ArrayList


        If Page.IsPostBack = False Then


            objArrayList = objSalutation.generateSalutationList


            lstSalutation.DataSource = objArrayList

            lstSalutation.DataTextField = "SalutationName"

            lstSalutation.DataValueField = "SalutationId"


            lstSalutation.DataBind()

        End If

        '-----------------------------------------------------------
        'Bind the dropdownlist for SurveyAnswers
        '-----------------------------------------------------------

        Dim objSurveyAnswer As New CDBDropDownLists
        Dim objArrayListSA As New ArrayList


        If Page.IsPostBack = False Then


            objArrayListSA = objSurveyAnswer.generateSurveyAnswerList


            lstAboutUs.DataSource = objArrayListSA

            lstAboutUs.DataTextField = "AnswerSU"

            lstAboutUs.DataValueField = "SequenceSU"


            lstAboutUs.DataBind()

        End If

        '-------------------------------------------------------------
        'Allow users to edit their particulars from Step 4.###########
        '-------------------------------------------------------------
        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("step2") Is Nothing) Then

            objUserDataCookie = Request.Cookies("step2")

            lstSalutation.SelectedItem.Text = objUserDataCookie.Values("salutation")
            txtGivenName.Text = objUserDataCookie.Values("name")
            txtFamilyName.Text = objUserDataCookie.Values("familyName")
            txtNRIC.Text = objUserDataCookie.Values("NRIC")
            txtAddress.Text = objUserDataCookie.Values("address")
            txtPostCode.Text = objUserDataCookie.Values("postalCode")
            txtTelephone.Text = objUserDataCookie.Values("telephone")
            lstAboutUs.SelectedItem.Text = objUserDataCookie.Values("hearAboutUs")

        End If

        'Following code - removes the initial step2 cookie.
        Dim objCookie As HttpCookie

        objCookie = New HttpCookie("step2")
        objCookie.Expires = DateTime.Now.AddDays(-1) 'removes the initial step2 cookie.
        Response.Cookies.Add(objCookie)
        '-------------------------------------------------------------
    End Sub


    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        Dim objUserDataCookie As HttpCookie
        objUserDataCookie = New HttpCookie("step2")

        Dim salutation As String
        Dim salutationId As Integer
        Dim name As String
        Dim familyName As String
        Dim NRIC As String
        Dim address As String
        Dim postalCode As String
        Dim telephone As String
        Dim hearAboutUs As String


        salutation = lstSalutation.SelectedItem.Text.Trim
        salutationId = lstSalutation.SelectedItem.Value
        name = txtGivenName.Text.Trim
        familyName = txtFamilyName.Text.Trim
        NRIC = txtNRIC.Text.Trim
        address = txtAddress.Text.Trim
        postalCode = txtPostCode.Text.Trim
        telephone = txtTelephone.Text.Trim
        hearAboutUs = lstAboutUs.SelectedItem.Text.Trim


        objUserDataCookie.Values.Add("salutation", salutation)
        objUserDataCookie.Values.Add("salutationId", salutationId)
        objUserDataCookie.Values.Add("name", name)
        objUserDataCookie.Values.Add("familyName", familyName)
        objUserDataCookie.Values.Add("NRIC", NRIC)
        objUserDataCookie.Values.Add("address", address)
        objUserDataCookie.Values.Add("postalCode", postalCode)
        objUserDataCookie.Values.Add("telephone", telephone)
        objUserDataCookie.Values.Add("hearAboutUs", hearAboutUs)
        Response.Cookies.Add(objUserDataCookie)

        '-------------------------------------------------------
        'Cookie Validation
        '-------------------------------------------------------

        If (Request.Cookies("step1") Is Nothing) Then
            Response.Redirect("step1.aspx")

        ElseIf (Request.Cookies("step2") Is Nothing) Then
            Response.Redirect("step2.aspx")

        ElseIf (Request.Cookies("step3") Is Nothing) Then
            Response.Redirect("step3.aspx")
        Else
            Response.Redirect("step4.aspx")

        End If

        '-------------------------------------------------------

    End Sub

    
End Class
