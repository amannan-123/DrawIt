#Region "Imports"
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
#End Region

#Region "MyTabControl"
''' <summary>
''' Custom drawn <see cref="TabControl"/> with close button on tabs.
''' </summary>
<Description("Custom drawn TabControl with close button on tabs.")>
Public Class MyTabControl
	Inherits TabControl

	Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.UserPaint, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
	End Sub

	Private hit As Integer = -1
	Private del As Integer = -1
	Private cl_size As New Size(10, 10)

	''' <summary>
	''' Occurs before tabpage is removed by clicking on cross icon.
	''' </summary>
	<Description("Occurs before tabpage is removed by clicking on cross icon.")>
	Public Event TabRemoving(sender As Object, e As TabRemovingEventArgs)

	Private _min As Integer = 1
	''' <summary>
	''' The minimum number of tabpages on control.
	''' </summary>
	<DefaultValue(1)>
	<Description("The minimum number of tabpages on control.")>
	Public Property MinimumTabs() As Integer
		Get
			Return _min
		End Get
		Set(ByVal value As Integer)
			If value < 0 Then value = 0
			_min = value
		End Set
	End Property

	Private _back As Color = Color.FromArgb(45, 47, 49)
	<EditorBrowsable(EditorBrowsableState.Always)>
	<Browsable(True)>
	<DefaultValue(GetType(Color), "45, 47, 49")>
	Public Overrides Property BackColor() As Color
		Get
			Return _back
		End Get
		Set(ByVal value As Color)
			_back = value
			Invalidate()
		End Set
	End Property

	Private _fore As Color = Color.White
	<EditorBrowsable(EditorBrowsableState.Always)>
	<Browsable(True)>
	<DefaultValue(GetType(Color), "White")>
	Public Overrides Property ForeColor() As Color
		Get
			Return _fore
		End Get
		Set(ByVal value As Color)
			_fore = value
			Invalidate()
		End Set
	End Property

	Private _sback As Color = Color.FromArgb(35, 168, 109)
	''' <summary>
	''' Color of tabpage button in selected state.
	''' </summary>
	<DefaultValue(GetType(Color), "35, 168, 109")>
	<Description("Color of tabpage button in selected state.")>
	Public Property SelectedTabColor() As Color
		Get
			Return _sback
		End Get
		Set(ByVal value As Color)
			_sback = value
			Invalidate()
		End Set
	End Property

	Private _nback As Color = Color.FromArgb(45, 47, 49)
	''' <summary>
	''' Color of tabpage button in normal state.
	''' </summary>
	<DefaultValue(GetType(Color), "45, 47, 49")>
	<Description("Color of tabpage button in normal state.")>
	Public Property NormalTabColor() As Color
		Get
			Return _nback
		End Get
		Set(ByVal value As Color)
			_nback = value
			Invalidate()
		End Set
	End Property

	Private Function TabInCursor(_pt As Point) As Integer
		Dim _hit As Integer = -1
		For i As Integer = 0 To TabCount - 1
			Dim BaseRect = GetTabRect(i)
			If BaseRect.Contains(_pt) Then _hit = i
		Next
		Return _hit
	End Function

	Private Function CloseInCursor(_pt As Point) As Integer
		Dim _del As Integer = -1
		For i As Integer = 0 To TabCount - 1
			Dim BaseRect = GetCloseRect(i)
			If BaseRect.Contains(_pt) Then _del = i
		Next
		Return _del
	End Function

	Private Function GetCloseRect(i As Integer) As RectangleF
		Dim rect As RectangleF
		Dim baserect As Rectangle = GetTabRect(i)
		rect.X = baserect.Right - cl_size.Width - 3
		rect.Y = baserect.Y + (baserect.Height / 2) - (cl_size.Height / 2)
		rect.Width = cl_size.Width
		rect.Height = cl_size.Height
		Select Case Alignment
			Case TabAlignment.Top
				rect.Y += 2
			Case TabAlignment.Bottom
				rect.Y -= 2
			Case TabAlignment.Left, TabAlignment.Right
				rect.Y = baserect.Bottom - cl_size.Width - 3
				rect.X = baserect.X + (baserect.Width / 2) - (cl_size.Height / 2)
				rect.X += 2
			Case TabAlignment.Right
				rect.Y = baserect.Bottom - cl_size.Width - 3
				rect.X = baserect.X + (baserect.Width / 2) - (cl_size.Height / 2)
				rect.X -= 2
		End Select
		rect.Inflate(2, 2)
		Return rect
	End Function

	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		Dim cl As Integer = CloseInCursor(e.Location)
		If cl > -1 AndAlso TabPages.Count > MinimumTabs Then
			Dim tcc As New TabRemovingEventArgs(cl, TabPages(cl), False)
			RaiseEvent TabRemoving(Me, tcc)
			If Not tcc.Cancel Then
				Dim tp = TabPages(cl)
				If DesignMode Then
					'Notify property grid that control is modified.

					'save refrence to old property
					Dim old_p = TabPages
					'get property to be changed
					Dim member = TypeDescriptor.GetProperties(Me)("TabPages")
					'get component change service
					Dim m_changeService = CType(GetService(GetType(IComponentChangeService)), IComponentChangeService)
					'get designer host
					Dim host = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
					'create transaction
					Dim t = host.CreateTransaction()
					'initate change
					m_changeService.OnComponentChanging(Me, member)
					'remove tabpage
					TabPages.Remove(tp)
					'destroy tabpage
					host.DestroyComponent(tp)
					'commit change
					t.Commit()
					'finalize change
					m_changeService.OnComponentChanged(Me, member, old_p, TabPages)
				Else
					TabPages.Remove(tp)
				End If
				End If
			End If
		MyBase.OnMouseDown(e)
	End Sub

	Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
		hit = TabInCursor(e.Location)
		del = CloseInCursor(e.Location)
		Invalidate()
		MyBase.OnMouseMove(e)
	End Sub

	Protected Overrides Sub OnMouseLeave(e As EventArgs)
		hit = -1
		del = -1
		Invalidate()
		MyBase.OnMouseLeave(e)
	End Sub

	Protected Overrides Sub OnPaint(e As PaintEventArgs)

		Dim _bmp = New Bitmap(Width, Height)
		Dim g = Graphics.FromImage(_bmp)

		g.SmoothingMode = SmoothingMode.AntiAlias

		Dim sf As New StringFormat()
		sf.Alignment = StringAlignment.Center
		sf.LineAlignment = StringAlignment.Center
		sf.Trimming = StringTrimming.EllipsisWord

		For i As Integer = 0 To TabCount - 1

			Dim BaseRect = GetTabRect(i)

			Select Case Alignment
				Case TabAlignment.Top
					If i = 0 Then
						BaseRect.X += 2
						BaseRect.Width -= 2
					End If
					BaseRect.Y += 2
				Case TabAlignment.Bottom
					If i = 0 Then
						BaseRect.X += 2
						BaseRect.Width -= 2
					End If
					BaseRect.Y -= 2
				Case TabAlignment.Left
					BaseRect.X += 2
					If i = 0 Then
						BaseRect.Y += 2
						BaseRect.Height -= 2
					End If
					sf.FormatFlags = StringFormatFlags.DirectionVertical
				Case TabAlignment.Right
					BaseRect.X -= 2
					If i = 0 Then
						BaseRect.Y += 2
						BaseRect.Height -= 2
					End If
					sf.FormatFlags = StringFormatFlags.DirectionVertical
			End Select

			'Fill tab button
			Dim _clr As Color = NormalTabColor
			If i = hit Then _clr = ControlPaint.Light(SelectedTabColor, 0.1)
			If i = SelectedIndex Then _clr = SelectedTabColor
			g.FillRectangle(New SolidBrush(_clr), BaseRect)

			'Draw text
			Dim textrect As Rectangle = BaseRect
			Dim t_size = g.MeasureString(TabPages(i).Text, Font)
			Select Case Alignment
				Case TabAlignment.Top, TabAlignment.Bottom
					textrect.Width -= (cl_size.Width + 2)
					textrect.Height = t_size.Height
					textrect.Y = BaseRect.Y + (BaseRect.Height / 2) - (t_size.Height / 2)
				Case TabAlignment.Left, TabAlignment.Right
					textrect.Height -= (cl_size.Width + 2)
					textrect.Width = t_size.Height
					textrect.X = BaseRect.X + (BaseRect.Width / 2) - (t_size.Height / 2)
			End Select
			g.DrawString(TabPages(i).Text, Font, New SolidBrush(ForeColor), textrect, sf)

			Dim cl_rect = GetCloseRect(i)

			'Fill close rect
			If del = i Then
				Dim cl_col = ControlPaint.Dark(SelectedTabColor, 0.1)
				g.FillRectangle(New SolidBrush(cl_col), cl_rect)
			End If

			'Draw cross
			cl_rect.Inflate(-3.5, -3.5)
			Dim p1 As PointF = cl_rect.Location
			Dim p2 As New PointF(cl_rect.Right, cl_rect.Bottom)
			Dim p3 As New PointF(cl_rect.Right, cl_rect.Y)
			Dim p4 As New PointF(cl_rect.X, cl_rect.Bottom)

			g.DrawLine(New Pen(ForeColor), p1, p2)
			g.DrawLine(New Pen(ForeColor), p3, p4)

		Next

		sf.FormatFlags = StringFormatFlags.DisplayFormatControl
		If TabPages.Count = 0 Then
			g.DrawString("Please insert tab!", New Font("Segoe UI", 20), New SolidBrush(ForeColor), ClientRectangle, sf)
		End If

		g.Dispose()

		If Enabled Then
			e.Graphics.DrawImageUnscaled(_bmp, 0, 0)
		Else

			ControlPaint.DrawImageDisabled(e.Graphics, _bmp, 0, 0, BackColor)
		End If

		_bmp.Dispose()
		MyBase.OnPaint(e)

	End Sub

End Class
#End Region

#Region "TabRemovingEventArgs"
''' <summary>
''' Provides data for the <see cref='MyTabControl.TabRemovingEvent'/> event of <see cref='MyTabControl'/> control.
''' </summary>
Public Class TabRemovingEventArgs
	Inherits CancelEventArgs

	Sub New(i As Integer, p As TabPage, c As Boolean)
		_index = i
		Cancel = c
	End Sub

	Private _index As Integer = -1
	''' <summary>
	''' Stores the index to the tabpage that is undergoing the TabControl event.
	''' </summary>
	Public ReadOnly Property Index() As Integer
		Get
			Return _index
		End Get
	End Property

	Private _page As TabPage = Nothing
	''' <summary>
	''' Stores the referemce to the tabpage that is undergoing the TabControl event.
	''' </summary>
	Public ReadOnly Property TabPage() As TabPage
		Get
			Return _page
		End Get
	End Property
End Class
#End Region