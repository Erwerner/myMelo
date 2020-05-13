Module GlobalDesign

    Public ReadOnly Property HöheHauptTakteEnde As Integer
        Get
            Return (gv_Song.mp_anzahlHauptTakte + global_BoolToInt(gv_Song.mp_hatAuftakt)) * 8 * globDes_BreiteTonCursor
        End Get
    End Property
      
    Public Const c_size_Kontrollleiste As Integer = 70
    Public Const globDes_BreiteTonCursor = 13
    Public Const globDes_BreiteTaktinfo = 130

    Public c_Color_Grundton As Color = gColor(160, 255, 140)
    Public c_Color_Ton As Color = gColor(220, 255, 120)
    Public c_Color_Note As Color = Color.White 'Color.Coral
    Public c_Color_Play As Color = Color.Blue
    Public c_color_SequenzBack As Color = Color.White
    Public c_color_Takteinheiteingabe_Back As Color = Color.WhiteSmoke
    Public c_color_taktanzeige_back As Color = c_color_Takteinheiteingabe_Back

    Public c_color_Akkordfunktion() As Color = New Color(5) {Color.Green, Color.LightYellow, Color.LightBlue, Color.Yellow, Color.Blue, Color.LightGreen}
      

    Public Sub Taktanzeigen_poitionieren()
        Form1.pnlSequenzer.AutoScrollPosition = New System.Drawing.Point(0, 0)
        For Each ta In g_Taktanzeige
            ta.Position_setzen()
        Next
        gp_TaktAnzeige(e_Takttyp.Auftakt).Position_setzen()
        gp_TaktAnzeige(e_Takttyp.Schlussakkord).Position_setzen()
        Form1.TaktEingabe1.me_setPosition()
    End Sub
End Module
