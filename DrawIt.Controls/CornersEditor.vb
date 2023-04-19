Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports DrawIt.Helpers

<DefaultEvent("CornersChanged")>
<DefaultProperty("Corners")>
Public Class CornersEditor

#Region "Enum"
	Public Enum CornerType
		T1
		T2
		R1
		R2
		B1
		B2
		L1
		L2
		None = -1
	End Enum
#End Region

#Region "New"
	Sub New()
		InitializeComponent()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
		_lst = {25, 75, 25, 75, 25, 75, 25, 75}
	End Sub
#End Region

#Region "Globals"
	Private Const pSize As Single = 5
	Private s_cn As CornerType = CornerType.None
	Private m_pt As PointF
	Private m_down As Boolean = False
	Private m_ent As Boolean = False
	Private rect As RectangleF
#End Region

#Region "Event"
	Public Event CornersChanged(sender As Object, e As EventArgs)
	Public Event CornerTypeChanged(sender As Object, e As EventArgs)
#End Region

#Region "Properties"
	Private _lst(8) As Single
	Public Property Corners() As Single()
		Get
			Return _lst
		End Get
		Set(value As Single())
			_lst = value
			Invalidate()
		End Set
	End Property

	Private ul_tp As Boolean = False
	Public Property ULReversed() As Boolean
		Get
			Return ul_tp
		End Get
		Set(value As Boolean)
			ul_tp = value
			Invalidate()
			RaiseEvent CornerTypeChanged(Me, New EventArgs)
		End Set
	End Property

	Private ur_tp As Boolean = False
	Public Property URReversed() As Boolean
		Get
			Return ur_tp
		End Get
		Set(value As Boolean)
			ur_tp = value
			Invalidate()
			RaiseEvent CornerTypeChanged(Me, New EventArgs)
		End Set
	End Property

	Private bl_tp As Boolean = False
	Public Property BLReversed() As Boolean
		Get
			Return bl_tp
		End Get
		Set(value As Boolean)
			bl_tp = value
			Invalidate()
			RaiseEvent CornerTypeChanged(Me, New EventArgs)
		End Set
	End Property

	Private br_tp As Boolean = False
	Public Property BRReversed() As Boolean
		Get
			Return br_tp
		End Get
		Set(value As Boolean)
			br_tp = value
			Invalidate()
			RaiseEvent CornerTypeChanged(Me, New EventArgs)
		End Set
	End Property
#End Region

#Region "Helper Functions"
	Private Function CPath(ind As Integer) As GraphicsPath
		Dim rt As RectangleF
		Select Case ind
			Case 0
				rt = New RectangleF(MathUtils.FromPercentage(rect.X, rect.Right, _lst(0)),
									rect.Y, 0, 0)
				rt.Y -= pSize
			Case 1
				rt = New RectangleF(MathUtils.FromPercentage(rect.X, rect.Right, _lst(1)),
									rect.Y, 0, 0)
				rt.Y -= pSize
			Case 2
				rt = New RectangleF(rect.Right,
									MathUtils.FromPercentage(rect.Y, rect.Bottom, _lst(2)),
									0, 0)
				rt.X += pSize
			Case 3
				rt = New RectangleF(rect.Right,
									MathUtils.FromPercentage(rect.Y, rect.Bottom, _lst(3)),
									0, 0)
				rt.X += pSize
			Case 4
				rt = New RectangleF(MathUtils.FromPercentage(rect.X, rect.Right, _lst(4)),
									rect.Bottom, 0, 0)
				rt.Y += pSize
			Case 5
				rt = New RectangleF(MathUtils.FromPercentage(rect.X, rect.Right, _lst(5)),
									rect.Bottom, 0, 0)
				rt.Y += pSize
			Case 6
				rt = New RectangleF(rect.X,
									MathUtils.FromPercentage(rect.Y, rect.Bottom, _lst(6)),
									0, 0)
				rt.X -= pSize
			Case 7
				rt = New RectangleF(rect.X,
									MathUtils.FromPercentage(rect.Y, rect.Bottom, _lst(7)),
									0, 0)
				rt.X -= pSize
		End Select
		rt.Inflate(pSize, pSize)
		Dim pth As New GraphicsPath
		pth.AddRectangle(rt)
		Return pth
	End Function

	Private Function PathInCursor(ept As PointF) As Integer
		For i As Integer = 0 To 7
			If CPath(i).IsVisible(ept) Then Return i
		Next
		Return -1
	End Function

	Private Sub SetRect()
		rect = New RectangleF(25, 25, Width - 51, Height - 51)
	End Sub
