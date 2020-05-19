
Partial Class Member_Functions_MovieDetails
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim role As Integer
        Dim email As String

        Dim objUserDataCookie As HttpCookie

        If Not (Request.Cookies("userdata") Is Nothing) Then

            objUserDataCookie = Request.Cookies("userdata")
            email = objUserDataCookie.Values("email")
            role = objUserDataCookie.Values("role")

            lblUserEmail.Text = email 'this is to welcome the user.

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

        Dim ID As Integer


        If Not (Request.QueryString("id") Is Nothing) Then

            ID = CInt(Request.QueryString("id"))

            Dim objArrayList As New ArrayList
            Dim objMovie As New CMovie

            objArrayList = objCDBMovies.getMovieByID(ID)

            objMovie = objArrayList.Item(0)

            Dim strTemp As String

            strTemp = "<table style=""width: 100%;""><tr><td id=""moviepic"" valign=""top"">"
            strTemp &= "<img src=""frmRetrieveImage.aspx?id={0}"" alt=""movie"" style=""margin-top: 0px;"" /><br /><br />"
            strTemp &= "<input type=""button"" name=""Button1"" value=""Add"" id=""Button1"" title=""Add to my movie queue."" onClick=""location.href='AddMovieTitle.aspx?id={0}'""/><br /></td>"
            strTemp &= "<td id=""moviedetail"" valign=""top"">"
            strTemp &= "{1}" 'Description
            strTemp &= "<br /><br /><table style=""width: 100%;""><tr><td><b>Actors:</b></td><td colspan=""3"">"
            strTemp &= "{2}" 'Actor
            strTemp &= "</td></tr><tr><td><b>Directors:</b></td><td>"
            strTemp &= "{3}" 'Director
            strTemp &= "</td><td><b>Year:</b></td><td>"
            strTemp &= "{4}" 'Year
            strTemp &= "</td></tr><tr><td><b>Studio:</b></td><td>"
            strTemp &= "{5}" 'Studio
            strTemp &= "</td><td><b>Time:</b></td><td>"
            strTemp &= "{6}" 'Time
            strTemp &= " mins"
            strTemp &= "</td></tr><tr><td><b>Category:</b></td><td>"
            strTemp &= "{7}" 'Category
            strTemp &= "</td><td><b>Rating:</b></td><td>"
            strTemp &= "{8}" 'Rating
            strTemp &= "</td></tr></table>"
            strTemp &= "</td></tr></table>"


            lblMovieTitle.Text = objMovie.TitleDV



            '###DISPLAY THE DETAILS OF THE MOVIE HERE!###
            Dim strActor As String = ""
            Dim objArrayListActor As New ArrayList


            Dim objActor As New CActor

            objArrayListActor = objCDBMovies.getActorByID(ID)

            Dim i As Integer = 0

            Try
                While Not objArrayListActor.Item(i).Equals("")

                    If i > 0 Then
                        strActor &= ", "
                    End If

                    objActor = New CActor
                    objActor = objArrayListActor.Item(i)
                    strActor &= objActor.FullNameAC


                    i += 1
                End While
            Catch

            End Try



            '//Director
            Dim strDirector As String = ""


            Dim objArrayListDirector As New ArrayList
            Dim objDirector As New CDirector

            objArrayListDirector = objCDBMovies.getDirectorsByID(ID)

            i = 0

            Try
                While Not objArrayListDirector.Item(i).Equals("")

                    If i > 0 Then
                        strDirector &= ", "
                    End If

                    objDirector = New CDirector
                    objDirector = objArrayListDirector.Item(i)
                    strDirector &= objDirector.FullNameDI

                    i += 1
                End While
            Catch
            End Try




            Dim strStudio As String = ""
            Dim objArrayListStudio As New ArrayList
            Dim objStudio As New CStudio

            objArrayListStudio = objCDBMovies.getStudioByID(ID)

            i = 0

            Try
                While Not objArrayListStudio.Item(i).Equals("")

                    If i > 0 Then
                        strStudio &= ", "
                    End If

                    objStudio = New CStudio
                    objStudio = objArrayListStudio.Item(i)
                    strStudio &= objStudio.StudioNameST
                    i += 1
                End While
            Catch
            End Try


            '//category
            Dim strCategory As String = ""
          
            Dim objArrayListCategory As New ArrayList
            Dim objCategory As New CCategory

            objArrayListCategory = objCDBMovies.getCategoryByID(ID)

            i = 0

            Try
                While Not objArrayListCategory.Item(i).Equals("")

                    If i > 0 Then
                        strCategory &= ", "
                    End If

                    objCategory = New CCategory
                    objCategory = objArrayListCategory.Item(i)
                    strCategory &= objCategory.CategoryNameCA


                    i += 1
                End While
            Catch
            End Try




            divMovieDetails.InnerHtml = String.Format(strTemp, objMovie.DVDTitleIdDV, objMovie.DescriptionDV, _
                                                      strActor, strDirector, objMovie.YearDV, strStudio, _
                                                      objMovie.MinuteDV, strCategory, objMovie.RatingCodeDV)





            '//Movies you might enjoy codes begin here. 

            objArrayList = objCDBMovies.getSimilarMovies(objMovie, objArrayListCategory, objArrayListActor, objArrayListDirector)




            Dim intNoOfMovies As Integer

            intNoOfMovies = objArrayList.Count



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


            Dim j As Integer
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
            Response.Redirect("ViewMovies.aspx")
        End If


    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click

        Dim search As String

        search = txtSearch.Text

        Response.Redirect("frmSearch.aspx?search=" & search)

    End Sub


End Class
