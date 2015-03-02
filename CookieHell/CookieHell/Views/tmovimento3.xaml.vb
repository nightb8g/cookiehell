Partial Public Class tmovimento3
    Inherits Page

    Dim direcao As Double = 1
    Dim playerimgcount As Integer = 1

    Public Sub New()
        InitializeComponent()

    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)


    End Sub
    Public Sub player_KeyDown(sender As Object, e As KeyEventArgs)

        If (e.Key = Key.Right) Then
            direcao = 1
            mover(10, direcao)
        ElseIf (e.Key = Key.Left) Then
            direcao = -1
            mover(10, direcao)
        ElseIf (e.Key = Key.Up) Then
            saltarlado()
        End If

    End Sub
    Private Sub direita(playerLeft As Double, canvasMidle As Double, bgLeft As Double, bgWidth As Double, canvasWidth As Double, distancia As Double)

        If (playerLeft < canvasMidle) Then
            player.SetValue(Canvas.LeftProperty, playerLeft + distancia)
        ElseIf (canvasWidth - bgLeft < bgWidth) Then
            bg.SetValue(Canvas.LeftProperty, bgLeft - distancia)
        ElseIf (playerLeft < canvasWidth - player.ActualWidth) Then
            player.SetValue(Canvas.LeftProperty, playerLeft + distancia)
        End If
        player.RenderTransform.SetValue(CompositeTransform.ScaleXProperty, direcao)


    End Sub
    Private Sub mover(distancia As Double, direcao As Double)
        'Background
        Dim bgLeft As Double = bg.GetValue(Canvas.LeftProperty)
        Dim bgTop As Double = bg.GetValue(Canvas.TopProperty)
        Dim bgWidth As Double = bg.ActualWidth
        Dim bgHeight As Double = bg.ActualHeight
        Dim bgRight As Double = bgLeft + bgWidth

        'Player
        Dim playerLeft As Double = player.GetValue(Canvas.LeftProperty)
        Dim playerTop As Double = player.GetValue(Canvas.TopProperty)
        Dim playerWidth As Double = player.ActualWidth
        Dim playerHeigh As Double = player.ActualHeight
        Dim playerRight As Double = playerLeft + playerWidth

        'Canvas
        Dim canvasWidth As Double = LayoutRoot.GetValue(Canvas.ActualWidthProperty)
        Dim canvasHeight As Double = LayoutRoot.GetValue(Canvas.ActualHeightProperty)
        Dim canvasMidle As Double = canvasWidth / 2


        'MessageBox.Show(player.Source.GetValue(Media.Imaging.BitmapImage.UriSourceProperty).ToString)

        If (playerimgcount = 1) Then
            player.Source.SetValue(Media.Imaging.BitmapImage.UriSourceProperty, New Uri("/CookieHell;component/img/c_go1.png", UriKind.RelativeOrAbsolute))
            playerimgcount = 2
        Else
            player.Source.SetValue(Media.Imaging.BitmapImage.UriSourceProperty, New Uri("/CookieHell;component/img/c_go2.png", UriKind.RelativeOrAbsolute))
            playerimgcount = 1
        End If

        Select Case direcao
            Case -1
                esquerda(playerLeft, canvasMidle, bgLeft, distancia)
            Case 1
                direita(playerLeft, canvasMidle, bgLeft, bgWidth, canvasWidth, distancia)
            Case 0
                'saltar
        End Select

    End Sub
    Private Sub esquerda(playerLeft As Double, canvasMidle As Double, bgLeft As Double, distancia As Double)

        If (playerLeft > canvasMidle) Then
            player.SetValue(Canvas.LeftProperty, playerLeft - distancia)
        ElseIf (bgLeft < 0) Then
            bg.SetValue(Canvas.LeftProperty, bgLeft + distancia)
        ElseIf (playerLeft > 0) Then
            player.SetValue(Canvas.LeftProperty, playerLeft - distancia)
        End If
        player.RenderTransform.SetValue(CompositeTransform.ScaleXProperty, direcao)

    End Sub

    Private Sub storyboard_saltar(ByRef st As Storyboard, ByVal direcao As Integer)
        ' <!--<Storyboard x:Name="saltar">
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)" Storyboard.TargetName="image">
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="50"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="80"/>
        '	</DoubleAnimationUsingKeyFrames>
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="image">
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="-100"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="0"/>
        '	</DoubleAnimationUsingKeyFrames>
        '</Storyboard> -->

        'Dim daTop As New DoubleAnimationUsingKeyFrames
        'Dim daLeft As New DoubleAnimationUsingKeyFrames
        'Dim keyframemidle As New EasingDoubleKeyFrame
        'Dim keyframefinal As New EasingDoubleKeyFrame

        'Left
        'keyframemidle.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))
        'keyframefinal.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 10))
        'keyframemidle.Value = bg_pontos.TranslateX + (-direcao * 50)
        'keyframefinal.Value = keyframemidle.Value + (-direcao * 80)
        'daLeft.KeyFrames.Add(keyframemidle)
        'daLeft.KeyFrames.Add(keyframefinal)
        'Storyboard.SetTarget(daLeft, bg_pontos)
        'Storyboard.SetTargetProperty(daLeft, New PropertyPath(CompositeTransform.TranslateXProperty))
        'st.Children.Add(daLeft)

        'Top
        'keyframemidle = New EasingDoubleKeyFrame
        'keyframefinal = New EasingDoubleKeyFrame
        'keyframemidle.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))
        'keyframefinal.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 10))
        'keyframemidle.Value = bg_pontos.TranslateY + 100
        ''keyframefinal.Value = keyframemidle.Value + 100
        'keyframefinal.Value = 0
        'daTop.KeyFrames.Add(keyframemidle)
        'daTop.KeyFrames.Add(keyframefinal)
        'Storyboard.SetTarget(daTop, bg_pontos)
        'Storyboard.SetTargetProperty(daTop, New PropertyPath(CompositeTransform.TranslateYProperty))
        'st.Children.Add(daTop)

        'st.SpeedRatio = 20
        'AddHandler st.Completed, AddressOf stop_saltar

    End Sub
    Private Sub stop_saltar(sender As Object, e As EventArgs)
        'CType(sender, Storyboard).Stop()
        'sender = Nothing
    End Sub
    Private Sub saltarlado()

        Dim st As New Storyboard
        storyboard_saltar(st, direcao)
        st.Begin()
        'bg_pontos.TranslateY = 100

    End Sub
End Class
