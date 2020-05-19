Imports Microsoft.VisualBasic

Public Class CActor

    Private intActorIdAC As Integer
    Private strFullNameAC As String
    
    Public Property ActorIdAC() As Integer
        Get
            Return intActorIdAC
        End Get
        Set(ByVal intValue As Integer)
            intActorIdAC = intValue
        End Set
    End Property


    Public Property FullNameAC() As String
        Get
            Return strFullNameAC
        End Get
        Set(ByVal strValue As String)
            strFullNameAC = strValue
        End Set
    End Property

End Class



