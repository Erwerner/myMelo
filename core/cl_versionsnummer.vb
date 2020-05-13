Public Class cl_versionsnummer
    Private Const c_installVersionstyp = "!"
    Private Const c_installVersionsDatum = "18.09.2012"
    Private Const c_installVersionsEdition = ""
    Public m_Datum As Date
    Public m_typ As Char
    Public m_versionsnummerString As String
    'Public m_edition As Integer ' %ToDo erweitern

    Public Shared ReadOnly Property cp_installversionsString As String
        Get
            If CDate(c_installVersionsDatum) <> Today And gp_Entwickung Then
                MsgBox("Versio")
            End If
            Return c_installVersionstyp & _
                CDate(c_installVersionsDatum) & _
                c_installVersionsEdition
        End Get
    End Property
    Public Shared ReadOnly Property cp_installVersionsdatum As Date
        Get
            Return c_installVersionsDatum
        End Get
    End Property

    ' KONSTRUKTOR
    Public Sub New(ByVal p_Versionsstring As String)
        m_versionsnummerString = p_Versionsstring
        m_typ = Mid(p_Versionsstring, 1, 1)
        Select Case m_typ
            Case "!"
                m_Datum = CDate(Mid(p_Versionsstring, 2, 10))
            Case Else
                m_Datum = CDate("31.12.2099")
        End Select
    End Sub
    Public Function me_Versionaktuell(ByVal p_Versionsnummer2 As cl_versionsnummer) As Boolean
        Dim l_istaktuell As Boolean
        If m_Datum > p_Versionsnummer2.m_Datum Then
            l_istaktuell = True
        Else
            If m_Datum = p_Versionsnummer2.m_Datum And _
                  Len(m_versionsnummerString) >= Len(p_Versionsnummer2.m_versionsnummerString) Then
                l_istaktuell = True
            End If
        End If
        me_Versionaktuell = l_istaktuell
    End Function
End Class
