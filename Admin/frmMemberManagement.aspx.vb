
Partial Class Admin_frmMemberManagement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '##############################################################
        '//Place this piece of code in page_load to check if 
        '//user is logged in as admin OR member
        '//Admin is (1) & Member is (2)
        '##############################################################
        'Dim role As Integer
        'Dim email As String

        'Dim objUserDataCookie As HttpCookie

        'If Not (Request.Cookies("userdata") Is Nothing) Then

        '    objUserDataCookie = Request.Cookies("userdata")
        '    email = objUserDataCookie.Values("email")
        '    role = objUserDataCookie.Values("role")


        '    If Not (role = 1) Then
        '        Response.Redirect("../login.aspx")
        '    End If

        'Else
        '    Response.Redirect("../login.aspx")
        'End If

        '##############################################################

        '##############################################################
        '//Databind the radiobuttons to display when page loads

        Dim objDBRadioButton As New CDBRadioButton
        Dim objRadioBtnArrayList As New ArrayList

        If Page.IsPostBack = False Then

            objRadioBtnArrayList = objDBRadioButton.getRadioButton
            radMemberType.DataSource = objRadioBtnArrayList
            radMemberType.DataTextField = "RadioName"
            radMemberType.DataValueField = "RadioId"
            radMemberType.DataBind()


            Dim membertype As String = "Member"
            Dim objDBUserInfo As New CDBUserInfo
            Dim objArrayList As New ArrayList

            objArrayList = objDBUserInfo.getActiveMemberRecords(membertype)

            grdData.DataSource = objArrayList

            grdData.DataBind()



        End If
        '##############################################################

    End Sub

    Protected Sub btnDisplayMembers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplayMembers.Click

        Dim membertype As String = "Active"
        Dim objDBUserInfo As New CDBUserInfo
        Dim objArrayList As New ArrayList

        'If CInt(Request.Form("radMemberType")) = 1 Then

        'objArrayList = objDBUserInfo.getActiveMemberRecords(membertype)

        'grdData.DataSource = objArrayList

        'grdData.DataBind()

        'ElseIf CInt(Request.Form("radMemberType")) = 2 Then


        '    objArrayList = objDBUserInfo.getActiveMemberRecords(membertype)

        '    grdData.DataSource = objArrayList

        '    grdData.DataBind()


        'End If

    End Sub

    Protected Sub grdData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdData.RowDataBound

        Dim ID As Integer

        If e.Row.RowType <> DataControlRowType.Footer And e.Row.RowType <> DataControlRowType.Header Then

            ID = e.Row.Cells(0).Text
            e.Row.Cells(0).Text = "<input type=""checkbox"" name=""chkRecordId"" id=""chkRecordId"" value=""" & ID & """ />"
            e.Row.Cells(1).Text = "<input type=""button"" name=""btnRecordId"" id=""btnRecordId"" value=""Manage"" onclick=""location.href='frmManageMember.aspx?id=" & ID & "'"" />"

        End If


    End Sub
End Class
