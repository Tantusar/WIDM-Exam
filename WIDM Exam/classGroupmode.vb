Public Class Groupmode
    Public Author As String
    Public Mole As New Candidate
    Public Property Candidates As New Dictionary(Of String, Candidate)
    Public Screens As New Dictionary(Of String, ScreenExecution)
    Public Episodes As New Dictionary(Of Integer, Episode)
    Public CurrentEpisode As Integer = 1
    Public Password As String 

    Public Function EpisodeExists(ByVal episode As Integer) As Boolean
        If episodes.ContainsKey(episode) Then
            Return True
        Else
            episodes.Add(episode, New Episode With {.number = episode})
            Return False
        End If
    End Function

    Public Function CandidateAdd(ByVal name As String, ByVal active As Boolean, ByVal episode As Integer)
        EpisodeExists(episode)
        If Not candidates.ContainsKey(name) Then
            Dim candidate As New Candidate
            candidate.name = name
            candidate.active(episode) = active
            candidates.Add(candidate.name, candidate)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CandidateAdd(ByVal name As String, ByVal active As Boolean)
        Return CandidateAdd(name, active, currentEpisode)
    End Function

    Public Function CandidateRemove(ByVal name As String)
        If candidates.ContainsKey(name) Then
            candidates.Remove(name)
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
        Return CandidateEdit(name, newName, active, currentEpisode)
    End Function

    Public Function AnswerAdd(ByVal number As Integer, ByVal question As String, ByVal candidate As Candidate, ByVal answer As String, ByVal episode As Integer)
        EpisodeExists(episode)
        Dim givenAnswer As New GivenAnswer
        givenAnswer.number = number
        givenAnswer.question = question
        givenAnswer.candidate = candidate
        givenAnswer.answer = answer
        episodes(episode).answers.Add(givenAnswer)
        Return True
    End Function

    Public Function AnswerAdd(ByVal number As Integer, ByVal question As String, ByVal candidate As Candidate, ByVal answer As String)
        Return AnswerAdd(number, question, candidate, answer, currentEpisode)
    End Function

    Public Function AnswerRemove(ByVal index As Integer, ByVal episode As Integer)
        EpisodeExists(episode)
        If Not episodes(episode).answers.Count > index Then
            episodes(episode).answers.RemoveAt(index)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AnswerRemove(ByVal index As Integer)
        Return AnswerRemove(index, currentEpisode)
    End Function

    Public Function ExecutionAdd(ByVal candidate As Candidate, ByVal answersRight As Integer, ByVal time As Integer, ByVal screen As String, ByVal jokers As Integer, ByVal episode As Integer)
        EpisodeExists(episode)
        Dim executionResult As New ExecutionResult
        executionResult.candidate = candidate
        executionResult.answersRight = answersRight
        executionResult.time = time
        executionResult.screen = screen
        executionResult.jokers = jokers
        episodes(episode).executionResults.Add(candidate.name, executionResult)
        Return True
    End Function

    Public Function ExecutionAdd(ByVal candidate As Candidate, ByVal answersRight As Integer, ByVal time As Integer, ByVal screen As String, ByVal jokers As Integer)
        Return ExecutionAdd(candidate, answersRight, time, screen, jokers, currentEpisode)
    End Function

    Public Function ExecutionRemove(ByVal candidate As Candidate, ByVal episode As Integer)
        EpisodeExists(episode)
        If episodes(episode).executionResults.ContainsKey(candidate.name) Then
            episodes(episode).executionResults.Remove(candidate.name)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ExecutionRemove(ByVal candidate As Candidate)
        Return ExecutionRemove(candidate, currentEpisode)
    End Function

    Public Function ExecutionEdit(ByVal candidate As Candidate, ByVal newCandidate As Candidate, ByVal answersRight As Integer, ByVal time As Integer, ByVal screen As String, ByVal jokers As Integer, ByVal episode As Integer)
        EpisodeExists(episode)
        If ExecutionRemove(candidate, episode) Then
            Return ExecutionAdd(newCandidate, answersRight, time, screen, jokers, episode)
        Else
            Return False
        End If
    End Function

    Public Function ExecutionEdit(ByVal candidate As Candidate, ByVal newCandidate As Candidate, ByVal answersRight As Integer, ByVal time As Integer, ByVal screen As String, ByVal jokers As Integer)
        Return ExecutionEdit(candidate, newCandidate, answersRight, time, screen, jokers, currentEpisode)
    End Function

    Public Function ScreenAdd(ByVal name As String, ByVal location As String)
        Dim screen As New ScreenExecution
        screen.name = name
        screen.location = location
        screens.Add(name, screen)
        Return True
    End Function

    Public Function ScreenRemove(ByVal name As String)
        If screens.ContainsKey(name) Then
            screens.Remove(name)
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
    Public Property Active As New Dictionary(Of Integer, Boolean)
End Class

Public Class GivenAnswer
    Public Number As Integer
    Public Question As String
    Public Candidate As New Candidate
    Public Answer As String
End Class

Public Class ExecutionResult
    Public Candidate As New Candidate
    Public AnswersRight As Integer
    Public Time As Integer
    Public Screen As String
    Public Jokers As Integer
End Class

Public Class ScreenExecution
    Public Name As String
    Public Location As String
End Class
