Public Class TaktEingabe 
    Private Shared m_EingabeTaktIndex As Integer
    Private Shared m_EingabeAkkordtonfunktion_byLeiterton(6) As e_Akkordtonfunktion
    Private Shared m_EingabeAkkord As Akkord
    Private m_TaktEinheitEingabe(7) As TaktEinheitEingabe

    ' SHARED
    Public Shared ReadOnly Property sp_EingabeTakt As Takt
        Get
            Return Takt.sp_Takt_absolut(m_EingabeTaktIndex)
        End Get
    End Property
    Public Shared ReadOnly Property sp_EingabeAkkord As Akkord
        Get
            Return m_EingabeAkkord
        End Get
    End Property
    Public Shared Property sp_EingabeTaktIndex As Integer
        Get
            Return m_EingabeTaktIndex
        End Get
        Set(ByVal value As Integer)
            m_EingabeTaktIndex = value
            m_EingabeAkkord = Takt.sp_Takt_absolut(value).mp_Akkord
            Form1.TaktEingabe1.me_clear()
        End Set
    End Property
    Public Shared ReadOnly Property sp_EingabeAkkordtonfunktion_byLeiterton(ByVal p_value As Integer) As e_Akkordtonfunktion
        Get
            Return m_EingabeAkkordtonfunktion_byLeiterton(p_value)
        End Get
    End Property
    ' READONLY 
    Public ReadOnly Property mp_TaktEinheitEingabe(ByVal p_value As Integer) As TaktEinheitEingabe
        Get
            Return m_TaktEinheitEingabe(p_value)
        End Get
    End Property
    ' KONSTRUKTOR
    Sub New()
        InitializeComponent()


        Me.Size = New System.Drawing.Size(globDes_BreiteTonCursor * 35, globDes_BreiteTonCursor * 8)
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle

        m_TaktEinheitEingabe(0) = New TaktEinheitEingabe(0)
        m_TaktEinheitEingabe(1) = New TaktEinheitEingabe(1)
        m_TaktEinheitEingabe(2) = New TaktEinheitEingabe(2)
        m_TaktEinheitEingabe(3) = New TaktEinheitEingabe(3)
        m_TaktEinheitEingabe(4) = New TaktEinheitEingabe(4)
        m_TaktEinheitEingabe(5) = New TaktEinheitEingabe(5)
        m_TaktEinheitEingabe(6) = New TaktEinheitEingabe(6)
        m_TaktEinheitEingabe(7) = New TaktEinheitEingabe(7)

        Me.Controls.Add(m_TaktEinheitEingabe(0))
        Me.Controls.Add(m_TaktEinheitEingabe(1))
        Me.Controls.Add(m_TaktEinheitEingabe(2))
        Me.Controls.Add(m_TaktEinheitEingabe(3))
        Me.Controls.Add(m_TaktEinheitEingabe(4))
        Me.Controls.Add(m_TaktEinheitEingabe(5))
        Me.Controls.Add(m_TaktEinheitEingabe(6))
        Me.Controls.Add(m_TaktEinheitEingabe(7)) 

    End Sub
    ' GET INSTANZ
    Public Shared Function getInstanz() As TaktEingabe
        Return Form1.TaktEingabe1
    End Function

    ' STATIC
    Public Shared Sub sm_setTakt(ByVal p_taktIndex As Integer)
        Try
            gp_TaktAnzeige(sp_EingabeTaktIndex).me_Melodie_aktualisieren()
        Catch ex As Exception

        End Try
        If p_taktIndex = m_EingabeTaktIndex Then Exit Sub
        Form1.TaktEingabe1.me_setTaktIndex(p_taktIndex)
    End Sub
    Public Shared Sub sm_initEingabe()
        Form1.TaktEingabe1.Visible = False
        m_EingabeTaktIndex = -1
    End Sub
    Public Shared Sub sm_Eingabe_aktualisiereTakt()
        Try
            m_EingabeAkkord = Takt.sp_Takt_absolut(m_EingabeTaktIndex).mp_Akkord
            For lz_Leiterton = 0 To 6
                m_EingabeAkkordtonfunktion_byLeiterton(lz_Leiterton) = e_Akkordtonfunktion.nichts
            Next
            m_EingabeAkkordtonfunktion_byLeiterton(g_TonLeiterFunktion(m_EingabeAkkord.mp_Grundton.mp_TonEnum)) = e_Akkordtonfunktion.Grundton
            m_EingabeAkkordtonfunktion_byLeiterton(g_TonLeiterFunktion(m_EingabeAkkord.mp_Ton(1).mp_TonEnum)) = e_Akkordtonfunktion.Ton2
            m_EingabeAkkordtonfunktion_byLeiterton(g_TonLeiterFunktion(m_EingabeAkkord.mp_Ton(2).mp_TonEnum)) = e_Akkordtonfunktion.Ton3
            Form1.TaktEingabe1.me_ladeTakt()
            TonKopf.sm_aktualisieren()
        Catch ex As Exception
            sm_setTakt(0)
        End Try
    End Sub
    ' PUBLIC
    Public Sub me_clear()
        Dim lz_EinheitIndex As Integer
        For lz_EinheitIndex = 0 To 7
            m_TaktEinheitEingabe(lz_EinheitIndex).me_clear()
        Next
    End Sub
    Public Sub me_ladeTakt()
        For Each lz_TaktEinheitEingabe In m_TaktEinheitEingabe
            lz_TaktEinheitEingabe.me_setTakt()
            lz_TaktEinheitEingabe.me_setMelodieton()
        Next
    End Sub
    Public Sub me_setPosition()
        Try

            With gp_TaktAnzeige(TaktEingabe.sp_EingabeTaktIndex).Location
                Me.Location = New System.Drawing.Point(.X + globDes_BreiteTaktinfo, .Y)
            End With
        Catch ex As Exception

        End Try
    End Sub
    Public Sub me_setTaktIndex(ByVal p_TaktIndex As Integer)
        Dim l_EingabeTakt_StartAtPlayStep As Integer
        Me.Visible = False
        sp_EingabeTaktIndex = p_TaktIndex

        ' Hinweis im Player setzen 
        l_EingabeTakt_StartAtPlayStep = Takt.sp_Takt_absolut(p_TaktIndex).mp_relativIndex * 8  'gPlayTaktIndex_byTaktIndex_int(p_TaktIndex) * 8
        sc_Player.sp_EingabeTakt_StartAtPlayStep = l_EingabeTakt_StartAtPlayStep

        me_setPosition()
        sm_Eingabe_aktualisiereTakt()
        Me.Visible = True
    End Sub


End Class
