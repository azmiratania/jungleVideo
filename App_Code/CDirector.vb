Imports Microsoft.VisualBasic

Public Class CDirector

    Private intDirectorIdDI As Integer
    Private strFullNameDI As String

    Public Property DirectorIdDI() As Integer
        Get
            Return intDirectorIdDI
        End Get
        Set(ByVal intValue As Integer)
            intDirectorIdDI = intValue
        End Set
    End Property


    Public Property FullNameDI() As String
        Get
            Return strFullNameDI
        End Get
        Set(ByVal strValue As String)
            strFullNameDI = strValue
        End Set
    End Property






End Class
