Public Class sc_SequenzSteuerung

    Private Shared sv_sequenzsteuerung As String
    Private Shared sv_steuerungIndex As Integer
    Private Shared sv_Sequenzinhalt As String
    Private Shared sv_SequenzinhaltIndex As Integer


    Private Shared m_MelodieTonDatei(,) As TonDatei
    Private Shared m_AkkordTonDatei(,) As TonDatei

    Public Shared Sub sm_leseSequenz()  
        Dim l_Takt_relativIndex As Integer

        ReDim m_AkkordTonDatei(arrIx(gv_Song.mp_anzahlAktivTakte), 2)
        ReDim m_MelodieTonDatei(arrIx(gv_Song.mp_anzahlAktivTakte), 7)
         
            Form1.stlStatus.Maximum = gv_Song.mp_anzahlHauptTakte * (c_MinEinheit + 1)
            Form1.stlStatus.Visible = True 

        For Each lz_Takt In Takt.get_alleAktivTakte_asArray
            With lz_Takt
                l_Takt_relativIndex = .mp_relativIndex
                m_AkkordTonDatei(l_Takt_relativIndex, 0) = New TonDatei(.mp_Akkord.mp_Ton(0), l_Takt_relativIndex, 0)
                m_AkkordTonDatei(l_Takt_relativIndex, 1) = New TonDatei(.mp_Akkord.mp_Ton(1), l_Takt_relativIndex, 0)
                m_AkkordTonDatei(l_Takt_relativIndex, 2) = New TonDatei(.mp_Akkord.mp_Ton(2), l_Takt_relativIndex, 0)
                For Each lz_Takteinheit In .get_alleTakteinheiten
                    With lz_Takteinheit
                        m_MelodieTonDatei(l_Takt_relativIndex, .mp_Index) = New TonDatei(.mp_Melodienote, l_Takt_relativIndex, .mp_Index)
                    End With
                    Form1.stlStatus.Increment(1)
                Next
            End With
        Next


        me_schreibeSequenzsteuerung()
        Form1.stlStatus.Visible = False
    End Sub

    Private Shared Sub me_schreibeSequenzsteuerung() 
        sv_sequenzsteuerung = ""
        sv_Sequenzinhalt = ""
        sv_steuerungIndex = 0
        sv_SequenzinhaltIndex = 0
        TonDatei.sm_clear()
         
        For lz_taktIndex = sc_Player.sp_startTaktIndex To sc_Player.sp_endTaktIndex
            If m_MelodieTonDatei(lz_taktIndex, 0).mp_Anschlag > 0 Then
                me_schreibeSteuercode("X", lz_taktIndex) 
            Else
                me_schreibeSteuercode("A", lz_taktIndex) 
            End If
            For lz_einheit = 1 To 7
                If m_MelodieTonDatei(lz_taktIndex, lz_einheit).mp_Anschlag > 0 Then
                    If m_MelodieTonDatei(lz_taktIndex, lz_einheit).mp_Stop_at_play Then
                        me_schreibeSteuercode("S", lz_taktIndex, lz_einheit)
                    Else
                        me_schreibeSteuercode("M", lz_taktIndex, lz_einheit)
                    End If
                Else
                    me_schreibeSteuercode(" ")
                End If
            Next
        Next
        me_schreibeSteuercode("-")
        dp(sv_sequenzsteuerung)
        dp(sv_Sequenzinhalt)

    End Sub
    Private Shared Sub me_schreibeSteuercode(ByVal p_Code As Char, Optional ByVal p_taktIndex As Integer = -2, Optional ByVal p_einheitIndex As Integer = 0)
        gAppendString(sv_sequenzsteuerung, p_Code)
        Select Case p_Code
            Case "M"
                me_schreibeSteuerinhalt(m_MelodieTonDatei(p_taktIndex, p_einheitIndex))
            Case "S"
                me_schreibeSteuerinhalt(m_MelodieTonDatei(p_taktIndex, p_einheitIndex))
            Case "A"
                me_schreibeSteuerinhalt(m_AkkordTonDatei(p_taktIndex, 0))
                me_schreibeSteuerinhalt(m_AkkordTonDatei(p_taktIndex, 1))
                me_schreibeSteuerinhalt(m_AkkordTonDatei(p_taktIndex, 2))
            Case "X"
                me_schreibeSteuerinhalt(m_AkkordTonDatei(p_taktIndex, 0))
                me_schreibeSteuerinhalt(m_AkkordTonDatei(p_taktIndex, 1))
                me_schreibeSteuerinhalt(m_AkkordTonDatei(p_taktIndex, 2))
                me_schreibeSteuerinhalt(m_MelodieTonDatei(p_taktIndex, p_einheitIndex))
        End Select
    End Sub
    Private Shared Sub me_schreibeSteuerinhalt(ByVal p_TonDatei As TonDatei)
        gAppendString(sv_Sequenzinhalt, p_TonDatei.mp_alias)
    End Sub

    ' Ausgabe

    Public Shared Sub sm_playSteuerung()
        Dim l_SteuerCode As Char

        gAdd(sv_steuerungIndex)
        l_SteuerCode = Mid(sv_sequenzsteuerung, sv_steuerungIndex, 1)
        Select Case l_SteuerCode
            Case "M"
                me_playTon() 
            Case " " 
            Case "S"
                me_stop_and_playTon() 
            Case "X"
                me_playTon()
                me_playTon()
                me_playTon()
                me_stop_and_playTon() 
                'Form1.stsPlayTakt.Increment(1)
            Case "A"
                me_playTon()
                me_playTon()
                me_playTon()
                'Form1.stsPlayTakt.Increment(1) 
            Case "-"
                sc_Player.factory.me_PlayerStop() 
        End Select
    End Sub
    Private Shared Sub me_playTon()
        sv_SequenzinhaltIndex = sv_SequenzinhaltIndex + 1
        mciSendString("play " & _
                         Mid(sv_Sequenzinhalt, 3 * sv_SequenzinhaltIndex - 2, 3) _
                         & " from 0", 0, 0, 0)
    End Sub
    Private Shared Sub me_stop_and_playTon()
        sv_SequenzinhaltIndex = sv_SequenzinhaltIndex + 1
        mciSendString("stop " & _
                         Mid(sv_Sequenzinhalt, 3 * sv_SequenzinhaltIndex - 2, 3) _
                         & " from 0", 0, 0, 0)
        mciSendString("play " & _
                         Mid(sv_Sequenzinhalt, 3 * sv_SequenzinhaltIndex - 2, 3) _
                         & " from 0", 0, 0, 0)
    End Sub
End Class
