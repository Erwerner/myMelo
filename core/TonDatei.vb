'%NK

Public Class TonDatei
    'Inherits SoundDatei

    Public Shared m_Ton_spieltInStep(35) As Integer
    Private m_stop_atPlay As Integer

    Private m_Alias As String
    Private m_FilePath As String
    Private m_Anschlag As Integer
    Private Shared sv_instrument As sc_instrument
    'private shared sv_Melodieinstrument_rdnt as instrument
    'private shared sv_Soundfileordner_rdnt as String
    ' SHARED
    Public Shared ReadOnly Property cp_pf_SoundfileOrdner As String
        Get
            Return cp_ProgrammOrdner & "\SoundFiles" & sv_instrument.mp_Instrumentordner() & "\" ' %ToDo als rdnt speichern
        End Get
    End Property
    ' READONLY
    Public ReadOnly Property mp_alias As String
        Get
            Return m_Alias
        End Get
    End Property
    Public ReadOnly Property mp_Path As String
        Get
            Return m_FilePath
        End Get
    End Property
    Public ReadOnly Property mp_Anschlag As Integer
        Get
            Return m_Anschlag
        End Get
    End Property
    Public ReadOnly Property mp_wirdGespielt(ByVal p_Step As Integer, ByVal p_tonindex As Integer) As Boolean
        Get
            Return m_Ton_spieltInStep(p_tonindex) + 10 >= p_Step And m_Ton_spieltInStep(p_tonindex) > 0
        End Get
    End Property
    Public ReadOnly Property mp_Stop_at_play As Boolean
        Get
            Return m_stop_atPlay
        End Get
    End Property

    ' KONSTRUKTOR 1
    Public Sub New(ByRef ref_Note As Note, ByVal p_taktindex As Integer, ByVal p_einheitindex As Integer)
        m_Anschlag = ref_Note.mp_Länge
        If m_Anschlag < 1 Then Exit Sub
        me_init_Attributes(ref_Note, p_taktindex, p_einheitindex)
    End Sub
    ' KONSTRUKTOR 2
    Public Sub New(ByRef ref_Ton As Ton, ByVal p_taktindex As Integer, ByVal p_einheitindex As Integer)
        m_Anschlag = 1
        me_init_Attributes(ref_Ton, p_taktindex, p_einheitindex)
    End Sub
    Private Sub me_init_Attributes(ByVal ref_ton As Ton, ByVal p_taktindex As Integer, ByVal p_einheitindex As Integer)
        Dim lv_Alias As String

        Dim lv_Step As Integer
        Dim lv_Tonindex As Integer

        Dim l_path As String
        lv_Alias = ""

        If ref_ton.mp_TonEnum < 10 Then
            gAppendString(lv_Alias, "0" & ref_ton.mp_TonEnum)
        Else
            gAppendString(lv_Alias, ref_ton.mp_TonEnum)
        End If
        m_Alias = lv_Alias & ref_ton.mp_Oktave_realTon


        l_path = cp_pf_SoundfileOrdner & m_Alias & ".wav"
        sm_ShortPath(l_path)


        m_FilePath = l_path
        lv_Tonindex = ref_ton.mp_TonIndex
        lv_Step = gStep_integer(p_taktindex, p_einheitindex)
        m_stop_atPlay = mp_wirdGespielt(lv_Step, lv_Tonindex)
        m_Ton_spieltInStep(lv_Tonindex) = lv_Step

        sm_open(m_FilePath, m_Alias)
    End Sub
    ' SHARED
    Public Shared Sub sm_closeSoundfiles()
        Dim lz_oktave As Integer
        Dim lz_ton As Integer

        Dim l_TonIndex As String
        l_TonIndex = ""

        With Form1.stlStatus
            .Maximum = 6 * 12
            .Visible = True

            For lz_oktave = 0 To 4
                For lz_ton = 0 To 11
                    If lz_ton < 10 Then
                        gAppendString(l_TonIndex, "0" & lz_ton & lz_oktave)
                    Else
                        gAppendString(l_TonIndex, lz_ton & lz_oktave)
                    End If
                    sm_close(l_TonIndex)
                    Form1.stlStatus.Value = (lz_ton + 1) + 12 * (lz_oktave)
                    l_TonIndex = ""
                Next
            Next
            .Visible = False
        End With
    End Sub
    Public Shared Sub sm_clear()
        For zTon = 0 To 35
            m_Ton_spieltInStep(zTon) = 0
        Next
    End Sub
    'Public Shared Sub sm_knopf()
    '    sm_playDatei("Knopf")
    'End Sub
    Public Shared Sub sm_playTon(ByVal p_ton As Ton)
        Dim l_Tondatei As TonDatei
        l_Tondatei = New TonDatei(p_ton, 0, 0)
        l_Tondatei.me_open()
        l_Tondatei.me_play()
        'l_Tondatei.me_close()
    End Sub
    Public Shared Sub initInstrument()
        sv_instrument = sc_instrument.factory(gv_Song.mp_instrumentmelodie)
    End Sub
    'Private Shared Sub sm_playDatei(ByVal p_Alias)
    '    Dim l_path As String
    '    l_path = cp_pf_SoundfileOrdner & p_Alias & ".wav"
    '    sm_ShortPath(l_path)

    '    sm_open(l_path, p_Alias)
    '    sm_play(p_Alias)
    'End Sub
    Private Shared Sub sm_ShortPath(ByRef ref_path As String)
        Dim sBuffer As String
        sBuffer = Space$(255)

        GetShortPathName(ref_path, sBuffer, Len(sBuffer))
        Try
            ref_path = Microsoft.VisualBasic.Left(sBuffer, InStr(sBuffer, vbNullChar) - 1) 
        Catch ex As Exception

        End Try
    End Sub
    Private Shared Sub sm_open(ByVal p_Filepath As String, ByVal p_alias As String)
        gsound_docommand("open " & p_Filepath & " type MPEGVideo alias " & p_alias)
    End Sub
    Private Shared Sub sm_play(ByVal p_alias As String)
        gsound_docommand("play " & p_alias & " from 0")
    End Sub
    Private Shared Sub sm_close(ByVal p_Alias As String)
        gsound_docommand("close " & p_Alias)
    End Sub
    ' PUBLIC
    'Public Sub me_stop()
    '    gsound_docommand("stop " & m_Alias)
    'End Sub
    ' PRIVATE
    Private Sub me_open()
        gsound_docommand("open " & m_FilePath & " type MPEGVideo alias " & m_Alias)
    End Sub
    Private Sub me_play()
        gsound_docommand("play " & m_Alias & " from 0")
    End Sub
    Private Sub me_close()
        gsound_docommand("close " & m_Alias)
    End Sub

End Class
