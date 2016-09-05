Public Class slider
    Dim asd As Boolean
    Dim xs As Integer
    Dim dsa As Integer
    Public sety As Boolean

    Public Event SetyChanged as EventHandler
    Private Sub Button1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        asd = True
        Dim MousePosition As Point
        MousePosition = Cursor.Position
        xs = MousePosition.X

    End Sub

    Private Sub Button1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        If asd = True Then
            Dim MousePosition As Point
            MousePosition = Cursor.Position
            dsa = MousePosition.X
            Dim movem As Integer

            If dsa < xs Then
                movem = (xs - dsa)
                If Button1.Left <= PictureBox1.Left Then
                    Button1.Left = PictureBox1.Left

                Else
                    Button1.Left = Button1.Left - movem

                End If
            ElseIf dsa > xs Then
                movem = (dsa - xs)
                If (Button1.Left + Button1.Width) >= (PictureBox1.Left + PictureBox1.Width) Then
                    Button1.Left = ((PictureBox1.Left + PictureBox1.Width) - Button1.Width)
                Else
                    Button1.Left = Button1.Left + movem

                End If
            End If
            xs = MousePosition.X
        End If
    End Sub

    Private Sub Button1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseUp
        asd = False
        Dim midimage As Integer
        Dim midbutt As Integer
        midbutt = CInt((Button1.Width / 2))
        midimage = CInt((PictureBox1.Width / 2))
        midbutt = Button1.Left + midbutt
        midimage = PictureBox1.Left + midimage

        If midbutt <= midimage Then
            Button1.Left = PictureBox1.Left
            sety = False
        End If

        If midbutt > midimage Then
            Button1.Left = ((PictureBox1.Left + PictureBox1.Width) - Button1.Width)
            sety = True
        End If
       
        RaiseEvent SetyChanged(Me,EventArgs.Empty)
    End Sub
    Public Sub onme()
        Button1.Left = (PictureBox1.Left + PictureBox1.Width) - Button1.Width
        sety = True
    End Sub
    Public Sub offme()
        Button1.Left = PictureBox1.Left
        sety = False
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If Button1.Left = PictureBox1.Left Then
            sety = True
            Button1.Left = ((PictureBox1.Left + PictureBox1.Width) - Button1.Width)
        Else
            sety = False
            Button1.Left = PictureBox1.Left
        End If
        RaiseEvent SetyChanged(Me,EventArgs.Empty)
    End Sub
End Class