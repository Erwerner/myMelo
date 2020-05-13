'%CS
Public Class cl_ImExport
    Private Shared this As cl_ImExport
    Private Shared m_saveFildedialog As FileDialog
    Private Shared m_openFildedialog As FileDialog
    Private m_ExportValue As String
    Private m_ImportValue As String
    Private m_ImportReadStep As Integer

    ' READONLY
    Private Shared ReadOnly Property sp_saveFildedialog As FileDialog
        Get
            If m_saveFildedialog Is Nothing Then
                m_saveFildedialog = New SaveFileDialog

                m_saveFildedialog.InitialDirectory = cp_SaveOrdner
                m_saveFildedialog.Title = "Song speichern"
                m_saveFildedialog.DefaultExt = "ehs"
                m_saveFildedialog.Filter = "easy harmony Songs (*.ehs)|*.ehs"
                m_saveFildedialog.RestoreDirectory = True
            End If
            Return m_saveFildedialog
        End Get
    End Property
    Private Shared ReadOnly Property sp_openFildedialog As FileDialog
        Get
            If m_openFildedialog Is Nothing Then
                m_openFildedialog = New OpenFileDialog

                m_openFildedialog.InitialDirectory = cp_SaveOrdner
                m_openFildedialog.Title = "Song öffnen"
                m_openFildedialog.DefaultExt = "ehs"
                m_openFildedialog.Filter = "easy harmony Songs (*.ehs)|*.ehs"
                m_openFildedialog.RestoreDirectory = True
            End If
            Return m_openFildedialog
        End Get
    End Property

    ' FACTORY
    Public Shared Function factory() As cl_ImExport
        If this Is Nothing Then
            this = New cl_ImExport
        End If
        factory = this
    End Function
    ' PUBLIC
    Public Sub me_ex_Popup()
        Dim l_path As String
        Dim l_fildeDialog As FileDialog
        l_fildeDialog = sp_saveFildedialog

        Try
            If (l_fildeDialog.ShowDialog() = DialogResult.OK) Then
                l_path = l_fildeDialog.FileName
                me_ex_File(l_path)
            End If
        Catch ex As Exception
            MsgBox("Ein Fehler ist während des Speicherns aufgetreten.")
        End Try
    End Sub
    Public Sub me_ex_File(ByVal p_pfad As String, Optional ByVal p_value As String = "")
        If Not p_value = "" Then gAppendString(m_ExportValue, p_value)
        Try
            My.Computer.FileSystem.WriteAllText(p_pfad, m_ExportValue, False)
        Catch ex As Exception
            MsgBox("Ein Fehler ist während des Speicherns aufgetreten.")
        End Try
        this.me_clear()
    End Sub
    Public Sub me_Ex_append(ByVal p_value, Optional ByVal p_boolToInt = False)
        If p_boolToInt Then p_value = global_BoolToInt(p_value)
        gAppendString(m_ExportValue, p_value & ";")
    End Sub
    Public Sub me_exportBreak()
        gAppendString(m_ExportValue, vbCrLf)
    End Sub
    Public Function me_imp_popup(ByRef ref_Titel As String) As String
        Dim l_return As New String("")
        Dim l_path As String
        Dim l_fildeDialog As FileDialog

        Dim l_PfadTeil As String()


        l_fildeDialog = sp_openFildedialog

        Try
            If (l_fildeDialog.ShowDialog() = DialogResult.OK) Then
                l_path = l_fildeDialog.FileName

                ' Titel ermitteln
                l_PfadTeil = Split(l_path, "\")
                For Each lz_part In l_PfadTeil
                    If Not InStr(lz_part, ".") = 0 Then
                        ref_Titel = Mid(lz_part, 1, Len(lz_part) - 4)
                    End If
                Next

                l_return = me_Imp_File(l_path)
            End If
        Catch ex As Exception
            MsgBox("Ein Fehler ist während des Ladens aufgetreten.")
        End Try
        Return l_return
    End Function
    Public Sub me_setImportData(ByVal p_Data As String)
        me_clear()
        m_ImportValue = p_Data
    End Sub
    Public Function me_Imp_File(ByVal p_Path As String, Optional ByVal p_FallbackString As String = "") As String
        this.me_clear()
        Try
            m_ImportValue = My.Computer.FileSystem.ReadAllText(p_Path)
            m_ImportValue = Replace(m_ImportValue, vbCrLf, "")
        Catch ex As Exception
            m_ImportValue = p_FallbackString
        End Try
        Return m_ImportValue
    End Function
    Public Function me_getImp_Part(Optional ByVal p_intToBool As Boolean = False)
        Dim l_starReadPos As Integer
        Dim l_DataValue
        l_starReadPos = m_ImportReadStep + 1
        m_ImportReadStep = InStr(l_starReadPos, m_ImportValue, ";")

        l_DataValue = Mid(m_ImportValue, l_starReadPos, m_ImportReadStep - l_starReadPos)
        If p_intToBool Then l_DataValue = gIntToBool(l_DataValue)
        me_getImp_Part = l_DataValue
    End Function

    Private Sub me_clear()
        m_ExportValue = ""
        m_ImportValue = ""
        m_ImportReadStep = 0
    End Sub
End Class
