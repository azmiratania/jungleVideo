
Partial Class Member_Functions_ViewMovies
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim role As Integer
        Dim email As String

        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("userdata") Is Nothing) Then

            objUserDataCookie = Request.Cookies("userdata")
            email = objUserDataCookie.Values("email")
            role = objUserDataCookie.Values("role")

            lblUserEmail.Text = email

            If Not (role = 2) Then
                Response.Redirect("../login.aspx")
            End If

        Else
            Response.Redirect("../login.aspx")
        End If



        '-------------------------------------------------------------------------------
        '##This is to display the category on the sidebar.

        Dim objCDBMovies As New CDBMovies
        Dim categoryName As String

        categoryName = objCDBMovies.getCategoryName

        lblSearchCategory.Text = "<ul>" + categoryName + "</ul>"

        '-------------------------------------------------------------------------------

        Dim strCategory As String = ""
        Dim objArrayList As New ArrayList
        Dim objMovie As New CMovie

        strCategory = Request.QueryString("category")

        If Not (strCategory = String.Empty) Then

            lblCurrentCategory.Text += "<h2>" + strCategory + "</h2>"

            objArrayList = objCDBMovies.getMovieByCategory(strCategory)
        Else

            objArrayList = objCDBMovies.getAllMovie

        End If

        Dim intNoOfMovies As Integer

        intNoOfMovies = objArrayList.Count

        Dim row As Integer
        Dim column As Integer = 4

        row = Math.Floor(intNoOfMovies / column)

        displayMovies.InnerHtml = "<table style=""width: 100%;"">"


        Dim formatRow As String = "<a href=""MovieDetails.aspx?id={0}""> " & _
                                  "<img src=""frmRetrieveImage.aspx?id={0}"" alt=""movie"" align=""middle"" /></a><br /><br />" & _
                                  "<input type=""button"" name=""btnAdd"" value=""Add"" id=""btnAdd"" onClick=""location.href='MovieDetails.aspx?id={0}'""/><br />" & _
                                  "<br />" & _
                                  "<a href=""MovieDetails.aspx?id={0}"">{1}" & _
                                  "</a>"

        Dim i, j As Integer
        Dim position As Integer

        For i = 0 To row
            displayMovies.InnerHtml &= "<tr>"

            For j = 1 To column
                displayMovies.InnerHtml &= "<td class=""movie"">"
                position = (4 * i) + j
                If (position <= intNoOfMovies) Then
                    objMovie = New CMovie

                    objMovie = objArrayList.Item(position - 1)
                    displayMovies.InnerHtml &= String.Format(formatRow, objMovie.DVDTitleIdDV, objMovie.TitleDV)

                End If

                displayMovies.InnerHtml &= "</td>"
            Next
            displayMovies.InnerHtml &= "</tr>"
        Next
        displayMovies.InnerHtml &= "</table>"

    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click

        Dim search As String

        search = txtSearch.Text

        Response.Redirect("frmSearch.aspx?search=" & search)

    End Sub
End Class
