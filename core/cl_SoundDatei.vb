
Module mod_SoundModul
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpszCommand As String, ByVal lpszReturnString As String, ByVal cchReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Public Declare Function GetShortPathName Lib "kernel32" Alias "GetShortPathNameA" (ByVal lpszLongPath As String, ByVal lpszShortPath As String, ByVal cchBuffer As Integer) As Integer
    Public Sub gsound_docommand(ByRef ref_command As String)
        mciSendString(ref_command, 0, 0, 0)
    End Sub
End Module


Public Class cl_SoundDatei

    Private Shared this(2) As cl_SoundDatei
    Private m_Dateiendung As String
    Private m_Alias As String
    Private m_Ordner As String


    ' Shared
    Private Shared ReadOnly Property cp_RootOrdnerSound As String
        Get
            Return gShortPath(cp_ProgrammOrdner & "\SoundFiles" & "\")
        End Get
    End Property
    ' READONLY
    Private ReadOnly Property mp_Path As String
        Get
            Return cp_RootOrdnerSound & m_Ordner & m_Alias & m_Dateiendung
        End Get
    End Property

    ' KONSTRUKTOR
    Private Sub New(ByVal p_Ordner As String, ByVal p_Alias As String, ByVal p_Dateiendung As String)
        m_Alias = p_Alias
        m_Dateiendung = p_Dateiendung
        m_Ordner = p_Ordner
        gShortPath(m_Ordner)
    End Sub

    ' SHARED
    Public Shared Function play(ByVal p_SoundDatei As e_SoundDatei) As cl_SoundDatei
        Dim l_return As cl_SoundDatei
        For Each lz_Sound In this
            If Not lz_Sound Is Nothing Then lz_Sound.me_close()
        Next
        If this(p_SoundDatei) Is Nothing Then
            Select Case p_SoundDatei
                Case e_SoundDatei.dummy
                    this(p_SoundDatei) = New cl_SoundDatei("", "dummy", ".wav")
                    'Case e_SoundDatei.dummymidi
                    '    this(p_SoundDatei) = New cl_SoundDatei("", "dummy_midi", ".mid")
                Case e_SoundDatei.Knopf
                    this(p_SoundDatei) = New cl_SoundDatei("", "Knopf", ".wav")
                Case Else
                    this(p_SoundDatei) = New cl_SoundDatei("", "dummy", ".wav")
            End Select
        End If
        l_return = this(p_SoundDatei)

        l_return.me_open()
        l_return.me_play()
        Return l_return
    End Function

    ' PRIVATE 
    Private Sub me_open()
        gsound_docommand("open " & mp_Path & " type MPEGVideo alias " & m_Alias)
        'gsound_docommand("open " & mp_Path & " type MIDI alias " & m_Alias)
    End Sub
    Private Sub me_play()
        gsound_docommand("play " & m_Alias & " from 0")
    End Sub
    Private Sub me_close()
        gsound_docommand("close " & m_Alias)
    End Sub
    Private Sub me_stop()
        gsound_docommand("stop " & m_Alias)
    End Sub
End Class
