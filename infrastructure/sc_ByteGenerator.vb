
Public Class Bytepuffer
    Private m_pufferindex As Integer
    Private m_Puffer As Byte()

    ' READONLY
    Public ReadOnly Property mp_Result As Byte()
        Get
            Dim l_return() As Byte
            gAdd(m_pufferindex, -1)
            ReDim l_return(m_pufferindex)
            For lz_Byteindex = 0 To m_pufferindex
                l_return(lz_Byteindex) = m_Puffer(lz_Byteindex)
            Next
            Return l_return
        End Get
    End Property
    ' KONSTRUKTOR
    Public Sub New(ByVal p_Size As Integer)
        ReDim m_Puffer(p_Size)
    End Sub
    ' PUBLIC
    Public Sub me_appendPuffer(ByVal p_value() As Byte)
        For Each lz_Byte In p_value
            m_Puffer(m_pufferindex) = lz_Byte
            gAdd(m_pufferindex)
        Next
    End Sub
End Class
Public Class sc_ByteGenerator
    Public Shared Sub sm_generiereByte(ByVal p_path As String, ByVal p_value As Byte())
        My.Computer.FileSystem.WriteAllBytes(p_path, p_value, False)
    End Sub
End Class
