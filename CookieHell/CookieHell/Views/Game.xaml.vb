Partial Public Class Game
    Inherits Page

    Public Sub New()
        InitializeComponent()
    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub

    Private Sub playerWalk()
        '<Storyboard x:Name="c_move">
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="c_go1">
        '		<EasingDoubleKeyFrame KeyTime="0" Value="191"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:1" Value="201"/>
        '	</DoubleAnimationUsingKeyFrames>
        '</Storyboard>

        Const playerMove As Double = 5.0R 'valor do movimento
        Dim playerPositionX As Double = c_go1.GetValue(Canvas.LeftProperty) 'valor da posição do obj no canvas

        Dim daLeft As New DoubleAnimationUsingKeyFrames 'conjunto keyFrame
        Dim kfEnd As New EasingDoubleKeyFrame ' keyframe [como só existe um tipo de animação e imagem associada só é necessário a ultima keyFrame]

        kfEnd.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 0.7)) 'determina o tempo da keyFrame
        kfEnd.Value = playerMove + playerPositionX 'keyTime é sempre Double/Real
        'como é necessário fazer a animação continuar sempre que é executada uma ação então necessita adicionar esse valor constante 



        daLeft.KeyFrames.Add(kfEnd) 'adiciona ao obj de conjunto um elemento

        Storyboard.SetTarget(daLeft, c_go1) 'coloca o elemento no obj mãe
        Storyboard.SetTargetProperty(daLeft, New PropertyPath(Canvas.LeftProperty)) 'coloca o elemento no caminho do obj alvo

        Dim st As New Storyboard 'cria uma instancia da storyboard

        st.Children.Add(daLeft) 'adiciona o obj ao conjunto
        st.SpeedRatio = 10
        st.Begin()
        'c_go1.Source.SetValue(Media.Imaging.BitmapImage.UriSourceProperty, New Uri("/c_anda2.png", UriKind.RelativeOrAbsolute))

    End Sub

    Private Sub playerJumpY(ByRef st As Storyboard)
 

        Dim playerPositionY As Double = c_go1.GetValue(Canvas.TopProperty)
        Dim playerPositionX As Double = c_go1.GetValue(Canvas.LeftProperty)
        Dim daJump As New DoubleAnimationUsingKeyFrames
        Dim kf(6) As EasingDoubleKeyFrame  'KeyFrame

        For i As Integer = 0 To 6
            kf(i) = New EasingDoubleKeyFrame()
        Next

        '+ é sempre para baixo
        '- é sempre para cima


        kf(0).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 1))
        kf(0).Value = playerPositionY + 17.1R '17.1R

        kf(1).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 2))
        kf(1).Value = kf(0).Value + 30.15R

        kf(2).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 3)) ' 100R
        kf(2).Value = playerPositionY + (playerPositionX ^ 2) / 100 - 200

        kf(3).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 4))
        kf(3).Value = playerPositionY + (playerPositionX ^ 2) / 100 - 200
        '46.25
        kf(4).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))
        kf(4).Value = playerPositionY + (playerPositionX ^ 2) / 100 - 200

        kf(5).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 6))
        kf(5).Value = playerPositionY + (playerPositionX ^ 2) / 100 - 200

        kf(6).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 7))
        kf(6).Value = playerPositionY + (playerPositionX ^ 2) / 100 - 200

        kf(6).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 7))
        kf(6).Value = playerPositionY + (playerPositionX ^ 2) / 100 - 200
        For Each i As EasingDoubleKeyFrame In kf
            daJump.KeyFrames.Add(i)
        Next

        Storyboard.SetTarget(daJump, c_go1)
        Storyboard.SetTargetProperty(daJump, New PropertyPath(Canvas.TopProperty))


        'Dim st As New Storyboard
        st.Children.Add(daJump)
        'st.Begin()
    End Sub

    Private Sub playerJumpX(ByRef st As Storyboard, direcao As Integer)
        '     <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="c_go1">
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="8.55"/>
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="17.1"/>
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="30.15"/>
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="40.2"/>
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="49.8"/>
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="56.85"/>
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="64.4"/>
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="67.45"/>
        '	<EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="72"/>
        '   </DoubleAnimationUsingKeyFrames>
        Dim playerPositionX As Double = c_go1.GetValue(Canvas.LeftProperty)

        Dim daJump3 As New DoubleAnimationUsingKeyFrames
        Dim kf(6) As EasingDoubleKeyFrame  'KeyFrame

        For i As Integer = 0 To 6
            kf(i) = New EasingDoubleKeyFrame()
        Next

        kf(0).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 1))
        kf(0).Value = playerPositionX + 25.0R '8.55R
        'playerPositionLeft = 191
        kf(1).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 2))
        kf(1).Value = kf(0).Value + 25.0R '17.1R

        kf(2).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 3))
        kf(2).Value = kf(1).Value + 25.0R '30.15R

        kf(3).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 4))
        kf(3).Value = kf(2).Value + 25.0R '40.2R

        kf(4).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))
        kf(4).Value = kf(3).Value + 25.0R '49.8R

        kf(5).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 6))
        kf(5).Value = kf(4).Value + 25.0R '56.85R

        kf(6).KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 7))
        kf(6).Value = kf(5).Value + 25.0R '64.4R


        For Each i As EasingDoubleKeyFrame In kf
            daJump3.KeyFrames.Add(i)
        Next

        Storyboard.SetTarget(daJump3, c_go1)
        Storyboard.SetTargetProperty(daJump3, New PropertyPath(Canvas.LeftProperty))


        'Dim st As New Storyboard
        st.Children.Add(daJump3)
        'st.Begin()
    End Sub
    Private Sub btn_jump_Click(sender As Object, e As RoutedEventArgs) Handles btn_jump.Click
        Dim st As New Storyboard
        jmp(st, c_go1)
        st.Begin()
        'playerJumpEnd()
    End Sub


    Public Sub jmp(ByRef st As Storyboard, ByRef player As Image)

        '       <Storyboard x:Name="jmp">
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="c_go1">
        '		<EasingDoubleKeyFrame KeyTime="0" Value="191"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:1" Value="391"/>
        '	</DoubleAnimationUsingKeyFrames>
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="c_go1">
        '		<EasingDoubleKeyFrame KeyTime="0" Value="297"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="97">
        '			<EasingDoubleKeyFrame.EasingFunction>
        '				<CubicEase EasingMode="EaseOut"/>
        '			</EasingDoubleKeyFrame.EasingFunction>
        '		</EasingDoubleKeyFrame>
        '		<EasingDoubleKeyFrame KeyTime="0:0:1" Value="297"/>
        '	</DoubleAnimationUsingKeyFrames>
        '</Storyboard>

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
        edf2.Value = edf1.Value + 200
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

    Private Sub btn_run_Click(sender As Object, e As RoutedEventArgs) Handles btn_run.Click
        playerWalk()
    End Sub
End Class
