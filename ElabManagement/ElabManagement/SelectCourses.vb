Public Class selectcourses

    Private weekno As Integer
    Private Lbl(6, 9) As Label   '**************容量为70（7*10）的数组**************
    Private LblWeek(9) As Label  '**************容量为10的数组**************
    Private LblTime(6) As Label  '**************容量为7的数组**************

#Region "窗体事件"

    Private Sub SelectCoursesPanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectCoursesPanel.HandleCreated
        'connection()   '**************调试时使用***************
        initialize()
        searchclass()
    End Sub

    Private Sub searchclass()   '*************查询某同学的选课时间*************

        Dim tableclass1 As String = "[" & schoolcalendar & "计算机安装与调试技术]"

        Dim sqlstr As String

        lblinfo.Text = username & "同学，" & "你已选择如下课程："

        sqlstr = "select 学号,姓名,硬件时间,软件时间 from " & tableclass1 & " where 学号 =" & usernum

        Dim classtable As New DataTable
        classtable = gettable("已选调试课", sqlstr, False)

        If classtable.Rows.Count > 0 Then
            Dim weekstr As String
            Dim week, time As Integer
            If classtable.Rows(0).Item("硬件时间").ToString <> "" And classtable.Rows(0).Item("硬件时间").ToString <> "1801" Then
                week = classtable.Rows(0).Item("硬件时间") \ 100
                time = classtable.Rows(0).Item("硬件时间") Mod 10
                Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.Green
                lblhard.Text = "硬件拆装"
                lblhard.Text &= vbCrLf & " 第 " & week & " 周 "
                lblhard.Visible = True
                lblhard.Text = lblhard.Text & GetDay(time) & vbCrLf & "下午 1:30 - 9:00"
            End If

            If classtable.Rows(0).Item("软件时间").ToString <> "" And classtable.Rows(0).Item("软件时间").ToString <> "1901" Then
                week = classtable.Rows(0).Item("软件时间") \ 100
                time = classtable.Rows(0).Item("软件时间") Mod 10
                Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.Green
                lblsoft.Text = "软件安装"
                lblsoft.Text &= vbCrLf & " 第 " & week & " 周 "
                weekstr = ""
                lblsoft.Visible = True
                lblsoft.Text = lblsoft.Text & GetDay(time) & vbCrLf & "下午 1:30 - 9:00"
            End If
        End If
        classtable.Dispose()
    End Sub

#End Region

