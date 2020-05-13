Public Class TonKopf

    Private Shared sv_Index As Integer
    Private Shared sv_tonkopf(42) As TonKopf
    Private m_tonindex As Integer

    Private Sub New(ByVal p_tonindex As e_TonEnum)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        'Me.Size = New System.Drawing.Size(globDes_BreiteTonCursor, 22) in Form 1 gesetzt
        m_tonindex = p_tonindex
        me_setText()

    End Sub

    Public Shared Function factory(ByVal p_tonindex As Integer) As TonKopf
        sv_tonkopf(sv_Index) = New TonKopf(p_tonindex)
        factory = sv_tonkopf(sv_Index)
        gAdd(sv_Index)
    End Function

    Private Sub me_setText()
        Dim lv_TonBezeichnung As String
        Dim lv_Vorzeichen As Char
        Dim lv_TonName As Char
        lv_TonBezeichnung = c_StrTonName(Ton.sm_TonEnum_byTonindex_Tonenum(m_tonindex))
        'lv_Vorzeichen = IIf(Mid(lv_TonBezeichnung, 3, 1) = "/", "#", " ") '%ToDo neue Klasse für Tonenums
        lv_Vorzeichen = IIf(Len(lv_TonBezeichnung) > 1, "#", " ") '%ToDo neue Klasse für Tonenums
        lv_TonName = Mid(lv_TonBezeichnung, 1, 1)
        Me.lbl_TonKopfZeile1.Text = lv_Vorzeichen & vbCrLf & lv_TonName

    End Sub

    Public Shared Sub sm_aktualisieren()
        sm_TextAktualisieren()
        sm_Farbeaktualisieren()
    End Sub


    Private Shared Sub sm_TextAktualisieren()
        Try
            For Each lz_tonkopf In sv_tonkopf
                lz_tonkopf.me_setText()
            Next
        Catch ex As Exception
            dp("OK sm_TextAktualisieren")
        End Try
    End Sub
    Private Shared Sub sm_Farbeaktualisieren()
        Dim lv_Backcolor As Color
        Try
            For Each lz_tonkopf In sv_tonkopf
                Select Case TaktEingabe.sp_EingabeAkkordtonfunktion_byLeiterton(Ton.sm_Leiterton_byTonindex_int(lz_tonkopf.m_tonindex)) ' %ToDo redundante Variable für Leiterton und Color
                    Case e_Akkordtonfunktion.nichts
                        lv_Backcolor = Color.WhiteSmoke
                    Case e_Akkordtonfunktion.Ton2
                        lv_Backcolor = c_Color_Ton
                    Case e_Akkordtonfunktion.Ton3
                        lv_Backcolor = c_Color_Ton
                    Case e_Akkordtonfunktion.Grundton
                        lv_Backcolor = c_Color_Grundton
                End Select
                lz_tonkopf.BackColor = lv_Backcolor
            Next
        Catch ex As Exception
            dp("OK sm_Farbeaktualisieren")
        End Try
    End Sub

End Class
