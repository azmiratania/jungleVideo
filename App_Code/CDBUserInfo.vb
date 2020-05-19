Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class CDBUserInfo

    Const CONNSTRING As String = "Data Source=DIT-NB0839408\SQLEXPRESS;Initial Catalog=JungleVideoDB;Persist Security Info=True;User ID=sa;password=12345678"

    Public Function addOneMember(ByVal pobjMember As CUserInfo) As Integer

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection


        objCn.ConnectionString = CONNSTRING
        objCmd.Connection = objCn

        objCn.Open()


        Dim strSQL As String

        strSQL = "INSERT INTO tblUser " & _
                 "(strEmailUS , strPasswordUS , strAddressUS , strPostalCodeUS , intSalutationIdUS," & _
                 "strFullNameUS,strNricUS,strContactUS,strRegistrationDateUS,strCreditCardUS,intRoleIdUS) " & _
                 "values ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}',{10})"

        objCmd.CommandText = String.Format(strSQL, pobjMember.EmailUS, pobjMember.PasswordUS, pobjMember.AddressUS, pobjMember.PostalCodeUS, _
                                           pobjMember.SalutationIdUS, pobjMember.FullNameUS, pobjMember.NricUS, pobjMember.ContactUS, _
                                           pobjMember.RegistrationDateUS, pobjMember.CreditCardUS, pobjMember.RoleIdUS)


        Dim intNumOfRecordsAffected As Integer

        intNumOfRecordsAffected = objCmd.ExecuteNonQuery()

        objCn.Close()

        Return intNumOfRecordsAffected



    End Function


    Function getActiveMemberRecords(ByVal strMemberType As String) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow



        Dim objMember As New CUserInfo
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblUser u,tblRole r " & _
        "WHERE  u.intRoleIdUS = r.intRoleIdRO AND r.strRoleNameRO = '" & strMemberType & "'"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMember = New CUserInfo

            With objMember

                .UserIdUS = objDr.Item("intUserIdUS")
                .FullNameUS = objDr.Item("strFullNameUS")
                .EmailUS = objDr.Item("strEmailUS")

            End With


            objArrayList.Add(objMember)


        Next
        objCn.Close()

        Return objArrayList

    End Function


    Public Function getMemberInfo(ByVal email As String) As CUserInfo

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection
        Dim objAdapter As New SqlDataAdapter
        Dim strSQL As String = ""
        Dim objDs As New DataSet
        Dim objDataRow As DataRow

        objCn.ConnectionString = CONNSTRING
        objCmd.Connection = objCn

      


        objCmd.CommandText = "SELECT * FROM tblUser WHERE strEmailUS = '" & email & "' "



        objAdapter.SelectCommand = objCmd

        objCn.Open()

        objAdapter.Fill(objDs, "tblData")

        objDataRow = objDs.Tables("tblData").Rows(0)

        Dim objUserInfo As New CUserInfo

        With objUserInfo

            .UserIdUS = objDataRow.Item("intUserIdUS")
            .EmailUS = objDataRow.Item("strEmailUS")
            .PasswordUS = objDataRow.Item("strPasswordUS")
            .AddressUS = objDataRow.Item("strAddressUS")
            .PostalCodeUS = objDataRow.Item("strPostalCodeUS")
            .SalutationIdUS = objDataRow.Item("intSalutationIdUS")
            .FullNameUS = objDataRow.Item("strFullNameUS")
            .NricUS = objDataRow.Item("strNricUS")
            .ContactUS = objDataRow.Item("strContactUS")
            .RegistrationDateUS = objDataRow.Item("strRegistrationDateUS")
            .CreditCardUS = objDataRow.Item("strCreditCardUS")
            .RoleIdUS = objDataRow.Item("intRoleIdUS")

        End With

        objCn.Close()

        Return objUserInfo

    End Function

    Public Function editParticulars(ByVal pobjMember As CUserInfo) As Integer

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection


        objCn.ConnectionString = CONNSTRING
        objCmd.Connection = objCn

        objCn.Open()


        Dim strSQL As String


        strSQL = "UPDATE tblUser SET strAddressUS='{0}', strPostalCodeUS='{1}', intSalutationIdUS={2}, " & _
                 "strFullNameUS='{3}', strNricUS='{4}', strContactUS='{5}' " & _
                 " WHERE strEmailUS='{6}'"


        objCmd.CommandText = String.Format(strSQL, pobjMember.AddressUS, pobjMember.PostalCodeUS, pobjMember.SalutationIdUS, _
                                            pobjMember.FullNameUS, pobjMember.NricUS, pobjMember.ContactUS, pobjMember.EmailUS)


        Dim intNumOfRecordsAffected As Integer

        intNumOfRecordsAffected = objCmd.ExecuteNonQuery()

        objCn.Close()

        Return intNumOfRecordsAffected



    End Function

    Public Function editCreditCardDetails(ByVal pobjMember As CUserInfo) As Integer

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection


        objCn.ConnectionString = CONNSTRING
        objCmd.Connection = objCn

        objCn.Open()


        Dim strSQL As String


        strSQL = "UPDATE tblUser SET strCreditCardUS='{0}' WHERE strEmailUS='{1}'"



        objCmd.CommandText = String.Format(strSQL, pobjMember.CreditCardUS, pobjMember.EmailUS)


        Dim intNumOfRecordsAffected As Integer

        intNumOfRecordsAffected = objCmd.ExecuteNonQuery()

        objCn.Close()

        Return intNumOfRecordsAffected



    End Function


    Public Function editPassword(ByVal pobjMember As CUserInfo) As Integer

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection


        objCn.ConnectionString = CONNSTRING
        objCmd.Connection = objCn

        objCn.Open()


        Dim strSQL As String


        strSQL = "UPDATE tblUser SET strPasswordUS='{0}' WHERE strEmailUS='{1}'"



        objCmd.CommandText = String.Format(strSQL, pobjMember.PasswordUS, pobjMember.EmailUS)


        Dim intNumOfRecordsAffected As Integer

        intNumOfRecordsAffected = objCmd.ExecuteNonQuery()

        objCn.Close()

        Return intNumOfRecordsAffected



    End Function

    Public Function suspendAccount(ByVal pobjMember As CUserInfo) As Integer

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection


        objCn.ConnectionString = CONNSTRING
        objCmd.Connection = objCn

        objCn.Open()


        Dim strSQL As String


        strSQL = "UPDATE tblUser SET intRoleIdUS= 3 WHERE strEmailUS='{0}'"



        objCmd.CommandText = String.Format(strSQL, pobjMember.EmailUS)


        Dim intNumOfRecordsAffected As Integer

        intNumOfRecordsAffected = objCmd.ExecuteNonQuery()

        objCn.Close()

        Return intNumOfRecordsAffected



    End Function


End Class
