
Partial Class Member_frmEditCreditCardDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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




        '-----------------------------------------------------------
        Dim objMonth As New CDBDropDownLists
        Dim objArrayList As ArrayList


        If Page.IsPostBack = False Then

            objArrayList = objMonth.generateMonthList

            lstMonth.DataSource = objArrayList
            lstMonth.DataTextField = "MonthName"
            lstMonth.DataValueField = "MonthId"

            lstMonth.DataBind()


            Dim objYear As New CDBDropDownLists
            Dim objYearArrayList As ArrayList

            objYearArrayList = objYear.generateYearList


            lstYear.DataSource = objYearArrayList

            lstYear.DataTextField = "YearName"

            lstYear.DataValueField = "YearId"


            lstYear.DataBind()



            Dim objCDBUserInfo As New CDBUserInfo
            Dim objUserInfo As New CUserInfo


            objUserInfo = objCDBUserInfo.getMemberInfo(email)

            txtHolderName.Text = objUserInfo.FullNameUS
            txtCardNo.Text = objUserInfo.CreditCardUS


        End If

        '-----------------------------------------------------------



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


        With objUserInfo

            .EmailUS = email
            .CreditCardUS = txtCardNo.Text

        End With

        objCDBUserInfo.editCreditCardDetails(objUserInfo)

        Response.Redirect("frmMemberAccountInfo.aspx")





    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("frmMemberAccountInfo.aspx")


    End Sub
End Class
