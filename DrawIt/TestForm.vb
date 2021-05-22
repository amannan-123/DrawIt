Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class TestForm

	Private Sub EnableBlur(hwnd As IntPtr, enabled As Boolean)

		Dim accent = New W10BlurHelper.AccentPolicy()
		If enabled Then
			accent.AccentState = W10BlurHelper.AccentState.ACCENT_ENABLE_BLURBEHIND
		Else
			accent.AccentState = W10BlurHelper.AccentState.ACCENT_DISABLED
		End If
		Dim transparency = 100
		Dim clr = Color.SteelBlue
		accent.GradientColor = (transparency << 24) Or (ToAbgr(clr) And &HFFFFFF)
		accent.AccentFlags = W10BlurHelper.AccentFlag.DrawBottomBorder
		Dim accentStructSize = Marshal.SizeOf(accent)

		Dim accentPtr = Marshal.AllocHGlobal(accentStructSize)
		Marshal.StructureToPtr(accent, accentPtr, False)

		Dim Data = New W10BlurHelper.WindowCompositionAttributeData()
		Data.Attribute = W10BlurHelper.WindowCompositionAttribute.WCA_ACCENT_POLICY
		Data.SizeOfData = accentStructSize
		Data.Data = accentPtr
		W10BlurHelper.SetWindowCompositionAttribute(hwnd, Data)

		Marshal.FreeHGlobal(accentPtr)
	End Sub

	Private Function getpath(rect As RectangleF)
		Dim lst As New List(Of PointF) From {
			FromPercentage(rect, New PointF(0, 25)),
			FromPercentage(rect, New PointF(0, 75)),
			FromPercentage(rect, New PointF(50, 100)),
			FromPercentage(rect, New PointF(100, 75)),
			FromPercentage(rect, New PointF(100, 25)),
			FromPercentage(rect, New PointF(50, 0))
		}
		Dim gp As New GraphicsPath
		gp.AddPolygon(lst.ToArray)
		Return gp
	End Function

	Private Sub TestForm_Paint(sender As Object, e As PaintEventArgs) 'Handles MyBase.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.HighQuality

		Dim c1 As Color = Color.SteelBlue
		Dim c2 As Color = Color.HotPink

		Dim rect = New RectangleF(20, 20, ClientRectangle.Width - 40, ClientRectangle.Height - 40)
		Dim cent As New PointF(rect.X + (rect.Width / 2),
							   rect.Y + (rect.Height / 2))
		Dim copies As Integer = 50
		Dim ra As RectangleF = rect
		ra.Inflate(1, 1)
		Dim lgb As New LinearGradientBrush(ra, c1, c2, LinearGradientMode.Horizontal)
		g.DrawPath(New Pen(lgb), getpath(rect))
		For i = 1 To copies
			rect.Inflate(-rect.Width + (rect.Width * 0.965), -rect.Height + (rect.Height * 0.965))
			Dim mm As New Matrix
			mm.RotateAt(-7 * i, cent)
			g.Transform = mm
			Dim pth As GraphicsPath = getpath(rect)
			If IsNothing(pth) Then Exit For
			If pth.GetBounds.Width <= 1 Or pth.GetBounds.Height <= 1 Then Exit For
			Dim rb As RectangleF = rect
			rb.Inflate(1, 1)
			If rb.Width = 0 Or rb.Height = 0 Then Exit For
			Dim lgb2 As New LinearGradientBrush(rb, c1, c2, LinearGradientMode.Horizontal)
			g.DrawPath(New Pen(lgb2, 1.5), pth)
		Next

	End Sub

	Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'Dim proc = Process.GetProcessById(11048)
		'Dim hnd = proc.MainWindowHandle

	End Sub

	Private Sub TestForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		Invalidate()
	End Sub

	Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
		EnableBlur(Handle, CheckBox1.Checked)
	End Sub

	Private Function ToAbgr(color As Color) As Integer
		Return (CInt(color.A) << 24) Or (CInt(color.B) << 16) Or (CInt(color.G) << 8) Or color.R
	End Function

	Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
		ColorListBox1.SelectedIndex = 7
	End Sub

	Private Sub ListBox1_DrawItem(sender As Object, e As DrawItemEventArgs)

	End Sub

	Private Sub ColorListBox1_DrawItem(sender As Object, e As MyControls.DrawItemsEventArgs) Handles ColorListBox1.DrawItem
		Dim g As Graphics = e.Graphics
		Dim rect As Rectangle = e.Bounds
		Dim clr As Color = e.Item
		If e.State = MyControls.DrawItemsEventArgs.ItemState.Foreground Then
			rect.Width -= 1
			rect.Height -= 1
			g.DrawRectangle(Pens.Black, rect)
		Else
			If e.State = MyControls.DrawItemsEventArgs.ItemState.Hover Then clr = ControlPaint.Light(clr, 0.9)
			g.FillRectangle(New SolidBrush(clr), rect)
			rect.Width -= 1
			If e.Index = ColorListBox1.Items.Count - 1 Then rect.Height -= 1
			g.DrawRectangle(Pens.Black, rect)
			If e.State = MyControls.DrawItemsEventArgs.ItemState.Selected Then
				Dim p1 As Point = New Point(rect.X, rect.Bottom)
				Dim p2 As Point = New Point(rect.Right, rect.Bottom)
				g.DrawLine(New Pen(Color.Red, 2), p1, p2)
			End If
		End If
	End Sub

	Private Sub MyVScrollBar1_Scroll(sender As Object, e As EventArgs) Handles MyVScrollBar1.Scroll
		Text = MyVScrollBar1.Value
	End Sub
End Class

Class W10BlurHelper

	Enum AccentState
		ACCENT_DISABLED = 0
		ACCENT_ENABLE_GRADIENT = 1
		ACCENT_ENABLE_TRANSPARENTGRADIENT = 2
		ACCENT_ENABLE_BLURBEHIND = 3
		ACCENT_ENABLE_ACRYLICBLURBEHIND = 4
		ACCENT_INVALID_STATE = 5
	End Enum

	Enum AccentFlag
		DrawLeftBorder = 1 << 5
		DrawTopBorder = 1 << 6
		DrawRightBorder = 1 << 7
		DrawBottomBorder = 1 << 8
		DrawAllBorders = (DrawLeftBorder Or DrawTopBorder Or DrawRightBorder Or DrawBottomBorder)
	End Enum

	<StructLayout(LayoutKind.Sequential)>
	Structure AccentPolicy
		Public AccentState As AccentState
		Public AccentFlags As Integer
		Public GradientColor As Integer
		Public AnimationId As Integer
	End Structure

	Enum WindowCompositionAttribute
		' ...
		WCA_ACCENT_POLICY = 19
		' ...
	End Enum

	<StructLayout(LayoutKind.Sequential)>
	Structure WindowCompositionAttributeData
		Public Attribute As WindowCompositionAttribute
		Public Data As IntPtr
		Public SizeOfData As Integer
	End Structure

	<DllImport("user32.dll")>
	Shared Function SetWindowCompositionAttribute(hwnd As IntPtr, ByRef data As WindowCompositionAttributeData) As Integer

	End Function

End Class