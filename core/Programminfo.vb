Public Class Programminfo

        ' Standard-Mailclient starten und neue Nachricht erstellen
    Private Sub NeueNachricht() 
        Process.Start("mailto: " & "info@musik-hilfe.de")
    End Sub
     
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        NeueNachricht()
    End Sub

    Private Sub Programminfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lbl_Version.Text = cl_versionsnummer.cp_installVersionsdatum & " v0.9"
    End Sub
End Class