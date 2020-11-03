
'Luis Torres
'RCET0265
'Fall 2020
'Etch-A-Sketch
'https://github.com/LuisTorres0419/EtchASketch.git

Option Strict On
Option Explicit On

Public Class EtchASketchForm

    Dim drawPen As New System.Drawing.Pen(Color.Black, 1)
    Dim erasePen As New System.Drawing.Pen(Color.FromName("control"), 10)
    Dim sinePen As New Pen(Color.Black, 10)
    Dim g As System.Drawing.Graphics
    Dim lastX, lastY As Integer


    Sub Draw(x As Integer, y As Integer)

        g = DrawBox.CreateGraphics

        If lastX = Nothing Then
            g.DrawLine(drawPen, x, y, x, y)
        Else
            g.DrawLine(drawPen, x, y, lastX, lastY)
        End If

        lastX = x
        lastY = y

    End Sub

    Sub Eraser(x As Integer, y As Integer)

        g = DrawBox.CreateGraphics

        If lastX = Nothing Then
            g.DrawLine(drawPen, x, y, x, y)
        Else
            g.DrawLine(drawPen, x, y, lastX, lastY)
        End If

        lastX = x
        lastY = y

    End Sub

    Sub PictureBox1_MouseHoldMove(sender As Object, e As MouseEventArgs) Handles DrawBox.MouseDown, DrawBox.MouseMove
        ActiveControl = DrawBox
        If e.Button.ToString = "Left" Then
            Draw(e.X, e.Y)
        ElseIf e.Button.ToString = "Right" Then
            Eraser(e.X, e.Y)
        ElseIf e.Button.ToString = "Middle" Then
            ColorChooser()
        End If

    End Sub

    Sub ColorChooser()
        ColorChoose.ShowDialog()
        drawPen.Color = ColorChoose.Color
    End Sub

    Sub Clear()

        For i = 1 To 100
            DrawBox.Left = DrawBox.Left + 5
            DrawBox.Top = DrawBox.Top + 5
            DrawBox.Left = DrawBox.Left - 10
            DrawBox.Top = DrawBox.Top - 10
            DrawBox.Left = DrawBox.Left + 10
            DrawBox.Top = DrawBox.Top + 10
            DrawBox.Left = DrawBox.Left - 5
            DrawBox.Top = DrawBox.Top - 5
        Next

        If g IsNot Nothing Then
            g.Clear(Color.FromName("control"))
        End If

    End Sub

    Private Sub DrawBox_MouseUp(sender As Object, e As MouseEventArgs) Handles DrawBox.MouseUp

        lastX = 0
        lastY = 0
    End Sub



    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click
        Clear()
    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click, SelectColorToolStripMenuItem.Click
        ColorChooser()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub DrawWaveformsButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click

        If g IsNot Nothing Then
            g.Clear(Color.FromName("Control"))
        End If

        DrawWaveform()

    End Sub

    Private Sub EtchASketchForm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ActiveControl = DrawBox
    End Sub

    Sub DrawWaveform()
        Dim SinPen As New System.Drawing.Pen(Color.Black, 3)
        Dim CoSinPen As New System.Drawing.Pen(Color.Red, 3)
        Dim TangentPen As New System.Drawing.Pen(Color.Blue, 3)
        Dim LinePen As New System.Drawing.Pen(Color.Black, 3)
        Dim x As Double
        Dim y As Double
        g = DrawBox.CreateGraphics

        For i = 1 To 10
            g.DrawLine(LinePen, 62 * i, 500, 62 * i, -500)
            g.DrawLine(LinePen, 1000, 34 * i, -1000, 34 * i)
        Next

        For Cycles As Double = 0 To 1000

            y = Math.Sin(Cycles / 400 * 2 * Math.PI) * 100 + 150
            x = Cycles
            g.DrawLine(SinPen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))

        Next

        For Cycles As Double = 0 To 100

            y = Math.Sin(Cycles / 400 * 2 * Math.PI) * 100 + 150
            x = Cycles
            g.DrawLine(SinPen, CType(x, Single), CType(y, Single), CType(x, Single) + 1, CType(y, Single))

        Next

        For Cycles As Double = 0 To 100

            y = Math.Sin(Cycles / 400 * 2 * Math.PI) * 100 + 150
            x = Cycles

            If lastX = Nothing Then
                lastX = CInt(x)
                lastY = CInt(y)
            ElseIf y - lastY < -50 Then
                lastX = CInt(x)
                lastY = CInt(y)
            End If

            g.DrawLine(SinPen, CType(x, Single), CType(y, Single), lastX, lastY)

            lastX = CInt(x)
            lastY = CInt(y)

        Next

    End Sub

End Class
