Public Class sc_Player

    Private Shared this As sc_Player
    Private Shared sv_PlayCursor() As System.Windows.Forms.UserControl
    Private Shared sv_playStepIndex As Integer
    Private Shared sv_EingabeTakt_StartAtPlayStep_rdnt As Integer
    Private Shared sv_alleTaktespielen As Boolean


    ' SHARED
    Public Shared WriteOnly Property sp_EingabeTakt_StartAtPlayStep As Integer
        Set(ByVal value As Integer)
            sv_EingabeTakt_StartAtPlayStep_rdnt = value
        End Set
    End Property 
    Public Shared ReadOnly Property sp_TimerValue As Double
        Get
            Return 60 / gv_Song.mp_Tempo * 4 / (c_MinEinheit + 1) * 1000
        End Get
    End Property
    Public Shared ReadOnly Property sp_PlayCursor As System.Windows.Forms.UserControl
        Get
            If Not sv_playStepIndex < 0 Then
                If Not (sv_playStepIndex >= sv_EingabeTakt_StartAtPlayStep_rdnt _
                        And sv_playStepIndex < sv_EingabeTakt_StartAtPlayStep_rdnt + 8) Then
                    'Try
                    Return sv_PlayCursor(sv_playStepIndex)
                    'Catch ex As Exception
                    'Return Nothing
                    'End Try
                Else
                    Return TaktEingabe.getInstanz.mp_TaktEinheitEingabe(sv_playStepIndex - sv_EingabeTakt_StartAtPlayStep_rdnt).mp_aktivTonpanel
                End If
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Shared ReadOnly Property sp_startTaktIndex As Integer
        Get
            Return Form1.cboSpiele_vonTakt.SelectedIndex
        End Get
    End Property
    Public Shared ReadOnly Property sp_endTaktIndex As Integer
        Get
            Return Form1.cboSpiele_bisTakt.SelectedIndex + Form1.cboSpiele_vonTakt.SelectedIndex
        End Get
    End Property
    Public Shared ReadOnly Property sp_Anzahl_Playtakte As Integer
        Get
            Return sp_endTaktIndex - sp_startTaktIndex + 1
        End Get
    End Property
    ' FACTORY
    Public Shared Function factory() As sc_Player
        If this Is Nothing Then
            this = New sc_Player
        End If
        Return this
    End Function
    ' SHARED
    Public Shared Sub sm_TimerTick()
        Dim l_PlayCursor As System.Windows.Forms.UserControl
        ' Sequenz
        sc_SequenzSteuerung.sm_playSteuerung()

        ' PlayAnzeige 
        l_PlayCursor = sp_PlayCursor
        If Not l_PlayCursor Is Nothing Then
            Try
                l_PlayCursor.BackColor = c_Color_Note
            Catch ex As Exception
            End Try
        End If

        gAdd(sv_playStepIndex)

        l_PlayCursor = sp_PlayCursor
        If Not l_PlayCursor Is Nothing Then
            Try
                l_PlayCursor.BackColor = c_Color_Play
            Catch ex As Exception

            End Try
        End If
    End Sub 
    ' PUBLIC
    Public Sub me_startPlayer() 
        ReDim sv_PlayCursor(gv_Song.mp_anzahlAktivTakte * 8)
        For lz_PlayTaktIndex = sp_startTaktIndex To sp_endTaktIndex
            For lz_TakteinheitIndex = 0 To c_MinEinheit
                    sv_PlayCursor(gStep_integer(lz_PlayTaktIndex, lz_TakteinheitIndex)) = Taktanzeige.sp_PlayTaktAnzeige(lz_PlayTaktIndex).mp_Takteinheitanzeige(lz_TakteinheitIndex).mp_TonCursor
            Next
        Next
        sv_playStepIndex = -1 + (sp_startTaktIndex * 8)

        'Form1.stsPlayTakt.Value = 0
        'Form1.stsPlayTakt.Maximum = sp_Anzahl_Playtakte

        sc_SequenzSteuerung.sm_leseSequenz()


            Form1.Timer1.Start()
    End Sub
    Public Sub me_PlayerStop()
        Form1.Timer1.Stop()
        'Form1.stsPlayTakt.Value = 0
        TonDatei.sm_closeSoundfiles()
        Try
            sp_PlayCursor.BackColor = c_Color_Note
        Catch ex As Exception
        End Try
    End Sub
    Public Sub me_setTimerValue()
        Form1.Timer1.Interval = sp_TimerValue
    End Sub
End Class
