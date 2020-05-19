
Partial Class Member_Functions_AddMovieTitle
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim role As Integer
        Dim email As String = ""

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

        '// End of checking for the cookie.

        '-------------------------------------------------------------------------------
        '##This is to display the category on the sidebar.

        Dim objCDBMovies As New CDBMovies
        Dim categoryName As String

        categoryName = objCDBMovies.getCategoryName

        lblSearchCategory.Text = "<ul>" + categoryName + "</ul>"

        '-------------------------------------------------------------------------------



        Dim ID As Integer

        If Not (Request.QueryString("id") Is Nothing) Then

            ID = CInt(Request.QueryString("id"))

            Dim objArrayList As New ArrayList
            Dim objMovie As New CMovie

            objArrayList = objCDBMovies.getMovieByID(ID)

            objMovie = objArrayList.Item(0)

            Dim IsPosted As Boolean
            IsPosted = objCDBMovies.existInQueue(ID)

            Dim objCDBUser As New CDBUserInfo
            Dim objUserInfo As New CUserInfo

            objUserInfo = objCDBUser.getMemberInfo(email)

            Dim noOfMoviesInQueue As Integer
            noOfMoviesInQueue = objCDBMovies.numOfMoviesInQueue(objUserInfo.UserIdUS) + 1

            If IsPosted Then
                lblMovieTitleHeader.Text = "Error"
                displayMovies.InnerHtml = "Movie already exist in movie queue."
                displayMovies.InnerHtml &= "<br /><br /><input type=""button"" name=""btnBack"" value=""Back"" id=""btnBack"" onClick=""location.href='ViewMovies.aspx'""/><br />"
            Else

                Dim objMovieQueue As New CMovieQueue

                With objMovieQueue

                    .UserIdMO = objUserInfo.UserIdUS
                    .TitleIdMO = objMovie.DVDTitleIdDV
                    .SequenceMO = noOfMoviesInQueue
                    .IsPostedMO = 0
                End With

                Dim numOfRowsAffected As Integer

                numOfRowsAffected = objCDBMovies.addMovieToQueue(objMovieQueue)

                If numOfRowsAffected > 0 Then
                    Dim strTemp As String

                    strTemp = "<table><tr><td>"
                    strTemp &= "Done! "
                    strTemp &= "<b>{0}</b>"
                    strTemp &= " has been added to Your Movie Queue. To maximise your membership benefits and to make sure "
                    strTemp &= "you always have movies ready at home,we encourage you to keep Your Movie Queue full!<br/><br/>You now have "
                    strTemp &= "<b>{1}</b>"
                    strTemp &= " movies in Your Movie Queue.<br /><br />"
                    strTemp &= "<input type=""button"" name=""btnBack"" value=""Back"" id=""btnBack"" onClick=""location.href='ViewMovies.aspx'""/><br /></td>"
                    strTemp &= "<td><img src=""frmRetrieveImage.aspx?id={2}"" alt=""movie"" style=""margin-top: 0px;"" /><br /><br /></td></tr>"
                    strTemp &= "</table>"

                    displayMovies.InnerHtml = String.Format(strTemp, objMovie.TitleDV, noOfMoviesInQueue, objMovie.DVDTitleIdDV)
                    lblMovieTitleHeader.Text = objMovie.TitleDV & " Added To Your Movie Queue!"
                Else
                    lblMovieTitleHeader.Text = "Error"
                    displayMovies.InnerHtml = "Movie could not be added due to database error."
                    displayMovies.InnerHtml &= "<br /><br /><input type=""button"" name=""btnBack"" value=""Back"" id=""btnBack"" onClick=""location.href='ViewMovies.aspx'""/><br />"
                End If


            End If

        Else

            Response.Redirect("ViewMovies.aspx")


        End If


    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click

        Dim search As String

        search = txtSearch.Text

        Response.Redirect("frmSearch.aspx?search=" & search)
    End Sub
End Class
