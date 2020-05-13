

Public Class sc_MIDI
    ' LOKALE KLASSEN 
    Private Class midicode  
        Private m_returnByte As Byte()
        Private m_SizeKey As Integer
        Private m_TrackIndex As Integer

        Public ReadOnly Property mp_return As Byte()
            Get
                Return m_returnByte
            End Get
        End Property
        Public WriteOnly Property mp_Value() As Byte()
            Set(ByVal value As Byte())
                For lz_ByteIndex = 0 To arrIx(value.Length)
                    m_returnByte(lz_ByteIndex + arrIx(m_SizeKey) + 1) = value(lz_ByteIndex)
                Next
            End Set
        End Property
        Public Sub New(ByVal p_sizeFull As Integer, ByVal p_KeyByte As Byte(), ByVal p_Trackindex As Integer)
            ReDim m_returnByte(arrIx(p_sizeFull))
            m_TrackIndex = p_Trackindex
            m_SizeKey = p_KeyByte.Length
            For lz_Byteindex = 0 To arrIx(m_SizeKey)
                m_returnByte(lz_Byteindex) = p_KeyByte(lz_Byteindex)
            Next
        End Sub 
    End Class
    Private Class MIDI_note
        Inherits Note
        ' READONLY
        Public ReadOnly Property mp_MIDI_An() As Byte()
            Get
                Dim l_Byte(4) As Byte
                l_Byte(0) = &H90
                l_Byte(1) = mp_Miditon()
                l_Byte(2) = mp_MIDI_Anschlagsdynamik
                l_Byte(3) = &H81
                l_Byte(4) = &H20
                Return l_Byte
            End Get
        End Property
        Public ReadOnly Property mp_MIDI_AUS() As Byte()
            Get
                Dim l_Byte(3) As Byte
                l_Byte(0) = &H90
                l_Byte(1) = mp_Miditon()
                l_Byte(2) = &H0
                l_Byte(3) = &H20
                Return l_Byte
            End Get
        End Property
        Public ReadOnly Property mp_Miditon() As Integer
            Get
                Return mp_Oktave_realTon * 12 + m_TonEnum + 48
            End Get
        End Property
        ' PRIVATE
        Private ReadOnly Property mp_MIDI_Anschlagsdynamik As Byte
            Get
                If mp_wirdGespielt Then
                    Return &H6E
                Else
                    Return &H0
                End If
            End Get
        End Property
        ' KONSTRUCTOR
        Public Sub New(ByVal p_note As Note)
            MyBase.new(p_note.mp_TonEnum, p_note.mp_Oktave, p_note.mp_Länge)
        End Sub
    End Class
        Private Class MIDI_Akkord
            Inherits Akkord
            ' READONLY
            Public ReadOnly Property mp_MIDI_An() As Byte()
                Get
                    Dim l_return As New Bytepuffer(14)
                    Dim l_AkkordTonByte(3) As Byte
                    Dim l_MIDI_AkkordNote As MIDI_note
                    For Each lz_ton In m_Ton
                        l_MIDI_AkkordNote = New MIDI_note(New Note(lz_ton.mp_TonEnum, lz_ton.mp_Oktave))
                        l_AkkordTonByte(0) = &H90
                        l_AkkordTonByte(1) = l_MIDI_AkkordNote.mp_Miditon()
                        l_AkkordTonByte(2) = &H40
                        l_AkkordTonByte(3) = &H0
                        'l_AkkordTonByte(4) = &H20
                        l_return.me_appendPuffer(l_AkkordTonByte)
                    Next
                    Return l_return.mp_Result
                End Get
            End Property
            Public ReadOnly Property mp_MIDI_AUS() As Byte()
                Get
                    Dim l_return As New Bytepuffer(11)
                    Dim l_AkkordTonByte(3) As Byte
                    Dim l_MIDI_AkkordNote As MIDI_note
                    For Each lz_ton In m_Ton
                        l_MIDI_AkkordNote = New MIDI_note(New Note(lz_ton.mp_TonEnum, lz_ton.mp_Oktave))
                        l_AkkordTonByte(0) = &H80
                        l_AkkordTonByte(1) = l_MIDI_AkkordNote.mp_Miditon()
                        l_AkkordTonByte(2) = &H0
                        l_AkkordTonByte(3) = &H0
                        l_return.me_appendPuffer(l_AkkordTonByte)
                    Next
                    Return l_return.mp_Result
                End Get
            End Property
            ' KONSTRUCTOR
            Public Sub New(ByVal p_akkord As Akkord)
                MyBase.new(p_akkord.mp_Grundton.mp_TonEnum, p_akkord.mp_Geschlecht)
            End Sub
    End Class

    Dim m_OutputByte As New Bytepuffer(4096)
    Private m_noteByte As New Bytepuffer(4096)
    Private m_Track1Länge As Byte
    Private m_Track2Länge1_byte As Byte
    Private m_Track2Länge256_byte As Byte
    Private m_Text_Byte() As Byte
    Private Shared m_saveFildedialog As FileDialog

    '  0001 = Midiformat 0 ; 
    '  0002 = Es folgen 2 MTrk Tracks; 
    '  00C0 = Die Basisgeschwindigkeit einer Viertelnote = 192
    Private MC_FileHead() As Byte = {&H0, &H1, &H0, &H2, &H0, &HC0, _
                                    &H4D, &H54, &H72, &H6B, &H0, &H0, &H0, &H79, &H0, _
                                   &HFF, &H1, &H8, &H54, &H65, &H73, &H74, &H66, &H69, &H6C, &H65, &H0, _
                                   &HFF, &H1, &HF, &H42, &H79, &H20, &H57, &H65, &H72, &H6E, &H65, &H72, &H20, &H45, &H72, &H69, &H6B, &H20, &H0, _
                                   &HFF, &H2, &H19, &H57, &H65, &H72, &H6E, &H65, &H72, &H20, &H45, &H72, &H69, &H6B, &H20, &HD, _
                                                    &H57, &H65, &H72, &H6E, &H65, &H72, &H20, &H45, &H72, &H69, &H6B, &H20, &H0}
    'Private MC_Track1Rest() As Byte = {&HFF, &H58, &H4, &H4, &H2, &H18, &H8, &H0} ', _
    '&HFF, &H59, &H2, &H3, &H0, &H0 } 



    Private MC_FileStart() As Byte = {&H4D, &H54}
    Private MC_TrackStart() As Byte = {&H4D, &H54, &H72, &H6B}

    ' MIDICODES
    Private m_MC_Trackend As New midicode(3, {&HFF, &H2F, &H0}, 0)
    Private m_MC_FileStart As New midicode(8, MC_FileStart, 0)

    Private m_MC_Textmessage1 As New midicode(36, {&HFF, &H1}, 1)
    Private m_MC_Tempo_T1 As New midicode(7, {&HFF, &H51, &H3}, 1)
    Private m_MC_TimeSignatur As New midicode(8, {&HFF, &H58, &H4, &H4, &H2, &H18, &H8, &H0}, 1)
    Private m_MC_Tonart As New midicode(5, {&HFF, &H59, &H2}, 1)

    Private m_MC_TrackStart_T2 As New midicode(6, MC_TrackStart, 2)
    Private m_MC_Instrument_T2 As New midicode(2, {&HC0}, 2)
    'Private m_MC_Instrument_T2 As New midicode(3, {&HC0, &H0}, 2)
    Private m_MC_Kanal_T2 As New midicode(4, {&HFF, &H21, &H1}, 2)
    Private m_MC_Lautstärke As New midicode(3, {&HB0, &H7}, 2)
    Private m_MC_Stereopanorama As New midicode(5, {&H0, &HB0, &HA, &H40, &H0}, 2) 
    Private m_MC_Instrumentname As New midicode(9, {&HFF, &H4}, 2)
    Private m_MC_Trackname As New midicode(9, {&HFF, &H3}, 2)
    Private m_MC_Textmessage As New midicode(9, {&HFF, &H1}, 2)

    ' READONLY
    Private Shared ReadOnly Property sp_saveFildedialog As FileDialog
        Get
            If m_saveFildedialog Is Nothing Then
                m_saveFildedialog = New SaveFileDialog

                m_saveFildedialog.InitialDirectory = cp_SaveOrdner
                m_saveFildedialog.Title = "MIDI Export"
                m_saveFildedialog.DefaultExt = "mid"
                m_saveFildedialog.Filter = "MIDI (*.mid)|*.mid"
                m_saveFildedialog.RestoreDirectory = True
            End If
            Return m_saveFildedialog
        End Get
    End Property
    ' GETINSTANZ
    Public Shared Function getInstanz() As sc_MIDI
        Return New sc_MIDI
    End Function

    Public Sub testmidiexport(ByVal p_showfiledialog As Boolean)
        Dim l_Tempo As Integer
        Dim l_Tempo_byte As Byte()
        Dim l_MIDINote As MIDI_note
        Dim l_MIDIAkkord As MIDI_Akkord
        Dim l_Track2Lenght(2) As Byte

        Try
            m_Track2Länge1_byte = &H2F

            ' Puffer Noten 
            For Each lz_Takt In Takt.get_alleAktivTakte_asArray
                With lz_Takt
                    l_MIDIAkkord = New MIDI_Akkord(.mp_Akkord)
                    me_appendOutputPuffer(l_MIDIAkkord.mp_MIDI_An, True)
                    For Each lz_taktEinheit In .get_alleTakteinheiten
                        l_MIDINote = New MIDI_note(lz_taktEinheit.mp_Melodienote)
                        me_appendOutputPuffer(l_MIDINote.mp_MIDI_An, True)
                        me_appendOutputPuffer(l_MIDINote.mp_MIDI_AUS, True)
                    Next
                    me_appendOutputPuffer(l_MIDIAkkord.mp_MIDI_AUS, True)
                End With
            Next

            ' Tempo ermitteln
            l_Tempo = 60000000 / gv_Song.mp_Tempo / 2
            l_Tempo_byte = BitConverter.GetBytes(l_Tempo)
            Array.Reverse(l_Tempo_byte)
            For lz_Byteindex = 0 To 2
                l_Tempo_byte(lz_Byteindex) = l_Tempo_byte(lz_Byteindex + 1)
            Next
            l_Tempo_byte(3) = 0

            ' TRACK 1
            m_MC_FileStart.mp_Value() = {&H68, &H64, &H0, &H0, &H0, &H6}
            m_MC_Tempo_T1.mp_Value() = l_Tempo_byte 
            m_MC_Textmessage1.mp_Value = {&H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H20, &H0}
            m_MC_Tonart.mp_Value = {&H3, &H0}
            ' TRACK 2
            m_MC_TrackStart_T2.mp_Value = {&H0, &H0}
            m_MC_Kanal_T2.mp_Value = {0}
            m_MC_Textmessage.mp_Value = {&H5, &H6F, &H72, &H67, &H61, &H6E, &H0}
            m_MC_Trackname.mp_Value = {&H5, &H6F, &H72, &H67, &H61, &H6E, &H0}
            m_MC_Instrumentname.mp_Value = {&H5, &H6F, &H72, &H67, &H61, &H6E, &H0}
            m_MC_Instrument_T2.mp_Value = {gv_Song.mp_instrumentmidi}
            m_MC_Lautstärke.mp_Value = {&H7F}

            ' TRACK 1
            me_appendMidicodeToOutputpuffer(m_MC_FileStart)
            me_appendOutputPuffer(MC_FileHead)
            me_appendMidicodeToOutputpuffer(m_MC_Textmessage1)
            me_appendMidicodeToOutputpuffer(m_MC_Tempo_T1)
            'me_appendOutputPuffer(MC_Track1Rest)
            me_appendMidicodeToOutputpuffer(m_MC_TimeSignatur)
            me_appendMidicodeToOutputpuffer(m_MC_Tonart)
            me_appendOutputPuffer({&H0})
            me_appendMidicodeToOutputpuffer(m_MC_Trackend)

            ' TRACK 2
            me_appendMidicodeToOutputpuffer(m_MC_TrackStart_T2)
            ' Länge
            l_Track2Lenght(0) = m_Track2Länge256_byte
            l_Track2Lenght(1) = m_Track2Länge1_byte
            l_Track2Lenght(2) = &H0
            me_appendOutputPuffer(l_Track2Lenght)
            me_appendMidicodeToOutputpuffer(m_MC_Kanal_T2)
            me_appendOutputPuffer({&H0})
            me_appendMidicodeToOutputpuffer(m_MC_Textmessage)
            me_appendMidicodeToOutputpuffer(m_MC_Trackname)
            me_appendMidicodeToOutputpuffer(m_MC_Instrumentname) 
            me_appendMidicodeToOutputpuffer(m_MC_Instrument_T2)
            me_appendOutputPuffer({&H0})
            me_appendMidicodeToOutputpuffer(m_MC_Lautstärke)
            me_appendMidicodeToOutputpuffer(m_MC_Stereopanorama) 

            ' Noten hinzufügen
            m_OutputByte.me_appendPuffer(m_noteByte.mp_Result)

            me_appendMidicodeToOutputpuffer(m_MC_Trackend)

            ' Datei schreiben
            me_exportMidi(m_OutputByte.mp_Result, p_showfiledialog)

        Catch ex As Exception
            MsgBox("Ein Fehler ist bei der Erstellung der MIDI-Datei aufgetreten.")
        End Try
    End Sub

    'Public Sub testmidiexport()
    '    Dim l_Tempo As Integer
    '    Dim l_Tempo_byte As Byte()
    '    Dim l_MIDINote As MIDI_note
    '    Dim l_MIDIAkkord As MIDI_Akkord
    '    Dim l_Track2Lenght(2) As Byte

    '    Try
    '        m_Track2Länge1_byte = &H2F

    '        ' Puffer Noten 
    '        For Each lz_Takt In Takt.get_alleAktivTakte_asArray
    '            With lz_Takt
    '                l_MIDIAkkord = New MIDI_Akkord(.mp_Akkord)
    '                me_appendOutputPuffer(l_MIDIAkkord.mp_MIDI_An, True)
    '                For Each lz_taktEinheit In .get_alleTakteinheiten
    '                    l_MIDINote = New MIDI_note(lz_taktEinheit.mp_Melodienote)
    '                    me_appendOutputPuffer(l_MIDINote.mp_MIDI_An, True)
    '                    me_appendOutputPuffer(l_MIDINote.mp_MIDI_AUS, True)
    '                Next
    '                me_appendOutputPuffer(l_MIDIAkkord.mp_MIDI_AUS, True)
    '            End With
    '        Next

    '        ' Tempo ermitteln
    '        l_Tempo = 60000000 / gv_Song.mp_Tempo / 2
    '        l_Tempo_byte = BitConverter.GetBytes(l_Tempo)
    '        Array.Reverse(l_Tempo_byte)
    '        For lz_Byteindex = 0 To 2
    '            l_Tempo_byte(lz_Byteindex) = l_Tempo_byte(lz_Byteindex + 1)
    '        Next
    '        l_Tempo_byte(3) = 0

    '        'm_Text_Byte = {&H5, &H6F, &H72, &H67, &H61, &H6E, &H0}
    '        'm_Text_Byte = {&H65, &H61, &H73, &H79, &H48, &H61, &H72, &H6D, &H6F, &H6E, &H79, &H0}

    '        ' TRACK 1 
    '        m_MC_TrackStart_T1.mp_Value(, False) = {&H68, &H64, &H0, &H0, &H0, &H6}
    '        me_appendMidicodeToOutputpuffer(m_MC_TrackStart_T1)
    '        'me_appendMidiFile(MC_Track1Head)
    '        me_appendOutputPuffer(MC_Track1Head)
    '        m_MC_Tempo_T1.mp_Value() = l_Tempo_byte
    '        m_MC_TrackStart_T2.mp_Value = {&H72, &H6B, &H0, &H0}
    '        m_MC_Kanal_T2.mp_Value = {0}
    '        m_MC_Textmessage.mp_Value = {&H5, &H6F, &H72, &H67, &H61, &H6E, &H0}
    '        m_MC_Trackname.mp_Value = {&H5, &H6F, &H72, &H67, &H61, &H6E, &H0}
    '        m_MC_Instrumentname.mp_Value = {&H5, &H6F, &H72, &H67, &H61, &H6E, &H0}
    '        m_MC_Instrument_T2.mp_Value = {0}
    '        me_appendMidicodeToOutputpuffer(m_MC_Tempo_T1)

    '        'me_appendMidiFile(MC_Track1Rest)
    '        me_appendOutputPuffer(MC_Track1Rest)
    '        ' TRACK 2
    '        me_appendMidicodeToOutputpuffer(m_MC_TrackStart_T2)
    '        ' Länge
    '        l_Track2Lenght(0) = m_Track2Länge256_byte
    '        l_Track2Lenght(1) = m_Track2Länge1_byte
    '        l_Track2Lenght(2) = &H0
    '        'me_appendMidiFile(l_Track2Lenght)
    '        me_appendOutputPuffer(l_Track2Lenght)
    '        me_appendMidicodeToOutputpuffer(m_MC_Kanal_T2)
    '        me_appendMidicodeToOutputpuffer(m_MC_Textmessage)
    '        me_appendMidicodeToOutputpuffer(m_MC_Trackname)
    '        me_appendMidicodeToOutputpuffer(m_MC_Instrumentname)
    '        ' Rest
    '        'me_appendMidiFile(MC_Track2Head)
    '        me_appendOutputPuffer(MC_Track2Head)
    '        me_appendMidicodeToOutputpuffer(m_MC_Instrument_T2)

    '        ' Noten hinzufügen
    '        m_OutputByte.me_appendPuffer(m_noteByte.mp_Result)

    '        me_appendMidicodeToOutputpuffer(m_MC_Trackend)

    '        me_exportMidi(m_OutputByte.mp_Result)
    '        'm_MC_Trackend.me_appendToFile()

    '        MsgBox("Export erfolgreich")
    '    Catch ex As Exception
    '        MsgBox("Ein Fehler ist bei der Erstellung der MIDI-Datei aufgetreten.")
    '    End Try
    'End Sub
    ' PRIVATE 
    Private Sub me_appendOutputPuffer(ByVal p_value() As Byte, Optional ByVal p_istNote As Boolean = False)
        If Not p_istNote Then
            m_OutputByte.me_appendPuffer(p_value)
        Else
            m_noteByte.me_appendPuffer(p_value)
            ' Track2 Länge erweitern
            For Each lz_Byte In p_value
                If Not m_Track2Länge1_byte = &HFF Then
                    gAdd(m_Track2Länge1_byte, 1)
                Else
                    gAdd(m_Track2Länge256_byte, 1)
                    m_Track2Länge1_byte = &H0
                End If
            Next
        End If

    End Sub
    Private Sub me_appendMidicodeToOutputpuffer(ByVal p_MC As midicode)
        me_appendOutputPuffer(p_MC.mp_return)
    End Sub

    Private Shared Sub me_exportMidi(ByVal p_value() As Byte, ByVal p_showfiledialog As Boolean)
        Dim l_Pfad As String = ""
        Dim l_filedialog As FileDialog
        l_filedialog = sp_saveFildedialog
        If p_showfiledialog Then
            If (l_filedialog.ShowDialog() = DialogResult.OK) Then
                l_Pfad = l_filedialog.FileName
            End If
        Else
            l_Pfad = cp_ProgrammOrdner & "\midi.mid"
        End If
        If Not l_Pfad = "" Then

            My.Computer.FileSystem.WriteAllBytes(l_Pfad, p_value, False)
            'cl_ByteGenerator.sm_generiereByte(l_Pfad, p_value)
            MsgBox("MIDI-Datei wurde erstellt.")
        End If
    End Sub
    'Private Function me_Str_toByte(ByVal p_Str As String) As Byte()
    '    Dim l_Bytes As Byte()
    '    l_Bytes = System.Text.Encoding.Unicode.GetBytes(p_Str)
    '    Return l_Bytes
    'End Function
    End Class

