Partial Public Class tmovimento3
    Inherits Page
    Dim direcao As Integer = 1
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
        ElseIf (e.Key = Key.Up) Then
            saltarlado()
        End If
    End Sub
    Private Sub direita()
        Dim Left As Double = bg.GetValue(Canvas.LeftProperty)
        Dim Width As Double = bg.ActualWidth
        Dim aw As Double = ActualWidth
        'MessageBox.Show("Left " + Left.ToString + "Width " + Width.ToString + "aw " + aw.ToString)
        If (aw - Left < Width) Then
            bg.SetValue(Canvas.LeftProperty, Left - 10.0R)
        End If
        'Dim trybg As Integer = bg_pontos.TranslateX - 10
        'Dim trypl As Integer = player_pontos.TranslateX + 10
        'If (trybg <= 200 And trybg >= -200 And player_pontos.TranslateX = 0) Then

        '    bg_pontos.TranslateX = trybg
        'ElseIf (trypl >= -200 And trypl <= 200) Then
        '    player_pontos.TranslateX = trypl
        'End If
        'direcao = 1
        'player_pontos.ScaleX = direcao


    End Sub
    Private Sub esquerda()
        Dim Left As Double = bg.GetValue(Canvas.LeftProperty)
        Dim Width As Double = bg.ActualWidth
        Dim aw As Double = ActualWidth

        If (Left < 0) Then
            bg.SetValue(Canvas.LeftProperty, Left + 10.0R)
        End If

        'Dim trybg As Double = bg_pontos.TranslateX + 10
        'Dim trypl As Integer = player_pontos.TranslateX - 10
        'If (trybg <= 200 And trybg >= -200 And player_pontos.TranslateX = 0) Then
        '    bg_pontos.TranslateX = trybg
        'ElseIf (trypl >= -200 And trypl <= 200) Then
        '    player_pontos.TranslateX = trypl
        'End If
        'direcao = -1
        'player_pontos.ScaleX = direcao


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

        ''Left
        'keyframemidle.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))
        'keyframefinal.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 10))
        'keyframemidle.Value = bg_pontos.TranslateX + (-direcao * 50)
        'keyframefinal.Value = keyframemidle.Value + (-direcao * 80)
        'daLeft.KeyFrames.Add(keyframemidle)
        'daLeft.KeyFrames.Add(keyframefinal)
        'Storyboard.SetTarget(daLeft, bg_pontos)
        'Storyboard.SetTargetProperty(daLeft, New PropertyPath(CompositeTransform.TranslateXProperty))
        'st.Children.Add(daLeft)

        ''Top
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
