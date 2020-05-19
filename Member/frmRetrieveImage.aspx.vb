Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System
Public Class frmRetrieveImage
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim intId As Integer = Request.QueryString("id")

        Dim objCn As New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=DIT-NB0839408\SQLEXPRESS;Initial Catalog=JungleVideoDB;Persist Security Info=True;User ID=sa;password=12345678;")

        objCn.Open()


        'Read blobs into memory (1 record at a time)
        Dim objCom As New OleDb.OleDbCommand("SELECT binImageTI FROM tblTitleImage Where intTitleImageIdTI=" & intId, objCn)
        Dim objDataReader As OleDb.OleDbDataReader
        objDataReader = objCom.ExecuteReader

        Do While objDataReader.Read
            'To fill the memstream object (required to build the imgFull image object, we need to _
            'first read the blob into a byte_array..

            Dim bytImage(objDataReader(0).length - 1) As Byte
            bytImage = objDataReader(0)
            'Create the mememorystream object and fill it with the byte array
            Dim memStream As New MemoryStream(bytImage)
            'Declare the GetThumbnameImageAbort object and then pass it the address of the callback routine
            Dim dummyCallBack As System.Drawing.Image.GetThumbnailImageAbort
            dummyCallBack = New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
            'Create bothe image ojects.. the first one to fill with the database image, the second to 
            'hold the scaled instance of the full image
            Dim imgFull As System.Drawing.Image
            Dim imgSmall As System.Drawing.Image
            'Fill the big image
            imgFull = System.Drawing.Image.FromStream(memStream)
            'Create the small image by calling the GetThumbnailImage method of the large file specifying output size of 150 w 100 h 
            'imgSmall = imgFull.GetThumbnailImage(150, 100, dummyCallBack, 0)

            Response.Clear()
            'Response.ContentType = "image/gif"
            'imgSmall.Save(Response.OutputStream, Imaging.ImageFormat.Gif)
            Response.ContentType = "image/jpg"
            imgFull.Save(Response.OutputStream, Drawing.Imaging.ImageFormat.Jpeg)
        Loop

        objCn.Close()
        objCn.Dispose()

    End Sub
    Function ThumbnailCallback() As Boolean
        Return False
    End Function

End Class
