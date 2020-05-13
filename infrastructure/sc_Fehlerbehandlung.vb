Public Class sc_Fehlerbehandlung

    Private Shared m_fehlerindex As Integer
    Private Shared m_fehlertext As String
    Public Shared ReadOnly Property mp_fehlertext As String
        Get
            Return m_fehlertext
        End Get
    End Property
    Public Shared Sub me_startFehlerbehandlung()
        AddHandler Application.ThreadException, AddressOf GeneralErrorHandler
    End Sub

    ' zentrale Fehlerbehandlung
    Private Shared Sub GeneralErrorHandler(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
         

        gAdd(m_fehlerindex)

        m_fehlertext = "Fehler#" & m_fehlerindex & ": " & vbCrLf & _
          e.Exception.Message.ToString & vbCrLf & vbCrLf & _
          "Source: " & e.Exception.StackTrace.ToString

        'If gp_Entwickung Then MsgBox(m_fehlertext)
        Fehlermeldung.ShowDialog()

    End Sub
    Public Shared Sub me_RaiseFehler(ByVal p_Methode As String)
        Dim l_Dummy As Ton
        l_Dummy = Nothing
        l_Dummy.me_Tonartwechsel()
    End Sub
    Public Shared Sub me_raisebehandelterfehler()
        Dim l_Dummy As Ton
        Try
            l_Dummy = Nothing
            l_Dummy.me_Tonartwechsel()
        Catch ex As Exception
            MsgBox("no Error")
            sc_Fehlerbehandlung.me_RaiseFehler("")
        End Try
    End Sub
End Class
