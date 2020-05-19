Imports Microsoft.VisualBasic

Public Class CSalutation

    Private intSalutationIdSA As Integer
    Private strSalutationNameSA As String

    Public Property SalutationId() As Integer
        Get
            Return intSalutationIdSA
        End Get
        Set(ByVal intValue As Integer)
            intSalutationIdSA = intValue
        End Set
    End Property

    Public Property SalutationName() As String
        Get
            Return strSalutationNameSA
        End Get
        Set(ByVal strValue As String)
            strSalutationNameSA = strValue
        End Set
    End Property

End Class
