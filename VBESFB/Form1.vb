Imports System.Speech.Recognition
Imports System.Speech.Synthesis
Imports System.Speech
Imports System

Public Class ComposeRead
    Dim WithEvents recognizerform1 As New SpeechRecognitionEngine(New System.Globalization.CultureInfo("en-US"))
    Dim listen As Integer = 0
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            sendemail()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Try
            reademail()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub startSpeechReco()
        Try
            recognizerform1.SetInputToDefaultAudioDevice()
            Dim gramform1 As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRuleform1 As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim messageListform1 As New Recognition.SrgsGrammar.SrgsOneOf("compose", "inbox", "begin", "stop", "exit")
            messageRuleform1.Add(messageListform1)
            gramform1.Rules.Add(messageRuleform1)
            gramform1.Root = messageRuleform1
            recognizerform1.LoadGrammar(New Recognition.Grammar(gramform1))
            recognizerform1.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub reco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recognizerform1.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text.ToLower
            '            MsgBox(sp)

            If sp.Contains("begin") Then
                listen = 1
                say("I am listening to you.")
                say("Say compose to compose email and say inbox to read mails in inbox.")
            ElseIf sp.Contains("stop") Then
                say("I am not listening to you.")
                listen = 0
            End If
            If listen = 1 Then
                If (sp.Contains("compose")) Then
                    acktone()
                    sp = ""
                    recognizerform1.RecognizeAsyncCancel()
                    recognizerform1.UnloadAllGrammars()
                    sendemail()
                ElseIf (sp.Contains("inbox")) Then
                    acktone()
                    sp = ""
                    recognizerform1.RecognizeAsyncCancel()
                    recognizerform1.UnloadAllGrammars()
                    reademail()
                Else
                    say("Please try again.")

                End If
            End If
            If (sp.Contains("exit") Or sp.Contains("quit") Or sp.Contains("close") Or sp.Contains("turn off") Or sp.Contains("terminate")) Then
                acktone()
                say("Application closing please wait")
                Me.Close()

            End If
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub reademail()
        Try
            say("Opening please wait  readmail.")
            recognizerform1.UnloadAllGrammars()
            My.Forms.ReadEmail.Show()
            Me.Hide()
            Me.Close()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub sendemail()
        Try
            say("Opening please wait  compose.")
            recognizerform1.UnloadAllGrammars()
            My.Forms.ComposeEmail.Show()
            Me.Hide()
            Me.Close()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Public Sub say(ByVal msg As String)
        Try
            Dim synthform1 As New SpeechSynthesizer()
            synthform1.SetOutputToDefaultAudioDevice()
            synthform1.SelectVoiceByHints(VoiceGender.Female)
            synthform1.Rate = -3
            synthform1.Volume = 100


            synthform1.Speak(msg)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Public Sub beep()
        Try
            My.Computer.Audio.Play(My.Resources.beep_09, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Public Sub errortone()
        Try
            My.Computer.Audio.Play(My.Resources.beep_02, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Public Sub acktone()
        Try
            My.Computer.Audio.Play(My.Resources.button_3, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Public Sub hovertone()
        Try
            My.Computer.Audio.Play(My.Resources.button_17, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Public Sub clearthroat()
        Try
            My.Computer.Audio.Play(My.Resources.ct, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub ComposeRead_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            recognizerform1.UnloadAllGrammars()
            recognizerform1.RecognizeAsyncCancel()
            listen = 0
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub


    Private Sub announcement()
        Try
            clearthroat()
            say("Currenly I am not listening. Say exit to close.")
            say("Say begin to start listening and say stop to stop listening.")
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub ComposeRead_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            announcement()
            startSpeechReco()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub ComposeRead_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
