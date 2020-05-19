Imports Microsoft.VisualBasic

Public Class CUserInfo

    Private intUserIdUS As Integer
    Protected strEmailUS As String
    Protected strPasswordUS As String
    Protected strAddressUS As String
    Protected strPostalCodeUS As String
    Protected intSalutationIdUS As Integer
    Protected strFullNameUS As String
    Protected strNricUS As String
    Protected strContactUS As String
    Protected strRegistrationDateUS As String
    Protected strCreditCardUS As String
    Protected intRoleIdUS As Integer


    Public Property UserIdUS() As Integer
        Get
            Return intUserIdUS
        End Get
        Set(ByVal intValue As Integer)
            intUserIdUS = intValue
        End Set
    End Property


    Public Property EmailUS() As String
        Get
            Return strEmailUS
        End Get
        Set(ByVal strValue As String)
            strEmailUS = strValue
        End Set
    End Property


    Public Property PasswordUS() As String
        Get
            Return strPasswordUS
        End Get
        Set(ByVal strValue As String)
            strPasswordUS = strValue
        End Set
    End Property


    Public Property AddressUS() As String
        Get
            Return strAddressUS
        End Get
        Set(ByVal strValue As String)
            strAddressUS = strValue
        End Set
    End Property

    Public Property PostalCodeUS() As String
        Get
            Return strPostalCodeUS
        End Get
        Set(ByVal strValue As String)
            strPostalCodeUS = strValue
        End Set
    End Property


    Public Property SalutationIdUS() As Integer
        Get
            Return intSalutationIdUS
        End Get
        Set(ByVal strValue As Integer)
            intSalutationIdUS = strValue
        End Set
    End Property


    Public Property FullNameUS() As String
        Get
            Return strFullNameUS
        End Get
        Set(ByVal strValue As String)
            strFullNameUS = strValue
        End Set
    End Property


    Public Property NricUS() As String
        Get
            Return strNricUS
        End Get
        Set(ByVal strValue As String)
            strNricUS = strValue
        End Set
    End Property


    Public Property ContactUS() As String
        Get
            Return strContactUS
        End Get
        Set(ByVal strValue As String)
            strContactUS = strValue
        End Set
    End Property


    Public Property RegistrationDateUS() As String
        Get
            Return strRegistrationDateUS
        End Get
        Set(ByVal strValue As String)
            strRegistrationDateUS = strValue
        End Set
    End Property


    Public Property CreditCardUS() As String
        Get
            Return strCreditCardUS
        End Get
        Set(ByVal strValue As String)
            strCreditCardUS = strValue
        End Set
    End Property


    Public Property RoleIdUS() As Integer
        Get
            Return intRoleIdUS
        End Get
        Set(ByVal strValue As Integer)
            intRoleIdUS = strValue
        End Set
    End Property


End Class
