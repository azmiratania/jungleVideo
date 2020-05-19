Imports Microsoft.VisualBasic

Public Class CMonth

    Private intMonthId As Integer
    Private strMonthName As String

    Public Property MonthId() As Integer
        Get
            Return intMonthId
        End Get
        Set(ByVal intValue As Integer)
            intMonthId = intValue
        End Set
    End Property

    Public Property MonthName() As String
        Get
            Return strMonthName
        End Get
        Set(ByVal strValue As String)
            strMonthName = strValue
        End Set
    End Property





End Class
