Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

<Designer(GetType(ColorListDesigner))>
<Description("Custom listbox for choosing colors.")>
<DefaultProperty("Colors")>
<DefaultEvent("SelectedIndexChanged")>
Public Class ColorListBox

    Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.UserMouse, True)
        AutoScaleMode = AutoScaleMode.None
    End Sub

    Private h_ind As Integer = -1

    Public Event SelectedIndexChanged(sender As Object, e As EventArgs)

    Private _lst As New ColorsCollection(Me)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Editor(GetType(CollectionEditor), GetType(UITypeEditor))>
    Public Property Items() As ColorsCollection
        Get
            Return _lst
        End Get
        Set(ByVal value As ColorsCollection)
            _lst = value
            RefreshItems()
        End Set
    End Property

    Private s_ind As Integer = -1
    Public Property SelectedIndex() As Integer
        Get
            If s_ind < 0 Or s_ind > _lst.Count - 1 Then Return -1
            Return s_ind
        End Get
        Set(ByVal value As Integer)
            s_ind = value
            RaiseEvent SelectedIndexChanged(Me, New EventArgs)
            pChild.Invalidate()
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public ReadOnly Property SelectedItem() As Color
        Get
            If s_ind = -1 Then Return Nothing
            Return _lst(s_ind)
        End Get
    End Property

    Private s_col As Color = Color.DimGray
    <DefaultValue(GetType(Color), "DimGray")>
    Public Property SelectedColor() As Color
        Get
            Return s_col
        End Get
        Set(ByVal value As Color)
            s_col = value
            pChild.Invalidate()
        End Set
    End Property

    Private h_col As Color = Color.Gray
    <DefaultValue(GetType(Color), "Gray")>
    Public Property HoverColor() As Color
        Get
            Return h_col
        End Get
        Set(ByVal value As Color)
            h_col = value
            pChild.Invalidate()
        End Set
    End Property

    Private n_col As Color = Color.DarkGray
    <DefaultValue(GetType(Color), "DarkGray")>
    Public Property NormalColor() As Color
        Get
            Return n_col
        End Get
        Set(ByVal value As Color)
            n_col = value
            pChild.Invalidate()
        End Set
    End Property

    Private item_h As Integer = 20
    <DefaultValue(GetType(Integer), "20")>
    Public Property ItemHeight() As Integer
        Get
            Return item_h
        End Get
        Set(ByVal value As Integer)
            item_h = value
            UpdateSize()
            pChild.Invalidate()
        End Set
    End Property

    Private Sub UpdateSize()
        pChild.Width = Width - 17
        Dim hgt As Integer = Items.Count * ItemHeight
        If hgt > Height Then
            pChild.Height = hgt
        Else
            pChild.Height = Height
            pChild.Width = Width
        End If
    End Sub

    Private Sub RefreshItems()
        If s_ind < 0 Or s_ind > _lst.Count - 1 Then s_ind = -1
        UpdateSize()
        pChild.Invalidate()
    End Sub

    Private Function GetItemRect(i As Integer) As Rectangle
        Dim y As Integer = i * ItemHeight
        Return New Rectangle(0, y, pChild.Width, ItemHeight)
    End Function

    Private Sub pChild_MouseDown(sender As Object, e As MouseEventArgs) Handles pChild.MouseDown
        For i As Integer = 0 To _lst.Count - 1
            If GetItemRect(i).Contains(e.Location) Then SelectedIndex = i
        Next
        pChild.Invalidate()
    End Sub

    Private Sub pChild_MouseMove(sender As Object, e As MouseEventArgs) Handles pChild.MouseMove
        h_ind = -1
        For i As Integer = 0 To _lst.Count - 1
            If GetItemRect(i).Contains(e.Location) Then h_ind = i
        Next
        pChild.Invalidate()
    End Sub

    Private Sub pChild_MouseLeave(sender As Object, e As EventArgs) Handles pChild.MouseLeave
        h_ind = -1
        pChild.Invalidate()
    End Sub

    Private Sub pChild_Paint(sender As Object, e As PaintEventArgs) Handles pChild.Paint
        Dim g As Graphics = e.Graphics

        For i As Integer = 0 To _lst.Count - 1
            Dim rect As Rectangle = GetItemRect(i)
            If i = SelectedIndex Then
                g.FillRectangle(New SolidBrush(SelectedColor), rect)
            ElseIf i = h_ind Then
                g.FillRectangle(New SolidBrush(HoverColor), rect)
            Else
                g.FillRectangle(New SolidBrush(NormalColor), rect)
            End If

            Dim itemString As String = _lst(i).Name
            Dim myBrush As New SolidBrush(_lst(i))
            Dim c_rect As New Rectangle(rect.X + 2, rect.Y + 2, 20, rect.Height - 5)

            'Draw a Color Swatch
            e.Graphics.FillRectangle(myBrush, c_rect)
            e.Graphics.DrawRectangle(Pens.Black, c_rect)

            ' Draw the text in the item.
            Dim rt As New Rectangle(c_rect.Right, rect.Y, rect.Width - c_rect.Right, rect.Height)
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(itemString, Font, New SolidBrush(ForeColor), rt, sf)

        Next

        Dim b_rect As New Rectangle(0, VerticalScroll.Value, pChild.Width, Height)
        b_rect.Width -= 1
        b_rect.Height -= 1
        g.DrawRectangle(Pens.Black, b_rect)

    End Sub

    Private Sub ColorList_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        UpdateSize()
    End Sub

    Private Sub ColorList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateSize()
    End Sub

    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Up, Keys.Down
                Return True
            Case Else
                Return MyBase.IsInputKey(keyData)
        End Select
    End Function

    Private Sub ColorList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.Up
                If SelectedIndex > 0 Then
                    SelectedIndex -= 1
                End If
                pChild.Invalidate()
            Case Keys.Down
                If SelectedIndex < _lst.Count - 1 Then
                    SelectedIndex += 1
                End If
                pChild.Invalidate()
        End Select
    End Sub

    Public Class ColorsCollection
        Implements IList(Of Color), IList, IEnumerable(Of Color)

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

    Private Sub pChild_LocationChanged(sender As Object, e As EventArgs) Handles pChild.LocationChanged
        pChild.Invalidate()
    End Sub

End Class

Public Class ColorListDesigner
    Inherits ControlDesigner

    Private _list As ColorListBox
    Public Overrides Sub Initialize(ByVal component As IComponent)
        MyBase.Initialize(component)

        ' Get list control shortcut reference
        _list = CType(component, ColorListBox)
    End Sub

    Protected Overrides Function GetHitTest(point As Point) As Boolean
        If _list.VerticalScroll.Visible Then
            point = _list.PointToClient(point)
            'scrollbar rectangle
            Dim rect As New Rectangle(_list.Width - 17, 0, 17, _list.Height)
            If rect.Contains(point) Then Return True
        End If
        Return MyBase.GetHitTest(point)
    End Function

End Class