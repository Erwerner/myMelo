Public Class TaktEinheitEingabe
    Private m_EinheitIndex As Integer
    Private m_TonPanel(34) As TonEingabe
    Private m_aktivTonpanel As TonEingabe

    Public Sub New()
        Me.New(1)
    End Sub
    Public Property mp_aktivTonpanel As TonEingabe
        Set(ByVal value As TonEingabe)
            m_aktivTonpanel = value
        End Set
        Get
            Dim l_return As TonEingabe
            If Not m_aktivTonpanel Is Nothing Then
                If m_aktivTonpanel.mp_istAktiv Then
                    l_return = m_aktivTonpanel
                Else
                    l_return = Nothing
                End If
            Else
                l_return = Nothing
            End If

            Return l_return
        End Get
    End Property
    Public ReadOnly Property mp_Takteinheit As Takteinheit
        Get
            Return TaktEingabe.sp_EingabeTakt.mp_TaktEinheit(m_EinheitIndex)
        End Get
    End Property

    Public Sub New(ByVal p_EinheitIndex As Integer)
        InitializeComponent()

        Dim lz_TonPanel As Integer
        Dim lz_oktave As Integer
        Dim lz_leiterton As Integer

        m_EinheitIndex = p_EinheitIndex

        For lz_oktave = 0 To 4
            For lz_leiterton = 0 To 6
                m_TonPanel(lz_TonPanel) = New TonEingabe(p_EinheitIndex, lz_oktave, lz_leiterton)
                Me.Controls.Add(m_TonPanel(lz_TonPanel))
                gAdd(lz_TonPanel)
            Next
        Next

        Me.Size = New System.Drawing.Size(globDes_BreiteTonCursor * 35, globDes_BreiteTonCursor)

        Me.Location = New System.Drawing.Point(1, globDes_BreiteTonCursor * m_EinheitIndex)
        Me.Name = "TakteinheitEinheit"
    End Sub
    Public Sub me_clear()
            If Not m_aktivTonpanel Is Nothing Then
                m_aktivTonpanel.me_deaktivieren()
            End If
    End Sub
    Public Sub me_setMelodieton()
        Dim l_Note As Note
        l_Note = mp_Takteinheit.mp_Melodienote
        If Not l_Note.mp_Länge = 0 Then
            m_TonPanel(l_Note.mp_TonIndex).me_aktivieren()
        Else
            me_clear()
        End If
    End Sub
    Public Sub me_setTakt()
        For Each lz_TonPanel In m_TonPanel
            lz_TonPanel.me_setAkkord()
        Next
    End Sub
End Class
