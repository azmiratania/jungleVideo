Imports Microsoft.VisualBasic

Public Class CJoinTable

    Private intJoinId As Integer
    Private intTitleId As Integer
    Private intACDId As Integer


    Public Property JoinId() As Integer
        Get
            Return intJoinId
        End Get
        Set(ByVal intValue As Integer)
            intJoinId = intValue
        End Set
    End Property

    Public Property TitleId() As Integer
        Get
            Return intTitleId
        End Get
        Set(ByVal intValue As Integer)
            intTitleId = intValue
        End Set
    End Property

    Public Property ACDId() As Integer
        Get
            Return intACDId
        End Get
        Set(ByVal intValue As Integer)
            intACDId = intValue
        End Set
    End Property









End Class
