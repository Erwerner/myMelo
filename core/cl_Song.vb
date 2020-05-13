Public Class cl_Song
    Private Shared this As cl_Song
    Private Shared sv_ImExport As cl_ImExport

    Private m_Tonart As e_TonEnum
    Private m_Tempo As Integer
    Private m_AnzahlHauptTakte As Integer
    Private m_instrumentakkord As e_instrumentenum
    Private m_instrumentmelodie As e_instrumentenum
    Private m_hatSchlussakkord As Boolean
    Private m_hatAuftakt As Boolean
    Private m_TonartGeschlecht As e_Tongeschlecht
    ' SHARED
    Private Shared ReadOnly Property sp_ImExport As cl_ImExport
        Get
            If sv_ImExport Is Nothing Then
                sv_ImExport = cl_ImExport.factory
            End If
            Return sv_ImExport
        End Get
    End Property
    ' PROPERTY
    Public WriteOnly Property mp_Tonartgeschlecht As e_Tongeschlecht
        Set(ByVal value As e_Tongeschlecht)
            m_TonartGeschlecht = value
            Select Case value
                Case e_Tongeschlecht.Dur
                    Form1.rbDur.Checked = True
                Case e_Tongeschlecht.Moll
                    Form1.rbMoll.Checked = True
            End Select
            Form1.me_aktualisiere_TonartLabel()
        End Set
    End Property
    Public Property mp_Tonart As e_TonEnum
        Get
            Return m_Tonart
        End Get
        Set(ByVal value As e_TonEnum)
            m_Tonart = value
        End Set
    End Property
    Public Property mp_instrumentmidi As e_instrumentenum
        Get
            Return m_instrumentakkord
        End Get
        Set(ByVal value As e_instrumentenum)
            m_instrumentakkord = value
        End Set
    End Property
    Public Property mp_instrumentmelodie As e_instrumentenum
        Get
            Return m_instrumentmelodie
        End Get
        Set(ByVal value As e_instrumentenum)
            m_instrumentmelodie = value
            TonDatei.initInstrument()
            Form1.KlavierToolStripMenuItem.Checked = False
            Form1.GitarreToolStripMenuItem.Checked = False
            Select Case value
                Case e_instrumentenum.Klavier
                    Form1.KlavierToolStripMenuItem.Checked = True
                Case (e_instrumentenum.Gitarre)
                    Form1.GitarreToolStripMenuItem.Checked = True
            End Select
        End Set
    End Property
    Public Property mp_Tempo As Integer
        Get
            Return m_Tempo
        End Get
        Set(ByVal value As Integer)
            m_Tempo = value
            Form1.lblTempo.Text = "Tempo " & m_Tempo
            sc_Player.factory.me_setTimerValue()
            Form1.scrlTempo.Value = m_Tempo
        End Set
    End Property
    Public Property mp_anzahlHauptTakte As Integer
        Get
            Return m_AnzahlHauptTakte
        End Get
        Set(ByVal value As Integer)
            m_AnzahlHauptTakte = value
        End Set
    End Property
    Public Property mp_hatSchlussakkord As Boolean
        Get
            Return m_hatSchlussakkord
        End Get
        Set(ByVal value As Boolean)
            m_hatSchlussakkord = value
            Form1.chkHatSchlussakkord.Checked = value
            gp_TaktAnzeige(e_Takttyp.Schlussakkord).Visible = value
            Form1.init_cboSpieleTakt_vonBis()
        End Set
    End Property
    Public Property mp_hatAuftakt As Boolean
        Get
            Return m_hatAuftakt
        End Get
        Set(ByVal value As Boolean)
            m_hatAuftakt = value
            Form1.chkHatAuftakt.Checked = value
            gp_TaktAnzeige(e_Takttyp.Auftakt).Visible = value
            Form1.init_cboSpieleTakt_vonBis()
        End Set
    End Property 
    ' READONLY
    Public ReadOnly Property mp_anzahlAktivTakte As Integer
        Get
            'Return mp_anzahlHauptTakte + global_BoolToInt(m_hatAuftakt) + global_BoolToInt(m_hatSchlussakkord)
            Return mp_anzahlHauptTakte + g_Auftakt_int() + g_Schlussakkord_int()
        End Get
    End Property
    Public ReadOnly Property mp_GrundAkkord As e_Akkordfunktion
        Get
            Select Case m_TonartGeschlecht
                Case e_Tongeschlecht.Dur
                    Return e_Akkordfunktion.Tonika
                Case e_Tongeschlecht.Moll
                    Return e_Akkordfunktion.Tonikaparallele
                Case Else
                    Return Nothing
            End Select
        End Get
    End Property

    Private WriteOnly Property mp_Titel As String
        Set(ByVal value As String)
            Form1.Text = value & IIf(Not value = "", " - ", "") & "easy Harmony"
        End Set
    End Property
    ' FACTORY
    Public Shared Function factory() As cl_Song
        If this Is Nothing Then
            this = New cl_Song()
        End If
        Return this
    End Function

    ' PUBLIC
    Public Sub initSong(ByVal p_Tonart As e_TonEnum,
                         ByVal p_Tempo As Integer,
                         ByVal p_AnzahlTakte As Integer,
                         ByVal p_instrumentakkord As e_instrumentenum, ByVal p_instrumentmelodie As e_instrumentenum,
                         ByVal p_hatAuftakt As Boolean, ByVal p_hatSchlussakkord As Boolean,
                         ByVal p_TaktAkkordFunktionen(,) As e_Akkordfunktion,
                         ByVal p_Auftaktmelodienote() As Note,
                         ByVal p_Hauptaktmelodienote(,) As Note,
                         ByVal p_Schlusstaktmelodienote() As Note,
                         ByVal p_Titel As String)

        Dim l_Akkordfunktion4Takt(3) As e_Akkordfunktion

        m_AnzahlHauptTakte = 0

        'Takte()
        For lz_4Takt = 0 To arrIx(p_AnzahlTakte \ 4)
            l_Akkordfunktion4Takt(0) = p_TaktAkkordFunktionen(lz_4Takt, 0)
            l_Akkordfunktion4Takt(1) = p_TaktAkkordFunktionen(lz_4Takt, 1)
            l_Akkordfunktion4Takt(2) = p_TaktAkkordFunktionen(lz_4Takt, 2)
            l_Akkordfunktion4Takt(3) = p_TaktAkkordFunktionen(lz_4Takt, 3)

            global_Takte_Hinzufügen(l_Akkordfunktion4Takt)
        Next

        ' Songvariablen
        gTonartwechsel_Tonart(p_Tonart)
        mp_Tempo = p_Tempo
        mp_instrumentmidi = p_instrumentakkord
        mp_instrumentmelodie = p_instrumentmelodie
        mp_hatAuftakt = p_hatAuftakt
        mp_hatSchlussakkord = p_hatSchlussakkord


        'Auftakt()
        For Each lz_Takteinheit In Takt.sp_Takt_absolut(e_Takttyp.Auftakt).get_alleTakteinheiten
            lz_Takteinheit.me_setMelodieNote(p_Auftaktmelodienote(lz_Takteinheit.mp_Index))
        Next
        For lz_Taktindex = 0 To arrIx(p_AnzahlTakte)
            For Each lz_Takteinheit In Takt.sp_Takt_absolut(lz_Taktindex).get_alleTakteinheiten
                lz_Takteinheit.me_setMelodieNote(p_Hauptaktmelodienote(lz_Taktindex, lz_Takteinheit.mp_Index))
            Next
        Next
        ' Schlusstakt
        For Each lz_Takteinheit In Takt.sp_Takt_absolut(e_Takttyp.Schlussakkord).get_alleTakteinheiten
            lz_Takteinheit.me_setMelodieNote(p_Schlusstaktmelodienote(lz_Takteinheit.mp_Index))
        Next
        Taktanzeige.sm_AnzeigeAktualisieren()
        TaktEingabe.sm_setTakt(Takt.sp_Takt_relativ(0).mp_TaktIndex)
        mp_Titel = p_Titel
    End Sub
    Public Sub me_reset()
        Dim l_Melodienote(7) As Note
        Dim l_HaupttaktMelodienote(3, 7) As Note
        Dim l_TaktAkkordfunktion(0, 3) As e_Akkordfunktion
        l_Melodienote = c_MelodienoteEmpty_1Dim
        l_HaupttaktMelodienote = cp_empty_Melodienote2Dim(4)
        l_TaktAkkordfunktion(0, 0) = e_Akkordfunktion.Tonika
        l_TaktAkkordfunktion(0, 1) = e_Akkordfunktion.Tonikaparallele
        l_TaktAkkordfunktion(0, 2) = e_Akkordfunktion.Subdominante
        l_TaktAkkordfunktion(0, 3) = e_Akkordfunktion.Dominante

        Me.initSong(e_TonEnum.C, 90, 4, _
                                    e_instrumentenum.Klavier, e_instrumentenum.Klavier, _
                                    False, True, _
                                    l_TaktAkkordfunktion, _
                                    l_Melodienote, l_HaupttaktMelodienote, l_Melodienote, "Neuer Song")
    End Sub
    Public Sub me_laden(Optional ByVal p_SongData As String = "", Optional ByVal p_Titel As String = "")
        Dim l_SongData As String

        Dim l_SongVersion As Char

        Dim l_ladeTonart As e_TonEnum
        Dim l_Tempo As Integer
        Dim l_AnzahlTakte As Integer
        Dim l_anzahl4Takt As Integer
        Dim l_hatAuftakt As Boolean
        Dim l_hatSchlusstakt As Boolean
        Dim l_instrumentakkord As e_instrumentenum
        Dim l_instrumentmelodie As e_instrumentenum
        Dim l_TaktakkordFunktion(,) As e_Akkordfunktion
        Dim l_MelodienoteAuftakt(7) As Note
        Dim l_MelodienoteSchlusstakt(7) As Note
        Dim l_MelodienoteHauptakt(,) As Note

        Dim l_Titel As String = ""

        sc_Player.factory.me_PlayerStop()

        If p_SongData = "" Then
            l_SongData = sp_ImExport.me_imp_popup(l_Titel)
        Else
            l_SongData = p_SongData
            l_Titel = p_Titel
            sp_ImExport.me_setImportData(p_SongData)
        End If
        If Not l_SongData = "" Then
            l_SongVersion = me_leseImportPart()
            Select Case l_SongVersion
                Case "!"
                    l_ladeTonart = me_leseImportPart()
                    l_Tempo = me_leseImportPart()
                    l_AnzahlTakte = me_leseImportPart()
                    l_hatAuftakt = me_leseImportPart(True)
                    l_hatSchlusstakt = me_leseImportPart(True)
                    l_instrumentakkord = me_leseImportPart()
                    l_instrumentmelodie = me_leseImportPart()

                    ' Takte
                    l_anzahl4Takt = l_AnzahlTakte \ 4 - 1
                    ReDim l_TaktakkordFunktion(l_anzahl4Takt, 3)
                    ReDim l_MelodienoteHauptakt(arrIx(l_AnzahlTakte), 7)
                    'For Each l_taf In l_TaktakkordFunktion
                    For lz_4taktindex = 0 To l_anzahl4Takt
                        For lz_Taktindex = 0 To 3
                            l_TaktakkordFunktion(lz_4taktindex, lz_Taktindex) = me_leseImportPart()
                        Next
                    Next
                    ' Next
                    'For Each l_mna In l_MelodienoteAuftakt
                    For lz_takteinheiindex = 0 To c_MinEinheit
                        l_MelodienoteAuftakt(lz_takteinheiindex) = (New Note(me_leseImportPart(), me_leseImportPart(), me_leseImportPart()))
                    Next
                    'Next
                    'For Each l_mnh In l_MelodienoteHauptakt
                    For lz_taktindex = 0 To arrIx(l_AnzahlTakte)
                        For lz_takteinheiindex = 0 To c_MinEinheit
                            l_MelodienoteHauptakt(lz_taktindex, lz_takteinheiindex) = (New Note(me_leseImportPart(), me_leseImportPart(), me_leseImportPart()))
                        Next
                    Next

                    'Next
                    'For Each l_mns In l_MelodienoteSchlusstakt 
                    For lz_takteinheiindex = 0 To c_MinEinheit
                        l_MelodienoteSchlusstakt(lz_takteinheiindex) = (New Note(me_leseImportPart(), me_leseImportPart(), me_leseImportPart()))
                    Next
                    'Next

                    initSong(l_ladeTonart, l_Tempo, l_AnzahlTakte, l_instrumentakkord, l_instrumentmelodie, l_hatAuftakt, l_hatSchlusstakt, l_TaktakkordFunktion, l_MelodienoteAuftakt, l_MelodienoteHauptakt, l_MelodienoteSchlusstakt, l_Titel)

                Case Else
                    If MsgBox("Diese easy Harmony Version kann die Datei nicht einlesen." & vbCrLf & "Möchtest du jetzt die aktuelle Version von easy Harmony herunterladen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        cl_update.getInstanz.me_downloadSetup()
                    End If

            End Select
        End If

    End Sub
    Public Sub me_speichern()
        me_speichereData("!")
        me_speichereData(m_Tonart)
        me_speichereData(m_Tempo)
        me_speichereData(mp_anzahlHauptTakte)
        me_speichereData(m_hatAuftakt, True)
        me_speichereData(m_hatSchlussakkord, True)
        me_speichereData(m_instrumentakkord)
        me_speichereData(m_instrumentmelodie)
        me_exportBreak()
        ' Takte
        ' Akkordfunktion
        For Each l_takt In g_Takt
            me_speichereData(l_takt.mp_Akkord.mp_Akkordfunktion)
        Next
        me_exportBreak()
        '' Auftakt
        'For Each lz_takteinheit In Takt.sp_Takt_absolut(e_Takttyp.Auftakt).get_alleTakteinheiten  

        '' Haupttakte
        'For Each l_takt In g_Takt
        '    For Each lz_takteinheit In l_takt.get_alleTakteinheiten
        '        me_speichereData(lz_takteinheit.mp_Melodienote.mp_TonEnum)
        '        me_speichereData(lz_takteinheit.mp_Melodienote.mp_Oktave)
        '        me_speichereData(lz_takteinheit.mp_Melodienote.mp_Länge) 

        '' Schlusstakt 

        ' Auftakt
        For Each lz_takt In Takt.get_absolut_alleTakte_asArray
            For Each lz_takteinheit In lz_takt.get_alleTakteinheiten
                With lz_takteinheit.mp_Melodienote
                    me_speichereData(.mp_TonEnum)
                    me_speichereData(.mp_Oktave)
                    me_speichereData(.mp_Länge)
                End With
            Next
            me_exportBreak()
        Next
        sp_ImExport.me_ex_Popup()
    End Sub
    'PRIVATE
    Private Sub me_speichereData(ByVal p_data, Optional ByVal p_boolToInt = False)
        sp_ImExport.me_Ex_append(p_data, p_boolToInt)
    End Sub
    Private Sub me_exportBreak()
        'sp_ImExport.me_exportBreak()
    End Sub
    Private Function me_leseImportPart(Optional ByVal p_intToBool As Boolean = False)
        Return sp_ImExport.me_getImp_Part(p_intToBool)
    End Function
End Class
