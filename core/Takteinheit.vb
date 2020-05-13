Public Class Takteinheit
    Private m_EinheitIndex As Integer       '0-7 Position im Takt

    Private m_MelodieNote As New Note(-1)   'ausgewählte Note
    Private m_Akkord As New Akkord(-1, e_Tongeschlecht.Dur)
    'Private myAnschlag As Integer           '0=Pause, 1-127 = Lautstärke

    Public ReadOnly Property mp_Melodienote As Note
        Get
            Return m_MelodieNote
        End Get
    End Property
    Public ReadOnly Property mp_Akkord As Akkord
        Get
            Return m_Akkord
        End Get
    End Property
    Public ReadOnly Property mp_Index As Integer
        Get
            Return m_EinheitIndex
        End Get
    End Property

    ' KONSTRUKTOR
    Sub New(ByVal p_EinheitIndex As Integer,
            ByVal p_Akkord As Akkord)
        m_EinheitIndex = p_EinheitIndex
        m_Akkord = p_Akkord
    End Sub


    ' PUBLIC
    Public Sub me_akkordwechsel(ByVal p_akkord As Akkord)
        m_Akkord = p_akkord
    End Sub
    Public Sub me_setMelodieNote(ByVal p_Note As Note)
        m_MelodieNote = p_Note
    End Sub
    Public Sub me_setMelodieNote(ByVal p_ton As e_TonEnum, ByVal p_Oktave As Integer, ByVal p_Länge As Integer)
        Dim l_Note As Note
        l_Note = New Note(p_ton, p_Oktave, p_Länge)
        me_setMelodieNote(l_Note) ' Aufruf der Notenübergabe
    End Sub
    Public Sub me_setMelodienote_aus()
        me_setMelodieNote(-1, -1, 0)
    End Sub
    Public Sub me_Tonartwechsel()
        m_MelodieNote.me_Tonartwechsel()
        m_Akkord.me_Tonartwechsel()
    End Sub
End Class
