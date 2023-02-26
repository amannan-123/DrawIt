#Region "Imports"
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms.Design
#End Region

#Region "ColorListBox"
<Description("Custom listbox for choosing colors.")>
<DefaultProperty("Items")>
<DefaultEvent("SelectedIndexChanged")>
Public Class ColorListBox

#Region "Enum"
	Public Enum DrawMode
		[Default]
		Custom
	End Enum
#End Region

#Region "Declarations"
	Private h_ind As Integer = -1
#End Region

#Region "New"
	Sub New()
		InitializeComponent()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.UserPaint, True)
		SetStyle(ControlStyles.UserMouse, True)
		AutoScaleMode = AutoScaleMode.None
	End Sub
#End Region

#Region "Events"
	''' <summary>
	''' Occurs whenever a particular item needs to be painted.
	''' </summary>
	<Description("Occurs whenever a particular item needs to be painted.")>
	Public Event DrawItem(sender As Object, e As DrawItemsEventArgs)

	''' <summary>
	''' Occurs when the value of SelectedIndex property changes.
	''' </summary>
	<Description("Occurs when the value of SelectedIndex property changes.")>
	Public Event SelectedIndexChanged(sender As Object, e As EventArgs)
#End Region

#Region "Properties"
	Private _mode As DrawMode = DrawMode.Default
	<DefaultValue(GetType(DrawMode), "Default")>
	Public Property DrawingMode() As DrawMode
		Get
			Return _mode
		End Get
		Set(value As DrawMode)
			_mode = value
		End Set
	End Property

	Private _lst As New ColorsCollection(Me)
	<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
	Public Property Items() As ColorsCollection
		Get
			Return _lst
		End Get
		Set(value As ColorsCollection)
			_lst = value
			RefreshItems()
		End Set
	End Property

	Private s_ind As Integer = -1
	<DefaultValue(-1)>
	Public Property SelectedIndex() As Integer
		Get
			If s_ind < 0 Or s_ind > _lst.Count - 1 Then Return -1
			Return s_ind
		End Get
		Set(value As Integer)
			s_ind = value
			If s_ind < 0 Or s_ind > Items.Count - 1 Then s_ind = -1
			If s_ind > -1 Then
				While GetItemRect(s_ind).Top < 0
					MyVScrollBar1.Value -= ItemHeight
				End While
				While GetItemRect(s_ind).Bottom > Height
					MyVScrollBar1.Value += ItemHeight
				End While
			End If
			RaiseEvent SelectedIndexChanged(Me, New EventArgs)
			Invalidate()
		End Set
	End Property

	<Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
	Public ReadOnly Property SelectedItem() As Color
		Get
			If s_ind = -1 Then Return Nothing
			Return _lst(s_ind)
		End Get
	End Property

	Private s_col As Color = Color.FromArgb(85, 85, 85)
	<DefaultValue(GetType(Color), "85,85,85")>
	Public Property SelectedColor() As Color
		Get
			Return s_col
		End Get
		Set(value As Color)
			s_col = value
			Invalidate()
		End Set
	End Property

	Private h_col As Color = Color.FromArgb(47, 53, 58)
	<DefaultValue(GetType(Color), "47,53,58")>
	Public Property HoverColor() As Color
		Get
			Return h_col
		End Get
		Set(value As Color)
			h_col = value
			Invalidate()
		End Set
	End Property

	Private n_col As Color = Color.FromArgb(33, 37, 41)
	<DefaultValue(GetType(Color), "33,37,41")>
	Public Property NormalColor() As Color
		Get
			Return n_col
		End Get
		Set(value As Color)
			n_col = value
			Invalidate()
		End Set
	End Property

	Private item_h As Integer = 20
	<DefaultValue(GetType(Integer), "20")>
	Public Property ItemHeight() As Integer
		Get
			Return item_h
		End Get
		Set(value As Integer)
			item_h = value
			UpdateSize()
			Invalidate()
		End Set
	End Property
#End Region

