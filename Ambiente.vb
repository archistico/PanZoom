Public Class Ambiente
    Public Cella(,) As Terreno

    Public Property Larghezza As Short
    Public Property Lunghezza As Short

    Public Sub New(ByVal Lungh As Short, ByVal largh As Short)
        Lunghezza = Lungh
        Larghezza = largh
        ReDim Cella(Lunghezza, Larghezza)
        For riga As Integer = 0 To Lunghezza - 1
            For colonna As Integer = 0 To Larghezza - 1
                Cella(riga, colonna) = New Terreno(0)
            Next
        Next
    End Sub
End Class