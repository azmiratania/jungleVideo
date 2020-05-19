Imports Microsoft.VisualBasic

Public Class CMovie

    Private intDVDTitleIdDV As Integer
    Private strTitleDV As String
    Private strDescriptionDV As String
    Private strYearDV As String
    Private intMinuteDV As Integer
    Private strRatingCodeDV As String

    Public Property DVDTitleIdDV() As Integer
        Get
            Return intDVDTitleIdDV
        End Get
        Set(ByVal intValue As Integer)
            intDVDTitleIdDV = intValue
        End Set
    End Property

    Public Property TitleDV() As String
        Get
            Return strTitleDV
        End Get
        Set(ByVal strValue As String)
            strTitleDV = strValue
        End Set
    End Property



    Public Property DescriptionDV() As String
        Get
            Return strDescriptionDV
        End Get
        Set(ByVal strValue As String)
            strDescriptionDV = strValue
        End Set
    End Property

    Public Property YearDV() As String
        Get
            Return strYearDV
        End Get
        Set(ByVal strValue As String)
            strYearDV = strValue
        End Set
    End Property


    Public Property MinuteDV() As Integer
        Get
            Return intMinuteDV
        End Get
        Set(ByVal intValue As Integer)
            intMinuteDV = intValue
        End Set
    End Property

    Public Property RatingCodeDV() As String
        Get
            Return strRatingCodeDV
        End Get
        Set(ByVal strValue As String)
            strRatingCodeDV = strValue
        End Set
    End Property





End Class
