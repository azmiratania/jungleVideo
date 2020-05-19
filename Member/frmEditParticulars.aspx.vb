
Partial Class Member_frmEditParticulars
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
        'Bind the dropdownlist for salutation

        Dim objSalutation As New CDBDropDownLists
        Dim objArrayList As New ArrayList


        If Page.IsPostBack = False Then


            objArrayList = objSalutation.generateSalutationList


            lstSalutation.DataSource = objArrayList

            lstSalutation.DataTextField = "SalutationName"

            lstSalutation.DataValueField = "SalutationId"


            lstSalutation.DataBind()


            Dim objCDBUserInfo As New CDBUserInfo
            Dim objUserInfo As New CUserInfo


            objUserInfo = objCDBUserInfo.getMemberInfo(email)

            lstSalutation.SelectedItem.Value = objUserInfo.SalutationIdUS
            txtFullName.Text = objUserInfo.FullNameUS
            txtNRIC.Text = objUserInfo.NricUS
            txtAddress.Text = objUserInfo.AddressUS
            txtPostCode.Text = objUserInfo.PostalCodeUS
            txtTelephone.Text = objUserInfo.ContactUS



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

            .SalutationIdUS = lstSalutation.SelectedItem.Value
            .FullNameUS = txtFullName.Text
            .NricUS = txtNRIC.Text
            .AddressUS = txtAddress.Text
            .PostalCodeUS = txtPostCode.Text
            .ContactUS = txtTelephone.Text
            .EmailUS = email

        End With

        objCDBUserInfo.editParticulars(objUserInfo)

        Response.Redirect("frmMemberAccountInfo.aspx")

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("frmMemberAccountInfo.aspx")
    End Sub
End Class
