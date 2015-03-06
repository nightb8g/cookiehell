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

        Const playerMove As Double = 10.0R 'valor do movimento
        Dim playerPosition As Double = c_go1.GetValue(Canvas.LeftProperty) 'valor da posição do obj no canvas

        Dim daLeft As New DoubleAnimationUsingKeyFrames 'conjunto keyFrame
        Dim kfEnd As New EasingDoubleKeyFrame ' keyframe [como só existe um tipo de animação e imagem associada só é necessário a ultima keyFrame]

        kfEnd.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 0.7)) 'determina o tempo da keyFrame
        kfEnd.Value = playerMove + playerPosition 'keyTime é sempre Double/Real
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

    Private Sub playerJump()
        '      <Storyboard x:Name="c_jump">
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)" Storyboard.TargetName="c_go1">
        '		<EasingDoubleKeyFrame KeyTime="0" Value="0">
        '			<EasingDoubleKeyFrame.EasingFunction>
        '				<CircleEase EasingMode="EaseOut"/>
        '			</EasingDoubleKeyFrame.EasingFunction>
        '		</EasingDoubleKeyFrame>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="8.55"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="17.1"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="30.15"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="40.2"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="49.8"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="56.85"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="64.4"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="67.45"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="72"/>
        '	</DoubleAnimationUsingKeyFrames>
        Dim daJump As New DoubleAnimationUsingKeyFrames
        Dim kf0 As New EasingDoubleKeyFrame

        kf0.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 0.1))
        kf0.Value = 8.55R

        'daJump.Key.add(kf0)

        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="c_go1">
        '		<EasingDoubleKeyFrame KeyTime="0" Value="0">
        '			<EasingDoubleKeyFrame.EasingFunction>
        '				<CircleEase EasingMode="EaseOut"/>
        '			</EasingDoubleKeyFrame.EasingFunction>
        '		</EasingDoubleKeyFrame>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="-6.9"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="-7.8"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="-9.45"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="-4.35"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="8.85"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="19.95"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="13.3"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="5.9"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="0"/>
        '	</DoubleAnimationUsingKeyFrames>
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="c_go1">
        '		<EasingDoubleKeyFrame KeyTime="0" Value="297">
        '			<EasingDoubleKeyFrame.EasingFunction>
        '				<CircleEase EasingMode="EaseOut"/>
        '			</EasingDoubleKeyFrame.EasingFunction>
        '		</EasingDoubleKeyFrame>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="281"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="265"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="249"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="233"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="233"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="254.333"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="275.667"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="297"/>
        '	</DoubleAnimationUsingKeyFrames>
        '</Storyboard>
    End Sub
    Private Sub btn_jump_Click(sender As Object, e As RoutedEventArgs) Handles btn_jump.Click
        playerWalk()
    End Sub
End Class
