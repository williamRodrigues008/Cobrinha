Imports Cobrinha.PontoEDirecao

Public Class Cobra

    Private Comprimento As Integer
    Private Posicao As New Ponto
    Private Corpo As New List(Of Ponto)
    Public Property Direcao As Direcao
    Public Property Vidas As Integer
    Public Pontuacao As Integer

    Public Function PegarX() As Integer
        Return Posicao.xPos
    End Function

    Public Function PegarY() As Integer
        Return Posicao.yPos
    End Function

    Public Sub New()
        Resetar()
    End Sub

    Public Sub Crescer(cresce As Integer)
        Comprimento += cresce
    End Sub

    Public Sub Resetar()
        Comprimento = 2
        Posicao.xPos = (Cobrinha.xMaximo / 2) + 2
        Posicao.yPos = (Cobrinha.yMaximo / 2) - 2
        Direcao = Direcao.Norte
        Corpo.Clear()
        Corpo.Add(New Ponto(Posicao.xPos, Posicao.yPos))
    End Sub

    Public Function Mover() As Boolean
        Select Case (Direcao)
            Case Direcao.Norte
                Posicao.yPos -= 1
            Case Direcao.Sul
                Posicao.yPos += 1
            Case Direcao.Leste
                Posicao.xPos += 1
            Case Direcao.Oeste
                Posicao.xPos -= 1
        End Select

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.SetCursorPosition(Posicao.xPos, Posicao.yPos)
        Console.Write(Convert.ToChar(Glifos.Paredes))

        If (Colidir(Posicao)) Then
            Return False
        End If

        Corpo.Add(New Ponto(Posicao.xPos, Posicao.yPos))

        If (Corpo.Count > Comprimento) Then
            Dim apagar As Ponto = Corpo(0)
            Corpo.RemoveAt(0)
            Console.SetCursorPosition(apagar.xPos, apagar.yPos)
            Console.ForegroundColor = ConsoleColor.Blue
            Console.Write(Convert.ToChar(Glifos.Paredes))
        End If

        Return True
    End Function

    Public Function PosicaoDaCobra() As Ponto
        Return Posicao
    End Function

    Public Function Colidir(ponto As Ponto)
        Return Corpo.Contains(ponto)
    End Function

    Public Sub AdicionarPonto(nivel As Integer, valor As Integer)
        Pontuacao += nivel * valor
        MostrarPontuacao()
    End Sub

    Public Sub ResetarPonto()
        Pontuacao = 0
    End Sub

    Public Sub MostrarPontuacao()
        Console.ForegroundColor = ConsoleColor.White
        Console.SetCursorPosition(37, Cobrinha.yMaximo)
        Console.WriteLine(Pontuacao)
    End Sub
End Class
