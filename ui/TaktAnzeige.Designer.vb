<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Taktanzeige
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
        Me.lblAkkordfunktion = New System.Windows.Forms.Label()
        Me.lblTaktNr = New System.Windows.Forms.Label()
        Me.pnlTaktinfo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_ton3 = New System.Windows.Forms.Label()
        Me.cboAkkordAuswahl = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_ton2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_grundton = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.pnl_Taktinfo = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pnlTaktinfo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAkkordfunktion
        '
        Me.lblAkkordfunktion.AutoSize = True
        Me.lblAkkordfunktion.BackColor = System.Drawing.Color.Gainsboro
        Me.lblAkkordfunktion.Font = New System.Drawing.Font("MS Reference Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAkkordfunktion.Location = New System.Drawing.Point(-2, 21)
        Me.lblAkkordfunktion.Name = "lblAkkordfunktion"
        Me.lblAkkordfunktion.Size = New System.Drawing.Size(45, 12)
        Me.lblAkkordfunktion.TabIndex = 1
        Me.lblAkkordfunktion.Text = "Label1"
        '
        'lblTaktNr
        '
        Me.lblTaktNr.AutoSize = True
        Me.lblTaktNr.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTaktNr.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaktNr.Location = New System.Drawing.Point(0, 0)
        Me.lblTaktNr.Name = "lblTaktNr"
        Me.lblTaktNr.Size = New System.Drawing.Size(50, 15)
        Me.lblTaktNr.TabIndex = 2
        Me.lblTaktNr.Text = "Label1"
        '
        'pnlTaktinfo
        '
        Me.pnlTaktinfo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlTaktinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTaktinfo.Controls.Add(Me.Panel1)
        Me.pnlTaktinfo.Controls.Add(Me.lblTaktNr)
        Me.pnlTaktinfo.Controls.Add(Me.ShapeContainer2)
        Me.pnlTaktinfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTaktinfo.Name = "pnlTaktinfo"
        Me.pnlTaktinfo.Size = New System.Drawing.Size(90, 121)
        Me.pnlTaktinfo.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lbl_ton3)
        Me.Panel1.Controls.Add(Me.cboAkkordAuswahl)
        Me.Panel1.Controls.Add(Me.lblAkkordfunktion)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lbl_ton2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lbl_grundton)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(117, 81)
        Me.Panel1.TabIndex = 12
        '
        'lbl_ton3
        '
        Me.lbl_ton3.AutoSize = True
        Me.lbl_ton3.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ton3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ton3.Location = New System.Drawing.Point(63, 64)
        Me.lbl_ton3.Name = "lbl_ton3"
        Me.lbl_ton3.Size = New System.Drawing.Size(41, 15)
        Me.lbl_ton3.TabIndex = 8
        Me.lbl_ton3.Text = "Label3"
        '
        'cboAkkordAuswahl
        '
        Me.cboAkkordAuswahl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAkkordAuswahl.FormattingEnabled = True
        Me.cboAkkordAuswahl.Location = New System.Drawing.Point(1, 1)
        Me.cboAkkordAuswahl.Name = "cboAkkordAuswahl"
        Me.cboAkkordAuswahl.Size = New System.Drawing.Size(114, 21)
        Me.cboAkkordAuswahl.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Ton 3"
        '
        'lbl_ton2
        '
        Me.lbl_ton2.AutoSize = True
        Me.lbl_ton2.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ton2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ton2.Location = New System.Drawing.Point(63, 51)
        Me.lbl_ton2.Name = "lbl_ton2"
        Me.lbl_ton2.Size = New System.Drawing.Size(41, 15)
        Me.lbl_ton2.TabIndex = 7
        Me.lbl_ton2.Text = "Label2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Ton 2"
        '
        'lbl_grundton
        '
        Me.lbl_grundton.AutoSize = True
        Me.lbl_grundton.BackColor = System.Drawing.Color.Transparent
        Me.lbl_grundton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_grundton.Location = New System.Drawing.Point(63, 38)
        Me.lbl_grundton.Name = "lbl_grundton"
        Me.lbl_grundton.Size = New System.Drawing.Size(41, 15)
        Me.lbl_grundton.TabIndex = 6
        Me.lbl_grundton.Text = "Label1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Grundton"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.pnl_Taktinfo})
        Me.ShapeContainer2.Size = New System.Drawing.Size(88, 119)
        Me.ShapeContainer2.TabIndex = 5
        Me.ShapeContainer2.TabStop = False
        '
        'pnl_Taktinfo
        '
        Me.pnl_Taktinfo.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_Taktinfo.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.pnl_Taktinfo.Location = New System.Drawing.Point(-3, -3)
        Me.pnl_Taktinfo.Name = "pnl_Taktinfo"
        Me.pnl_Taktinfo.Size = New System.Drawing.Size(91, 126)
        '
        'Taktanzeige
        '
        Me.Controls.Add(Me.pnlTaktinfo)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Taktanzeige"
        Me.Size = New System.Drawing.Size(424, 138)
        Me.pnlTaktinfo.ResumeLayout(False)
        Me.pnlTaktinfo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblAkkordfunktion As System.Windows.Forms.Label
    Friend WithEvents lblTaktNr As System.Windows.Forms.Label
    Friend WithEvents pnlTaktinfo As System.Windows.Forms.Panel
    Friend WithEvents cboAkkordAuswahl As System.Windows.Forms.ComboBox
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents pnl_Taktinfo As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lbl_ton3 As System.Windows.Forms.Label
    Friend WithEvents lbl_ton2 As System.Windows.Forms.Label
    Friend WithEvents lbl_grundton As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
