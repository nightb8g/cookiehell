Imports System.Windows.Media.Imaging

Partial Public Class tmovimento3
    Inherits Page

    Dim direcao As Double = 1
    Dim playerimgcount As Integer = 1
    Dim playerimg1 As New BitmapImage(New Uri("/CookieHell;component/img/c_anda1.png", UriKind.RelativeOrAbsolute))
    Dim playerimg2 As New BitmapImage(New Uri("/CookieHell;component/img/c_anda2.png", UriKind.RelativeOrAbsolute))
    Dim vidasimg As New BitmapImage(New Uri("/CookieHell;component/img/cookie.png", UriKind.RelativeOrAbsolute))
    Dim inUse As Boolean = False
    Dim playervidas As Integer = 3
    Public Sub New()
        InitializeComponent()
        tirarVida()
    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub


    Public Sub player_KeyDown(sender As Object, e As KeyEventArgs)
        If Not (inUse) Then
            If (e.Key = Key.Right) Then
                direcao = 1
                mover(player, 15.0R, direcao)
            ElseIf (e.Key = Key.Left) Then
                direcao = -1
                mover(player, 15.0R, direcao)
            ElseIf (e.Key = Key.Up) Then
                saltarlado()
            ElseIf (e.Key = Key.D) Then 'morre
                playervidas = 0
            ElseIf (e.Key = Key.B) Then 'gera nova caixa
                gerarCaixa() 'random
                gerarCaixa(100) 'posição definida (100 é coordenada x)
            ElseIf (e.Key = Key.L) Then 'gera nova caixa
                Dim lvl2 As New BitmapImage(New Uri("/CookieHell;component/img/level_troll.png", UriKind.RelativeOrAbsolute))
                mudarbg(lvl2)
            End If
        End If
    End Sub
    Private Sub mudarbg(imagem As BitmapImage)
        bgimg.Source = imagem
        bg.Width = 3484
        bg.Height = 600
        bgimg.Width = 3484
        bg.Height = 600
    End Sub

    Private Function colisao(ByRef obj1 As Image, ByRef obj2 As Image) As Integer

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
                ' obj2.Visibility = Windows.Visibility.Collapsed
                Return 2
            Else
                'colidiu esquerda+direita
                'obj2.Visibility = Windows.Visibility.Collapsed
                Return 1
            End If
        Else
            Return 0
        End If
    End Function
    Public Function verificarColisao()

        For Each img As Image In caixas.Children
            If Not (colisao(player, img) = 0) Then
                '  MessageBox.Show("colidiu")
                img.Visibility = Windows.Visibility.Collapsed
            Else
                img.Visibility = Windows.Visibility.Visible
            End If
        Next
        For Each img As Image In enimigos.Children
            If Not (colisao(player, img) = 0) Then
                MessageBox.Show("colidiu")
                bg.SetValue(Canvas.LeftProperty, 0.0R)
                player.SetValue(Canvas.LeftProperty, 20.0R)

                playervidas -= 1
                tirarVida()
            End If
        Next


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
                'player.Source.SetValue(Media.Imaging.BitmapImage.UriSourceProperty, New Uri("/CookieHell;component/img/c_anda1.png", UriKind.RelativeOrAbsolute))
                player.Source = playerimg2
                playerimgcount = 2
            Else
                'player.Source.SetValue(Media.Imaging.BitmapImage.UriSourceProperty, New Uri("/CookieHell;component/img/c_anda2.png", UriKind.RelativeOrAbsolute))
                player.Source = playerimg1
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
        verificarColisao()
        If (playervidas <= 0) Then
            MessageBox.Show("Game Over")
            NavigationService.Refresh()
        End If
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

        If (canvasleft - bgleft > 0 And (objleft + bgleft) < canvasmidle) Then
            bg.SetValue(Canvas.LeftProperty, bg.GetValue(Canvas.LeftProperty) + distancia)
        End If
        If (objleft > 0) Then
            obj.SetValue(Canvas.LeftProperty, obj.GetValue(Canvas.LeftProperty) - distancia)
        End If
        obj.RenderTransform.SetValue(CompositeTransform.ScaleXProperty, direcao)

    End Sub

    Private Sub storyboard_saltar(ByRef st As Storyboard, ByVal direcao As Integer)
        AddHandler st.Completed, AddressOf stop_saltar
        Dim edf1, edf2, edf3 As New EasingDoubleKeyFrame
        Dim ce As New CubicEase
        Dim daLeft As New DoubleAnimationUsingKeyFrames
        Dim daTop As New DoubleAnimationUsingKeyFrames
        Dim objY As New Double
        objY = player.GetValue(Canvas.TopProperty)

        edf1.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0))
        edf1.Value = player.GetValue(Canvas.LeftProperty)
        daLeft.KeyFrames.Add(edf1)
        edf2.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 1.6))
        edf2.Value = edf1.Value + (200 * direcao)
        daLeft.KeyFrames.Add(edf2)

        edf1 = New EasingDoubleKeyFrame
        edf2 = New EasingDoubleKeyFrame
        edf1.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0))
        edf1.Value = objY
        daTop.KeyFrames.Add(edf1)
        edf2.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 0.6))
        edf2.Value = edf1.Value - 200
        ce.EasingMode = EasingMode.EaseOut
        edf2.EasingFunction = ce
        daTop.KeyFrames.Add(edf2)
        edf3.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 1.6))
        edf3.Value = 440.0R
        daTop.KeyFrames.Add(edf3)

        Storyboard.SetTarget(daLeft, player)
        Storyboard.SetTarget(daTop, player)
        Storyboard.SetTargetProperty(daLeft, New PropertyPath(Canvas.LeftProperty))
        Storyboard.SetTargetProperty(daTop, New PropertyPath(Canvas.TopProperty))
      st.Children.Add(daLeft)
        st.Children.Add(daTop)

    End Sub
    Private Sub stop_saltar(sender As Object, e As EventArgs)

        TryCast(sender, Storyboard).FillBehavior = FillBehavior.Stop
        verificarColisao()
        inUse = False
    End Sub


    Private Function gerarCaixa(Optional ByVal Left As Double = 0.0R) As Boolean
        '<Image Height="100" Canvas.Left="975" Canvas.Top="440" Width="100" Source="/CookieHell;component/img/obj.jpg"/>
        If (Left = 0) Then
            Dim rand As New Random()
            Left = rand.NextDouble() * (bg.ActualWidth - 200) 'para nao aparecer nas margens
        End If
        Dim box As New Image
        box.Source = New BitmapImage(New Uri("/CookieHell;component/img/obj.jpg", UriKind.RelativeOrAbsolute))
        box.Width = 50.0R
        box.Height = 50.0R
        box.SetValue(Canvas.TopProperty, 440.0R)
        box.SetValue(Canvas.LeftProperty, Left)

        For Each obj As Image In caixas.Children
            If Not (colisao(box, obj) = 0 And colisao(box, player) = 0) Then
                Return False
            End If
        Next
        For Each img As Image In enimigos.Children
            If Not (colisao(box, img) = 0) Then
                Return False
            End If
        Next
        caixas.Children.Add(box)
        Return True
    End Function
    Private Sub gerarEnimigo(ByVal Left As Double)
        'ToBeImplemented

    End Sub
    Private Sub tirarVida()
        vidas.Children.Clear()

        For i As Integer = 0 To playervidas - 1 Step 1
            Dim image As New Image
            image.Source = vidasimg
            image.Width = 50
            image.Height = 50
            Dim column As New ColumnDefinition
            column.Width = New GridLength(50.0R)
            vidas.ColumnDefinitions.Add(column)
            Grid.SetColumn(image, i)
            vidas.Children.Add(image)
        Next
    End Sub
    Private Sub saltarlado()

        Dim st As New Storyboard
        storyboard_saltar(st, direcao)
        st.Begin()
        inUse = True
        'bg_pontos.TranslateY = 100

    End Sub
End Class
