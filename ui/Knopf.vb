Public Class Knopf
    Public Enum e_Knopftyp
        ktPlay
        ktStop
        ktTonartHoch
        ktTonartRunter
        kt4Takt
    End Enum

    Private m_pushed As Boolean
    Private m_postopx As Integer
    Private m_postopy As Integer
    Private m_poslabelx As Integer
    Private m_Knopftyp As e_Knopftyp
    Private m_poslabely As Integer

    Public Sub me_init(ByVal p_Text As String, ByVal p_KnopfTyp As e_Knopftyp)
        Me.Label1.Text = p_Text
        m_Knopftyp = p_KnopfTyp
    End Sub
    Private WriteOnly Property mp_pushed As Boolean
        Set(ByVal value As Boolean)
            Dim sender As New Object
            Dim e As New System.EventArgs
            m_pushed = value
            Select Case value
                Case True
                    Me.knopftop.Location = New System.Drawing.Point(m_postopx + 1, m_postopy + 3)
                    Me.Label1.Location = New System.Drawing.Point(m_poslabelx + 1, m_poslabely + 3)
                Case False
                    Me.knopftop.Location = New System.Drawing.Point(m_postopx, m_postopy)
                    Me.Label1.Location = New System.Drawing.Point(m_poslabelx, m_poslabely)
            End Select
        End Set
    End Property
    Public Sub New()
        InitializeComponent()

        Me.pnlBack.Size = Me.Size
        Me.Size = New System.Drawing.Size(Me.Width, c_size_Kontrollleiste - 6)
        Me.Label1.Location = New System.Drawing.Point(Me.Label1.Location.X, 25)
        m_postopx = Me.knopftop.Location.X
        m_postopy = Me.knopftop.Location.Y
        m_poslabelx = Me.Label1.Location.X + 1
        m_poslabely = Me.Label1.Location.Y - 4
    End Sub

    Private Sub doFunction() 
        cl_SoundDatei.play(e_SoundDatei.Knopf)
        Select Case m_Knopftyp
            Case e_Knopftyp.ktPlay
                sc_Player.factory.me_startplayer()
            Case e_Knopftyp.ktStop
                sc_Player.factory.me_PlayerStop()
            Case e_Knopftyp.ktTonartHoch
                Dim l_Ton As New Ton(gv_Song.mp_Tonart)
                gTonartwechsel_Tonart(TonÄndern_TonEnum(l_Ton, 1))
            Case e_Knopftyp.ktTonartRunter
                Dim lTon As New Ton(gv_Song.mp_Tonart)
                gTonartwechsel_Tonart(TonÄndern_TonEnum(lTon, -1))
            Case e_Knopftyp.kt4Takt
                global_Takte_Hinzufügen(c_AkkordfunktionKadenz)
        End Select
    End Sub


    Private Sub knopftop_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles knopftop.MouseDown, RectangleShape1.MouseDown
        mp_pushed = True
    End Sub

    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        mp_pushed = True
    End Sub

    Private Sub knopftop_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RectangleShape1.MouseUp, knopftop.MouseUp
        doFunction()
        mp_pushed = False
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        doFunction()
        mp_pushed = False
    End Sub

    Private Sub knopfschatten_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles knopfschatten.MouseUp
        mp_pushed = False
    End Sub

    Private Sub pnlBack_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBack.MouseUp
        mp_pushed = False
    End Sub
End Class
