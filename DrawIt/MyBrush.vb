Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices

<Serializable>
Public Class MyBrush
	Implements INotifyPropertyChanged, ICloneable

#Region "Event"
	<NonSerialized>
	Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

	Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As String = "")
		RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
	End Sub
#End Region

#Region "Type"
	Public Enum BrushType
		Solid
		LinearGradient
		PathGradient
		Hatch
		Texture
	End Enum

	Private sty As BrushType = BrushType.Solid
	Public Property BType() As BrushType
		Get
			Return sty
		End Get
		Set(value As BrushType)
			If Not value = sty Then
				sty = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property
#End Region

#Region "Solid"
	Private _sld As Color = Color.White
	Public Property SolidColor() As Color
		Get
			Return _sld
		End Get
		Set(value As Color)
			If Not value = _sld Then
				_sld = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property
#End Region

#Region "LinearGradient"
	Private _lg1 As Color = Color.White
	Public Property LColor1() As Color
		Get
			Return _lg1
		End Get
		Set(value As Color)
			If Not value = _lg1 Then
				_lg1 = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _lg2 As Color = Color.Black
	Public Property LColor2() As Color
		Get
			Return _lg2
		End Get
		Set(value As Color)
			If Not value = _lg2 Then
				_lg2 = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private l_angle As Integer = 0
	Public Property LinearAngle() As Integer
		Get
			Return l_angle
		End Get
		Set(value As Integer)
			If Not value = l_angle Then
				l_angle = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _gamma As Boolean = False
	Public Property LGamma() As Boolean
		Get
			Return _gamma
		End Get
		Set(value As Boolean)
			If Not value = _gamma Then
				_gamma = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _tri As Boolean = False
	Public Property LTriangular() As Boolean
		Get
			Return _tri
		End Get
		Set(value As Boolean)
			If Not value = _tri Then
				If value Then LBell = False
				_tri = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private tri_f As Single = 0.5
	Public Property LTriFocus() As Single
		Get
			Return tri_f
		End Get
		Set(value As Single)
			If Not value = tri_f Then
				tri_f = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private tri_s As Single = 1
	Public Property LTriScale() As Single
		Get
			Return tri_s
		End Get
		Set(value As Single)
			If Not value = tri_s Then
				tri_s = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _bell As Boolean = False
	Public Property LBell() As Boolean
		Get
			Return _bell
		End Get
		Set(value As Boolean)
			If Not value = _bell Then
				If value Then LTriangular = False
				_bell = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private bell_f As Single = 0.5
	Public Property LBellFocus() As Single
		Get
			Return bell_f
		End Get
		Set(value As Single)
			If Not value = bell_f Then
				bell_f = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private bell_s As Single = 1
	Public Property LBellScale() As Single
		Get
			Return bell_s
		End Get
		Set(value As Single)
			If Not value = bell_s Then
				bell_s = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private l_inter As Boolean = False
	Public Property LInterpolate() As Boolean
		Get
			Return l_inter
		End Get
		Set(value As Boolean)
			If Not value = l_inter Then
				If value Then LBlend = False
				l_inter = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private l_intcol As Color() = New Color() {Color.White, Color.Black}
	Public Property LInterColors() As Color()
		Get
			Return l_intcol
		End Get
		Set(value As Color())
			If Not value.SequenceEqual(l_intcol) Then
				l_intcol = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private l_intpol As Single() = New Single() {0, 1}
	Public Property LInterPositions() As Single()
		Get
			Return l_intpol
		End Get
		Set(value As Single())
			If Not value.SequenceEqual(l_intpol) Then
				l_intpol = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private l_blend As Boolean = False
	Public Property LBlend() As Boolean
		Get
			Return l_blend
		End Get
		Set(value As Boolean)
			If Not value = l_blend Then
				If value Then LInterpolate = False
				l_blend = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private l_bldfac As Single() = New Single() {0, 1}
	Public Property LBlendFactors() As Single()
		Get
			Return l_bldfac
		End Get
		Set(value As Single())
			If Not value.SequenceEqual(l_bldfac) Then
				l_bldfac = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private l_bldpos As Single() = New Single() {0, 1}
	Public Property LBlendPositions() As Single()
		Get
			Return l_bldpos
		End Get
		Set(value As Single())
			If Not value.SequenceEqual(l_bldpos) Then
				l_bldpos = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property
#End Region

