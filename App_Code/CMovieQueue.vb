Imports Microsoft.VisualBasic

Public Class CMovieQueue

    Private intMovieQueueIdMO As Integer
    Private intUserIdMO As Integer
    Private intTitleIdMO As Integer
    Private intSequenceMO As Integer
    Private blnIsPostedMO As Integer


    Public Property MovieQueueIdMO() As Integer
        Get
            Return intMovieQueueIdMO
        End Get
        Set(ByVal intValue As Integer)
            intMovieQueueIdMO = intValue
        End Set
    End Property

    Public Property UserIdMO() As Integer
        Get
            Return intUserIdMO
        End Get
        Set(ByVal intValue As Integer)
            intUserIdMO = intValue
        End Set
    End Property

    Public Property TitleIdMO() As Integer
        Get
            Return intTitleIdMO
        End Get
        Set(ByVal intValue As Integer)
            intTitleIdMO = intValue
        End Set
    End Property

    Public Property SequenceMO() As Integer
        Get
            Return intSequenceMO
        End Get
        Set(ByVal intValue As Integer)
            intSequenceMO = intValue
        End Set
    End Property

    Public Property IsPostedMO() As Integer
        Get
            Return blnIsPostedMO
        End Get
        Set(ByVal intValue As Integer)
            blnIsPostedMO = intValue
        End Set
    End Property


End Class
