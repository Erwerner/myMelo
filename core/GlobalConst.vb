Public Enum e_SoundDatei
    dummy
    'dummymidi
    Knopf
End Enum
Public Enum e_InstrumentListTyp
    MIDI
    MIDI_REAL
    MIDI_TEXT
    MIDI_REAL_TEXT
End Enum
Public Enum e_TonEnum
    C = 0
    Cs = 1
    Df = 1
    D = 2
    Ds = 3
    Ef = 3
    E = 4
    F = 5
    Fs = 6
    Gf = 6
    G = 7
    Gs = 8
    Af = 8
    A = 9
    Asrp = 10
    Bf = 10
    B = 11

End Enum
Public Enum e_instrumentenum
    Klavier = 0
    Gitarre = 1
End Enum
Public Enum e_Tongeschlecht
    Dur
    Moll
End Enum
Public Enum e_Akkordfunktion
    Tonika = 0
    Subdominantparallele = 1
    Dominantparallele = 2
    Subdominante = 3
    Dominante = 4
    Tonikaparallele = 5
    letzter = 6
End Enum
Public Enum e_Akkordtonfunktion
    Grundton
    Ton2
    Ton3
    nichts
End Enum
Public Enum e_Takttyp
    Auftakt = -1
    Schlussakkord = -2
End Enum
Public Enum e_wertErhaltenEnum
    WertErhalten
    WertÄndern
End Enum
Module GlobalConst

    Public c_MinEinheit As Integer = 7
    Public c_LeiterAkkordgeschlecht(6) As e_Tongeschlecht
    Public c_Halbtonintervall() As Integer = New Integer(6) {2, 2, 1, 2, 2, 2, 1}
    Public c_Halbtonhöhe() As Integer = New Integer(6) {0, 2, 4, 5, 7, 9, 11}

    Public c_StrAkkordfunktion() As String = New String(5) {"Tonika", "Subdominantparallele", "Dominantparallele", "Subdominante", "Dominante", "Tonikaparallele"}
    Public c_StrTonName() As String = New String(11) {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "H"}
    'Public c_StrTonName() As String = New String(11) {"C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab", "A", "A#/b", "H/Cb"}
    Public c_strTonGeschlecht() As String = New String(1) {"Dur", "Moll"}
    Public c_Tastenfarbe() As Color = New Color(11) {Color.White, Color.Black, Color.White, Color.Black, Color.White, Color.White, Color.Black, Color.White, Color.Black, Color.White, Color.Black, Color.White}

    Public c_AkkordfunktionKadenz As e_Akkordfunktion() = {e_Akkordfunktion.Tonika, e_Akkordfunktion.Tonikaparallele, e_Akkordfunktion.Subdominante, e_Akkordfunktion.Dominante}
    Public c_MelodienoteEmpty_1Dim(c_MinEinheit) As Note

    Public ReadOnly Property cp_Akkord(ByVal p_Index As e_TonEnum, ByVal p_Geschlecht As e_Tongeschlecht) As Akkord
        Get
            Dim xAkkord As New Akkord(p_Index, p_Geschlecht)
            Return xAkkord
        End Get
    End Property

    Public ReadOnly Property cp_dummyTon
        Get
            Return New Ton(-1, -1)
        End Get
    End Property
    Public ReadOnly Property cp_ProgrammOrdner As String
        Get
            Dim l_Path As String
            l_Path = IIf(gp_Entwickung, "C:\easy Harmony", _
                            Application.StartupPath)
            Return gShortPath(l_Path)
        End Get
    End Property
    Public ReadOnly Property cp_SaveOrdner As String
        Get
            Dim l_Path As String
            l_Path = cp_ProgrammOrdner & "\save\"
            Return l_Path
        End Get
    End Property 
    Public ReadOnly Property cp_empty_Melodienote2Dim(ByVal l_AnzahlTakte As Integer) As Note(,)
        Get
            Dim l_Melodienote(l_AnzahlTakte, c_MinEinheit) As Note
            For lz_taltindex = 0 To 3
                For lz_Takteinheitindex = 0 To 7
                    l_Melodienote(lz_taltindex, lz_Takteinheitindex) = New Note(-1, -1, 0)
                Next
            Next
            Return l_Melodienote
        End Get
    End Property

    Public Sub gm_ConstantInitialisierung()
        c_LeiterAkkordgeschlecht(0) = e_Tongeschlecht.Dur
        c_LeiterAkkordgeschlecht(1) = e_Tongeschlecht.Moll
        c_LeiterAkkordgeschlecht(2) = e_Tongeschlecht.Moll
        c_LeiterAkkordgeschlecht(3) = e_Tongeschlecht.Dur
        c_LeiterAkkordgeschlecht(4) = e_Tongeschlecht.Dur
        c_LeiterAkkordgeschlecht(5) = e_Tongeschlecht.Moll
        c_LeiterAkkordgeschlecht(6) = e_Tongeschlecht.Moll


        For lz_Takteinheitindex = 0 To 7
            c_MelodienoteEmpty_1Dim(lz_Takteinheitindex) = New Note(-1, -1, 0)
        Next
    End Sub 
End Module
