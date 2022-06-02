Imports System.Speech.Recognition
Imports System.Speech
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Speech.Synthesis

Public Class ComposeEmail
    Dim attachment As System.Net.Mail.Attachment
    Dim WithEvents recoalphacompose As New SpeechRecognitionEngine()
    Dim WithEvents recobegincompose As New SpeechRecognitionEngine()
    Dim WithEvents recognizercompose As New SpeechRecognitionEngine()
    Dim WithEvents recognizerDrivecompose As New SpeechRecognitionEngine()
    Dim WithEvents recognizerDircompose As New SpeechRecognitionEngine()
    Dim listen As Integer = 0
    Dim action As String = "none"
    Dim Dirs() As String
    Dim refstr As String
    Dim sel As Integer = 0
    Dim dirarray As New ArrayList
    Dim DirList As New ArrayList

    Private Sub startSpeechReco()
        Try
            Dim dictationGrammar As Grammar = New DictationGrammar()
            recognizercompose.LoadGrammar(dictationGrammar)
            recognizercompose.SetInputToDefaultAudioDevice()
            recognizercompose.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Private Sub startrecodir()
        Try
            recognizerDircompose.SetInputToDefaultAudioDevice()
            Dim gramdircompose As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRuledircompose As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim dirl As String() = CType(dirarray.ToArray(GetType(String)), String())
            Dim messageListdircompose As New Recognition.SrgsGrammar.SrgsOneOf(dirl)
            messageRuledircompose.Add(messageListdircompose)
            gramdircompose.Rules.Add(messageRuledircompose)
            gramdircompose.Root = messageRuledircompose
            recognizerDircompose.LoadGrammar(New Recognition.Grammar(gramdircompose))
            recognizerDircompose.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Private Sub startSpeechRecoAlpha()
        Try
            recoalphacompose.SetInputToDefaultAudioDevice()
            Dim gramalphacompose As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRulealphacompose As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim messageListalphacompose As New Recognition.SrgsGrammar.SrgsOneOf("a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "at the rate", "gmail", "dot", "com", "done", "yes", "no", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "exit", "yahoo")
            messageRulealphacompose.Add(messageListalphacompose)
            gramalphacompose.Rules.Add(messageRulealphacompose)
            gramalphacompose.Root = messageRulealphacompose
            recoalphacompose.LoadGrammar(New Recognition.Grammar(gramalphacompose))
            recoalphacompose.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub startSpeechRecoBegin()
        Try
            recobegincompose.SetInputToDefaultAudioDevice()
            Dim grambegincompose As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRulebegincompose As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim messageListbegincompose As New Recognition.SrgsGrammar.SrgsOneOf("begin", "exit", "stop")
            messageRulebegincompose.Add(messageListbegincompose)
            grambegincompose.Rules.Add(messageRulebegincompose)
            grambegincompose.Root = messageRulebegincompose
            recobegincompose.LoadGrammar(New Recognition.Grammar(grambegincompose))
            recobegincompose.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub recoalpha_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recoalphacompose.SpeechRecognized
        Try

            Dim sp As String = e.Result.Text.ToLower
            If sp.Contains("exit") Then
                recognizercompose.RecognizeAsyncCancel()
                recognizercompose.UnloadAllGrammars()
                recoalphacompose.RecognizeAsyncCancel()
                recoalphacompose.UnloadAllGrammars()
                recognizerDircompose.RecognizeAsyncCancel()
                recognizerDircompose.UnloadAllGrammars()
                recognizerDrivecompose.RecognizeAsyncCancel()
                recognizerDrivecompose.UnloadAllGrammars()
                recobegincompose.RecognizeAsyncCancel()
                recobegincompose.UnloadAllGrammars()
                ' sel = 1
                say("Application closing please wait")
                ComposeRead.Show()
                Me.Hide()
                Me.Close()
            End If

            If listen = 1 Then
                If (refstr = "TO") Then
                    Select Case sp
                        Case "a"
                            tbTo.AppendText("a")
                        Case "b"
                            tbTo.AppendText("b")
                        Case "c"
                            tbTo.AppendText("c")
                        Case "d"
                            tbTo.AppendText("d")
                        Case "e"
                            tbTo.AppendText("e")
                        Case "f"
                            tbTo.AppendText("f")
                        Case "g"
                            tbTo.AppendText("g")
                        Case "h"
                            tbTo.AppendText("h")
                        Case "i"
                            tbTo.AppendText("i")
                        Case "j"
                            tbTo.AppendText("j")
                        Case "k"
                            tbTo.AppendText("k")
                        Case "l"
                            tbTo.AppendText("l")
                        Case "m"
                            tbTo.AppendText("m")
                        Case "n"
                            tbTo.AppendText("n")
                        Case "o"
                            tbTo.AppendText("o")
                        Case "p"
                            tbTo.AppendText("p")
                        Case "q"
                            tbTo.AppendText("q")
                        Case "r"
                            tbTo.AppendText("r")
                        Case "s"
                            tbTo.AppendText("s")
                        Case "t"
                            tbTo.AppendText("t")
                        Case "u"
                            tbTo.AppendText("u")
                        Case "v"
                            tbTo.AppendText("v")
                        Case "w"
                            tbTo.AppendText("w")
                        Case "x"
                            tbTo.AppendText("x")
                        Case "y"
                            tbTo.AppendText("y")
                        Case "z"
                            tbTo.AppendText("z")
                        Case "one"
                            tbTo.AppendText("1")
                        Case "1"
                            tbTo.AppendText("1")
                        Case "two"
                            tbTo.AppendText("2")
                        Case "2"
                            tbTo.AppendText("2")
                        Case "three"
                            tbTo.AppendText("3")
                        Case "3"
                            tbTo.AppendText("3")
                        Case "four"
                            tbTo.AppendText("4")
                        Case "4"
                            tbTo.AppendText("4")
                        Case "five"
                            tbTo.AppendText("5")
                        Case "5"
                            tbTo.AppendText("5")
                        Case "six"
                            tbTo.AppendText("6")
                        Case "6"
                            tbTo.AppendText("6")
                        Case "seven"
                            tbTo.AppendText("7")
                        Case "7"
                            tbTo.AppendText("7")
                        Case "eight"
                            tbTo.AppendText("8")
                        Case "8"
                            tbTo.AppendText("8")
                        Case "nine"
                            tbTo.AppendText("9")
                        Case "9"
                            tbTo.AppendText("9")
                        Case "zero"
                            tbTo.AppendText("0")
                        Case "0"
                            tbTo.AppendText("0")
                        Case "at the rate"
                            tbTo.AppendText("@")
                        Case "dot"
                            tbTo.AppendText(".")
                        Case "gmail"
                            tbTo.AppendText("gmail.com")

                        Case "yahoo"
                            tbTo.AppendText("yahoo.com")
                            say("yahoo.com")
                        Case "com"
                            tbTo.AppendText("com")
                        Case "done"
                            refstr = "none"
                            receiverCCASK()

                    End Select
                End If

                If (refstr = "CC") Then

                    Select Case sp
                        Case "a"
                            tbCC.AppendText("a")
                        Case "b"
                            tbCC.AppendText("b")
                        Case "c"
                            tbCC.AppendText("c")
                        Case "d"
                            tbCC.AppendText("d")
                        Case "e"
                            tbCC.AppendText("e")
                        Case "f"
                            tbCC.AppendText("f")
                        Case "g"
                            tbCC.AppendText("g")
                        Case "h"
                            tbCC.AppendText("h")
                        Case "i"
                            tbCC.AppendText("i")
                        Case "j"
                            tbCC.AppendText("j")
                        Case "k"
                            tbCC.AppendText("k")
                        Case "l"
                            tbCC.AppendText("l")
                        Case "m"
                            tbCC.AppendText("m")
                        Case "n"
                            tbCC.AppendText("n")
                        Case "o"
                            tbCC.AppendText("o")
                        Case "p"
                            tbCC.AppendText("p")
                        Case "q"
                            tbCC.AppendText("q")
                        Case "r"
                            tbCC.AppendText("r")
                        Case "s"
                            tbCC.AppendText("s")
                        Case "t"
                            tbCC.AppendText("t")
                        Case "u"
                            tbCC.AppendText("u")
                        Case "v"
                            tbCC.AppendText("v")
                        Case "w"
                            tbCC.AppendText("w")
                        Case "x"
                            tbCC.AppendText("x")
                        Case "y"
                            tbCC.AppendText("y")
                        Case "z"
                            tbCC.AppendText("z")
                        Case "one"
                            tbCC.AppendText("1")
                        Case "1"
                            tbCC.AppendText("1")
                        Case "two"
                            tbTo.AppendText("2")
                        Case "2"
                            tbCC.AppendText("2")
                        Case "three"
                            tbCC.AppendText("3")
                        Case "3"
                            tbCC.AppendText("3")
                        Case "four"
                            tbCC.AppendText("4")
                        Case "4"
                            tbCC.AppendText("4")
                        Case "five"
                            tbCC.AppendText("5")
                        Case "5"
                            tbCC.AppendText("5")
                        Case "six"
                            tbCC.AppendText("6")
                        Case "6"
                            tbCC.AppendText("6")
                        Case "seven"
                            tbCC.AppendText("7")
                        Case "7"
                            tbCC.AppendText("7")
                        Case "eight"
                            tbCC.AppendText("8")
                        Case "8"
                            tbCC.AppendText("8")
                        Case "nine"
                            tbCC.AppendText("9")
                        Case "9"
                            tbCC.AppendText("9")
                        Case "zero"
                            tbCC.AppendText("0")
                        Case "0"
                            tbCC.AppendText("0")
                        Case "at the rate"
                            tbCC.AppendText("@")
                        Case "dot"
                            tbCC.AppendText(".")
                        Case "gmail"
                            tbCC.AppendText("gmail.com")
                        Case "yahoo"
                            tbCC.AppendText("yahoo.com")
                        Case "com"
                            tbCC.AppendText("com")
                        Case "done"
                            refstr = "none"
                            receiverBCCASK()
                            startSpeechReco()
                    End Select
                End If

                If (refstr = "BCC") Then
                    Select Case sp
                        Case "a"
                            tbBCC.AppendText("a")
                        Case "b"
                            tbBCC.AppendText("b")
                        Case "c"
                            tbBCC.AppendText("c")
                        Case "d"
                            tbBCC.AppendText("d")
                        Case "e"
                            tbBCC.AppendText("e")
                        Case "f"
                            tbBCC.AppendText("f")
                        Case "g"
                            tbBCC.AppendText("g")
                        Case "h"
                            tbBCC.AppendText("h")
                        Case "i"
                            tbBCC.AppendText("i")
                        Case "j"
                            tbBCC.AppendText("j")
                        Case "k"
                            tbBCC.AppendText("k")
                        Case "l"
                            tbBCC.AppendText("l")
                        Case "m"
                            tbBCC.AppendText("m")
                        Case "n"
                            tbBCC.AppendText("n")
                        Case "o"
                            tbBCC.AppendText("o")
                        Case "p"
                            tbBCC.AppendText("p")
                        Case "q"
                            tbBCC.AppendText("q")
                        Case "r"
                            tbBCC.AppendText("r")
                        Case "s"
                            tbBCC.AppendText("s")
                        Case "t"
                            tbBCC.AppendText("t")
                        Case "u"
                            tbBCC.AppendText("u")
                        Case "v"
                            tbBCC.AppendText("v")
                        Case "w"
                            tbBCC.AppendText("w")
                        Case "x"
                            tbBCC.AppendText("x")
                        Case "y"
                            tbBCC.AppendText("y")
                        Case "z"
                            tbBCC.AppendText("z")
                        Case "one"
                            tbBCC.AppendText("1")
                        Case "1"
                            tbBCC.AppendText("1")
                        Case "two"
                            tbBCC.AppendText("2")
                        Case "2"
                            tbBCC.AppendText("2")
                        Case "three"
                            tbBCC.AppendText("3")
                        Case "3"
                            tbBCC.AppendText("3")
                        Case "four"
                            tbBCC.AppendText("4")
                        Case "4"
                            tbBCC.AppendText("4")
                        Case "five"
                            tbBCC.AppendText("5")
                        Case "5"
                            tbBCC.AppendText("5")
                        Case "six"
                            tbBCC.AppendText("6")
                        Case "6"
                            tbBCC.AppendText("6")
                        Case "seven"
                            tbBCC.AppendText("7")
                        Case "7"
                            tbBCC.AppendText("7")
                        Case "eight"
                            tbBCC.AppendText("8")
                        Case "8"
                            tbBCC.AppendText("8")
                        Case "nine"
                            tbBCC.AppendText("9")
                        Case "9"
                            tbBCC.AppendText("9")
                        Case "zero"
                            tbBCC.AppendText("0")
                        Case "0"
                            tbBCC.AppendText("0")
                        Case "at the rate"
                            tbBCC.AppendText("@")
                        Case "dot"
                            tbBCC.AppendText(".")
                        Case "gmail"
                            tbBCC.AppendText("gmail.com")
                        Case "yahoo"
                            tbBCC.AppendText("yahoo.com")
                        Case "com"
                            tbBCC.AppendText("com")
                        Case "done"
                            refstr = "none"
                            recoalphacompose.RecognizeAsyncCancel()
                            recoalphacompose.UnloadAllGrammars()
                            subject()
                            startSpeechReco()
                    End Select
                End If

                If (refstr = "CCASK") Then
                    Select Case sp
                        Case "yes"
                            cbkCC.Checked = True
                            receiverCC()
                        Case "no"
                            cbkCC.Checked = False
                            sp = ""
                            receiverBCCASK()
                    End Select
                End If
                If (refstr = "BCCASK") Then
                    Select Case sp
                        Case "yes"
                            cbkBCC.Checked = True
                            receiverBCC()
                        Case "no"
                            cbkBCC.Checked = False
                            subject()
                    End Select
                End If
                If (refstr = "ATTACH") Then
                    Select Case sp
                        Case "yes"
                            CheckBox3.Checked = True
                            attach()
                        Case "no"
                            asksend()
                    End Select
                End If
                If (refstr = "SEND") Then
                    Select Case sp
                        Case "yes"
                            gmail()
                        Case "no"

                    End Select
                End If
            End If
            sp = ""
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub asksend()
        Try
            say("Do you want to send email?")
            refstr = "SEND"
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub receiverCCASK()
        Try
            say("Do you want to add CC recepient? Say your response after the tone.")
            say("Say yes if you want to add CC recepients else say no.")
            beep()
            refstr = "CCASK"
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Private Sub receiverBCCASK()
        Try
            say("Do you want to add BCC recepient? Say your response after the tone.")
            say("Say yes if you want to add BCC recepients else say no.")
            beep()
            refstr = "BCCASK"
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Private Sub receiverBCC()
        Try
            say("Please say the receivers email id to be added in BCC word by word after the tone.")
            say("Say done after you have entered the receivers email id.")
            beep()
            refstr = "BCC"
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Private Sub receiverCC()
        Try
            say("Please say the receivers email id to be added in CC word by word after the tone.")
            say("Say done after you have entered the receivers email id.")
            beep()
            refstr = "CC"
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Private Sub subject()
        Try
            say("Say the subject of the email after the tone.")

            recoalphacompose.RecognizeAsyncStop()
            recoalphacompose.UnloadAllGrammars()
            '''''''''''''''''''''
            startSpeechReco()
            beep()
            refstr = "SUBJECT"
        Catch ex As Exception
            '  'say("An error has occurred.")  '**********************************
        End Try
    End Sub
    Public Sub message()
        Try
            say("Please say the message which you want to send.")
            beep()
            refstr = "MESSAGE"
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Public Sub attach()
        Try
            say("Please Select A  drive")
            Button1.PerformClick()
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Public Sub askattach()
        Try
            say("do you Want to attach file?")
            ''''''''''''''''
            recognizercompose.RecognizeAsyncStop()
            recognizercompose.UnloadAllGrammars()
            startSpeechRecoAlpha()
            beep()
            refstr = "ATTACH"
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Public Sub say(ByVal msg As String)
        Try
            Dim synthcompose As New SpeechSynthesizer()
            synthcompose.SetOutputToDefaultAudioDevice()
            synthcompose.SelectVoiceByHints(VoiceGender.Female)
            synthcompose.Rate = -3
            synthcompose.Volume = 100

            synthcompose.Speak(msg)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Public Sub beep()
        Try
            My.Computer.Audio.Play(My.Resources.beep_09, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Public Sub errortone()
        Try
            My.Computer.Audio.Play(My.Resources.beep_02, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Public Sub acktone()
        Try
            My.Computer.Audio.Play(My.Resources.button_3, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Public Sub hovertone()
        Try
            My.Computer.Audio.Play(My.Resources.button_17, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Public Sub clearthroat()
        Try
            My.Computer.Audio.Play(My.Resources.ct, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub ComposeEmail_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            stopRecognizer()
            listen = 0
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub ComposeEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            acktone()
            startSpeechRecoBegin()
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")

                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Sub recobegin_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recobegincompose.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text.ToLower
            ' MsgBox(sp)

            If sp.Contains("begin") Then
                listen = 1
                recobegincompose.RecognizeAsyncCancel()
                recobegincompose.UnloadAllGrammars()
                say("I am listening to you.")

                If (refstr = "SUBJECT" Or refstr = "MESSAGE") Then
                    recoalphacompose.RecognizeAsyncCancel()
                    recoalphacompose.UnloadAllGrammars()
                    If refstr = "SUBJECT" Then

                        say("Enter your Subject")

                    ElseIf refstr = "MESSAGE" Then
                        say("Enter Your Message")
                    End If
                    startSpeechReco()
                Else
                    say("Enter recievers email id")
                    refstr = "TO"
                    recognizercompose.RecognizeAsyncCancel()
                    recognizercompose.UnloadAllGrammars()
                    startSpeechRecoAlpha()
                End If

            ElseIf (sp.Contains("exit")) Then
                acktone()

                recognizercompose.RecognizeAsyncCancel()
                recognizercompose.UnloadAllGrammars()
                recoalphacompose.RecognizeAsyncCancel()
                recoalphacompose.UnloadAllGrammars()
                recognizerDircompose.RecognizeAsyncCancel()
                recognizerDircompose.UnloadAllGrammars()
                recognizerDrivecompose.RecognizeAsyncCancel()
                recognizerDrivecompose.UnloadAllGrammars()

                say("Application closing please wait")
                ComposeRead.Show()
                Me.Hide()
                Me.Close()

            End If
        Catch
        End Try
    End Sub
    Private Sub reco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recognizercompose.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text.ToLower
            '   MsgBox(sp)

            If sp.Contains("begin") Then
                listen = 1
                say("I am listening to you.")

                If (refstr = "SUBJECT" Or refstr = "MESSAGE") Then
                    recoalphacompose.RecognizeAsyncCancel()
                    recoalphacompose.UnloadAllGrammars()
                    startSpeechReco()
                Else

                    refstr = "TO"
                    recognizercompose.RecognizeAsyncCancel()
                    recognizercompose.UnloadAllGrammars()
                    startSpeechRecoAlpha()
                End If
            ElseIf sp.Contains("stop") Then
                say("I am not listening to you.")
                listen = 0
            End If
            If listen = 1 And refstr = "SUBJECT" Then

                If sp.ToLower.Contains("done") Then
                    message()
                    sp = ""
                Else
                    tbSubject.AppendText(sp.ToString)
                End If
            End If

            If listen = 1 And refstr = "MESSAGE" Then
                If sp.ToLower.Contains("done") Then
                    askattach()
                Else
                    tbMessage.AppendText(sp.ToString)
                End If

            End If
            If (sp.Contains("exit") Or sp.Contains("quit") Or sp.Contains("close") Or sp.Contains("turn off") Or sp.Contains("terminate")) Then
                acktone()

                recognizercompose.RecognizeAsyncCancel()
                recognizercompose.UnloadAllGrammars()
                recoalphacompose.RecognizeAsyncCancel()
                recoalphacompose.UnloadAllGrammars()
                recognizerDircompose.RecognizeAsyncCancel()
                recognizerDircompose.UnloadAllGrammars()
                recognizerDrivecompose.RecognizeAsyncCancel()
                recognizerDrivecompose.UnloadAllGrammars()
                say("Application closing please wait")
                ComposeRead.Show()
                Me.Hide()
                Me.Close()
            End If

            sp = ""
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub whatwouldyoudo()
        Try
            say("What would you like to do?")
            say("Available options are:")
            say("1. Enter receivers email id")

        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub announcement()
        Try
            say("Your application has regained focus.")
            say("I am currently not listening to you. Say begin to start listening and stop to stop listening.")
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub ComposeEmail_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            announcement()
            tbCC.Visible = False
            tbBCC.Visible = False
            Label7.Visible = False
            TextBox5.Visible = False
            Button1.Visible = False
            ListBox1.Visible = False
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        Try
            If CheckBox3.Checked = True Then
                Label7.Visible = True
                TextBox5.Visible = True
                Button1.Visible = True
                ListBox1.Visible = True
            Else
                Label7.Visible = False
                TextBox5.Visible = False
                Button1.Visible = False
                ListBox1.Visible = False
            End If
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Button1.Enabled = False
            Dim allDrives() As DriveInfo = DriveInfo.GetDrives
            Dim d As DriveInfo
            startRecognizerDrive()
            say("Please select a drive. Available drives with their labels are:")
            For Each d In allDrives
                If d.IsReady = True Then
                    ListBox1.Items.Add(d.Name)
                    say(d.Name.Substring(0, 1))
                    ListBox1.Items.Add(d.VolumeLabel)
                    say(d.VolumeLabel)
                End If
            Next
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub


    Private Sub stopRecognizer()
        Try
            recognizercompose.RecognizeAsyncCancel()
            recognizercompose.UnloadAllGrammars()
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub startRecognizerDrive()
        Try
            recognizerDrivecompose.SetInputToDefaultAudioDevice()
            Dim gramDrivecompose As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRuleDrivecompose As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim messageListDrivecompose As New Recognition.SrgsGrammar.SrgsOneOf("a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z")
            messageRuleDrivecompose.Add(messageListDrivecompose)
            gramDrivecompose.Rules.Add(messageRuleDrivecompose)
            gramDrivecompose.Root = messageRuleDrivecompose
            recognizerDrivecompose.LoadGrammar(New Recognition.Grammar(gramDrivecompose))
            recognizerDrivecompose.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub stopRecognizerDrive()
        Try
            recognizerDrivecompose.RecognizeAsyncCancel()
            recognizerDrivecompose.UnloadAllGrammars()
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub recoDrive_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recognizerDrivecompose.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text.ToLower
            Dim allDrives() As DriveInfo = DriveInfo.GetDrives
            Dim d As DriveInfo
            Dim di As DirectoryInfo

            Dim gramDrive1compose As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRuleDrive1compose As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim messageListDrive1compose As New Recognition.SrgsGrammar.SrgsOneOf()

            For Each d In allDrives
                If d.IsReady = True Then
                    If (d.Name.Substring(0, 1).ToLower.Equals(sp)) Then ' Or (d.VolumeLabel.Equals(sp)) Or sp.Contains(d.VolumeLabel.ToString) Then
                        youSelected("drive" + sp)
                        say(d.VolumeLabel)
                        GetDirectories(d.Name, DirList)
                        TextBox5.Text = d.Name
                        getf(TextBox5.Text)
                        recognizerDrivecompose.RecognizeAsyncCancel()
                        recognizerDrivecompose.UnloadAllGrammars()
                    End If
                End If
            Next


            For Each item In DirList
                Dim dir As String = item.ToString
            Next
        Catch ex As Exception
            'say("An error has occurred.")
        End Try

    End Sub
    Private Sub getf(str As String)
        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(str) ': Throw New System.Exception("An exception has occurred.")

                ListBox1.Items.Add(foundFile)
            Next
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Private Sub recoDir_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recognizerDircompose.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text
            say(sp)
            TextBox5.AppendText(sp)
            For i As Integer = 0 To ListBox1.Items.Count
            Next
            While ListBox1.Items.Count > 0
                ListBox1.Items.RemoveAt(0)
            End While
            recognizerDircompose.RecognizeAsyncCancel()
            recognizerDircompose.UnloadAllGrammars()

        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub youSelected(ByVal str As String)
        Try
            say("You selected " + str)
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Sub GetDirectories(ByVal StartPath As String, ByRef DirectoryList As ArrayList)
        Try
            Dirs = Directory.GetDirectories(StartPath)
            DirectoryList.AddRange(Dirs)
            Dirs = Directory.GetFiles(StartPath)
            DirectoryList.AddRange(Dirs)
            For Each item In DirectoryList
                Dim dir As String = item.ToString
                dir = dir.Substring(3, dir.Length - 3)
                ListBox1.Items.Add(dir)
                dirarray.Add(dir)
            Next
            startrecodir()
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            pgbProcess.Value = 0
            pgbProcess.Visible = True
            gmail()
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub
    Private Sub gmail()
        Try
            Dim EmailMessage As New MailMessage
            Dim stat As Integer = 1
            pgbProcess.Value += 5
            Try
                EmailMessage.From = New MailAddress(tbFrom.Text)
                pgbProcess.Value += 10
                If tbTo.Text.Contains("@gmail.com") Then
                    '  MsgBox("@ found")
                    EmailMessage.To.Add(tbTo.Text)
                    pgbProcess.Value += 10

                    If cbkCC.Checked = True And tbCC.Text.Contains("@gmail.com") Then
                        EmailMessage.CC.Add(tbCC.Text)
                    Else
                        stat = 0
                    End If
                    pgbProcess.Value += 5

                    If cbkBCC.Checked = True And tbBCC.Text.Contains("@gmail.com") Then
                        EmailMessage.Bcc.Add(tbBCC.Text)
                    Else
                           stat = 0
                    End If
                    pgbProcess.Value += 5
                    EmailMessage.Subject = tbSubject.Text
                    pgbProcess.Value += 10
                    EmailMessage.Body = tbMessage.Text
                    pgbProcess.Value += 10
                    If CheckBox3.Checked = True And TextBox5.Text.Contains(":") And TextBox5.Text.Contains(".") And TextBox5.Text.Contains("\") Then
                        If File.Exists(TextBox5.Text) Then
                            attachment = New System.Net.Mail.Attachment(TextBox5.Text) 'file path
                            EmailMessage.Attachments.Add(attachment) 'attachment
                            stat = 1
                        Else
                            say("File does not exist.")
                            stat = 0
                        End If
                    ElseIf CheckBox3.Checked = False Then
                        stat = 1
                    Else

                        say("Invalid attachment detected.")
                        stat = 0
                    End If
                    If stat = 1 Then
                        Dim smtp As New SmtpClient("smtp.gmail.com", 587)
                        pgbProcess.Value += 10
                        smtp.EnableSsl = True
                        pgbProcess.Value += 5
                        smtp.Credentials = New System.Net.NetworkCredential(tbFrom.Text, tbPass.Text)
                        pgbProcess.Value += 10
                        smtp.Send(EmailMessage)
                        pgbProcess.Value += 20
                        say("Your mail has been sent successfully")
                    End If
                End If
                pgbProcess.Visible = False
                tbTo.Text = ""
                tbCC.Text = ""
                tbBCC.Text = ""
                cbkCC.Checked = False
                cbkBCC.Checked = False
                tbSubject.Text = ""
                tbMessage.Text = ""
                TextBox5.Text = ""
            Catch ex As Exception
                MsgBox(ex.ToString)
                say("Error occured while sending mail. Check or  re enter your credentials.")
                pgbProcess.Value = 0
                pgbProcess.Visible = False
            End Try
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub


    Private Sub cbkCC_CheckedChanged(sender As Object, e As EventArgs) Handles cbkCC.CheckedChanged
        Try
            If cbkCC.Checked = True Then
                tbCC.Visible = True
            Else
                tbCC.Visible = False
            End If
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub cbkBCC_CheckedChanged(sender As Object, e As EventArgs) Handles cbkBCC.CheckedChanged
        Try
            If cbkBCC.Checked = True Then
                tbBCC.Visible = True
            Else
                tbBCC.Visible = False
            End If
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub ComposeEmail_Click(sender As Object, e As EventArgs) Handles Me.Click
        Try
            listen = 1
            say("I am listening to you.")
            whatwouldyoudo()
            If (refstr = "SUBJECT" Or refstr = "MESSAGE") Then
                startSpeechReco()
            Else
                refstr = "TO"
                startSpeechRecoAlpha()
            End If
        Catch ex As Exception
            'say("An error has occurred.")
        End Try
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Try
            Dim array() As Char = TextBox5.Text.ToCharArray
            Dim dummy As String = ""
            Dim charcount As Integer = 0
            Dim stat As Integer = 0
            Dim dot As Char = "."
            For Each ch As Char In array
                Dim cha As String = ch
                If cha.Equals(".") Then
                    'MsgBox("dot found")
                    dummy = dummy + ch
                    stat = 1
                    charcount = 0
                Else
                    If stat = 1 And charcount <= 4 Then
                        charcount += 1
                    ElseIf charcount > 4 Then
                        stat = 0
                        charcount = 0
                    ElseIf stat = 1 And charcount >= 3 And charcount <= 4 Then
                    End If

                End If
            Next
            If stat = 1 Then
                say("You have selected a file.")
                asksend()
                recognizerDircompose.RecognizeAsyncCancel()
                recognizerDircompose.UnloadAllGrammars()
                startSpeechRecoAlpha()
            ElseIf stat = 0 Then
                say("You have selelcted a folder.")
            End If
        Catch ex As Exception
            'say("An error has occurred.")
        End Try

    End Sub

End Class