Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sc_Fehlerbehandlung.me_startFehlerbehandlung()
        gm_StartAblauf()
        me_initForm()
        'Melodie1()
        melodie2()
        cl_ImExport.factory.me_Imp_File(cp_ProgrammOrdner & "\" & "Song1.ehs")
    End Sub
    Private Sub me_initForm()
        Dim lv_Tonkopf As TonKopf
        Dim lv_Tonindex As Integer
        Me.SystemToolStripMenuItem.Visible = gp_Entwickung

        Me.Steuerleiste1.me_init("Player")
        Me.Steuerleiste2.me_init("Song")

        For lz_leiterton = 0 To 6
            lv_Tonkopf = TonKopf.factory(lz_leiterton)
            Me.SplitContainer1.Panel1.Controls.Add(lv_Tonkopf)

            With lv_Tonkopf
                .BackColor = System.Drawing.Color.LightGray
                .Location = New System.Drawing.Point(lz_leiterton * globDes_BreiteTonCursor, 28)
                .Name = "TonKopf1"
                .TabIndex = 1
                .Size = New System.Drawing.Size(globDes_BreiteTonCursor, 27)
                .BringToFront()
            End With
        Next
        For lz_oktave = 0 To 4
            For lz_leiterton = 0 To 6
                lv_Tonindex = Ton.sm_TonIndex_int(lz_oktave, lz_leiterton)

                lv_Tonkopf = TonKopf.factory(lv_Tonindex)
                Me.SplitContainer1.Panel2.Controls.Add(lv_Tonkopf)

                With lv_Tonkopf
                    .BackColor = System.Drawing.Color.LightGray
                    .Location = New System.Drawing.Point(lv_Tonindex * globDes_BreiteTonCursor, 28)
                    .Name = "TonKopf1"
                    .TabIndex = 1
                    .Size = New System.Drawing.Size(globDes_BreiteTonCursor, 27)
                End With
            Next
        Next
    End Sub

    Private Sub DebugToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebugToolStripMenuItem.Click

    End Sub
    'Private Sub Melodie1() 
    '    Dim l_Akkordfunktion(0, 3) As e_Akkordfunktion
    '    Dim l_AuftaktMelodienote(7) As Note
    '    Dim l_SchlusstaktMelodienote(7) As Note
    '    Dim l_HaupttaktMelodienote(3, 7) As Note 

    '    l_AuftaktMelodienote = c_MelodienoteEmpty_1Dim
    '    l_SchlusstaktMelodienote = c_MelodienoteEmpty_1Dim
    '    l_HaupttaktMelodienote = cp_empty_Melodienote2Dim(4)

    '    l_Akkordfunktion(0, 0) = e_Akkordfunktion.Tonika
    '    l_Akkordfunktion(0, 1) = e_Akkordfunktion.Tonikaparallele
    '    l_Akkordfunktion(0, 2) = e_Akkordfunktion.Subdominante
    '    l_Akkordfunktion(0, 3) = e_Akkordfunktion.Dominante

    '    l_HaupttaktMelodienote(0, 0) = New Note(e_TonEnum.C, 3, 1)
    '    l_HaupttaktMelodienote(0, 2) = New Note(e_TonEnum.E, 3, 1)
    '    l_HaupttaktMelodienote(0, 4) = New Note(e_TonEnum.G, 3, 1)
    '    l_HaupttaktMelodienote(0, 6) = New Note(e_TonEnum.C, 3, 1)

    '    l_HaupttaktMelodienote(1, 0) = New Note(e_TonEnum.A, 2, 1)
    '    l_HaupttaktMelodienote(1, 2) = New Note(e_TonEnum.C, 3, 1)
    '    l_HaupttaktMelodienote(1, 4) = New Note(e_TonEnum.E, 3, 1)
    '    l_HaupttaktMelodienote(1, 6) = New Note(e_TonEnum.A, 2, 1)

    '    l_HaupttaktMelodienote(2, 0) = New Note(e_TonEnum.F, 2, 1)
    '    l_HaupttaktMelodienote(2, 2) = New Note(e_TonEnum.A, 2, 1)
    '    l_HaupttaktMelodienote(2, 4) = New Note(e_TonEnum.C, 3, 1)
    '    l_HaupttaktMelodienote(2, 6) = New Note(e_TonEnum.F, 2, 1)

    '    l_HaupttaktMelodienote(3, 0) = New Note(e_TonEnum.G, 2, 1)
    '    l_HaupttaktMelodienote(3, 2) = New Note(e_TonEnum.B, 2, 1)
    '    l_HaupttaktMelodienote(3, 4) = New Note(e_TonEnum.D, 3, 1)
    '    l_HaupttaktMelodienote(3, 6) = New Note(e_TonEnum.B, 2, 1)

    '    l_SchlusstaktMelodienote(0) = New Note(e_TonEnum.C, 3, 1)

    '    gv_Song.initSong(e_TonEnum.C, 130, 4, e_instrumentenum.Klavier, e_instrumentenum.Klavier, False, True, _
    '                      l_Akkordfunktion, l_AuftaktMelodienote, l_HaupttaktMelodienote, l_SchlusstaktMelodienote, "Beispiel")

    'End Sub
    Private Sub melodie2()
        Dim l_Songdata As String = "!;2;140;8;0;1;0;0;0;4;5;2;3;0;3;4;4;3;1;3;-1;0;3;-1;0;3;-1;0;3;-1;0;3;-1;0;3;-1;0;3;-1;0;2;2;1;1;-1;0;9;2;1;1;-1;0;2;3;1;1;-1;0;6;3;1;1;-1;0;9;1;1;1;-1;0;4;2;1;1;-1;0;9;2;1;1;-1;0;1;2;1;1;-1;0;11;1;1;1;-1;0;6;2;1;1;-1;0;11;2;1;1;-1;0;2;3;1;1;-1;0;6;1;1;1;-1;0;6;2;1;1;-1;0;9;2;1;1;-1;0;1;2;1;1;-1;0;7;1;1;1;1;0;2;2;1;1;1;0;7;2;1;1;1;0;11;2;1;1;1;0;2;2;1;1;1;0;6;2;1;1;1;0;9;2;1;1;1;0;2;3;1;1;1;0;7;1;1;1;1;0;7;2;1;1;1;0;11;2;1;1;1;0;2;3;1;1;1;0;9;1;1;1;1;0;4;2;1;1;1;0;9;2;1;1;1;0;1;2;1;1;1;0;2;3;1;3;-1;0;3;-1;0;3;-1;0;3;-1;0;3;-1;0;3;-1;0;3;-1;0;"
        gv_Song.me_laden(l_Songdata, "Johann Pachelbels Kanon in D Dur Intro")
    End Sub
    Public Sub init_cboSpieleTakt_vonBis()
        init_cbospieletakt(Me.cboSpiele_vonTakt)
        init_cbospieletakt(Me.cboSpiele_bisTakt)
        me_aktualisiere_spieletakt()
    End Sub
    Private Sub init_cbospieletakt(ByRef ref_cbo As ComboBox, Optional ByVal p_startIndex As Integer = 0)
        With ref_cbo.Items
            .Clear()
            For Each lz_Takt In Takt.get_alleAktivTakte_asArray
                If lz_Takt.mp_relativIndex >= p_startIndex Then .Add(lz_Takt.mp_taktBezeichnung)
            Next
        End With
        ref_cbo.Text = ""
    End Sub
    Public Sub me_aktualisiere_spieletakt()
        Me.cboSpiele_vonTakt.SelectedIndex = 0
        Me.cboSpiele_bisTakt.SelectedIndex = arrIx(Me.cboSpiele_bisTakt.Items.Count)
    End Sub
    Public Sub me_aktualisiere_TonartLabel()
        lblTonartDur.Text = gp_LeiterAkkord(gv_Song.mp_GrundAkkord).mp_Bezeichnung
    End Sub

    ' Formmethoden
    Private Sub chkHatSchlussakkord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHatSchlussakkord.CheckedChanged
        gv_Song.mp_hatSchlussakkord = Me.chkHatSchlussakkord.Checked
        Taktanzeigen_poitionieren()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHatAuftakt.CheckedChanged
        gv_Song.mp_hatAuftakt = Me.chkHatAuftakt.Checked
        Taktanzeigen_poitionieren()
    End Sub
    Private Sub BeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ResetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetToolStripMenuItem.Click
        gv_Song.me_reset()
    End Sub
    Private Sub crt_Trackbar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scrlTempo.Scroll
        gv_Song.mp_Tempo = Me.scrlTempo.Value
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        sc_Player.sm_TimerTick()
    End Sub
    Private Sub AufUpdatePrüfenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AufUpdatePrüfenToolStripMenuItem.Click
        cl_update.sv_checkupdate()
    End Sub
    Private Sub AutomatischeUpdatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomatischeUpdatesToolStripMenuItem.Click
        Dim l_Programmdaten As cl_Programmdaten
        l_Programmdaten = cl_Programmdaten.getInstanz
        l_Programmdaten.mp_UpdateAutom = Not Me.AutomatischeUpdatesToolStripMenuItem.Checked
        If l_Programmdaten.mp_UpdateAutom = True Then cl_update.sv_checkupdate()
    End Sub
    Private Sub NachrichtAnDenSupportSendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NachrichtAnDenSupportSendenToolStripMenuItem.Click

        If Not sc_internetverbindung.me_prüfeInternteverbindung Then Exit Sub
        Supportnachricht.Show()
    End Sub
    Private Sub KlavierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlavierToolStripMenuItem.Click
        gv_Song.mp_instrumentmelodie = e_instrumentenum.Klavier
    End Sub
    Private Sub GitarreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GitarreToolStripMenuItem.Click
        gv_Song.mp_instrumentmelodie = e_instrumentenum.Gitarre
    End Sub
    Private Sub InfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoToolStripMenuItem.Click
        Programminfo.Show()
    End Sub
    Private Sub SpeichernBetaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernBetaToolStripMenuItem.Click
        gv_Song.me_speichern()
    End Sub
    Private Sub LadenBetaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LadenBetaToolStripMenuItem.Click
        gv_Song.me_laden()
    End Sub
    Private Sub MIDIExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIDIExportToolStripMenuItem.Click
        sc_MIDI.getInstanz.testmidiexport(False)
    End Sub
    Private Sub ÜberwachungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÜberwachungToolStripMenuItem.Click
        Tracküberwachung.Show()
    End Sub
    Private Sub chkAlleTakteSpielen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlleTakteSpielen.CheckedChanged
        'sc_Player.sp_alleTakteSpielen = Me.chkAlleTakteSpielen.Checked
    End Sub
    Private Sub cboSpiele_vonTakt_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSpiele_vonTakt.SelectedValueChanged
        init_cbospieletakt(Me.cboSpiele_bisTakt, Me.cboSpiele_vonTakt.SelectedIndex)
        Me.cboSpiele_bisTakt.SelectedIndex = Me.cboSpiele_bisTakt.Items.Count - 1
    End Sub
    Private Sub rbDur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDur.CheckedChanged
        If Me.rbDur.Checked Then
            gv_Song.mp_Tonartgeschlecht = e_Tongeschlecht.Dur 
        End If

    End Sub
    Private Sub rbMoll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMoll.CheckedChanged
        If Me.rbMoll.Checked Then
            gv_Song.mp_Tonartgeschlecht = e_Tongeschlecht.Moll 
        End If
    End Sub

    Private Sub MIDIExportBetaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIDIExportBetaToolStripMenuItem.Click
        MIDIExport_Option.Show()
    End Sub

    Private Sub MIDIInstrumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIDIInstrumentToolStripMenuItem.Click
        MIDIExport_Option.Show()
    End Sub

    Private Sub DummyMidiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DummyMidiToolStripMenuItem.Click
        'cl_SoundDatei.play(e_SoundDatei.dummymidi)
    End Sub

    Private Sub MIDIGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIDIGeneratorToolStripMenuItem.Click
        sc_MIDIGenerator.sm_generiereMIDIDateien(0, cp_ProgrammOrdner & "\SoundFiles\testMIDI\")
    End Sub

    Private Sub RaiseFehlerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RaiseFehlerToolStripMenuItem.Click
        sc_Fehlerbehandlung.me_RaiseFehler("")
    End Sub

    Private Sub BehandelterFehlerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BehandelterFehlerToolStripMenuItem.Click
        sc_Fehlerbehandlung.me_raisebehandelterfehler()
    End Sub
End Class
