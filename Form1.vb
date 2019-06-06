Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Form1
    Const AmbienteLarghezza As Integer = 30
    Const AmbienteAltezza As Integer = 30
    Const pxCella As Integer = 75

    Dim scena As Ambiente = New Ambiente(AmbienteLarghezza, AmbienteAltezza)
    Dim automa As Automi = New Automi

    Private immagine As Image
    Private nomeImmagine As String = "..\..\test.tif"

    Private startx As Integer = 0  ' offset of image when mouse was pressed
    Private starty As Integer = 0
    Private imgx As Integer = 0  ' current offset of image
    Private imgy As Integer = 0

    Private mouseCoord As Point
    Private mousepremuto As Boolean = False  ' true as long as left mousebutton is pressed
    Private zoom As Single = 1

    Private CellaH As Integer = 75
    Private CellaV As Integer = 75

    Private g As Graphics = Me.CreateGraphics()
    Private tempo As Integer = 0

    Private AutomaX, AutomaY As Integer
    Private riempimento As Brush
    Private linea As Brush

    Private Giallo As Brush = New Drawing.SolidBrush(Color.FromArgb(255, 255, 0))
    Private GialloScuro As Brush = New Drawing.SolidBrush(Color.FromArgb(100, 100, 0))
    Private Rosso As Brush = New Drawing.SolidBrush(Color.FromArgb(255, 0, 0))
    Private RossoScuro As Brush = New Drawing.SolidBrush(Color.FromArgb(100, 0, 0))
    Private Blu As Brush = New Drawing.SolidBrush(Color.FromArgb(0, 225, 255))
    Private BluScuro As Brush = New Drawing.SolidBrush(Color.FromArgb(0, 90, 100))
    Private Verde As Brush = New Drawing.SolidBrush(Color.FromArgb(0, 255, 0))
    Private VerdeScuro As Brush = New Drawing.SolidBrush(Color.FromArgb(0, 100, 0))
    Private Grigio As Brush = New Drawing.SolidBrush(Color.FromArgb(235, 235, 235))
    Private GrigioScuro As Brush = New Drawing.SolidBrush(Color.FromArgb(100, 100, 100))


    Private Sub TerrenoBase()
        '-----SETTA IL TERRENO DI BASE------
        '----------OSTACOLI-----------------

        'Disegno i bordi come ostacoli
        For i As Integer = 0 To AmbienteLarghezza - 1
            scena.Cella(i, 0).stato = 4
            scena.Cella(i, AmbienteAltezza - 1).stato = 4
        Next

        For i As Integer = 1 To AmbienteAltezza - 2
            scena.Cella(0, i).stato = 4
            scena.Cella(AmbienteLarghezza - 1, i).stato = 4
        Next

        scena.Cella(18, 1).stato = 4
        scena.Cella(18, 2).stato = 4
        scena.Cella(2, 5).stato = 4
        scena.Cella(2, 6).stato = 4
        scena.Cella(2, 7).stato = 4
        scena.Cella(2, 8).stato = 4
        scena.Cella(8, 13).stato = 4
        scena.Cella(9, 13).stato = 4
        scena.Cella(13, 14).stato = 4
        scena.Cella(13, 10).stato = 4
        scena.Cella(14, 10).stato = 4
        scena.Cella(15, 10).stato = 4
        scena.Cella(16, 10).stato = 4
        scena.Cella(17, 10).stato = 4
        scena.Cella(18, 10).stato = 4
        scena.Cella(19, 10).stato = 4
        scena.Cella(13, 11).stato = 4
        scena.Cella(13, 12).stato = 4
        scena.Cella(13, 14).stato = 4
        scena.Cella(13, 5).stato = 4
        scena.Cella(16, 5).stato = 4
        scena.Cella(13, 6).stato = 4
        scena.Cella(14, 6).stato = 4
        scena.Cella(15, 6).stato = 4
        scena.Cella(16, 6).stato = 4
        '----------CIBO-----------------
        scena.Cella(14, 2).stato = 3
        scena.Cella(2, 3).stato = 3
        scena.Cella(19, 2).stato = 3
        scena.Cella(4, 10).stato = 3
        scena.Cella(9, 12).stato = 3
        scena.Cella(16, 8).stato = 3
        scena.Cella(16, 13).stato = 3
        '----------ACQUA---------------
        scena.Cella(8, 4).stato = 2
        scena.Cella(6, 5).stato = 2
        scena.Cella(7, 5).stato = 2
        scena.Cella(8, 5).stato = 2
        scena.Cella(10, 5).stato = 2
        scena.Cella(7, 6).stato = 2
        scena.Cella(8, 6).stato = 2
        scena.Cella(9, 6).stato = 2
        scena.Cella(10, 6).stato = 2
        scena.Cella(7, 7).stato = 2
        scena.Cella(8, 7).stato = 2
        scena.Cella(7, 8).stato = 2
        '---------PERICOLO-----------
        scena.Cella(14, 5).stato = 5
    End Sub

    Private Sub pb_Paint(sender As Object, e As PaintEventArgs) Handles pb.Paint
        Dim g As Graphics = e.Graphics

        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.ScaleTransform(zoom, zoom)
        'g.DrawImage(immagine, imgx, imgy)

        'g.FillRectangle(Brushes.Red, imgx + CellaH * tempo, imgy, CellaH, CellaV)
        'For i As Integer = 0 To 20 - 1
        '    g.DrawRectangle(Pens.Black, imgx + CellaH * i, imgy, CellaH, CellaV)
        'Next

        '--------------------------------------------
        '-----------DISEGNA AMBIENTE-----------------
        '--------------------------------------------
        Dim tipoCella As Brush = Brushes.Black
        For colonna = 0 To AmbienteLarghezza - 1
            For riga = 0 To AmbienteAltezza - 1
                Select Case scena.Cella(colonna, riga).stato
                    Case 0
                        'Vuoto
                        tipoCella = Brushes.Black
                    Case 1
                        'Occupato
                        tipoCella = Brushes.Gray
                    Case 2
                        'Acqua
                        tipoCella = Brushes.Blue
                    Case 3
                        'Cibo
                        tipoCella = Brushes.Green
                    Case 4
                        'Ostacolo
                        tipoCella = Brushes.SandyBrown
                    Case 5
                        'Pericolo
                        tipoCella = Brushes.Red
                End Select
                g.FillRectangle(tipoCella, imgx + colonna * pxCella, imgy + riga * pxCella, pxCella, pxCella)
                g.DrawRectangle(Pens.White, imgx + colonna * pxCella, imgy + riga * pxCella, pxCella, pxCella)
            Next
        Next

        '--------------------------------------------
        '--------------------------------------------
        '-----------CICLA PER OGNI AUTOMA------------
        '--------------------------------------------
        '--------------------------------------------

        'Trova la cella dell'automa
        AutomaX = automa.posX * pxCella
        AutomaY = automa.posY * pxCella


        '---------------------------------------------
        '---------SFONDO AUTOMA-----------------------
        '---------------------------------------------
        g.FillRectangle(Brushes.Black, imgx + AutomaX + 1, imgy + AutomaY + 1, 74, 74)

        '---------------------------------------------
        '---------SENSORI-----------------------------
        '---------------------------------------------

        '--------CIBO---------

        'CIBO ALTO
        If automa.CiboSu Then
            riempimento = Rosso
        Else
            riempimento = RossoScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 8, imgy + AutomaY + 1, 59, 5)

        'CIBO ANGOLO ALTO DX
        If automa.CiboSuDx Then
            riempimento = Rosso
        Else
            riempimento = RossoScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 69, imgy + AutomaY + 1, 5, 5)

        'CIBO ANGOLO ALTO SX
        If automa.CiboSuSx Then
            riempimento = Rosso
        Else
            riempimento = RossoScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 1, imgy + AutomaY + 1, 5, 5)

        'CIBO SX
        If automa.CiboSx Then
            riempimento = Rosso
        Else
            riempimento = RossoScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 1, imgy + AutomaY + 8, 5, 59)

        'CIBO DX
        If automa.CiboDx Then
            riempimento = Rosso
        Else
            riempimento = RossoScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 69, imgy + AutomaY + 8, 5, 59)

        'CIBO GIU
        If automa.CiboGiu Then
            riempimento = Rosso
        Else
            riempimento = RossoScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 8, imgy + AutomaY + 69, 59, 5)

        'CIBO ANGOLO BASSO DX
        If automa.CiboGiuDx Then
            riempimento = Rosso
        Else
            riempimento = RossoScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 69, imgy + AutomaY + 69, 5, 5)

        'CIBO ANGOLO BASSO SX
        If automa.CiboGiuSx Then
            riempimento = Rosso
        Else
            riempimento = RossoScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 1, imgy + AutomaY + 69, 5, 5)

        '--------ACQUA---------

        'ACQUA ALTO
        If automa.acquaSu Then
            riempimento = Blu
        Else
            riempimento = BluScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 15, imgy + AutomaY + 8, 45, 5)

        'ACQUA ANGOLO ALTO DX
        If automa.AcquaSuDx Then
            riempimento = Blu
        Else
            riempimento = BluScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 62, imgy + AutomaY + 8, 5, 5)

        'ACQUA ANGOLO ALTO SX
        If automa.AcquaSuSx Then
            riempimento = Blu
        Else
            riempimento = BluScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 8, imgy + AutomaY + 8, 5, 5)

        'ACQUA SX
        If automa.AcquaSx Then
            riempimento = Blu
        Else
            riempimento = BluScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 8, imgy + AutomaY + 15, 5, 45)

        'ACQUA DX
        If automa.AcquaDx Then
            riempimento = Blu
        Else
            riempimento = BluScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 62, imgy + AutomaY + 15, 5, 45)

        'ACQUA GIU
        If automa.AcquaGiu Then
            riempimento = Blu
        Else
            riempimento = BluScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 15, imgy + AutomaY + 62, 45, 5)

        'ACQUA ANGOLO BASSO DX
        If automa.AcquaGiuDx Then
            riempimento = Blu
        Else
            riempimento = BluScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 62, imgy + AutomaY + 62, 5, 5)

        'ACQUA ANGOLO BASSO SX
        If automa.AcquaGiuSx Then
            riempimento = Blu
        Else
            riempimento = BluScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 8, imgy + AutomaY + 62, 5, 5)

        '------------STATI ON/OFF--------------

        If automa.stato01 Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 15, imgy + AutomaY + 15, 9, 9)

        If chbStato02.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 26, imgy + AutomaY + 15, 9, 9)

        If chbStato03.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 15, imgy + AutomaY + 26, 9, 9)

        If chbStato04.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 26, imgy + AutomaY + 26, 9, 9)

        If chbStato05.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 40, imgy + AutomaY + 15, 9, 9)

        If chbStato06.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 51, imgy + AutomaY + 15, 9, 9)

        If chbStato07.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 40, imgy + AutomaY + 26, 9, 9)

        If chbStato08.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 51, imgy + AutomaY + 26, 9, 9)

        If chbStato09.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 37, imgy + AutomaY + 15, 1, 20)

        If chbStato10.Checked Then
            riempimento = Grigio
        Else
            riempimento = GrigioScuro
        End If
        g.FillRectangle(riempimento, imgx + AutomaX + 37, imgy + AutomaY + 37, 1, 23)



        '-------------------------------------------------------
        '---------INDICATORE SALUTE-----------------------------
        '-------------------------------------------------------
        Select Case automa.salute
            Case 0
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 37, 9, 3)
            Case 1 To 20
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 37, 9, 3)
            Case 21 To 40
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 37, 9, 3)
            Case 41 To 60
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 37, 9, 3)
            Case 61 To 80
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(GialloScuro, imgx + AutomaX + 40, imgy + AutomaY + 37, 9, 3)
            Case 81 To 100
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(Giallo, imgx + AutomaX + 40, imgy + AutomaY + 37, 9, 3)
        End Select

        '-------------------------------------------------------
        '---------INDICATORE VITA ----------------------------
        '-------------------------------------------------------
        Select Case automa.vita
            Case 0
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 37, 9, 3)
            Case 1 To 20
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 37, 9, 3)
            Case 21 To 40
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 37, 9, 3)
            Case 41 To 60
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 37, 9, 3)
            Case 61 To 80
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(VerdeScuro, imgx + AutomaX + 51, imgy + AutomaY + 37, 9, 3)
            Case 81 To 100
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(Verde, imgx + AutomaX + 51, imgy + AutomaY + 37, 9, 3)
        End Select

        '-------------------------------------------------------
        '---------INDICATORE FAME-------------------------------
        '-------------------------------------------------------
        Select Case automa.fame
            Case 0
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 37, 9, 3)
            Case 1 To 20
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 37, 9, 3)
            Case 21 To 40
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 37, 9, 3)
            Case 41 To 60
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 37, 9, 3)
            Case 61 To 80
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(RossoScuro, imgx + AutomaX + 15, imgy + AutomaY + 37, 9, 3)
            Case 81 To 100
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(Rosso, imgx + AutomaX + 15, imgy + AutomaY + 37, 9, 3)
        End Select

        '-------------------------------------------------------
        '---------INDICATORE SETE-------------------------------
        '-------------------------------------------------------
        Select Case automa.sete
            Case 0
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 37, 9, 3)
            Case 1 To 20
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 37, 9, 3)
            Case 21 To 40
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 37, 9, 3)
            Case 41 To 60
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 37, 9, 3)
            Case 61 To 80
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(BluScuro, imgx + AutomaX + 26, imgy + AutomaY + 37, 9, 3)
            Case 81 To 100
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 57, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 52, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 47, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 42, 9, 3)
                g.FillRectangle(Blu, imgx + AutomaX + 26, imgy + AutomaY + 37, 9, 3)
        End Select

        lblFame.Text = automa.fame.ToString
        lblSete.Text = automa.sete.ToString
        lblVita.Text = automa.vita.ToString
        lblSalute.Text = automa.salute.ToString

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
        imgx = ((newimagex - oldimagex) + imgx)
        ' Where to move image to keep focus on one point
        imgy = ((newimagey - oldimagey) + imgy)
        pb.Refresh()
        ' calls imageBox_Paint
    End Sub

    Private Sub pb_MouseDown(sender As Object, e As MouseEventArgs) Handles pb.MouseDown
        Dim mouse As MouseEventArgs = CType(e, MouseEventArgs)
        If (mouse.Button = MouseButtons.Left) Then
            If Not mousepremuto Then
                mousepremuto = True
                mouseCoord = mouse.Location
                startx = imgx
                starty = imgy
            End If
        End If
    End Sub

    Private Sub pb_MouseUp(sender As Object, e As MouseEventArgs) Handles pb.MouseUp
        mousepremuto = False
    End Sub

    Private Sub pb_MouseMove(sender As Object, e As MouseEventArgs) Handles pb.MouseMove
        Dim mouse As MouseEventArgs = CType(e, MouseEventArgs)
        If (mouse.Button = MouseButtons.Left) Then
            Dim mousePosNow As Point = mouse.Location
            Dim deltaX As Integer = (mousePosNow.X - mouseCoord.X)
            ' the distance the mouse has been moved since mouse was pressed
            Dim deltaY As Integer = (mousePosNow.Y - mouseCoord.Y)
            imgx = CType((startx + (deltaX / zoom)), Integer)
            ' calculate new offset of image based on the current zoom factor
            imgy = CType((starty + (deltaY / zoom)), Integer)
            pb.Refresh()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tempo = tempo + 1

        'Copia la mappa 3,3 che attornia l'automa
        Dim mappamentale As Ambiente = New Ambiente(3, 3)

        'Controlla di non essere su un bordo altrimenti attiva altre soluzioni

        mappamentale.Cella(0, 0).stato = scena.Cella(automa.posX - 1, automa.posY - 1).stato
        mappamentale.Cella(1, 0).stato = scena.Cella(automa.posX, automa.posY - 1).stato
        mappamentale.Cella(2, 0).stato = scena.Cella(automa.posX + 1, automa.posY - 1).stato
        mappamentale.Cella(0, 1).stato = scena.Cella(automa.posX - 1, automa.posY).stato
        mappamentale.Cella(1, 1).stato = scena.Cella(automa.posX, automa.posY).stato
        mappamentale.Cella(2, 1).stato = scena.Cella(automa.posX + 1, automa.posY).stato
        mappamentale.Cella(0, 2).stato = scena.Cella(automa.posX - 1, automa.posY + 1).stato
        mappamentale.Cella(1, 2).stato = scena.Cella(automa.posX, automa.posY + 1).stato
        mappamentale.Cella(2, 2).stato = scena.Cella(automa.posX + 1, automa.posY + 1).stato

        If tempo Mod 2 = 0 Then
            automa.Pensa(mappamentale)
        Else
            automa.Vai()
        End If

        pb.Refresh()
    End Sub

    Private Sub btTempoStart_Click(sender As Object, e As EventArgs) Handles btTempoStart.Click
        Timer1.Start()
    End Sub

    Private Sub btTempoStop_Click(sender As Object, e As EventArgs) Handles btTempoStop.Click
        Timer1.Stop()
    End Sub

    Private Sub SettaAutoma()
        'Posizione iniziale
        automa.posX = 3
        automa.posY = 12

        'Nasce ben carico
        automa.fame = 20
        automa.sete = 20
        automa.salute = 100
        automa.vita = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        immagine = Image.FromFile(nomeImmagine)
        zoom = (pb.Width / immagine.Width) * (immagine.HorizontalResolution / g.DpiX)
        'Setta terreno base
        TerrenoBase()
        'Setta automa
        SettaAutoma()

        'Il ragionamento parte dal timer_tick
    End Sub

End Class
