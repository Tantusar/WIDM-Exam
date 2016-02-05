Imports System.Globalization
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If Settings.language = "en" Then
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("en")
                FrmOpenTest.btnLanguage.Image = Resources.gb
                'CurrentThread.CurrentCulture = New CultureInfo("EN")
            Else
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("nl")
                FrmOpenTest.btnLanguage.Image = Resources.nl
                'CurrentThread.CurrentCulture = New CultureInfo("NL")
            End If
            If My.Settings.MustUpgrade = True Then
                My.Settings.MustUpgrade = False 
                My.Settings.Upgrade()
            End If
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf KaboomHandler
        End Sub

        Private Sub KaboomHandler(sender As Object, e As System.UnhandledExceptionEventArgs)
            MsgBox(e.ExceptionObject.ToString())
        End Sub
    End Class
End Namespace

