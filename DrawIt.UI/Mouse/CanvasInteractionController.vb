Imports System.Windows.Forms

Public Class CanvasInteractionController
    Private ReadOnly _handlers As ICanvasMouseHandler()
    Private _capturedHandler As ICanvasMouseHandler = Nothing

    Public Sub New(ParamArray handlers() As ICanvasMouseHandler)
        _handlers = handlers
    End Sub

    Private Function Dispatch(context As ICanvasInteractionContext, dispatchFn As Func(Of ICanvasMouseHandler, ICanvasInteractionContext, CanvasMouseHandlerResult)) As Boolean
        If Not IsNothing(_capturedHandler) Then
            Dim capturedResult = dispatchFn(_capturedHandler, context)
            If capturedResult.ReleaseCapture Then _capturedHandler = Nothing
            If Not IsNothing(_capturedHandler) Then Return True
            If capturedResult.Handled Then Return True
        End If

        For Each handler In _handlers
            Dim result = dispatchFn(handler, context)
            If result.Handled Then
                If result.Capture Then _capturedHandler = handler
                Return True
            End If
        Next
        Return False
    End Function

    Public Function HandleMouseDown(context As ICanvasInteractionContext, e As MouseEventArgs) As Boolean
        Return Dispatch(context, Function(h, c) h.OnMouseDown(c, e))
    End Function

    Public Function HandleMouseMove(context As ICanvasInteractionContext, e As MouseEventArgs) As Boolean
        Return Dispatch(context, Function(h, c) h.OnMouseMove(c, e))
    End Function

    Public Function HandleMouseUp(context As ICanvasInteractionContext, e As MouseEventArgs) As Boolean
        Return Dispatch(context, Function(h, c) h.OnMouseUp(c, e))
    End Function

    Public Function HandleMouseLeave(context As ICanvasInteractionContext) As Boolean
        Return Dispatch(context, Function(h, c) h.OnMouseLeave(c))
    End Function
End Class
