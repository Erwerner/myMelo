'%NK

Module Tonartwechsel
    Private m_TonartStep As Integer
    Public g_TonartVerschiebung As Integer ' Tonart poitiv oder negativ von C

    Public Sub gTonartwechsel_Tonart(ByVal p_Tonart As e_TonEnum)

        m_TonartStep = p_Tonart - gv_Song.mp_Tonart
        gv_Song.mp_Tonart = p_Tonart

        'Form1.lblTonartDur.Text = c_StrTonName(p_Tonart) & " Dur"

        Select Case m_TonartStep
            Case Is = -11
                m_TonartStep = m_TonartStep + 12
            Case Is = 11
                m_TonartStep = m_TonartStep - 12
        End Select

        gAdd(g_TonartVerschiebung, m_TonartStep)


        gm_setLeiterTöne()
        gm_setTonLeiterFunktionen()
        'initTasteaktiv()
        'Takt.gp_Takt_absolut(e_Takttyp.Auftakt).me_Tonartwechsel()
        'Takt.gp_Takt_absolut(e_Takttyp.Schlussakkord).me_Tonartwechsel()
        'For Each lz_Takt In g_Takt
        '    lz_Takt.me_Tonartwechsel()
        'Next
        For Each lz_Takt In Takt.get_absolut_alleTakte_asArray
            lz_Takt.me_Tonartwechsel()
        Next
        'Taktanzeigen(Tonartwechsel)
        gp_TaktAnzeige(e_Takttyp.Auftakt).Tonartwechsel()
        gp_TaktAnzeige(e_Takttyp.Schlussakkord).Tonartwechsel()
        For Each lz_TA In g_Taktanzeige
            lz_TA.Tonartwechsel()
        Next


        Form1.me_aktualisiere_TonartLabel()
        TonKopf.sm_aktualisieren()

    End Sub

    Public Sub gTonartwechsel_Ton(ByVal ref_ton As Ton)
        TonÄndern(ref_ton, m_TonartStep)
    End Sub
End Module
