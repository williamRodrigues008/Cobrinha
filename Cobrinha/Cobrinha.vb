Imports System
Imports System.Threading
Imports Cobrinha.PontoEDirecao

Namespace Cobrinha

	Module Cobrinha
		Public Const xMaximo = 80, yMaximo = 40

		Public Property PosicaoAlvo As Ponto
		Public Property valorAlvo As Integer
		Public Sub Main(args As String())
			Dim JogarNovamente As Char = "Y"
			Dim Vivo As Boolean
			Dim Chave As ConsoleKey
			Dim cobra As Cobra = New Cobra
			Dim alvo As Alvo = New Alvo
			'Dim valorAlvo As Integer
			Dim Tela As Tela = New Tela(xMaximo, yMaximo)


			Do
				cobra.Vidas = 5
				Tela.Nivel = 0
				Tela.ProximoNivel()
				Console.SetCursorPosition(67, yMaximo)
				Console.ForegroundColor = ConsoleColor.White
				Console.Write(cobra.Vidas)
				cobra.ResetarPonto()
				cobra.MostrarPontuacao()

				While cobra.Vidas > 0
					Vivo = True
					cobra.Resetar()
					alvo.Resetar()

					ProximoAlvo(alvo, cobra, Tela)

					While (Vivo)
						If (Console.KeyAvailable) Then
							Chave = Console.ReadKey(True).Key

							Select Case Chave
								Case ConsoleKey.UpArrow
									If (Not cobra.Direcao = Direcao.Sul) Then cobra.Direcao = Direcao.Norte
								Case ConsoleKey.DownArrow
									If (Not cobra.Direcao = Direcao.Norte) Then cobra.Direcao = Direcao.Sul
								Case ConsoleKey.LeftArrow
									If (Not cobra.Direcao = Direcao.Leste) Then cobra.Direcao = Direcao.Oeste
								Case ConsoleKey.RightArrow
									If (Not cobra.Direcao = Direcao.Oeste) Then cobra.Direcao = Direcao.Leste
								Case ConsoleKey.Escape
									Environment.Exit(0)
							End Select
						End If

						Thread.Sleep(100)

						Vivo = cobra.Mover()

						If ((cobra.PegarX() = 0) OrElse
							(cobra.PegarY() = 0) OrElse
							(cobra.PegarX() = xMaximo - 1) OrElse
							(cobra.PegarY() = yMaximo - 1) OrElse
							(Tela.Colidir(cobra.PosicaoDaCobra()))) Then
							Vivo = False
						End If

						If (cobra.PosicaoDaCobra().Equals(PosicaoAlvo)) Then
							If (valorAlvo > 9) Then
								cobra.Crescer(valorAlvo * Tela.Nivel)
								cobra.AdicionarPonto(Tela.Nivel, valorAlvo)
								alvo.AdicionaValor()
								ProximoAlvo(alvo, cobra, Tela)
							Else
								cobra.AdicionarPonto(Tela.Nivel, valorAlvo)
								Tela.ProximoNivel()
								Console.SetCursorPosition(67, yMaximo)
								Console.ForegroundColor = ConsoleColor.White
								Console.Write(cobra.Vidas)
								alvo.Resetar()
								cobra.Resetar()
								cobra.MostrarPontuacao()
								ProximoAlvo(alvo, cobra, Tela)
							End If
						End If
					End While

					cobra.Vidas -= 1
					Tela.Nivel -= 1
					Tela.ProximoNivel()
					Console.SetCursorPosition(67, yMaximo)
					Console.ForegroundColor = ConsoleColor.White
					Console.Write(cobra.Vidas)
					alvo.Resetar()
					cobra.Resetar()
					cobra.MostrarPontuacao()
				End While

				CenterText(5, "Jogar Novamente? (Y/N)")
				JogarNovamente = " "

				While (Not (Char.ToUpper(JogarNovamente) = "Y") AndAlso Not (Char.ToUpper(JogarNovamente) = "N"))
					JogarNovamente = Console.ReadKey(True).KeyChar
				End While
				CenterText(5, "                  ")
			Loop
			While (Char.ToUpper(JogarNovamente) = "Y")
			End While

			Environment.Exit(0)
		End Sub

		Private Sub CenterText(linha As Integer, mensagem As String)
			Dim comp As Integer = mensagem.Length
			Dim xPosicao As Integer = (xMaximo - comp) / 2

			Console.SetCursorPosition(xPosicao, linha)
			Console.Write(mensagem)
		End Sub

		Private Sub ProximoAlvo(alvo As Alvo, cobra As Cobra, tela As Tela)
			Dim pegou As Boolean = True
			PosicaoAlvo = alvo.PegarAlvo().Item1
			valorAlvo = alvo.PegarAlvo().Item2
			While (pegou)

				If (Not cobra.Colidir(PosicaoAlvo) AndAlso Not (tela.Colidir(PosicaoAlvo))) Then
					pegou = False
				End If
			End While

			Console.ForegroundColor = ConsoleColor.White
			Console.SetCursorPosition(PosicaoAlvo.xPos, PosicaoAlvo.yPos)
			Console.Write(valorAlvo)
		End Sub
	End Module
End Namespace
