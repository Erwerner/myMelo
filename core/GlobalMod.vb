Module GlobalMod
    Public g_Takt(3) As Takt
    Private m_TaktZwischenspeicher(3) As Takt
    Private m_TaktanzeigeZwischenspeicherr(3) As Taktanzeige
    Public gv_TakteHinzufügen As Boolean ' Für Bezeichnung des ersten Takts bei Takt hinzufügen


    Public Sub gm_StartAblauf()
        gm_Startinitialisierung()
        If cl_Programmdaten.getInstanz.mp_UpdateAutom Then cl_update.sv_checkupdate(True)
    End Sub
    Public Sub gm_Startinitialisierung()
        'me_Programmdaten_laden()
        gm_ConstantInitialisierung()

        ' Knöpfe
        Form1.kpfPlay.me_init("Play", Knopf.e_Knopftyp.ktPlay)
        Form1.kpfStop.me_init("Stop", Knopf.e_Knopftyp.ktStop)
        Form1.kpfTonartHoch.me_init(">", Knopf.e_Knopftyp.ktTonartHoch)
        Form1.kpfTonartRunter.me_init("<", Knopf.e_Knopftyp.ktTonartRunter)
        Form1.kpf4Takt.me_init("4 Takte hinzufügen", Knopf.e_Knopftyp.kt4Takt)

        Form1.stlStatus.Visible = False

        gv_Song = cl_Song.factory
        gv_Song.mp_Tonart = e_TonEnum.C
        gm_setLeiterTöne()
        gm_initAuftSchlss()
        gv_Song.me_reset()

        TaktEingabe.sm_initEingabe()
        TaktEingabe.sm_setTakt(0)

        'sc_Player.sp_alleTakteSpielen = True
        gv_Song.mp_Tonartgeschlecht = e_Tongeschlecht.Dur
    End Sub
    Public Function TonErmitteln_TonEnum(ByVal p_Halbtonschritt As Integer, ByVal p_Startton As e_TonEnum) As e_TonEnum
        TonErmitteln_TonEnum = TonÄndern_TonEnum(cp_dummyTon, p_Halbtonschritt, p_Startton, e_wertErhaltenEnum.WertErhalten)
    End Function

    ' Funktion zum Übergabetton ändern
    Public Sub TonÄndern(ByRef ref_Ton As Ton, _
                                ByVal p_Halbtonschritt As Integer, _
                                Optional ByVal p_StartTon As Integer = -1, _
                                Optional ByRef ref_RückgabeOktave As Integer = -1)
        TonÄndern_TonEnum(ref_Ton, p_Halbtonschritt, p_StartTon, e_wertErhaltenEnum.WertÄndern, ref_RückgabeOktave)
    End Sub

    ' Funktion mit Rückgabewert
    Public Function TonÄndern_TonEnum(ByRef ref_Ton As Ton, _
                                ByVal p_Halbtonschritt As Integer, _
                                Optional ByVal p_StartTon As Integer = -1, _
                                Optional ByVal p_wertErhalten As e_wertErhaltenEnum = e_wertErhaltenEnum.WertÄndern, _
                                Optional ByRef ref_RückgabeOktave As Integer = -1) As e_TonEnum
        Dim l_newTonEnum As e_TonEnum
        Dim l_oktavSchritt As Integer
        Dim l_StartTon As e_TonEnum
        l_oktavSchritt = 0

        If p_StartTon = -1 Then
            l_StartTon = ref_Ton.mp_TonEnum
        Else
            l_StartTon = p_StartTon
        End If

        l_newTonEnum = l_StartTon + p_Halbtonschritt

        ' Oktave ermitteln
        If l_newTonEnum > e_TonEnum.B Then l_oktavSchritt = -1
        If l_newTonEnum < e_TonEnum.C Then l_oktavSchritt = 1
        l_newTonEnum = l_newTonEnum + (e_TonEnum.B * l_oktavSchritt) + l_oktavSchritt

        TonÄndern_TonEnum = l_newTonEnum
        ref_RückgabeOktave = ref_Ton.mp_Oktave '+ l_oktavSchritt * -1

        If p_wertErhalten = e_wertErhaltenEnum.WertÄndern Then  'Wert erhalten ist immer performanter
            ref_Ton.mp_TonEnum = l_newTonEnum
            ref_Ton.mp_Oktave = ref_RückgabeOktave
        End If
    End Function
 
    Public Sub global_Takte_Hinzufügen(ByVal p_HauptTaktAkkordfunktion() As e_Akkordfunktion)
        Dim lv_anzahlHauptTakte As Integer
        lv_anzahlHauptTakte = gv_Song.mp_anzahlHauptTakte

        Try
            For Each l_taktanzeige In g_Taktanzeige
                l_taktanzeige.Visible = False   ' %ToDo Objekte zerstören %prfc
            Next
        Catch ex As Exception

        End Try
        'Reinitialisieren von Takt und Anzeige
        ReDim g_Takt(lv_anzahlHauptTakte + 3)
        ReDim g_Taktanzeige(lv_anzahlHauptTakte + 3)

        'Lesen aus Zwischenspeicher
        For lz_Takt = 0 To lv_anzahlHauptTakte - 1
            g_Takt(lz_Takt) = m_TaktZwischenspeicher(lz_Takt)
            g_Taktanzeige(lz_Takt) = m_TaktanzeigeZwischenspeicherr(lz_Takt)
        Next

        ' Takte vergeben 
        For lz_Takt = 0 To 3
            g_Takt(lv_anzahlHauptTakte + lz_Takt) = New Takt(lv_anzahlHauptTakte + lz_Takt, gp_LeiterAkkord(p_HauptTaktAkkordfunktion(lz_Takt)))
        Next

        For zTakt = lv_anzahlHauptTakte To lv_anzahlHauptTakte + 3
            gv_TakteHinzufügen = True
            g_Taktanzeige(zTakt) = New Taktanzeige(zTakt)
            gv_TakteHinzufügen = False
            g_Taktanzeige(zTakt).me_inForm1Einbinden()
        Next
        For Each l_taktanzeige In g_Taktanzeige
            l_taktanzeige.Visible = True   ' %ToDo überflüssig wenn Objekte zerstört
        Next
        gAdd(lv_anzahlHauptTakte, 4)



        'Zwischenspeicher vergrößern
        ReDim m_TaktZwischenspeicher(lv_anzahlHauptTakte + 3)
        ReDim m_TaktanzeigeZwischenspeicherr(lv_anzahlHauptTakte + 3)
        'Arrays zwischenspeichern
        For zTakt = 0 To arrIx(lv_anzahlHauptTakte)
            m_TaktZwischenspeicher(zTakt) = g_Takt(zTakt)
            m_TaktanzeigeZwischenspeicherr(zTakt) = g_Taktanzeige(zTakt)
        Next

        gv_Song.mp_anzahlHauptTakte = lv_anzahlHauptTakte
        gp_TaktAnzeige(e_Takttyp.Schlussakkord).Position_setzen()
        Form1.init_cboSpieleTakt_vonBis()
    End Sub



    Public Function gStep_integer(ByVal p_Taktindex As Integer, ByVal p_einheitindex As Integer) As Integer
        gStep_integer = p_Taktindex * 8 + p_einheitindex
    End Function
    Public Function gMelodienote_byStep_integer(ByVal p_step As Integer) As Note
        Try
            gMelodienote_byStep_integer = gTakteinheit_byStep_integer(p_step).mp_Melodienote
        Catch ex As Exception
            gMelodienote_byStep_integer = Takt.sp_Takt_absolut(0).mp_TaktEinheit(0).mp_Melodienote
            dp("ERROR gMelodienote_byStep_integer " & p_step)
        End Try
    End Function
    Public Function gTakteinheit_byStep_integer(ByVal p_step As Integer) As Takteinheit
        Try
            Dim l_Takt As Integer
            Dim l_Takteinheit As Integer
            p_step = p_step - 1
            l_Takt = p_step \ 8
            l_Takteinheit = p_step Mod 8
            gTakteinheit_byStep_integer = Takt.sp_Takt_absolut(l_Takt - g_Auftakt_int()).mp_TaktEinheit(l_Takteinheit)

        Catch ex As Exception
            gTakteinheit_byStep_integer = Takt.sp_Takt_absolut(0).mp_TaktEinheit(0)
            dp("ERROR gTakteinheit_byStep_integer " & p_step)
        End Try
    End Function
    Public Function gTakteinheitAnzeige_byStep_integer(ByVal p_step As Integer) As TakteinheitAnzeige
        Try
            Dim l_Takt As Integer
            Dim l_Takteinheit As Integer
            p_step = p_step - 1
            l_Takt = p_step \ 8
            l_Takteinheit = p_step Mod 8
            'dp(p_step & " = " & l_Takt & l_Takteinheit)
            gTakteinheitAnzeige_byStep_integer = gp_TaktAnzeige(l_Takt - g_Auftakt_int()).mp_Takteinheitanzeige(l_Takteinheit)

        Catch ex As Exception
            gTakteinheitAnzeige_byStep_integer = gp_TaktAnzeige(0).mp_Takteinheitanzeige(0)
            dp("ERROR gTakteinheit_byStep_integer " & p_step)
        End Try
    End Function
    Public Function g_Auftakt_int() As Integer
        If gv_Song.mp_hatAuftakt Then Return 1 Else Return 0
    End Function
    Public Function g_Schlussakkord_int() As Integer
        If gv_Song.mp_hatSchlussakkord Then Return 1 Else Return 0
    End Function

End Module
