Public Class sc_instrument
    Private Shared this(128) As sc_instrument
    Private Shared sv_Name() As String = New String(1) {"Piano", "Gitarre"}
    Private m_intrumentenum As e_instrumentenum
    Private m_Instrumentordner() As String = New String(1) {"\Piano1", "\Gitarre1"}

    ' READONLY
    Public ReadOnly Property mp_Instrumentordner As String
        Get
            Return m_Instrumentordner(m_intrumentenum)
        End Get
    End Property
    ' KONSTRUKTOR
    Public Sub New(ByVal p_intrumentenum As e_instrumentenum)
        m_intrumentenum = p_intrumentenum
    End Sub
    ' FACTORY
    Public Shared Function factory(ByVal p_intrumentenum As e_instrumentenum) As sc_instrument
        If this(p_intrumentenum) Is Nothing Then
            this(p_intrumentenum) = New sc_instrument(p_intrumentenum)
        End If
        Return this(p_intrumentenum)
    End Function
End Class