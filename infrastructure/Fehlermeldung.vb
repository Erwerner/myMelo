Public Class Fehlermeldung



    Private Sub btn_beenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_beenden.Click
        Application.Exit()
    End Sub

    Private Sub btn_weiter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_weiter.Click
        On Error Resume Next
        Me.Close()
    End Sub

    Private Sub btn_senden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_senden.Click
        cl_internmail.new_fehlermeldung()
    End Sub

    Private Sub Fehlermeldung_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.btn_senden.Enabled = sc_internetverbindung.me_prüfeInternteverbindung(True)
    End Sub
End Class