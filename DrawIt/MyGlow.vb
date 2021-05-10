Imports System.ComponentModel

<Serializable>
Public Class MyGlow

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

#Region "Properties"
	Private _enabled As Boolean = False
	Public Property Enabled() As Boolean
		Get
			Return _enabled
		End Get
		Set(value As Boolean)
			_enabled = value
		End Set
	End Property

	Private _style As GlowStyle = GlowStyle.OnShape
	Public Property GStyle() As GlowStyle
		Get
			Return _style
		End Get
		Set(value As GlowStyle)
			_style = value
		End Set
	End Property

	Private _clip As Clip = Clip.None
	Public Property GClip() As Clip
		Get
			Return _clip
		End Get
		Set(value As Clip)
			_clip = value
		End Set
	End Property

	Private _before As Boolean = True
	Public Property BeforeFill() As Boolean
		Get
			Return _before
		End Get
		Set(value As Boolean)
			_before = value
		End Set
	End Property

	Private _glow As Integer = 35
	Public Property Glow() As Integer
		Get
			Return _glow
		End Get
		Set(value As Integer)
			_glow = value
		End Set
	End Property

	Private _feather As Integer = 35
	Public Property Feather() As Integer
		Get
			Return _feather
		End Get
		Set(value As Integer)
			_feather = value
		End Set
	End Property

	Private _clr As Color = Color.Red
	Public Property GlowColor() As Color
		Get
			Return _clr
		End Get
		Set(value As Color)
			_clr = value
		End Set
	End Property
#End Region

#Region "Clone"
	Public Function Clone() As MyGlow
		Dim _new As New MyGlow
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyGlow))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		Return _new
	End Function
#End Region

End Class
