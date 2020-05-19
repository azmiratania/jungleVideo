Imports Microsoft.VisualBasic

Public Class CCategory

    Private intCategoryIdCA As Integer
    Private strCategoryNameCA As String
    Private strDescriptionCA As String

    Public Property CategoryIdCA() As Integer
        Get
            Return intCategoryIdCA
        End Get
        Set(ByVal intValue As Integer)
            intCategoryIdCA = intValue
        End Set
    End Property

    Public Property CategoryNameCA() As String
        Get
            Return strCategoryNameCA
        End Get
        Set(ByVal strValue As String)
            strCategoryNameCA = strValue
        End Set
    End Property


    Public Property DescriptionCA() As String
        Get
            Return strDescriptionCA
        End Get
        Set(ByVal strValue As String)
            strDescriptionCA = strValue
        End Set
    End Property

End Class
