<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ComposeEmail
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbBCC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbSubject = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbMessage = New System.Windows.Forms.RichTextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbkCC = New System.Windows.Forms.CheckBox()
        Me.cbkBCC = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.pgbProcess = New System.Windows.Forms.ProgressBar()
        Me.tbFrom = New System.Windows.Forms.TextBox()
        Me.tbPass = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1107, 34)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Compose Email"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbTo
        '
        Me.tbTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTo.Location = New System.Drawing.Point(112, 63)
        Me.tbTo.Name = "tbTo"
        Me.tbTo.Size = New System.Drawing.Size(387, 26)
        Me.tbTo.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "To:"
        '
        'tbCC
        '
        Me.tbCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCC.Location = New System.Drawing.Point(112, 111)
        Me.tbCC.Name = "tbCC"
        Me.tbCC.Size = New System.Drawing.Size(387, 26)
        Me.tbCC.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "CC:"
        '
        'tbBCC
        '
        Me.tbBCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBCC.Location = New System.Drawing.Point(112, 159)
        Me.tbBCC.Name = "tbBCC"
        Me.tbBCC.Size = New System.Drawing.Size(387, 26)
        Me.tbBCC.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "BCC:"
        '
        'tbSubject
        '
        Me.tbSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSubject.Location = New System.Drawing.Point(112, 207)
        Me.tbSubject.Name = "tbSubject"
        Me.tbSubject.Size = New System.Drawing.Size(387, 26)
        Me.tbSubject.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Subject:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(532, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Message:"
        '
        'tbMessage
        '
        Me.tbMessage.Location = New System.Drawing.Point(642, 63)
        Me.tbMessage.Name = "tbMessage"
        Me.tbMessage.Size = New System.Drawing.Size(387, 221)
        Me.tbMessage.TabIndex = 20
        Me.tbMessage.Text = ""
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(112, 258)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(245, 26)
        Me.TextBox5.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 261)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 20)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Attachments:"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(363, 258)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 26)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(722, 459)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 26)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Send Mail"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cbkCC
        '
        Me.cbkCC.AutoSize = True
        Me.cbkCC.Location = New System.Drawing.Point(23, 92)
        Me.cbkCC.Name = "cbkCC"
        Me.cbkCC.Size = New System.Drawing.Size(62, 17)
        Me.cbkCC.TabIndex = 25
        Me.cbkCC.Text = "Add CC"
        Me.cbkCC.UseVisualStyleBackColor = True
        '
        'cbkBCC
        '
        Me.cbkBCC.AutoSize = True
        Me.cbkBCC.Location = New System.Drawing.Point(23, 142)
        Me.cbkBCC.Name = "cbkBCC"
        Me.cbkBCC.Size = New System.Drawing.Size(69, 17)
        Me.cbkBCC.TabIndex = 26
        Me.cbkBCC.Text = "Add BCC"
        Me.cbkBCC.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(6, 241)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(107, 17)
        Me.CheckBox3.TabIndex = 27
        Me.CheckBox3.Text = "Add Attachments"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(6, 306)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(1004, 147)
        Me.ListBox1.TabIndex = 28
        '
        'pgbProcess
        '
        Me.pgbProcess.Location = New System.Drawing.Point(278, 467)
        Me.pgbProcess.Name = "pgbProcess"
        Me.pgbProcess.Size = New System.Drawing.Size(424, 10)
        Me.pgbProcess.TabIndex = 29
        '
        'tbFrom
        '
        Me.tbFrom.Location = New System.Drawing.Point(510, 241)
        Me.tbFrom.Name = "tbFrom"
        Me.tbFrom.Size = New System.Drawing.Size(100, 20)
        Me.tbFrom.TabIndex = 30
        Me.tbFrom.Visible = False
        '
        'tbPass
        '
        Me.tbPass.Location = New System.Drawing.Point(510, 213)
        Me.tbPass.Name = "tbPass"
        Me.tbPass.Size = New System.Drawing.Size(100, 20)
        Me.tbPass.TabIndex = 31
        Me.tbPass.Visible = False
        '
        'ComposeEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1107, 497)
        Me.Controls.Add(Me.tbPass)
        Me.Controls.Add(Me.tbFrom)
        Me.Controls.Add(Me.pgbProcess)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.cbkBCC)
        Me.Controls.Add(Me.cbkCC)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbMessage)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbSubject)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbBCC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbCC)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ComposeEmail"
        Me.Text = "ComposeEmail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbTo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbCC As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbBCC As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbSubject As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbMessage As RichTextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button2 As Button
    Friend WithEvents cbkCC As CheckBox
    Friend WithEvents cbkBCC As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents pgbProcess As ProgressBar
    Friend WithEvents tbFrom As TextBox
    Friend WithEvents tbPass As TextBox
End Class
