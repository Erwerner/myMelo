Public Class TonEingabe

    Private m_taktEinheitIndex As Integer
    Private m_oktavIndex As Integer
    Private m_leitertonIndex As Integer

    Private m_BackColor As Color

    Private m_anschlag As Integer

    Public ReadOnly Property mp_istAktiv As Boolean
        Get
            Return m_anschlag > 0
        End Get
    End Property
    Private ReadOnly Property mp_Ton As Ton
        Get
            Return New Ton(g_Leiterton(m_leitertonIndex), m_oktavIndex)
        End Get
    End Property
    Private ReadOnly Property mp_parent As TaktEinheitEingabe
        Get
            Return Form1.TaktEingabe1.mp_TaktEinheitEingabe(m_taktEinheitIndex)
        End Get
    End Property
    Private ReadOnly Property mp_TaktEinheit As Takteinheit
        Get
            Return TaktEingabe.sp_EingabeTakt.mp_TaktEinheit(m_taktEinheitIndex)
        End Get
    End Property
    Private WriteOnly Property mp_BackColor As Color
        Set(ByVal value As Color)
            Me.PictureBox1.Visible = value = c_Color_Note
            Me.BackColor = value
        End Set
    End Property
    ' KONSTRUKTOR
    Public Sub New(ByVal p_Einheitindex As Integer, ByVal p_oktavindex As Integer, ByVal p_Leitertonindex As Integer)
        InitializeComponent()

        m_taktEinheitIndex = p_Einheitindex
        m_oktavIndex = p_oktavindex
        m_leitertonIndex = p_Leitertonindex
        Me.Location = New System.Drawing.Point(globDes_BreiteTonCursor * p_Leitertonindex + globDes_BreiteTonCursor * p_oktavindex * 7, 1)
        'mp_Backcolor = m_BackColor
        Me.Size = New System.Drawing.Size(globDes_BreiteTonCursor, globDes_BreiteTonCursor)
    End Sub

    Public Sub me_setAkkord()
        Select Case TaktEingabe.sp_EingabeAkkordtonfunktion_byLeiterton(m_leitertonIndex)
            Case e_Akkordtonfunktion.nichts
                m_BackColor = Color.WhiteSmoke
            Case e_Akkordtonfunktion.Ton2
                m_BackColor = c_Color_Ton
            Case e_Akkordtonfunktion.Ton3
                m_BackColor = c_Color_Ton
            Case e_Akkordtonfunktion.Grundton
                m_BackColor = c_Color_Grundton
        End Select
        mp_Backcolor = m_BackColor
    End Sub
    Public Sub me_deaktivieren()
        m_anschlag = 0
        mp_Backcolor = m_BackColor
    End Sub
    Public Sub me_aktivieren(Optional ByVal p_anschlag As Integer = 1)
        m_anschlag = p_anschlag
        mp_Backcolor = c_Color_Note
        mp_parent.mp_aktivTonpanel = Me
    End Sub
    Private Sub me_setzeTon(Optional ByVal p_anschlag As Integer = 1)
        If p_anschlag > 0 Then
            mp_parent.me_clear()
            mp_parent.mp_aktivTonpanel = Me
            mp_TaktEinheit.me_setMelodieNote(g_Leiterton(m_leitertonIndex), m_oktavIndex, 1)
            me_aktivieren()
        Else
            mp_TaktEinheit.me_setMelodienote_aus()
            me_deaktivieren()
        End If

    End Sub

    Private Sub me_clicked()
        If mp_istAktiv Then
            me_setzeTon(0)
        Else
            me_setzeTon()
            TonDatei.sm_playTon(mp_Ton)
        End If
    End Sub
    ' Formmethoden
    Private Sub TonPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        me_clicked()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        me_clicked()
    End Sub
End Class
