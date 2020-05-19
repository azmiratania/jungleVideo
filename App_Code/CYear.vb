Imports Microsoft.VisualBasic

Public Class CYear


    Private intYearId As Integer
    Private strYearName As String

    Public Property YearId() As Integer
        Get
            Return intYearId
        End Get
        Set(ByVal intValue As Integer)
            intYearId = intValue
        End Set
    End Property

    Public Property YearName() As String
        Get
            Return strYearName
        End Get
        Set(ByVal strValue As String)
            strYearName = strValue
        End Set
    End Property


End Class
