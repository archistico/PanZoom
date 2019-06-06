Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Form1
    Dim img As Image
    Dim mouseDown As Point
    Dim startx As Integer = 0  ' offset of image when mouse was pressed
    Dim starty As Integer = 0
    Dim imgx As Integer = 0  ' current offset of image
    Dim imgy As Integer = 0

    Dim mousepressed As Boolean = False  ' true as long as left mousebutton is pressed
    Dim zoom As Single = 1

    Dim imagefilename As String = "..\..\test.tif"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        img = Image.FromFile(imagefilename)
        Dim g As Graphics = Me.CreateGraphics()
        zoom = (pb.Width / img.Width) * (img.HorizontalResolution / g.DpiX)
    End Sub

    Private Sub pb_Paint(sender As Object, e As PaintEventArgs) Handles pb.Paint
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.ScaleTransform(zoom, zoom)
        e.Graphics.DrawImage(img, imgx, imgy)
    End Sub

    Private Sub Form1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        Dim oldzoom As Single = zoom
        If (e.Delta > 0) Then
            zoom = (zoom + 0.1!)
        ElseIf (e.Delta < 0) Then
            zoom = Math.Max((zoom - 0.1!), 0.01!)
        End If
        Dim mouse As MouseEventArgs = CType(e, MouseEventArgs)
        Dim mousePosNow As Point = mouse.Location
        Dim x As Integer = (mousePosNow.X - pb.Location.X)
        ' Where location of the mouse in the pictureframe
        Dim y As Integer = (mousePosNow.Y - pb.Location.Y)
        Dim oldimagex As Integer = CType((x / oldzoom), Integer)
        ' Where in the IMAGE is it now
        Dim oldimagey As Integer = CType((y / oldzoom), Integer)
        Dim newimagex As Integer = CType((x / zoom), Integer)
        ' Where in the IMAGE will it be when the new zoom i made
        Dim newimagey As Integer = CType((y / zoom), Integer)
        imgx = ((newimagex - oldimagex) _
                    + imgx)
        ' Where to move image to keep focus on one point
        imgy = ((newimagey - oldimagey) _
                    + imgy)
        pb.Refresh()
        ' calls imageBox_Paint
    End Sub
End Class
