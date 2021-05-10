Imports System.ComponentModel

<Serializable>
Public Class MyShape

#Region "Type"
	Public Enum ShapeStyle
		Rectangle
		RoundedRectangle
		Ellipse
		Triangle
		Lines
		Polygon
		Curves
		ClosedCurve
		Spiral
		Arc
		Pie
		Text
	End Enum

	Private s_type As ShapeStyle = ShapeStyle.Rectangle
	Public Property SType() As ShapeStyle
		Get
			Return s_type
		End Get
		Set(value As ShapeStyle)
			s_type = value
		End Set
	End Property

	Private _cls As Boolean = False
	Public Property IsClosed() As Boolean
		Get
			Return _cls
		End Get
		Set(value As Boolean)
			_cls = value
		End Set
	End Property
#End Region

#Region "RoundedRect"
	Public Enum CornerType
		Normal
		Inverted
	End Enum

	Private ul_sz As Single = 5
	Public Property ULSize() As Single
		Get
			Return ul_sz
		End Get
		Set(value As Single)
			ul_sz = value
		End Set
	End Property

	Private ul_tp As CornerType = CornerType.Normal
	Public Property ULType() As CornerType
		Get
			Return ul_tp
		End Get
		Set(value As CornerType)
			ul_tp = value
		End Set
	End Property

	Private ur_sz As Single = 5
	Public Property URSize() As Single
		Get
			Return ur_sz
		End Get
		Set(value As Single)
			ur_sz = value
		End Set
	End Property

	Private ur_tp As CornerType = CornerType.Normal
	Public Property URType() As CornerType
		Get
			Return ur_tp
		End Get
		Set(value As CornerType)
			ur_tp = value
		End Set
	End Property

	Private bl_sz As Single = 5
	Public Property BLSize() As Single
		Get
			Return bl_sz
		End Get
		Set(value As Single)
			bl_sz = value
		End Set
	End Property

	Private bl_tp As CornerType = CornerType.Normal
	Public Property BLType() As CornerType
		Get
			Return bl_tp
		End Get
		Set(value As CornerType)
			bl_tp = value
		End Set
	End Property

	Private br_sz As Single = 5
	Public Property BRSize() As Single
		Get
			Return br_sz
		End Get
		Set(value As Single)
			br_sz = value
		End Set
	End Property

	Private br_tp As CornerType = CornerType.Normal
	Public Property BRType() As CornerType
		Get
			Return br_tp
		End Get
		Set(value As CornerType)
			br_tp = value
		End Set
	End Property
#End Region

#Region "Lines/Polygon"
	Private pol_pt As PointF() = New PointF() {New PointF(10, 10), New PointF(10, 90), New PointF(90, 90)}
	Public Property PolygonPoints() As PointF()
		Get
			Return pol_pt
		End Get
		Set(value As PointF())
			pol_pt = value
		End Set
	End Property
#End Region

#Region "Curve/ClosedCurve"
	Private cur_pt As PointF() = New PointF() {New PointF(10, 10), New PointF(10, 90), New PointF(90, 90)}
	Public Property CurvePoints() As PointF()
		Get
			Return cur_pt
		End Get
		Set(value As PointF())
			cur_pt = value
		End Set
	End Property

	Private cur_t As Single = 0.5
	Public Property Tension() As Single
		Get
			Return cur_t
		End Get
		Set(value As Single)
			cur_t = value
		End Set
	End Property
#End Region

#Region "Spiral"
	Private _spirals As Integer = 5
	Public Property Spirals() As Integer
		Get
			Return _spirals
		End Get
		Set(value As Integer)
			_spirals = value
		End Set
	End Property
#End Region

#Region "Arc/Pie"
	Private st_and As Single = 0
	Public Property StartAngle() As Single
		Get
			Return st_and
		End Get
		Set(value As Single)
			st_and = value
		End Set
	End Property

	Private end_and As Single = 270
	Public Property SweepAngle() As Single
		Get
			Return end_and
		End Get
		Set(value As Single)
			end_and = value
		End Set
	End Property
#End Region

#Region "Text"
	Private f_name As String = "Segoe UI"
	Public Property FontName() As String
		Get
			Return f_name
		End Get
		Set(value As String)
			f_name = value
		End Set
	End Property

	Private f_size As Single = 30
	Public Property FontSize() As Single
		Get
			Return f_size
		End Get
		Set(value As Single)
			f_size = value
		End Set
	End Property

	Private f_style As FontStyle = FontStyle.Regular
	Public Property FontStyle() As FontStyle
		Get
			Return f_style
		End Get
		Set(value As FontStyle)
			f_style = value
		End Set
	End Property

	Private _txt As String = "Text"
	Public Property Text() As String
		Get
			Return _txt
		End Get
		Set(value As String)
			_txt = value
		End Set
	End Property

	Private txt_al As ContentAlignment = ContentAlignment.MiddleCenter
	Public Property TextAlignment() As ContentAlignment
		Get
			Return txt_al
		End Get
		Set(value As ContentAlignment)
			txt_al = value
		End Set
	End Property
#End Region

#Region "Clone"
	Public Function Clone() As MyShape
		Dim _new As New MyShape
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyShape))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		Return _new
	End Function
#End Region

End Class
