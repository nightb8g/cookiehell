Imports System.Windows.Media.Imaging

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
            mover(player, 15.0R, direcao)
        ElseIf (e.Key = Key.Left) Then
            direcao = -1
            mover(player, 15.0R, direcao)
        ElseIf (e.Key = Key.Up) Then
            saltarlado()
        ElseIf (e.Key = Key.B) Then
            

            gerarCaixa()

        End If

    End Sub

    Private Function colisao(ByRef obj1 As Image, ByRef obj2 As Image) As Boolean

        Dim obj1Left As Double = obj1.GetValue(Canvas.LeftProperty)
        Dim obj2Left As Double = obj2.GetValue(Canvas.LeftProperty)
        Dim obj1Top As Double = obj1.GetValue(Canvas.TopProperty)
        Dim obj2Top As Double = obj2.GetValue(Canvas.TopProperty)
        Dim obj1Width As Double = obj1.GetValue(Canvas.ActualWidthProperty)
        Dim obj2Width As Double = obj2.GetValue(Canvas.ActualWidthProperty)
        Dim obj1Right As Double = obj1Left + obj1Width
        Dim obj2Right As Double = obj2Left + obj2Width
        Dim obj1Bottom As Double = obj1Top + obj1.GetValue(Canvas.ActualHeightProperty)
        Dim obj2Bottom As Double = obj2Top + obj2.GetValue(Canvas.ActualHeightProperty)

        If (obj2Left - obj1Right < 0 And obj2Right - obj1Left > 0) Then
            If obj1Top < obj2Bottom And obj2Top < obj1Bottom Then
                'colidiu em cima/baixo + esquerda/direita
                obj2.Visibility = Windows.Visibility.Collapsed
                Return True
            Else
                'colidiu esquerda+direita
                obj2.Visibility = Windows.Visibility.Collapsed
                Return True
            End If
        Else
            obj2.Visibility = Windows.Visibility.Visible
            Return False
        End If
    End Function
   
    Private Sub mover(ByRef obj As Image, distancia As Double, direcao As Double)
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
        If (obj.Equals(player)) Then
            If (playerimgcount = 1) Then
                player.Source.SetValue(Media.Imaging.BitmapImage.UriSourceProperty, New Uri("/CookieHell;component/img/c_anda1.png", UriKind.RelativeOrAbsolute))
                playerimgcount = 2
            Else
                player.Source.SetValue(Media.Imaging.BitmapImage.UriSourceProperty, New Uri("/CookieHell;component/img/c_anda2.png", UriKind.RelativeOrAbsolute))
                playerimgcount = 1
            End If
        End If
        Select Case direcao
            Case -1
                esquerda(obj, distancia)
            Case 1
                direita(obj, distancia)
            Case 0
                'saltar
        End Select
        For Each img As Image In caixas.Children
            If (colisao(player, img)) Then
                '  MessageBox.Show("colidiu")
            End If

        Next
    End Sub
    Private Sub direita(ByRef obj As Image, distancia As Double)
        'metodo antigo (apenas para referência)
        'If (playerLeft < canvasMidle) Then
        '    player.SetValue(Canvas.LeftProperty, playerLeft + distancia)
        'End If
        'If (canvasWidth - bgLeft < bgWidth) Then
        '    bg.SetValue(Canvas.LeftProperty, bgLeft - distancia)
        'ElseIf (playerLeft < canvasWidth - player.ActualWidth) Then
        '    player.SetValue(Canvas.LeftProperty, playerLeft + distancia)
        'End If

        Dim bgright As Double = bg.GetValue(Canvas.LeftProperty) + bg.ActualWidth
        Dim canvasright As Double = LayoutRoot.GetValue(Canvas.LeftProperty) + LayoutRoot.ActualWidth
        Dim objright As Double = obj.GetValue(Canvas.LeftProperty) + obj.ActualWidth
        Dim objleft As Double = obj.GetValue(Canvas.LeftProperty)
        Dim canvasmidle As Double = LayoutRoot.ActualWidth / 2

        'bgright - canvasright > 0 = backgroud right alinhado com o layoutroot right
        'objleft > canvasmidle = objecto depois do ponto central do layoutroot
        If (bgright - canvasright > 0 And objleft > canvasmidle) Then
            bg.SetValue(Canvas.LeftProperty, bg.GetValue(Canvas.LeftProperty) - distancia) 'move o bg (todos os objecto contidos)
        End If

        'bg.ActualWidth - objright > 0 = enquando o objecto nao chegou ao fim do bg
        If (bg.ActualWidth - objright > 0) Then
            obj.SetValue(Canvas.LeftProperty, obj.GetValue(Canvas.LeftProperty) + distancia) 'move o player(
        End If
        obj.RenderTransform.SetValue(CompositeTransform.ScaleXProperty, direcao)


    End Sub
    Private Sub esquerda(ByRef obj As Image, distancia As Double)
        'metodo antigo (apenas para referência)
        'If (playerLeft > canvasMidle) Then
        '    player.SetValue(Canvas.LeftProperty, playerLeft - distancia)
        'End If
        'If (bgLeft < 0) Then
        '    bg.SetValue(Canvas.LeftProperty, bgLeft + distancia)
        'ElseIf (playerLeft > 0) Then
        '    player.SetValue(Canvas.LeftProperty, playerLeft - distancia)

        'End If
        Dim bgleft As Double = bg.GetValue(Canvas.LeftProperty)
        Dim canvasleft As Double = LayoutRoot.GetValue(Canvas.LeftProperty)
        Dim objleft As Double = obj.GetValue(Canvas.LeftProperty)
        Dim canvasmidle As Double = LayoutRoot.ActualWidth / 2

        If (canvasleft - bgleft > 0 And objleft < canvasmidle) Then
            bg.SetValue(Canvas.LeftProperty, bg.GetValue(Canvas.LeftProperty) + distancia)
        End If
        If (objleft > 0) Then
            obj.SetValue(Canvas.LeftProperty, obj.GetValue(Canvas.LeftProperty) - distancia)
        End If
        obj.RenderTransform.SetValue(CompositeTransform.ScaleXProperty, direcao)

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


    Private Function gerarCaixa(Optional ByVal Left As Double = 0.0R) As Boolean
        '<Image Height="100" Canvas.Left="975" Canvas.Top="440" Width="100" Source="/CookieHell;component/img/obj.jpg"/>
        If (Left = 0) Then
            Dim rand As New Random()
            Left = rand.NextDouble() * (bg.ActualWidth - 200) 'para nao aparecer nas margens
        End If
        Dim box As New Image
        box.Source = New BitmapImage(New Uri("/CookieHell;component/img/obj.jpg", UriKind.RelativeOrAbsolute))
        box.Width = 100.0R
        box.Height = 100.0R
        box.SetValue(Canvas.TopProperty, 440.0R)
        box.SetValue(Canvas.LeftProperty, Left)
        'Dim lbl As New Label
        For Each obj As Image In caixas.Children
            If (colisao(box, obj) And Not obj.Equals(bgimg) And Not obj.Equals(player)) Then
                Return False
            End If
        Next
        caixas.Children.Add(box)
        Return True
    End Function
    Private Sub gerarEnimigo(ByVal Left As Double)
        'ToBeImplemented
    End Sub

    Private Sub saltarlado()

        Dim st As New Storyboard
        storyboard_saltar(st, direcao)
        st.Begin()
        'bg_pontos.TranslateY = 100

    End Sub
End Class