#Region "初始化"

    Public Sub initialize()

        lblinfo.Text = username & "同学，" & "你已选择如下课程："
        lblhard.BackColor = Color.LightGreen
        lblsoft.BackColor = Color.Pink

        'init()
        getweek()
        weekno = CInt(RJ(1)) - CInt(YJ(0)) + 1

        Dim Width As Integer = LblStandard.Width
        Dim Height As Integer = LblStandard.Height
        Dim i, j As Integer
        '*******************时间栏*****************
        For i = 0 To 7 - 1 Step 1
            LblTime(i) = New Label
            LblTime(i).AutoSize = False
            LblTime(i).Height = Height
            LblTime(i).Width = Width
            LblTime(i).Top = LblStandard.Top
            LblTime(i).Left = LblStandard.Left + (i + 1) * Width
            LblTime(i).BorderStyle = BorderStyle.FixedSingle
            LblTime(i).BackColor = Color.FromArgb(128, 255, 255)
            LblTime(i).Font = New Font("宋体", 12)
            If i < 7 Then LblTime(i).Text = GetDay(i + 1)
            LblTime(i).TextAlign = ContentAlignment.MiddleCenter
            PanelTime.Controls.Add(LblTime(i))
        Next
        '***********************周次栏***********************
        For j = 0 To weekno - 1 Step 1
            LblWeek(j) = New Label
            LblWeek(j).AutoSize = False
            LblWeek(j).Height = Height
            LblWeek(j).Width = Width
            LblWeek(j).Top = LblStandard.Top + (j + 1) * Height
            LblWeek(j).Left = LblStandard.Left
            LblWeek(j).BorderStyle = BorderStyle.FixedSingle
            LblWeek(j).BackColor = Color.FromArgb(128, 255, 255)
            LblWeek(j).Font = New Font("宋体", 12)

            Dim Decade As Integer = j + CInt(YJ(0))
            If Decade < 10 Then
                LblWeek(j).Text = "第 " & "0" & (j + CInt(YJ(0))).ToString & " 周"
            Else
                LblWeek(j).Text = "第 " & (j + CInt(YJ(0))).ToString & " 周"
            End If
            LblWeek(j).TextAlign = ContentAlignment.MiddleCenter
            PanelTime.Controls.Add(LblWeek(j))
        Next
        '*********************表格区********************
        For j = 0 To weekno - 1
            For i = 0 To 6     'i代表周几，j代表第几周
                Lbl(i, j) = New Label
                Lbl(i, j).Name = "lbl" & i.ToString & j.ToString
                Lbl(i, j).AutoSize = False
                Lbl(i, j).Width = Width
                Lbl(i, j).Height = Height
                Lbl(i, j).Top = LblStandard.Top + (j + 1) * Height
                Lbl(i, j).Left = LblStandard.Left + (i + 1) * Width
                Lbl(i, j).BorderStyle = BorderStyle.Fixed3D
                Lbl(i, j).BackColor = Color.FloralWhite
                Lbl(i, j).TextAlign = ContentAlignment.MiddleCenter
                Lbl(i, j).Font = New Font("宋体", 12)
                PanelTime.Controls.Add(Lbl(i, j))
                Lbl(i, j).TabIndex = 1000 + (j + 1) * 10 + i + 1
                AddHandler Lbl(i, j).DoubleClick, New System.EventHandler(AddressOf Me.lbl_doubleclick)
                AddHandler Lbl(i, j).MouseEnter, New System.EventHandler(AddressOf Me.lbl_MouseEnter)
            Next
        Next
        gettime()
        getremain()
    End Sub

    Private Function gettime() As Boolean     '***************填充表格****************
        Dim i, j As Integer
        For i = 0 To CInt(YJ(1)) - CInt(YJ(0))
            For j = 0 To 6
                Lbl(j, i).Text = "硬件拆装"
                Lbl(j, i).BackColor = Color.LightGreen
            Next
        Next
        For i = CInt(RJ(0)) - CInt(YJ(0)) To CInt(RJ(1)) - CInt(YJ(0))
            For j = 0 To 6
                Lbl(j, i).Text = "软件安装"
                Lbl(j, i).BackColor = Color.Pink
            Next
        Next
    End Function

    Private Sub getremain()    '**************读取选课人数****************
        Application.DoEvents()
        gettotalnum()
        Dim i, j As Integer
        Dim sqlstr As String
        For i = 0 To YJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select count(*) from [" & schoolcalendar & "计算机安装与调试技术] "
                sqlstr &= "where 硬件时间 = " & (i + YJ(0)) & "0" & (j + 1)
                If sql(sqlstr, False) And myreader.Read Then
                    Lbl(j, i).Text = "硬件" & "(" & (Totalnum(j, i) - CInt(myreader.Item(0).ToString.Trim)) & "/" & Totalnum(j, i) & ")"
                    If CInt(myreader.Item(0).ToString.Trim) >= Totalnum(j, i) Then
                        Lbl(j, i).BackColor = Color.Red
                        'Else : Lbl(j, i).BackColor = Color.LightGreen
                    End If
                End If
                conn.Close()
                sqlstr = "select 是否可选 from [上课日期]"
                sqlstr &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "'"
                If sql(sqlstr, True) And myreader.Read Then
                    If myreader.Item(0) = "否" Then
                        Lbl(j, i).Text = "禁止选课"
                        Lbl(j, i).BackColor = Color.Gray
                    End If
                End If
                conn.Close()
            Next
        Next
        For i = RJ(0) - YJ(0) To RJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select count(*) from [" & schoolcalendar & "计算机安装与调试技术] "
                sqlstr &= "where 软件时间 = " & (i + YJ(0)) & "0" & (j + 1)
                If sql(sqlstr, False) And myreader.Read Then
                    Lbl(j, i).Text = "软件" & "(" & (Totalnum(j, i) - CInt(myreader.Item(0).ToString.Trim)) & "/" & Totalnum(j, i) & ")"
                    If CInt(myreader.Item(0).ToString.Trim) >= Totalnum(j, i) Then Lbl(j, i).BackColor = Color.Red
                End If
                conn.Close()
                sqlstr = "select 是否可选 from [上课日期]"
                sqlstr &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "'"
                If sql(sqlstr, True) And myreader.Read Then
                    If myreader.Item(0) = "否" Then
                        Lbl(j, i).Text = "禁止选课"
                        Lbl(j, i).BackColor = Color.Gray
                    End If
                End If
                conn.Close()
            Next
        Next
    End Sub

#End Region

