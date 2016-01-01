Imports System.Resources
Imports WIDM_Exam.My.Resources

Module langChooser
    Public rm As ResourceManager

    'Function
    Public Function getLang(strValue As String)
        Dim strLanguage As String

        If IsNothing(rm) Then
            'Get system language
            strLanguage = My.Settings.language

            'Set resource manager
            If strLanguage = "en" Then
                rm = langEN.ResourceManager
            Else
                rm = langNL.ResourceManager
            End If
        End If

        getLang = rm.GetString(strValue)
    End Function
End Module
