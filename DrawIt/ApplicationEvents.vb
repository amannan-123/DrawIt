Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
	' The following events are available for MyApplication:
	' Startup: Raised when the application starts, before the startup form is created.
	' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
	' UnhandledException: Raised if the application encounters an unhandled exception.
	' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
	' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
	Partial Friend Class MyApplication

		Protected Overrides Sub OnStartupNextInstance(eventArgs As StartupNextInstanceEventArgs)
			If eventArgs.CommandLine.Count > 0 Then
				Dim frm = Application.MainForm
				If TypeOf frm Is MainForm Then
					DirectCast(frm, MainForm).OpenFiles(eventArgs.CommandLine.ToArray)
					eventArgs.BringToForeground = True
				End If
			End If
			MyBase.OnStartupNextInstance(eventArgs)
		End Sub

		Protected Overrides Function OnUnhandledException(e As UnhandledExceptionEventArgs) As Boolean
			e.ExitApplication = True
			Return MyBase.OnUnhandledException(e)
		End Function

	End Class
End Namespace