#Region "选课"

    Private Sub xuanke(ByVal tablename As String, ByVal columnname As String, ByVal columnvalue As Integer)

        Dim week, time As Integer
        If CInt(columnvalue) = 0 Then
            MsgBox("错误！", MsgBoxStyle.OkOnly, "警告")
        End If
        week = columnvalue \ 100
        time = columnvalue Mod 10

        Try
            Dim datenow As Date = Now.Date
            Dim updatestr As String = "update " & tablename & " set 选课时间 = '" & DateTime.Now & "'," & columnname & "=" & _
                          columnvalue.ToString & " where 学号= " & usernum & " and 选课时间 is NULL;"
            updatestr &= "update " & tablename & " set " & columnname & "=" & _
                          columnvalue.ToString & " where 学号= " & usernum & " and 选课时间 is not NULL"
            executesql(tablename, updatestr)        '如果选课时间为null，则更新选课时间和上课时间，否则只更新上课时间（需要知道第一次选课的时间）

            Dim checknum As String = "select count(*) from " & tablename & " where " & columnname & "='" & columnvalue.ToString & "'"
            Dim num As Integer
            sql(checknum, False)
            If myreader.Read() Then
                num = myreader.Item(0)
                If num > Totalnum(CInt(time - 1), CInt(week - YJ(0))) Then
                    updatestr = "update " & tablename & " set 选课时间 = NULL, " & columnname & "= NULL where 学号='" & usernum & "'"
                    sql(updatestr, False)
                    conn.Close()
                End If
            End If
            conn.Close()

            If num > Totalnum(CInt(time - 1), CInt(week - YJ(0))) Then
                MsgBox("对不起，已经没有课余量了！")
                gettime()
                getremain()
                searchclass()
                Exit Sub
            End If


            Dim weeks As Integer
            weeks = DateDiff(DateInterval.DayOfYear, startday, GetServerTime()) \ 7 + 1    '校历第几周
            If weeks < YJ(0) Then  '选课时间在理论课期间正常选课，备注记录正常
                strSql = "update " & tablename & " set 备注='正常' where 学号 = '" & usernum & "'"
                sql(strSql, False)
                conn.Close()
                MsgBox("选课成功！请牢记选课时间。", MsgBoxStyle.OkOnly, "信息")
            ElseIf authority = 1 Then  '选课时间在实践课期间，且是第一次进行选课，备注记录未签到
                strSql = "update " & tablename & " set 备注='未签到' where 学号 = '" & usernum & "'"
                sql(strSql, False)
                conn.Close()
                MsgBox("选课成功！选课时间不在理论课期间，按未签到处理。")
            ElseIf authority = 2 Then  '选课时间在实践课期间，且非第一次进行选课，即进行课程修改，备注记录不修改。不影响正常上课时登记的备注记录
                MsgBox("选课成功！请牢记选课时间。", MsgBoxStyle.OkOnly, "信息")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        gettime()
        getremain()
        searchclass()
    End Sub '选课

    Private Sub lbl_doubleclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If authority = 1 Then
            If CloseXuanke = True Then MsgBox("选课系统已关闭！") : Exit Sub
        ElseIf authority = 8 Then : Exit Sub '管理员界面时，管理员查看选课信息。不进行上课情况修改
        End If

        getremain()  '**************读取选课人数,确保课余量****************

        Dim lblback As Color = sender.backcolor
        If lblback = Color.Red Then
            MsgBox("课余量已为零!", MsgBoxStyle.OkOnly, "警告")
            Exit Sub
        ElseIf lblback = Color.Gray Then
            MsgBox("因该时间段为节假日或其他原因，不能选课，请选择其他时间！", MsgBoxStyle.OkOnly, "警告")
            Exit Sub
        ElseIf lblback = Color.Green Then
            MsgBox("你已选择此段时间！", MsgBoxStyle.OkOnly, "警告")
            Exit Sub
        End If
        Dim week, time As Integer
        week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
        time = sender.tabindex Mod 10

        Dim tablename As String = "[" & schoolcalendar
        Dim columnname As String
        Dim columnvalue As Integer = week * 100 + time
        Dim sendertext As String = sender.text
        Dim lbltext As String = Microsoft.VisualBasic.Left(sendertext, 2)
        If lbltext = "" Then
            Exit Sub
        End If
        Select Case lbltext
            Case "硬件"
                tablename = tablename & "计算机安装与调试技术]"
                columnname = "硬件时间"
            Case "软件"
                tablename = tablename & "计算机安装与调试技术]"
                columnname = "软件时间"
            Case Else
                tablename = ""
                columnname = ""
                MsgBox("错误！", MsgBoxStyle.OkOnly, "警告")
                Exit Sub
        End Select
        xuanke(tablename, columnname, columnvalue)

    End Sub '双击标签

    Private Sub lbl_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.backcolor <> Color.FloralWhite Then
            If sender.backcolor <> Color.Gray Then
                Try
                    Dim week, time As Integer
                    week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
                    time = sender.tabindex Mod 10
                    Dim d As Date = DateAdd(DateInterval.Day, (week - 1) * 7 + time - 1, startday)
                    Dim course As String = ""
                    If week >= YJ(0) And week <= YJ(1) Then course = "安装与调试(硬件部分)"
                    If week >= RJ(0) And week <= RJ(1) Then course = "安装与调试(软件部分)"
                    Dim remain As Integer = CInt(sender.text.ToString.Split("(")(1).Split("/")(0))
                    Me.ToolTip1.SetToolTip(sender, "第" & week & "周 " & GetDay(time) & vbCrLf & d & vbCrLf & course & vbCrLf & "剩余" & remain & "人")
                Catch ex As Exception
                End Try
            Else
                Try
                    Dim week, time As Integer
                    week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
                    time = sender.tabindex Mod 10
                    Dim d As Date = DateAdd(DateInterval.Day, (week - 1) * 7 + time - 1, startday)
                    Dim course As String = ""
                    If week >= YJ(0) And week <= YJ(1) Then course = "硬件部分（节假日）"
                    If week >= RJ(0) And week <= RJ(1) Then course = "软件部分（节假日）"
                    Me.ToolTip1.SetToolTip(sender, "第" & week & "周 " & GetDay(time) & vbCrLf & d & vbCrLf & course & vbCrLf)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub '鼠标悬浮在标签上显示课程信息

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quit.Click
        Me.Close()
    End Sub

    
End Class