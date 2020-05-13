'%CS
Imports System.Net.Mail
Public Class cl_internmail
    Inherits sc_internetverbindung
    Private m_Empfänger As String
    Private m_Betreff As String
    Private m_text As String
    Private m_absender As String
    Private m_absenderadresse As String

    ' SHARED
    Private Shared ReadOnly Property sp_Programminfo As String
        Get
            Return cl_Programmdaten.getInstanz.mp_ProgrammdatenString & " " & cl_versionsnummer.cp_installversionsString
        End Get
    End Property
    ' KONSTRUKTOR
    Private Sub New(ByVal p_Empfänger As String,
                     ByVal p_Betreff As String,
                     ByVal p_text As String,
                     ByVal p_absender As String,
                     ByVal p_absenderadresse As String)

        m_Empfänger = p_Empfänger
        m_Betreff = p_Betreff
        m_text = p_text
        m_absender = p_absender
        m_absenderadresse = p_absenderadresse
    End Sub
    ' FACTORY
    Private Shared Function factory(Optional ByVal p_Empfänger As String = "mailerror@musik-hilfe.de",
                    Optional ByVal p_Betreff As String = "fehlt",
                    Optional ByVal p_text As String = "fehlt",
                    Optional ByVal p_absender As String = "Programm",
                    Optional ByVal p_absenderadresse As String = "ehProgsend@musik-hilfe.de") As cl_internmail
        If Not me_prüfeInternteverbindung() Then
            factory = Nothing
            Exit Function
        End If
        factory = New cl_internmail(p_Empfänger, p_Betreff, p_text, p_absender, p_absenderadresse)
    End Function
    ' SHARED
    Public Shared Sub new_supportmail(ByVal p_Text As String, Optional ByVal p_titel As String = "Support")
        'ByVal ref_senden As Boolean, 
        Dim l_mail As cl_internmail
        l_mail = factory("SupportEH@musik-hilfe.de", p_titel, p_Text, "ehProgsend@musik-hilfe.de")
        'If l_mail Is Nothing Then ref_senden = False : Exit Sub
         
            'new_supportmail = l_mail
            'If ref_senden Then
            'ref_senden = False
            If l_mail.me_senden(True) Then
                MsgBox("Vielen Dank für deine Nachricht." & vbCrLf & "Wir werden deine Anfrage so schnell wie möglich bearbeiten." & vbCrLf & vbCrLf & " Das easy-Harmony-Team")
                'ref_senden = True
            End If
            'End If 
    End Sub
    Public Shared Sub new_updateanforderung()
        Dim l_mail As cl_internmail
        l_mail = factory("UpdateAnforderung@musik-hilfe.de", "Updateanforderung " & sp_Programminfo, "", "ehProgsend@musik-hilfe.de")
        If l_mail Is Nothing Then Exit Sub
        l_mail.me_senden(True)
    End Sub
    Public Shared Sub new_updateapruefung(ByVal p_silent As Boolean)
        Dim l_mail As cl_internmail
        Dim l_Updatetyp_str As String
        l_Updatetyp_str = ""
        'If cl_Programmdaten.getInstanz.mp_erstUpdate Then gAppendString(l_Updatetyp_str, "Erststart ")
        If My.Settings.ErstUpdate Then gAppendString(l_Updatetyp_str, "ErstUpdate ")
        If p_silent Then gAppendString(l_Updatetyp_str, "Auto ") 
        l_mail = factory("UpdatePruefung@musik-hilfe.de", l_Updatetyp_str & "Updateprüfung " & sp_Programminfo, "", "ehProgsend@musik-hilfe.de")
        If l_mail Is Nothing Then Exit Sub
        l_mail.me_senden(True)
    End Sub
    Public Shared Sub new_fehlermeldung()
        Dim l_mail As cl_internmail
        l_mail = factory("SupportEH@musik-hilfe.de", "Fehlermeldung", sc_Fehlerbehandlung.mp_fehlertext)
        l_mail.me_senden(, True)
    End Sub
    ' PRIVATE
    Private Function me_senden(Optional ByVal p_silent As Boolean = False, Optional ByVal p_mitProgrammdaten As Boolean = False) As Boolean
        Dim Msg As New MailMessage
        Dim myCredentials As New System.Net.NetworkCredential
        me_senden = False

        myCredentials.UserName = m_absenderadresse
        myCredentials.Password = "123Start"

        Msg.IsBodyHtml = False

        Dim mySmtpsvr As New SmtpClient()
        mySmtpsvr.Host = "mail.musik-hilfe.de"
        mySmtpsvr.Port = 25

        mySmtpsvr.UseDefaultCredentials = False
        mySmtpsvr.Credentials = myCredentials

        Try
            Msg.From = New MailAddress(m_absenderadresse)
            Msg.To.Add(m_Empfänger)
            Msg.Subject = m_Betreff & IIf(p_mitProgrammdaten, " | " & cl_Programmdaten.getInstanz.mp_ProgrammdatenString, "")
            Msg.Body = m_text
            mySmtpsvr.Send(Msg)
            If Not p_silent Then MsgBox("E-Mail gesendet.", MsgBoxStyle.Information, Title:="Information")
            me_senden = True
        Catch ex As Exception
            sc_Fehlerbehandlung.me_RaiseFehler("me_senden" & vbCrLf & m_text)
        End Try
    End Function
End Class