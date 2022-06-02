Imports System.Net
Imports System.Speech.Synthesis

Public NotInheritable Class SplashScreen

    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If My.Application.Info.Title <> "" Then
                ApplicationTitle.Text = My.Application.Info.Title
            Else
                ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If
            Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
            Copyright.Text = My.Application.Info.Copyright

        Catch ex As Exception

        End Try
    End Sub

    Private Sub announcement()
        Try

            '    clearthroat()
            say("This is the acknowledgement tone to indicate you are going right. The tone will repeat three times.")
            For i As Integer = 1 To 3
                acktone()
            Next
            say("This is the error tone to indicate you are going wrong. The tone will repeat three times.")
            For i As Integer = 1 To 3
                errortone()
            Next
            say("This is the hover tone to indicate your mouse is over an object. The tone will repeat three times.")
            For i As Integer = 1 To 3
                hovertone()
            Next
            say("This is beep tone to alert you. The tone will repeat only one time.")
            beep()

            say("Checking your internet connection")

            If CheckForInternetConnection() = True Then
                say("You are connected to internet. Application will start in a moment. Please wait.")
                My.Forms.Login.Show()
                Me.Hide()
            Else
                say("You are not connected to internet. Please check your internet connection")
            End If
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

    Private Sub SplashScreen_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            announcement()
        Catch ex As Exception
            say("An error has occurred.")
        End Try
    End Sub

    Private Sub ApplicationTitle_Click(sender As Object, e As EventArgs) Handles ApplicationTitle.Click

    End Sub

    Private Sub MainLayoutPanel_Paint(sender As Object, e As PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
End Class
