
Partial Class Member_frmSearch
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objUserDataCookie As HttpCookie

        Dim role As Integer
        Dim email As String


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

        Dim strSearch As String = ""


        strSearch = Request.QueryString("search")

        If Not (strSearch = String.Empty) Then


            Dim objArrayList As New ArrayList
            Dim objMovie As New CMovie

            objArrayList = objCDBMovies.getMovieBySearch(strSearch)


            Dim intNoOfMovies As Integer

            intNoOfMovies = objArrayList.Count

            If intNoOfMovies > 0 Then





                Dim row As Integer
                Dim column As Integer = 4

                row = Math.Floor(intNoOfMovies / column)

                '1 2 3 4 
                '5 6 7 8
                '9 

                'displayMovies.InnerHtml = intNoOfMovies & " " & row

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

            Else
                displayMovies.InnerHtml = "<b>No Results Found.</b>"

            End If

        Else
            displayMovies.InnerHtml = "<b>Please enter a movie to search.</b>"
        End If

    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click

        Dim search As String

        search = txtSearch.Text

        Response.Redirect("frmSearch.aspx?search=" & search)

    End Sub



End Class
