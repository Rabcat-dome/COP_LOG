Public Class PlaceHolderTextBox
    Inherits TextBox

    Dim isPlaceHolder As Boolean = True
    Dim _placeHolderText As String
    Public Property PlaceHolderText As String
        Get
            Return _placeHolderText
        End Get
        Set(value As String)
            _placeHolderText = value
            setPlaceholder()
        End Set
    End Property

    Private Sub setPlaceholder() Handles Me.LostFocus 'when the control loses focus, the placeholder is shown
        If Me.Text = "" Then
            Me.Text = PlaceHolderText
            Me.ForeColor = Color.Gray
            Me.Font = New Font(Me.Font, FontStyle.Italic)
            isPlaceHolder = True
        End If
    End Sub

    Private Sub removePlaceHolder() Handles Me.GotFocus 'when the control is focused, the placeholder is removed

        If isPlaceHolder Then
            Me.Text = ""
            Me.ForeColor = Color.Blue
            Me.Font = New Font(Me.Font, FontStyle.Regular)
            isPlaceHolder = False
        End If
    End Sub
End Class