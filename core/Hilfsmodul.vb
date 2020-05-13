Module Hilfsmodul
    Public Sub dp(ByVal p_Output As String)
        Debug.Print(p_Output)
    End Sub

    Public Function global_BoolToInt(ByVal p_Boolean As Boolean) As Integer
        If p_Boolean Then Return 1 Else Return 0
    End Function
    Public Function gIntToBool(ByVal p_int As Integer) As Boolean
        Return p_int = 1
    End Function

    Public Function arrIx(ByVal xIndex As Integer) As Integer
        Return xIndex - 1
    End Function

    Public Function gAdd(ByRef ref_Integer As Integer, Optional ByVal p_step As Integer = 1) As Integer
        ref_Integer = ref_Integer + p_step
        Return ref_Integer
    End Function
    Public Sub gAppendString(ByRef ref_String As String, ByVal p_Value As String)
        ref_String = ref_String & p_Value
    End Sub

    Public Function gColor(ByVal p_a As Integer, ByVal p_b As Integer, ByVal p_c As Integer) As Color
        Return System.Drawing.Color.FromArgb(CType(CType(p_a, Byte), Integer), CType(CType(p_b, Byte), Integer), CType(CType(p_c, Byte), Integer))
    End Function

    Public Function gShortPath(ByRef ref_path As String) As String
        Dim sBuffer As String
        sBuffer = Space$(255)

        GetShortPathName(ref_path, sBuffer, Len(sBuffer))
        Try
            ref_path = Microsoft.VisualBasic.Left(sBuffer, InStr(sBuffer, vbNullChar) - 1)
        Catch ex As Exception

        End Try
        Return ref_path
    End Function
End Module
