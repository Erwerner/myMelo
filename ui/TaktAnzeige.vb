Public Class Taktanzeige
    Private m_Index As e_Takttyp
    Private m_Takteinheitanzeige(7) As TakteinheitAnzeige
     
    Private m_istAuftakt_rdnt As Boolean
    Private m_istSchlussakkord_rdnt As Boolean

    Private m_Takt_wirdinitialisiert As Boolean 

    ' SHARED
    Public Shared ReadOnly Property sp_PlayTaktAnzeige(ByVal p_PlayTaktIndex As Integer) As Taktanzeige
        Get
            Dim l_DifAuftakt As Integer
            Dim l_Taktindex As Integer
            With gv_Song
                l_DifAuftakt = global_BoolToInt(.mp_hatAuftakt)
                If Not (p_PlayTaktIndex = arrIx(.mp_anzahlAktivTakte) And .mp_hatSchlussakkord) Then
                    l_Taktindex = p_PlayTaktIndex - l_DifAuftakt
                Else
                    l_Taktindex = e_Takttyp.Schlussakkord
                End If
            End With 
            Return gp_TaktAnzeige(l_Taktindex)
        End Get
    End Property
    ' READONLY
    Public ReadOnly Property mp_istAuftakt As Boolean
        Get
            Return m_istAuftakt_rdnt
        End Get
    End Property
    Public ReadOnly Property mp_istSchlussakkord As Boolean
        Get
            Return m_istSchlussakkord_rdnt
        End Get
    End Property
    Public ReadOnly Property mp_Akkord As Akkord
        Get
            Return Takt.sp_Takt_absolut(m_Index).mp_Akkord
        End Get
    End Property
    Public ReadOnly Property mp_Takt As Takt
        Get
            Return Takt.sp_Takt_absolut(m_Index)
        End Get
    End Property
    Public ReadOnly Property mp_Takteinheitanzeige(ByVal p_Einheitindex As Integer) As TakteinheitAnzeige
        Get
            Return m_Takteinheitanzeige(p_Einheitindex)
        End Get
    End Property

    ' KONSTRUKTOR
    Sub New(ByVal p_TaktIndex As Integer)
        InitializeComponent()

        'Me.Anchor = AnchorStyles.Top

        m_Index = p_TaktIndex
        m_istAuftakt_rdnt = p_TaktIndex = e_Takttyp.Auftakt
        m_istSchlussakkord_rdnt = p_TaktIndex = e_Takttyp.Schlussakkord

        Me.lblTaktNr.Text = mp_Takt.mp_taktBezeichnung

        If m_istAuftakt_rdnt Or m_istSchlussakkord_rdnt Then
            Me.pnlTaktinfo.BackColor = System.Drawing.Color.LightGray
            'Me.cboAkkordAuswahl.Enabled = False
        End If 
         
            Me.Size = New System.Drawing.Size(globDes_BreiteTaktinfo + globDes_BreiteTonCursor * 35, globDes_BreiteTonCursor * 8)
            Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
         

            Position_setzen()

            Me.pnlTaktinfo.Size = New System.Drawing.Size(globDes_BreiteTaktinfo + globDes_BreiteTonCursor * 35, globDes_BreiteTonCursor * 8)
            'Me.brd_rand.Size = Me.pnlTaktinfo.Size

            m_Takteinheitanzeige(0) = New TakteinheitAnzeige(0, m_Index)
            m_Takteinheitanzeige(1) = New TakteinheitAnzeige(1, m_Index)
            m_Takteinheitanzeige(2) = New TakteinheitAnzeige(2, m_Index)
            m_Takteinheitanzeige(3) = New TakteinheitAnzeige(3, m_Index)
            m_Takteinheitanzeige(4) = New TakteinheitAnzeige(4, m_Index)
            m_Takteinheitanzeige(5) = New TakteinheitAnzeige(5, m_Index)
            m_Takteinheitanzeige(6) = New TakteinheitAnzeige(6, m_Index)
            m_Takteinheitanzeige(7) = New TakteinheitAnzeige(7, m_Index)


            Me.pnlTaktinfo.Controls.Add(m_Takteinheitanzeige(0))
            Me.pnlTaktinfo.Controls.Add(m_Takteinheitanzeige(1))
            Me.pnlTaktinfo.Controls.Add(m_Takteinheitanzeige(2))
            Me.pnlTaktinfo.Controls.Add(m_Takteinheitanzeige(3))
            Me.pnlTaktinfo.Controls.Add(m_Takteinheitanzeige(4))
            Me.pnlTaktinfo.Controls.Add(m_Takteinheitanzeige(5))
            Me.pnlTaktinfo.Controls.Add(m_Takteinheitanzeige(6))
            Me.pnlTaktinfo.Controls.Add(m_Takteinheitanzeige(7))

            me_initCboAkkordauswahl()
            me_Taktinfos_aktualisieren()

            Me.lbl_grundton.BackColor = c_Color_Grundton
            Me.lbl_ton2.BackColor = c_Color_Ton
            Me.lbl_ton3.BackColor = c_Color_Ton

            Me.pnl_Taktinfo.Width = globDes_BreiteTaktinfo
    End Sub

    ' STATIC
    Public Shared Sub sm_AnzeigeAktualisieren()
        gp_TaktAnzeige(e_Takttyp.Auftakt).me_Melodie_aktualisieren()
        gp_TaktAnzeige(e_Takttyp.Schlussakkord).me_Melodie_aktualisieren()
        'Taktanzeige
        For Each ta In g_Taktanzeige
            ta.me_Melodie_aktualisieren()
        Next

        TaktEingabe.sm_Eingabe_aktualisiereTakt()
    End Sub
    ' PUBLIC
    Public Sub Position_setzen()
        If m_istAuftakt_rdnt Then
            Me.Location = New System.Drawing.Point(1, 0)
        End If
        If m_istSchlussakkord_rdnt Then
            Me.Location = New System.Drawing.Point(1, HöheHauptTakteEnde)
        End If
        If m_Index >= 0 Then
            Me.Location = New System.Drawing.Point(1, globDes_BreiteTonCursor * 8 * (m_Index + global_BoolToInt(gv_Song.mp_hatAuftakt)))
        End If
    End Sub
    Public Sub me_Melodie_aktualisieren()
        For Each xTEA In m_Takteinheitanzeige
            xTEA.Melodie_aktualisieren()
        Next
    End Sub
    Public Sub Tonartwechsel()
        me_initCboAkkordauswahl()
        me_Taktinfos_aktualisieren()
    End Sub
    Public Sub me_Taktinfos_aktualisieren()
        m_Takt_wirdinitialisiert = True
        Me.lblAkkordfunktion.Text = c_StrAkkordfunktion(Me.mp_Akkord.mp_Akkordfunktion)
        Me.cboAkkordAuswahl.SelectedIndex = mp_Akkord.mp_Akkordfunktion

        Me.lbl_grundton.Text = mp_Akkord.mp_Grundton.mp_StrName
        Me.lbl_ton2.Text = mp_Akkord.mp_Ton(1).mp_StrName
        Me.lbl_ton3.Text = mp_Akkord.mp_Ton(2).mp_StrName


        m_Takt_wirdinitialisiert = False
    End Sub
    Public Sub me_inForm1Einbinden()
        Form1.pnlSequenzer.AutoScrollPosition = New System.Drawing.Point(0, 0)
        Form1.pnlSequenzer.Controls.Add(Me)
    End Sub
    ' PRIVATE
    Private Sub me_initCboAkkordauswahl()
        Dim lz_Leiterton As Integer

        m_Takt_wirdinitialisiert = True

        Me.cboAkkordAuswahl.Items.Clear()
        For lz_Leiterton = 0 To 5
            Me.cboAkkordAuswahl.Items.Add( _
                c_StrTonName(g_Leiterton(lz_Leiterton)) _
                & " " & c_strTonGeschlecht(c_LeiterAkkordgeschlecht(lz_Leiterton)) _
            )
        Next
        m_Takt_wirdinitialisiert = False
    End Sub 

    ' CONTROLMETHODEN
    Private Sub pnlTaktinfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlTaktinfo.Click
        TaktEingabe.sm_setTakt(m_Index)
    End Sub
    Private Sub brd_rand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub brd_rand_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        sc_KlickAnzeige.me_mouseenter(Me)
    End Sub
    Private Sub cboAkkordAuswahl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAkkordAuswahl.Click
        TaktEingabe.sm_setTakt(m_Index)
    End Sub
    Private Sub cboAkkordAuswahl_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAkkordAuswahl.SelectedValueChanged
        Dim l_Akkordfunktion As e_Akkordfunktion

        l_Akkordfunktion = Me.cboAkkordAuswahl.SelectedIndex
        'Me.cboAkkordAuswahl.BackColor = c_color_Akkordfunktion(l_Akkordfunktion)

        If Not m_Takt_wirdinitialisiert Then
            mp_Takt.me_akkordwechsel(gp_LeiterAkkord(l_Akkordfunktion))
        End If

        me_Taktinfos_aktualisieren()
    End Sub
    Private Sub cboAkkordAuswahl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAkkordAuswahl.SelectedIndexChanged
        Dim l_TaktBezeichnung As String
        Dim l_Tonika_Name As String
        Dim l_Tonikaparallele_Name As String
        If m_Index <= 0 Then
            If Not (cboAkkordAuswahl.SelectedIndex = 0 _
                Or cboAkkordAuswahl.SelectedIndex = 5) Then
                l_Tonika_Name = gp_LeiterAkkord(e_Akkordfunktion.Tonika).mp_Bezeichnung
                l_Tonikaparallele_Name = gp_LeiterAkkord(e_Akkordfunktion.Tonikaparallele).mp_Bezeichnung
                l_TaktBezeichnung = IIf(m_Index = 0, "erster Takt", mp_Takt.mp_taktBezeichnung)
                MsgBox("Als " & l_TaktBezeichnung & " sollte die Tonika (" & l_Tonika_Name & ") oder die Tonikaparallele (" & l_Tonikaparallele_Name & ") gewählt werden.")
            End If
        End If
    End Sub
End Class
