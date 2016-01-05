Imports System.Drawing
Imports System.Windows.Forms

Public Class inputscore
    Public line As Byte
    Public Getweek, semester As String
    Public std As Date, soft() As String, hard() As String
    Public selectcmd As String

#Region "初始化"

    Private Sub ini()
        Dim i As Byte = 0
        selectcmd = "select * from [开学日期] "
        If sql(selectcmd, True) And myreader.Read Then
            semester = Trim(myreader.Item("学期").ToString)
            std = Trim(myreader.Item("开学日期").ToString)
            soft = Trim(myreader.Item("软件周次").ToString).Split("~")
            hard = Trim(myreader.Item("硬件周次").ToString).Split("~")
        End If
        conn.Close()
    End Sub

    Private Function getw()
        ini()
        Dim days As Integer = DateDiff("d", std, Me.DateTimePicker1.Value.Date)
        Getweek = days \ 7 + 1
        Dim getday = days Mod 7 + 1
        Dim gbday() As Char = "日一二三四五六"
        Me.Label1.Text = "第" & Getweek & "周 周" & gbday(getday Mod 7)
        Return Trim(Str(Getweek * 100 + getday))
    End Function

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Try
            getw()
        Catch ex As Exception
            Exit Sub
        End Try
        liebiao()
        seline()
        TxtScore.Focus()
    End Sub

    Private Sub InputScorePanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles InputScorePanel.HandleCreated

        getw()
        init()
        get_info()
        If Val(Getweek) <= Val(hard(1).Trim) Or Val(Getweek) = 18 Then
            CBmoshi.Text = "成绩/成绩"
            Me.CbCourse.Text = "硬件课"
            liebiao()
            seline()
            TxtScore.Focus()
        ElseIf Val(Getweek) >= Val(soft(0).Trim) And Val(Getweek) <= Val(soft(1).Trim) Or Val(Getweek) = 19 Then
            CBmoshi.Text = "成绩/成绩"
            Me.CbCourse.Text = "软件课"
            liebiao()
            seline()
            TxtScore.Focus()
        Else
            CBmoshi.Text = "学号/成绩"
            liebiao()
            seline()
            TxtNum.Focus()
        End If
       
    End Sub

#End Region

#Region "键盘事件"

    Private Sub InputScore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown, TxtNum.KeyDown, TxtScore.KeyDown
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

    Private Sub TxtScore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtScore.KeyDown
        If e.KeyCode = Keys.Enter Then
            Submit_Score()
        End If
    End Sub  '成绩文本框回车功能

    Private Sub TxtNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call schid(sender, e)
            If Me.CBmoshi.Text = "学号/学号" Then
                Me.TxtNum.Focus()
                Me.TxtNum.Text = ""
            Else
                Me.TxtScore.Focus()
                Me.TxtName.Text = ""
            End If
        End If
    End Sub  '按学号搜索

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call schid(sender, e)
            Me.TxtScore.Focus()
            Me.TxtNum.Text = ""
        End If
    End Sub '按姓名搜索

#End Region

