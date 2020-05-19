Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Linq
Imports System.Data


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class AutoCompleteWebServices
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function getMemberList(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim returnList As New List(Of String)
        '
        'Try


        Dim cs As String = ConfigurationManager.ConnectionStrings("AJAXExperimentDB").ConnectionString
        Dim context As DataClassesDataContext = New DataClassesDataContext(cs)
        context.Connection.Open()

        For Each ClubMember In (From c In context.Members Where c.FullName.StartsWith(prefixText) Select c.FullName Distinct Take (6))
            returnList.Add(ClubMember)
        Next

        '   Catch ex As Exception

        '  End Try

        Return returnList.ToArray()

    End Function

    <WebMethod()> _
    Public Function getCategoryList(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim returnList As New List(Of String)
        '
        'Try


        Dim cs As String = ConfigurationManager.ConnectionStrings("AJAXExperimentDB").ConnectionString
        Dim context As DataClassesDataContext = New DataClassesDataContext(cs)
        context.Connection.Open()

        For Each CategoryData In (From c In context.CCTitleCategories Where c.Title.StartsWith(prefixText) Select c.Title Distinct Take (6))
            returnList.Add(CategoryData)
        Next

        '   Catch ex As Exception

        '  End Try

        Return returnList.ToArray()

    End Function

End Class
