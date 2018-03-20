Imports System.IO
Imports log4net.Config
Imports log4net
Public NotInheritable Class LogService
    Private Sub New()
    End Sub
#Region "Members"
    Private Shared ReadOnly logger As ILog = LogManager.GetLogger(GetType(LogService))
#End Region
#Region "Constructors"
    Shared Sub New()
        BasicConfigurator.Configure()
        XmlConfigurator.Configure()
    End Sub
#End Region
#Region "Methods"

    Public Shared Sub WriteLog(ByVal strLevel As String, ByVal strLog As String)
        If strLevel.Equals(Constants.LogLevel._Debug) Then
            logger.Debug(strLog)
        ElseIf strLevel.Equals(Constants.LogLevel._Error) Then
            logger.Error(strLog)
        ElseIf strLevel.Equals(Constants.LogLevel._Fatal) Then
            logger.Fatal(strLog)
        ElseIf strLevel.Equals(Constants.LogLevel._Info) Then
            logger.Info(strLog)
        ElseIf strLevel.Equals(Constants.LogLevel._Warn) Then
            logger.Warn(strLog)
        End If
    End Sub
#End Region

End Class