Imports System.Drawing.Drawing2D

Module Helpers

#Region "Enum"

	Enum MOperations
		TopLeft
		Top
		TopRight
		Left
		Right
		BottomLeft
		Bottom
		BottomRight
        Move
        Rotate
        Draw
        Selection
		Centering
		None
	End Enum

#End Region

#Region "Functions"
	Public Function GetRoundedRectPath(ByVal BaseRect As RectangleF, UpperLeft As Single, ulc As MyShape.CornerType, UpperRight As Single, urc As MyShape.CornerType, LowerLeft As Single, llc As MyShape.CornerType, LowerRight As Single, lrc As MyShape.CornerType) As GraphicsPath

		Dim ArcRect As RectangleF
		Dim MyPath As New GraphicsPath()
		With MyPath
			' top left arc
			If UpperLeft = 0 Then
				.AddLine(BaseRect.X, BaseRect.Y, BaseRect.X, BaseRect.Y)
			Else
				Select Case ulc
					Case MyShape.CornerType.Normal
						ArcRect = New RectangleF(BaseRect.Location,
											New SizeF(UpperLeft * 2, UpperLeft * 2))
						.AddArc(ArcRect, 180, 90)
					Case MyShape.CornerType.Inverted
						ArcRect = New RectangleF(BaseRect.X - UpperLeft, BaseRect.Y - UpperLeft,
											UpperLeft * 2, UpperLeft * 2)
						.AddArc(ArcRect, 90, -90)
				End Select

			End If

			' top right arc
			If UpperRight = 0 Then
				.AddLine(BaseRect.X + (UpperLeft), BaseRect.Y, BaseRect.Right - (UpperRight), BaseRect.Top)
			Else
				Select Case urc
					Case MyShape.CornerType.Normal
						ArcRect = New RectangleF(BaseRect.Location,
											New SizeF(UpperRight * 2, UpperRight * 2))
						ArcRect.X = BaseRect.Right - (UpperRight * 2)
						.AddArc(ArcRect, 270, 90)
					Case MyShape.CornerType.Inverted
						ArcRect = New RectangleF(BaseRect.Right - UpperRight, BaseRect.Y - UpperRight,
											UpperRight * 2, UpperRight * 2)
						.AddArc(ArcRect, 180, -90)
				End Select

			End If

			' bottom right arc
			If LowerRight = 0 Then
				.AddLine(BaseRect.Right, BaseRect.Top + (UpperRight), BaseRect.Right, BaseRect.Bottom - (LowerRight))
			Else
				Select Case lrc
					Case MyShape.CornerType.Normal
						ArcRect = New RectangleF(BaseRect.Location,
											New SizeF(LowerRight * 2, LowerRight * 2))
						ArcRect.Y = BaseRect.Bottom - (LowerRight * 2)
						ArcRect.X = BaseRect.Right - (LowerRight * 2)
						.AddArc(ArcRect, 0, 90)
					Case MyShape.CornerType.Inverted
						ArcRect = New RectangleF(BaseRect.Right - LowerRight, BaseRect.Bottom - LowerRight,
											LowerRight * 2, LowerRight * 2)
						.AddArc(ArcRect, 270, -90)
				End Select

			End If

			' bottom left arc
			If LowerLeft = 0 Then
				.AddLine(BaseRect.Right - (LowerRight), BaseRect.Bottom, BaseRect.X - (LowerLeft), BaseRect.Bottom)
			Else
				Select Case llc
					Case MyShape.CornerType.Normal
						ArcRect = New RectangleF(BaseRect.Location,
											New SizeF(LowerLeft * 2, LowerLeft * 2))
						ArcRect.Y = BaseRect.Bottom - (LowerLeft * 2)
						.AddArc(ArcRect, 90, 90)
					Case MyShape.CornerType.Inverted
						ArcRect = New RectangleF(BaseRect.X - LowerLeft, BaseRect.Bottom - LowerLeft,
											LowerLeft * 2, LowerLeft * 2)
						.AddArc(ArcRect, 0, -90)
				End Select

			End If

			.CloseFigure()
		End With

		Return MyPath
	End Function

    Public Function SpiralPath(rect As RectangleF, spirals As Integer) As GraphicsPath
        Dim cx = rect.Width
        Dim cy = rect.Height
        Dim iNumRevs = spirals
        Dim iNumPoints As Integer = (rect.Width * rect.Height) / (spirals * spirals)
        If iNumPoints < 30 Then iNumPoints = 30
        Dim aptf As PointF() = New PointF(iNumPoints - 1) {}
        Dim fAngle, fScale As Single
        For i As Integer = 0 To iNumPoints - 1
            fAngle = (i * 2 * Math.PI / (iNumPoints / iNumRevs))
            fScale = 1 - i / iNumPoints
            aptf(i).X = (cx / 2 * (1 + fScale * Math.Cos(fAngle)))
            aptf(i).Y = (cy / 2 * (1 + fScale * Math.Sin(fAngle)))
        Next
        Dim gp As New GraphicsPath
        gp.AddCurve(aptf)
        Return gp
    End Function

    Public Function ToPercentage(rect As RectangleF, pt As PointF) As PointF
		Return New PointF(100 - ((rect.Right - pt.X) * 100) / (rect.Right - rect.X),
						  100 - ((rect.Bottom - pt.Y) * 100) / (rect.Bottom - rect.Y))
	End Function

	Public Function FromPercentage(rect As RectangleF, pt As PointF) As PointF
		Return New PointF(pt.X * (rect.Right - rect.X) / 100 + rect.X,
						  pt.Y * (rect.Bottom - rect.Y) / 100 + rect.Y)
	End Function

    Public Function AnchorToCursor(ByVal eAnchor As MOperations, _angle As Single) As Cursor
        Dim snAngle As Single = _angle
        Select Case eAnchor
            Case MOperations.Rotate
                Return Cursors.Hand
            Case MOperations.TopLeft To MOperations.BottomRight
                Select Case eAnchor
                    Case MOperations.TopLeft, MOperations.BottomRight
                        snAngle += 45
                    Case MOperations.Top, MOperations.Bottom
                        snAngle += 90
                    Case MOperations.TopRight, MOperations.BottomLeft
                        snAngle += 135
                    Case MOperations.Left, MOperations.Right
                        ' No additional rotation
                End Select
                If snAngle > 360 Then snAngle -= 360
                ' Select base on snAngle
                Select Case snAngle
                    Case 26 To 68, 204 To 248
                        Return Cursors.SizeNWSE
                    Case 69 To 113, 249 To 293
                        Return Cursors.SizeNS
                    Case 114 To 158, 294 To 338
                        Return Cursors.SizeNESW
                    Case Else ' 0 To 23, 159 To 203, 339 To 360
                        Return Cursors.SizeWE
                End Select
            Case Else
                Return Cursors.Default
        End Select
    End Function

    Public Function EditRotateAngle(snRotation As Single, dbAngle As Double, Optional ByVal _quantized As Boolean = False) As Single

		' Get new angle and trim decimals
		Dim snOut As Single = Int(snRotation + dbAngle)

		' Keep within 0 ~ 359.9
		If (snOut >= 360) Then snOut = snOut Mod 360
		If (snOut <0) Then snOut = 360 - (-snOut Mod 360)

        ' Quantize
        If _quantized Then
            Dim bQuantized As Boolean = False
            For snTarget As Single = 0.0 To 360 Step 45
                snOut = QuantizeRotation(snOut, snTarget, bQuantized)
                If bQuantized Then Exit For
            Next snTarget
        Else
            snRotation = snOut
        End If

        ' Return
        Return snOut

    End Function

    Private Function QuantizeRotation(ByVal snRotation As Single,
									  ByVal snTarget As Single,
									  ByRef bQuantized As Boolean) As Single

        ' Quantize angle
        Dim snQuantize As Single = 5

        ' Set init
        Dim snLowRef As Single = (snTarget - snQuantize)
		Dim snHiRef As Single = (snTarget + snQuantize)

		' Keep targets within boundires
		If (snLowRef >= 360) Then snLowRef = snLowRef Mod 360
		If (snLowRef < 0) Then snLowRef = 360 - (-snLowRef Mod 360)
		If (snHiRef >= 360) Then snHiRef = snHiRef Mod 360
		If (snHiRef < 0) Then snHiRef = 360 - (-snHiRef Mod 360)

		If snLowRef < snHiRef Then
			Select Case snRotation
				Case snLowRef To snHiRef
                    ' Quantized
                    bQuantized = True
                    Return snTarget
				Case Else
					' No quantize
					Return snRotation
			End Select
		Else
			Select Case snRotation
				Case snLowRef To 360, 0 To snHiRef
                    ' Quantized
                    bQuantized = True
                    Return snTarget
                Case Else
                    ' No quantize
                    Return snRotation
            End Select
		End If
	End Function

	Public Function RotatePoint(pointToRotate As PointF, centerPoint As PointF, angleInDegrees As Double) As PointF
		Dim angleInRadians As Double = angleInDegrees * (Math.PI / 180)
		Dim cosTheta As Double = Math.Cos(angleInRadians)
		Dim sinTheta As Double = Math.Sin(angleInRadians)
		Return New PointF() With {.X = CInt(cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
								  .Y = CInt(sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)}
	End Function

	Public Function GetAngleBetweenTwoPointsWithFixedPoint(tPt1 As PointF, tPt2 As PointF, tPtFixed As PointF) As Single
		Dim snAngle1 As Single = Math.Atan2(tPt1.Y - tPtFixed.Y, tPt1.X - tPtFixed.X)
		Dim snAngle2 As Single = Math.Atan2(tPt2.Y - tPtFixed.Y, tPt2.X - tPtFixed.X)
		Return snAngle1 - snAngle2
	End Function

#End Region

End Module