#Region "PathGradient"
	Private _pg1 As Color = Color.White
	Public Property PCenter() As Color
		Get
			Return _pg1
		End Get
		Set(value As Color)
			If Not value = _pg1 Then
				_pg1 = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _pg2 As Color() = New Color() {Color.Black}
	Public Property PSurround() As Color()
		Get
			Return _pg2
		End Get
		Set(value As Color())
			If Not value.SequenceEqual(_pg2) Then
				_pg2 = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_cent As PointF = New PointF(50, 50)
	Public Property PCenterPoint() As PointF
		Get
			Return p_cent
		End Get
		Set(value As PointF)
			If Not value = p_cent Then
				p_cent = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private pfoc_x As Single = 0
	Public Property PFocusX() As Single
		Get
			Return pfoc_x
		End Get
		Set(value As Single)
			If Not value = pfoc_x Then
				pfoc_x = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private pfoc_y As Single = 0
	Public Property PFocusY() As Single
		Get
			Return pfoc_y
		End Get
		Set(value As Single)
			If Not value = pfoc_y Then
				pfoc_y = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_tri As Boolean = False
	Public Property PTriangular() As Boolean
		Get
			Return p_tri
		End Get
		Set(value As Boolean)
			If Not value = p_tri Then
				If value Then PBell = False
				p_tri = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private ptri_f As Single = 0.5
	Public Property PTriFocus() As Single
		Get
			Return ptri_f
		End Get
		Set(value As Single)
			If Not value = ptri_f Then
				ptri_f = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private ptri_s As Single = 1
	Public Property PTriScale() As Single
		Get
			Return ptri_s
		End Get
		Set(value As Single)
			If Not value = ptri_s Then
				ptri_s = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_bell As Boolean = False
	Public Property PBell() As Boolean
		Get
			Return p_bell
		End Get
		Set(value As Boolean)
			If Not value = p_bell Then
				If value Then PTriangular = False
				p_bell = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private pbell_f As Single = 0.5
	Public Property PBellFocus() As Single
		Get
			Return pbell_f
		End Get
		Set(value As Single)
			If Not value = pfoc_x Then
				pbell_f = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private pbell_s As Single = 1
	Public Property PBellScale() As Single
		Get
			Return pbell_s
		End Get
		Set(value As Single)
			If Not value = pfoc_x Then
				pbell_s = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_inter As Boolean = False
	Public Property PInterpolate() As Boolean
		Get
			Return p_inter
		End Get
		Set(value As Boolean)
			If Not value = p_inter Then
				If value Then PBlend = False
				p_inter = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_intcol As Color() = New Color() {Color.Black, Color.White}
	Public Property PInterColors() As Color()
		Get
			Return p_intcol
		End Get
		Set(value As Color())
			If Not value.SequenceEqual(p_intcol) Then
				p_intcol = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_intpol As Single() = New Single() {0, 1}
	Public Property PInterPositions() As Single()
		Get
			Return p_intpol
		End Get
		Set(value As Single())
			If Not value.SequenceEqual(p_intpol) Then
				p_intpol = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_blend As Boolean = False
	Public Property PBlend() As Boolean
		Get
			Return p_blend
		End Get
		Set(value As Boolean)
			If Not value = p_blend Then
				If value Then PInterpolate = False
				p_blend = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_bldfac As Single() = New Single() {0, 1}
	Public Property PBlendFactors() As Single()
		Get
			Return p_bldfac
		End Get
		Set(value As Single())
			If Not value.SequenceEqual(p_bldfac) Then
				p_bldfac = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private p_bldpos As Single() = New Single() {0, 1}
	Public Property PBlendPositions() As Single()
		Get
			Return p_bldpos
		End Get
		Set(value As Single())
			If Not value.SequenceEqual(p_bldpos) Then
				p_bldpos = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property
#End Region

#Region "Hatch"
	Private _hb1 As Color = Color.White
	Public Property HBack() As Color
		Get
			Return _hb1
		End Get
		Set(value As Color)
			If Not value = _hb1 Then
				_hb1 = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _hb2 As Color = Color.Black
	Public Property HFore() As Color
		Get
			Return _hb2
		End Get
		Set(value As Color)
			If Not value = _hb2 Then
				_hb2 = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private _hst As HatchStyle = HatchStyle.Horizontal
	Public Property HStyle() As HatchStyle
		Get
			Return _hst
		End Get
		Set(value As HatchStyle)
			If Not value = _hst Then
				_hst = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property
#End Region

#Region "Texture"
	Private t_img As Image = Nothing
	Public Property TImage() As Image
		Get
			Return t_img
		End Get
		Set(value As Image)
			t_img = value
			NotifyPropertyChanged()
		End Set
	End Property

	Private t_trn As Boolean = False
	Public Property TTransparency() As Boolean
		Get
			Return t_trn
		End Get
		Set(value As Boolean)
			If Not value = t_trn Then
				t_trn = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private t_col As Color = Color.White
	Public Property TColor() As Color
		Get
			Return t_col
		End Get
		Set(value As Color)
			If Not value = t_col Then
				t_col = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property

	Private t_rot As RotateFlipType = RotateFlipType.RotateNoneFlipNone
	Public Property TRotateFlip() As RotateFlipType
		Get
			Return t_rot
		End Get
		Set(value As RotateFlipType)
			If Not value = t_rot Then
				t_rot = value
				NotifyPropertyChanged()
			End If
		End Set
	End Property
#End Region

#Region "Clone"
	''' <summary>
	''' Creates an exact copy of this <see cref="MyBrush"/> object.
	''' </summary>
	Public Function Clone() As Object Implements ICloneable.Clone
		Dim _new As New MyBrush
		For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(MyBrush))
			pd.SetValue(_new, pd.GetValue(Me))
		Next
		Return _new
	End Function
#End Region

End Class
