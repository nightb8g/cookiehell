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
        Dim playerPosition As Double = c_go1.GetValue(Canvas.LeftProperty) 'valor da posição do obj no canvas

        Dim daLeft As New DoubleAnimationUsingKeyFrames 'conjunto keyFrame
        Dim kfEnd As New EasingDoubleKeyFrame ' keyframe [como só existe um tipo de animação e imagem associada só é necessário a ultima keyFrame]

        kfEnd.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 1)) 'determina o tempo da keyFrame
        kfEnd.Value = playerMove + playerPosition 'keyTime é sempre Double/Real
        'como é necessário fazer a animação continuar sempre que é executada uma ação então necessita adicionar esse valor constante 



        daLeft.KeyFrames.Add(kfEnd) 'adiciona ao obj de conjunto um elemento

        Storyboard.SetTarget(daLeft, c_go1) 'coloca o elemento no obj mãe
        Storyboard.SetTargetProperty(daLeft, New PropertyPath(Canvas.LeftProperty)) 'coloca o elemento no caminho do obj alvo

        Dim st As New Storyboard 'cria uma instancia da storyboard

        st.Children.Add(daLeft) 'adiciona o obj ao conjunto
        st.Begin()
        'c_go1.Source.SetValue(Media.Imaging.BitmapImage.UriSourceProperty, New Uri("c_anda1.png", UriKind.RelativeOrAbsolute))

    End Sub

    Private Sub playerJump()

    End Sub
    Private Sub btn_jump_Click(sender As Object, e As RoutedEventArgs) Handles btn_jump.Click
        playerWalk()
    End Sub
End Class
