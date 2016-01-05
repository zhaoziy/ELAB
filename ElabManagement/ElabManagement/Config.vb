Public Class Config

    Private Sub Config_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        selectcmd = "select * from 开学日期"
        sql(selectcmd, True)
        Try
            If myreader.Read Then
                Me.DateTimePicker1.Value = Trim(myreader.Item("开学日期").ToString)
                Dim hard() As String = myreader.Item("硬件周次").ToString.Trim.Split("~")
                Dim soft() As String = myreader.Item("软件周次").ToString.Trim.Split("~")
                Dim closexuanke As Boolean = myreader.Item("关闭选课")
                With Me
                    .NumericUpDown1.Value = hard(0)
                    .NumericUpDown2.Value = hard(1)
                    .NumericUpDown3.Value = soft(0)
                    .NumericUpDown4.Value = soft(1)
                    If closexuanke = False Then
                        RBno.Checked = True
                    Else
                        RByes.Checked = True
                    End If
                    Total.Text = myreader.Item("课容量")
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()

        If authority <> 8 Then                '非助教组长和班长清零按钮不显示
            ReturnZero.Visible = False
            ReturnZero.Enabled = False
        End If

    End Sub  '窗体读取

    Private Sub Save1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save1.Click
        If MsgBox("确认更新？", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim semester As String
            Dim i As Integer
            If DateDiff(DateInterval.Month, CDate(Me.DateTimePicker1.Value.Year & "-3-1"), CDate(Me.DateTimePicker1.Value)) <= 1 Then
                semester = Me.DateTimePicker1.Value.Year.ToString & "春"
            Else
                semester = Me.DateTimePicker1.Value.Year.ToString & "秋"
            End If

            updatecmd = "update 开学日期 set  开学日期='" & Me.DateTimePicker1.Value.ToShortDateString & "', 学期='" & semester & "', 硬件周次='" & Me.NumericUpDown1.Value & "~" & Me.NumericUpDown2.Value & "',软件周次='" & Me.NumericUpDown3.Value & "~" & Me.NumericUpDown4.Value & "',课容量= '" & Total.Text & "'"
            sql(updatecmd, True)
            conn.Close()

            If Me.NumericUpDown3.Value - Me.NumericUpDown2.Value >= 1 Then

                For i = Me.NumericUpDown1.Value To Me.NumericUpDown2.Value
                    updatecmd = "update 上课日期 set 是否可选='是' ,上课类型 = '硬件课' ,助教容量='1',课容量='" & Total.Text & "' where 周次='" & i & "' and 上课类型 is not null"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = Me.NumericUpDown3.Value To Me.NumericUpDown4.Value
                    updatecmd = "update 上课日期 set 是否可选='是' ,上课类型 = '软件课' ,助教容量='1',课容量='" & Total.Text & "' where 周次='" & i & "' and 上课类型 is not null"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = 6 To Me.NumericUpDown1.Value - 1
                    updatecmd = "update 上课日期 set 是否可选='否' ,上课类型 = NULL ,助教容量 = NULL ,课容量 = NULL where 周次='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = Me.NumericUpDown4.Value + 1 To 18
                    updatecmd = "update 上课日期 set 是否可选='否' ,上课类型 = NULL ,助教容量 = NULL ,课容量 = NULL where 周次='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                If Me.NumericUpDown3.Value - Me.NumericUpDown2.Value > 1 Then
                    For i = Me.NumericUpDown2.Value + 1 To Me.NumericUpDown3.Value - 1
                        updatecmd = "update 上课日期 set 是否可选='否' ,上课类型 = NULL ,助教容量 = NULL ,课容量 = NULL where 周次='" & i & "'"
                        sql(updatecmd, True)
                        conn.Close()
                    Next
                End If
            Else
                MsgBox("时间设置有误！")
                Exit Sub
            End If

            Grade()
            MsgBox("当前设置已保存！" & vbCrLf & vbCrLf & "请重新启动程序！")
        End If
    End Sub  '初始设定保存按钮

    Private Sub Save1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Save1.MouseEnter
        Me.ToolTip1.SetToolTip(sender, "保存本框内当前设置，不修改其他设置")
    End Sub

    Private Sub Save2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save2.Click
        If RBno.Checked = True Then
            updatecmd = "update 开学日期 set 关闭选课= 'False'"
        Else
            updatecmd = "update 开学日期 set 关闭选课= 'True'"
        End If
        sql(updatecmd, True)
        conn.Close()
        MsgBox("选课启闭设定成功！")
    End Sub  '选课开关保存按钮

    Private Sub quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quit.Click
        Me.Close()
    End Sub   '关闭按钮

    Private Sub ReturnZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnZero.Click
        
        If MsgBox("确认更新？", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            Dim str As String
            str = "update member set 主讲=0 ,助课=0"
            sql(str, True)
            conn.Close()
            MsgBox("主讲与助教次数数据已清除！")

            Dim semester As String
            Dim i As Integer
            If DateDiff(DateInterval.Month, CDate(Me.DateTimePicker1.Value.Year & "-3-1"), CDate(Me.DateTimePicker1.Value)) <= 1 Then
                semester = Me.DateTimePicker1.Value.Year.ToString & "春"
            Else
                semester = Me.DateTimePicker1.Value.Year.ToString & "秋"
            End If

            updatecmd = "update 开学日期 set  开学日期='" & Me.DateTimePicker1.Value.ToShortDateString & "', 学期='" & semester & "', 硬件周次='" & Me.NumericUpDown1.Value & "~" & Me.NumericUpDown2.Value & "',软件周次='" & Me.NumericUpDown3.Value & "~" & Me.NumericUpDown4.Value & "',课容量= '" & Total.Text & "'"
            sql(updatecmd, True)
            conn.Close()

            If Me.NumericUpDown3.Value - Me.NumericUpDown2.Value >= 1 Then

                For i = Me.NumericUpDown1.Value To Me.NumericUpDown2.Value
                    updatecmd = "update 上课日期 set 是否可选='是' ,上课类型 = '硬件课' ,助教容量='1',课容量='" & Total.Text & "' where 周次='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = Me.NumericUpDown3.Value To Me.NumericUpDown4.Value
                    updatecmd = "update 上课日期 set 是否可选='是' ,上课类型 = '软件课' ,助教容量='1',课容量='" & Total.Text & "' where 周次='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = 6 To Me.NumericUpDown1.Value - 1
                    updatecmd = "update 上课日期 set 是否可选='否' ,上课类型 = NULL ,助教容量 = NULL ,课容量 = NULL where 周次='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = Me.NumericUpDown4.Value + 1 To 18
                    updatecmd = "update 上课日期 set 是否可选='否' ,上课类型 = NULL ,助教容量 = NULL ,课容量 = NULL where 周次='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                If Me.NumericUpDown3.Value - Me.NumericUpDown2.Value > 1 Then
                    For i = Me.NumericUpDown2.Value + 1 To Me.NumericUpDown3.Value - 1
                        updatecmd = "update 上课日期 set 是否可选='否' ,上课类型 = NULL ,助教容量 = NULL ,课容量 = NULL where 周次='" & i & "'"
                        sql(updatecmd, True)
                        conn.Close()
                    Next
                End If
            Else
                MsgBox("时间设置有误！")
                Exit Sub
            End If

            Grade()
            MsgBox("初始化设定成功！" & vbCrLf & vbCrLf & "请重新启动程序！")
        End If
    End Sub  '完全初始化

    Private Sub ReturnZero_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReturnZero.MouseEnter
        Me.ToolTip1.SetToolTip(sender, "所有数据初始化，建议开学初设定")
    End Sub

    Private Sub Grade()
        Dim str As String = String.Empty
        Dim str_grade As String = String.Empty
        Dim num_table As DataTable
        Dim grade As Integer
        Dim i As Integer

        Try
            str = "select distinct 学号 from [member]"
            num_table = gettable("num_table", str, True)

            For i = 0 To num_table.Rows.Count - 1
                If num_table.Rows(i).Item("学号").ToString.Count = 9 Then
                    grade = CInt(Now.Year.ToString) - CInt(num_table.Rows(i).Item("学号").ToString().Substring(0, 4))
                    If Now.Month >= 8 Then
                        If grade = 0 Then
                            str_grade = "大一"
                        ElseIf grade = 1 Then
                            str_grade = "大二"
                        ElseIf grade = 2 Then
                            str_grade = "大三"
                        ElseIf grade = 3 Then
                            str_grade = "大四"
                        ElseIf grade > 3 Then
                            str_grade = "往届"
                        End If
                    Else
                        If grade = 1 Then
                            str_grade = "大一"
                        ElseIf grade = 2 Then
                            str_grade = "大二"
                        ElseIf grade = 3 Then
                            str_grade = "大三"
                        ElseIf grade = 4 Then
                            str_grade = "大四"
                        ElseIf grade > 4 Then
                            str_grade = "往届"
                        End If
                    End If
                    str = "update [member] set 年级='" & str_grade & "' where 学号='" & num_table.Rows(i).Item("学号").ToString() & "'"
                    sql(str, True)
                    conn.Close()
                End If
            Next
            num_table.Dispose()
            MsgBox("学生年级已经设定成功")
        Catch ex As Exception
            MsgBox("学生年级已经设定出错，请重新初始化")
        End Try
     
    End Sub

End Class