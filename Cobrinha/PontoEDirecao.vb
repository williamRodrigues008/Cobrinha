Public Class PontoEDirecao

    Structure Ponto
        Public xPos As Integer
        Public yPos As Integer

        Public Sub New(x As Integer, y As Integer)
            xPos = x
            yPos = y

        End Sub

    End Structure

    Enum Glifos
        Paredes = 9619
        Cobra = 9608
    End Enum

    Enum Direcao
        Norte
        Sul
        Leste
        Oeste
    End Enum

End Class
