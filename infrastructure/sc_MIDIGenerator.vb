Public Class sc_MIDIGenerator
    Public Shared Sub sm_generiereMIDIDateien(ByVal p_MIDIInstrument As Integer, ByVal p_path As String)
        Dim l_BytePuffer As Bytepuffer
        Dim l_miditon As Integer
        Dim l_FileName As String
        For lz_oktave = 0 To 4
            For lz_ton = 0 To 11
                l_miditon = lz_oktave * 12 + lz_ton + 48

                l_FileName = ""
                If lz_ton < 10 Then
                    gAppendString(l_FileName, "0" & lz_ton)
                Else
                    gAppendString(l_FileName, lz_ton)
                End If
                gAppendString(l_FileName, lz_oktave)
                l_BytePuffer = New Bytepuffer(64)
                l_BytePuffer.me_appendPuffer({&H4D, &H54, &H68, &H64, &H0, &H0, &H0, &H6, &H0, &H0, &H0, &H1, &H3, &HC0, &H4D, &H54, &H72, &H6B, &H0, &H0, &H0, &H27, &H0, _
                                              &HFF, &H20, &H1})
                l_BytePuffer.me_appendPuffer({lz_ton})
                l_BytePuffer.me_appendPuffer({&H0, &HFF, &H3, &H2, &H65, &H68, &H0, _
                                              &HC0, &H0, &H0, &HFF, &H59, &H2, &H0, &H0, &H0, &HFF, &H59, &H2, &H0, &H0, &H0, _
                                              &H90})
                l_BytePuffer.me_appendPuffer({l_miditon})
                l_BytePuffer.me_appendPuffer({&H40, &H87, &H40, &H80})
                l_BytePuffer.me_appendPuffer({l_miditon})
                l_BytePuffer.me_appendPuffer({&H0, &H0, &HFF, &H2F, &H0})
                sc_ByteGenerator.sm_generiereByte(p_path & l_FileName & ".mid", l_BytePuffer.mp_Result)

            Next

        Next
    End Sub
     
End Class
