Public Class MIDIExport_Option
    Private m_InstrumentAuswahl As cl_InstrumentAuswahl

    Private Sub MIDIExport_Option_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_InstrumentAuswahl = cl_InstrumentAuswahl.getInstance(e_InstrumentListTyp.MIDI_TEXT)
        With m_InstrumentAuswahl
            For Each lz_Instrumentname In .mp_arrayfetch_Name()
                Me.ComboBox1.Items.Add(lz_Instrumentname)
            Next
            Me.ComboBox1.SelectedIndex = .mp_InstrumentListIndex_vonInstrument(gv_Song.mp_instrumentmidi)

        End With
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        gv_Song.mp_instrumentmidi = m_InstrumentAuswahl.mp_wähle_InstrumentIndex(Me.ComboBox1.SelectedIndex)
        sc_MIDI.getInstanz.testmidiexport(True)
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.ComboBox1.SelectedIndex = m_InstrumentAuswahl.mp_InstrumentListIndex_vonInstrument(m_InstrumentAuswahl.mp_wähle_InstrumentIndex(Me.ComboBox1.SelectedIndex))
    End Sub
End Class