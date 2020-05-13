Public Class Steuerleiste
    Public Sub New()
        InitializeComponent()

        Me.RectangleShape2.Size = Me.Size
        'Me.pnlSchatten.Size = Me.Size
        Me.Size = New System.Drawing.Size(Me.Size.Width + 3, c_size_Kontrollleiste + 3)
        Me.RectangleShape2.Size = New System.Drawing.Size(Me.RectangleShape2.Size.Width - 3, c_size_Kontrollleiste - 3)
        'Me.pnlSchatten.Size = New System.Drawing.Size(Me.pnlSchatten.Size.Width - 3, c_size_Kontrollleiste - 3)

    End Sub
    Public Sub me_init(ByVal p_Titel As String)
        Me.lblTitel.Text = p_Titel
    End Sub
End Class
