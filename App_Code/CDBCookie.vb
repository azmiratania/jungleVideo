Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CDBCookie

    Const CONNSTRING As String = "Data Source=DIT-NB0839408\SQLEXPRESS;Initial Catalog=JungleVideoDB;Persist Security Info=True;User ID=sa;password=12345678"

    Public Function CheckEmailAndPassWord(ByVal strEmail As String, _
                                          ByVal strPassword As String) As Integer

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow


        objCn.ConnectionString = CONNSTRING
        objCmd.Connection = objCn

        Dim strSQL As String
        strSQL = "SELECT * " & _
                 "FROM tblUser " & _
                 "WHERE strEmailUS = '" & strEmail & "' AND strPasswordUS = '" & strPassword & "' "

        objCmd.CommandText = strSQL

        objAd.SelectCommand = objCmd

        objCn.Open()

        objAd.Fill(objDs, "tblUserInfo")

        Dim role As Integer


        Try 'if the email & password matches the dastabase then this will be true
            objDr = objDs.Tables("tblUserInfo").Rows(0)
           
            role = objDr.Item("intRoleIdUS") ' I WANT ONLY ROLE.

        Catch 'else it will enter catch which will return "Error".

            role = 0 ' any value that is not in the database 

        Finally
            objCn.Close()
        End Try

        Return role
    End Function





End Class
