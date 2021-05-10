Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class MovablePanel
	Inherits Panel

#Region "New"
	Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
	End Sub
#End Region

#Region "Declarations"
	Private m_pt As Point
	Private m_cl As Boolean
	Private m_op = -1
	Private r_up As Rectangle
	Private r_down As Rectangle
	Private r_cls As Rectangle
#End Region

#Region "Properties"
	Private _txt As String = "Title"
	<Browsable(True)>
	<DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
	<EditorBrowsable(EditorBrowsableState.Always)>
	<Bindable(True)>
	Public Overrides Property Text() As String
		Get
			Return _txt
		End Get
		Set(value As String)
			_txt = value
			Invalidate()
		End Set
	End Property

	Private _res As Boolean = True
	<DefaultValue(GetType(Boolean), "True")>
	Public Property Resizable() As Boolean
		Get
			Return _res
		End Get
		Set(value As Boolean)
			_res = value
		End Set
	End Property
#End Region

#Region "Mouse Events"
	Private Sub MovablePanel_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		m_pt = e.Location
		If r_cls.Contains(e.Location) Then
			Visible = False
		ElseIf r_up.Contains(e.Location) Then
			m_op = 1
		ElseIf r_down.Contains(e.Location) Then
			m_pt.Y = Height - e.Y
			m_op = 2
		End If
	End Sub

	Private Sub MovablePanel_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		If m_op = 1 Then
			Location = New Point(e.X + Location.X - m_pt.X,
								 e.Y + Location.Y - m_pt.Y)
		ElseIf m_op = 2 AndAlso Resizable Then
			Height = e.Y + m_pt.Y
			Invalidate()
		ElseIf r_down.Contains(e.Location) AndAlso Resizable Then
			Cursor = Cursors.SizeNS
		Else
			Cursor = Cursors.Default
			m_cl = r_cls.Contains(e.Location)
			Invalidate()
		End If
	End Sub

	Private Sub MovablePanel_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		m_op = -1
	End Sub

	Private Sub MovablePanel_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
		m_cl = False
		Invalidate()
	End Sub
#End Region

#Region "Paint"
	Private Sub MovablePanel_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.AntiAlias

		g.FillRectangle(New SolidBrush(BackColor), ClientRectangle)

		'Draw title
		Dim sf As New StringFormat()
		sf.Alignment = StringAlignment.Near
		sf.LineAlignment = StringAlignment.Center
		g.DrawString(Text, Font, New SolidBrush(ForeColor), r_up, sf)

		'Draw Cross
		If m_cl Then
			g.FillRectangle(New SolidBrush(Color.FromArgb(150, 150, 150)),
							r_cls)
		End If
		Dim rt = New PointF(r_cls.X + (r_cls.Width / 2),
						   r_cls.Y + (r_cls.Height / 2))
		Dim r_cl = New RectangleF(rt, SizeF.Empty)
		r_cl.Inflate(5, 5)
		g.DrawLine(New Pen(ForeColor, 2),
				   New PointF(r_cl.X, r_cl.Y),
				   New PointF(r_cl.Right, r_cl.Bottom))
		g.DrawLine(New Pen(ForeColor, 2),
				   New PointF(r_cl.Right, r_cl.Y),
				   New PointF(r_cl.X, r_cl.Bottom))

		'Draw bottom anchor
		rt = New PointF(r_down.X + (r_down.Width / 2),
					   r_down.Y + (r_down.Height / 2))
		Dim r_bt = New RectangleF(rt, Size.Empty)
		r_bt.Inflate(10, 5)
		For i = r_bt.X To r_bt.Right Step 2
			g.DrawLine(New Pen(ForeColor),
					   New Point(i, r_bt.Y + 2),
					   New Point(i, r_bt.Bottom - 4))
		Next

		'Draw inner border
		Dim r_in As Rectangle = New Rectangle(0, r_up.Bottom, Width - 1, Height - (r_up.Height + r_down.Height + 1))
		g.FillRectangle(New SolidBrush(Color.FromArgb(30, 30, 30)), r_in)
		g.DrawRectangle(Pens.Black, r_in)

		'Draw border
		Dim b_rect As Rectangle = ClientRectangle
		b_rect.Width -= 1 : b_rect.Height -= 1
		g.DrawRectangle(Pens.Black, b_rect)
	End Sub
#End Region

#Region "Resize"
	Private Sub MovablePanel_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		r_up = New Rectangle(0, 0, Width, Font.Height + 4)
		r_cls = New Rectangle(Width - r_up.Height, 0, r_up.Height, r_up.Height)
		r_down = New Rectangle(0, Height - 10, Width, 10)
	End Sub
#End Region
End Class
