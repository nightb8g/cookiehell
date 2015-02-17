﻿Partial Public Class tmovimento
    Inherits UserControl
    Dim direcao As Integer = 1

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub storyboard_saltar(st As Storyboard)
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

        Dim daTop As New DoubleAnimationUsingKeyFrames
        Dim daLeft As New DoubleAnimationUsingKeyFrames
        Dim keyframemidle As New EasingDoubleKeyFrame
        Dim keyframefinal As New EasingDoubleKeyFrame


        'Left
        keyframemidle.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))
        keyframefinal.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 10))
        keyframemidle.Value = player_pontos.TranslateX + (direcao * 50)
        keyframefinal.Value = keyframemidle.Value + (direcao * 80)
        daLeft.KeyFrames.Add(keyframemidle)
        daLeft.KeyFrames.Add(keyframefinal)
        Storyboard.SetTarget(daLeft, player_pontos)
        Storyboard.SetTargetProperty(daLeft, New PropertyPath(CompositeTransform.TranslateXProperty))
        st.Children.Add(daLeft)

        'Top
        keyframemidle = New EasingDoubleKeyFrame
        keyframefinal = New EasingDoubleKeyFrame
        keyframemidle.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 5))
        keyframefinal.KeyTime = KeyTime.FromTimeSpan(New TimeSpan(0, 0, 10))
        keyframemidle.Value = player_pontos.TranslateY - 100
        'keyframefinal.Value = keyframemidle.Value + 100
        keyframefinal.Value = 200
        daTop.KeyFrames.Add(keyframemidle)
        daTop.KeyFrames.Add(keyframefinal)
        Storyboard.SetTarget(daTop, player_pontos)
        Storyboard.SetTargetProperty(daTop, New PropertyPath(CompositeTransform.TranslateYProperty))

        st.Children.Add(daTop)
        st.SpeedRatio = 10
    End Sub


    Private Sub saltarlado()
        Dim st As New Storyboard
        storyboard_saltar(st)
        st.Begin()

    End Sub


    Public Sub player_KeyDown(sender As Object, e As KeyEventArgs)

        If (e.Key = Key.Right) Then
            player_pontos.TranslateX = player_pontos.TranslateX + 10
            direcao = 1 'direira
        ElseIf (e.Key = Key.Left) Then
            player_pontos.TranslateX = player_pontos.TranslateX - 10
            direcao = -1 'esquerda
        ElseIf (e.Key = Key.Up) Then
            saltarlado()
        End If
    End Sub

End Class
