Public Class TheoryCourses

    Dim line As Integer

    Private Sub liebiao()
        Me.ListView1.Items.Clear()
        Try
            Dim i As Integer
            Dim outputdatestr As String
            Dim outputdatenow As Date = Now.Date
            Try
                outputdatestr = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            Catch
                outputdatestr = Format(outputdatenow, "yyyy-MM-dd")
            End Try

            Dim tablename1 As String = "[" & schoolcalendar & "计算机安装与调试技术]"
            selectcmd = "select 学号,姓名,院系,选课时间,硬件时间,软件时间,备注 from " & tablename1 & " where CONVERT(varchar(10),选课时间, 23)='" & outputdatestr & "'"
            If sql(selectcmd, False) Then
                Do While myreader.Read '**********************查询上课成员************************
                    Me.ListView1.Items.Add((myreader("学号").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("姓名").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("院系").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("选课时间").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("硬件时间").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("软件时间").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("备注").ToString))
                    i += 1
                Loop
            End If
            conn.Close()
            Label1.Text = "共 " & i & " 人"
        Catch ex As Exception
            Me.ListView1.Items.Clear()
            MsgBox(ex.ToString)
        End Try
    End Sub '列表

    Private Sub seline()
        Try
            If ListView1.Items.Count <> 0 Then
                Me.ListView1.Items(line).Selected = True
            End If

            Me.ListView1.Items(line).BackColor = SystemColors.Highlight
            Me.ListView1.Items(line).ForeColor = Color.White
            Me.ListView1.Items(line).EnsureVisible()

            '**************显示个人信息***************
            selectcmd = "select * from [" & schoolcalendar & "计算机安装与调试技术] where 学号=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
            Dim tableinfo As New DataTable
            tableinfo = gettable(Val(Me.ListView1.SelectedItems.Item(0).Text), selectcmd, False)
            Me.TxtNum.Text = tableinfo.Rows(0).Item("学号").ToString.Trim
            Me.TxtName.Text = tableinfo.Rows(0).Item("姓名").ToString.Trim
            Me.Maillb.Text = tableinfo.Rows(0).Item("邮箱").ToString.Trim
            Me.phonelb.Text = tableinfo.Rows(0).Item("联系电话").ToString.Trim
            Me.liluntime.Text = tableinfo.Rows(0).Item("理论课").ToString.Trim
            Me.selecttime.Text = tableinfo.Rows(0).Item("选课时间").ToString.Trim
            If tableinfo.Rows(0).Item("备注").ToString.Trim = "正常" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            Else
                RadioButton1.Checked = False
                RadioButton2.Checked = True
            End If
            '**************显示个人信息***************
        Catch ex As Exception
        End Try
    End Sub '显示个人信息

    Private Sub TheoryCourses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'connection()
        'init()        '*************调试时使用*************
        Dim strsql As String
        CBTime.Items.Clear()
        strsql = "select distinct CONVERT(varchar(100), 选课时间, 23) from [" & schoolcalendar & "计算机安装与调试技术]"
        sql(strsql, False)
        While myreader.Read
            If IsDBNull(myreader.Item(0)) = True Then
                CBTime.Items.Add("未选课")
            Else
                CBTime.Items.Add(myreader.Item(0))
            End If
        End While
        change()
        liebiao()
        seline()
        Me.TxtNum.Focus()
    End Sub

    Private Sub InputScore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Up Then
                If line > 0 And line < Me.ListView1.Items.Count Then
                    Me.ListView1.Items(line).Selected = False
                    Me.ListView1.Items(line).BackColor = Color.White
                    Me.ListView1.Items(line).ForeColor = Color.Black
                    line -= 1
                    seline()
                ElseIf line >= Me.ListView1.Items.Count Then
                    If Me.ListView1.Items.Count - 1 < 0 Then
                        Exit Sub
                    End If
                    line = Me.ListView1.Items.Count - 1
                    seline()
                End If
            ElseIf e.KeyCode = Keys.Down Then
                If line < Me.ListView1.Items.Count - 1 Then
                    Me.ListView1.Items(line).Selected = False
                    Me.ListView1.Items(line).BackColor = Color.White
                    Me.ListView1.Items(line).ForeColor = Color.Black
                    line += 1
                End If
                seline()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub  'listview中上下键功能

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        TxtName.Clear()
        TxtNum.Clear()
    End Sub

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call schid(sender, e)
        End If
    End Sub '按姓名查询

    Private Sub TxtNum_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNum.GotFocus
        TxtName.Clear()
        TxtNum.Clear()
    End Sub

    Private Sub TxtNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call schid(sender, e)
        End If
    End Sub '按学号查询

    Public Sub schid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtNum.Text = "" And TxtName.Text = "" Then
            Exit Sub
        Else
            Try
                Dim i As Byte = 0

                If sender.name.ToString = "TxtNum" Or sender.name.ToString = "TxtName" Then
                    If TxtNum.Text <> "" And TxtNum.Focused = True And TxtName.Focused = False Then
                        selectcmd = "select * from [" & schoolcalendar & "计算机安装与调试技术] where 学号=" & Val(TxtNum.Text)
                    ElseIf TxtName.Text <> "" And TxtName.Focused = True And TxtNum.Focused = False Then
                        selectcmd = "select * from [" & schoolcalendar & "计算机安装与调试技术] where 姓名 like '%" & TxtName.Text & "%'"
                    End If
                ElseIf sender.name.ToString = "CbCourse" Then
                    selectcmd = "select * from [" & schoolcalendar & "计算机安装与调试技术] where 学号=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
                End If

                If sql(selectcmd, False) And myreader.Read Then
                    Dim selday As String
                    selday = Format(Convert.ToDateTime(myreader("选课时间").ToString), "yyyy-MM-dd")
                    selectcmd = "select * from [" & schoolcalendar & "计算机安装与调试技术] where CONVERT(varchar(10),选课时间, 23) = '" & selday & "'"
                    conn.Close()

                    If selday = "" Then
                        MsgBox("该学生未上理论课，因此没有选试验课！")
                        Exit Sub
                    End If

                    If sql(selectcmd, False) Then
                        Do While myreader.Read
                            If myreader("学号").ToString = TxtNum.Text Or myreader("姓名").ToString = TxtName.Text Then
                                line = i
                                Exit Do
                            End If
                            i += 1
                        Loop
                    End If
                    conn.Close()

                    If Me.DateTimePicker1.Text = selday Then
                        Call DateTimePicker1_ValueChanged(sender, e)
                    Else
                        Me.DateTimePicker1.Value = selday
                    End If
                Else
                    conn.Close()
                    MsgBox("未搜索到该学生或是输入有误！")
                    Me.ListView1.Items.Clear()
                    TxtNum.Text = ""
                    TxtName.Text = ""
                End If
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
        End If
    End Sub '搜索

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        updatecmd = "update [" & schoolcalendar & "计算机安装与调试技术] set 备注 = '正常' where 学号=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
        sql(updatecmd, False)
        conn.Close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        updatecmd = "update [" & schoolcalendar & "计算机安装与调试技术] set 备注 = '未签到' where 学号=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
        sql(updatecmd, False)
        conn.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        liebiao()
        seline()
    End Sub

    Private Sub change()
        Dim str1 As String
        Dim table1 As DataTable
        Dim i, j As Integer
        str1 = "select * from [" & schoolcalendar & "计算机安装与调试技术] where 备注 is null or 备注=''"
        table1 = gettable("计算机安装与调试技术", str1, False)
        i = table1.Rows.Count
        For j = 0 To i - 1
            str1 = "update [" & schoolcalendar & "计算机安装与调试技术] set 备注 = '正常' where 学号='" & table1.Rows(j).Item("学号") & "'"
            sql(str1, False)
            conn.Close()
        Next
    End Sub '将所有备注为空的信息赋值为正常，选课功能里有按时间赋值功能，实践课期间上课自动赋值为未签到。互相不影响。

    Private Sub CBTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBTime.SelectedIndexChanged
        If CBTime.SelectedItem = "未选课" Then
            Me.ListView1.Items.Clear()
            Dim strsql As String
            Dim i As Integer
            strsql = "select 学号,姓名,院系,选课时间,硬件时间,软件时间,备注 from [" & schoolcalendar & "计算机安装与调试技术] where 选课时间 is NULL"
            If sql(strsql, False) Then
                Do While myreader.Read '**********************查询上课成员************************
                    Me.ListView1.Items.Add((myreader("学号").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("姓名").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("院系").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("选课时间").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("硬件时间").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("软件时间").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("备注").ToString))
                    i += 1
                Loop
            End If
            conn.Close()
            Label1.Text = "共 " & i & " 人"
        Else
            DateTimePicker1.Value = CDate(CBTime.SelectedItem)
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Try
            line = Me.ListView1.Items.IndexOf(Me.ListView1.SelectedItems.Item(0))
            liebiao()
            seline()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quit.Click
        Me.Close()
    End Sub

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

End Class