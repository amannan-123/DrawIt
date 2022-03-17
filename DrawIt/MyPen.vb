Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices

<Serializable>
Public Class MyPen
	Implements INotifyPropertyChanged, ICloneable

#Region "New"
	Sub New()
		PBrush.SolidColor = Color.Black
		PBrush.LInterpolate = True
		AddHandler PBrush.PropertyChanged, AddressOf NPC
	End Sub

	Private Sub NPC(sender As Object, e As PropertyChangedEventArgs)
		RaiseEvent PropertyChanged(Me, e)
	End Sub
#End Region

#Region "Event"
	<NonSerialized>
	Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

	Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As String = "")
		RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
	End Sub

#End Region

#Region "Pen"
	Private _br As MyBrush = New MyBrush()
	Public Property PBrush() As MyBrush
		Get
			Return _br
		End Get
		Set(value As MyBrush)
			If Not value.Equals(_br) Then
				_br = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _wid As Single = 1
	Public Property PWidth() As Single
		Get
			Return _wid
		End Get
		Set(value As Single)
			If Not value = _wid Then
				_wid = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private d_cap As DashCap = DashCap.Flat
	Public Property PDashCap() As DashCap
		Get
			Return d_cap
		End Get
		Set(value As DashCap)
			If Not value = d_cap Then
				d_cap = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private d_style As DashStyle = DashStyle.Solid
	Public Property PDashstyle() As DashStyle
		Get
			Return d_style
		End Get
		Set(value As DashStyle)
			If Not value = d_style Then
				d_style = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private st_cap As LineCap = LineCap.Flat
	Public Property PStartCap() As LineCap
		Get
			Return st_cap
		End Get
		Set(value As LineCap)
			If Not value = st_cap Then
				st_cap = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private end_cap As LineCap = LineCap.Flat
	Public Property PEndCap() As LineCap
		Get
			Return end_cap
		End Get
		Set(value As LineCap)
			If Not value = end_cap Then
				end_cap = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private l_join As LineJoin = LineJoin.Miter
	Public Property PLineJoin() As LineJoin
		Get
			Return l_join
		End Get
		Set(value As LineJoin)
			If Not value = l_join Then
				l_join = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private scale_x As Single = 1
	Public Property ScaleX() As Single
		Get
			Return scale_x
		End Get
		Set(value As Single)
			If Not value = scale_x Then
				scale_x = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private scale_y As Single = 1
	Public Property ScaleY() As Single
		Get
			Return scale_y
		End Get
		Set(value As Single)
			If Not value = scale_y Then
				scale_y = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property
#End Region

#Region "Clone"
	''' <summary>
	''' Creates an exact copy of this <see cref="MyPen"/> object.
	''' </summary>
	Public Function Clone() As Object Implements ICloneable.Clone
		Dim _new As New MyPen
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyPen))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		_new.PBrush = PBrush.Clone
		Return _new
	End Function
#End Region

End Class