#End Region

#Region "Mouse Events"
	Private Sub CornersEditor_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		m_pt = e.Location
		Dim curr As Integer = PathInCursor(m_pt)
		If curr > -1 Then
			m_down = True
			s_cn = curr
		Else
			s_cn = -1
		End If
		Invalidate()
	End Sub

	Private Sub CornersEditor_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		If m_down Then
			Cursor = Cursors.SizeAll
			Dim x_pt = MathUtils.ToPercentage(rect.X, rect.Right, e.X)
			Dim y_pt = MathUtils.ToPercentage(rect.Y, rect.Bottom, e.Y)

			If My.Computer.Keyboard.CtrlKeyDown Then
				x_pt = CInt(x_pt)
				y_pt = CInt(y_pt)
			End If

			Select Case s_cn
				Case 0
					If x_pt < 0 Or x_pt > 100 Then Return
					If x_pt <= _lst(1) Then
						_lst(0) = x_pt
						If My.Computer.Keyboard.AltKeyDown Then
							_lst(6) = x_pt
							If _lst(7) < _lst(6) Then _lst(7) = _lst(6)
						End If
					End If
				Case 1
					If x_pt < 0 Or x_pt > 100 Then Return
					If x_pt >= _lst(0) Then
						_lst(1) = x_pt
						If My.Computer.Keyboard.AltKeyDown Then
							_lst(2) = 100 - x_pt
							If _lst(3) < _lst(2) Then _lst(3) = _lst(2)
						End If
					End If
				Case 2
					If y_pt < 0 Or y_pt > 100 Then Return
					If y_pt <= _lst(3) Then
						_lst(2) = y_pt
						If My.Computer.Keyboard.AltKeyDown Then
							_lst(1) = 100 - y_pt
							If _lst(0) > _lst(1) Then _lst(0) = _lst(1)
						End If
					End If
				Case 3
					If y_pt < 0 Or y_pt > 100 Then Return
					If y_pt >= _lst(2) Then
						_lst(3) = y_pt
						If My.Computer.Keyboard.AltKeyDown Then
							_lst(5) = y_pt
							If _lst(4) > _lst(5) Then _lst(4) = _lst(5)
						End If
					End If
				Case 4
					If x_pt < 0 Or x_pt > 100 Then Return
					If x_pt <= _lst(5) Then
						_lst(4) = x_pt
						If My.Computer.Keyboard.AltKeyDown Then
							_lst(7) = 100 - x_pt
							If _lst(6) > _lst(7) Then _lst(6) = _lst(7)
						End If
					End If
				Case 5
					If x_pt < 0 Or x_pt > 100 Then Return
					If x_pt >= _lst(4) Then
						_lst(5) = x_pt
						If My.Computer.Keyboard.AltKeyDown Then
							_lst(3) = x_pt
							If _lst(2) > _lst(3) Then _lst(2) = _lst(3)
						End If
					End If
				Case 6
					If y_pt < 0 Or y_pt > 100 Then Return
					If y_pt <= _lst(7) Then
						_lst(6) = y_pt
						If My.Computer.Keyboard.AltKeyDown Then
							_lst(0) = y_pt
							If _lst(1) < _lst(0) Then _lst(1) = _lst(0)
						End If
					End If
				Case 7
					If y_pt < 0 Or y_pt > 100 Then Return
					If y_pt >= _lst(6) Then
						_lst(7) = y_pt
						If My.Computer.Keyboard.AltKeyDown Then
							_lst(4) = 100 - y_pt
							If _lst(5) < _lst(4) Then _lst(5) = _lst(4)
						End If
					End If
			End Select

			RaiseEvent CornersChanged(Me, New EventArgs)
			Invalidate()
		End If
	End Sub

	Private Sub CornersEditor_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		m_down = False
		Cursor = Cursors.Default
	End Sub

	Private Sub CornersEditor_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
		m_ent = True
		Invalidate()
	End Sub

	Private Sub CornersEditor_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
		m_ent = False
		Invalidate()
	End Sub
