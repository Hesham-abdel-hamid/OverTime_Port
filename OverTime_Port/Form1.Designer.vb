<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.exitButton = New System.Windows.Forms.Button()
        Me.wellcomeLabel = New System.Windows.Forms.Label()
        Me.applyGroupBox = New System.Windows.Forms.GroupBox()
        Me.ramLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.userApply = New System.Windows.Forms.ComboBox()
        Me.shiftLabel = New System.Windows.Forms.Label()
        Me.shiftCombo = New System.Windows.Forms.ComboBox()
        Me.oneistwoChk = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.toCombo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fromCombo = New System.Windows.Forms.ComboBox()
        Me.applyButton = New System.Windows.Forms.Button()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.overTimeLabel = New System.Windows.Forms.Label()
        Me.quiryGroupBox = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.reportButton = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.monthCombo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.viewButton = New System.Windows.Forms.Button()
        Me.userCombo = New System.Windows.Forms.ComboBox()
        Me.breakFastLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.transLabel = New System.Windows.Forms.Label()
        Me.lunchLabel = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lastApplyLable = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.applyGroupBox.SuspendLayout()
        Me.quiryGroupBox.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'exitButton
        '
        Me.exitButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitButton.Location = New System.Drawing.Point(12, 14)
        Me.exitButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(200, 45)
        Me.exitButton.TabIndex = 1
        Me.exitButton.Text = "Quit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'wellcomeLabel
        '
        Me.wellcomeLabel.AutoSize = True
        Me.wellcomeLabel.Font = New System.Drawing.Font("Tahoma", 16.2!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wellcomeLabel.ForeColor = System.Drawing.SystemColors.InfoText
        Me.wellcomeLabel.Location = New System.Drawing.Point(19, 14)
        Me.wellcomeLabel.Name = "wellcomeLabel"
        Me.wellcomeLabel.Size = New System.Drawing.Size(217, 34)
        Me.wellcomeLabel.TabIndex = 2
        Me.wellcomeLabel.Text = "Welcome User"
        '
        'applyGroupBox
        '
        Me.applyGroupBox.BackColor = System.Drawing.SystemColors.Control
        Me.applyGroupBox.Controls.Add(Me.ramLabel)
        Me.applyGroupBox.Controls.Add(Me.Label8)
        Me.applyGroupBox.Controls.Add(Me.userApply)
        Me.applyGroupBox.Controls.Add(Me.shiftLabel)
        Me.applyGroupBox.Controls.Add(Me.shiftCombo)
        Me.applyGroupBox.Controls.Add(Me.oneistwoChk)
        Me.applyGroupBox.Controls.Add(Me.Label4)
        Me.applyGroupBox.Controls.Add(Me.toCombo)
        Me.applyGroupBox.Controls.Add(Me.Label3)
        Me.applyGroupBox.Controls.Add(Me.fromCombo)
        Me.applyGroupBox.Controls.Add(Me.applyButton)
        Me.applyGroupBox.Controls.Add(Me.DateTimePicker)
        Me.applyGroupBox.Font = New System.Drawing.Font("Tahoma", 13.8!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.applyGroupBox.Location = New System.Drawing.Point(25, 97)
        Me.applyGroupBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.applyGroupBox.Name = "applyGroupBox"
        Me.applyGroupBox.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.applyGroupBox.Size = New System.Drawing.Size(1156, 159)
        Me.applyGroupBox.TabIndex = 3
        Me.applyGroupBox.TabStop = False
        Me.applyGroupBox.Text = "Apply Attendance:"
        '
        'ramLabel
        '
        Me.ramLabel.AutoSize = True
        Me.ramLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ramLabel.ForeColor = System.Drawing.Color.DarkRed
        Me.ramLabel.Location = New System.Drawing.Point(835, 49)
        Me.ramLabel.Name = "ramLabel"
        Me.ramLabel.Size = New System.Drawing.Size(106, 24)
        Me.ramLabel.TabIndex = 12
        Me.ramLabel.Text = "Ramadan"
        Me.ramLabel.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 21)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "User:"
        '
        'userApply
        '
        Me.userApply.Enabled = False
        Me.userApply.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userApply.FormattingEnabled = True
        Me.userApply.Location = New System.Drawing.Point(70, 45)
        Me.userApply.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.userApply.Name = "userApply"
        Me.userApply.Size = New System.Drawing.Size(265, 29)
        Me.userApply.TabIndex = 10
        '
        'shiftLabel
        '
        Me.shiftLabel.AutoSize = True
        Me.shiftLabel.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shiftLabel.Location = New System.Drawing.Point(249, 89)
        Me.shiftLabel.Name = "shiftLabel"
        Me.shiftLabel.Size = New System.Drawing.Size(57, 21)
        Me.shiftLabel.TabIndex = 9
        Me.shiftLabel.Text = "Shift:"
        '
        'shiftCombo
        '
        Me.shiftCombo.DisplayMember = "Select Time"
        Me.shiftCombo.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shiftCombo.FormattingEnabled = True
        Me.shiftCombo.Items.AddRange(New Object() {"Mornning", "Afternoon", "Night"})
        Me.shiftCombo.Location = New System.Drawing.Point(312, 84)
        Me.shiftCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.shiftCombo.Name = "shiftCombo"
        Me.shiftCombo.Size = New System.Drawing.Size(157, 31)
        Me.shiftCombo.TabIndex = 8
        '
        'oneistwoChk
        '
        Me.oneistwoChk.AutoSize = True
        Me.oneistwoChk.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oneistwoChk.Location = New System.Drawing.Point(13, 88)
        Me.oneistwoChk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.oneistwoChk.Name = "oneistwoChk"
        Me.oneistwoChk.Size = New System.Drawing.Size(163, 25)
        Me.oneistwoChk.TabIndex = 7
        Me.oneistwoChk.Text = "Official Holiday"
        Me.oneistwoChk.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(782, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 21)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "To:"
        '
        'toCombo
        '
        Me.toCombo.DisplayMember = "Select Time"
        Me.toCombo.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toCombo.FormattingEnabled = True
        Me.toCombo.Items.AddRange(New Object() {"12:00 AM", "01:00 AM", "02:00 AM", "03:00 AM", "04:00 AM", "05:00 AM", "06:00 AM", "07:00 AM", "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "01:00 PM", "02:00 PM", "03:00 PM", "04:00 PM", "05:00 PM", "06:00 PM", "07:00 PM", "08:00 PM", "09:00 PM", "10:00 PM", "11:00 PM"})
        Me.toCombo.Location = New System.Drawing.Point(829, 86)
        Me.toCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.toCombo.Name = "toCombo"
        Me.toCombo.Size = New System.Drawing.Size(157, 29)
        Me.toCombo.TabIndex = 5
        Me.toCombo.Text = "12:00 AM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(514, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "From:"
        '
        'fromCombo
        '
        Me.fromCombo.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fromCombo.FormattingEnabled = True
        Me.fromCombo.Items.AddRange(New Object() {"12:00 AM", "01:00 AM", "02:00 AM", "03:00 AM", "04:00 AM", "05:00 AM", "06:00 AM", "07:00 AM", "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "01:00 PM", "02:00 PM", "03:00 PM", "04:00 PM", "05:00 PM", "06:00 PM", "07:00 PM", "08:00 PM", "09:00 PM", "10:00 PM", "11:00 PM"})
        Me.fromCombo.Location = New System.Drawing.Point(580, 84)
        Me.fromCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fromCombo.Name = "fromCombo"
        Me.fromCombo.Size = New System.Drawing.Size(157, 29)
        Me.fromCombo.TabIndex = 3
        Me.fromCombo.Tag = "Select Time"
        Me.fromCombo.Text = "12:00 AM"
        '
        'applyButton
        '
        Me.applyButton.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.applyButton.Location = New System.Drawing.Point(1001, 51)
        Me.applyButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.applyButton.Name = "applyButton"
        Me.applyButton.Size = New System.Drawing.Size(135, 64)
        Me.applyButton.TabIndex = 2
        Me.applyButton.Text = "Apply"
        Me.applyButton.UseVisualStyleBackColor = True
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker.Location = New System.Drawing.Point(377, 46)
        Me.DateTimePicker.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker.MinimumSize = New System.Drawing.Size(4, 25)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(452, 28)
        Me.DateTimePicker.TabIndex = 0
        '
        'overTimeLabel
        '
        Me.overTimeLabel.AutoSize = True
        Me.overTimeLabel.Font = New System.Drawing.Font("Tahoma", 13.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.overTimeLabel.ForeColor = System.Drawing.Color.DarkRed
        Me.overTimeLabel.Location = New System.Drawing.Point(6, 59)
        Me.overTimeLabel.Name = "overTimeLabel"
        Me.overTimeLabel.Size = New System.Drawing.Size(229, 28)
        Me.overTimeLabel.TabIndex = 4
        Me.overTimeLabel.Text = "overtime : 0 Hours"
        '
        'quiryGroupBox
        '
        Me.quiryGroupBox.Controls.Add(Me.ComboBox1)
        Me.quiryGroupBox.Controls.Add(Me.Label11)
        Me.quiryGroupBox.Controls.Add(Me.Label2)
        Me.quiryGroupBox.Controls.Add(Me.deleteButton)
        Me.quiryGroupBox.Controls.Add(Me.Label7)
        Me.quiryGroupBox.Controls.Add(Me.Label9)
        Me.quiryGroupBox.Controls.Add(Me.reportButton)
        Me.quiryGroupBox.Controls.Add(Me.Label10)
        Me.quiryGroupBox.Controls.Add(Me.saveButton)
        Me.quiryGroupBox.Controls.Add(Me.DataGridView1)
        Me.quiryGroupBox.Controls.Add(Me.Label6)
        Me.quiryGroupBox.Controls.Add(Me.monthCombo)
        Me.quiryGroupBox.Controls.Add(Me.Label5)
        Me.quiryGroupBox.Controls.Add(Me.viewButton)
        Me.quiryGroupBox.Controls.Add(Me.userCombo)
        Me.quiryGroupBox.Font = New System.Drawing.Font("Tahoma", 13.8!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quiryGroupBox.Location = New System.Drawing.Point(25, 260)
        Me.quiryGroupBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.quiryGroupBox.Name = "quiryGroupBox"
        Me.quiryGroupBox.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.quiryGroupBox.Size = New System.Drawing.Size(1591, 599)
        Me.quiryGroupBox.TabIndex = 5
        Me.quiryGroupBox.TabStop = False
        Me.quiryGroupBox.Text = "User Activities:"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.ComboBox1.Location = New System.Drawing.Point(1509, 52)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(76, 29)
        Me.ComboBox1.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(20, 562)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(156, 21)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Last Apply: None"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(418, 562)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Transportation : 0 EGP"
        '
        'deleteButton
        '
        Me.deleteButton.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteButton.Location = New System.Drawing.Point(800, 41)
        Me.deleteButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(200, 50)
        Me.deleteButton.TabIndex = 8
        Me.deleteButton.Text = "Delete Record"
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkRed
        Me.Label7.Location = New System.Drawing.Point(778, 562)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 21)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Lunch : 0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(1148, 562)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 21)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "overtime : 0 Hours"
        '
        'reportButton
        '
        Me.reportButton.Enabled = False
        Me.reportButton.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reportButton.Location = New System.Drawing.Point(1212, 41)
        Me.reportButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.reportButton.Name = "reportButton"
        Me.reportButton.Size = New System.Drawing.Size(291, 50)
        Me.reportButton.TabIndex = 7
        Me.reportButton.Text = "Generate Report for month :"
        Me.reportButton.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(954, 562)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 21)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Breakfast : 0"
        '
        'saveButton
        '
        Me.saveButton.Enabled = False
        Me.saveButton.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveButton.Location = New System.Drawing.Point(1006, 40)
        Me.saveButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(200, 50)
        Me.saveButton.TabIndex = 6
        Me.saveButton.Text = "Save cahnges"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 13.8!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 13.8!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.Location = New System.Drawing.Point(13, 116)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 13.8!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1572, 429)
        Me.DataGridView1.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 21)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Month:"
        '
        'monthCombo
        '
        Me.monthCombo.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.monthCombo.FormattingEnabled = True
        Me.monthCombo.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.monthCombo.Location = New System.Drawing.Point(99, 79)
        Me.monthCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.monthCombo.Name = "monthCombo"
        Me.monthCombo.Size = New System.Drawing.Size(64, 29)
        Me.monthCombo.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 21)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "User:"
        '
        'viewButton
        '
        Me.viewButton.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewButton.Location = New System.Drawing.Point(594, 41)
        Me.viewButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.viewButton.Name = "viewButton"
        Me.viewButton.Size = New System.Drawing.Size(200, 50)
        Me.viewButton.TabIndex = 1
        Me.viewButton.Text = "View"
        Me.viewButton.UseVisualStyleBackColor = True
        '
        'userCombo
        '
        Me.userCombo.Enabled = False
        Me.userCombo.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userCombo.FormattingEnabled = True
        Me.userCombo.Location = New System.Drawing.Point(73, 41)
        Me.userCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.userCombo.Name = "userCombo"
        Me.userCombo.Size = New System.Drawing.Size(247, 29)
        Me.userCombo.TabIndex = 0
        '
        'breakFastLabel
        '
        Me.breakFastLabel.AutoSize = True
        Me.breakFastLabel.Font = New System.Drawing.Font("Tahoma", 13.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.breakFastLabel.ForeColor = System.Drawing.Color.DarkRed
        Me.breakFastLabel.Location = New System.Drawing.Point(6, 89)
        Me.breakFastLabel.Name = "breakFastLabel"
        Me.breakFastLabel.Size = New System.Drawing.Size(162, 28)
        Me.breakFastLabel.TabIndex = 6
        Me.breakFastLabel.Text = "Breakfast : 0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(12, 898)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(474, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Developed By Hesham Abdelhamid - IT Operation CMM"
        '
        'transLabel
        '
        Me.transLabel.AutoSize = True
        Me.transLabel.Font = New System.Drawing.Font("Tahoma", 13.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transLabel.ForeColor = System.Drawing.Color.DarkRed
        Me.transLabel.Location = New System.Drawing.Point(6, 31)
        Me.transLabel.Name = "transLabel"
        Me.transLabel.Size = New System.Drawing.Size(275, 28)
        Me.transLabel.TabIndex = 8
        Me.transLabel.Text = "Transportation : 0 EGP"
        '
        'lunchLabel
        '
        Me.lunchLabel.AutoSize = True
        Me.lunchLabel.Font = New System.Drawing.Font("Tahoma", 13.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lunchLabel.ForeColor = System.Drawing.Color.DarkRed
        Me.lunchLabel.Location = New System.Drawing.Point(6, 117)
        Me.lunchLabel.Name = "lunchLabel"
        Me.lunchLabel.Size = New System.Drawing.Size(119, 28)
        Me.lunchLabel.TabIndex = 9
        Me.lunchLabel.Text = "Lunch : 0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.transLabel)
        Me.GroupBox1.Controls.Add(Me.lunchLabel)
        Me.GroupBox1.Controls.Add(Me.overTimeLabel)
        Me.GroupBox1.Controls.Add(Me.breakFastLabel)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 13.8!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1231, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 158)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status:"
        '
        'lastApplyLable
        '
        Me.lastApplyLable.AutoSize = True
        Me.lastApplyLable.Font = New System.Drawing.Font("Tahoma", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastApplyLable.ForeColor = System.Drawing.Color.Maroon
        Me.lastApplyLable.Location = New System.Drawing.Point(21, 59)
        Me.lastApplyLable.Name = "lastApplyLable"
        Me.lastApplyLable.Size = New System.Drawing.Size(180, 24)
        Me.lastApplyLable.TabIndex = 11
        Me.lastApplyLable.Text = "Last Apply: None"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.exitButton)
        Me.GroupBox2.Location = New System.Drawing.Point(1398, 864)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 64)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1628, 929)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lastApplyLable)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.quiryGroupBox)
        Me.Controls.Add(Me.applyGroupBox)
        Me.Controls.Add(Me.wellcomeLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OverTime Portal"
        Me.applyGroupBox.ResumeLayout(False)
        Me.applyGroupBox.PerformLayout()
        Me.quiryGroupBox.ResumeLayout(False)
        Me.quiryGroupBox.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents exitButton As Button
    Friend WithEvents wellcomeLabel As Label
    Friend WithEvents applyGroupBox As GroupBox
    Friend WithEvents DateTimePicker As DateTimePicker
    Friend WithEvents overTimeLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents fromCombo As ComboBox
    Friend WithEvents applyButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents toCombo As ComboBox
    Friend WithEvents oneistwoChk As CheckBox
    Friend WithEvents quiryGroupBox As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents viewButton As Button
    Friend WithEvents userCombo As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents monthCombo As ComboBox
    Friend WithEvents saveButton As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents reportButton As Button
    Friend WithEvents breakFastLabel As Label
    Friend WithEvents shiftLabel As Label
    Friend WithEvents shiftCombo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents userApply As ComboBox
    Friend WithEvents transLabel As Label
    Friend WithEvents lunchLabel As Label
    Friend WithEvents ramLabel As Label
    Friend WithEvents deleteButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lastApplyLable As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
End Class
