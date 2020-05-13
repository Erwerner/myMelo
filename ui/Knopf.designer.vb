<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Knopf
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.pnlBack = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.knopfschatten = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.knopftop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.knopftop, Me.RectangleShape1, Me.knopfschatten, Me.pnlBack})
        Me.ShapeContainer1.Size = New System.Drawing.Size(150, 70)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'pnlBack
        '
        Me.pnlBack.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBack.BackColor = System.Drawing.Color.Red
        Me.pnlBack.BorderColor = System.Drawing.Color.Transparent
        Me.pnlBack.FillColor = System.Drawing.Color.WhiteSmoke
        Me.pnlBack.FillGradientColor = System.Drawing.Color.DarkGray
        Me.pnlBack.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Vertical
        Me.pnlBack.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.pnlBack.Location = New System.Drawing.Point(0, 0)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = Me.Size
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(9, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Knopf"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'knopfschatten
        '
        Me.knopfschatten.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.knopfschatten.BackColor = System.Drawing.Color.Transparent
        Me.knopfschatten.BorderColor = System.Drawing.Color.Transparent
        Me.knopfschatten.CornerRadius = 10
        Me.knopfschatten.FillColor = System.Drawing.Color.DarkGray
        Me.knopfschatten.FillGradientColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.knopfschatten.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.ForwardDiagonal
        Me.knopfschatten.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.knopfschatten.Location = New System.Drawing.Point(5, 25)
        Me.knopfschatten.Name = "knopfschatten"
        Me.knopfschatten.Size = New System.Drawing.Size(140, 25)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape1.BackColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Black
        Me.RectangleShape1.BorderWidth = 2
        Me.RectangleShape1.CornerRadius = 10
        Me.RectangleShape1.FillColor = System.Drawing.Color.Gainsboro
        Me.RectangleShape1.FillGradientColor = System.Drawing.Color.Silver
        Me.RectangleShape1.Location = New System.Drawing.Point(2, 20)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(142, 28)
        '
        'knopftop
        '
        Me.knopftop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.knopftop.BackColor = System.Drawing.Color.LightGray
        Me.knopftop.BorderColor = System.Drawing.Color.DarkGray
        Me.knopftop.CornerRadius = 10
        Me.knopftop.FillColor = System.Drawing.Color.Gainsboro
        Me.knopftop.FillGradientColor = System.Drawing.Color.Silver
        Me.knopftop.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.knopftop.Location = New System.Drawing.Point(2, 18)
        Me.knopftop.Name = "knopftop"
        Me.knopftop.Size = New System.Drawing.Size(140, 25)
        '
        'Knopf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "Knopf"
        Me.Size = New System.Drawing.Size(150, 70)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlBack As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents knopftop As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents knopfschatten As Microsoft.VisualBasic.PowerPacks.RectangleShape

End Class
