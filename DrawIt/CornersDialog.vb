Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class CornersDialog

#Region "Globals"
	Private shp As Shape = Nothing
	Private canvas As Canvas = Nothing
#End Region

#Region "New"
	Sub New()
		InitializeComponent()
	End Sub

	Sub New(_shp As Shape, _canvas As Canvas)
		InitializeComponent()
		shp = _shp
		canvas = _canvas

	End Sub
#End Region

End Class
