'%CS
Public Class cl_Programmdaten
    Private Shared this As cl_Programmdaten 
    Private m_ProgrammdatenString As String
    Private m_programmdatenversion As Char = "§"
    '!
    Private m_ProgrammEditionsTyp As Char = "B"
    Private m_UpdateAutom As Boolean = True
    ' §
    Private m_ProgrammHerkunft As String = "AAC"
    'Private m_erststart As Boolean
    'Private m_erstUpdate As Boolean

    'Public Property mp_erststart As Boolean
    '    Get
    '        Return m_erststart
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_erststart = value
    '        m_erstUpdate = value
    '    End Set
    'End Property
    Public Property mp_UpdateAutom(Optional ByVal p_aktualisiereDatei As Boolean = True) As Boolean
        Set(ByVal value As Boolean)
            m_UpdateAutom = value
            Form1.AutomatischeUpdatesToolStripMenuItem.Checked = value
            If p_aktualisiereDatei Then
                me_schreibeProgrammdaten() 
            End If
        End Set
        Get
            Return m_UpdateAutom
        End Get
    End Property
    'Public Property mp_erstUpdate As Boolean
    '    Get
    '        Return m_erstUpdate
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_erstUpdate = value
    '    End Set
    'End Property
    ' READONLY
    'Private ReadOnly Property mp_programmdatenversion
    '    Get
    '        Return m_programmdatenversion
    '    End Get
    'End Property
    Public ReadOnly Property cp_ProgrammdataPath
        Get
            Return cp_ProgrammOrdner & "\data"
        End Get
    End Property
    Public ReadOnly Property mp_ProgrammEditionsTyp As String
        Get
            Return m_ProgrammEditionsTyp
        End Get
    End Property
    Public ReadOnly Property mp_ProgrammdatenString(Optional ByVal p_refresh As Boolean = False) As String
        Get
            If m_ProgrammdatenString = "" Or p_refresh Then
                m_ProgrammdatenString = m_programmdatenversion & ";" & _
                m_ProgrammEditionsTyp & ";" & _
                global_BoolToInt(m_UpdateAutom) & ";" & _
                m_ProgrammHerkunft & ";"
            End If
            Return m_ProgrammdatenString
        End Get
    End Property
    'GET INSTANZ
    Public Shared Function getInstanz() As cl_Programmdaten
        If this Is Nothing Then
            this = New cl_Programmdaten
            this.me_Programmdaten_laden()
        End If
        getInstanz = this
    End Function
    ' PRIVATE
    'Private Sub me_Programmdaten_ändern(ByVal p_startpos As Integer, ByVal p_länge As Integer, ByVal p_value As String)
    '    Mid(m_ProgrammdatenString, p_startpos, p_länge) = p_value
    '    cl_ImExport.factory.me_ex_File(cp_ProgrammdataPath, m_ProgrammdatenString)
    'End Sub
    Private Sub me_Programmdaten_laden()
        Dim l_Fallbackstring As String
        Dim l_Programmdatenpath As String
        Dim l_Programmdataversion As Char
        Dim l_ImExport As cl_ImExport
        l_ImExport = cl_ImExport.factory
        l_Programmdatenpath = cp_ProgrammdataPath
        l_Fallbackstring = mp_ProgrammdatenString
        If My.Computer.FileSystem.FileExists(l_Programmdatenpath) Then
            ' lese Daten
            My.Settings.ErstStart = False
            My.Settings.ErstUpdate = False
            m_ProgrammdatenString = l_ImExport.me_Imp_File(l_Programmdatenpath, l_Fallbackstring)
            l_Programmdataversion = l_ImExport.me_getImp_Part()
            Select Case l_Programmdataversion
                Case "!"
                    me_programmdatenLesen1(l_ImExport)
                    me_schreibeProgrammdaten()
                    'l_ImExport.me_ex_File(l_Programmdatenpath, mp_ProgrammdatenString(True))
                Case "§"
                    me_programmdatenLesen1(l_ImExport)
                    me_programmdatenLesen2(l_ImExport)
                Case Else

            End Select
        Else
            ' Programmdaten schreiben
            me_schreibeProgrammdaten()
            My.Settings.ErstStart = True
            My.Settings.ErstUpdate = True
            mp_UpdateAutom = True
            'l_ImExport.me_ex_File(l_Programmdatenpath, l_Fallbackstring)
            'My.Settings.ErstStart = True
            'My.Settings.ErstUpdate = True
            'm_ProgrammdatenString = l_Fallbackstring
            'l_Programmdataversion = mp_programmdatenversion
            'l_ProgrammEditionsTyp = mp_ProgrammEditionsTyp
            'l_automUpdate = mp_UpdateAutom
        End If
        'Select Case l_Programmdataversion
        '    Case "!"
        'End Select
    End Sub
    Private Sub me_programmdatenLesen1(ByVal p_ImExport As cl_ImExport)
        m_ProgrammEditionsTyp = p_ImExport.me_getImp_Part
        mp_UpdateAutom(False) = p_ImExport.me_getImp_Part(True)
    End Sub
    Private Sub me_programmdatenLesen2(ByVal p_ImExport As cl_ImExport)
        m_ProgrammHerkunft = p_ImExport.me_getImp_Part
    End Sub
    Private Sub me_schreibeProgrammdaten()
        cl_ImExport.factory.me_ex_File(cp_ProgrammdataPath, mp_ProgrammdatenString(True))
    End Sub
End Class
