<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class copLogAVL
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(copLogAVL))
        Me.TimerFadeForm = New System.Windows.Forms.Timer(Me.components)
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.TimerSecOnLoad = New System.Windows.Forms.Timer(Me.components)
        Me.Sep1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButSet = New System.Windows.Forms.Button()
        Me.TimerMinute = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.SMSLabel = New System.Windows.Forms.Label()
        Me.timeRun = New System.Windows.Forms.Label()
        Me.lblSMS = New System.Windows.Forms.Label()
        Me.lblSMS2 = New System.Windows.Forms.Label()
        Me.lblSMS3 = New System.Windows.Forms.Label()
        Me.lblLogstat = New System.Windows.Forms.Label()
        Me.lblLogError = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.Summary = New System.Windows.Forms.TabPage()
        Me.textScroll = New System.Windows.Forms.TextBox()
        Me.SumAd = New System.Windows.Forms.TabPage()
        Me.TextAd = New System.Windows.Forms.TextBox()
        Me.Log = New System.Windows.Forms.TabPage()
        Me.LogText = New System.Windows.Forms.TextBox()
        Me.Log_Clear = New System.Windows.Forms.Button()
        Me.sourceHit = New System.Windows.Forms.Label()
        Me.trackHit = New System.Windows.Forms.Label()
        Me.valueHit = New System.Windows.Forms.Label()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.lblTrack = New System.Windows.Forms.Label()
        Me.lblHit = New System.Windows.Forms.Label()
        Me.lblSourceFilter = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RadioTMode = New System.Windows.Forms.RadioButton()
        Me.RadioDMode = New System.Windows.Forms.RadioButton()
        Me.TimerHour = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.TimerDay = New System.Windows.Forms.Timer(Me.components)
        Me.TimerFullHour = New System.Windows.Forms.Timer(Me.components)
        Me.COMPortText = New copLogSMS.PlaceHolderTextBox()
        Me.SourceBox = New copLogSMS.PlaceHolderTextBox()
        Me.PassBox = New copLogSMS.PlaceHolderTextBox()
        Me.UserBox = New copLogSMS.PlaceHolderTextBox()
        Me.IPBox = New copLogSMS.PlaceHolderTextBox()
        Me.SMSFilter = New copLogSMS.PlaceHolderTextBox()
        Me.SMSTextBox = New copLogSMS.PlaceHolderTextBox()
        Me.SliderFilter = New copLogSMS.slider()
        Me.SliderError = New copLogSMS.slider()
        Me.SliderStat = New copLogSMS.slider()
        Me.SliderSMS = New copLogSMS.slider()
        Me.TabControl.SuspendLayout
        Me.Summary.SuspendLayout
        Me.SumAd.SuspendLayout
        Me.Log.SuspendLayout
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox6,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TimerFadeForm
        '
        Me.TimerFadeForm.Enabled = true
        '
        'DateLabel
        '
        Me.DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.DateLabel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.DateLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DateLabel.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.DateLabel.Location = New System.Drawing.Point(0, 284)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(198, 23)
        Me.DateLabel.TabIndex = 2
        Me.DateLabel.Text = "00:00:00 00000000"
        Me.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerSecOnLoad
        '
        Me.TimerSecOnLoad.Interval = 1000
        '
        'Sep1
        '
        Me.Sep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Sep1.Location = New System.Drawing.Point(0, 284)
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Size = New System.Drawing.Size(382, 2)
        Me.Sep1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(381, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(2, 290)
        Me.Label1.TabIndex = 6
        '
        'ButSet
        '
        Me.ButSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButSet.Font = New System.Drawing.Font("Lucida Fax", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ButSet.Location = New System.Drawing.Point(282, 284)
        Me.ButSet.Name = "ButSet"
        Me.ButSet.Size = New System.Drawing.Size(100, 23)
        Me.ButSet.TabIndex = 7
        Me.ButSet.Text = "Advance Setting"
        Me.ButSet.UseVisualStyleBackColor = true
        '
        'TimerMinute
        '
        Me.TimerMinute.Interval = 60000
        '
        'ButtonStart
        '
        Me.ButtonStart.Font = New System.Drawing.Font("Lucida Fax", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ButtonStart.Location = New System.Drawing.Point(248, 5)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(130, 41)
        Me.ButtonStart.TabIndex = 8
        Me.ButtonStart.Text = "START"
        Me.ButtonStart.UseVisualStyleBackColor = true
        '
        'SMSLabel
        '
        Me.SMSLabel.AutoSize = true
        Me.SMSLabel.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.SMSLabel.ForeColor = System.Drawing.Color.Black
        Me.SMSLabel.Location = New System.Drawing.Point(463, 3)
        Me.SMSLabel.Name = "SMSLabel"
        Me.SMSLabel.Size = New System.Drawing.Size(38, 20)
        Me.SMSLabel.TabIndex = 9
        Me.SMSLabel.Text = "SMS"
        '
        'timeRun
        '
        Me.timeRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.timeRun.BackColor = System.Drawing.SystemColors.GrayText
        Me.timeRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.timeRun.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.timeRun.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.timeRun.Location = New System.Drawing.Point(196, 284)
        Me.timeRun.Name = "timeRun"
        Me.timeRun.Size = New System.Drawing.Size(85, 23)
        Me.timeRun.TabIndex = 11
        Me.timeRun.Text = "00:00 Hrs"
        Me.timeRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSMS
        '
        Me.lblSMS.AutoSize = true
        Me.lblSMS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblSMS.Location = New System.Drawing.Point(245, 88)
        Me.lblSMS.Name = "lblSMS"
        Me.lblSMS.Size = New System.Drawing.Size(69, 16)
        Me.lblSMS.TabIndex = 12
        Me.lblSMS.Text = "SMS SENT :"
        '
        'lblSMS2
        '
        Me.lblSMS2.Location = New System.Drawing.Point(308, 90)
        Me.lblSMS2.Name = "lblSMS2"
        Me.lblSMS2.Size = New System.Drawing.Size(43, 14)
        Me.lblSMS2.TabIndex = 14
        Me.lblSMS2.Text = "0"
        Me.lblSMS2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSMS3
        '
        Me.lblSMS3.AutoSize = true
        Me.lblSMS3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblSMS3.Location = New System.Drawing.Point(350, 88)
        Me.lblSMS3.Name = "lblSMS3"
        Me.lblSMS3.Size = New System.Drawing.Size(31, 16)
        Me.lblSMS3.TabIndex = 15
        Me.lblSMS3.Text = "times"
        '
        'lblLogstat
        '
        Me.lblLogstat.AutoSize = true
        Me.lblLogstat.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblLogstat.ForeColor = System.Drawing.Color.Black
        Me.lblLogstat.Location = New System.Drawing.Point(463, 125)
        Me.lblLogstat.Name = "lblLogstat"
        Me.lblLogstat.Size = New System.Drawing.Size(97, 20)
        Me.lblLogstat.TabIndex = 18
        Me.lblLogstat.Text = "LOG STAT DB"
        '
        'lblLogError
        '
        Me.lblLogError.AutoSize = true
        Me.lblLogError.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblLogError.ForeColor = System.Drawing.Color.Black
        Me.lblLogError.Location = New System.Drawing.Point(463, 150)
        Me.lblLogError.Name = "lblLogError"
        Me.lblLogError.Size = New System.Drawing.Size(109, 20)
        Me.lblLogError.TabIndex = 19
        Me.lblLogError.Text = "LOG ERROR DB"
        '
        'TabControl
        '
        Me.TabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TabControl.Controls.Add(Me.Summary)
        Me.TabControl.Controls.Add(Me.SumAd)
        Me.TabControl.Controls.Add(Me.Log)
        Me.TabControl.Location = New System.Drawing.Point(3, 82)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(378, 196)
        Me.TabControl.TabIndex = 20
        '
        'Summary
        '
        Me.Summary.Controls.Add(Me.textScroll)
        Me.Summary.Location = New System.Drawing.Point(4, 22)
        Me.Summary.Name = "Summary"
        Me.Summary.Padding = New System.Windows.Forms.Padding(3)
        Me.Summary.Size = New System.Drawing.Size(370, 170)
        Me.Summary.TabIndex = 0
        Me.Summary.Text = "Summary"
        Me.Summary.UseVisualStyleBackColor = true
        '
        'textScroll
        '
        Me.textScroll.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.textScroll.Location = New System.Drawing.Point(0, 1)
        Me.textScroll.Multiline = true
        Me.textScroll.Name = "textScroll"
        Me.textScroll.ReadOnly = true
        Me.textScroll.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textScroll.Size = New System.Drawing.Size(369, 173)
        Me.textScroll.TabIndex = 14
        '
        'SumAd
        '
        Me.SumAd.Controls.Add(Me.TextAd)
        Me.SumAd.Location = New System.Drawing.Point(4, 22)
        Me.SumAd.Name = "SumAd"
        Me.SumAd.Size = New System.Drawing.Size(370, 170)
        Me.SumAd.TabIndex = 2
        Me.SumAd.Text = "Advance Sum."
        Me.SumAd.UseVisualStyleBackColor = true
        '
        'TextAd
        '
        Me.TextAd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TextAd.Location = New System.Drawing.Point(0, 1)
        Me.TextAd.Multiline = true
        Me.TextAd.Name = "TextAd"
        Me.TextAd.ReadOnly = true
        Me.TextAd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextAd.Size = New System.Drawing.Size(369, 173)
        Me.TextAd.TabIndex = 15
        '
        'Log
        '
        Me.Log.Controls.Add(Me.LogText)
        Me.Log.Controls.Add(Me.Log_Clear)
        Me.Log.Location = New System.Drawing.Point(4, 22)
        Me.Log.Name = "Log"
        Me.Log.Padding = New System.Windows.Forms.Padding(3)
        Me.Log.Size = New System.Drawing.Size(370, 170)
        Me.Log.TabIndex = 1
        Me.Log.Text = "Error Log"
        Me.Log.UseVisualStyleBackColor = true
        '
        'LogText
        '
        Me.LogText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.LogText.Location = New System.Drawing.Point(0, 1)
        Me.LogText.MaxLength = 65535
        Me.LogText.Multiline = true
        Me.LogText.Name = "LogText"
        Me.LogText.ReadOnly = true
        Me.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LogText.Size = New System.Drawing.Size(369, 145)
        Me.LogText.TabIndex = 0
        '
        'Log_Clear
        '
        Me.Log_Clear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Log_Clear.BackColor = System.Drawing.Color.DarkGray
        Me.Log_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Log_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Log_Clear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Log_Clear.Location = New System.Drawing.Point(-1, 144)
        Me.Log_Clear.Margin = New System.Windows.Forms.Padding(0)
        Me.Log_Clear.Name = "Log_Clear"
        Me.Log_Clear.Size = New System.Drawing.Size(371, 27)
        Me.Log_Clear.TabIndex = 17
        Me.Log_Clear.Text = "CLEAR"
        Me.Log_Clear.UseVisualStyleBackColor = false
        '
        'sourceHit
        '
        Me.sourceHit.AutoSize = true
        Me.sourceHit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.sourceHit.Location = New System.Drawing.Point(106, 55)
        Me.sourceHit.Name = "sourceHit"
        Me.sourceHit.Size = New System.Drawing.Size(16, 17)
        Me.sourceHit.TabIndex = 29
        Me.sourceHit.Text = "0"
        Me.sourceHit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'trackHit
        '
        Me.trackHit.AutoSize = true
        Me.trackHit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.trackHit.Location = New System.Drawing.Point(106, 30)
        Me.trackHit.Name = "trackHit"
        Me.trackHit.Size = New System.Drawing.Size(16, 17)
        Me.trackHit.TabIndex = 28
        Me.trackHit.Text = "0"
        Me.trackHit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'valueHit
        '
        Me.valueHit.AutoSize = true
        Me.valueHit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.valueHit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.valueHit.Location = New System.Drawing.Point(106, 5)
        Me.valueHit.Name = "valueHit"
        Me.valueHit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.valueHit.Size = New System.Drawing.Size(17, 17)
        Me.valueHit.TabIndex = 27
        Me.valueHit.Text = "0"
        Me.valueHit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSource
        '
        Me.lblSource.AutoSize = true
        Me.lblSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblSource.Location = New System.Drawing.Point(4, 55)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(108, 17)
        Me.lblSource.TabIndex = 26
        Me.lblSource.Text = "Total Sources  :"
        '
        'lblTrack
        '
        Me.lblTrack.AutoSize = true
        Me.lblTrack.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTrack.Location = New System.Drawing.Point(4, 30)
        Me.lblTrack.Name = "lblTrack"
        Me.lblTrack.Size = New System.Drawing.Size(106, 17)
        Me.lblTrack.TabIndex = 25
        Me.lblTrack.Text = "Total tracks     :"
        '
        'lblHit
        '
        Me.lblHit.AutoSize = true
        Me.lblHit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblHit.Location = New System.Drawing.Point(4, 5)
        Me.lblHit.Name = "lblHit"
        Me.lblHit.Size = New System.Drawing.Size(106, 17)
        Me.lblHit.TabIndex = 24
        Me.lblHit.Text = "Total hits     :"
        '
        'lblSourceFilter
        '
        Me.lblSourceFilter.AutoSize = true
        Me.lblSourceFilter.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblSourceFilter.ForeColor = System.Drawing.Color.Black
        Me.lblSourceFilter.Location = New System.Drawing.Point(463, 257)
        Me.lblSourceFilter.Name = "lblSourceFilter"
        Me.lblSourceFilter.Size = New System.Drawing.Size(84, 20)
        Me.lblSourceFilter.TabIndex = 32
        Me.lblSourceFilter.Text = "Souce Filter"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.copLogSMS.My.Resources.Resources.fil
        Me.PictureBox5.Location = New System.Drawing.Point(388, 283)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox5.TabIndex = 36
        Me.PictureBox5.TabStop = false
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.copLogSMS.My.Resources.Resources.pass
        Me.PictureBox4.Location = New System.Drawing.Point(388, 230)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox4.TabIndex = 35
        Me.PictureBox4.TabStop = false
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.copLogSMS.My.Resources.Resources.user
        Me.PictureBox3.Location = New System.Drawing.Point(389, 203)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox3.TabIndex = 34
        Me.PictureBox3.TabStop = false
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.copLogSMS.My.Resources.Resources.ip
        Me.PictureBox2.Location = New System.Drawing.Point(388, 176)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = false
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.copLogSMS.My.Resources.Resources.Phone_icon
        Me.PictureBox1.Location = New System.Drawing.Point(385, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = false
        '
        'RadioTMode
        '
        Me.RadioTMode.AutoSize = true
        Me.RadioTMode.Checked = true
        Me.RadioTMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RadioTMode.Location = New System.Drawing.Point(265, 47)
        Me.RadioTMode.Name = "RadioTMode"
        Me.RadioTMode.Size = New System.Drawing.Size(72, 16)
        Me.RadioTMode.TabIndex = 44
        Me.RadioTMode.TabStop = true
        Me.RadioTMode.Text = "Track Mode"
        Me.RadioTMode.UseVisualStyleBackColor = true
        '
        'RadioDMode
        '
        Me.RadioDMode.AutoSize = true
        Me.RadioDMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RadioDMode.Location = New System.Drawing.Point(265, 62)
        Me.RadioDMode.Name = "RadioDMode"
        Me.RadioDMode.Size = New System.Drawing.Size(89, 16)
        Me.RadioDMode.TabIndex = 45
        Me.RadioDMode.Text = "DEFCON Mode"
        Me.RadioDMode.UseVisualStyleBackColor = true
        '
        'TimerHour
        '
        Me.TimerHour.Interval = 1800000
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.copLogSMS.My.Resources.Resources.fil
        Me.PictureBox6.Location = New System.Drawing.Point(389, 88)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox6.TabIndex = 47
        Me.PictureBox6.TabStop = false
        '
        'TimerDay
        '
        Me.TimerDay.Interval = 86400000
        '
        'TimerFullHour
        '
        Me.TimerFullHour.Interval = 3600000
        '
        'COMPortText
        '
        Me.COMPortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic)
        Me.COMPortText.ForeColor = System.Drawing.Color.Gray
        Me.COMPortText.Location = New System.Drawing.Point(524, 3)
        Me.COMPortText.Name = "COMPortText"
        Me.COMPortText.PlaceHolderText = "COM1"
        Me.COMPortText.Size = New System.Drawing.Size(56, 24)
        Me.COMPortText.TabIndex = 46
        Me.COMPortText.Text = "COM1"
        '
        'SourceBox
        '
        Me.SourceBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Italic)
        Me.SourceBox.ForeColor = System.Drawing.Color.Gray
        Me.SourceBox.Location = New System.Drawing.Point(421, 284)
        Me.SourceBox.Name = "SourceBox"
        Me.SourceBox.PlaceHolderText = "4.1.1.1,3.1.1.1"
        Me.SourceBox.Size = New System.Drawing.Size(159, 21)
        Me.SourceBox.TabIndex = 43
        Me.SourceBox.Text = "4.1.1.1,3.1.1.1"
        Me.SourceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PassBox
        '
        Me.PassBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Italic)
        Me.PassBox.ForeColor = System.Drawing.Color.Gray
        Me.PassBox.Location = New System.Drawing.Point(421, 230)
        Me.PassBox.Name = "PassBox"
        Me.PassBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassBox.PlaceHolderText = "rujv6hpl^9igpHo"
        Me.PassBox.Size = New System.Drawing.Size(159, 21)
        Me.PassBox.TabIndex = 42
        Me.PassBox.Text = "rujv6hpl^9igpHo"
        Me.PassBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UserBox
        '
        Me.UserBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Italic)
        Me.UserBox.ForeColor = System.Drawing.Color.Gray
        Me.UserBox.Location = New System.Drawing.Point(421, 203)
        Me.UserBox.Name = "UserBox"
        Me.UserBox.PlaceHolderText = "logStat"
        Me.UserBox.Size = New System.Drawing.Size(159, 21)
        Me.UserBox.TabIndex = 41
        Me.UserBox.Text = "logStat"
        Me.UserBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IPBox
        '
        Me.IPBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Italic)
        Me.IPBox.ForeColor = System.Drawing.Color.Gray
        Me.IPBox.Location = New System.Drawing.Point(421, 176)
        Me.IPBox.Name = "IPBox"
        Me.IPBox.PlaceHolderText = "127.0.0.1"
        Me.IPBox.Size = New System.Drawing.Size(159, 21)
        Me.IPBox.TabIndex = 40
        Me.IPBox.Text = "127.0.0.1"
        Me.IPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SMSFilter
        '
        Me.SMSFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.SMSFilter.ForeColor = System.Drawing.Color.Gray
        Me.SMSFilter.Location = New System.Drawing.Point(416, 88)
        Me.SMSFilter.Multiline = true
        Me.SMSFilter.Name = "SMSFilter"
        Me.SMSFilter.PlaceHolderText = "4.1.1.1:ACCS:1:0.5,3.1.1.1:RTN C3I:24:12"
        Me.SMSFilter.Size = New System.Drawing.Size(164, 32)
        Me.SMSFilter.TabIndex = 39
        Me.SMSFilter.Text = "4.1.1.1:ACCS:1:0.5,3.1.1.1:RTN C3I:24:12"
        Me.SMSFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SMSTextBox
        '
        Me.SMSTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.SMSTextBox.ForeColor = System.Drawing.Color.Gray
        Me.SMSTextBox.Location = New System.Drawing.Point(416, 33)
        Me.SMSTextBox.Multiline = true
        Me.SMSTextBox.Name = "SMSTextBox"
        Me.SMSTextBox.PlaceHolderText = "0863883307,0831981821,0801653516,0847571117"
        Me.SMSTextBox.Size = New System.Drawing.Size(164, 52)
        Me.SMSTextBox.TabIndex = 38
        Me.SMSTextBox.Text = "0863883307,0831981821,0801653516,0847571117"
        Me.SMSTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SliderFilter
        '
        Me.SliderFilter.Location = New System.Drawing.Point(385, 257)
        Me.SliderFilter.Name = "SliderFilter"
        Me.SliderFilter.Size = New System.Drawing.Size(64, 20)
        Me.SliderFilter.TabIndex = 30
        '
        'SliderError
        '
        Me.SliderError.Location = New System.Drawing.Point(385, 150)
        Me.SliderError.Name = "SliderError"
        Me.SliderError.Size = New System.Drawing.Size(64, 20)
        Me.SliderError.TabIndex = 17
        '
        'SliderStat
        '
        Me.SliderStat.Location = New System.Drawing.Point(385, 124)
        Me.SliderStat.Name = "SliderStat"
        Me.SliderStat.Size = New System.Drawing.Size(64, 20)
        Me.SliderStat.TabIndex = 16
        '
        'SliderSMS
        '
        Me.SliderSMS.Location = New System.Drawing.Point(385, 5)
        Me.SliderSMS.Name = "SliderSMS"
        Me.SliderSMS.Size = New System.Drawing.Size(64, 20)
        Me.SliderSMS.TabIndex = 3
        '
        'copLogAVL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(584, 307)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.COMPortText)
        Me.Controls.Add(Me.RadioDMode)
        Me.Controls.Add(Me.RadioTMode)
        Me.Controls.Add(Me.SourceBox)
        Me.Controls.Add(Me.PassBox)
        Me.Controls.Add(Me.UserBox)
        Me.Controls.Add(Me.IPBox)
        Me.Controls.Add(Me.SMSFilter)
        Me.Controls.Add(Me.SMSTextBox)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblSourceFilter)
        Me.Controls.Add(Me.SliderFilter)
        Me.Controls.Add(Me.sourceHit)
        Me.Controls.Add(Me.trackHit)
        Me.Controls.Add(Me.valueHit)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.lblTrack)
        Me.Controls.Add(Me.lblHit)
        Me.Controls.Add(Me.lblLogError)
        Me.Controls.Add(Me.lblLogstat)
        Me.Controls.Add(Me.SliderError)
        Me.Controls.Add(Me.SliderStat)
        Me.Controls.Add(Me.lblSMS3)
        Me.Controls.Add(Me.lblSMS2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblSMS)
        Me.Controls.Add(Me.timeRun)
        Me.Controls.Add(Me.SMSLabel)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.DateLabel)
        Me.Controls.Add(Me.ButSet)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Sep1)
        Me.Controls.Add(Me.SliderSMS)
        Me.Controls.Add(Me.TabControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "copLogAVL"
        Me.Opacity = 0R
        Me.Text = "COP LOG AVL"
        Me.TabControl.ResumeLayout(false)
        Me.Summary.ResumeLayout(false)
        Me.Summary.PerformLayout
        Me.SumAd.ResumeLayout(false)
        Me.SumAd.PerformLayout
        Me.Log.ResumeLayout(false)
        Me.Log.PerformLayout
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox6,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents DateLabel As System.Windows.Forms.Label
    Friend WithEvents TimerSecOnLoad As System.Windows.Forms.Timer
    Friend WithEvents SliderSMS As copLogSMS.slider
    Friend WithEvents TimerFadeForm As System.Windows.Forms.Timer
    Friend WithEvents Sep1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButSet As System.Windows.Forms.Button
    Friend WithEvents TimerMinute As System.Windows.Forms.Timer
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents SMSLabel As System.Windows.Forms.Label
    Friend WithEvents timeRun As System.Windows.Forms.Label
    Friend WithEvents lblSMS As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblSMS2 As System.Windows.Forms.Label
    Friend WithEvents lblSMS3 As System.Windows.Forms.Label
    Friend WithEvents SliderStat As copLogSMS.slider
    Friend WithEvents SliderError As copLogSMS.slider
    Friend WithEvents lblLogstat As System.Windows.Forms.Label
    Friend WithEvents lblLogError As System.Windows.Forms.Label
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents Summary As System.Windows.Forms.TabPage
    Friend WithEvents textScroll As System.Windows.Forms.TextBox
    Friend WithEvents Log As System.Windows.Forms.TabPage
    Friend WithEvents LogText As System.Windows.Forms.TextBox
    Friend WithEvents Log_Clear As System.Windows.Forms.Button
    Friend WithEvents sourceHit As System.Windows.Forms.Label
    Friend WithEvents trackHit As System.Windows.Forms.Label
    Friend WithEvents valueHit As System.Windows.Forms.Label
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents lblTrack As System.Windows.Forms.Label
    Friend WithEvents lblHit As System.Windows.Forms.Label
    Friend WithEvents SliderFilter As copLogSMS.slider
    Friend WithEvents lblSourceFilter As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents SMSTextBox As copLogSMS.PlaceHolderTextBox
    Friend WithEvents SMSFilter As copLogSMS.PlaceHolderTextBox
    Friend WithEvents IPBox As copLogSMS.PlaceHolderTextBox
    Friend WithEvents UserBox As copLogSMS.PlaceHolderTextBox
    Friend WithEvents PassBox As copLogSMS.PlaceHolderTextBox
    Friend WithEvents SourceBox As copLogSMS.PlaceHolderTextBox
    Friend WithEvents RadioTMode As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDMode As System.Windows.Forms.RadioButton
    Friend WithEvents SumAd As System.Windows.Forms.TabPage
    Friend WithEvents TextAd As System.Windows.Forms.TextBox
    Friend WithEvents COMPortText As copLogSMS.PlaceHolderTextBox
    Friend WithEvents TimerHour As System.Windows.Forms.Timer
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents TimerDay As System.Windows.Forms.Timer
    Friend WithEvents TimerFullHour As System.Windows.Forms.Timer

End Class
