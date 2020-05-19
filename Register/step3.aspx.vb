
Partial Class Register_step3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objMonth As New CDBDropDownLists
        Dim objArrayList As ArrayList

        '-----------------------------------------------------------
        'Bind the dropdownlist for month
        '-----------------------------------------------------------

        If Page.IsPostBack = False Then
            objArrayList = objMonth.generateMonthList
            lstMonth.DataSource = objArrayList
            lstMonth.DataTextField = "MonthName"
            lstMonth.DataValueField = "MonthId"
            lstMonth.DataBind()
        End If

        '-----------------------------------------------------------
        'Bind the dropdownlist for year
        '-----------------------------------------------------------

        Dim objYear As New CDBDropDownLists
        Dim objYearArrayList As ArrayList

        If Page.IsPostBack = False Then
            objYearArrayList = objYear.generateYearList
            lstYear.DataSource = objYearArrayList
            lstYear.DataTextField = "YearName"
            lstYear.DataValueField = "YearId"
            lstYear.DataBind()
        End If

        '-----------------------------------------------------------

        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("step3") Is Nothing) Then

            objUserDataCookie = Request.Cookies("step3")

            txtHolderName.Text = objUserDataCookie.Values("cardHolderName")
            txtCardNo.Text = objUserDataCookie.Values("cardNumber")
            lstMonth.SelectedItem.Text = objUserDataCookie.Values("month")
            lstYear.SelectedItem.Text = objUserDataCookie.Values("year")

        End If

        '-----------------------------------------------------------
        Dim objCookie As HttpCookie

        objCookie = New HttpCookie("step3")
        objCookie.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(objCookie)




    End Sub

    Protected Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click


        Dim objUserDataCookie As HttpCookie
        objUserDataCookie = New HttpCookie("step3")

        Dim cardHolderName As String
        Dim cardNumber As String
        Dim expirationDate As String
        Dim month As String
        Dim year As String


        cardHolderName = txtHolderName.Text
        cardNumber = txtCardNo.Text

        month = lstMonth.SelectedItem.Text
        year = lstYear.SelectedItem.Text
        expirationDate = CStr(lstMonth.SelectedItem.Text) + CStr("/") + CStr(lstYear.SelectedItem.Text)


        objUserDataCookie.Values.Add("cardHolderName", cardHolderName)
        objUserDataCookie.Values.Add("cardNumber", cardNumber)
        objUserDataCookie.Values.Add("expirationDate", expirationDate)
        objUserDataCookie.Values.Add("month", month)
        objUserDataCookie.Values.Add("year", year)
        Response.Cookies.Add(objUserDataCookie)



        If (Request.Cookies("step1") Is Nothing) Then
            Response.Redirect("step1.aspx")

        ElseIf (Request.Cookies("step2") Is Nothing) Then
            Response.Redirect("step2.aspx")

        ElseIf (Request.Cookies("step3") Is Nothing) Then
            Response.Redirect("step3.aspx")
        Else
            Response.Redirect("step4.aspx")

        End If


    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("step1.aspx")

    End Sub
  
End Class
