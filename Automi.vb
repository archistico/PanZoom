Public Class Automi
    Public Property salute As Double
    Public Property vita As Double
    Public Property fame As Double
    Public Property sete As Double
    Public Property durataVita As Double

    Private contFame As Integer = 0
    Private contSete As Integer = 0
    Private ContVita As Integer = 0
    Private ContSalute As Integer = 0

    Public Property posX As Integer
    Public Property posY As Integer

    Public Property stato01 As Boolean
    Public Property stato02 As Boolean
    Public Property stato03 As Boolean
    Public Property stato04 As Boolean
    Public Property stato05 As Boolean
    Public Property stato06 As Boolean
    Public Property stato07 As Boolean
    Public Property stato08 As Boolean
    Public Property stato09 As Boolean
    Public Property stato10 As Boolean

    Public Property CiboDx As Boolean
    Public Property CiboSx As Boolean
    Public Property CiboSu As Boolean
    Public Property CiboGiu As Boolean
    Public Property CiboSuSx As Boolean
    Public Property CiboSuDx As Boolean
    Public Property CiboGiuSx As Boolean
    Public Property CiboGiuDx As Boolean

    Public Property AcquaDx As Boolean
    Public Property AcquaSx As Boolean
    Public Property AcquaSu As Boolean
    Public Property AcquaGiu As Boolean
    Public Property AcquaSuSx As Boolean
    Public Property AcquaSuDx As Boolean
    Public Property AcquaGiuSx As Boolean
    Public Property AcquaGiuDx As Boolean


    Public Property Mangia As Boolean
    Public Property Bevi As Boolean

    Public Property scelta As Short

    Public Sub Pensa(mappamentale As Ambiente)
        'ATTIVA SENSORE OSTACOLO
        If mappamentale.Cella(1, 0).stato = 4 Or mappamentale.Cella(0, 1).stato = 4 Or mappamentale.Cella(2, 1).stato = 4 Or mappamentale.Cella(1, 2).stato = 4 Then
            stato01 = True
        Else
            stato01 = False
        End If

        'ATTIVA SENSORE CIBO
        If mappamentale.Cella(0, 0).stato = 3 Then
            CiboSuSx = True
        Else
            CiboSuSx = False
        End If

        If mappamentale.Cella(1, 0).stato = 3 Then
            CiboSu = True
        Else
            CiboSu = False
        End If

        If mappamentale.Cella(2, 0).stato = 3 Then
            CiboSuDx = True
        Else
            CiboSuDx = False
        End If

        If mappamentale.Cella(0, 1).stato = 3 Then
            CiboSx = True
        Else
            CiboSx = False
        End If

        If mappamentale.Cella(1, 1).stato = 3 Then
            Mangia = True
        Else
            Mangia = False
        End If

        If mappamentale.Cella(2, 1).stato = 3 Then
            CiboDx = True
        Else
            CiboDx = False
        End If

        If mappamentale.Cella(0, 2).stato = 3 Then
            CiboGiuSx = True
        Else
            CiboGiuSx = False
        End If

        If mappamentale.Cella(1, 2).stato = 3 Then
            CiboGiu = True
        Else
            CiboGiu = False
        End If

        If mappamentale.Cella(2, 2).stato = 3 Then
            CiboGiuDx = True
        Else
            CiboGiuDx = False
        End If

        Dim diffFame As Integer = 10
        Dim diffSete As Integer = 10
        Dim diffSalute As Integer = 10
        Dim diffVita As Integer = 5

        'SETTA GLI STATI FAME SETE VITA SALUTE
        contFame += 1
        contSete += 1
        ContVita += 1

        If contFame = diffFame Then
            contFame = 0
            If fame > 1 Then
                fame -= 1
            Else
                fame = 0
                ContSalute += 5
            End If
        End If
        If contSete = diffSete Then
            contSete = 0
            If sete > 1 Then
                sete -= 1
            Else
                sete = 0
                ContSalute += 5
            End If
        End If

        If ContSalute = diffSalute Then
            ContSalute = 0
            salute -= 1
        End If

        If ContVita = diffVita Then
            ContVita = 0
            vita += diffVita / 50
        End If

        '----------------RAGIONAMENTO-------------------

        If mappamentale.Cella(1, 0).stato = 0 Then
            'Muovi avanti - Verso l'alto del tabellone
            scelta = 1
        End If

        If mappamentale.Cella(0, 1).stato = 0 Then
            'Muovi a sx
            scelta = 4
        End If

        If mappamentale.Cella(2, 1).stato = 0 Then
            'Muovi a dx
            scelta = 2
        End If

        If mappamentale.Cella(1, 2).stato = 0 Then
            'Muovi verso il basso
            scelta = 3
        End If


    End Sub

    Public Sub Vai()
        'MUOVI 
        Muovi(scelta)
    End Sub

    Public Sub Muovi(dir As Short)
        Select Case dir
            Case 1
                'Muovi avanti - Verso l'alto del tabellone
                posY -= 1
            Case 2
                'Muovi a dx
                posX += 1
            Case 3
                'Muovi verso il basso
                posY += 1
            Case 4
                'Muovi a sx
                posX -= 1
        End Select
    End Sub

End Class