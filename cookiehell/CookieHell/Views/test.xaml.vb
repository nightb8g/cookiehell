Partial Public Class test
    Inherits Page

    Public Sub New()
        InitializeComponent()
    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

        '<MediaElement x:Name="mediaElement" Source="/img/demo_HD.wmv" Height="219" Canvas.Left="349" Canvas.Top="45" Width="573" AutoPlay="true" IsMuted="True" Stretch="Fill"/



    End Sub

    'Private Sub Replay(sender As Object, e As MouseButtonEventArgs) Handles play.MouseLeftButtonDown, play.MouseRightButtonDown
    '    If MediaElement.CurrentState = MediaElementState.Stopped Then
    '        MediaElement.Play()
    '    Else
    '        MediaElement.Stop()
    '        MediaElement.Play()
    '    End If
    'End Sub


End Class
