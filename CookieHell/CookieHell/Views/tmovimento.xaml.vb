Partial Public Class tmovimento
    Inherits UserControl

    Public Sub New 
        InitializeComponent()

    End Sub


    Private Sub andarDireita(img As UserControl)
      
        img.Margin = New Thickness(img.Margin.Left + 100, img.Margin.Top, img.Margin.Right, img.Margin.Bottom)
    End Sub
    Private Sub andarEsquerda(img As Object)
        img.Margin = New Thickness(img.Margin.Left - 100, img.Margin.Top, img.Margin.Right, img.Margin.Bottom)
    End Sub

    Private Sub saltar(img As Object)

    End Sub
 

    Public Sub player_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.Key = Key.Right) Then
            andarDireita(player)
        ElseIf (e.Key = Key.Left) Then
            andarEsquerda(player)
        ElseIf (e.Key = Key.Up) Then

        End If
    End Sub

End Class
