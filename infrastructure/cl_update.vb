' %CS

Public Class cl_update
    Inherits sc_internetverbindung
    Private Shared this As cl_update
    Private Shared sv_pathlokal_newversion As String = Application.StartupPath & "\lvers"
    Private Shared sv_pathlokal_setupLink As String = Application.StartupPath & "\dl_lk"
    Private Shared sv_pathlokal_updatehistorie As String = Application.StartupPath & "\dl_updthstry"
    Private Shared sv_pathlokal_setup As String = Application.StartupPath & "\easy_Harmony_Setup.exe"
    Private Shared sv_pathserver_versionlink As String = "http://www.musik-hilfe.de/Download/version/%1%2version.txt"
    Private Shared sv_pathserver_setuppathlink As String = "http://www.musik-hilfe.de/Download/version/dl_path.txt"
    Private Shared sv_pathserver_updatehistorie As String = "http://www.musik-hilfe.de/Download/version/dl_updthstry"

    Private m_versionsnummer_installiert As cl_versionsnummer
    Private m_versionsnummer_homepage As cl_versionsnummer

    ' GETINSTANZ
    Public Shared Function getInstanz() As cl_update
        If this Is Nothing Then
            this = New cl_update
            this.m_versionsnummer_installiert = New cl_versionsnummer(cl_versionsnummer.cp_installversionsString)
        End If
        getInstanz = this
    End Function
    ' SHARED
    Public Shared Sub sv_checkupdate(Optional ByVal p_silent As Boolean = False)
        Dim l_UpdateHistorie As String
        If Not me_prüfeInternteverbindung(p_silent) Then Exit Sub
        If Not cl_Programmdaten.getInstanz.mp_ProgrammEditionsTyp = "X" Then cl_internmail.new_updateapruefung(p_silent)
        getInstanz()
        Try
            With this
                ' Internetverbindung prüfen
                ' Webseite aufrufen
                .me_holeVersionHomepage()
                If Not .me_versionaktuell() Then
                    l_UpdateHistorie = .me_Updatehistorie()
                    ' Soll die neue Version heruntergeladen werden?
                    If MsgBox("Ein neues Update ist auf www.musik-hilfe.de verfügbar." & vbCrLf & _
                              vbCrLf & l_UpdateHistorie & vbCrLf & vbCrLf & _
                           "Das Update wird jetzt heruntergeladen.", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        ' Herunterladen
                        .me_downloadSetup()
                        ' Anwendung schließen
                        'Application.Exit()
                    End If
                Else
                    If Not p_silent Then MsgBox("Du benutzt die aktuelle Version von easy Harmony.")
                End If
            End With
        Catch ex As Exception
            MsgBox("Ein Fehler ist während der Updateprüfung aufgetreten." & vbCrLf & _
                "Auf www.musik-hilfe.de findest Du die aktuelle Version von easy Harmony.")
        End Try
        My.Settings.ErstUpdate = False
    End Sub
    ' PUBLIC
    Public Sub me_downloadSetup()
        Try
            cl_internmail.new_updateanforderung()
            Dim l_downloadlink As String
            me_löscheFile(sv_pathlokal_setupLink)
            me_löscheFile(sv_pathlokal_setup)
            My.Computer.Network.DownloadFile(sv_pathserver_setuppathlink, sv_pathlokal_setupLink)
            l_downloadlink = My.Computer.FileSystem.ReadAllText(sv_pathlokal_setupLink)
            'me_löscheFile(m_path_downloadLink)
            'My.Computer.Network.DownloadFile(l_downloadlink, m_path_setup, "", "", True, 10000000, True, FileIO.UICancelOption.DoNothing)
            'me_löscheFile(m_path_setup)
            Process.Start(l_downloadlink)
            MsgBox("Bitte schließe das Programm, bevor du das Update ausführst.")
        Catch ex As Exception
            MsgBox("Ein Fehler ist während des Downloads aufgetreten." & vbCrLf & _
                "Auf www.musik-hilfe.de findest Du die aktuelle Version von easy Harmony.")
        End Try
    End Sub
    ' PRIVATE
    Private Sub me_holeVersionHomepage()
        Dim l_VersionHmepagestring As String
        Dim l_Programmdaten As cl_Programmdaten
        Dim l_pathserver_versionlink As String
        l_Programmdaten = cl_Programmdaten.getInstanz
        me_löscheFile(sv_pathlokal_newversion)

        l_pathserver_versionlink = Replace(sv_pathserver_versionlink, "%1", l_Programmdaten.mp_ProgrammEditionsTyp)
        l_pathserver_versionlink = Replace(l_pathserver_versionlink, "%2", global_BoolToInt(My.Settings.ErstUpdate))
        'My.Computer.Network.DownloadFile(l_pathserver_versionlink, sv_pathlokal_newversion, "", "", True, 1000 * 30, True, FileIO.UICancelOption.DoNothing)
        me_downloadFTPFile(l_pathserver_versionlink, sv_pathlokal_newversion)
        l_VersionHmepagestring = My.Computer.FileSystem.ReadAllText(sv_pathlokal_newversion)

        me_löscheFile(sv_pathlokal_newversion)
        m_versionsnummer_homepage = New cl_versionsnummer(l_VersionHmepagestring)
    End Sub
    Private Function me_versionaktuell() As Boolean
        me_versionaktuell = m_versionsnummer_installiert.me_Versionaktuell(m_versionsnummer_homepage)
    End Function
    Private Sub me_löscheFile(ByVal p_filepath As String)
        Try
            My.Computer.FileSystem.DeleteFile(p_filepath)
        Catch ex As Exception
            dp("OK me_löscheVersionsinfo")
        End Try
    End Sub
    Private Function me_Updatehistorie() As String
        Dim l_output As String
        Dim l_ImExpost As cl_ImExport
        Dim l_UdHy_version As Char
        Dim l_UdHy_Einträge As Integer
        Dim l_UdHy_DatumÄnderung As Integer
        Dim l_UdHy_datum As Date
        Dim l_ÄnderungText As String
        Try
            me_downloadFTPFile(sv_pathserver_updatehistorie, sv_pathlokal_updatehistorie)
            l_ImExpost = cl_ImExport.factory
            l_ImExpost.me_Imp_File(sv_pathlokal_updatehistorie, "X;")
            l_UdHy_version = l_ImExpost.me_getImp_Part
            Select Case l_UdHy_version
                Case "!"
                    l_output = "Neuste Änderungen:" & vbCrLf

                    l_UdHy_Einträge = l_ImExpost.me_getImp_Part
                    For lz_eintrag = 1 To l_UdHy_Einträge
                        l_UdHy_DatumÄnderung = l_ImExpost.me_getImp_Part
                        l_UdHy_datum = l_ImExpost.me_getImp_Part
                        If l_UdHy_datum > m_versionsnummer_installiert.m_Datum Then
                            gAppendString(l_output, l_UdHy_datum & vbCrLf)
                            For lz_Änderung = 1 To l_UdHy_DatumÄnderung
                                l_ÄnderungText = l_ImExpost.me_getImp_Part
                                gAppendString(l_output, "- " & l_ÄnderungText & vbCrLf)
                            Next
                        Else
                            Exit For
                        End If
                    Next
                Case Else
                    l_output = ""
            End Select
            me_löscheFile(sv_pathlokal_updatehistorie)
        Catch ex As Exception
            l_output = ""
        End Try
        Return l_output
    End Function
    Private Sub me_downloadFTPFile(ByVal p_FTPPath As String, ByVal p_pathLokal As String)
        My.Computer.Network.DownloadFile(p_FTPPath, p_pathLokal, "", "", True, 1000 * 30, True, FileIO.UICancelOption.DoNothing)
    End Sub
End Class
