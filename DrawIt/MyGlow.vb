Public Class MyGlow

    Public Enum GlowStyle
        OnShape
        OnBorder
    End Enum

    Private _style As GlowStyle = GlowStyle.OnShape
    Public Property GStyle() As GlowStyle
        Get
            Return _style
        End Get
        Set(ByVal value As GlowStyle)
            _style = value
        End Set
    End Property

    Private _before As Boolean = True
    Public Property BeforeFill() As Boolean
        Get
            Return _before
        End Get
        Set(ByVal value As Boolean)
            _before = value
        End Set
    End Property

    Private _glow As Integer = 35
    Public Property Glow() As Integer
        Get
            Return _glow
        End Get
        Set(ByVal value As Integer)
            _glow = value
        End Set
    End Property

    Private _feather As Integer = 35
    Public Property Feather() As Integer
        Get
            Return _feather
        End Get
        Set(ByVal value As Integer)
            _feather = value
        End Set
    End Property

    Private _clr As Color = Color.Red
    Public Property GlowColor() As Color
        Get
            Return _clr
        End Get
        Set(ByVal value As Color)
            _clr = value
        End Set
    End Property


End Class
