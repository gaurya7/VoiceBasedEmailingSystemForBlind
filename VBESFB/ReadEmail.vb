Imports ImapX
Imports ImapX.Enums
Imports System.Speech
Imports System.Speech.Recognition
Imports System.Speech.Synthesis
Imports System

Public Class ReadEmail
    Dim iterations As Integer = 0
    Dim count As Integer = 0
    Dim WithEvents recognizerread As New SpeechRecognitionEngine(New System.Globalization.CultureInfo("en-US"))
    Dim WithEvents recoSubdicread As New SpeechRecognitionEngine(New System.Globalization.CultureInfo("en-US"))
    Dim listen As Integer = 1
    Dim refstr As String = ""
    Dim minref As Integer = 0
    Dim maxref As Integer = 0
    Dim sel As Integer = 0
    Dim subdic As New ArrayList
    Private Sub startSpeechRecognizer()
        Try
            recognizerread.SetInputToDefaultAudioDevice()
            Dim gramread As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRuleread As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim messageListread As New Recognition.SrgsGrammar.SrgsOneOf("exit", "done", "yes", "no", "begin", "stop")
            messageRuleread.Add(messageListread)
            gramread.Rules.Add(messageRuleread)
            gramread.Root = messageRuleread
            recognizerread.LoadGrammar(New Recognition.Grammar(gramread))
            recognizerread.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub recosubdic_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recoSubdicread.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text.ToLower
            MsgBox(sp)
            For i As Integer = 0 To 9

                If sp = ComboBox1.Items(i).ToString Then
                    ComboBox1.Text = ComboBox1.Items(i).ToString
                End If
            Next
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub


    Private Sub recognizer_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles recognizerread.SpeechRecognized
        Try
            Dim sp As String = e.Result.Text.ToLower
            MsgBox(sp)
            If sp.Contains("begin") Then
                listen = 1
                say("I am listening to you.")

            ElseIf sp.Contains("stop") Then
                say("I am not listening to you.")
                listen = 0
            End If

            If listen = 1 And refstr = "DOWNATTACH" Then

                If sp.Contains("yes") Then
                    Dim imap As New ImapX.ImapClient
                    imap.Behavior.MessageFetchMode = MessageFetchMode.Minimal
                    Dim messages = imap.Folders("INBOX").Search(lbSubject.SelectedItem.ToString, True)
                    For Each item As ImapX.Message In messages
                        Dim subject As String = item.Subject
                        Dim name As String = item.From.DisplayName
                        Dim from As String = item.From.Address
                        Dim dates As String = item.Date
                        Dim message As String = item.Body.Text.ToString
                        Dim attach As Integer = 0
                        For Each attachment As ImapX.Attachment In item.Attachments
                            attachment.Download()
                            attachment.Save(My.Computer.FileSystem.SpecialDirectories.MyDocuments)
                            say("File downloaded and stored at " + My.Computer.FileSystem.SpecialDirectories.MyDocuments.ToString)
                            MsgBox("File downloaded and stored at " + My.Computer.FileSystem.SpecialDirectories.MyDocuments.ToString)
                        Next
                    Next
                End If
                If sp.Contains("no") Then

                End If
            End If

            If listen = 1 And refstr = "WHICHMAIL" Then
                recognizerread.RecognizeAsyncCancel()
                recognizerread.UnloadAllGrammars()
                startrecoSubdic()

            End If

            If listen = 1 And refstr = "NXTMAIL" Then
                If sel = 0 Then
                    If sp.ToLower.Contains("yes") Then
                        minref += 1
                        lbFrom.SelectedIndex = minref
                        lbName.SelectedIndex = minref
                        lbDate.SelectedIndex = minref
                        lbSubject.SelectedIndex = minref
                        lbMessage.SelectedIndex = minref
                        lbAttachment.SelectedIndex = minref
                        disp()
                    ElseIf sp.ToLower.Contains("no") Then
                        minref += 1
                        nextmailask()
                    End If
                End If

            End If


            If listen = 1 And refstr = "FIRSTMAIL" Then
                If sel = 0 Then
                    If sp.ToLower.Contains("yes") Then
                        lbFrom.SelectedIndex = minref
                        lbName.SelectedIndex = minref
                        lbDate.SelectedIndex = minref
                        lbSubject.SelectedIndex = minref
                        lbMessage.SelectedIndex = minref
                        lbAttachment.SelectedIndex = minref
                        disp()
                    ElseIf sp.ToLower.Contains("no") Then
                        nextmailask()
                    End If
                End If
            End If
            If listen = 1 And refstr = "COMPOSEMAIL" Then

                If sp.ToLower.Contains("yes") Then
                    ComposeEmail.Show()
                    ComposeEmail.tbFrom.Text = Me.tbUN.Text
                    ComposeEmail.tbPass.Text = Me.tbPW.Text
                ElseIf sp.ToLower.Contains("no") Then

                End If
            End If

            If (sp.Contains("exit") Or sp.Contains("quit") Or sp.Contains("close") Or sp.Contains("turn off") Or sp.Contains("terminate")) Then
                acktone()
                recognizerread.RecognizeAsyncCancel()
                recognizerread.UnloadAllGrammars()
                recoSubdicread.RecognizeAsyncCancel()
                recoSubdicread.UnloadAllGrammars()
                sel = 1
                say("Application closing please wait")


                My.Forms.ComposeRead.Show()
                Me.Hide()
                Me.Close()

            End If
            sp = ""
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub
    Public Sub say(ByVal msg As String)
        Try
            Dim synthread As New SpeechSynthesizer()
            synthread.SetOutputToDefaultAudioDevice()
            synthread.SelectVoiceByHints(VoiceGender.Female)
            synthread.Rate = -3
            synthread.Volume = 100


            synthread.Speak(msg)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub
    Private Sub nextmailask()
        Try
            refstr = "NXTMAIL"
            lbSubject.SelectedIndex = (minref + 1)
            say("Do you want to read next mail with subject " + lbSubject.SelectedItem.ToString)

        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub firstmailask()
        Try
            refstr = "FIRSTMAIL"
            lbSubject.SelectedIndex = (minref)
            say("Do you want to read mail with subject " + lbSubject.SelectedItem.ToString)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub loadnextten()
        Try
            For i As Integer = 0 To 10
                ComboBox1.Items.RemoveAt(i)
            Next

            For i As Integer = 0 To 10
                lbSubject.SelectedIndex = maxref
                ComboBox1.Items.Add(lbSubject.SelectedItem.ToString)
                maxref += 1
            Next
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub composemail()
        Try
            say("Do you want to compose mail?")
            refstr = "COMPOSEMAIL"
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub
    Private Sub downattach()
        Try
            say("Do you want to download attachment?")
            refstr = "DOWNATTACH"
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try

            MsgBox("Logout Successful")
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub
    Private Sub retrive()
        Try
            Dim imap As New ImapX.ImapClient
            count = 0
            imap.Connect("imap.gmail.com", 993, Security.Authentication.SslProtocols.Default)
            If (imap.IsConnected) Then
                say("Connected to Gmail Server for IMAP")

            End If
            imap.Login(tbUN.Text, tbPW.Text)
            ' imap.Login("bevbes0", "bevbes00")
            imap.Behavior.MessageFetchMode = MessageFetchMode.Minimal

            Dim messages = imap.Folders("INBOX").Search("ALL", True)
            For Each item As ImapX.Message In messages
                Dim subject As String = item.Subject
                Dim name As String = item.From.DisplayName
                Dim from As String = item.From.Address
                Dim dates As String = item.Date
                Dim message As String = item.Body.Text.ToString
                Dim attach As Integer = 0

                If subject = Nothing Then
                    subject = "No subject specified by the sender " + name
                End If
                If message = Nothing Or message = "" Or message.Count <= 2 Then
                    message = "No message specified by the sender " + name

                End If

                subdic.Add(subject.ToString)
                For Each attachment As ImapX.Attachment In item.Attachments
                    attach += 1
                Next
                lbSubject.Items.Add(subject.ToString)
                lbFrom.Items.Add(from.ToString)
                lbName.Items.Add(name.ToString)
                lbDate.Items.Add(dates.ToString)
                lbMessage.Items.Add(message.ToString)
                lbAttachment.Items.Add(attach.ToString)

            Next
            announcement()
            firstmailask()
            startSpeechRecognizer()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub startrecoSubdic()
        Try
            recoSubdicread.SetInputToDefaultAudioDevice()
            Dim gramsubdicread As New Recognition.SrgsGrammar.SrgsDocument
            Dim messageRulesubdicread As New Recognition.SrgsGrammar.SrgsRule("message")
            Dim subdicl As String() = CType(subdic.ToArray(GetType(String)), String())
            Dim messageListsubdicread As New Recognition.SrgsGrammar.SrgsOneOf(subdicl)
            messageRulesubdicread.Add(messageListsubdicread)
            gramsubdicread.Rules.Add(messageRulesubdicread)
            gramsubdicread.Root = messageRulesubdicread
            recoSubdicread.LoadGrammar(New Recognition.Grammar(gramsubdicread))
            recoSubdicread.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub ReadEmail_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try
            say("Your application has gained focus.")
            say("Please Wait inbox is loading")
            acktone()
            If CheckForInternetConnection() = True Then
                retrive()
            Else
                say("You are not connected to internet. Please check your internet connection")
            End If

        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub
    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New Net.WebClient()
                Using stream = client.OpenRead("http://www.google.com")

                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim index As Integer = ComboBox1.SelectedIndex.ToString
            Dim pos As Integer = Integer.Parse(iterations * 10 + index)
            MsgBox(pos)
            lbFrom.SelectedIndex = pos
            lbName.SelectedIndex = pos
            lbDate.SelectedIndex = pos
            lbSubject.SelectedIndex = pos
            lbMessage.SelectedIndex = pos
            lbAttachment.SelectedIndex = pos
            disp()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub
    Private Sub readsub()
        Try
            For i As Integer = 1 To 10
                ComboBox1.SelectedItem = i
                say("The subject Of mail " + i.ToString + " is " + ComboBox1.SelectedText.ToString)
            Next
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub disp()
        Try
            readmail.Height = 10
            readmail.Width = 10
            readmail.Text = "From: " + lbFrom.SelectedItem.ToString + vbNewLine + "Name: " + lbName.SelectedItem.ToString + vbNewLine + "Date: " + lbDate.SelectedItem.ToString + vbNewLine + "Subject: " + lbSubject.SelectedItem.ToString + vbNewLine + "Message: " + lbMessage.SelectedItem.ToString + vbNewLine + "Attachment: " + lbAttachment.SelectedItem.ToString
            acktone()
            say("Reading of mail completed.")
            If lbAttachment.SelectedItem.ToString >= 1 Then
                downattach()
            End If
            nextmailask()
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

    Private Sub announcement()
        Try
            say("I am currently  listening to you. Say stop to stop listening.")
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub
    Private Sub readmail_Resize(sender As Object, e As EventArgs) Handles readmail.Resize
        Try
            recoSubdicread.RecognizeAsyncCancel()
            recoSubdicread.UnloadAllGrammars()
            say(readmail.Text.ToString)
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class