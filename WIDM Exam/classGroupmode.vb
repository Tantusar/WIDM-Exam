Public Class Groupmode
    Public Author As String
    Public Version As String = Application.ProductVersion.ToString()
    Public Mole As New Candidate
    Public CurrentEpisode As Integer = 1
    Public Password As String
    Public Candidates As New SortedDictionary(Of String, Candidate)
    Public Episodes As New SortedDictionary(Of Integer, Episode)
    Public Screens As New SortedDictionary(Of String, ScreenExecution)

    Sub New()
        Mole = New Candidate()
        Candidates = New SortedDictionary(Of String, Candidate)
        Episodes = New SortedDictionary(Of Integer, Episode)
        Screens = New SortedDictionary(Of String, ScreenExecution)
        Episodes.Add(1, New Episode())
    End Sub

    Public Function EpisodeExists(ByVal episode As Integer) As Boolean
        If Episodes.ContainsKey(episode) Then
            Return True
        Else
            Episodes.Add(episode, New Episode With {.Number = episode})
            Return False
        End If
    End Function

    Public Function CandidateAdd(ByVal candidate As Candidate)
        Try
            Candidates.Add(candidate.Name, candidate)
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            Return False
        End Try
    End Function

    Public Function CandidateAdd(ByVal name As String, ByVal active As Boolean, ByVal episode As Integer)
        EpisodeExists(episode)
        If Not Candidates.ContainsKey(name) Then
            Dim candidate As New Candidate
            candidate.Name = name
            candidate.Active(episode) = active
            Candidates.Add(candidate.Name, candidate)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CandidateAdd(ByVal name As String, ByVal active As Boolean)
        Return CandidateAdd(name, active, CurrentEpisode)
    End Function

    Public Function CandidateRemove(ByVal name As String)
        If Candidates.ContainsKey(name) Then
            Candidates.Remove(name)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CandidateEdit(ByVal name As String, ByVal newName As String, ByVal active As Boolean, ByVal episode As Integer)
        EpisodeExists(episode)
        If CandidateRemove(name) Then
            Return CandidateAdd(newName, active, episode)
        Else
            Return False
        End If
    End Function

    Public Function CandidateEdit(ByVal name As String, ByVal newName As String, ByVal active As Boolean)
        Return CandidateEdit(name, newName, active, CurrentEpisode)
    End Function

    Public Function AnswerAdd(ByVal number As Integer, ByVal question As String, ByVal candidate As String, ByVal answer As String, ByVal episode As Integer)
        EpisodeExists(episode)
        Dim givenAnswer As New GivenAnswer
        givenAnswer.Number = number
        givenAnswer.Question = question
        givenAnswer.Candidate = candidate
        givenAnswer.Answer = answer
        Episodes(episode).Answers.Add(givenAnswer)
        Return True
    End Function

    Public Function AnswerAdd(ByVal number As Integer, ByVal question As String, ByVal candidate As String, ByVal answer As String)
        Return AnswerAdd(number, question, candidate, answer, CurrentEpisode)
    End Function

    Public Function AnswerRemove(ByVal index As Integer, ByVal episode As Integer)
        EpisodeExists(episode)
        If Not Episodes(episode).Answers.Count > index Then
            Episodes(episode).Answers.RemoveAt(index)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AnswerRemove(ByVal index As Integer)
        Return AnswerRemove(index, CurrentEpisode)
    End Function

    Public Function ExecutionAdd(ByVal result As ExecutionResult, ByVal episode As Integer)
        Try
            Episodes(episode).ExecutionResults.Add(result.Candidate, result)
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            Return False
        End Try
    End Function

    Public Function ExecutionAdd(ByVal result As ExecutionResult)
        Return ExecutionAdd(result, CurrentEpisode)
    End Function

    Public Function ExecutionAdd(ByVal candidate As String, ByVal answersRight As Integer, ByVal time As Integer, ByVal screen As String, ByVal jokers As Integer, ByVal episode As Integer)
        EpisodeExists(episode)
        If Episodes(CurrentEpisode).ExecutionResults.ContainsKey(candidate) Then
            ExecutionRemove(candidate)
        End If
        Dim executionResult As New ExecutionResult
        executionResult.Candidate = candidate
        executionResult.AnswersRight = answersRight
        executionResult.Time = time
        executionResult.Screen = screen
        executionResult.Jokers = jokers
        Episodes(episode).ExecutionResults.Add(candidate, executionResult)
        Return True
    End Function

    Public Function ExecutionAdd(ByVal candidate As String, ByVal answersRight As Integer, ByVal time As Integer, ByVal screen As String, ByVal jokers As Integer)
        Return ExecutionAdd(candidate, answersRight, time, screen, jokers, CurrentEpisode)
    End Function

    Public Function ExecutionRemove(ByVal candidate As String, ByVal episode As Integer)
        EpisodeExists(episode)
        If Episodes(episode).ExecutionResults.ContainsKey(candidate) Then
            Episodes(episode).ExecutionResults.Remove(candidate)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ExecutionRemove(ByVal candidate As String)
        Return ExecutionRemove(candidate, CurrentEpisode)
    End Function

    Public Function ExecutionEdit(ByVal candidate As String, ByVal newCandidate As String, ByVal answersRight As Integer, ByVal time As Integer, ByVal screen As String, ByVal jokers As Integer, ByVal episode As Integer)
        EpisodeExists(episode)
        If ExecutionRemove(candidate, episode) Then
            Return ExecutionAdd(newCandidate, answersRight, time, screen, jokers, episode)
        Else
            Return False
        End If
    End Function

    Public Function ExecutionEdit(ByVal candidate As String, ByVal newCandidate As String, ByVal answersRight As Integer, ByVal time As Integer, ByVal screen As String, ByVal jokers As Integer)
        Return ExecutionEdit(candidate, newCandidate, answersRight, time, screen, jokers, CurrentEpisode)
    End Function

    Public Function ScreenAdd(ByVal name As String, ByVal location As String)
        Dim screen As New ScreenExecution
        screen.Name = name
        screen.Location = location
        Screens.Add(name, screen)
        Return True
    End Function

    Public Function ScreenRemove(ByVal name As String)
        If Screens.ContainsKey(name) Then
            Screens.Remove(name)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ScreenEdit(ByVal name As String, ByVal newName As String, ByVal location As String)
        If ScreenRemove(name) Then
            Return ScreenAdd(newName, location)
        Else
            Return False
        End If
    End Function
End Class

Public Class Episode
    Public Number As Integer
    Public ExecutionResults As New Dictionary(Of String, ExecutionResult)
    Public Answers As New List(Of GivenAnswer)
End Class

Public Class Candidate
    Public Property Name As String
    Public Property Active As New SortedDictionary(Of Integer, Boolean)
End Class

Public Class GivenAnswer
    Public Number As Integer
    Public Question As String
    Public Candidate As String
    Public Answer As String
End Class

Public Class ExecutionResult
    Public Candidate As String
    Public AnswersRight As Integer
    Public Time As Integer
    Public Screen As String
    Public Jokers As Integer
End Class

Public Class ScreenExecution
    Public Name As String
    Public Location As String
End Class
