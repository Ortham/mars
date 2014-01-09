<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI
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
        Me.txtOutputLocation = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.txtSets = New System.Windows.Forms.TextBox()
        Me.txtDelay = New System.Windows.Forms.TextBox()
        Me.txtCompliance = New System.Windows.Forms.TextBox()
        Me.txtTDrainCount = New System.Windows.Forms.TextBox()
        Me.txtTDrainStop = New System.Windows.Forms.TextBox()
        Me.txtTDrainStart = New System.Windows.Forms.TextBox()
        Me.txtTGateCount = New System.Windows.Forms.TextBox()
        Me.txtTGateStop = New System.Windows.Forms.TextBox()
        Me.txtTGateStart = New System.Windows.Forms.TextBox()
        Me.txtLabel = New System.Windows.Forms.TextBox()
        Me.txtDevAddress = New System.Windows.Forms.TextBox()
        Me.BrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.stsStatusBar = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtTDrainStepSize = New System.Windows.Forms.TextBox()
        Me.txtTGateStepSize = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtODrainStepSize = New System.Windows.Forms.TextBox()
        Me.txtOGateStepSize = New System.Windows.Forms.TextBox()
        Me.txtODrainCount = New System.Windows.Forms.TextBox()
        Me.txtODrainStop = New System.Windows.Forms.TextBox()
        Me.txtODrainStart = New System.Windows.Forms.TextBox()
        Me.txtOGateCount = New System.Windows.Forms.TextBox()
        Me.txtOGateStop = New System.Windows.Forms.TextBox()
        Me.txtOGateStart = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Worker = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtAperture = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtGateBiasVoltage = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtDrainBiasVoltage = New System.Windows.Forms.TextBox()
        Me.stsStatusBar.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOutputLocation
        '
        Me.txtOutputLocation.Location = New System.Drawing.Point(146, 60)
        Me.txtOutputLocation.Name = "txtOutputLocation"
        Me.txtOutputLocation.Size = New System.Drawing.Size(253, 20)
        Me.txtOutputLocation.TabIndex = 55
        Me.txtOutputLocation.Text = "C:\"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Output Location"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 360)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 13)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "Repeat Interval (s)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 334)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 13)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "No. of Measurement Sets"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 13)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Measurement Delay (s)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Compliance (A)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Drain Step Count"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Drain Stop (V)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Drain Start (V)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Gate Step Count"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Gate Stop (V)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Gate Start (V)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "File label"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Device Address"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(227, 399)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(130, 28)
        Me.btnClose.TabIndex = 41
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(63, 399)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(106, 28)
        Me.btnRun.TabIndex = 40
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(146, 357)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(253, 20)
        Me.txtInterval.TabIndex = 39
        Me.txtInterval.Text = "0"
        '
        'txtSets
        '
        Me.txtSets.Location = New System.Drawing.Point(146, 331)
        Me.txtSets.Name = "txtSets"
        Me.txtSets.Size = New System.Drawing.Size(253, 20)
        Me.txtSets.TabIndex = 38
        Me.txtSets.Text = "1"
        '
        'txtDelay
        '
        Me.txtDelay.Location = New System.Drawing.Point(153, 91)
        Me.txtDelay.Name = "txtDelay"
        Me.txtDelay.Size = New System.Drawing.Size(203, 20)
        Me.txtDelay.TabIndex = 37
        Me.txtDelay.Text = "0.0005"
        '
        'txtCompliance
        '
        Me.txtCompliance.Location = New System.Drawing.Point(153, 65)
        Me.txtCompliance.Name = "txtCompliance"
        Me.txtCompliance.Size = New System.Drawing.Size(203, 20)
        Me.txtCompliance.TabIndex = 36
        Me.txtCompliance.Text = "0.01"
        '
        'txtTDrainCount
        '
        Me.txtTDrainCount.Location = New System.Drawing.Point(126, 144)
        Me.txtTDrainCount.Name = "txtTDrainCount"
        Me.txtTDrainCount.Size = New System.Drawing.Size(97, 20)
        Me.txtTDrainCount.TabIndex = 35
        Me.txtTDrainCount.Text = "0"
        '
        'txtTDrainStop
        '
        Me.txtTDrainStop.Location = New System.Drawing.Point(126, 118)
        Me.txtTDrainStop.Name = "txtTDrainStop"
        Me.txtTDrainStop.Size = New System.Drawing.Size(230, 20)
        Me.txtTDrainStop.TabIndex = 34
        Me.txtTDrainStop.Text = "0"
        '
        'txtTDrainStart
        '
        Me.txtTDrainStart.Location = New System.Drawing.Point(126, 92)
        Me.txtTDrainStart.Name = "txtTDrainStart"
        Me.txtTDrainStart.Size = New System.Drawing.Size(230, 20)
        Me.txtTDrainStart.TabIndex = 33
        Me.txtTDrainStart.Text = "0"
        '
        'txtTGateCount
        '
        Me.txtTGateCount.Location = New System.Drawing.Point(126, 66)
        Me.txtTGateCount.Name = "txtTGateCount"
        Me.txtTGateCount.Size = New System.Drawing.Size(97, 20)
        Me.txtTGateCount.TabIndex = 32
        Me.txtTGateCount.Text = "0"
        '
        'txtTGateStop
        '
        Me.txtTGateStop.Location = New System.Drawing.Point(126, 40)
        Me.txtTGateStop.Name = "txtTGateStop"
        Me.txtTGateStop.Size = New System.Drawing.Size(230, 20)
        Me.txtTGateStop.TabIndex = 31
        Me.txtTGateStop.Text = "0"
        '
        'txtTGateStart
        '
        Me.txtTGateStart.Location = New System.Drawing.Point(126, 13)
        Me.txtTGateStart.Name = "txtTGateStart"
        Me.txtTGateStart.Size = New System.Drawing.Size(230, 20)
        Me.txtTGateStart.TabIndex = 30
        Me.txtTGateStart.Text = "0"
        '
        'txtLabel
        '
        Me.txtLabel.Location = New System.Drawing.Point(146, 87)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.Size = New System.Drawing.Size(253, 20)
        Me.txtLabel.TabIndex = 29
        Me.txtLabel.Text = "measurement"
        '
        'txtDevAddress
        '
        Me.txtDevAddress.Location = New System.Drawing.Point(146, 34)
        Me.txtDevAddress.Name = "txtDevAddress"
        Me.txtDevAddress.Size = New System.Drawing.Size(253, 20)
        Me.txtDevAddress.TabIndex = 28
        Me.txtDevAddress.Text = "USB0::0x0957::0x8C18::my51140134::0::INSTR"
        '
        'BrowserDialog
        '
        Me.BrowserDialog.Description = "Please select a folder in which to store the data."
        '
        'stsStatusBar
        '
        Me.stsStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.stsStatusBar.Location = New System.Drawing.Point(0, 447)
        Me.stsStatusBar.Name = "stsStatusBar"
        Me.stsStatusBar.Size = New System.Drawing.Size(411, 22)
        Me.stsStatusBar.TabIndex = 56
        Me.stsStatusBar.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(77, 17)
        Me.lblStatus.Text = "Status: Ready"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(16, 113)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(383, 203)
        Me.TabControl1.TabIndex = 57
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtTDrainStepSize)
        Me.TabPage1.Controls.Add(Me.txtTGateStepSize)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtTGateStart)
        Me.TabPage1.Controls.Add(Me.txtTGateStop)
        Me.TabPage1.Controls.Add(Me.txtTGateCount)
        Me.TabPage1.Controls.Add(Me.txtTDrainStart)
        Me.TabPage1.Controls.Add(Me.txtTDrainStop)
        Me.TabPage1.Controls.Add(Me.txtTDrainCount)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(375, 177)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Transfer"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtTDrainStepSize
        '
        Me.txtTDrainStepSize.Location = New System.Drawing.Point(287, 145)
        Me.txtTDrainStepSize.Name = "txtTDrainStepSize"
        Me.txtTDrainStepSize.ReadOnly = True
        Me.txtTDrainStepSize.Size = New System.Drawing.Size(69, 20)
        Me.txtTDrainStepSize.TabIndex = 53
        '
        'txtTGateStepSize
        '
        Me.txtTGateStepSize.Location = New System.Drawing.Point(287, 66)
        Me.txtTGateStepSize.Name = "txtTGateStepSize"
        Me.txtTGateStepSize.ReadOnly = True
        Me.txtTGateStepSize.Size = New System.Drawing.Size(69, 20)
        Me.txtTGateStepSize.TabIndex = 52
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(229, 148)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 51
        Me.Label21.Text = "Step Size"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(229, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 13)
        Me.Label20.TabIndex = 50
        Me.Label20.Text = "Step Size"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.txtODrainStepSize)
        Me.TabPage2.Controls.Add(Me.txtOGateStepSize)
        Me.TabPage2.Controls.Add(Me.txtODrainCount)
        Me.TabPage2.Controls.Add(Me.txtODrainStop)
        Me.TabPage2.Controls.Add(Me.txtODrainStart)
        Me.TabPage2.Controls.Add(Me.txtOGateCount)
        Me.TabPage2.Controls.Add(Me.txtOGateStop)
        Me.TabPage2.Controls.Add(Me.txtOGateStart)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(375, 177)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Output"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(229, 148)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 13)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Step Size"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(229, 69)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 13)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "Step Size"
        '
        'txtODrainStepSize
        '
        Me.txtODrainStepSize.Location = New System.Drawing.Point(287, 145)
        Me.txtODrainStepSize.Name = "txtODrainStepSize"
        Me.txtODrainStepSize.ReadOnly = True
        Me.txtODrainStepSize.Size = New System.Drawing.Size(68, 20)
        Me.txtODrainStepSize.TabIndex = 13
        '
        'txtOGateStepSize
        '
        Me.txtOGateStepSize.Location = New System.Drawing.Point(287, 66)
        Me.txtOGateStepSize.Name = "txtOGateStepSize"
        Me.txtOGateStepSize.ReadOnly = True
        Me.txtOGateStepSize.Size = New System.Drawing.Size(69, 20)
        Me.txtOGateStepSize.TabIndex = 12
        '
        'txtODrainCount
        '
        Me.txtODrainCount.Location = New System.Drawing.Point(126, 144)
        Me.txtODrainCount.Name = "txtODrainCount"
        Me.txtODrainCount.Size = New System.Drawing.Size(97, 20)
        Me.txtODrainCount.TabIndex = 11
        Me.txtODrainCount.Text = "0"
        '
        'txtODrainStop
        '
        Me.txtODrainStop.Location = New System.Drawing.Point(126, 118)
        Me.txtODrainStop.Name = "txtODrainStop"
        Me.txtODrainStop.Size = New System.Drawing.Size(230, 20)
        Me.txtODrainStop.TabIndex = 10
        Me.txtODrainStop.Text = "0"
        '
        'txtODrainStart
        '
        Me.txtODrainStart.Location = New System.Drawing.Point(126, 92)
        Me.txtODrainStart.Name = "txtODrainStart"
        Me.txtODrainStart.Size = New System.Drawing.Size(230, 20)
        Me.txtODrainStart.TabIndex = 9
        Me.txtODrainStart.Text = "0"
        '
        'txtOGateCount
        '
        Me.txtOGateCount.Location = New System.Drawing.Point(126, 66)
        Me.txtOGateCount.Name = "txtOGateCount"
        Me.txtOGateCount.Size = New System.Drawing.Size(97, 20)
        Me.txtOGateCount.TabIndex = 8
        Me.txtOGateCount.Text = "0"
        '
        'txtOGateStop
        '
        Me.txtOGateStop.Location = New System.Drawing.Point(126, 40)
        Me.txtOGateStop.Name = "txtOGateStop"
        Me.txtOGateStop.Size = New System.Drawing.Size(230, 20)
        Me.txtOGateStop.TabIndex = 7
        Me.txtOGateStop.Text = "0"
        '
        'txtOGateStart
        '
        Me.txtOGateStart.Location = New System.Drawing.Point(126, 13)
        Me.txtOGateStart.Name = "txtOGateStart"
        Me.txtOGateStart.Size = New System.Drawing.Size(230, 20)
        Me.txtOGateStart.TabIndex = 6
        Me.txtOGateStart.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 147)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Drain Step Count"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 121)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Drain Stop (V)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Drain Start (V)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Gate Step Count"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Gate Stop (V)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Gate Start (V)"
        '
        'Worker
        '
        Me.Worker.WorkerReportsProgress = True
        Me.Worker.WorkerSupportsCancellation = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(411, 24)
        Me.MenuStrip1.TabIndex = 59
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 120)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(128, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Measurement Aperture (s)"
        '
        'txtAperture
        '
        Me.txtAperture.Location = New System.Drawing.Point(153, 117)
        Me.txtAperture.Name = "txtAperture"
        Me.txtAperture.Size = New System.Drawing.Size(203, 20)
        Me.txtAperture.TabIndex = 61
        Me.txtAperture.Text = "0.0001"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(108, 13)
        Me.Label25.TabIndex = 62
        Me.Label25.Text = "Gate Bias Voltage (V)"
        '
        'txtGateBiasVoltage
        '
        Me.txtGateBiasVoltage.Location = New System.Drawing.Point(153, 13)
        Me.txtGateBiasVoltage.Name = "txtGateBiasVoltage"
        Me.txtGateBiasVoltage.Size = New System.Drawing.Size(203, 20)
        Me.txtGateBiasVoltage.TabIndex = 63
        Me.txtGateBiasVoltage.Text = "0"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtDrainBiasVoltage)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Controls.Add(Me.txtGateBiasVoltage)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.txtCompliance)
        Me.TabPage3.Controls.Add(Me.txtAperture)
        Me.TabPage3.Controls.Add(Me.txtDelay)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(375, 177)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Common"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 42)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(110, 13)
        Me.Label26.TabIndex = 64
        Me.Label26.Text = "Drain Bias Voltage (V)"
        '
        'txtDrainBiasVoltage
        '
        Me.txtDrainBiasVoltage.Location = New System.Drawing.Point(153, 39)
        Me.txtDrainBiasVoltage.Name = "txtDrainBiasVoltage"
        Me.txtDrainBiasVoltage.Size = New System.Drawing.Size(203, 20)
        Me.txtDrainBiasVoltage.TabIndex = 65
        Me.txtDrainBiasVoltage.Text = "0"
        '
        'UI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 469)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.stsStatusBar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtOutputLocation)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.txtInterval)
        Me.Controls.Add(Me.txtSets)
        Me.Controls.Add(Me.txtLabel)
        Me.Controls.Add(Me.txtDevAddress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "UI"
        Me.Text = "MARS"
        Me.stsStatusBar.ResumeLayout(False)
        Me.stsStatusBar.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOutputLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents txtSets As System.Windows.Forms.TextBox
    Friend WithEvents txtDelay As System.Windows.Forms.TextBox
    Friend WithEvents txtCompliance As System.Windows.Forms.TextBox
    Friend WithEvents txtTDrainCount As System.Windows.Forms.TextBox
    Friend WithEvents txtTDrainStop As System.Windows.Forms.TextBox
    Friend WithEvents txtTDrainStart As System.Windows.Forms.TextBox
    Friend WithEvents txtTGateCount As System.Windows.Forms.TextBox
    Friend WithEvents txtTGateStop As System.Windows.Forms.TextBox
    Friend WithEvents txtTGateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtLabel As System.Windows.Forms.TextBox
    Friend WithEvents txtDevAddress As System.Windows.Forms.TextBox
    Friend WithEvents BrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents stsStatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtODrainCount As System.Windows.Forms.TextBox
    Friend WithEvents txtODrainStop As System.Windows.Forms.TextBox
    Friend WithEvents txtODrainStart As System.Windows.Forms.TextBox
    Friend WithEvents txtOGateCount As System.Windows.Forms.TextBox
    Friend WithEvents txtOGateStop As System.Windows.Forms.TextBox
    Friend WithEvents txtOGateStart As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtOGateStepSize As System.Windows.Forms.TextBox
    Friend WithEvents txtTDrainStepSize As System.Windows.Forms.TextBox
    Friend WithEvents txtTGateStepSize As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtODrainStepSize As System.Windows.Forms.TextBox
    Friend WithEvents Worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtAperture As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtGateBiasVoltage As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtDrainBiasVoltage As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
End Class
