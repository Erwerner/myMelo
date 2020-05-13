Option Explicit On

Public Class Akkord 
    Private m_Geschlecht As e_Tongeschlecht
    Protected m_Ton(2) As Akkordton

    ' PROPERTY
    Public Property mp_Ton(ByVal z As Integer) As Akkordton
        Get
            Return m_Ton(z)
        End Get
        Set(ByVal value As Akkordton)
            m_Ton(z) = value
        End Set
    End Property
    ' READONLY
    Public ReadOnly Property mp_Grundton As Ton
        Get 
            Return m_Ton(0)
        End Get
    End Property
    Public ReadOnly Property mp_Geschlecht As e_Tongeschlecht
        Get
            Return m_Geschlecht
        End Get
    End Property
    Public ReadOnly Property mp_StrGeschlecht As String
        Get
            Return c_strTonGeschlecht(m_Geschlecht)
        End Get
    End Property
    Public ReadOnly Property mp_Akkordfunktion() As Integer
        Get
            'Return (m_Grundton.mp_Leiterton)
            Return (m_Ton(0).mp_Leiterton)
        End Get
    End Property
    Public ReadOnly Property mp_Bezeichnung As String
        Get
            Return m_Ton(0).mp_StrName & " " & mp_StrGeschlecht
        End Get
    End Property

    ' KONSTRUKTOR
    Sub New(ByVal p_Grundton As e_TonEnum,
            ByVal p_Geschlecht As e_Tongeschlecht,
            Optional ByVal p_OktaveGrundton As Integer = 1)
         
        Dim Ton2Intervall As Integer
        Dim RückgabeOktave As Integer
         
        m_Geschlecht = p_Geschlecht

        'Alle Tonfunktionen auf nichts setzen
        'For zTF = 0 To 6
        '    m_TonFunktion(zTF) = Akkordtonfunktion.nichts
        'Next

        'Mittleren ton lesen
        If m_Geschlecht = e_Tongeschlecht.Dur Then
            Ton2Intervall = 4
        Else
            Ton2Intervall = 3
        End If
         
        m_Ton(0) = New Akkordton(p_Grundton, 1, 0, p_OktaveGrundton)
        m_Ton(1) = New Akkordton(TonÄndern_TonEnum(m_Ton(0), Ton2Intervall, , e_wertErhaltenEnum.WertErhalten, RückgabeOktave), 2, Ton2Intervall, RückgabeOktave)
        m_Ton(2) = New Akkordton(TonÄndern_TonEnum(m_Ton(0), 7, , e_wertErhaltenEnum.WertErhalten, RückgabeOktave), 3, 7, RückgabeOktave)
    End Sub

    ' PUBLIC
    Public Sub me_Tonartwechsel()
        'm_Grundton.me_Tonartwechsel()
        For Each xTon In m_Ton
            xTon.me_Tonartwechsel()
        Next
    End Sub
    Public Function me_Akkord_hatTon(ByVal p_ton As Ton) As Boolean
        For Each lz_ton In m_Ton
            If lz_ton.mp_Oktave = p_ton.mp_Oktave Then
                If lz_ton.mp_TonEnum = p_ton.mp_TonEnum Then
                    Return True
                    Exit Function
                End If
            End If
        Next

        Return False
    End Function

End Class
