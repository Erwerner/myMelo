'%NK
Public Class Akkordton
    Inherits Ton
    Private m_TonIndex As Integer
    Private m_Position As Integer '(1-3)
    Private m_Intervall_nachGrundton As Integer
    'Public m_funktion As Integer

    Sub New(ByVal p_TonEnum As e_TonEnum,
            ByVal p_TonIndex As Integer,
            ByVal p_Intervall As Integer,
   Optional ByVal p_Oktave As Integer = 1)

        MyBase.New(p_TonEnum, p_Oktave)
        m_TonIndex = p_TonIndex
        m_Intervall_nachGrundton = p_Intervall
    End Sub
End Class
