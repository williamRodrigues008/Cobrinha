Imports Cobrinha.PontoEDirecao

Namespace Cobrinha
    Friend Class Tela

        Private Paredes As List(Of Ponto) = New List(Of Ponto)
        Private ReadOnly xMaximo As Integer
        Private ReadOnly yMaximo As Integer
        Public Nivel As Integer

        Public Sub New(xMaximo As Integer, yMaximo As Integer)
            Console.Title = "Cobrinha"
            Console.SetWindowSize(xMaximo, yMaximo + 1)
            Console.CursorVisible = False
            Console.BackgroundColor = ConsoleColor.Blue
            Console.Clear()

            Me.xMaximo = xMaximo
            Me.yMaximo = yMaximo

            Nivel = 0

            ProximoNivel()

        End Sub

        Public Sub Resetar()
            Console.Clear()
            Console.ForegroundColor = ConsoleColor.Red
            For x As Integer = 0 To xMaximo + 1

                Console.SetCursorPosition(x, 0)
                Console.Write(Convert.ToChar(Glifos.Paredes))
                Console.SetCursorPosition(x, yMaximo - 1)
                Console.Write(Convert.ToChar(Glifos.Paredes))

            Next

            For y As Integer = 0 To yMaximo - 1
                Console.SetCursorPosition(0, y)
                Console.Write(Convert.ToChar(Glifos.Paredes))

                Console.SetCursorPosition(xMaximo - 1, y)
                Console.Write(Convert.ToChar(Glifos.Paredes))
            Next

            Console.ForegroundColor = ConsoleColor.White
            Console.SetCursorPosition(1, yMaximo)
            Console.Write("Nivel: ")

            Console.SetCursorPosition(30, yMaximo)
            Console.Write("Pontos: ")

            Console.SetCursorPosition(60, yMaximo)
            Console.Write("Vidas: ")
        End Sub

        Public Function Colidir(ponto As Ponto) As Boolean
            Return Paredes.Contains(ponto)
        End Function

        Public Sub ProximoNivel()
            Nivel += 1

            Resetar()

            Console.SetCursorPosition(8, yMaximo)
            Console.Write(Nivel)

            Console.ForegroundColor = ConsoleColor.Red

            Select Case Nivel
                Case 1
                    Paredes.Clear()
                Case 2
                    Paredes.Clear()
                    For x As Integer = 20 To 60
                        ColocarParede(x, 20)
                    Next
                Case 3
                    Paredes.Clear()
                    For y As Integer = 10 To 30
                        ColocarParede(15, y)
                        ColocarParede(65, y)
                    Next
                Case 4
                    Paredes.Clear()
                    For y As Integer = 1 To 15
                        ColocarParede(20, y)
                        ColocarParede(60, 40 - y)
                    Next

                    For x As Integer = 1 To 35
                        ColocarParede(x, 30)
                        ColocarParede(80 - x, 10)
                    Next
                Case 5
                    Paredes.Clear()
                    For y As Integer = 13 To 27
                        ColocarParede(9, y)
                        ColocarParede(71, y)
                    Next

                    For x As Integer = 11 To 69
                        ColocarParede(x, 11)
                        ColocarParede(x, 29)
                    Next

                Case 6
                    Paredes.Clear()
                    For y As Integer = 1 To 40
                        If ((y <= 15) OrElse (y >= 25)) Then
                            ColocarParede(10, y)
                            ColocarParede(20, y)
                            ColocarParede(30, y)
                            ColocarParede(40, y)
                            ColocarParede(50, y)
                            ColocarParede(60, y)
                            ColocarParede(70, y)
                        End If
                    Next

                Case 7
                    Paredes.Clear()
                    For y As Integer = 1 To 40 + 2
                        ColocarParede(40, y)
                    Next
                Case 8
                    Paredes.Clear()
                    For y As Integer = 0 To 35
                        ColocarParede(10, y)
                        ColocarParede(20, 39 - y)
                        ColocarParede(30, y)
                        ColocarParede(40, 39 - y)
                        ColocarParede(50, y)
                        ColocarParede(60, 39 - y)
                        ColocarParede(70, y)
                    Next
                Case 9
                    Paredes.Clear()
                    For i As Integer = 3 To 37
                        ColocarParede(i, i)
                        ColocarParede(i + 39, i)
                    Next
                Case Else
                    Paredes.Clear()
                    For y As Integer = 1 To 39 + 2
                        ColocarParede(10, y)
                        ColocarParede(20, y + 1)
                        ColocarParede(30, y)
                        ColocarParede(40, y + 1)
                        ColocarParede(50, y)
                        ColocarParede(60, y + 1)
                        ColocarParede(70, y)
                    Next

            End Select
        End Sub

        Private Sub ColocarParede(x As Integer, y As Integer)
            Console.SetCursorPosition(x, y)
            Console.Write(Convert.ToChar(Glifos.Paredes))
            Paredes.Add(New Ponto(x, y))
        End Sub
    End Class
End Namespace
