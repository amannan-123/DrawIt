Imports System.ComponentModel
Imports System.Runtime.CompilerServices

<Serializable>
Public Class MyShadow
	Implements INotifyPropertyChanged, ICloneable

#Region "Event"
	<NonSerialized>
	Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

	Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As String = "")
		RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
	End Sub
#End Region

#Region "Properties"
	Private _enabled As Boolean = False
	Public Property Enabled() As Boolean
		Get
			Return _enabled
		End Get
		Set(value As Boolean)
			If Not value = _enabled Then
				_enabled = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _off As Point = New Point(10, 10)
	Public Property Offset() As Point
		Get
			Return _off
		End Get
		Set(value As Point)
			If Not value = _off Then
				_off = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _fill As Boolean = True
	Public Property Fill() As Boolean
		Get
			Return _fill
		End Get
		Set(value As Boolean)
			If Not value = _fill Then
				_fill = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _clip As Boolean = True
	Public Property RegionClipping() As Boolean
		Get
			Return _clip
		End Get
		Set(value As Boolean)
			If Not value = _clip Then
				_clip = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _blur As Integer = 2
	Public Property Blur() As Integer
		Get
			Return _blur
		End Get
		Set(value As Integer)
			If Not value = _blur Then
				_blur = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _feather As Integer = 100
	Public Property Feather() As Integer
		Get
			Return _feather
		End Get
		Set(value As Integer)
			If Not value = _feather Then
				_feather = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _clr As Color = Color.Gray
	Public Property ShadowColor() As Color
		Get
			Return _clr
		End Get
		Set(value As Color)
			If Not value = _clr Then
				_clr = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property
#End Region

#Region "Clone"

	''' <summary>
	''' Creates an exact copy of this <see cref="MyShadow"/> object.
	''' </summary>
	Public Function Clone() As Object Implements ICloneable.Clone
		Dim _new As New MyShadow
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyShadow))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		Return _new
	End Function
#End Region

End Class
