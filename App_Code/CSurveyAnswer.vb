Imports Microsoft.VisualBasic

Public Class CSurveyAnswer

    Private intSurveryAnswerIdSU As Integer
    Private strAnswerSU As String
    Private intSequenceSU As Integer

    Public Property SurveryAnswerId() As Integer
        Get
            Return intSurveryAnswerIdSU
        End Get
        Set(ByVal intValue As Integer)
            intSurveryAnswerIdSU = intValue
        End Set
    End Property

    Public Property AnswerSU() As String
        Get
            Return strAnswerSU
        End Get
        Set(ByVal strValue As String)
            strAnswerSU = strValue
        End Set
    End Property

    Public Property SequenceSU() As Integer
        Get
            Return intSequenceSU
        End Get
        Set(ByVal intValue As Integer)
            intSequenceSU = intValue
        End Set
    End Property



End Class
