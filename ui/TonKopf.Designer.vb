<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TonKopf
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_TonKopfZeile1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_TonKopfZeile1
        '
        Me.lbl_TonKopfZeile1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TonKopfZeile1.Location = New System.Drawing.Point(-1, -1)
        Me.lbl_TonKopfZeile1.Name = "lbl_TonKopfZeile1"
        Me.lbl_TonKopfZeile1.Size = New System.Drawing.Size(12, 27)
        Me.lbl_TonKopfZeile1.TabIndex = 2
        '
        'TonKopf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.lbl_TonKopfZeile1)
        Me.Name = "TonKopf"
        Me.Size = New System.Drawing.Size(7, 22)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_TonKopfZeile1 As System.Windows.Forms.Label

End Class
