Imports System.Drawing

Module Helpers

    Public Function ToPercentage(p1 As Single, p2 As Single, pt As Single) As Single
		Return (pt - p1) * 100 / (p2 - p1)
	End Function

    Public Function FromPercentage(p1 As Single, p2 As Single, pt As Single) As Single
        Return pt * (p2 - p1) / 100 + p1
    End Function

    Public Function ToPercentage(p1 As PointF, p2 As PointF, pt As PointF) As PointF
		Return New PointF((pt.X - p1.X) * 100 / (p2.X - p1.X),
						  (pt.Y - p1.Y) * 100 / (p2.Y - p1.Y))
	End Function

    Public Function FromPercentage(p1 As PointF, p2 As PointF, pt As PointF) As PointF
        Return New PointF(pt.X * (p2.X - p1.X) / 100 + p1.X,
                          pt.Y * (p2.Y - p1.Y) / 100 + p1.Y)
    End Function

    Public Function ToPercentage(rect As RectangleF, pt As PointF) As PointF
		Return New PointF((pt.X - rect.X) * 100 / (rect.Right - rect.X),
						  (pt.Y - rect.Y) * 100 / (rect.Bottom - rect.Y))
	End Function

    Public Function FromPercentage(rect As RectangleF, pt As PointF) As PointF
        Return New PointF(pt.X * (rect.Right - rect.X) / 100 + rect.X,
                          pt.Y * (rect.Bottom - rect.Y) / 100 + rect.Y)
    End Function


End Module