#End Region

#Region "Drawing"
	Public Function GetRoundedRectPath(rect As RectangleF, crn As Single(),
									   ulc As Boolean, urc As Boolean,
									   blc As Boolean, brc As Boolean) As GraphicsPath
		Dim ArcRect As RectangleF
		Dim _t1 = MathUtils.FromPercentage(0, rect.Width, crn(0))
		Dim _t2 = MathUtils.FromPercentage(0, rect.Width, 100 - crn(1))
		Dim _r1 = MathUtils.FromPercentage(0, rect.Height, crn(2))
		Dim _r2 = MathUtils.FromPercentage(0, rect.Height, 100 - crn(3))
		Dim _b1 = MathUtils.FromPercentage(0, rect.Width, crn(4))
		Dim _b2 = MathUtils.FromPercentage(0, rect.Width, 100 - crn(5))
		Dim _l1 = MathUtils.FromPercentage(0, rect.Height, crn(6))
		Dim _l2 = MathUtils.FromPercentage(0, rect.Height, 100 - crn(7))
		Dim MyPath As New GraphicsPath()
		With MyPath
			' top left arc
			If _t1 = 0 Or _l1 = 0 Then
				.AddLine(rect.X, rect.Y + _l1, rect.X + _t1, rect.Y)
			Else
				Select Case ulc
					Case 0
						ArcRect = New RectangleF(rect.Location,
											New SizeF(_t1 * 2, _l1 * 2))
						.AddArc(ArcRect, 180, 90)
					Case 1
						ArcRect = New RectangleF(rect.X - _t1, rect.Y - _l1,
											_t1 * 2, _l1 * 2)
						.AddArc(ArcRect, 90, -90)
				End Select
			End If

			' top right arc
			If _t2 = 0 Or _r1 = 0 Then
				.AddLine(rect.Right - _t2, rect.Y, rect.Right, rect.Y + _r1)
			Else
				Select Case urc
					Case 0
						ArcRect = New RectangleF(rect.Location,
											New SizeF(_t2 * 2, _r1 * 2))
						ArcRect.X = rect.Right - ArcRect.Width
						.AddArc(ArcRect, 270, 90)
					Case 1
						ArcRect = New RectangleF(rect.Right - _t2, rect.Y - _r1,
											_t2 * 2, _r1 * 2)
						.AddArc(ArcRect, 180, -90)
				End Select

			End If

			' bottom right arc
			If _b2 = 0 Or _r2 = 0 Then
				.AddLine(rect.Right, rect.Bottom - _r2, rect.Right - _b2, rect.Bottom)
			Else
				Select Case brc
					Case 0
						ArcRect = New RectangleF(rect.Location,
											New SizeF(_b2 * 2, _r2 * 2))
						ArcRect.X = rect.Right - ArcRect.Width
						ArcRect.Y = rect.Bottom - ArcRect.Height
						.AddArc(ArcRect, 0, 90)
					Case 1
						ArcRect = New RectangleF(rect.Right - _b2, rect.Bottom - _r2,
											_b2 * 2, _r2 * 2)
						.AddArc(ArcRect, 270, -90)
				End Select

			End If

			' bottom left arc
			If _b1 = 0 Or _l2 = 0 Then
				.AddLine(rect.X + _b1, rect.Bottom, rect.X, rect.Bottom - _l2)
			Else
				Select Case blc
					Case 0
						ArcRect = New RectangleF(rect.Location,
											New SizeF(_b1 * 2, _l2 * 2)) With {
							.Y = rect.Bottom - (_l2 * 2)
											}
						.AddArc(ArcRect, 90, 90)
					Case 1
						ArcRect = New RectangleF(rect.X - _b1, rect.Bottom - _l2,
											_b1 * 2, _l2 * 2)
						.AddArc(ArcRect, 0, -90)
				End Select

			End If

			.CloseFigure()
		End With

		Return MyPath
	End Function

	Private Sub DrawPoints(g As Graphics)
		For i As Integer = 7 To 0 Step -1
			Dim pth = CPath(i)
			Dim clr = Color.White
			If s_cn = i Then clr = Color.Gray
			g.FillPath(New SolidBrush(clr), pth)
			g.DrawPath(Pens.Black, pth)
		Next
	End Sub

	Private Sub CornersEditor_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.AntiAlias

		Dim pn As New Pen(Color.Gray) With {
			.DashStyle = DashStyle.Dash
		}
		g.DrawRectangle(pn, Rectangle.Ceiling(rect))

		Dim pth As GraphicsPath = GetRoundedRectPath(rect, Corners,
													 ul_tp, ur_tp, bl_tp, br_tp)
		g.DrawPath(Pens.Black, pth)

		If m_ent Then DrawPoints(g)

		Dim curr = s_cn
		If curr > -1 Then
			Dim str As String
			Select Case curr
				Case 1, 3, 5, 7
					str = curr.ToString & ": " & (100 - _lst(curr)).ToString
				Case Else
					str = curr.ToString & ": " & _lst(curr).ToString
			End Select

			Dim sf As New StringFormat With {
				.Alignment = StringAlignment.Center,
				.LineAlignment = StringAlignment.Center
			}
			Dim rtext As New Rectangle(rect.X, rect.Bottom + pSize, rect.Width, Height - rect.Bottom)
			g.DrawString(str, Font, Brushes.Black, rtext, sf)
		End If

		Dim r_brd As Rectangle = ClientRectangle
		r_brd.Width -= 1 : r_brd.Height -= 1
		g.DrawRectangle(Pens.Black, r_brd)

		pn.Dispose()
	End Sub
