Imports System.Windows.Media.Imaging

Partial Public Class tmovimento3
    Inherits Page
    'Define a direção(vector) de deslocamento do jogador(1=Direita, -1=esquerda)
    Dim direcao As Double = 1
    'Define a imagem do player a ser mostrada actualmente(movimento andar)
    Dim playerimgcount As Integer = 1
    'Imagem do jogador a andar
    Dim playerimg1 As New BitmapImage(New Uri("/CookieHell;component/img/c_anda1.png", UriKind.RelativeOrAbsolute))
    Dim playerimg2 As New BitmapImage(New Uri("/CookieHell;component/img/c_anda2.png", UriKind.RelativeOrAbsolute))
    'Imagem das vidas
    Dim vidasimg As New BitmapImage(New Uri("/CookieHell;component/img/cookie.png", UriKind.RelativeOrAbsolute))
    'Imagem das caixas
    Dim caixasimg As New BitmapImage(New Uri("/CookieHell;component/img/obj.jpg", UriKind.RelativeOrAbsolute))
    'Verifica se o storyboard saltar está a decorrer ou nao(previne duplo salto)
    Dim inUse As Boolean = False
    'Número de vidas do jogador
    Dim playervidas As Integer = 3
    'Número de caixas necessários para ganhar o nivel
    Dim caixasRestantes As Integer = 10
    'Número de caixas gerados(pode ser aumentado no decorrer do jogo)
    Dim caixasNum As Integer = 1
    'Número de inimigos gerados(pode ser aumentado no decorrer do jogo)
    Dim enimigosNum As Integer = 3
    Public Sub New()
        InitializeComponent()
        lvl1()

    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub


    Public Sub player_KeyDown(sender As Object, e As KeyEventArgs)
        'verifica se o jogador nao está no ar
        If Not (inUse) Then
            'move o jogador para a direita
            If (e.Key = Key.Right) Then
                direcao = 1
                mover(player, 15.0R, direcao)
                'move o jogador para a esquerda
            ElseIf (e.Key = Key.Left) Then
                direcao = -1
                mover(player, 15.0R, direcao)
                'executa o salto do jogador
            ElseIf (e.Key = Key.Up) Then
                saltarlado()
            ElseIf (e.Key = Key.D) Then 'morre
                playervidas = 0
            ElseIf (e.Key = Key.B) Then 'gera nova caixa
                gerarCaixa() 'random
            ElseIf (e.Key = Key.L) Then 'salta de nivel
                If (lblNivel.Content = 1) Then
                    lvl2()
                ElseIf (lblNivel.Content = 2) Then
                    lvl3()
                End If
            ElseIf (e.Key = Key.E) Then 'gera novo inimigo
                gerarEnimigo() 'random
            End If
        End If
    End Sub
    Private Sub lvl1()
        Dim lvl1 As New BitmapImage(New Uri("/CookieHell;component/img/bg_game_trial.png", UriKind.RelativeOrAbsolute))
        bgimg.Source = lvl1
        bg.Width = 1600
        bg.Height = 600
        bgimg.Width = 1600
        bg.Height = 600
        caixasRestantes = 10
        playervidas = 3
        caixasNum = 1
        enimigosNum = 3
        tirarCaixa()
        tirarVida()
        While (caixas.Children.Count < caixasNum)
            gerarCaixa()
        End While
        While (enimigos.Children.Count < enimigosNum)
            gerarEnimigo()
        End While
        lblNivel.Content = 1
    End Sub
    Private Sub lvl2()
        Dim lvl2 As New BitmapImage(New Uri("/CookieHell;component/img/level_troll.png", UriKind.RelativeOrAbsolute))
        bgimg.Source = lvl2
        bg.Width = 3484
        bg.Height = 600
        bgimg.Width = 3484
        bg.Height = 600
        caixasRestantes = 15
        playervidas = 3
        caixasNum = 2
        enimigosNum = 5
        tirarCaixa()
        tirarVida()
        player.SetValue(Canvas.LeftProperty, 0.0R)
        bg.SetValue(Canvas.LeftProperty, 0.0R)
        While (caixas.Children.Count < caixasNum)
            gerarCaixa()
        End While
        While (enimigos.Children.Count < enimigosNum)
            gerarEnimigo()
        End While
        lblNivel.Content = 2
    End Sub
    Private Sub lvl3()
        Dim lvl3 As New BitmapImage(New Uri("/CookieHell;component/img/bg.png", UriKind.RelativeOrAbsolute))
        bgimg.Source = lvl3
        bg.Width = 1600
        bg.Height = 600
        bgimg.Width = 1600
        bg.Height = 600
        caixasRestantes = 20
        playervidas = 3
        caixasNum = 3
        enimigosNum = 10
        tirarCaixa()
        tirarVida()
        While (caixas.Children.Count < caixasNum)
            gerarCaixa()
        End While
        While (enimigos.Children.Count < enimigosNum)
            gerarEnimigo()
        End While
        lblNivel.Content = 3
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
    Public Sub acertouPlayer()
        Dim col As New Collection
        'Percorre todas as caixas e adiciona-as a uma nova colecção
        For Each img As Image In caixas.Children
            If Not (colisao(player, img) = 0) Then
                col.Add(img)
            End If
        Next
        'Remove todas as caixas encontradas na colecção anterior
        For Each c In col
            caixas.Children.Remove(c)
            caixasRestantes -= 1
            tirarCaixa()
            While (caixas.Children.Count < caixasNum)
                gerarCaixa()
            End While
        Next
        'Remove vida ao colidir com inimigo
        For Each img As Image In enimigos.Children
            If Not (colisao(player, img) = 0) Then
                MessageBox.Show("colidiu")
                bg.SetValue(Canvas.LeftProperty, 0.0R)
                player.SetValue(Canvas.LeftProperty, 20.0R)
                playervidas -= 1
                tirarVida()
            End If
        Next
    End Sub
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

        'Troca imagens do jogador
        If (obj.Equals(player)) Then
            If (playerimgcount = 1) Then
                player.Source = playerimg2
                playerimgcount = 2
            Else
                player.Source = playerimg1
                playerimgcount = 1
            End If
        End If
        'Move o jogador consoante a direção
        Select Case direcao
            Case -1
                esquerda(obj, distancia)
            Case 1
                direita(obj, distancia)
            Case 0
                'saltar
        End Select
        acertouPlayer()
        If (playervidas <= 0) Then
            MessageBox.Show("Game Over")
            NavigationService.Refresh()
        End If
        If (caixasRestantes <= 0) Then
            MessageBox.Show("Ganhou")
            If (lblNivel.Content = 1) Then
                lvl2()
            ElseIf lblNivel.Content = 2 Then
                lvl3()
            End If
        End If
    End Sub
    Private Sub direita(ByRef obj As Image, distancia As Double)
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
            obj.SetValue(Canvas.LeftProperty, obj.GetValue(Canvas.LeftProperty) + distancia) 'move o player
        End If
        obj.RenderTransform.SetValue(CompositeTransform.ScaleXProperty, direcao)
    End Sub
    Private Sub esquerda(ByRef obj As Image, distancia As Double)
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
        Dim daBG As New DoubleAnimationUsingKeyFrames
        Dim daTop As New DoubleAnimationUsingKeyFrames
        Dim objY As New Double
        objY = player.GetValue(Canvas.TopProperty)

        'player x
        edf1.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0))
        edf1.Value = player.GetValue(Canvas.LeftProperty)
        daLeft.KeyFrames.Add(edf1)
        edf2.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 1.6))
        edf2.Value = edf1.Value + (200 * direcao)
        daLeft.KeyFrames.Add(edf2)
        Storyboard.SetTarget(daLeft, player)
        Storyboard.SetTargetProperty(daLeft, New PropertyPath(Canvas.LeftProperty))
        st.Children.Add(daLeft)

        'bg x (bg.GetValue(Canvas.LeftProperty) + bg.ActualWidth)=bgRight
        'temporary fix
        Dim bgright As Double = bg.GetValue(Canvas.LeftProperty) + bg.ActualWidth
        Dim canvasright As Double = LayoutRoot.GetValue(Canvas.LeftProperty) + LayoutRoot.ActualWidth
        Dim bgleft As Double = bg.GetValue(Canvas.LeftProperty)
        Dim canvasleft As Double = LayoutRoot.GetValue(Canvas.LeftProperty)
        If ((bgright - canvasright) - 200 > 0 And (canvasleft - bgleft) - 200 > 0) Then
            edf1 = New EasingDoubleKeyFrame
            edf2 = New EasingDoubleKeyFrame
            edf1.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0))
            edf1.Value = bg.GetValue(Canvas.LeftProperty)
            daBG.KeyFrames.Add(edf1)
            edf2.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 1.6))
            edf2.Value = edf1.Value - (200 * direcao)
            daBG.KeyFrames.Add(edf2)
            Storyboard.SetTarget(daBG, bg)
            Storyboard.SetTargetProperty(daBG, New PropertyPath(Canvas.LeftProperty))
            st.Children.Add(daBG)
        End If

        'player y
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
        Storyboard.SetTarget(daTop, player)
        Storyboard.SetTargetProperty(daTop, New PropertyPath(Canvas.TopProperty))
        st.Children.Add(daTop)


        st.SpeedRatio = 3






    End Sub
    Private Sub stop_saltar(sender As Object, e As EventArgs)
        TryCast(sender, Storyboard).FillBehavior = FillBehavior.Stop
        acertouPlayer()
        inUse = False
    End Sub
    Private Function gerarCaixa(Optional ByVal Left As Double = 0.0R) As Boolean
        If (Left = 0) Then
            Dim rand As New Random()
            Left = rand.NextDouble() * (bg.ActualWidth - 200) 'para nao aparecer nas margens
        End If
        Dim box As New Image
        box.Source = caixasimg
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
    Private Function gerarEnimigo(Optional ByVal Left As Double = 0.0R)
        'falta evitar que nascam adjacentes
        If (Left = 0) Then
            Dim rand As New Random()
            Left = rand.NextDouble() * (bg.ActualWidth - 200) 'para nao aparecer nas margens
        End If
        Dim nemesis As New Image
        nemesis.Source = New BitmapImage(New Uri("/CookieHell;component/img/enemie.png", UriKind.RelativeOrAbsolute))
        nemesis.Width = 50.0R
        nemesis.Height = 100.0R
        nemesis.SetValue(Canvas.TopProperty, 440.0R)
        nemesis.SetValue(Canvas.LeftProperty, Left)
        For Each obj As Image In caixas.Children
            If Not (colisao(nemesis, obj) = 0 And colisao(nemesis, player) = 0) Then
                Return False
            End If
        Next
        For Each img As Image In enimigos.Children
            If Not (colisao(nemesis, img) = 0) Then
                Return False
            End If
        Next
        enimigos.Children.Add(nemesis)
        Return True
    End Function
    Private Sub tirarVida()
        vidasGrid.Children.Clear()
        For i As Integer = 0 To playervidas - 1 Step 1
            Dim image As New Image
            image.Source = vidasimg
            image.Width = 50
            image.Height = 50
            Dim column As New ColumnDefinition
            column.Width = New GridLength(50.0R)
            vidasGrid.ColumnDefinitions.Add(column)
            Grid.SetColumn(image, i)
            vidasGrid.Children.Add(image)
        Next
    End Sub
    Private Sub tirarCaixa()
        caixasGrid.Children.Clear()
        For i As Integer = 0 To caixasRestantes - 1 Step 1
            Dim image As New Image
            image.Source = caixasimg
            image.Width = 50
            image.Height = 50
            Dim column As New ColumnDefinition
            column.Width = New GridLength(50.0R)
            caixasGrid.ColumnDefinitions.Add(column)
            Grid.SetColumn(image, i)
            caixasGrid.Children.Add(image)
        Next
    End Sub
    Private Sub saltarlado()

        Dim st As New Storyboard
        storyboard_saltar(st, direcao)
        st.Begin()
        inUse = True

    End Sub
End Class
