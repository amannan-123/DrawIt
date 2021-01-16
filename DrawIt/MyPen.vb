Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<Serializable>
Public Class MyPen

#Region "New"
    Sub New()
        PBrush.SolidColor = Color.Black
        PBrush.LInterpolate = True
    End Sub
#End Region

#Region "Pen"
    Private _br As MyBrush = New MyBrush()
    Public Property PBrush() As MyBrush
        Get
            Return _br
        End Get
        Set(ByVal value As MyBrush)
            _br = value
        End Set
    End Property

    Private _wid As Single = 1
    Public Property PWidth() As Single
        Get
            Return _wid
        End Get
        Set(ByVal value As Single)
            _wid = value
        End Set
    End Property

    Private d_cap As DashCap = DashCap.Flat
    Public Property PDashCap() As DashCap
        Get
            Return d_cap
        End Get
        Set(ByVal value As DashCap)
            d_cap = value
        End Set
    End Property

    Private d_style As DashStyle = DashStyle.Solid
    Public Property PDashstyle() As DashStyle
        Get
            Return d_style
        End Get
        Set(ByVal value As DashStyle)
            d_style = value
        End Set
    End Property

    Private st_cap As LineCap = LineCap.Flat
    Public Property PStartCap() As LineCap
        Get
            Return st_cap
        End Get
        Set(ByVal value As LineCap)
            st_cap = value
        End Set
    End Property

    Private end_cap As LineCap = LineCap.Flat
    Public Property PEndCap() As LineCap
        Get
            Return end_cap
        End Get
        Set(ByVal value As LineCap)
            end_cap = value
        End Set
    End Property

    Private l_join As LineJoin = LineJoin.Miter
    Public Property PLineJoin() As LineJoin
        Get
            Return l_join
        End Get
        Set(ByVal value As LineJoin)
            l_join = value
        End Set
    End Property

    Private scale_x As Single = 1
    Public Property ScaleX() As Single
        Get
            Return scale_x
        End Get
        Set(ByVal value As Single)
            scale_x = value
        End Set
    End Property

    Private scale_y As Single = 1
    Public Property ScaleY() As Single
        Get
            Return scale_y
        End Get
        Set(ByVal value As Single)
            scale_y = value
        End Set
    End Property
#End Region

#Region "Clone"
    Public Function Clone() As MyPen
        Dim _new As New MyPen
        For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyPen))
            pd.SetValue(_new, pd.GetValue(Me))
        Next
        _new.PBrush = PBrush.Clone
        Return _new
    End Function
#End Region

End Class