#Region "Private Functions"
	Private Sub UpdateSize()
		Dim i_height = (Items.Count * ItemHeight) + 1
		If i_height > Height Then
			MyVScrollBar1.Visible = True
			MyVScrollBar1.Maximum = i_height - Height
		Else
			MyVScrollBar1.Visible = False
			MyVScrollBar1.Maximum = 1
		End If
	End Sub

	Private Sub RefreshItems()
		If s_ind < 0 Or s_ind > _lst.Count - 1 Then s_ind = -1
		UpdateSize()
		Invalidate()
	End Sub

	Private Function GetItemRect(i As Integer) As Rectangle
		Dim y As Integer = i * ItemHeight
		If MyVScrollBar1.Visible Then y -= MyVScrollBar1.Value
		Dim i_width As Integer = If(MyVScrollBar1.Visible, (Width - 1) - MyVScrollBar1.Width, Width - 1)
		Return New Rectangle(0, y, i_width, ItemHeight)
	End Function
#End Region

#Region "Resize"
	Private Sub ColorList_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		UpdateSize()
		Invalidate()
	End Sub

	Private Sub ColorList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		MyVScrollBar1.BindWheelEvent(Me)
		UpdateSize()
	End Sub
#End Region

#Region "Keyboard"
	Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
		'Because a Usercontrol ignores the arrows in the KeyDown Event
		'and changes focus no matter what in the KeyUp Event
		'This is needed to fix the KeyDown problem
		Select Case keyData
			Case Keys.Left, Keys.Right, Keys.Up, Keys.Down
				Return True
			Case Else
				Return MyBase.IsInputKey(keyData)
		End Select
	End Function

	Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
		Select Case keyData
			Case Keys.Up
				If SelectedIndex > 0 Then SelectedIndex -= 1
			Case Keys.Down
				If SelectedIndex < _lst.Count - 1 Then SelectedIndex += 1
		End Select
		Return MyBase.ProcessCmdKey(msg, keyData)
	End Function
#End Region

#Region "Mouse"
	Private Sub ColorListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		s_ind = -1
		For i As Integer = 0 To _lst.Count - 1
			If GetItemRect(i).Contains(e.Location) Then SelectedIndex = i
		Next
		Invalidate()
	End Sub

	Private Sub ColorListBox_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		h_ind = -1
		For i As Integer = 0 To _lst.Count - 1
			If GetItemRect(i).Contains(e.Location) Then h_ind = i
		Next
		Invalidate()
	End Sub

	Private Sub ColorListBox_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
		h_ind = -1
		Invalidate()
	End Sub
#End Region

#Region "Paint"
	Private Sub ColorListBox_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.AntiAlias
		g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

		If DesignMode Or DrawingMode = DrawMode.Default Then

			For i As Integer = 0 To _lst.Count - 1
				Dim rect As Rectangle = GetItemRect(i)
				If i = SelectedIndex Then
					g.FillRectangle(New SolidBrush(SelectedColor), rect)
					Dim rd = rect
					rd.Inflate(-1, -1)
					g.DrawRectangle(New Pen(Color.White), rd)
				ElseIf i = h_ind Then
					g.FillRectangle(New SolidBrush(HoverColor), rect)
					g.DrawLine(New Pen(Color.FromArgb(55, 59, 62)), rect.X, rect.Bottom - 1, rect.Right, rect.Bottom - 1)
				Else
					g.FillRectangle(New SolidBrush(NormalColor), rect)
					g.DrawLine(New Pen(Color.FromArgb(55, 59, 62)), rect.X, rect.Bottom - 1, rect.Right, rect.Bottom - 1)
				End If

				Dim itemString As String = _lst(i).Name
				Dim curr_c = _lst(i)
				Dim _pad = 3
				Dim c_rect As New Rectangle(rect.X + 1, rect.Y + 1, rect.Height - 2, rect.Height - 2)

				'Draw a Color Swatch
				g.DrawRectangle(New Pen(Color.White), c_rect)
				c_rect.Inflate(-_pad, -_pad)
				g.FillRectangle(New SolidBrush(curr_c), c_rect)

				' Draw the text in the item.
				Dim rt As New Rectangle(c_rect.Right, rect.Y, rect.Width - c_rect.Right, rect.Height)
				Dim sf As New StringFormat With {
					.Alignment = StringAlignment.Center,
					.LineAlignment = StringAlignment.Center
				}
				g.DrawString(itemString, Font, New SolidBrush(ForeColor), rt, sf)

			Next

			Dim b_rect As New Rectangle(0, 0, Width, Height)
			b_rect.Width -= 1
			b_rect.Height -= 1
			g.DrawRectangle(Pens.Black, b_rect)

		ElseIf DrawingMode = DrawMode.Custom Then

			RaiseEvent DrawItem(Me, New DrawItemsEventArgs(g, -1, BackColor, ClientRectangle, DrawItemsEventArgs.ItemState.Background))

			For i As Integer = 0 To _lst.Count - 1
				Dim rect As Rectangle = GetItemRect(i)
				If i = SelectedIndex Then
					RaiseEvent DrawItem(Me, New DrawItemsEventArgs(g, i, Items(i), rect, DrawItemsEventArgs.ItemState.Selected))
				ElseIf i = h_ind Then
					RaiseEvent DrawItem(Me, New DrawItemsEventArgs(g, i, Items(i), rect, DrawItemsEventArgs.ItemState.Hover))
				Else
					RaiseEvent DrawItem(Me, New DrawItemsEventArgs(g, i, Items(i), rect, DrawItemsEventArgs.ItemState.Normal))
				End If
			Next

			RaiseEvent DrawItem(Me, New DrawItemsEventArgs(g, -1, ForeColor, ClientRectangle, DrawItemsEventArgs.ItemState.Foreground))

		End If

	End Sub
