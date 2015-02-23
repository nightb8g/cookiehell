Partial Public Class tmovimento2
    Inherits Page

    Public Sub New()
        InitializeComponent()
    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub

    Public Sub player_KeyDown(sender As Object, e As KeyEventArgs)

        If (e.Key = Key.Right) Then
            direita()
        ElseIf (e.Key = Key.Left) Then
            esquerda()
        End If
    End Sub
    Private Sub direita()

        CType(bg.RenderTransform, CompositeTransform).TranslateX -= 10


    End Sub
    Private Sub esquerda()
        CType(bg.RenderTransform, CompositeTransform).TranslateX += 10
    End Sub

End Class
