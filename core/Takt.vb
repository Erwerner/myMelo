Public Class Takt
    Private Shared m_Auftakt As Takt
    Private Shared m_Schlussakkord As Takt

    Private m_TaktIndex As Integer
    Private m_Takteinheit(7) As Takteinheit

    ' SHARED 
    Public Shared ReadOnly Property sp_Takt_relativ(ByVal p_index As Integer) As Takt 'nur für Takteingabe bei Songinit
        Get
            Dim l_startTaktIndex As Integer
            Dim l_TaktIndex As Integer
            l_startTaktIndex = global_BoolToInt(gv_Song.mp_hatAuftakt) * -1
            l_TaktIndex = p_index + l_startTaktIndex
            Try
                Return sp_Takt_absolut(l_TaktIndex)
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public Shared ReadOnly Property sp_Takt_absolut(ByVal p_value As e_Takttyp) As Takt
        Get
            Try
                Select Case p_value
                    Case e_Takttyp.Auftakt
                        Return m_Auftakt
                    Case e_Takttyp.Schlussakkord
                        Return m_Schlussakkord
                    Case arrIx(gv_Song.mp_anzahlHauptTakte) + 1
                        If Not gv_TakteHinzufügen Then
                            Return m_Schlussakkord
                        Else
                            Return g_Takt(p_value)
                        End If
                    Case Else
                        Return g_Takt(p_value)
                End Select
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    ' READONLY
    Public ReadOnly Property mp_taktBezeichnung As String
        Get
            Select Case m_TaktIndex
                Case e_Takttyp.Auftakt
                    Return "Auftakt"
                Case e_Takttyp.Schlussakkord
                    Return "Schlusstakt"
                Case Else
                    Return "Takt " & m_TaktIndex + 1
            End Select
        End Get
    End Property
    Public ReadOnly Property mp_TaktIndex As Integer
        Get
            Return m_TaktIndex
        End Get
    End Property
    Public ReadOnly Property mp_Akkord As Akkord
        Get
            Return (m_Takteinheit(0).mp_Akkord)
        End Get
    End Property
    Public ReadOnly Property mp_TaktEinheit(ByVal p_TaktEinheitIndex As Integer) As Takteinheit
        Get
            Return m_Takteinheit(p_TaktEinheitIndex)
        End Get
    End Property
    Public ReadOnly Property mp_relativIndex As Integer
        Get
            If Not m_TaktIndex = e_Takttyp.Schlussakkord Then
                Return m_TaktIndex + global_BoolToInt(gv_Song.mp_hatAuftakt)
            Else
                Return gv_Song.mp_anzahlAktivTakte - 1
            End If
        End Get
    End Property 
        'Public ReadOnly Property mp_Akkord_wirdUnterbrochen(Optional ByVal p_step As Integer = -1) As Boolean
        '    Get
        '        Dim l_Akkord As Akkord
        '        Dim l_return As Boolean
        '        Dim l_Takteinheitindex_Start As Integer
        '        Dim l_Takteinheitindex_Ende As Integer

        '        If p_step = -1 Then
        '            l_Takteinheitindex_Start = 0
        '            l_Takteinheitindex_Ende = c_MinEinheit
        '        Else
        '            l_Takteinheitindex_Start = p_step
        '            l_Takteinheitindex_Ende = p_step
        '        End If

        '        l_Akkord = mp_Akkord
        '        For lz_takteinheitindex = l_Takteinheitindex_Start To l_Takteinheitindex_Ende
        '            If l_Akkord.me_Akkord_hatTon(m_Takteinheit(lz_takteinheitindex).mp_Melodienote) Then
        '                l_return = True
        '                Exit For
        '            End If
        '        Next
        '        Return l_return
        '    End Get
        'End Property

        ' KONSTRUKTOR
    Sub New(ByVal p_Index As Integer, ByVal p_Akkord As Akkord)
        Dim lz_TaktEinheitIndex As Integer
        Dim l_akkord As Akkord
         
        m_TaktIndex = p_Index
        For lz_TaktEinheitIndex = 0 To 7
            l_akkord = New Akkord(p_Akkord.mp_Grundton.mp_TonEnum, p_Akkord.mp_Geschlecht, p_Akkord.mp_Grundton.mp_Oktave)
            m_Takteinheit(lz_TaktEinheitIndex) = New Takteinheit(lz_TaktEinheitIndex, l_akkord)
        Next
    End Sub
    ' SHARED
    Public Shared Function get_alleAktivTakte_asArray() As Takt()
        Dim l_return(arrIx(gv_Song.mp_anzahlAktivTakte)) As Takt
        For lz_TaktIndex = 0 To arrIx(gv_Song.mp_anzahlAktivTakte)
            l_return(lz_TaktIndex) = sp_Takt_relativ(lz_TaktIndex)
        Next
        Return l_return
    End Function
    Public Shared Function get_absolut_alleTakte_asArray() As Takt()
        Dim l_return(arrIx(gv_Song.mp_anzahlHauptTakte + 2)) As Takt
        For lz_TaktIndex = -1 To arrIx(gv_Song.mp_anzahlHauptTakte + 1)
            l_return(lz_TaktIndex + 1) = sp_Takt_absolut(lz_TaktIndex)
        Next
        Return l_return
    End Function
    Public Shared Sub sm_initAuftSchlss()
        'Auftakt
        m_Auftakt = New Takt(e_Takttyp.Auftakt, cp_Akkord(e_TonEnum.C, e_Tongeschlecht.Dur))
        'Schlussakkord
        m_Schlussakkord = New Takt(e_Takttyp.Schlussakkord, cp_Akkord(e_TonEnum.C, e_Tongeschlecht.Dur))
    End Sub
    ' PUBLIC
    Public Sub me_Tonartwechsel()
        For Each l_TE In m_Takteinheit
            l_TE.me_Tonartwechsel()
        Next
    End Sub
    Public Sub me_akkordwechsel(ByVal p_akkord As Akkord)
        m_Takteinheit(0).me_akkordwechsel(p_akkord)
        TaktEingabe.sm_Eingabe_aktualisiereTakt()
    End Sub
    Public Sub me_reset()
        For Each lz_TA In m_Takteinheit
            lz_TA.me_setMelodienote_aus()
        Next
    End Sub
    Public Function get_alleTakteinheiten() As Takteinheit()
        Return m_Takteinheit
    End Function
    'Public Function get_Akkord_unterbrechungen() As Boolean(,)
    '    Dim l_Unterbrechung(7, 3) As Boolean
    '    Dim l_akkord As Akkord

    '    l_akkord = mp_Akkord

    '    For lz_Takteinheitindex = 0 To c_MinEinheit
    '        With m_Takteinheit(lz_Takteinheitindex).mp_Melodienote
    '            For lz_TonIndex = 0 To 2
    '                l_Unterbrechung(lz_Takteinheitindex, lz_TonIndex) = .me_VergleicheTon(l_akkord.mp_Ton(lz_TonIndex))
    '            Next
    '        End With
    '    Next
    '    Return l_Unterbrechung
    'End Function
End Class
