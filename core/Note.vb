'%ToDo Anschlag
Public Class Note
    Inherits Ton
    Private m_Länge As Integer ' -1 verbunden 
    '                             0 Pause
    '                           1-8 Länge

    ' PUBLIC
    Public Property mp_Länge As Integer ' Wird nur beim Songladen geschrieben
        Get
            Return m_Länge
        End Get
        Set(ByVal value As Integer)
            m_Länge = value
        End Set
    End Property
    Public ReadOnly Property mp_wirdGespielt As Boolean
        Get
            Return m_Oktave_derTonart >= 0 And m_TonEnum >= 0 And m_Länge > 0
        End Get
    End Property

    ' KONSTRUKTOR
    Sub New(ByVal p_TonEnum As e_TonEnum,
   Optional ByVal p_Oktave As Integer = 1,
   Optional ByVal p_Länge As Integer = 0)
        MyBase.New(p_TonEnum, p_Oktave)
        m_Länge = p_Länge
    End Sub
End Class