#End Region

#Region "ScrollBar"
	Private Sub MyVScrollBar1_Scroll(sender As Object, e As EventArgs) Handles MyVScrollBar1.Scroll
		h_ind = -1
		Invalidate()
	End Sub
#End Region

#Region "ColorsCollection"
	Public Class ColorsCollection
		Implements IList(Of Color), IList

		Private _lst As New List(Of Color)

		Private _ctrl As ColorListBox

		Sub New(ctrl As ColorListBox)
			_ctrl = ctrl
		End Sub

		Default Public Property Item(index As Integer) As Color Implements IList(Of Color).Item
			Get
				Return DirectCast(_lst, IList(Of Color))(index)
			End Get
			Set(value As Color)
				DirectCast(_lst, IList(Of Color))(index) = value
				_ctrl.RefreshItems()
			End Set
		End Property

		Public ReadOnly Property Count As Integer Implements ICollection(Of Color).Count
			Get
				Return DirectCast(_lst, IList(Of Color)).Count
			End Get
		End Property

		Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of Color).IsReadOnly
			Get
				Return DirectCast(_lst, IList(Of Color)).IsReadOnly
			End Get
		End Property

		Private ReadOnly Property IList_IsReadOnly As Boolean Implements IList.IsReadOnly
			Get
				Return DirectCast(_lst, IList).IsReadOnly
			End Get
		End Property

		Public ReadOnly Property IsFixedSize As Boolean Implements IList.IsFixedSize
			Get
				Return DirectCast(_lst, IList).IsFixedSize
			End Get
		End Property

		Private ReadOnly Property ICollection_Count As Integer Implements ICollection.Count
			Get
				Return DirectCast(_lst, IList).Count
			End Get
		End Property

		Public ReadOnly Property SyncRoot As Object Implements ICollection.SyncRoot
			Get
				Return DirectCast(_lst, IList).SyncRoot
			End Get
		End Property

		Public ReadOnly Property IsSynchronized As Boolean Implements ICollection.IsSynchronized
			Get
				Return DirectCast(_lst, IList).IsSynchronized
			End Get
		End Property

		Property IList_Item(index As Integer) As Object Implements IList.Item
			Get
				Return DirectCast(_lst, IList)(index)
			End Get
			Set(value As Object)
				DirectCast(_lst, IList)(index) = value
				_ctrl.RefreshItems()
			End Set
		End Property

		Public Function IndexOf(item As Color) As Integer Implements IList(Of Color).IndexOf
			Return DirectCast(_lst, IList(Of Color)).IndexOf(item)
			_ctrl.RefreshItems()
		End Function

		Public Sub Insert(index As Integer, item As Color) Implements IList(Of Color).Insert
			DirectCast(_lst, IList(Of Color)).Insert(index, item)
			_ctrl.RefreshItems()
		End Sub

		Public Sub RemoveAt(index As Integer) Implements IList(Of Color).RemoveAt
			DirectCast(_lst, IList(Of Color)).RemoveAt(index)
			_ctrl.RefreshItems()
		End Sub

		Public Sub Add(item As Color) Implements ICollection(Of Color).Add
			DirectCast(_lst, IList(Of Color)).Add(item)
			_ctrl.RefreshItems()
		End Sub

		Public Sub Clear() Implements ICollection(Of Color).Clear
			DirectCast(_lst, IList(Of Color)).Clear()
			_ctrl.RefreshItems()
		End Sub

		Public Function Contains(item As Color) As Boolean Implements ICollection(Of Color).Contains
			Return DirectCast(_lst, IList(Of Color)).Contains(item)
			_ctrl.RefreshItems()
		End Function

		Public Sub CopyTo(array() As Color, arrayIndex As Integer) Implements ICollection(Of Color).CopyTo
			DirectCast(_lst, IList(Of Color)).CopyTo(array, arrayIndex)
			_ctrl.RefreshItems()
		End Sub

		Public Function Remove(item As Color) As Boolean Implements ICollection(Of Color).Remove
			Return DirectCast(_lst, IList(Of Color)).Remove(item)
			_ctrl.RefreshItems()
		End Function

		Public Function GetEnumerator() As IEnumerator(Of Color) Implements IEnumerable(Of Color).GetEnumerator
			Return DirectCast(_lst, IList(Of Color)).GetEnumerator()
			_ctrl.RefreshItems()
		End Function

		Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
			Return DirectCast(_lst, IList(Of Color)).GetEnumerator()
			_ctrl.RefreshItems()
		End Function

		Public Function Add(value As Object) As Integer Implements IList.Add
			Return DirectCast(_lst, IList).Add(value)
			_ctrl.RefreshItems()
		End Function

		Public Function Contains(value As Object) As Boolean Implements IList.Contains
			Return DirectCast(_lst, IList).Contains(value)
			_ctrl.RefreshItems()
		End Function

		Private Sub IList_Clear() Implements IList.Clear
			DirectCast(_lst, IList).Clear()
			_ctrl.RefreshItems()
		End Sub

		Public Function IndexOf(value As Object) As Integer Implements IList.IndexOf
			Return DirectCast(_lst, IList).IndexOf(value)
			_ctrl.RefreshItems()
		End Function

		Public Sub Insert(index As Integer, value As Object) Implements IList.Insert
			DirectCast(_lst, IList).Insert(index, value)
			_ctrl.RefreshItems()
		End Sub

		Public Sub Remove(value As Object) Implements IList.Remove
			DirectCast(_lst, IList).Remove(value)
			_ctrl.RefreshItems()
		End Sub

		Private Sub IList_RemoveAt(index As Integer) Implements IList.RemoveAt
			DirectCast(_lst, IList).RemoveAt(index)
			_ctrl.RefreshItems()
		End Sub

		Public Sub CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
			DirectCast(_lst, IList).CopyTo(array, index)
			_ctrl.RefreshItems()
		End Sub

	End Class
