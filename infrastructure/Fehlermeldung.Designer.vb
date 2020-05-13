<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fehlermeldung
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fehlermeldung))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_beenden = New System.Windows.Forms.Button()
        Me.btn_weiter = New System.Windows.Forms.Button()
        Me.btn_senden = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(44, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 57)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ein Fehler ist aufgetreten." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Soll der Fehler zur Bearbeitung an das Support-Tea" & _
            "m gesendet werden?"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.easy_Harmony.My.Resources.Resources.Actions_messagebox_warning_icon
        Me.PictureBox1.Location = New System.Drawing.Point(5, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 27)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btn_beenden
        '
        Me.btn_beenden.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_beenden.Image = Global.easy_Harmony.My.Resources.Resources.Actions_process_stop_icon
        Me.btn_beenden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_beenden.Location = New System.Drawing.Point(174, 74)
        Me.btn_beenden.Name = "btn_beenden"
        Me.btn_beenden.Size = New System.Drawing.Size(87, 26)
        Me.btn_beenden.TabIndex = 2
        Me.btn_beenden.Text = "Beenden"
        Me.btn_beenden.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_beenden.UseVisualStyleBackColor = True
        '
        'btn_weiter
        '
        Me.btn_weiter.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_weiter.Image = Global.easy_Harmony.My.Resources.Resources.Arrow_right_icon
        Me.btn_weiter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_weiter.Location = New System.Drawing.Point(96, 74)
        Me.btn_weiter.Name = "btn_weiter"
        Me.btn_weiter.Size = New System.Drawing.Size(76, 26)
        Me.btn_weiter.TabIndex = 1
        Me.btn_weiter.Text = "Weiter"
        Me.btn_weiter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_weiter.UseVisualStyleBackColor = True
        '
        'btn_senden
        '
        Me.btn_senden.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_senden.Image = Global.easy_Harmony.My.Resources.Resources.Mail_icon
        Me.btn_senden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_senden.Location = New System.Drawing.Point(12, 74)
        Me.btn_senden.Name = "btn_senden"
        Me.btn_senden.Size = New System.Drawing.Size(82, 26)
        Me.btn_senden.TabIndex = 0
        Me.btn_senden.Text = "Senden"
        Me.btn_senden.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_senden.UseVisualStyleBackColor = True
        '
        'Fehlermeldung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(266, 105)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_beenden)
        Me.Controls.Add(Me.btn_weiter)
        Me.Controls.Add(Me.btn_senden)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fehlermeldung"
        Me.Text = "Fehlermeldung"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_senden As System.Windows.Forms.Button
    Friend WithEvents btn_weiter As System.Windows.Forms.Button
    Friend WithEvents btn_beenden As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
