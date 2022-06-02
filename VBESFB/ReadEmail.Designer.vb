<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReadEmail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tbUN = New System.Windows.Forms.TextBox()
        Me.tbPW = New System.Windows.Forms.TextBox()
        Me.readmail = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.lbFrom = New System.Windows.Forms.ListBox()
        Me.lbDate = New System.Windows.Forms.ListBox()
        Me.lbSubject = New System.Windows.Forms.ListBox()
        Me.lbMessage = New System.Windows.Forms.ListBox()
        Me.lbAttachment = New System.Windows.Forms.ListBox()
        Me.lbName = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbUN
        '
        Me.tbUN.Location = New System.Drawing.Point(1050, 7)
        Me.tbUN.Name = "tbUN"
        Me.tbUN.Size = New System.Drawing.Size(10, 20)
        Me.tbUN.TabIndex = 1
        Me.tbUN.Visible = False
        '
        'tbPW
        '
        Me.tbPW.Location = New System.Drawing.Point(1050, 38)
        Me.tbPW.Name = "tbPW"
        Me.tbPW.Size = New System.Drawing.Size(10, 20)
        Me.tbPW.TabIndex = 2
        Me.tbPW.Visible = False
        '
        'readmail
        '
        Me.readmail.AutoSize = True
        Me.readmail.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.readmail.Location = New System.Drawing.Point(9, 10)
        Me.readmail.Name = "readmail"
        Me.readmail.Size = New System.Drawing.Size(83, 19)
        Me.readmail.TabIndex = 4
        Me.readmail.Text = "retrived mail"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 64)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(230, 21)
        Me.ComboBox1.TabIndex = 6
        Me.ComboBox1.Visible = False
        '
        'lbFrom
        '
        Me.lbFrom.FormattingEnabled = True
        Me.lbFrom.Location = New System.Drawing.Point(12, 107)
        Me.lbFrom.Name = "lbFrom"
        Me.lbFrom.Size = New System.Drawing.Size(230, 43)
        Me.lbFrom.TabIndex = 7
        Me.lbFrom.Visible = False
        '
        'lbDate
        '
        Me.lbDate.FormattingEnabled = True
        Me.lbDate.Location = New System.Drawing.Point(12, 172)
        Me.lbDate.Name = "lbDate"
        Me.lbDate.Size = New System.Drawing.Size(230, 43)
        Me.lbDate.TabIndex = 8
        Me.lbDate.Visible = False
        '
        'lbSubject
        '
        Me.lbSubject.FormattingEnabled = True
        Me.lbSubject.Location = New System.Drawing.Point(12, 237)
        Me.lbSubject.Name = "lbSubject"
        Me.lbSubject.Size = New System.Drawing.Size(230, 43)
        Me.lbSubject.TabIndex = 9
        Me.lbSubject.Visible = False
        '
        'lbMessage
        '
        Me.lbMessage.FormattingEnabled = True
        Me.lbMessage.Location = New System.Drawing.Point(12, 302)
        Me.lbMessage.Name = "lbMessage"
        Me.lbMessage.Size = New System.Drawing.Size(230, 43)
        Me.lbMessage.TabIndex = 10
        Me.lbMessage.Visible = False
        '
        'lbAttachment
        '
        Me.lbAttachment.FormattingEnabled = True
        Me.lbAttachment.Location = New System.Drawing.Point(12, 367)
        Me.lbAttachment.Name = "lbAttachment"
        Me.lbAttachment.Size = New System.Drawing.Size(230, 43)
        Me.lbAttachment.TabIndex = 11
        Me.lbAttachment.Visible = False
        '
        'lbName
        '
        Me.lbName.FormattingEnabled = True
        Me.lbName.Location = New System.Drawing.Point(12, 424)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(230, 43)
        Me.lbName.TabIndex = 12
        Me.lbName.Visible = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1062, 34)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Inbox"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ReadEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1062, 486)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.lbAttachment)
        Me.Controls.Add(Me.lbMessage)
        Me.Controls.Add(Me.lbSubject)
        Me.Controls.Add(Me.lbDate)
        Me.Controls.Add(Me.lbFrom)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.readmail)
        Me.Controls.Add(Me.tbPW)
        Me.Controls.Add(Me.tbUN)
        Me.Name = "ReadEmail"
        Me.Text = "A"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbUN As TextBox
    Friend WithEvents tbPW As TextBox
    Friend WithEvents readmail As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents lbFrom As ListBox
    Friend WithEvents lbDate As ListBox
    Friend WithEvents lbSubject As ListBox
    Friend WithEvents lbMessage As ListBox
    Friend WithEvents lbAttachment As ListBox
    Friend WithEvents lbName As ListBox
    Friend WithEvents Label1 As Label
End Class
