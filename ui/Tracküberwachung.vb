Public Class Tracküberwachung

    Private Sub Tracküberwachung_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l_output As New String("") 

        gAppendString(l_output, "Takt ")
        gAppendString(l_output, vbTab & vbTab & "Einht. ")
        gAppendString(l_output, vbTab & vbTab & "play")
        gAppendString(l_output, vbTab & vbTab & "Ton")
        gAppendString(l_output, vbTab & vbTab & "Oktv")
        gAppendString(l_output, vbTab & vbTab & "Länge")
                gAppendString(l_output, vbCrLf)

        'For lz_Takt = 0 To arrIx(gv_Song.mp_anzahlAlleTakte)
        For Each lz_Takt In Takt.get_absolut_alleTakte_asArray()

            With lz_Takt
                gAppendString(l_output, .mp_taktBezeichnung)
            End With
            For Each lz_Takteinheit In lz_Takt.get_alleTakteinheiten
                With lz_Takteinheit.mp_Melodienote
                    gAppendString(l_output, vbTab & vbTab & "Einht. " & lz_Takteinheit.mp_Index + 1)
                    gAppendString(l_output, vbTab & vbTab & IIf(.mp_wirdGespielt, "X", " "))
                    gAppendString(l_output, vbTab & vbTab & .mp_StrName)
                    gAppendString(l_output, vbTab & vbTab & .mp_Oktave)
                    gAppendString(l_output, vbTab & vbTab & .mp_Länge)
                    gAppendString(l_output, vbCrLf)
                End With
            Next
        Next

        Me.TextBox1.Text = l_output
    End Sub
End Class