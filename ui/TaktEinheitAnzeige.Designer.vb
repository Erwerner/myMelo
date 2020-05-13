<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TakteinheitAnzeige
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
    Private Sub InitializeComponent(ByVal p_Taktindex As Integer, ByVal p_taktEinheitindex As Integer)
        Me.Toncursor2 = New easy_Harmony.Toncursor(p_Taktindex, p_taktEinheitindex)
        Me.SuspendLayout()
        '
        'Toncursor2
        '
        Me.Toncursor2.BackColor = c_Color_Note
        Me.Toncursor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Toncursor2.Location = New System.Drawing.Point(0, 0)
        Me.Toncursor2.Name = "Toncursor2"
        Me.Toncursor2.Size = New System.Drawing.Size(globDes_BreiteTonCursor, globDes_BreiteTonCursor)
        Me.Toncursor2.Visible = False
        Me.Toncursor2.TabIndex = 0
        '
        'TakteinheitAnzeige
        '
        Me.Controls.Add(Me.Toncursor2)
        Me.Name = "TakteinheitAnzeige"
        Me.ResumeLayout(False)
        Me.BackColor = c_color_Takteinheiteingabe_Back

    End Sub
    Friend WithEvents Toncursor2 As easy_Harmony.Toncursor

End Class
