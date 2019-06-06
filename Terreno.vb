Public Class Terreno
    Public Property stato As Short
    Public Property descrizione As String

    Public Sub New(ByVal definisci As Short)
        stato = definisci
        Select Case stato
            Case 0 : descrizione = "Vuoto"
            Case 1 : descrizione = "Occupato"
            Case 2 : descrizione = "Acqua"
            Case 3 : descrizione = "Cibo"
            Case 4 : descrizione = "Ostacolo"
            Case 5 : descrizione = "Pericolo"
            Case -1 : descrizione = "Nullo"
            Case Else : descrizione = "Errore"
        End Select
    End Sub
End Class