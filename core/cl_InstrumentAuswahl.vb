Public Class cl_InstrumentAuswahl
    Const c_InstrumentRawData As String = "Piano:" & vbCrLf & _
                                        "1 Acoustic Grand Piano" & vbCrLf & _
                                        "2 Bright Acoustic Piano" & vbCrLf & _
                                        "3 Electric Grand Piano" & vbCrLf & _
                                        "4 Honky-tonk Piano" & vbCrLf & _
                                        "5 Electric Piano 1" & vbCrLf & _
                                        "6 Electric Piano 2" & vbCrLf & _
                                        "7 Harpsichord" & vbCrLf & _
                                        "8 Clavi" & vbCrLf & _
                                        "Chromatic Percussion:" & vbCrLf & _
                                        "9 Celesta" & vbCrLf & _
                                        "10 Glockenspiel" & vbCrLf & _
                                        "11 Music Box" & vbCrLf & _
                                        "12 Vibraphone" & vbCrLf & _
                                        "13 Marimba" & vbCrLf & _
                                        "14 Xylophone" & vbCrLf & _
                                        "15 Tubular Bells" & vbCrLf & _
                                        "16 Dulcimer" & vbCrLf & _
                                        "Organ:" & vbCrLf & _
                                        "17 Organ" & vbCrLf & _
                                        "18 Percussive Organ" & vbCrLf & _
                                        "19 Rock Organ" & vbCrLf & _
                                        "20 Church Organ" & vbCrLf & _
                                        "21 Reed Organ" & vbCrLf & _
                                        "22 Accordion" & vbCrLf & _
                                        "23 Harmonica" & vbCrLf & _
                                        "24 Tango Accordion" & vbCrLf & _
                                        "Guitar:" & vbCrLf & _
                                        "25 Acoustic Guitar (nylon)" & vbCrLf & _
                                        "26 Acoustic Guitar (steel)" & vbCrLf & _
                                        "27 Electric Guitar (jazz)" & vbCrLf & _
                                        "28 Electric Guitar (clean)" & vbCrLf & _
                                        "29 Electric Guitar (muted)" & vbCrLf & _
                                        "30 Overdriven Guitar" & vbCrLf & _
                                        "31 Distortion Guitar" & vbCrLf & _
                                        "32 Guitar harmonics" & vbCrLf & _
                                        "Bass:" & vbCrLf & _
                                        "33 Acoustic Bass" & vbCrLf & _
                                        "34 Electric Bass (finger)" & vbCrLf & _
                                        "35 Electric Bass (pick)" & vbCrLf & _
                                        "36 Fretless Bass" & vbCrLf & _
                                        "37 Slap Bass 1" & vbCrLf & _
                                        "38 Slap Bass 2" & vbCrLf & _
                                        "39 Synth Bass 1" & vbCrLf & _
                                        "40 Synth Bass 2" & vbCrLf & _
                                        "Strings:" & vbCrLf & _
                                        "41 Violin" & vbCrLf & _
                                        "42 Viola" & vbCrLf & _
                                        "43 Cello" & vbCrLf & _
                                        "44 Contrabass" & vbCrLf & _
                                        "45 Tremolo Strings" & vbCrLf & _
                                        "46 Pizzicato Strings" & vbCrLf & _
                                        "47 Orchestral Harp" & vbCrLf & _
                                        "48 Timpani" & vbCrLf & _
                                        "Ensemble:" & vbCrLf & _
                                        "49 String Ensemble 1" & vbCrLf & _
                                        "50 String Ensemble 2" & vbCrLf & _
                                        "51 Synth Strings 1" & vbCrLf & _
                                        "52 Synth Strings 2" & vbCrLf & _
                                        "53 Voice Aahs" & vbCrLf & _
                                        "54 Voice Oohs" & vbCrLf & _
                                        "55 Synth Voice" & vbCrLf & _
                                        "56 Orchestra Hit" & vbCrLf & _
                                        "Brass:" & vbCrLf & _
                                        "57 Trumpet" & vbCrLf & _
                                        "58 Trombone" & vbCrLf & _
                                        "59 Tuba" & vbCrLf & _
                                        "60 Muted Trumpet" & vbCrLf & _
                                        "61 French Horn" & vbCrLf & _
                                        "62 Brass Section" & vbCrLf & _
                                        "63 Synth Brass 1" & vbCrLf & _
                                        "64 Synth Brass 2 " & vbCrLf & _
                                        "Reed:" & vbCrLf & _
                                        "65 Soprano Sax" & vbCrLf & _
                                        "66 Alto Sax" & vbCrLf & _
                                        "67 Tenor Sax" & vbCrLf & _
                                        "68 Baritone Sax" & vbCrLf & _
                                        "69 Oboe" & vbCrLf & _
                                        "70 English Horn" & vbCrLf & _
                                        "71 Bassoon" & vbCrLf & _
                                        "72 Clarinet" & vbCrLf & _
                                        "Pipe:" & vbCrLf & _
                                        "73 Piccolo" & vbCrLf & _
                                        "74 Flute" & vbCrLf & _
                                        "75 Recorder" & vbCrLf & _
                                        "76 Pan Flute" & vbCrLf & _
                                        "77 Blown Bottle" & vbCrLf & _
                                        "78 Shakuhachi" & vbCrLf & _
                                        "79 Whistle" & vbCrLf & _
                                        "80 Ocarina" & vbCrLf & _
                                        "Synth Lead:" & vbCrLf & _
                                        "81 Lead 1 (square)" & vbCrLf & _
                                        "82 Lead 2 (sawtooth)" & vbCrLf & _
                                        "83 Lead 3 (calliope)" & vbCrLf & _
                                        "84 Lead 4 (chiff)" & vbCrLf & _
                                        "85 Lead 5 (charang)" & vbCrLf & _
                                        "86 Lead 6 (voice)" & vbCrLf & _
                                        "87 Lead 7 (fifths)" & vbCrLf & _
                                        "88 Lead 8 (bass + lead)" & vbCrLf & _
                                        "Synth Pad:" & vbCrLf & _
                                        "89 Pad 1 (new age)" & vbCrLf & _
                                        "90 Pad 2 (warm)" & vbCrLf & _
                                        "91 Pad 3 (polysynth)" & vbCrLf & _
                                        "92 Pad 4 (choir)" & vbCrLf & _
                                        "93 Pad 5 (bowed)" & vbCrLf & _
                                        "94 Pad 6 (metallic)" & vbCrLf & _
                                        "95 Pad 7 (halo)" & vbCrLf & _
                                        "96 Pad 8 (sweep)" & vbCrLf & _
                                        "Synth Effects:" & vbCrLf & _
                                        "97 FX 1 (rain)" & vbCrLf & _
                                        "98 FX 2 (soundtrack)" & vbCrLf & _
                                        "99 FX 3 (crystal)" & vbCrLf & _
                                        "100 FX 4 (atmosphere)" & vbCrLf & _
                                        "101 FX 5 (brightness)" & vbCrLf & _
                                        "102 FX 6 (goblins)" & vbCrLf & _
                                        "103 FX 7 (echoes)" & vbCrLf & _
                                        "104 FX 8 (sci-fi)" & vbCrLf & _
                                        "Ethnic:" & vbCrLf & _
                                        "105 Sitar" & vbCrLf & _
                                        "106 Banjo" & vbCrLf & _
                                        "107 Shamisen" & vbCrLf & _
                                        "108 Koto" & vbCrLf & _
                                        "109 Kalimba" & vbCrLf & _
                                        "110 Bagpipe" & vbCrLf & _
                                        "111 Fiddle" & vbCrLf & _
                                        "112 Shanai" & vbCrLf & _
                                        "Percussive:" & vbCrLf & _
                                        "113 Tinkle Bell" & vbCrLf & _
                                        "114 Agogo Bells" & vbCrLf & _
                                        "115 Steel Drums" & vbCrLf & _
                                        "116 Woodblock" & vbCrLf & _
                                        "117 Taiko Drum" & vbCrLf & _
                                        "118 Melodic Tom" & vbCrLf & _
                                        "119 Synth Drum" & vbCrLf & _
                                        "120 Reverse Cymbal" & vbCrLf & _
                                        "Sound effects:" & vbCrLf & _
                                        "121 Guitar Fret Noise" & vbCrLf & _
                                        "122 Breath Noise" & vbCrLf & _
                                        "123 Seashore" & vbCrLf & _
                                        "124 Bird Tweet" & vbCrLf & _
                                        "125 Telephone Ring" & vbCrLf & _
                                        "126 Helicopter" & vbCrLf & _
                                        "127 Applause" & vbCrLf & _
                                        "128 Gunshot"
    Private Class cl_InstrumentItem
        'Private Shared sv_Index As Integer
        'Private m_Index As Integer
        Private m_InstrumentIndex As Integer
        Private m_istInstrument As Boolean
        Private m_istMIDI As Boolean
        Private m_Text As String

        Public ReadOnly Property mp_InstrumentIndex As Integer
            Get
                Return m_InstrumentIndex
            End Get
        End Property
        Public ReadOnly Property mp_istInstrument As Boolean
            Get
                Return m_istInstrument
            End Get
        End Property
        Public ReadOnly Property mp_istMIDI As Boolean
            Get
                Return m_istMIDI
            End Get
        End Property
        Public ReadOnly Property mp_Text As String
            Get
                Return m_Text
            End Get
        End Property
        'Public ReadOnly Property mp_FileOrdner As String
        '    Get

        '    End Get
        'End Property

        Public Sub New(ByVal p_Text As String, Optional ByVal p_istMIDI As Boolean = False, Optional ByVal p_InstrumentIndex As Integer = -1, Optional ByVal p_istInstrument As Boolean = True)
            m_istInstrument = p_istInstrument
            m_istMIDI = p_istMIDI
            m_InstrumentIndex = p_InstrumentIndex
            m_Text = p_Text
        End Sub
    End Class



    Private Shared this(3) As cl_InstrumentAuswahl
    Private m_instrumentItem As New List(Of cl_InstrumentItem)
    Private m_InstrumentListIndex_vonInstrument As New List(Of Integer)
    Private ReadOnly Property mp_InstrumentCount As Integer
        Get
            Return m_instrumentItem.Count
        End Get
    End Property


    ' READONLY
    Public ReadOnly Property mp_InstrumentListIndex_vonInstrument(ByVal p_Instrumentindex As Integer) As Integer
        Get
            Return m_InstrumentListIndex_vonInstrument(p_Instrumentindex)
        End Get
    End Property
    Public ReadOnly Property mp_wähle_InstrumentIndex(ByVal p_InstrumentListIndex As Integer) As Integer
        Get
            Dim l_return As cl_InstrumentItem
            Dim l_ListIndex As Integer
            Dim l_fertig As Boolean
            l_fertig = False
            l_ListIndex = p_InstrumentListIndex
            l_return = New cl_InstrumentItem("DUMMY", True, 0)
            Do While Not l_fertig
                Try
                    If m_instrumentItem(l_ListIndex).mp_istInstrument Then
                        l_return = m_instrumentItem(l_ListIndex)
                        l_fertig = True
                    End If
                Catch ex As Exception
                    l_fertig = True
                End Try
                gAdd(l_ListIndex)
            Loop
            Return l_return.mp_InstrumentIndex
        End Get
    End Property
    Public ReadOnly Property mp_arrayfetch_Name() As List(Of String)
        Get
            Dim l_Return As New List(Of String)
            For Each lz_I In m_instrumentItem
                l_Return.Add(lz_I.mp_Text)
            Next
            Return l_Return
        End Get
    End Property

    ' KONSTRUKTOR
    Private Sub New(ByVal p_InstrumentListTyp As e_InstrumentListTyp)
        Select Case p_InstrumentListTyp
            Case e_InstrumentListTyp.MIDI
                me_initRawdata(False)
            Case e_InstrumentListTyp.MIDI_REAL
                me_initRawdata(False)
            Case e_InstrumentListTyp.MIDI_REAL_TEXT
                me_initRawdata()
            Case e_InstrumentListTyp.MIDI_TEXT
                me_initRawdata()
        End Select
    End Sub
    Public Shared Function getInstance(ByVal p_InstrumentListTyp As e_InstrumentListTyp) As cl_InstrumentAuswahl
        If this(p_InstrumentListTyp) Is Nothing Then
            this(p_InstrumentListTyp) = New cl_InstrumentAuswahl(p_InstrumentListTyp)
        End If
        Return this(p_InstrumentListTyp)
    End Function

    ' INIT
    Private Sub me_initRawdata(Optional ByVal p_mitText As Boolean = True)
        Dim l_raw As String()
        Dim l_posStartInstrument As Integer
        Dim l_InstrumentString() As String
        Dim l_Instrument As Integer
        l_raw = Split(c_InstrumentRawData, vbCrLf)
        For Each lz_String In l_raw
            If InStr(lz_String, ":") = 0 Then
                ' Ist Midi
                l_posStartInstrument = InStr(lz_String, " ")
                Mid(lz_String, l_posStartInstrument, 1) = ";"
                l_InstrumentString = Split(lz_String, ";")
                If p_mitText Then l_InstrumentString(1) = "- " & l_InstrumentString(1)
                l_Instrument = l_InstrumentString(0) - 1
                m_instrumentItem.Add(New cl_InstrumentItem(l_InstrumentString(1), True, l_Instrument))
                m_InstrumentListIndex_vonInstrument.Add(arrIx(mp_InstrumentCount))

            ElseIf p_mitText Then
                ' Ist Text
                m_instrumentItem.Add(New cl_InstrumentItem("", , , False))
                m_instrumentItem.Add(New cl_InstrumentItem("___ " & lz_String & " ___", , , False))
            End If
        Next
    End Sub
End Class