#End Region

#Region "Load & Resize"
	Private Sub CornersEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetRect()
	End Sub

	Private Sub CornersEditor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		SetRect()
		Invalidate()
	End Sub
#End Region

#Region "Keyboard Events"
	Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
		Select Case keyData
			Case Keys.Left, Keys.Right, Keys.Up, Keys.Down
				Return True
			Case Else
				Return MyBase.IsInputKey(keyData)
		End Select
	End Function

	Private Sub CornersEditor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		If s_cn > -1 Then
			Select Case e.KeyCode
				Case Keys.Left, Keys.Up
					IncrementSelected(-1)
				Case Keys.Right, Keys.Down
					IncrementSelected(1)
			End Select
		End If
	End Sub

	Private Sub IncrementSelected(_inc As Integer)
		Dim _val = _lst(s_cn)
		_val += _inc
		If (Control.ModifierKeys And Keys.Control) = Keys.Control Then _val = CInt(_val)
		If _val < 0 Or _val > 100 Then Return
		Select Case s_cn
			Case 0
				If _val <= _lst(1) Then
					_lst(0) = _val
					If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
						_lst(6) = _val
						If _lst(7) < _lst(6) Then _lst(7) = _lst(6)
					End If
				End If
			Case 1
				If _val >= _lst(0) Then
					_lst(1) = _val
					If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
						_lst(2) = 100 - _val
						If _lst(3) < _lst(2) Then _lst(3) = _lst(2)
					End If
				End If
			Case 2
				If _val <= _lst(3) Then
					_lst(2) = _val
					If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
						_lst(1) = 100 - _val
						If _lst(0) > _lst(1) Then _lst(0) = _lst(1)
					End If
				End If
			Case 3
				If _val >= _lst(2) Then
					_lst(3) = _val
					If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
						_lst(5) = _val
						If _lst(4) > _lst(5) Then _lst(4) = _lst(5)
					End If
				End If
			Case 4
				If _val <= _lst(5) Then
					_lst(4) = _val
					If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
						_lst(7) = 100 - _val
						If _lst(6) > _lst(7) Then _lst(6) = _lst(7)
					End If
				End If
			Case 5
				If _val >= _lst(4) Then
					_lst(5) = _val
					If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
						_lst(3) = _val
						If _lst(2) > _lst(3) Then _lst(2) = _lst(3)
					End If
				End If
			Case 6
				If _val <= _lst(7) Then
					_lst(6) = _val
					If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
						_lst(0) = _val
						If _lst(1) < _lst(0) Then _lst(1) = _lst(0)
					End If
				End If
			Case 7
				If _val >= _lst(6) Then
					_lst(7) = _val
					If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
						_lst(4) = 100 - _val
						If _lst(5) < _lst(4) Then _lst(5) = _lst(4)
					End If
				End If
		End Select
		RaiseEvent CornersChanged(Me, New EventArgs)
		Invalidate()
	End Sub
#End Region

End Class