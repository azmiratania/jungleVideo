Imports Microsoft.VisualBasic

Public Class CRadioButton

    Private intRadioId As Integer
    Private strRadioName As String

    Public Property RadioId() As Integer
        Get
            Return intRadioId
        End Get
        Set(ByVal intValue As Integer)
            intRadioId = intValue
        End Set
    End Property

    Public Property RadioName() As String
        Get
            Return strRadioName
        End Get
        Set(ByVal strValue As String)
            strRadioName = strValue
        End Set
    End Property








End Class
