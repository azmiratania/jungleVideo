Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class CDBMovies
    Const CONNSTRING As String = "Data Source=DIT-NB0839408\SQLEXPRESS;Initial Catalog=JungleVideoDB;Persist Security Info=True;User ID=sa;password=12345678"



    Function getCategoryName() As String

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow
        Dim categoryName As String = ""
        Dim strFormatName As String = ""



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblCategory "

        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")

        strFormatName = " <li><a href=""ViewMovies.aspx?category={0}"">{0}</a></li>"



        For Each objDr In objDs.Tables("tblData").Rows

            categoryName += String.Format(strFormatName, objDr.Item("strCategoryNameCA"))

        Next


        objCn.Close()

        Return categoryName

    End Function


    Function getMovieByCategory(ByVal category As String) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow



        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblDVDTitle d, tblCategory c, tblTitle_Category tc " & _
                             "WHERE c.strCategoryNameCA = '" & category & "' " & _
                             "AND c.intCategoryIdCA = tc.intCategoryIdTC " & _
                             "AND tc.intTitleIdTC = d.intDVDTitleIdDV"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next
        objCn.Close()

        Return objArrayList

    End Function


    Function getMovieByActor(ByVal search As String) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow



        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        'objCmd.CommandText = "SELECT * FROM tblActor a, tblDirector d, tblDVDTitle t,tblTitle_Actor ta,tblTitle_Director td " & _
        '                     "WHERE (a.strFullNameAC LIKE '%" & search & "%' AND  a.intActorIdAC = ta.intActorIdTA AND ta.intTitleIdTA = t.intDVDTitleIdDV)" & _
        '                     "OR (d.strFullNameDI LIKE '%" & search & "%' AND  d.intDirectorIdDI = td.intDirectorIdTD AND td.intTitleIdTD = t.intDVDTitleIdDV)" & _
        '                     "OR t.strTitleDV LIKE '%" & search & "%'"




        objCmd.CommandText = "SELECT * FROM tblActor a, tblDVDTitle t,tblTitle_Actor ta " & _
                             "WHERE a.strFullNameAC LIKE '%" & search & "%' AND  a.intActorIdAC = ta.intActorIdTA AND ta.intTitleIdTA = t.intDVDTitleIdDV"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next





        objCn.Close()

        Return objArrayList

    End Function


    Function getMovieByDirector(ByVal search As String) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow



        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn


        objCmd.CommandText = "SELECT * FROM tblDirector d,tblDVDTitle t,tblTitle_Director td" & _
                             " WHERE d.strFullNameDI LIKE '%" & search & "%' AND  d.intDirectorIdDI = td.intDirectorIdTD AND td.intTitleIdTD = t.intDVDTitleIdDV"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next





        objCn.Close()

        Return objArrayList

    End Function

    Function getMovieByTitle(ByVal search As String) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow



        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        'MY COMPUTER CANNOT HANDLE THIS SQL STATEMENT :(
        'objCmd.CommandText = "SELECT * FROM tblActor a, tblDirector d, tblDVDTitle t,tblTitle_Actor ta,tblTitle_Director td " & _
        '                     "WHERE (a.strFullNameAC LIKE '%" & search & "%' AND  a.intActorIdAC = ta.intActorIdTA AND ta.intTitleIdTA = t.intDVDTitleIdDV)" & _
        '                     "OR (d.strFullNameDI LIKE '%" & search & "%' AND  d.intDirectorIdDI = td.intDirectorIdTD AND td.intTitleIdTD = t.intDVDTitleIdDV)" & _
        '                     "OR t.strTitleDV LIKE '%" & search & "%'"




        objCmd.CommandText = "SELECT * FROM tblDVDTitle t WHERE t.strTitleDV LIKE '%" & search & "%'"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next





        objCn.Close()

        Return objArrayList

    End Function


    Function getMovieBySearch(ByVal search As String) As ArrayList

        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList
        Dim objArrayListActor As New ArrayList
        Dim objArrayListDirector As New ArrayList
        Dim objArrayListTitle As New ArrayList

        objArrayListActor = getMovieByActor(search)
        objArrayListDirector = getMovieByDirector(search)
        objArrayListTitle = getMovieByTitle(search)

        Dim intMovieByActor As Integer
        Dim intMovieByDirector As Integer
        Dim intMovieByTitle As Integer

        intMovieByActor = objArrayListActor.Count
        intMovieByDirector = objArrayListDirector.Count
        intMovieByTitle = objArrayListTitle.Count

        Dim i As Integer

        For i = 0 To (intMovieByActor - 1)

            objMovie = New CMovie

            objMovie = objArrayListActor.Item(i)

            objArrayList.Add(objMovie)
        Next


        For i = 0 To (intMovieByDirector - 1)

            objMovie = New CMovie

            objMovie = objArrayListDirector.Item(i)

            objArrayList.Add(objMovie)
        Next


        For i = 0 To (intMovieByTitle - 1)

            objMovie = New CMovie

            objMovie = objArrayListTitle.Item(i)

            objArrayList.Add(objMovie)
        Next


        Dim j As Integer = 0
        Dim objMovie1 As CMovie
        Dim objMovie2 As CMovie

        '0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20
        '1 1 1 1 4 2 2 4 2 2 3 3 3 4 3 


        For i = 0 To (objArrayList.Count - 1)
            For j = (objArrayList.Count - 1) To (i + 1) Step -1
                objMovie1 = New CMovie
                objMovie2 = New CMovie

                objMovie1 = objArrayList.Item(i)
                objMovie2 = objArrayList.Item(j)

                If (objMovie1.DVDTitleIdDV = objMovie2.DVDTitleIdDV) Then
                    objArrayList.RemoveAt(i)
                End If
            Next

        Next

        For i = 0 To (objArrayList.Count - 1)
            For j = (objArrayList.Count - 1) To (i + 1) Step -1
                objMovie1 = New CMovie
                objMovie2 = New CMovie

                objMovie1 = objArrayList.Item(i)
                objMovie2 = objArrayList.Item(j)

                If (objMovie1.DVDTitleIdDV = objMovie2.DVDTitleIdDV) Then
                    objArrayList.RemoveAt(i)
                End If
            Next

        Next


        Return objArrayList

    End Function


    Function getAllMovie() As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow



        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        'objCmd.CommandText = "SELECT * FROM tblActor a, tblDirector d, tblDVDTitle t,tblTitle_Actor ta,tblTitle_Director td " & _
        '                     "WHERE (a.strFullNameAC LIKE '%" & search & "%' AND  a.intActorIdAC = ta.intActorIdTA AND ta.intTitleIdTA = t.intDVDTitleIdDV)" & _
        '                     "OR (d.strFullNameDI LIKE '%" & search & "%' AND  d.intDirectorIdDI = td.intDirectorIdTD AND td.intTitleIdTD = t.intDVDTitleIdDV)" & _
        '                     "OR t.strTitleDV LIKE '%" & search & "%'"




        objCmd.CommandText = "SELECT * FROM tblDVDTitle"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next





        objCn.Close()

        Return objArrayList

    End Function

    Function getMovieByID(ByVal ID As Integer) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow



        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblDVDTitle  WHERE intDVDTitleIdDV = " & ID & " "



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next
        objCn.Close()

        Return objArrayList

    End Function

    Function getActorByID(ByVal id As Integer) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow


        Dim objActor As New CActor
        Dim objArrayList As New ArrayList

        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblActor a,tblTitle_Actor ta " & _
                             "WHERE ta.intTitleIdTA = " & id & " AND ta.intActorIdTA = a.intActorIdAC"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objActor = New CActor

            With objActor

                .ActorIdAC = objDr.Item("intActorIdAC")
                .FullNameAC = objDr.Item("strFullNameAC")
            End With


            objArrayList.Add(objActor)
        Next
        objCn.Close()

        Return objArrayList

    End Function

    Function getDirectorsByID(ByVal id As Integer) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow


        Dim objDirector As New CDirector
        Dim objArrayList As New ArrayList

        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblDirector d,tblTitle_Director td " & _
                             "WHERE td.intTitleIdTD = " & id & " AND td.intDirectorIdTD = d.intDirectorIdDI"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objDirector = New CDirector

            With objDirector

                .DirectorIdDI = objDr.Item("intDirectorIdDI")
                .FullNameDI = objDr.Item("strFullNameDI")
            End With


            objArrayList.Add(objDirector)
        Next
        objCn.Close()

        Return objArrayList

    End Function

    Function getCategoryByID(ByVal id As Integer) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow


        Dim objCategory As New CCategory
        Dim objArrayList As New ArrayList

        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblCategory c,tblTitle_Category tc " & _
                             "WHERE tc.intTitleIdTC = " & id & " AND tc.intCategoryIdTC = c.intCategoryIdCA"

        objAd.SelectCommand = objCmd

        objAd.Fill(objDs, "tblData")

        For Each objDr In objDs.Tables("tblData").Rows

            objCategory = New CCategory

            With objCategory

                .CategoryIdCA = objDr.Item("intCategoryIdCA")
                .CategoryNameCA = objDr.Item("strCategoryNameCA")
                .DescriptionCA = objDr.Item("strDescriptionCA")
            End With

            objArrayList.Add(objCategory)
        Next
        objCn.Close()

        Return objArrayList

    End Function

    Function getStudioByID(ByVal id As Integer) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow


        Dim objStudio As New CStudio
        Dim objArrayList As New ArrayList

        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblStudio s,tblTitle_Studio ts " & _
                             "WHERE ts.intTitleIdTS = " & id & " AND ts.intStudioIdTS = s.intStudioIdST"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objStudio = New CStudio

            With objStudio

                .StudioIdST = objDr.Item("intStudioIdST")
                .StudioNameST = objDr.Item("strStudioNameST")
            End With


            objArrayList.Add(objStudio)
        Next
        objCn.Close()

        Return objArrayList

    End Function

    Function getMovieByDirectorId(ByVal id As Integer) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow

        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblDVDTitle d, tblTitle_Director td " & _
                             "WHERE td.intDirectorIdTD = " & id & " AND td.intTitleIdTD = d.intDVDTitleIdDV"


        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next
        objCn.Close()

        Return objArrayList

    End Function

    Function getMovieByActorId(ByVal id As Integer) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow

        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblDVDTitle d, tblTitle_Actor ta " & _
                             "WHERE ta.intActorIdTA = " & id & " AND ta.intTitleIdTA = d.intDVDTitleIdDV"


        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next
        objCn.Close()

        Return objArrayList

    End Function


    Function getMovieByCategoryId(ByVal id As Integer) As ArrayList

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow

        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList



        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblDVDTitle d, tblTitle_Category tc " & _
                             "WHERE tc.intCategoryIdTC = " & id & " AND tc.intTitleIdTC = d.intDVDTitleIdDV"



        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")


        For Each objDr In objDs.Tables("tblData").Rows

            objMovie = New CMovie

            With objMovie

                .DVDTitleIdDV = objDr.Item("intDVDTitleIdDV")
                .TitleDV = objDr.Item("strTitleDV")
                .DescriptionDV = objDr.Item("strDescriptionDV")
                .YearDV = objDr.Item("strYearDV")
                .MinuteDV = objDr.Item("intMinuteDV")
                .RatingCodeDV = objDr.Item("strRatingCodeDV")


            End With


            objArrayList.Add(objMovie)


        Next
        objCn.Close()

        Return objArrayList

    End Function

    Function getSimilarMovies(ByVal thisMovie As CMovie, ByVal ALCatergory As ArrayList, _
                              ByVal ALActor As ArrayList, ByVal ALDirector As ArrayList) _
                              As ArrayList

        Dim objMovie As New CMovie
        Dim objArrayList As New ArrayList


        Dim objMovie1 As CMovie
        Dim objMovie2 As CMovie

        Dim objArrayListCategory As New ArrayList
        Dim objArrayListActor As New ArrayList
        Dim objArrayListDirector As New ArrayList
        Dim objtempArrayList As New ArrayList
        Dim count As Integer


        Dim objCategory As New CCategory
        Dim objActor As New CActor
        Dim objDirector As New CDirector

        Dim i, j, k As Integer

        'this is for category 
        For k = 0 To (ALCatergory.Count - 1)
            objtempArrayList = New ArrayList
            objCategory = New CCategory
            objCategory = ALCatergory.Item(k)

            objtempArrayList = getMovieByCategoryId(objCategory.CategoryIdCA)
            count = objtempArrayList.Count

            For i = 0 To (count - 1)

                objMovie = New CMovie

                objMovie = objtempArrayList.Item(i)

                objArrayListDirector.Add(objMovie)
            Next
        Next



        'this is for actor //
        For k = 0 To (ALActor.Count - 1)

            objtempArrayList = New ArrayList
            objActor = New CActor
            objActor = ALActor.Item(k)
            objtempArrayList = getMovieByActorId(objActor.ActorIdAC)
            count = objtempArrayList.Count

            For i = 0 To (count - 1)

                objMovie = New CMovie

                objMovie = objtempArrayList.Item(i)

                objArrayListActor.Add(objMovie)
            Next
        Next

        'this for loop is for the director //

        For k = 0 To (ALDirector.Count - 1)

            objtempArrayList = New ArrayList
            objDirector = New CDirector
            objDirector = ALDirector.Item(k)
            objtempArrayList = getMovieByDirectorId(objDirector.DirectorIdDI)
            count = objtempArrayList.Count

            For i = 0 To (count - 1)

                objMovie = New CMovie

                objMovie = objtempArrayList.Item(i)

                objArrayListDirector.Add(objMovie)
            Next
        Next

        '----------







        Dim intMovieByCategory As Integer
        Dim intMovieByActor As Integer
        Dim intMovieByDirector As Integer

        intMovieByCategory = objArrayListCategory.Count
        intMovieByActor = objArrayListActor.Count
        intMovieByDirector = objArrayListDirector.Count




        For i = 0 To (intMovieByActor - 1)

            objMovie = New CMovie

            objMovie = objArrayListActor.Item(i)

            objArrayList.Add(objMovie)
        Next


        For i = 0 To (intMovieByDirector - 1)

            objMovie = New CMovie

            objMovie = objArrayListDirector.Item(i)

            objArrayList.Add(objMovie)
        Next


        For i = 0 To (intMovieByCategory - 1)

            objMovie = New CMovie

            objMovie = objArrayListCategory.Item(i)

            objArrayList.Add(objMovie)
        Next

        '//Important code to ensure there is no repetition in the image & that the current movie is not suggested.

        For k = 0 To 10
            For i = 0 To (objArrayList.Count - 1)
                For j = (objArrayList.Count - 1) To (i + 1) Step -1

                    objMovie1 = New CMovie
                    objMovie2 = New CMovie

                    objMovie1 = objArrayList.Item(i)
                    objMovie2 = objArrayList.Item(j)

                    If (objMovie1.DVDTitleIdDV = objMovie2.DVDTitleIdDV) Then
                        objArrayList.RemoveAt(i)
                    ElseIf (objMovie1.DVDTitleIdDV = thisMovie.DVDTitleIdDV) Then
                        objArrayList.RemoveAt(i)
                    ElseIf (objMovie2.DVDTitleIdDV = thisMovie.DVDTitleIdDV) Then
                        objArrayList.RemoveAt(j)
                    End If

                Next
            Next
        Next

        Return objArrayList

    End Function

    

    

    Public Function addMovieToQueue(ByVal objMovieQueue As CMovieQueue) As Integer

        Dim objCmd As New SqlCommand
        Dim objCn As New SqlConnection


        objCn.ConnectionString = CONNSTRING
        objCmd.Connection = objCn

        objCn.Open()


        Dim strSQL As String

        strSQL = "INSERT INTO tblMovieQueue " & _
                 "(intUserIdMO , intTitleIdMO , intSequenceMO , blnIsPostedMO) " & _
                 "values ({0},{1},{2},{3})"

        objCmd.CommandText = String.Format(strSQL, objMovieQueue.UserIdMO, objMovieQueue.TitleIdMO, _
                                           objMovieQueue.SequenceMO, objMovieQueue.IsPostedMO)


        Dim intNumOfRecordsAffected As Integer

        intNumOfRecordsAffected = objCmd.ExecuteNonQuery()

        objCn.Close()

        Return intNumOfRecordsAffected



    End Function

    
    Function numOfMoviesInQueue(ByVal userId As Integer) As Integer

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow

        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblMovieQueue WHERE intUserIdMO=" & userId & ""

        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")

        Dim i As Integer = 0

        For Each objDr In objDs.Tables("tblData").Rows

            i += 1
        Next
        objCn.Close()

        Return i

    End Function


    Function existInQueue(ByVal id As Integer) As Integer

        Dim objCn As New SqlConnection
        Dim objCmd As New SqlCommand
        Dim objAd As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objDr As DataRow

        objCn.ConnectionString = CONNSTRING

        objCmd.Connection = objCn

        objCmd.CommandText = "SELECT * FROM tblMovieQueue WHERE intTitleIdMO=" & id & ""

        objAd.SelectCommand = objCmd


        objAd.Fill(objDs, "tblData")

        Dim i As Integer = 0

        For Each objDr In objDs.Tables("tblData").Rows

            i += 1
        Next
        objCn.Close()

        Return i

    End Function

End Class
