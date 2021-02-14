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
        Dim lst As New List(Of PointF)
        lst.Add(FromPercentage(rect, New PointF(0, 25)))
        lst.Add(FromPercentage(rect, New PointF(0, 75)))
        lst.Add(FromPercentage(rect, New PointF(50, 100)))
        lst.Add(FromPercentage(rect, New PointF(100, 75)))
        lst.Add(FromPercentage(rect, New PointF(100, 25)))
        lst.Add(FromPercentage(rect, New PointF(50, 0)))
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

	Private Sub MyTabControl1_TabRemoving(sender As Object, e As MyControls.TabRemovingEventArgs)
		If MessageBox.Show("Tab", "Do you want to close tab?", MessageBoxButtons.YesNo) = DialogResult.No Then
			e.Cancel = True
		End If
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