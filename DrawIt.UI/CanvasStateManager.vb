Imports System.Drawing
Imports System.Collections.Generic

Public Class CanvasStateManager
    Public ReadOnly Property Shapes As New List(Of Shape)
    Public Property CurrentOperation As MOperations = MOperations.None
    Public Property FocusColor As Color = Color.Silver

    Public Property IsCloned As Boolean = False
    Public Property IsCloning As Boolean = False
    Public Property MouseUpFix As Boolean = True

    Public Property MouseDownPoint As PointF
    Public Property RotationCenter As PointF
    Public Property RotationAngle As Single

    Public ReadOnly Property OldSelectionIndices As New List(Of Integer)
    Public ReadOnly Property ResizeRects As New List(Of RectangleF)
    Public ReadOnly Property MoveSnapshot As New List(Of KeyValuePair(Of Shape, RectangleF))
    Public Property ResizeBounds As RectangleF
    Public Property SelectionRect As RectangleF
    Public Property Hover As Canvas.HoverInfo = New Canvas.HoverInfo(-1, 0)
    Public Property NegateX As Boolean = False
    Public Property NegateY As Boolean = False

    Public Property DrawInfo As Canvas.DrawModeInfo = New Canvas.DrawModeInfo(False)
    Public Property CurrentLocation As PointF = PointF.Empty
End Class