#Region "成绩录入"

    Private Function cj()
        If Me.RadioButton1.Checked = True Then
            cj = Me.RadioButton1.Text & "1"
        ElseIf Me.RadioButton2.Checked = True Then
            cj = Me.RadioButton2.Text & "2"
        ElseIf Me.RadioButton3.Checked = True Then
            cj = Me.RadioButton3.Text & "3"
        Else : Return ""
        End If
    End Function  '判断输入的科目

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        Me.TxtScore.Focus()
    End Sub

    Private Sub CbCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCourse.SelectedIndexChanged
        Call schid(sender, e)
    End Sub '选择课程下拉列表

    Private Sub Submit_Score()
        Try
            If TxtScore.Text = "" OrElse Num_Tb.Text = "" Then
                MsgBox("未输入成绩，或未选定学生！")
                Exit Sub
            End If

            If cj() = "" Then MsgBox("请选择成绩选项！") : Exit Sub
            If TxtScore.Text = "" Then TxtScore.Text = "NULL"
            '**********************修改后的成绩录入************************
            If (Val(TxtScore.Text) < 60 And TxtScore.Text <> "NULL") Then
                If MsgBox("确认成绩为" & TxtScore.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    TxtScore.Clear()
                    Exit Sub
                End If
            End If
            '*************************************************************************************

            If Val(Me.ListView1.Items(line).SubItems(CInt(Mid(cj, 5, 1)) + 2).Text) <> 0 Then 'CInt(Mid(cj,5,1))+2表示第几列数据
                If MsgBox("确认更新？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    If line < Me.ListView1.Items.Count - 1 Then
                        Me.ListView1.Items(line).Selected = False
                        Me.ListView1.Items(line).BackColor = Color.White
                        Me.ListView1.Items(line).ForeColor = Color.Black
                        line += 1
                    End If
                    liebiao()
                    seline()
                    TxtScore.Clear()
                    Me.TxtScore.Focus()
                    Exit Sub
                End If
            End If

            Dim updatecmd As String
            updatecmd = "update [" & semester & "_计算机安装与调试技术] set  " & Mid(cj, 1, 4) & "=" & TxtScore.Text & " where 学号=" & Me.ListView1.Items(line).Text
            If Me.RadioButton1.Checked Then
                logwrite("hard", Me.ListView1.Items(line).Text, TxtScore.Text)
            ElseIf Me.RadioButton2.Checked Then
                logwrite("soft", Me.ListView1.Items(line).Text, TxtScore.Text)
            ElseIf Me.RadioButton3.Checked Then
                logwrite("paper", Me.ListView1.Items(line).Text, TxtScore.Text)
            End If
            sql(updatecmd, False)
            conn.Close()

            If line < Me.ListView1.Items.Count - 1 Then
                Me.ListView1.Items(line).Selected = False
                Me.ListView1.Items(line).BackColor = Color.White
                Me.ListView1.Items(line).ForeColor = Color.Black
                line += 1
            End If
            liebiao()
            seline()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        TxtScore.Clear()
        If Me.CBmoshi.Text = "成绩/成绩" Then
            Me.TxtScore.Focus()
        Else
            Me.TxtNum.Focus()
        End If
    End Sub

    Private Sub BtSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSubmit.Click
        Submit_Score()
    End Sub

#End Region

#Region "学生查询"

    Public Sub schid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtNum.Text = "" And TxtName.Text = "" Then
            Exit Sub
        Else
            Try
                Dim i As Byte = 0
                If sender.name.ToString = "TxtNum" Or sender.name.ToString = "TxtName" Then
                    If TxtNum.Text <> "" And TxtNum.Focused = True And TxtName.Focused = False Then
                        selectcmd = "select * from [" & Me.semester & "_计算机安装与调试技术] where 学号=" & Val(TxtNum.Text)
                    ElseIf TxtName.Text <> "" And TxtName.Focused = True And TxtNum.Focused = False Then
                        selectcmd = "select * from [" & Me.semester & "_计算机安装与调试技术] where 姓名 like '%" & TxtName.Text & "%'"
                    End If
                ElseIf sender.name.ToString = "CbCourse" Then
                    If Me.ListView1.SelectedItems.Count <> 0 Then
                        selectcmd = "select * from [" & Me.semester & "_计算机安装与调试技术] where 学号=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
                    Else
                        selectcmd = "select * from [" & Me.semester & "_计算机安装与调试技术] where 学号=" & Val(Me.ListView1.Items(0).Text)
                    End If
                End If

                If sql(selectcmd, False) And myreader.Read Then
                    Dim selday As String
                    If Me.CbCourse.Text = "软件课" Then
                        selday = myreader("软件时间").ToString
                        selectcmd = "select * from [" & Me.semester & "_计算机安装与调试技术] where 软件时间=" & selday
                    Else
                        selday = myreader("硬件时间").ToString
                        selectcmd = "select * from [" & Me.semester & "_计算机安装与调试技术] where 硬件时间=" & selday
                    End If

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
                    Dim nd As Date = DateAdd("d", CInt(Mid(selday, 1, selday.Length - 2)) * 7 - 8 + CInt(Mid(selday, selday.Length - 1)), std)
                    If Me.DateTimePicker1.Text = nd Then
                        Call DateTimePicker1_ValueChanged(sender, e)
                    Else
                        Me.DateTimePicker1.Value = nd
                    End If
                    TxtScore.Focus()
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
    End Sub  '搜索函数

    Private Sub seline()  '显示个人信息
        Try
            If ListView1.Items.Count <> 0 Then
                If ListView1.Items.Count < line Then
                    Me.ListView1.Items(0).Selected = True
                    Me.ListView1.Items(0).BackColor = SystemColors.Highlight
                    Me.ListView1.Items(0).ForeColor = Color.White
                    Me.ListView1.Items(0).EnsureVisible()
                Else
                    Me.ListView1.Items(line).Selected = True
                    Me.ListView1.Items(line).BackColor = SystemColors.Highlight
                    Me.ListView1.Items(line).ForeColor = Color.White
                    Me.ListView1.Items(line).EnsureVisible()
                End If
            End If

            '**************显示个人信息***************
            Dim tableinfo As New DataTable
            If Me.ListView1.SelectedItems.Count = 0 Then
                selectcmd = "select * from [" & Me.semester & "_计算机安装与调试技术] where 学号=" & Val(Me.ListView1.Items(0).Text)
            Else
                selectcmd = "select * from [" & Me.semester & "_计算机安装与调试技术] where 学号=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
            End If
            tableinfo = gettable("显示个人信息", selectcmd, False)
            Me.TxtNum.Text = tableinfo.Rows(0).Item("学号").ToString.Trim
            Me.TxtName.Text = tableinfo.Rows(0).Item("姓名").ToString.Trim

            Me.Num_Tb.Text = tableinfo.Rows(0).Item("学号").ToString.Trim
            Me.Name_Tb.Text = tableinfo.Rows(0).Item("姓名").ToString.Trim
            Me.Maillb.Text = tableinfo.Rows(0).Item("邮箱").ToString.Trim
            Me.phonelb.Text = tableinfo.Rows(0).Item("联系电话").ToString.Trim
            Me.liluntime.Text = decode_lilun(tableinfo.Rows(0).Item("理论课").ToString.Trim)
            Me.selecttime.Text = tableinfo.Rows(0).Item("选课时间").ToString.Trim
            tableinfo.Dispose()
            '**************显示个人信息***************

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        TxtScore.Focus()
    End Sub

    Private Function decode_lilun(ByVal str As String)
        Dim day, week As Integer
        day = Val(str) Mod 10
        week = (Val(str) - day) / 100
        Return "第" & week & "周 " & GetDay(day)
    End Function

    Private Sub TxtNum_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNum.GotFocus
        TxtName.Clear()
        TxtNum.Clear()
    End Sub

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        TxtNum.Clear()
        TxtName.Clear()
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Try
            line = Me.ListView1.Items.IndexOf(Me.ListView1.SelectedItems.Item(0))
            liebiao()
            seline()
            TxtScore.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

    Private Sub liebiao() '列表函数

        Me.ListView1.Items.Clear()
        Try
            Dim i As Byte = 0
            If Val(Getweek) <= Val(hard(1).Trim) Then
                selectcmd = "select * from [" & semester & "_计算机安装与调试技术] where 硬件时间='" & getw() & "'"
                Me.Label1.Text += "     硬件课"
                Me.CbCourse.Text = "硬件课"
                Me.RadioButton1.Enabled = True
                Me.RadioButton1.Checked = True
                Me.RadioButton2.Enabled = False
                Me.RadioButton3.Enabled = False
            ElseIf Val(Getweek) <= Val(soft(1).Trim) And Val(Getweek) >= Val(soft(0).Trim) Then
                selectcmd = "select * from [" & semester & "_计算机安装与调试技术] where 软件时间='" & getw() & "'"
                Me.Label1.Text += "     软件课"
                Me.CbCourse.Text = "软件课"
                Me.RadioButton2.Enabled = True
                Me.RadioButton3.Enabled = True
                Me.RadioButton2.Checked = True
                Me.RadioButton1.Checked = False
                Me.RadioButton1.Enabled = False
            ElseIf Val(Getweek) = 18 Then
                selectcmd = "select * from [" & semester & "_计算机安装与调试技术] where 硬件时间='" & getw() & "'"
                Me.Label1.Text += "     硬件课"
                Me.CbCourse.Text = "硬件课"
                Me.RadioButton1.Enabled = True
                Me.RadioButton1.Checked = True
                Me.RadioButton2.Enabled = False
                Me.RadioButton3.Enabled = False
            ElseIf Val(Getweek) = 19 Then
                selectcmd = "select * from [" & semester & "_计算机安装与调试技术] where 软件时间='" & getw() & "'"
                Me.Label1.Text += "     软件课"
                Me.CbCourse.Text = "软件课"
                Me.RadioButton2.Enabled = True
                Me.RadioButton3.Enabled = True
                Me.RadioButton2.Checked = True
                Me.RadioButton1.Checked = False
                Me.RadioButton1.Enabled = False
            Else
                Exit Sub
            End If

            If sql(selectcmd, False) Then
                Do While myreader.Read '**********************查询上课成员************************
                    Me.ListView1.Items.Add((myreader("学号").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("姓名").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("院系").ToString))
                    Me.ListView1.Items(i).SubItems.Add(myreader(Me.RadioButton1.Text).ToString)
                    Me.ListView1.Items(i).SubItems.Add(myreader(Me.RadioButton2.Text).ToString)
                    Me.ListView1.Items(i).SubItems.Add(myreader(Me.RadioButton3.Text).ToString)
                    i += 1
                Loop
            End If
            conn.Close()
            Me.Label1.Text &= "      共 " & i & " 人"
            Me.TxtScore.Focus()
        Catch ex As Exception
            Me.ListView1.Items.Clear()
            'MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

End Class