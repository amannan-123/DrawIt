Imports System.ComponentModel
Imports System.Runtime.CompilerServices

<Serializable>
Public Class MyGlow
	Implements INotifyPropertyChanged, ICloneable

#Region "Enum"
	Public Enum GlowStyle
		OnShape
		OnBorder
	End Enum

	Public Enum Clip
		None
		Inside
		Outside
	End Enum

#End Region

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

	Private _style As GlowStyle = GlowStyle.OnShape
	Public Property GStyle() As GlowStyle
		Get
			Return _style
		End Get
		Set(value As GlowStyle)
			If Not value = _style Then
				_style = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _clip As Clip = Clip.None
	Public Property GClip() As Clip
		Get
			Return _clip
		End Get
		Set(value As Clip)
			If Not value = _clip Then
				_clip = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _before As Boolean = True
	Public Property BeforeFill() As Boolean
		Get
			Return _before
		End Get
		Set(value As Boolean)
			If Not value = _before Then
				_before = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _glow As Integer = 35
	Public Property Glow() As Integer
		Get
			Return _glow
		End Get
		Set(value As Integer)
			If Not value = _glow Then
				_glow = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _feather As Integer = 35
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

	Private _clr As Color = Color.Red
	Public Property GlowColor() As Color
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
	''' Creates an exact copy of this <see cref="MyGlow"/> object.
	''' </summary>
	Public Function Clone() As Object Implements ICloneable.Clone
		Dim _new As New MyGlow
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyGlow))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		Return _new
	End Function
#End Region

End Class
