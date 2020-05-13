Public Class sc_KlickAnzeige
    'Inherits aktivControl

    Private Shared stc_aktivFeld As New System.Windows.Forms.UserControl

    Private Shared ReadOnly Property sp_aktivfeld As System.Windows.Forms.UserControl
        Get
            If Not stc_aktivFeld Is Nothing Then
                Return stc_aktivFeld
            Else
                Return New System.Windows.Forms.UserControl
            End If
        End Get
    End Property

    Private Shared Sub me_setaktivFeld(ByRef ref_aktivFeld As System.Windows.Forms.UserControl)
        me_mouseleave()
        stc_aktivFeld = ref_aktivFeld
    End Sub
    Public Shared Sub me_mouseenter(ByRef ref_control As System.Windows.Forms.UserControl)
        If stc_aktivFeld Is ref_control Then Exit Sub
        me_mouseleave()
        me_setaktivFeld(ref_control)
        sp_aktivfeld.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
    End Sub
    Private Shared Sub me_mouseleave()
        sp_aktivfeld.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub
End Class
