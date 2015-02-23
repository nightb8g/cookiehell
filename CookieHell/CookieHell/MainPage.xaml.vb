Imports System.Windows.Navigation

Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ContentFrame_Navigated(ByVal sender As Object, ByVal e As NavigationEventArgs) Handles ContentFrame.Navigated
        For Each child As UIElement In LinksStackPanel.Children
            Dim hb As HyperlinkButton = TryCast(child, HyperlinkButton)
            If hb IsNot Nothing AndAlso hb.NavigateUri IsNot Nothing Then
                If hb.NavigateUri = e.Uri Then
                    VisualStateManager.GoToState(hb, "ActiveLink", True)
                Else
                    VisualStateManager.GoToState(hb, "InactiveLink", True)
                End If
            End If
        Next
    End Sub

    Private Sub ContentFrame_NavigationFailed(ByVal sender As Object, ByVal e As NavigationFailedEventArgs) Handles ContentFrame.NavigationFailed
        e.Handled = True
        Dim errorWindow As ChildWindow = New ErrorWindow(e.Uri)
        errorWindow.Show() 'aqui
    End Sub

    Private Sub player_KeyDown(sender As Object, e As KeyEventArgs)
        If (ContentFrame.CurrentSource.OriginalString.Contains("tmovimento2")) Then

            CType(ContentFrame.Content, tmovimento2).player_KeyDown(sender, e)
        ElseIf (ContentFrame.CurrentSource.OriginalString.Contains("tmovimento")) Then

            CType(ContentFrame.Content, tmovimento).player_KeyDown(sender, e)
        End If
    End Sub

  
End Class