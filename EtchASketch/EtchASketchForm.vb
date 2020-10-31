
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

        g = drawbox.CreateGraphics

        If lastX = Nothing Then
            g.DrawLine(drawPen, x, y, x, y)
        Else
            g.DrawLine(drawPen, x, y, lastX, lastY)
        End If

        lastX = x
        lastY = y

    End Sub

    Sub Eraser(x As Integer, y As Integer)

        g = drawbox.CreateGraphics

        If lastX = Nothing Then
            g.DrawLine(drawPen, x, y, x, y)
        Else
            g.DrawLine(drawPen, x, y, lastX, lastY)
        End If

        lastX = x
        lastY = y

    End Sub

    Sub PictureBox1_Click(sender As Object, e As MouseEventArgs) Handles drawbox.MouseDown, drawbox.MouseMove
        ActiveControl = drawbox
        If e.Button.ToString = "left" Then
            Draw(e.X, e.Y)
        ElseIf e.Button.ToString = "left" Then
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
            drawbox.Left = drawbox.Left + 5
            drawbox.Top = drawbox.Top + 5
            drawbox.Left = drawbox.Left - 10
            drawbox.Top = drawbox.Top - 10
            drawbox.Left = drawbox.Left + 10
            drawbox.Top = drawbox.Top + 10
            drawbox.Left = drawbox.Left - 5
            drawbox.Top = drawbox.Top - 5
        Next

        If g IsNot Nothing Then
            g.Clear(Color.FromName("control"))
        End If

    End Sub

    Private Sub drawbox_MouseUp(sender As Object, e As MouseEventArgs) Handles drawbox.MouseUp
        lastX = 0
        lastY = 0
    End Sub



    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click
        Clear()
    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click, SelectColorToolStripMenuItem.Click
        ColorChooser()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, EditToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub DrawWaveformsButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click

        If g IsNot Nothing Then
            g.Clear(Color.FromName("Control"))
        End If

        DrawWaveform()

    End Sub

    Private Sub EtchASketchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = drawbox
    End Sub

    Sub DrawWaveform()
        Dim SinPen As New System.Drawing.Pen(Color.Black, 3)
        Dim CoSinPen As New System.Drawing.Pen(Color.Red, 3)
        Dim TangentPen As New System.Drawing.Pen(Color.Blue, 3)
        Dim LinePen As New System.Drawing.Pen(Color.Black, 3)
        Dim x As Double
        Dim y As Double
        g = drawbox.CreateGraphics

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

            y = Math.Sin(Cycles / 400 * 2 * Math.PI) * 20 + 150
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
