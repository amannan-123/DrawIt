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
	Public Function IsDesignMode() As Boolean
		Return Process.GetCurrentProcess().ProcessName = "devenv"
	End Function

	Public Function AbsRect(_rect As RectangleF) As RectangleF
		Dim frect = _rect
		If frect.Width < 0 Then
			frect.Width *= -1
			frect.X -= frect.Width
		End If
		If frect.Height < 0 Then
			frect.Height *= -1
			frect.Y -= frect.Height
		End If
		Return frect
	End Function

	Public Function GetRoundedRectPath(rect As RectangleF, crn As RRCorners,
									   ulc As MyShape.CornerType, urc As MyShape.CornerType,
									   llc As MyShape.CornerType, lrc As MyShape.CornerType) As GraphicsPath
		Dim ArcRect As RectangleF
		Dim _t1 = FromPercentage(rect.X, rect.Width, crn.T1)
		Dim _t2 = FromPercentage(rect.X, rect.Width, crn.T2)
		Dim _r1 = FromPercentage(rect.Y, rect.Height, crn.R1)
		Dim _r2 = FromPercentage(rect.Y, rect.Height, crn.R2)
		Dim _b1 = FromPercentage(rect.X, rect.Width, crn.B1)
		Dim _b2 = FromPercentage(rect.X, rect.Width, crn.B2)
		Dim _l1 = FromPercentage(rect.Y, rect.Height, crn.L1)
		Dim _l2 = FromPercentage(rect.Y, rect.Height, crn.L2)
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
				Select Case lrc
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
				Select Case llc
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

	Public Function ToPercentage(p1 As Single, p2 As Single, pt As Single) As Single
		Return (pt - p1) * 100 / (p2 - p1)
	End Function

	Public Function FromPercentage(p1 As Single, p2 As Single, pt As Single) As Single
		Return pt * (p2 - p1) / 100 + p1
	End Function

	Public Function ToPercentage(rect As RectangleF, pt As PointF) As PointF
		Return New PointF((pt.X - rect.X) * 100 / (rect.Right - rect.X),
						  (pt.Y - rect.Y) * 100 / (rect.Bottom - rect.Y))
	End Function

	Public Function FromPercentage(rect As RectangleF, pt As PointF) As PointF
		Return New PointF(pt.X * (rect.Right - rect.X) / 100 + rect.X,
						  pt.Y * (rect.Bottom - rect.Y) / 100 + rect.Y)
	End Function

	Public Function AnchorToCursor(eAnchor As MOperations, _angle As Single) As Cursor
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

	Public Function EditRotateAngle(snRotation As Single, dbAngle As Double,
									Optional _quantized As Boolean = False) As Single

		' Get new angle and trim decimals
		Dim snOut As Single = Int(snRotation + dbAngle)

		' Keep within 0 ~ 359.9
		If (snOut >= 360) Then snOut = snOut Mod 360
		If (snOut < 0) Then snOut = 360 - (-snOut Mod 360)

		' Quantize
		If _quantized Then
			Dim bQuantized As Boolean = False
			For snTarget As Single = 0.0 To 360 Step 45
				snOut = QuantizeRotation(snOut, snTarget, bQuantized)
				If bQuantized Then Exit For
			Next snTarget
		End If

		' Return
		Return snOut

	End Function

	Private Function QuantizeRotation(snRotation As Single, snTarget As Single,
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

	Public Function RotatePoint(pointToRotate As PointF, centerPoint As PointF,
								angleInDegrees As Double) As PointF
		Dim angleInRadians As Double = angleInDegrees * (Math.PI / 180)
		Dim cosTheta As Double = Math.Cos(angleInRadians)
		Dim sinTheta As Double = Math.Sin(angleInRadians)
		Return New PointF() With {.X = CInt(cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
								  .Y = CInt(sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)}
	End Function

	Public Function GetAngleBetweenTwoPointsWithFixedPoint(tPt1 As PointF, tPt2 As PointF,
														   tPtFixed As PointF) As Single
		Dim snAngle1 As Single = Math.Atan2(tPt1.Y - tPtFixed.Y, tPt1.X - tPtFixed.X)
		Dim snAngle2 As Single = Math.Atan2(tPt2.Y - tPtFixed.Y, tPt2.X - tPtFixed.X)
		Return snAngle1 - snAngle2
	End Function

#End Region

End Module
