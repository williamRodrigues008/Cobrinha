Imports Cobrinha.PontoEDirecao

Public Class Alvo
    Dim random = New Random
    Private valor As Integer = 1

    Public Sub Resetar()
        valor = 1
    End Sub

    Public Function PegarAlvo() As (Ponto, Integer)
        Return (New Ponto(random.Next(1, Cobrinha.xMaximo - 1),
                random.Next(1, Cobrinha.yMaximo - 1)), valor)
    End Function

    Public Sub AdicionaValor()
        valor += 1
    End Sub

End Class
