Public Class TakteinheitAnzeige
    Public m_EinheitIndex As Integer
    Public m_Taktindex As Integer

    Private m_Toncursor As Toncursor
    'Public myAkkordcursor(2) As Toncursor
    'Public myTonTrenneroben(7) As VariantType

    Public ReadOnly Property mp_Parent As Taktanzeige
        Get
            Select Case m_Taktindex
                Case e_Takttyp.Auftakt
                    Return gp_TaktAnzeige(e_Takttyp.Auftakt)
                Case e_Takttyp.Schlussakkord
                    Return gp_TaktAnzeige(e_Takttyp.Schlussakkord)
                Case Else
                    Return g_Taktanzeige(m_Taktindex)
            End Select
        End Get
    End Property
    Public ReadOnly Property Melodienote As Note
        Get
            Return mp_Parent.mp_Takt.mp_TaktEinheit(m_EinheitIndex).mp_Melodienote
        End Get
    End Property
    'Private ReadOnly Property mp_Klickanzeige As KlickAnzeige
    '    Get
    '        Return mp_Parent.mp_Klickanzeige
    '    End Get
    'End Property
    Public ReadOnly Property mp_TonCursor As Toncursor
        Get
            Return m_Toncursor
        End Get
    End Property

    Sub New(ByVal p_EinheitIndex As Integer, ByVal p_Taktindex As Integer)
        InitializeComponent(p_Taktindex, p_EinheitIndex)

        m_EinheitIndex = p_EinheitIndex
        m_Taktindex = p_Taktindex

        m_Toncursor = Me.Toncursor2
        m_Toncursor.Top = 0
        Me.Size = New System.Drawing.Size(globDes_BreiteTonCursor * 35, globDes_BreiteTonCursor)

        Me.Location = New System.Drawing.Point(globDes_BreiteTaktinfo, globDes_BreiteTonCursor * m_EinheitIndex)
        Me.Name = "TakteinheitAnzeige1"
    End Sub

    Public Sub Melodie_aktualisieren()
        Dim lv_Note As Note
        lv_Note = Melodienote
        With lv_Note
            If .mp_Länge > 0 Then
                m_Toncursor.Left = (.mp_Oktave) * globDes_BreiteTonCursor * 7 _
                                     + (.mp_Leiterton) * globDes_BreiteTonCursor
                'm_Toncursor.Left = globDes_BreiteTaktinfo + globDes_BreiteTonCursor * Ton.sm_TonIndex_int(.mp_Oktave, .mp_Leiterton)
                m_Toncursor.einblenden()
            Else
                m_Toncursor.ausblenden()
            End If
        End With
    End Sub

    ' Formmethoden

    Private Sub TakteinheitAnzeige_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        TaktEingabe.sm_setTakt(m_Taktindex)
    End Sub

    Private Sub TakteinheitAnzeige_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        sc_KlickAnzeige.me_mouseenter(mp_Parent)
    End Sub
End Class