#End Region

End Class
#End Region

#Region "DrawItemsEventArgs"
''' <summary>
''' Provides data for the DrawItem event of <see cref='ColorListBox'/> control.
''' </summary>
Public Class DrawItemsEventArgs
	Inherits EventArgs

	Public Enum ItemState
		''' <summary>
		''' The item is in normal state.
		''' </summary>
		Normal
		''' <summary>
		''' Cursor is within item region.
		''' </summary>
		Hover
		''' <summary>
		''' The item is in selected state.
		''' </summary>
		Selected
		''' <summary>
		''' Background of control.
		''' </summary>
		Background
		''' <summary>
		''' Foreground of control.
		''' </summary>
		Foreground
	End Enum

	Sub New(_g As Graphics, _i As Integer, _clr As Color, _bd As Rectangle, _st As ItemState)
		g = _g
		_index = _i
		bound = _bd
		st = _st
		clr = _clr
	End Sub

	Private _index As Integer
	''' <summary>
	''' Gets the index value of the item being drawn.
	''' </summary>
	Public ReadOnly Property Index() As Integer
		Get
			Return _index
		End Get
	End Property

	Private g As Graphics
	''' <summary>
	''' Gets the graphics surface to draw the item on.
	''' </summary>
	Public ReadOnly Property Graphics() As Graphics
		Get
			Return g
		End Get
	End Property

	Private bound As Rectangle
	''' <summary>
	''' Gets the rectangle that represents the bounds of the item being drawn.
	''' </summary>
	Public ReadOnly Property Bounds() As Rectangle
		Get
			Return bound
		End Get
	End Property

	Private st As ItemState
	''' <summary>
	''' Gets the state of the item being drawn.
	''' </summary>
	Public ReadOnly Property State() As ItemState
		Get
			Return st
		End Get
	End Property

	Private clr As Color
	''' <summary>
	''' Gets the list box item being drawn.
	''' </summary>
	Public ReadOnly Property Item() As Color
		Get
			Return clr
		End Get
	End Property
End Class
#End Region
