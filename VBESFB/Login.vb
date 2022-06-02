Imports System.Speech.Recognition
Imports System.Speech
Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Net.Security
Imports System.Net
Imports System.ComponentModel
Imports System.Speech.Synthesis
Imports System

Public Class Login

    Dim WithEvents recognizerlogin As New SpeechRecognitionEngine()
    Dim WithEvents recoalphalogin As New SpeechRecognitionEngine()
    Dim listen As Integer = 0
    Dim action As String = "none"
    Dim PopHost As String
    Dim UserName As String
    Dim Password As String
    Dim PortNm As Integer

    Dim POP3 As New TcpClient
    Dim Read_Stream As StreamReader
    Dim NetworkS_tream As NetworkStream
    Dim m_sslStream As SslStream
    Dim server_Command As String
    Dim ret_Val As Integer
    Dim Response As String
    Dim Parts() As String
    Dim m_buffer() As Byte
    Dim StatResp As String
    Dim server_Stat(2) As String
    Dim portno As Integer = 995


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If POP3.Connected = True Then
                CloseServer()
                POP3 = New TcpClient(PopHost, Integer.Parse(portno))
                ret_Val = 0
                Exit Sub
            Else

                PopHost = "pop.gmail.com"
                UserName = TextBox1.Text.ToString
                Password = TextBox2.Text.ToString
                PortNm = portno


                Cursor = Cursors.WaitCursor

                If CheckForInternetConnection() = True Then

                    POP3 = New TcpClient(PopHost, Integer.Parse(portno))

                    NetworkS_tream = POP3.GetStream
                    m_sslStream = New SslStream(NetworkS_tream)
                    m_sslStream.AuthenticateAsClient(PopHost)
                    Read_Stream = New StreamReader(m_sslStream)
                    StatResp = Read_Stream.ReadLine()
                    StatResp = Login(m_sslStream, "USER " & UserName) & vbCrLf
                    server_Stat = StatResp.Split(" ")
                    If server_Stat(0) = "+OK" Then
                        server_Stat(0) = ""
                        StatResp = Login(m_sslStream, "PASS " & Password) & vbCrLf
                        server_Stat = StatResp.Split(" ")
                        If server_Stat(0) = "+OK" Then
                            server_Stat(0) = ""

                            recognizerlogin.RecognizeAsyncCancel()
                            recognizerlogin.UnloadAllGrammars()
                            recoalphalogin.RecognizeAsyncCancel()
                            recoalphalogin.UnloadAllGrammars()

                            say("You have been logged in successfully. Please Wait.")
                            ComposeEmail.tbFrom.Text = TextBox1.Text
                            ComposeEmail.tbPass.Text = TextBox2.Text
                            ReadEmail.tbUN.Text = TextBox1.Text
                            ReadEmail.tbPW.Text = TextBox2.Text
                            CloseServer()
                            ret_Val = 0
                            listen = 0
                            My.Forms.ComposeRead.Show()
                            Me.Hide()
                            Me.Close()

                        Else
                            say("Incorrect password. Please re enter password.")
                            TextBox2.Text = ""
                        End If
                    Else
                        say("Incorrect username. Please re enter username.")
                        TextBox1.Text = ""
                    End If
                    ret_Val = 1
                Else
                    say("You are not connected to internet. Please check your internet connection")
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception

            say("An error has occurred.")
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
    Sub CloseServer()
        Try
            StatResp = Login(m_sslStream, "QUIT ") & vbCrLf
            TextBox1.Text = String.Empty
            POP3.Close()
            ret_Val = 0
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Function Login(ByVal SslStrem As SslStream, ByVal Server_Command As String) As String
        Try
            Dim Read_Stream2 = New StreamReader(SslStrem)
            Server_Command = Server_Command + vbCrLf
            m_buffer = System.Text.Encoding.ASCII.GetBytes(Server_Command.ToCharArray())
            m_sslStream.Write(m_buffer, 0, m_buffer.Length)
            Dim Server_Reponse As String
            Server_Reponse = Read_Stream2.ReadLine()
            Return Server_Reponse
        Catch ex As Exception

            say("An error has occurred.")
        End Try
        Return (0)
    End Function

    Public Sub say(ByVal msg As String)
        Try
            Dim synth As New SpeechSynthesizer()
            synth.SetOutputToDefaultAudioDevice()
            synth.SelectVoiceByHints(VoiceGender.Female)
            synth.Rate = -3
            synth.Volume = 100
            synth.Speak(msg)
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

    Private Sub Login_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            recognizerlogin.RecognizeAsyncCancel()
            recognizerlogin.UnloadAllGrammars()
            listen = 0
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            acktone()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub reco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recognizerlogin.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text.ToLower
            If sp.Contains("begin") Then
                listen = 1
                recognizerlogin.RecognizeAsyncCancel()
                recognizerlogin.UnloadAllGrammars()
                say("I am listening to you.")
                startSpeechRecoAlpha()
                If TextBox1.Text.Contains("@gmail.com") Then
                    say("Enter your password")
                    action = "password"
                Else
                    say("Enter your username")
                    action = "username"
                End If
            ElseIf sp.Contains("stop") Then
                say("I am not listening to you.")
                listen = 0
            End If

            If (sp.Contains("exit") Or sp.Contains("quit") Or sp.Contains("close") Or sp.Contains("turn off") Or sp.Contains("terminate")) Then
                acktone()
                say("Application closing please wait")
                Me.Hide()
                Me.Close()
            End If
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub recoalpha_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recoalphalogin.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text.ToLower

            If sp.Contains("stop") Then
                listen = 0
                recoalphalogin.RecognizeAsyncCancel()
                recoalphalogin.UnloadAllGrammars()
                startSpeechReco()
            End If
            If (action = "username") Then
                Select Case sp
                    Case "a"
                        TextBox1.AppendText("a")
                    Case "b"
                        TextBox1.AppendText("b")
                    Case "c"
                        TextBox1.AppendText("c")
                    Case "d"
                        TextBox1.AppendText("d")
                    Case "e"
                        TextBox1.AppendText("e")
                    Case "f"
                        TextBox1.AppendText("f")
                    Case "g"
                        TextBox1.AppendText("g")
                    Case "h"
                        TextBox1.AppendText("h")
                    Case "i"
                        TextBox1.AppendText("i")
                    Case "j"
                        TextBox1.AppendText("j")
                    Case "k"
                        TextBox1.AppendText("k")
                    Case "l"
                        TextBox1.AppendText("l")
                    Case "m"
                        TextBox1.AppendText("m")
                    Case "n"
                        TextBox1.AppendText("n")
                    Case "o"
                        TextBox1.AppendText("o")
                    Case "p"
                        TextBox1.AppendText("p")
                    Case "q"
                        TextBox1.AppendText("q")
                    Case "r"
                        TextBox1.AppendText("r")
                    Case "s"
                        TextBox1.AppendText("s")
                    Case "t"
                        TextBox1.AppendText("t")
                    Case "u"
                        TextBox1.AppendText("u")
                    Case "v"
                        TextBox1.AppendText("v")
                    Case "w"
                        TextBox1.AppendText("w")
                    Case "x"
                        TextBox1.AppendText("x")
                    Case "y"
                        TextBox1.AppendText("y")
                    Case "z"
                        TextBox1.AppendText("z")
                    Case "one"
                        TextBox1.AppendText("1")
                    Case "1"
                        TextBox1.AppendText("1")
                    Case "two"
                        TextBox1.AppendText("2")
                    Case "2"
                        TextBox1.AppendText("2")
                    Case "three"
                        TextBox1.AppendText("3")
                    Case "3"
                        TextBox1.AppendText("3")
                    Case "four"
                        TextBox1.AppendText("4")
                    Case "4"
                        TextBox1.AppendText("4")
                    Case "five"
                        TextBox1.AppendText("5")
                    Case "5"
                        TextBox1.AppendText("5")
                    Case "six"
                        TextBox1.AppendText("6")
                    Case "6"
                        TextBox1.AppendText("6")
                    Case "seven"
                        TextBox1.AppendText("7")
                    Case "7"
                        TextBox1.AppendText("7")
                    Case "eight"
                        TextBox1.AppendText("8")
                    Case "8"
                        TextBox1.AppendText("8")
                    Case "nine"
                        TextBox1.AppendText("9")
                    Case "9"
                        TextBox1.AppendText("9")
                    Case "zero"
                        TextBox1.AppendText("0")
                    Case "0"
                        TextBox1.AppendText("0")
                    Case "at the rate"
                        TextBox1.AppendText("@gmail.com")
                       ' say("gmail.com")
                    Case "dot"
                        TextBox1.AppendText(".")
                    Case "gmail"
                        TextBox1.AppendText("gmail")
                    Case "com"
                        TextBox1.AppendText("com")
                    Case "done"
                        If TextBox1.Text.Contains("@gmail.com") And TextBox1.Text.Length >= 16 Then
                            say("Entered user name is " + TextBox1.Text)
                            action = "password"
                            sp = ""
                            say("Enter Your Password")

                        Else
                            say("Incorrect username. please reenter username")
                            TextBox1.Text = ""
                        End If

                End Select
            End If

            If (action = "password") Then
                Select Case sp
                    Case "a"
                        TextBox2.AppendText("a")
                    Case "b"
                        TextBox2.AppendText("b")
                    Case "c"
                        TextBox2.AppendText("c")
                    Case "d"
                        TextBox2.AppendText("d")
                    Case "e"
                        TextBox2.AppendText("e")
                    Case "f"
                        TextBox2.AppendText("f")
                    Case "g"
                        TextBox2.AppendText("g")
                    Case "h"
                        TextBox2.AppendText("h")
                    Case "i"
                        TextBox2.AppendText("i")
                    Case "j"
                        TextBox2.AppendText("j")
                    Case "k"
                        TextBox2.AppendText("k")
                    Case "l"
                        TextBox2.AppendText("l")
                    Case "m"
                        TextBox2.AppendText("m")
                    Case "n"
                        TextBox2.AppendText("n")
                    Case "o"
                        TextBox2.AppendText("o")
                    Case "p"
                        TextBox2.AppendText("p")
                    Case "q"
                        TextBox2.AppendText("q")
                    Case "r"
                        TextBox2.AppendText("r")
                    Case "s"
                        TextBox2.AppendText("s")
                    Case "t"
                        TextBox2.AppendText("t")
                    Case "u"
                        TextBox2.AppendText("u")
                    Case "v"
                        TextBox2.AppendText("v")
                    Case "w"
                        TextBox2.AppendText("w")
                    Case "x"
                        TextBox2.AppendText("x")
                    Case "y"
                        TextBox2.AppendText("y")
                    Case "z"
                        TextBox2.AppendText("z")
                    Case "one"
                        TextBox2.AppendText("1")
                    Case "1"
                        TextBox2.AppendText("1")
                    Case "two"
                        TextBox2.AppendText("2")
                    Case "2"
                        TextBox2.AppendText("2")
                    Case "three"
                        TextBox2.AppendText("3")
                    Case "3"
                        TextBox2.AppendText("3")
                    Case "four"
                        TextBox2.AppendText("4")
                    Case "4"
                        TextBox2.AppendText("4")
                    Case "five"
                        TextBox2.AppendText("5")
                    Case "5"
                        TextBox2.AppendText("5")
                    Case "six"
                        TextBox2.AppendText("6")
                    Case "6"
                        TextBox2.AppendText("6")
                    Case "seven"
                        TextBox2.AppendText("7")
                    Case "7"
                        TextBox2.AppendText("7")
                    Case "eight"
                        TextBox2.AppendText("8")
                    Case "8"
                        TextBox2.AppendText("8")
                    Case "nine"
                        TextBox2.AppendText("9")
                    Case "9"
                        TextBox2.AppendText("9")
                    Case "zero"
                        TextBox2.AppendText("0")
                    Case "0"
                        TextBox2.AppendText("0")
                    Case "at the rate"
                        TextBox2.AppendText("@")
                    Case "dot"
                        TextBox2.AppendText(".")
                    Case "gmail"
                        TextBox2.AppendText("gmail")
                    Case "com"
                        TextBox2.AppendText("com")
                    Case "done"
                        If TextBox2.Text.Length >= 8 Then
                            say("Entered password is " + TextBox2.Text)
                            action = "none"
                            say("Loginng")
                            Button1.PerformClick()
                            recoalphalogin.RecognizeAsyncCancel()
                            recoalphalogin.UnloadAllGrammars()

                        Else
                            say("Incorrect password. please reenter password")
                            TextBox2.Text = ""
                        End If


                End Select
            End If
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub


    Private Sub whatwouldyoudo()
        Try
            say("What would you like to do?")
            say("Available options are:")
            say("1. Enter username")
            say("2. Enter password")
            say("3. Login")
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Public Sub addusername(ByVal user As String)
        Try
            TextBox1.AppendText(user)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Public Sub addpassword(ByVal pass As String)
        Try
            TextBox2.AppendText(pass)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub announcement()
        Try
            say("Your application has gained focus.")
            say("I am currently not listening to you. Say begin to start listening and stop to stop listening.")
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub startSpeechRecoAlpha()
        Try
            recoalphalogin.SetInputToDefaultAudioDevice()
            Dim gramalpha As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRulealpha As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim messageListalpha As New Recognition.SrgsGrammar.SrgsOneOf("stop", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "at the rate", "gmail", "dot", "com", "done", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0")
            messageRulealpha.Add(messageListalpha)
            gramalpha.Rules.Add(messageRulealpha)
            gramalpha.Root = messageRulealpha
            recoalphalogin.LoadGrammar(New Recognition.Grammar(gramalpha))
            recoalphalogin.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub startSpeechReco()

        Try
            recognizerlogin.SetInputToDefaultAudioDevice()
            Dim gram As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRule As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim messageList As New Recognition.SrgsGrammar.SrgsOneOf("Start", "begin", "stop", "log", "login", "user", "username", "name", "pass", "password", "word")
            messageRule.Add(messageList)
            gram.Rules.Add(messageRule)
            gram.Root = messageRule
            recognizerlogin.LoadGrammar(New Recognition.Grammar(gram))
            recognizerlogin.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub Login_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        action = "none"
        announcement()
        startSpeechReco()
        say("I am  not Listening To You.")
    End Sub
End Class