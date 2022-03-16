Imports System.ComponentModel
Imports System.Runtime.CompilerServices

<Serializable>
Public Class MyShape
	Implements INotifyPropertyChanged, ICloneable

#Region "New"
	Sub New()
		AddHandler Corners.PropertyChanged, AddressOf NPC
	End Sub

	Private Sub NPC(sender As Object, e As PropertyChangedEventArgs)
		NotifyPropertyChanged()
	End Sub
#End Region

#Region "Event"
	Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

	Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As String = "")
		RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
	End Sub

#End Region

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
			NotifyPropertyChanged()
		End Set
	End Property

#End Region

#Region "RoundedRect"
	Public Enum CornerType
		Normal
		Inverted
	End Enum

	Private _crn As RRCorners = New RRCorners()
	Public Property Corners() As RRCorners
		Get
			Return _crn
		End Get
		Set(ByVal value As RRCorners)
			_crn = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private ul_tp As CornerType = CornerType.Normal
	Public Property ULType() As CornerType
		Get
			Return ul_tp
		End Get
		Set(value As CornerType)
			ul_tp = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private ur_tp As CornerType = CornerType.Normal
	Public Property URType() As CornerType
		Get
			Return ur_tp
		End Get
		Set(value As CornerType)
			ur_tp = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private bl_tp As CornerType = CornerType.Normal
	Public Property BLType() As CornerType
		Get
			Return bl_tp
		End Get
		Set(value As CornerType)
			bl_tp = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private br_tp As CornerType = CornerType.Normal
	Public Property BRType() As CornerType
		Get
			Return br_tp
		End Get
		Set(value As CornerType)
			br_tp = value
			NotifyPropertyChanged()
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
			NotifyPropertyChanged()
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
			NotifyPropertyChanged()
		End Set
	End Property

	Private cur_t As Single = 0.5
	Public Property Tension() As Single
		Get
			Return cur_t
		End Get
		Set(value As Single)
			cur_t = value
			NotifyPropertyChanged()
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
			NotifyPropertyChanged()
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
			NotifyPropertyChanged()
		End Set
	End Property

	Private end_and As Single = 270
	Public Property SweepAngle() As Single
		Get
			Return end_and
		End Get
		Set(value As Single)
			end_and = value
			NotifyPropertyChanged()
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
			NotifyPropertyChanged()
		End Set
	End Property

	Private f_size As Single = 30
	Public Property FontSize() As Single
		Get
			Return f_size
		End Get
		Set(value As Single)
			f_size = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private f_style As FontStyle = FontStyle.Regular
	Public Property FontStyle() As FontStyle
		Get
			Return f_style
		End Get
		Set(value As FontStyle)
			f_style = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private _txt As String = "Text"
	Public Property Text() As String
		Get
			Return _txt
		End Get
		Set(value As String)
			_txt = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private txt_al As ContentAlignment = ContentAlignment.MiddleCenter
	Public Property TextAlignment() As ContentAlignment
		Get
			Return txt_al
		End Get
		Set(value As ContentAlignment)
			txt_al = value
			NotifyPropertyChanged()
		End Set
	End Property
#End Region

#Region "Clone"
	''' <summary>
	''' Creates an exact copy of this <see cref="MyShape"/> object.
	''' </summary>
	Public Function Clone() As Object Implements ICloneable.Clone
		Dim _new As New MyShape
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyShape))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		If Not IsNothing(Corners) Then _new.Corners = Corners.Clone
		Return _new
	End Function
#End Region

End Class

#Region "RRCorners"
<Serializable>
Public Class RRCorners
	Implements INotifyPropertyChanged, ICloneable

#Region "Event"
	Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

	Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As String = "")
		RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
	End Sub

#End Region

#Region "Properties"
	Private _t1 As Single = 25
	Public Property T1() As Single
		Get
			Return _t1
		End Get
		Set(ByVal value As Single)
			_t1 = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private _t2 As Single = 25
	Public Property T2() As Single
		Get
			Return _t2
		End Get
		Set(ByVal value As Single)
			_t2 = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private _r1 As Single = 25
	Public Property R1() As Single
		Get
			Return _r1
		End Get
		Set(ByVal value As Single)
			_r1 = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private _r2 As Single = 25
	Public Property R2() As Single
		Get
			Return _r2
		End Get
		Set(ByVal value As Single)
			_r2 = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private _b1 As Single = 25
	Public Property B1() As Single
		Get
			Return _b1
		End Get
		Set(ByVal value As Single)
			_b1 = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private _b2 As Single = 25
	Public Property B2() As Single
		Get
			Return _b2
		End Get
		Set(ByVal value As Single)
			_b2 = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private _l1 As Single = 25
	Public Property L1() As Single
		Get
			Return _l1
		End Get
		Set(ByVal value As Single)
			_l1 = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private _l2 As Single = 25
	Public Property L2() As Single
		Get
			Return _l2
		End Get
		Set(ByVal value As Single)
			_l2 = value
			NotifyPropertyChanged()
		End Set
	End Property
#End Region

#Region "Helpers"
	Shared Function FromArray(arr As Single()) As RRCorners
		If arr.Length < 8 Then Return Nothing
		Dim crr As New RRCorners
		crr.T1 = arr(0)
		crr.T2 = 100 - arr(1)
		crr.R1 = arr(2)
		crr.R2 = 100 - arr(3)
		crr.B1 = arr(4)
		crr.B2 = 100 - arr(5)
		crr.L1 = arr(6)
		crr.L2 = 100 - arr(7)
		Return crr
	End Function

	Public Function ToArray() As Single()
		Return New Single() {T1, 100 - T2,
							 R1, 100 - R2,
							 B1, 100 - B2,
							 L1, 100 - L2}
	End Function
#End Region

#Region "Clone"
	''' <summary>
	''' Creates an exact copy of this <see cref="RRCorners"/> object.
	''' </summary>
	Public Function Clone() As Object Implements ICloneable.Clone
		Dim _new As New RRCorners
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(RRCorners))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		Return _new
	End Function
#End Region

End Class
#End Region
