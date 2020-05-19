Imports Microsoft.VisualBasic

Public Class CStudio

    Private intStudioIdST As Integer
    Private strStudioNameST As String

    Public Property StudioIdST() As Integer
        Get
            Return intStudioIdST
        End Get
        Set(ByVal intValue As Integer)
            intStudioIdST = intValue
        End Set
    End Property

    Public Property StudioNameST() As String
        Get
            Return strStudioNameST
        End Get
        Set(ByVal strValue As String)
            strStudioNameST = strValue
        End Set
    End Property


End Class
