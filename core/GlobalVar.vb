'%NK

Module GlobalVar  
    ' Taktvariablen
    Private m_Auftaktanzeige As Taktanzeige
    Private m_Schlussakkordanzeige As Taktanzeige
    Public g_Taktanzeige(3) As Taktanzeige
     
    Public g_Leiterton(6) As e_TonEnum
    Public g_TonLeiterFunktion(11) As Integer 

    Public gv_Song As cl_Song
     
    Public ReadOnly Property gp_LeiterAkkord(ByVal p_Akkordfunktion As e_Akkordfunktion) As Akkord
        Get
            Return cp_Akkord(g_Leiterton(p_Akkordfunktion), c_LeiterAkkordgeschlecht(p_Akkordfunktion))
        End Get
    End Property
    Public ReadOnly Property gp_Entwickung As Boolean
        Get
            Return Application.StartupPath = "C:\Dokumente und Einstellungen\Erik\Desktop\myMelo\myMelo\bin\Debug"
        End Get
    End Property

    Public ReadOnly Property gp_TaktAnzeige(ByVal p_value As e_Takttyp) As Taktanzeige
        Get
            Try

                Select Case p_value
                    Case e_Takttyp.Auftakt
                        Return m_Auftaktanzeige
                    Case e_Takttyp.Schlussakkord
                        Return m_Schlussakkordanzeige
                    Case Else
                        Return g_Taktanzeige(p_value)
                End Select
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Sub gm_setLeiterTöne()
        Dim z As Integer
        For Each xLT In g_Leiterton
            g_Leiterton(z) = TonErmitteln_TonEnum(c_Halbtonhöhe(z), gv_Song.mp_Tonart)
            z = z + 1
        Next
    End Sub
    Public Sub gm_setTonLeiterFunktionen()
        Dim l_aktTon As e_TonEnum
        Dim lv_Tonart As e_TonEnum
        Dim lz_TonLeiterFunktion As Integer
        For Each xLT In g_TonLeiterFunktion
            g_TonLeiterFunktion(lz_TonLeiterFunktion) = -1                                ' alle Töne auf -1 setzen
            lz_TonLeiterFunktion = lz_TonLeiterFunktion + 1
        Next
        lv_Tonart = gv_Song.mp_Tonart
        l_aktTon = lv_Tonart 'TonÄndern(l_Ton, 0, glob_Tonart)                        ' Grundton ermitteln
        g_TonLeiterFunktion(l_aktTon) = e_Akkordfunktion.Tonika            ' Grundton auf tonika setzen
        l_aktTon = TonErmitteln_TonEnum(2, lv_Tonart)
        g_TonLeiterFunktion(l_aktTon) = e_Akkordfunktion.Subdominantparallele
        l_aktTon = TonErmitteln_TonEnum(4, lv_Tonart)
        g_TonLeiterFunktion(l_aktTon) = e_Akkordfunktion.Dominantparallele
        l_aktTon = TonErmitteln_TonEnum(5, lv_Tonart)
        g_TonLeiterFunktion(l_aktTon) = e_Akkordfunktion.Subdominante
        l_aktTon = TonErmitteln_TonEnum(7, lv_Tonart)
        g_TonLeiterFunktion(l_aktTon) = e_Akkordfunktion.Dominante
        l_aktTon = TonErmitteln_TonEnum(9, lv_Tonart)
        g_TonLeiterFunktion(l_aktTon) = e_Akkordfunktion.Tonikaparallele
        l_aktTon = TonErmitteln_TonEnum(11, lv_Tonart)
        g_TonLeiterFunktion(l_aktTon) = 6
    End Sub
    Public Sub gm_initAuftSchlss()
        Takt.sm_initAuftSchlss()
        'Auftakt
        'm_Auftakt = New Takt(e_Takttyp.Auftakt, cp_Akkord(e_TonEnum.C, e_Tongeschlecht.Dur))
        m_Auftaktanzeige = New Taktanzeige(e_Takttyp.Auftakt)
        m_Auftaktanzeige.me_inForm1Einbinden()
        'Schlussakkord
        'm_Schlussakkord = New Takt(e_Takttyp.Schlussakkord, cp_Akkord(e_TonEnum.C, e_Tongeschlecht.Dur))
        m_Schlussakkordanzeige = New Taktanzeige(e_Takttyp.Schlussakkord)
        m_Schlussakkordanzeige.me_inForm1Einbinden()
    End Sub
End Module
