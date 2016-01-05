Public Class LogRead

    Public line As Integer = 0

    Public Sub log()
        Dim i As Integer
        ColumnHeader1.Width = 38
        ColumnHeader2.Width = 72
        ColumnHeader3.Width = 120
        ColumnHeader4.Width = 90
        ColumnHeader5.Width = 84
        ColumnHeader6.Width = 60
        ColumnHeader7.Width = 60
        ColumnHeader8.Width = 60
        ColumnHeader9.Width = 97
        ColumnHeader10.Width = 24

        If Sql(strSql, True) Then
            Do While myreader.Read '**********************查询成员************************
                Me.ListView1.Items.Add((myreader("ID").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("操作人学号").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("操作时间").ToString))
                Me.ListView1.Items(i).SubItems.Add(Trim(myreader("操作人IP").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("被修改人学号").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("硬件成绩").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("软件成绩").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("试卷成绩").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("登录信息").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("版本号").ToString))
                i += 1
            Loop
        End If
        If Me.ListView1.Items.Count <> 0 Then
            ListView1.Items(line).Selected = True
        End If
        conn.Close()
        Label1.Text = "共" & i & "条记录"
    End Sub '读取log记录

    Public Sub ComboBoxInfo()
        Try
            Me.ComboBox1.Items.Clear()
            strSql = "select distinct 登录信息 from [Log] where 学期='" & schoolcalendar.Substring(0, 5) & "'"
            sql(strSql, True)
            ComboBox1.Items.Add("所有信息")
            While myreader.Read
                ComboBox1.Items.Add(myreader("登录信息"))
            End While
            conn.Close()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub '登陆信息

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.ListView1.Items.Clear()
        If ComboBox1.Text = "所有信息" Then
            strSql = "select * from [Log] where 登录信息 like '%%' and 学期='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        Else
            strSql = "select * from [Log] where 登录信息 like '%" & Me.ComboBox1.Text & "%' and 学期='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        End If
        log()
    End Sub '下拉列表修改

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim month As String
        Dim day As String
        ListView1.Items.Clear()
        If Me.DateTimePicker1.Value.Month < 10 Then
            month = "0" & Me.DateTimePicker1.Value.Month
        Else : month = Me.DateTimePicker1.Value.Month
        End If
        If Me.DateTimePicker1.Value.Day < 10 Then
            day = "0" & Me.DateTimePicker1.Value.Day
        Else : day = Me.DateTimePicker1.Value.Day
        End If
        strSql = "select * from [log] where Convert(varchar(100),操作时间,111) = '" & Me.DateTimePicker1.Value.Year & "/" & month & "/" & day & "' and 学期='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        log()
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox2.Clear()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub '控制textbox1只能输入数字

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.TextLength <> 9 Then
            Exit Sub
        Else
            ListView1.Items.Clear()
            strSql = "select * from [log] where 操作人学号 = '" & TextBox1.Text & "' and 学期='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
            log()
        End If
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox1.Clear()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub '控制textbox2只能输入数字

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength <> 9 Then
            Exit Sub
        Else
            ListView1.Items.Clear()
            strSql = "select * from [log] where 被修改人学号 = '" & TextBox2.Text & "' and 学期='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
            log()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If My.Computer.Network.Ping("192.168.1.252", 2000) = True Then
            strSql = "EXEC sp_configure 'show advanced options',1; RECONFIGURE; EXEC sp_configure 'xp_cmdshell',1;RECONFIGURE;"
            sql(strSql, True)
            strSql = "exec master..xp_cmdshell'bcp student.dbo.Log out d:\log.txt -c -S 192.168.1.252 -U sa -P elab2012'"
            sql(strSql, True)
            strSql = "EXEC sp_configure 'show advanced options',1; RECONFIGURE; EXEC sp_configure 'xp_cmdshell',0;RECONFIGURE;"
            sql(strSql, True)
            conn.Close()
            MsgBox("导出成功，请到252服务器上D:\log.txt取回文件")
        Else
            MsgBox("192.168.1.252网络不通，请联系相关同学")
        End If
    End Sub '导出到txt，保存在服务器上

    Private Sub Refreshbt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Refreshbt.Click
        strSql = "select * from Log where 学期='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        log()
        ComboBoxInfo()
        ComboBox1.Text = "所有信息"
    End Sub '刷新按钮

    Private Sub LogReadPanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles LogReadPanel.HandleCreated

        'init()     '**************调试时使用************
        strSql = "select * from Log where 学期='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        log()
        ComboBoxInfo()
        ComboBox1.Text = "所有信息"
    End Sub

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

End Class