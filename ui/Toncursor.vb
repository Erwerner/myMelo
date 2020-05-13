Public Class Toncursor

    Private m_Taktindex As Integer
    Private Shared m_PlayCursor As New Toncursor(-3, -1)
    Public m_Takteinheitindex As Integer

    Private ReadOnly Property mp_TaktAnzeige As Taktanzeige
        Get
            Return gp_TaktAnzeige(m_Taktindex)
        End Get
    End Property
    'Public Sub New()
    '    Me.New(-3, -1)
    'End Sub
    Public Sub New(ByVal p_Taktindex As Integer, ByVal p_TaktEinheitindex As Integer)
        InitializeComponent()
        Me.BackColor = c_Color_Note
        m_Taktindex = p_Taktindex
        m_Takteinheitindex = p_TaktEinheitindex
        Me.Top = -1
    End Sub

    Public Sub einblenden()
        Me.Visible = True
    End Sub
    Public Sub ausblenden()
        Me.Visible = False
    End Sub

    Private Sub Toncursor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        me_clicked()
    End Sub
    Private Sub TonPanel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Me.ToolTip1.Show(Takt.sp_Takt_absolut(m_Taktindex).mp_TaktEinheit(m_Takteinheitindex).mp_Melodienote.mp_StrName, Me, 6000)
        sc_KlickAnzeige.me_mouseenter(mp_TaktAnzeige)
    End Sub

    'Public Shared Sub sm_play(ByVal p_StepIndex As Integer)
    '    sm_playAus()
    '    m_PlayCursor = gTakteinheitAnzeige_byStep_integer(p_StepIndex).mp_TonCursor
    '    m_PlayCursor.BackColor = c_Color_Play
    'End Sub
    'Public Shared Sub sm_playAus()
    '    m_PlayCursor.BackColor = c_Color_Note
    'End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        me_clicked()
    End Sub
    Private Sub me_clicked()
        TaktEingabe.sm_setTakt(m_Taktindex)
        TaktEingabe.sp_EingabeTakt.mp_TaktEinheit(m_Takteinheitindex).me_setMelodienote_aus()
        TaktEingabe.sm_Eingabe_aktualisiereTakt()
    End Sub
End Class
