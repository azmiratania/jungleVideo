Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class CDBDropDownLists

    Const CONNSTRING As String = "Data Source=DIT-NB0839408\SQLEXPRESS;Initial Catalog=JungleVideoDB;Persist Security Info=True;User ID=sa;password=12345678"

    Public Function generateSalutationList() As ArrayList

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow

        objCmd.Connection = objCn
        objCn.ConnectionString = CONNSTRING


        objCn.Open()
        objCmd.CommandText = "SELECT * FROM tblSalutation"
        objAd.SelectCommand = objCmd
        objAd.Fill(objDs, "tblSalutation")


        Dim objSalutation As New CSalutation
        Dim objArrayList As New ArrayList

        For Each objDr In objDs.Tables("tblSalutation").Rows

            objSalutation = New CSalutation

            With objSalutation

                .SalutationId = objDr.Item("intSalutationIdSA")
                .SalutationName = objDr.Item("strSalutationNameSA")

            End With

            objArrayList.Add(objSalutation)
        Next

        objCn.Close()

        Return objArrayList

    End Function



    Public Function generateSurveyAnswerList() As ArrayList

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow

        objCmd.Connection = objCn
        objCn.ConnectionString = CONNSTRING


        objCn.Open()
        objCmd.CommandText = "SELECT * FROM tblSurveyAnswer"
        objAd.SelectCommand = objCmd
        objAd.Fill(objDs, "tblSurveyAnswer")


        Dim objSurveyAnswer As New CSurveyAnswer
        Dim objArrayList As New ArrayList

        For Each objDr In objDs.Tables("tblSurveyAnswer").Rows

            objSurveyAnswer = New CSurveyAnswer

            With objSurveyAnswer

                .SurveryAnswerId = objDr.Item("intSurveryAnswerIdSU")
                .AnswerSU = objDr.Item("strAnswerSU")
                .SequenceSU = objDr.Item("intSequenceSU")

            End With

            objArrayList.Add(objSurveyAnswer)
        Next

        objCn.Close()

        Return objArrayList

    End Function


    Public Function generateMonthList() As ArrayList

        Dim Month(12) As String
        Dim i As Integer

        For i = 1 To 12
            If i < 10 Then
                Month(i) = "0" + CStr(i) '//Convert 1 2 3 to 01 02 03
            Else
                Month(i) = i
            End If
        Next


        Dim objMonth As New CMonth
        Dim objArrayList As New ArrayList


        For i = 1 To 12
            objMonth = New CMonth
            With objMonth
                .MonthId = CInt(Month(i))
                .MonthName = Month(i)
            End With

            objArrayList.Add(objMonth)
        Next

        Return objArrayList


    End Function

    Public Function generateYearList() As ArrayList

        Dim Year(11) As String
        Dim i As Integer

        For i = 0 To 11
            Year(i) = CStr(2010 + i)
        Next


        Dim objYear As New CYear
        Dim objArrayList As New ArrayList


        For i = 0 To 11
            objYear = New CYear
            With objYear
                .YearId = CInt(Year(i))
                .YearName = Year(i)
            End With

            objArrayList.Add(objYear)
        Next

        Return objArrayList


    End Function



End Class
