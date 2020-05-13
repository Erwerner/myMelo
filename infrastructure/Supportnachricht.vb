Public Class Supportnachricht

    Private Sub btn_senden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_senden.Click
        If Not sc_internetverbindung.me_prüfeInternteverbindung Then Exit Sub
        cl_internmail.new_supportmail(Me.txtText.Text & vbCrLf & "--------- Absender: " & Me.txtAbsender.Text & vbCrLf & cl_Programmdaten.getInstanz.mp_ProgrammdatenString)
        Me.Close()
    End Sub
End Class