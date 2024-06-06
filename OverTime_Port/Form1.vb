'Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports System.IO
Imports System.Data.SQLite
'Imports System.Data.Entity.ModelConfiguration.Conventions
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Globalization
'Imports System.Data.SqlClient
'Imports System.Data.OleDb
Imports Microsoft.Office.Interop '.Excel
Imports Microsoft.Office.Interop.Excel
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
'Imports Newtonsoft.Json.Linq

Public Class Form1
    Dim json As String = File.ReadAllText("u.json")     ' Read the contents of the JSON file
    Dim userList As List(Of User) = JsonConvert.DeserializeObject(Of List(Of User))(json)       ' Deserialize the JSON into a list of objects
    Dim userNameW As String = Environment.UserName       ' Get the username of the currently logged-in Windows user
    Dim fileContents As String = File.ReadAllText("offset.txt")
    Dim offset As Integer = Integer.Parse(fileContents)
    Dim hijriCalendar As New HijriCalendar()            'define hijri date
    Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load    ' Code to be executed when Form1 is loaded
        Dim currentUser As User = userList.Find(Function(u) u.userName = userNameW)      ' Find the user object with a matching username
        If currentUser IsNot Nothing Then       ' Display the alias in a text box if a matching user is found
            wellcomeLabel.Text = "Hi " & currentUser.aliasName
            userCombo.Text = currentUser.aliasName
            userApply.Text = currentUser.aliasName
            monthCombo.Text = Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2)
            ComboBox1.Text = Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2)
        Else
            MsgBox("your user Is Not authorized To access the application.")
            Close()
        End If
        If currentUser.rank = "man" Then
            userCombo.Enabled = True
            userApply.Enabled = True
            saveButton.Enabled = True
            reportButton.Enabled = True
            For Each user As User In userList
                userCombo.Items.Add(user.aliasName)
                userApply.Items.Add(user.aliasName)
            Next
        End If
        DateTimePicker_ValueChanged(sender, e)
        CalculateOverSum("T" & currentUser.userName, overTimeLabel, monthCombo.Text)
        CalculateTransSum("T" & currentUser.userName, transLabel, monthCombo.Text)
        CalculateBreakFastSum("T" & currentUser.userName, breakFastLabel, monthCombo.Text)
        CalculateLunchSum("T" & currentUser.userName, lunchLabel, monthCombo.Text)
        FindLastApply("T" & userNameW, lastApplyLable)
        lastApplyLable.Text = "Your " & lastApplyLable.Text
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Close()         'quit Button
    End Sub
    Private Sub applyButton_Click(sender As Object, e As EventArgs) Handles applyButton.Click
        If shiftCombo.SelectedItem = "" Then
            MsgBox("Missing parameters!")
        Else
            '''''''''''''''''''''''''''''''''''''''''''''''init''''''''''''''''''''''''''''''''''''''''''''
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("trans.txt")
            Dim lineReader As String
            lineReader = fileReader.ReadLine()
            Dim morni As Integer = Integer.Parse(lineReader)
            lineReader = fileReader.ReadLine()
            Dim afterNoon As Integer = Integer.Parse(lineReader)
            lineReader = fileReader.ReadLine()
            Dim nighty As Integer = Integer.Parse(lineReader)
            lineReader = fileReader.ReadLine()
            Dim holiDay As Integer = Integer.Parse(lineReader)
            Dim Transport = 0   'initialize variable
            Dim BreakFastT = 0  'initialize variable
            Dim LunchT = 0  'initialize variable
            Dim OverTime = 0    'initialize variable
            Dim currentUser As User = userList.Find(Function(u) u.aliasName = userApply.Text)      'initialize variable
            Dim connectionString As String = "Data Source=OPDB.db;Version=3;"       'open connection to database
            Dim duration As Integer     'get duration
            If CDate(toCombo.SelectedItem) >= CDate(fromCombo.SelectedItem) Then
                duration = (CDate(toCombo.SelectedItem) - CDate(fromCombo.SelectedItem)).Hours
            Else
                duration = (CDate(toCombo.SelectedItem) - CDate(fromCombo.SelectedItem)).Hours + 24
            End If
            Dim selectedDate As DateTime = DateTimePicker.Value       'define date
            Dim dayOfWeek As String = selectedDate.DayOfWeek.ToString()         'define day name
            Dim lastSat As Date = CDate(DateTimePicker.Value).AddDays(-6)       'define last saturday date
            Dim hijriMonth As Integer = hijriCalendar.GetMonth(CDate(DateTimePicker.Value.AddDays(offset)))  'ramadan is 9
            Dim hijriDay As Integer = hijriCalendar.GetDayOfMonth(CDate(DateTimePicker.Value.AddDays(offset)))
            Dim lastSatHijMon As Integer = hijriCalendar.GetMonth(CDate(lastSat.AddDays(offset)))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case shiftCombo.SelectedItem
                Case "Mornning"
                    If dayOfWeek = "Friday" Or dayOfWeek = "Saturday" Or oneistwoChk.Checked = True Then
                        Transport = holiDay
                    Else                                    'transpotation
                        Transport = morni
                    End If '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If duration > 9 And hijriMonth <> 9 Then
                        LunchT = 1                          'lunch allawences
                    End If ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If hijriMonth = 9 Then
                        If oneistwoChk.Checked = True Then
                            OverTime = duration * 2
                        End If
                    Else                                    'overtime
                        If oneistwoChk.Checked = True Then
                            OverTime = duration * 2
                        Else
                            If dayOfWeek = "Friday" Or dayOfWeek = "Saturday" Then
                                OverTime = duration
                            End If
                        End If
                    End If'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case "Afternoon"
                    If dayOfWeek = "Friday" Or dayOfWeek = "Saturday" Or oneistwoChk.Checked = True Then
                        Transport = holiDay
                    Else                                     'transpotation
                        Transport = afterNoon
                    End If ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oneistwoChk.Checked = True Then
                        OverTime = duration * 2
                    Else                                            'Overtime
                        If (dayOfWeek = "Friday" Or dayOfWeek = "Saturday") And hijriMonth <> 9 Then
                            OverTime = duration
                        End If
                    End If
                Case "Night"
                    If dayOfWeek = "Friday" Or dayOfWeek = "Saturday" Or oneistwoChk.Checked = True Then
                        Transport = holiDay
                    Else                                         'transpotation
                        Transport = nighty
                    End If '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim pastday As Date = CDate(DateTimePicker.Value)
                    Dim pastMonHij As Integer = hijriCalendar.GetMonth(pastday.AddDays(offset + 1))
                    If pastMonHij <> 9 Then
                        BreakFastT = 1   'breakfast allawences
                    End If ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If hijriMonth = 9 Then
                        If oneistwoChk.Checked = True Then
                            OverTime = duration * 2
                        Else
                            If dayOfWeek = "Friday" Then
                                OverTime = 0
                                Dim lastsatquery As String = "SELECT COUNT(*) FROM T" & currentUser.userName & " WHERE Date = @daysat AND Shift = @Night"
                                Using connection As New SQLiteConnection(connectionString)
                                    Using command As New SQLiteCommand(lastsatquery, connection)
                                        command.Parameters.AddWithValue("@daysat", Format(lastSat, "dd/MM/yyyy"))
                                        command.Parameters.AddWithValue("@Night", "Night")
                                        connection.Open()
                                        Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                                        If count <> 0 And lastSatHijMon <> 9 Then
                                            OverTime = 0   'update friday
                                            Dim sql As String = "UPDATE T" & currentUser.userName & " SET OverTimeHours = Duration WHERE date = @date"
                                            command.Parameters.AddWithValue("@date", Format(lastSat, "dd/MM/yyyy"))
                                            command.CommandText = sql
                                            command.ExecuteNonQuery()
                                        End If
                                    End Using
                                End Using
                            End If
                        End If
                    Else
                        If oneistwoChk.Checked = True Then
                            OverTime = duration * 2
                        Else
                            If dayOfWeek = "Friday" Then
                                OverTime = 0
                                Dim lastsatquery As String = "SELECT COUNT(*) FROM T" & currentUser.userName & " WHERE Date = @daysat AND Shift = @Shift"
                                Using connection As New SQLiteConnection(connectionString)
                                    Using command As New SQLiteCommand(lastsatquery, connection)
                                        command.Parameters.AddWithValue("@daysat", Format(lastSat, "dd/MM/yyyy"))
                                        command.Parameters.AddWithValue("@Shift", "Night")
                                        connection.Open()
                                        Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                                        If count = 0 Then
                                            OverTime = duration
                                        ElseIf count = 1 And lastSatHijMon = 9 Then
                                            OverTime = 0
                                        ElseIf count = 1 And lastSatHijMon <> 9 Then
                                            OverTime = 0
                                            Dim sql As String = "UPDATE T" & currentUser.userName & " SET OverTimeHours = Duration WHERE date = @date"
                                            command.Parameters.AddWithValue("@date", Format(lastSat, "dd/MM/yyyy"))
                                            command.CommandText = sql
                                            command.ExecuteNonQuery()
                                        End If
                                    End Using
                                End Using
                            End If
                        End If
                    End If '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select
            If vpnCheckBox.Checked = True Then
                Transport = 0
                BreakFastT = 0
                LunchT = 0
                OverTime = 0
            End If
            Try
                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()
                    Dim sql As String = "INSERT INTO T" & currentUser.userName & " (Id, Name, Date, WeekDay, Shift, FromTime, ToTime, Duration, Holiday, Transportation, BreakFast, Lunch, OverTimeHours, Julian) VALUES (@Id, @Name, @Date, @WeekDay, @Shift, @FromTime, @ToTime, @Duration, @Holiday, @Transportation, @BreakFast, @Lunch, @OverTimeHours, @Julian)"
                    Using command As New SQLiteCommand(sql, connection)
                        command.Parameters.AddWithValue("@Id", currentUser.userName)
                        command.Parameters.AddWithValue("@Name", currentUser.aliasName)
                        command.Parameters.AddWithValue("@Date", DateTimePicker.Value.ToString("dd/MM/yyyy"))
                        command.Parameters.AddWithValue("@WeekDay", dayOfWeek)
                        command.Parameters.AddWithValue("@Shift", shiftCombo.SelectedItem)
                        command.Parameters.AddWithValue("@FromTime", fromCombo.SelectedItem.ToString())
                        command.Parameters.AddWithValue("@ToTime", toCombo.SelectedItem.ToString())
                        command.Parameters.AddWithValue("@Duration", duration)
                        command.Parameters.AddWithValue("@Holiday", If(vpnCheckBox.Checked, "VPN", If(oneistwoChk.Checked, "Official Holiday", If(dayOfWeek = "Friday" Or dayOfWeek = "Saturday", "WeekEnd", "WorkDay"))))
                        command.Parameters.AddWithValue("@Transportation", Transport)
                        command.Parameters.AddWithValue("@BreakFast", BreakFastT)
                        command.Parameters.AddWithValue("@Lunch", LunchT)
                        command.Parameters.AddWithValue("@OverTimeHours", OverTime)
                        command.Parameters.AddWithValue("@Julian", CLng(DateTimePicker.Value.ToString("yyyyMMdd")))
                        command.ExecuteNonQuery()
                    End Using
                    connection.Close()
                End Using
                MsgBox("Data Applied Successfully")
                oneistwoChk.Checked = False
                vpnCheckBox.Checked = False
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            CalculateOverSum("T" & currentUser.userName, overTimeLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
            CalculateTransSum("T" & currentUser.userName, transLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
            CalculateBreakFastSum("T" & currentUser.userName, breakFastLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
            CalculateLunchSum("T" & currentUser.userName, lunchLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
            FindLastApply("T" & userNameW, lastApplyLable)
            lastApplyLable.Text = "Your " & lastApplyLable.Text
        End If
    End Sub

    Private Sub viewButton_Click(sender As Object, e As EventArgs) Handles viewButton.Click
        Dim currentUser As User = userList.Find(Function(u) u.aliasName = userCombo.Text)
        Dim connectionString As String = "Data Source=OPDB.db;Version=3;" ' Replace with your actual connection string
        Dim query As String = "SELECT Name, Date, WeekDay As Day, Holiday As Type, Shift, Duration, Transportation, BreakFast, Lunch, OverTimeHours As OverTime, Review As Checker FROM T" & currentUser.userName & " WHERE date LIKE '%/" & monthCombo.Text & "/%' ORDER BY Julian ASC" ' SQL query to select rows where the date is in the desired month
        Using connection As New SQLiteConnection(connectionString) ' Create a new SQLiteConnection using the connection string
            Dim adapter As New SQLiteDataAdapter(query, connection) ' Create a new SQLiteDataAdapter with the query and connection
            Dim dataSet As New DataSet() ' Create a new DataSet to hold the results
            adapter.Fill(dataSet) ' Fill the DataSet with the data from the query
            DataGridView1.DataSource = dataSet.Tables(0) ' Bind the first table in the DataSet to the DataGridView
        End Using
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font(New FontFamily("Tahoma"), 12, FontStyle.Bold)    ' Set the font for the column headers
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.DefaultCellStyle.Font = New System.Drawing.Font(New FontFamily("Tahoma"), 10, FontStyle.Regular)    ' Set the font for the body of the DataGridView
        Next
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        CalculateOverSum("T" & currentUser.userName, Label9, monthCombo.Text)
        CalculateTransSum("T" & currentUser.userName, Label2, monthCombo.Text)
        CalculateBreakFastSum("T" & currentUser.userName, Label10, monthCombo.Text)
        CalculateLunchSum("T" & currentUser.userName, Label7, monthCombo.Text)
        FindLastApply("T" & currentUser.userName, Label11)
    End Sub
    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        Dim currentUser As User = userList.Find(Function(u) u.aliasName = userCombo.Text)
        Dim connectionString As String = "Data Source=OPDB.db;Version=3;"
        Dim query As String = "UPDATE T" & currentUser.userName & " SET Transportation = @Column1Value, BreakFast = @Column2Value, Lunch = @Column3Value, OverTimeHours = @Column4Value, Review = @Column5Value WHERE Date = @DateValue"
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow AndAlso row.Cells("Date").Value IsNot DBNull.Value Then
                    Dim command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@Column1Value", row.Cells("Transportation").Value)
                    command.Parameters.AddWithValue("@Column2Value", row.Cells("BreakFast").Value)
                    command.Parameters.AddWithValue("@Column3Value", row.Cells("Lunch").Value)
                    command.Parameters.AddWithValue("@Column4Value", row.Cells("OverTime").Value)
                    command.Parameters.AddWithValue("@Column5Value", row.Cells("Review").Value)
                    command.Parameters.AddWithValue("@DateValue", row.Cells("Date").Value)
                    command.ExecuteNonQuery()
                End If
            Next
        End Using
        MsgBox("Data Updated.")
        CalculateOverSum("T" & currentUser.userName, Label9, monthCombo.Text)
        CalculateTransSum("T" & currentUser.userName, Label2, monthCombo.Text)
        CalculateBreakFastSum("T" & currentUser.userName, Label10, monthCombo.Text)
        CalculateLunchSum("T" & currentUser.userName, Label7, monthCombo.Text)
        currentUser = userList.Find(Function(u) u.aliasName = userApply.Text)
        CalculateOverSum("T" & currentUser.userName, overTimeLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateTransSum("T" & currentUser.userName, transLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateBreakFastSum("T" & currentUser.userName, breakFastLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateLunchSum("T" & currentUser.userName, lunchLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
    End Sub
    Private Sub reportButton_Click(sender As Object, e As EventArgs) Handles reportButton.Click
        Form2.Show()
        Form2.ProgressBar1.Value = 1
        Dim iftarfileContents As String = File.ReadAllText("Iftar.txt")
        Dim Iftar As DateTime = DateTime.ParseExact(iftarfileContents, "hh:mm tt", Nothing)
        Dim hijriMonth As Integer = hijriCalendar.GetMonth(CDate(DateTimePicker.Value.AddDays(offset)))  'ramadan is 9
        Dim hijriDay As Integer = hijriCalendar.GetDayOfMonth(CDate(DateTimePicker.Value.AddDays(offset)))
        Dim selectedMonth As String = ComboBox1.SelectedItem.ToString()
        Dim daysInMonth As Integer = DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(selectedMonth))
        Dim excelApp As New Excel.Application()    ' Create a new Excel application object
        Dim templateFilePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Temp.xlsx")    ' Get the path to the template file
        excelApp.DisplayAlerts = False
        Dim workbook As Excel.Workbook = excelApp.Workbooks.Open(templateFilePath)    ' Open the template workbook
        Dim totalWorksheet As Excel.Worksheet = workbook.Sheets("البدلات")
        Dim transWorksheet As Excel.Worksheet = workbook.Sheets("بدل الانتقال")    ' Get the first worksheet
        Dim tableWorksheet As Excel.Worksheet = workbook.Sheets("جدول الشهر")
        Dim users As List(Of User) = JsonConvert.DeserializeObject(Of List(Of User))(json)
        Dim row As Integer = 3
        Form2.ProgressBar1.Value = Form2.ProgressBar1.Value + 1
        For Each user In users                ' total worksheet and transportation worksheet
            Form2.ProgressBar1.Value = Form2.ProgressBar1.Value + 5
            If user.inTable = "True" Then
                totalWorksheet.Range("A" & row).Value = user.arabName
                totalWorksheet.Range("B" & row).Value = user.userName
                transWorksheet.Range("A" & row).Value = user.arabName
                transWorksheet.Range("B" & row).Value = user.userName
                Dim connectionString As String = "Data Source=OPDB.db;Version=3;"
                Dim query As String = "SELECT SUM(Transportation) FROM T" & user.userName & " WHERE Date LIKE '%/" & selectedMonth & "/%'"
                Using connection As New SQLiteConnection(connectionString)
                    Dim command As New SQLiteCommand(query, connection)
                    connection.Open()
                    Dim sum As Object = command.ExecuteScalar()
                    If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                        totalWorksheet.Range("C" & row).Value = sum.ToString()
                    Else
                        totalWorksheet.Range("C" & row).Value = "0"
                    End If
                End Using
                query = "SELECT SUM(OverTimeHours) FROM T" & user.userName & " WHERE Date LIKE '%/" & selectedMonth & "/%'"
                Using connection As New SQLiteConnection(connectionString)
                    Dim command As New SQLiteCommand(query, connection)
                    connection.Open()
                    Dim sum As Object = command.ExecuteScalar()
                    If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                        totalWorksheet.Range("D" & row).Value = sum.ToString()
                    Else
                        totalWorksheet.Range("D" & row).Value = "0"
                    End If
                End Using
                query = "SELECT SUM(BreakFast) FROM T" & user.userName & " WHERE Date LIKE '%/" & selectedMonth & "/%'"
                Using connection As New SQLiteConnection(connectionString)
                    Dim command As New SQLiteCommand(query, connection)
                    connection.Open()
                    Dim sum As Object = command.ExecuteScalar()
                    If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                        totalWorksheet.Range("E" & row).Value = sum.ToString()
                        transWorksheet.Range("H" & row).Value = sum.ToString()
                    Else
                        totalWorksheet.Range("E" & row).Value = "0"
                        transWorksheet.Range("H" & row).Value = "0"
                    End If
                End Using
                query = "SELECT SUM(Lunch) FROM T" & user.userName & " WHERE Date LIKE '%/" & selectedMonth & "/%'"
                Using connection As New SQLiteConnection(connectionString)
                    Dim command As New SQLiteCommand(query, connection)
                    connection.Open()
                    Dim sum As Object = command.ExecuteScalar()
                    If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                        totalWorksheet.Range("F" & row).Value = sum.ToString()
                        transWorksheet.Range("I" & row).Value = sum.ToString()
                    Else
                        totalWorksheet.Range("F" & row).Value = "0"
                        transWorksheet.Range("I" & row).Value = "0"
                    End If
                End Using
                query = "SELECT COUNT(Transportation) FROM T" & user.userName & " WHERE Date LIKE '%/" & selectedMonth & "/%' AND Shift = 'Mornning' AND Holiday = 'WorkDay'"
                Using connection As New SQLiteConnection(connectionString)
                    Dim command As New SQLiteCommand(query, connection)
                    connection.Open()
                    Dim sum As Object = command.ExecuteScalar()
                    If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                        transWorksheet.Range("C" & row).Value = sum.ToString()
                    Else
                        transWorksheet.Range("C" & row).Value = "0"
                    End If
                End Using
                query = "SELECT COUNT(Transportation) FROM T" & user.userName & " WHERE Date LIKE '%/" & selectedMonth & "/%' AND Shift = 'Afternoon' AND Holiday = 'WorkDay'"
                Using connection As New SQLiteConnection(connectionString)
                    Dim command As New SQLiteCommand(query, connection)
                    connection.Open()
                    Dim sum As Object = command.ExecuteScalar()
                    If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                        transWorksheet.Range("D" & row).Value = sum.ToString()
                    Else
                        transWorksheet.Range("D" & row).Value = "0"
                    End If
                End Using
                query = "SELECT COUNT(Transportation) FROM T" & user.userName & " WHERE Date LIKE '%/" & selectedMonth & "/%' AND Shift = 'Night' AND Holiday = 'WorkDay'"
                Using connection As New SQLiteConnection(connectionString)
                    Dim command As New SQLiteCommand(query, connection)
                    connection.Open()
                    Dim sum As Object = command.ExecuteScalar()
                    If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                        transWorksheet.Range("E" & row).Value = sum.ToString()
                    Else
                        transWorksheet.Range("E" & row).Value = "0"
                    End If
                End Using
                query = "SELECT COUNT(Transportation) FROM T" & user.userName & " WHERE Date LIKE '%/" & selectedMonth & "/%' AND Holiday IN ('Official Holiday', 'WeekEnd')"
                Using connection As New SQLiteConnection(connectionString)
                    Dim command As New SQLiteCommand(query, connection)
                    connection.Open()
                    Dim sum As Object = command.ExecuteScalar()
                    If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                        transWorksheet.Range("F" & row).Value = sum.ToString()
                    Else
                        transWorksheet.Range("F" & row).Value = "0"
                    End If
                End Using
                For day As Integer = 1 To daysInMonth    '''''''''''''''''''''''''''''The Table''''''''''''''''''''
                    Dim currentDate As Date = New Date(DateTime.Now.Year, Convert.ToInt32(selectedMonth), day)
                    hijriMonth = hijriCalendar.GetMonth(currentDate.AddDays(offset))  'ramadan is 9
                    hijriDay = hijriCalendar.GetDayOfMonth(currentDate.AddDays(offset))
                    tableWorksheet.Range("A" & (day + 2)).Value = currentDate.ToString("dd/MM/yyyy") & vbNewLine & currentDate.DayOfWeek.ToString()
                    query = "SELECT WeekDay, Shift, FromTime, ToTime, Holiday FROM T" & user.userName & " WHERE Date = @Date"
                    Using connection As New SQLiteConnection(connectionString)
                        Dim command As New SQLiteCommand(query, connection)
                        command.Parameters.AddWithValue("@Date", currentDate.ToString("dd/MM/yyyy"))
                        connection.Open()
                        Using reader As SQLiteDataReader = command.ExecuteReader()
                            If reader.HasRows Then
                                While reader.Read()
                                    Dim Weekday As String = reader.GetString(0)
                                    Dim Shift As String = reader.GetString(1)
                                    Dim FromTime As DateTime = DateTime.ParseExact(reader.GetString(2), "hh:mm tt", Nothing)
                                    Dim ToTime As DateTime = DateTime.ParseExact(reader.GetString(3), "hh:mm tt", Nothing)
                                    Dim Type As String = reader.GetString(4)
                                    If Shift = "Mornning" Then
                                        If Type = "VPN" Then
                                            tableWorksheet.Range("B" & (day + 2)).Value = Replace((tableWorksheet.Range("B" & (day + 2)).Value & "-" & user.arabNick & Type).TrimStart("-"c), "-", vbNewLine)
                                        Else
                                            tableWorksheet.Range("B" & (day + 2)).Value = Replace((tableWorksheet.Range("B" & (day + 2)).Value & "-" & user.arabNick).TrimStart("-"c), "-", vbNewLine)
                                        End If
                                        If Type = "Official Holiday" Then
                                            tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A101").Value
                                            If hijriMonth = 9 Then
                                                tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A101").Value & "-" & hijriDay & tableWorksheet.Range("A100").Value
                                            End If
                                        ElseIf Type = "WeekEnd" Then
                                            tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A102").Value
                                            If hijriMonth = 9 Then
                                                tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A102").Value & "-" & hijriDay & tableWorksheet.Range("A100").Value
                                            End If
                                        ElseIf Type = "WorkDay" Then
                                            tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A103").Value
                                            If hijriMonth = 9 Then
                                                tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A103").Value & "-" & hijriDay & tableWorksheet.Range("A100").Value
                                            End If
                                        End If
                                    ElseIf Shift = "Afternoon" Then
                                        If hijriMonth = 9 Then    'ramadan
                                            tableWorksheet.Columns("D").Hidden = False
                                            If Iftar > FromTime And Iftar < ToTime Then    ' Iftar shift
                                                If Type = "VPN" Then
                                                    tableWorksheet.Range("D" & (day + 2)).Value = Replace((tableWorksheet.Range("D" & (day + 2)).Value & "-" & user.arabNick & Type).TrimStart("-"c), "-", vbNewLine)
                                                Else
                                                    tableWorksheet.Range("D" & (day + 2)).Value = Replace((tableWorksheet.Range("D" & (day + 2)).Value & "-" & user.arabNick).TrimStart("-"c), "-", vbNewLine)
                                                End If
                                            Else
                                                If Type = "VPN" Then
                                                    tableWorksheet.Range("C" & (day + 2)).Value = Replace((tableWorksheet.Range("C" & (day + 2)).Value & "-" & user.arabNick & Type).TrimStart("-"c), "-", vbNewLine)
                                                Else
                                                    tableWorksheet.Range("C" & (day + 2)).Value = Replace((tableWorksheet.Range("C" & (day + 2)).Value & "-" & user.arabNick).TrimStart("-"c), "-", vbNewLine)
                                                End If
                                            End If
                                        Else    'not ramadan
                                            If Type = "VPN" Then
                                                tableWorksheet.Range("C" & (day + 2)).Value = Replace((tableWorksheet.Range("C" & (day + 2)).Value & "-" & user.arabNick & Type).TrimStart("-"c), "-", vbNewLine)
                                            Else
                                                tableWorksheet.Range("C" & (day + 2)).Value = Replace((tableWorksheet.Range("C" & (day + 2)).Value & "-" & user.arabNick).TrimStart("-"c), "-", vbNewLine)
                                            End If
                                        End If
                                    ElseIf Shift = "Night" Then
                                        If Type = "VPN" Then
                                            tableWorksheet.Range("E" & (day + 2)).Value = Replace((tableWorksheet.Range("E" & (day + 2)).Value & "-" & user.arabNick & Type).TrimStart("-"c), "-", vbNewLine)
                                        Else
                                            tableWorksheet.Range("E" & (day + 2)).Value = Replace((tableWorksheet.Range("E" & (day + 2)).Value & "-" & user.arabNick).TrimStart("-"c), "-", vbNewLine)
                                        End If
                                        If Type = "Official Holiday" Then
                                            tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A101").Value
                                            If hijriMonth = 9 Then
                                                tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A101").Value & "-" & hijriDay & tableWorksheet.Range("A100").Value
                                            End If
                                        ElseIf Type = "WeekEnd" Then
                                            tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A102").Value
                                            If hijriMonth = 9 Then
                                                tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A102").Value & "-" & hijriDay & tableWorksheet.Range("A100").Value
                                            End If
                                        ElseIf Type = "WorkDay" Then
                                            tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A103").Value
                                            If hijriMonth = 9 Then
                                                tableWorksheet.Range("F" & (day + 2)).Value = tableWorksheet.Range("A103").Value & "-" & hijriDay & tableWorksheet.Range("A100").Value
                                            End If
                                        End If
                                    End If
                                End While
                            Else
                            End If
                        End Using
                    End Using
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                row = row + 1
            End If
        Next
        Form2.ProgressBar1.Value = 90
        transWorksheet.Range("G" & row & ":G20").Value = ""
        tableWorksheet.Range("A100:A103").Value = ""
        Dim range As Microsoft.Office.Interop.Excel.Range = tableWorksheet.Range("A3:F35")
        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        Form2.ProgressBar1.Value = 95
        Dim SaveFileDialog As New SaveFileDialog()    ' Save the workbook
        SaveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
        SaveFileDialog.FileName = "overTime_Report" & ComboBox1.Text & ".xlsx"
        SaveFileDialog.InitialDirectory = "\\nbe.ahly.bank\plz\New Departments\HQ\Business Technology\IT_Operation"
        Form2.ProgressBar1.Value = 100
        Form2.Close()
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            workbook.SaveAs(SaveFileDialog.FileName)
            MessageBox.Show("Report saved successfully.")
        End If
        workbook.Close(True)    ' Close the workbook
        excelApp.Quit()    ' Close the Excel application
        releaseObject(totalWorksheet)    ' Release the Excel objects
        releaseObject(transWorksheet)
        releaseObject(tableWorksheet)
        releaseObject(workbook)
        releaseObject(excelApp)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub shiftCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles shiftCombo.SelectedIndexChanged
        Dim selectedDate As DateTime = DateTimePicker.Value
        Dim dayOfWeek As String = selectedDate.DayOfWeek.ToString()
        If shiftCombo.SelectedItem = "Mornning" Then
            fromCombo.SelectedItem = "07:00 AM"
            toCombo.SelectedItem = "03:00 PM"
            If dayOfWeek = "Friday" Or dayOfWeek = "Saturday" Then
                toCombo.SelectedItem = "07:00 PM"
            End If
        ElseIf shiftCombo.SelectedItem = "Afternoon" Then
            fromCombo.SelectedItem = "02:00 PM"
            toCombo.SelectedItem = "10:00 PM"
        ElseIf shiftCombo.SelectedItem = "Night" Then
            fromCombo.SelectedItem = "09:00 PM"
            toCombo.SelectedItem = "07:00 AM"
            If dayOfWeek = "Friday" Or dayOfWeek = "Saturday" Then
                fromCombo.SelectedItem = "07:00 PM"
            End If
        End If
    End Sub

    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker.ValueChanged
        Dim hijriMonth As Integer = hijriCalendar.GetMonth(CDate(DateTimePicker.Value.AddDays(offset)))  'ramadan is 9
        Dim hijriDay As Integer = hijriCalendar.GetDayOfMonth(CDate(DateTimePicker.Value.AddDays(offset)))
        If hijriMonth = 9 Then
            ramLabel.Visible = True
            ramLabel.Text = hijriDay & " Ramadan"
        Else
            ramLabel.Visible = False
        End If
        Dim selectedDate As DateTime = DateTimePicker.Value
        Dim dayOfWeek As String = selectedDate.DayOfWeek.ToString()
        If shiftCombo.SelectedItem = "Mornning" Then
            fromCombo.SelectedItem = "07:00 AM"
            toCombo.SelectedItem = "03:00 PM"
            If dayOfWeek = "Friday" Or dayOfWeek = "Saturday" Then
                toCombo.SelectedItem = "07:00 PM"
            End If
        ElseIf shiftCombo.SelectedItem = "Afternoon" Then
            fromCombo.SelectedItem = "02:00 PM"
            toCombo.SelectedItem = "10:00 PM"
        ElseIf shiftCombo.SelectedItem = "Night" Then
            fromCombo.SelectedItem = "09:00 PM"
            toCombo.SelectedItem = "07:00 AM"
            If dayOfWeek = "Friday" Or dayOfWeek = "Saturday" Then
                fromCombo.SelectedItem = "07:00 PM"
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles deleteButton.Click
        If DataGridView1.SelectedRows.Count > 0 Then    ' Check if a row is selected
            Dim result As DialogResult = MessageBox.Show("Are you sure Delete this record?", "Confirmation", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)   ' Get the selected row
                Dim valueToDelete As String = selectedRow.Cells("Date").Value.ToString()  ' Get the value from a specific column in the selected row
                DeleteFromTable(valueToDelete)   ' Delete the record from the table using the value
                DataGridView1.Rows.Remove(selectedRow)    ' Remove the selected row from the DataGridView
                MsgBox("Record Deleted")
            ElseIf result = DialogResult.No Then    ' Do nothing
            End If
        Else
            MsgBox("No Record Selected")
        End If
    End Sub
    Private Sub DeleteFromTable(value As String)
        Dim currentUser As User = userList.Find(Function(u) u.aliasName = userCombo.Text)
        Dim connectionString As String = "Data Source=OPDB.db;Version=3;"
        Using connection As New SQLiteConnection(connectionString)
            Dim commandText As String = "DELETE FROM T" & currentUser.userName & " WHERE Date = @DateValue"
            Dim command As New SQLiteCommand(commandText, connection)
            command.Parameters.AddWithValue("@DateValue", value)
            connection.Open()
            command.ExecuteNonQuery()
        End Using
        CalculateOverSum("T" & currentUser.userName, Label9, monthCombo.Text)
        CalculateTransSum("T" & currentUser.userName, Label2, monthCombo.Text)
        CalculateBreakFastSum("T" & currentUser.userName, Label10, monthCombo.Text)
        CalculateLunchSum("T" & currentUser.userName, Label7, monthCombo.Text)
        currentUser = userList.Find(Function(u) u.aliasName = userApply.Text)
        CalculateOverSum("T" & currentUser.userName, overTimeLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateTransSum("T" & currentUser.userName, transLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateBreakFastSum("T" & currentUser.userName, breakFastLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateLunchSum("T" & currentUser.userName, lunchLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
    End Sub
    Private Sub CalculateBreakFastSum(table, lableName, month)
        Dim connectionString As String = "Data Source=OPDB.db;Version=3;"
        Dim query As String = "SELECT SUM(BreakFast) FROM " & table & " WHERE Date LIKE '%/" & month & "/%'"
        Using connection As New SQLiteConnection(connectionString)
            Dim command As New SQLiteCommand(query, connection)
            connection.Open()
            Dim sum As Object = command.ExecuteScalar()
            If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                lableName.Text = "BreakFast: " & sum.ToString()
            Else
                lableName.Text = "BreakFast: 0"
            End If
        End Using
    End Sub

    Public Sub FindLastApply(table As String, lablName As System.Windows.Forms.Label)
        Dim connectionString As String = "Data Source=OPDB.db;Version=3;"
        Dim allDates As New List(Of DateTime)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT date FROM " & table
            Dim command As New SQLiteCommand(query, connection)
            Dim reader As SQLiteDataReader = command.ExecuteReader()
            While reader.Read()    ' Collect all the date values in the list
                If Not reader.IsDBNull(reader.GetOrdinal("date")) Then
                    Dim dateString As String = reader.GetString(reader.GetOrdinal("date"))
                    Dim formats() As String = {"yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy"}    ' Try to parse the date string in different formats
                    Dim parsedDate As DateTime
                    Dim isDateParsed As Boolean = False
                    For Each format As String In formats
                        If DateTime.TryParseExact(dateString, format, Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, parsedDate) Then
                            allDates.Add(parsedDate)
                            isDateParsed = True
                            Exit For
                        End If
                    Next
                    If Not isDateParsed Then
                        MsgBox("Error: Unable to parse a date value")
                    End If
                End If
            End While
            reader.Close()
            connection.Close()
        End Using
        If allDates.Count > 0 Then    ' Find the newest date
            Dim newestDate As DateTime = allDates.Max()
            lablName.Text = "Last Apply: " & newestDate.ToString("dd/MM/yyyy")
        Else
            lablName.Text = "Last Apply: None"
        End If
    End Sub
    Private Sub CalculateLunchSum(table, lableName, month)
        Dim connectionString As String = "Data Source=OPDB.db;Version=3;"
        Dim query As String = "SELECT SUM(Lunch) FROM " & table & " WHERE Date LIKE '%/" & month & "/%'"
        Using connection As New SQLiteConnection(connectionString)
            Dim command As New SQLiteCommand(query, connection)
            connection.Open()
            Dim sum As Object = command.ExecuteScalar()
            If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                lableName.Text = "Lunch: " & sum.ToString()
            Else
                lableName.Text = "Lunch: 0"
            End If
        End Using
    End Sub
    Private Sub CalculateTransSum(table, lableName, month)
        Dim connectionString As String = "Data Source=OPDB.db;Version=3;"
        Dim query As String = "SELECT SUM(Transportation) FROM " & table & " WHERE Date LIKE '%/" & month & "/%'"
        Using connection As New SQLiteConnection(connectionString)
            Dim command As New SQLiteCommand(query, connection)
            connection.Open()
            Dim sum As Object = command.ExecuteScalar()
            If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                lableName.Text = "Transportation: " & sum.ToString() & " EGP"
            Else
                lableName.Text = "Transportation: 0 EGP"
            End If
        End Using
    End Sub
    Private Sub CalculateOverSum(table, lableName, month)
        Dim connectionString As String = "Data Source=OPDB.db;Version=3;"
        Dim query As String = "SELECT SUM(OverTimeHours) FROM " & table & " WHERE Date LIKE '%/" & month & "/%'"
        Using connection As New SQLiteConnection(connectionString)
            Dim command As New SQLiteCommand(query, connection)
            connection.Open()
            Dim sum As Object = command.ExecuteScalar()
            If sum IsNot Nothing AndAlso sum IsNot DBNull.Value Then
                lableName.Text = "OverTime: " & sum.ToString() & " Hours"
            Else
                lableName.Text = "OverTime: 0 Hours"
            End If
        End Using
    End Sub

    Private Sub userApply_SelectedIndexChanged(sender As Object, e As EventArgs) Handles userApply.SelectedIndexChanged
        Dim currentUser As User = userList.Find(Function(u) u.aliasName = userApply.Text)      'initialize variable
        CalculateOverSum("T" & currentUser.userName, overTimeLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateTransSum("T" & currentUser.userName, transLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateBreakFastSum("T" & currentUser.userName, breakFastLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
        CalculateLunchSum("T" & currentUser.userName, lunchLabel, Mid(Format(DateTimePicker.Value, "dd/MM/yyyy"), 4, 2))
    End Sub

    Private Sub userCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles userCombo.SelectedIndexChanged
        DataGridView1.Columns.Clear()
        Label9.Text = "OverTime: 0 Hours"
        Label2.Text = "Transportation: 0 EGP"
        Label10.Text = "BreakFast: 0"
        Label7.Text = "Lunch: 0"
        Label11.Text = "Last Apply: None"
    End Sub

    Private Sub monthCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles monthCombo.SelectedIndexChanged
        DataGridView1.Columns.Clear()
        Label9.Text = "OverTime: 0 Hours"
        Label2.Text = "Transportation: 0 EGP"
        Label10.Text = "BreakFast: 0"
        Label7.Text = "Lunch: 0"
    End Sub
End Class
Public Class User
    Public Property userName As String
    Public Property aliasName As String
    Public Property rank As String
    Public Property arabName As String
    Public Property arabNick As String
    Public Property inTable As String
End Class
