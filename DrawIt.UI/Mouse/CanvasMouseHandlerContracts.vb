Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Structure CanvasMouseHandlerResult
    Public Shared ReadOnly Property Ignore As CanvasMouseHandlerResult
        Get
            Return New CanvasMouseHandlerResult(False, False, False)
        End Get
    End Property

    Public Shared ReadOnly Property HandledResult As CanvasMouseHandlerResult
        Get
            Return New CanvasMouseHandlerResult(True, False, False)
        End Get
    End Property

    Public Shared ReadOnly Property CaptureResult As CanvasMouseHandlerResult
        Get
            Return New CanvasMouseHandlerResult(True, True, False)
        End Get
    End Property

    Public Shared ReadOnly Property ReleaseResult As CanvasMouseHandlerResult
        Get
            Return New CanvasMouseHandlerResult(True, False, True)
        End Get
    End Property

    Public Sub New(handled As Boolean, capture As Boolean, releaseCapture As Boolean)
        Me.Handled = handled
        Me.Capture = capture
        Me.ReleaseCapture = releaseCapture
    End Sub

    Public ReadOnly Handled As Boolean
    Public ReadOnly Capture As Boolean
    Public ReadOnly ReleaseCapture As Boolean
End Structure

Public Interface ICanvasInteractionContext
    ReadOnly Property State As CanvasStateManager
    Function IsPanInputActive() As Boolean
    Function ToWorldPoint(pt As Point) As PointF
    Function ShapeInCursor(screenPt As PointF) As Integer
    Function GetAnchorsRegion() As Region
    Function SelectedIndices() As List(Of Integer)
    Function MainSelected() As Shape
    Function MultipleSelectionBounds() As RectangleF
    Function GetAnchorType(pt As PointF) As Canvas.AnchorType
    Function GetWorldToScreenMatrix() As Matrix
    Function IsPathHit(path As GraphicsPath, screenPt As PointF) As Boolean
    Function DModeMin() As Integer
    Function DPInCursor(screenPt As PointF) As Integer

    Sub DeselectAll()
    Sub SetPrimary()
    Sub SetPrimaryByIndex(index As Integer)
    Sub EnsurePrimarySelected()
    Sub CaptureMoveSnapshot(indices As List(Of Integer))
    Sub CloneSelected()
    Sub DeleteSelected()
    Sub FinalizeResize(shp As Shape)
    Sub ClearDrawingData()
    Sub InvalidateCanvas()
    Sub UpdateControls()
    Sub UpdateBoundControls()
    Sub SwitchToSelectMode()

    Property CanvasCursor As Cursor
    ReadOnly Property HighlightShapesEnabled As Boolean
End Interface

Public Interface ICanvasMouseHandler
    Function OnMouseDown(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult
    Function OnMouseMove(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult
    Function OnMouseUp(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult
    Function OnMouseLeave(context As ICanvasInteractionContext) As CanvasMouseHandlerResult
End Interface
