Partial Public Class tmovimento
    Inherits UserControl
    Dim direcao As Integer = 1


    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub story_saltar(left, top, img)
        '      <Storyboard x:Name="saltar">
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="player">
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="140"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="190"/>
        '	</DoubleAnimationUsingKeyFrames>
        '	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="player">
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="60"/>
        '		<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="110"/>
        '	</DoubleAnimationUsingKeyFrames>
        '</Storyboard>
        Dim daTop As New DoubleAnimationUsingKeyFrames
        Dim daLeft As New DoubleAnimationUsingKeyFrames
        Dim keyframemidle As New EasingDoubleKeyFrame
        Dim keyframefinal As New EasingDoubleKeyFrame

        Dim st As New Storyboard


        keyframemidle.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 3))
        keyframefinal.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))


        'Left
        keyframemidle.Value = left + (direcao * 50)
        keyframefinal.Value = keyframefinal.Value + (direcao * 50)
        daLeft.KeyFrames.Add(keyframemidle)
        daLeft.KeyFrames.Add(keyframefinal)

        keyframemidle = New EasingDoubleKeyFrame
        keyframefinal = New EasingDoubleKeyFrame
        keyframemidle.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 3))
        keyframefinal.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))

        'Top
        keyframemidle.Value = top - (direcao * 50)
        keyframefinal.Value = keyframefinal.Value + (direcao * 50)

        daTop.KeyFrames.Add(keyframemidle)
        daTop.KeyFrames.Add(keyframefinal)


        Storyboard.SetTarget(daTop, player)
        Storyboard.SetTargetProperty(daTop, New PropertyPath(img.Margin.Top))
        Storyboard.SetTarget(daLeft, player)
        Storyboard.SetTargetProperty(daLeft, New PropertyPath(img.Margin.Left))

        st.Children.Add(daLeft)
        st.Children.Add(daTop)
        st.Begin()
    End Sub


    Private Sub saltarlado(img As UserControl)

        story_saltar(img.Margin.Left, img.Margin.Top, img)

    End Sub


    Public Sub player_KeyDown(sender As Object, e As KeyEventArgs)

        If (e.Key = Key.Right) Then
            player_pontos.TranslateX = player_pontos.TranslateX + 100
            direcao = 1
        ElseIf (e.Key = Key.Left) Then
            player_pontos.TranslateX = player_pontos.TranslateX - 100
            direcao = -1
        ElseIf (e.Key = Key.Up) Then


        End If
    End Sub

End Class
