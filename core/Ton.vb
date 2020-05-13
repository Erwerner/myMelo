Public Class Ton
    Protected m_TonEnum As e_TonEnum
    Protected m_Oktave_derTonart As Integer

    ' PROPERTY
    Public Property mp_TonEnum() As e_TonEnum
        Get
            Return m_TonEnum
        End Get
        Set(ByVal Value As e_TonEnum)
            m_TonEnum = Value
        End Set
    End Property
    Public Property mp_Oktave As Integer ' Oktave der Tonart
        Get
            Return m_Oktave_derTonart
        End Get
        Set(ByVal value As Integer)
            m_Oktave_derTonart = value
        End Set
    End Property
    ' READONLY
    Public ReadOnly Property mp_Oktave_realTon As Integer
        Get
            Dim lv_OktavStep As Integer
            Select Case g_TonartVerschiebung
                Case Is < 0
                    If m_TonEnum >= gv_Song.mp_Tonart Then lv_OktavStep = -1
                Case Is > 0
                    If m_TonEnum < gv_Song.mp_Tonart Then lv_OktavStep = 1
            End Select
            Return m_Oktave_derTonart + lv_OktavStep
        End Get
    End Property
    Public ReadOnly Property mp_Leiterton As Integer
        Get
            Return g_TonLeiterFunktion(m_TonEnum)
        End Get
    End Property
    Public ReadOnly Property mp_StrName As String
        Get
            Try
                Return c_StrTonName(m_TonEnum) 
            Catch ex As Exception
                Return "###"
            End Try
        End Get
    End Property
    Public ReadOnly Property mp_TonIndex As Integer
        Get
            Return sm_TonIndex_int(m_Oktave_derTonart, mp_Leiterton)
        End Get
    End Property
     
    ' KONSTRUKTOR
    Sub New(ByVal p_TonEnum As e_TonEnum,
            Optional ByVal p_Oktave As Integer = 1)
        m_TonEnum = p_TonEnum
        m_Oktave_derTonart = p_Oktave
    End Sub
     
    ' STATIC
    Public Shared Function sm_TonIndex_int(ByVal p_oktave As Integer, ByVal p_Leiterton As Integer) As Integer
        sm_TonIndex_int = p_oktave * 7 + p_Leiterton
    End Function
    Public Shared Function sm_TonEnum_byTonindex_Tonenum(ByVal p_Tonindex As Integer) As e_TonEnum
        sm_TonEnum_byTonindex_Tonenum = g_Leiterton(sm_Leiterton_byTonindex_int(p_Tonindex))
    End Function
    Public Shared Function sm_Leiterton_byTonindex_int(ByVal p_Tonindex As Integer) As e_TonEnum
        sm_Leiterton_byTonindex_int = p_Tonindex Mod 7
    End Function

    ' PUBLIC 
    Public Sub me_Tonartwechsel()
        gTonartwechsel_Ton(Me)
    End Sub
    Public Function me_VergleicheTon(ByVal p_ton As Ton) As Boolean
        If p_ton.mp_TonEnum = m_TonEnum And _
            p_ton.mp_Oktave = m_Oktave_derTonart Then
            Return True
        Else
            Return False
        End If
    End Function
End Class