Imports System.ComponentModel

<Serializable>
Public Class MyShadow

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

	Private _off As Point = New Point(10, 10)
	Public Property Offset() As Point
		Get
			Return _off
		End Get
		Set(value As Point)
			_off = value
		End Set
	End Property

	Private _fill As Boolean = True
	Public Property Fill() As Boolean
		Get
			Return _fill
		End Get
		Set(value As Boolean)
			_fill = value
		End Set
	End Property

	Private _clip As Boolean = True
	Public Property RegionClipping() As Boolean
		Get
			Return _clip
		End Get
		Set(value As Boolean)
			_clip = value
		End Set
	End Property

	Private _blur As Integer = 2
	Public Property Blur() As Integer
		Get
			Return _blur
		End Get
		Set(value As Integer)
			_blur = value
		End Set
	End Property

	Private _feather As Integer = 100
	Public Property Feather() As Integer
		Get
			Return _feather
		End Get
		Set(value As Integer)
			_feather = value
		End Set
	End Property

	Private _clr As Color = Color.Gray
	Public Property ShadowColor() As Color
		Get
			Return _clr
		End Get
		Set(value As Color)
			_clr = value
		End Set
	End Property
#End Region

#Region "Clone"
	Public Function Clone() As MyShadow
		Dim _new As New MyShadow
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyShadow))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		Return _new
	End Function
#End Region

End Class
