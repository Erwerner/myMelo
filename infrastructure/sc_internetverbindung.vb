Public Class sc_internetverbindung
    Public Shared Function me_prüfeInternteverbindung(Optional ByVal p_silent As Boolean = False)
        Dim siteResponds As Boolean = False
        Try
            siteResponds = My.Computer.Network.Ping("www.google.com")
        Catch
            siteResponds = False
            If Not p_silent Then MsgBox("Es besteht keine Verbindung zum Internet.")
        End Try
        me_prüfeInternteverbindung = siteResponds
    End Function
End Class
