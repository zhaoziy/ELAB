Imports Microsoft.Win32
Public Class Main

    Public IsFirstRun As Boolean             '此程序是否第一次在本机上运行
    Public IsBackTip As Boolean             '是否后台提示

    Public NowTime As Date         '当前时间，需要时时更新，所以不给初始值

    Public IsSignIn As Boolean = False            '是否已签到

    '我的值班信息
    Public DutyTimeStatus As String = String.Empty        '值班时段
    Public IsOnDuty As Boolean = False                    '我是否正在值班
    Public IsDuty As Boolean = True                     '今天是不是我值班
    Public IsSignOut As Boolean = False

#Region "窗体事件"

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.ApplicationExitCall Then      '退出程序
            If Me.IsSignIn Then
                If IsOnDuty Then                    '如果值班则签退,联网失败不返回错误信息，在下面正常签退的时候返回
                    If MsgBox("系统检测到你还在值班，是否仍然退出程序？（退出不影响已录入值班信息，但无法记录签退信息）", MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, SoftName) = MsgBoxResult.Ok Then
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                EndDate = ServerTime()
                If EndDate.Year = 1991 OrElse Not sql("update 时间统计 set 离开='" & EndDate.ToString("T") & "',合计时间='" & TimeDiff(StartDate, EndDate) & "' where ID=" & Sign_Identity) Then
                    If MsgBox("无法正常签退，可能是网络连接故障。" & vbCrLf _
                             & "点击 确定 将强行退出，此次签到记录作废。" & vbCrLf _
                             & "点击 取消 将不会退出，可修复网络连接后再尝试退出。", _
                             MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, SoftName) = MsgBoxResult.Ok Then
                        '强行签退
                    Else
                        e.Cancel = True
                    End If
                End If
                sql_rele(conn, cmd)
            End If
        ElseIf e.CloseReason = CloseReason.UserClosing Then            '隐藏窗口
            e.Cancel = True
            Me.ShowOrHide(False)
            If Me.IsFirstRun AndAlso Me.IsBackTip Then          '第一次点×提示后台运行
                With Me.NotifyIcon
                    .Visible = True
                    .BalloonTipIcon = ToolTipIcon.Info
                    .BalloonTipTitle = UserName
                    .BalloonTipText = "我在后台运行呢~~嘿嘿"
                    .ShowBalloonTip(30)
                End With
                Me.IsBackTip = False
            End If
        Else                         '关机自动签退，如果签退失败不提示         包含e.CloseReason = CloseReason.WindowsShutDown
            If Me.IsSignIn Then
                EndDate = ServerTime()
                sql("update 时间统计 set 离开='" & EndDate.ToString("T") & "',合计时间='" & TimeDiff(StartDate, EndDate) & "' where ID=" & Sign_Identity)
                sql_rele(conn, cmd)
            End If
        End If

        thread_end()  '结束多线程，结束监听

    End Sub

    Private Sub Main_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        Me.Opacity = 0
        Me.TextBMotto.Focus()
        Me.Label1.Text = "版本号：" & Version
        thread_init()  '启动多线程，用于远程监听

        Dim STR1 As String
        STR1 = Application.StartupPath
        If STR1.Substring(0, 2) = "\\" Then
            MsgBox("请不要在服务器上运行，请安装到本地后再运行。")
            Application.Exit()
            Exit Sub
        End If

        '检测程序是否已经在运行
        If Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1 Then
            MsgBox("检测到程序正在运行！", MsgBoxStyle.Critical, SoftName)
            Application.Exit()
            Exit Sub
        End If

        '检测网络
        If Not My.Computer.Network.IsAvailable Then
            MsgBox("电脑不能联网，请检查网络连接", MsgBoxStyle.Critical, SoftName)
            Application.Exit()
            Exit Sub
        End If

        init()
        checkip()                       '获取LocalIP

        CheckVerList()
        NowTime = ServerTime()

        If disable = True Then
            MsgBox("该版本已屏蔽，请升级新版本。")
            Application.Exit()
            Exit Sub
        End If

        '将本程序和注册表统一
        Dim reg As RegistryKey = My.Computer.Registry.CurrentUser
        reg = reg.CreateSubKey("Software\ELAB\" & SoftName)
        If CInt(reg.GetValue("Version")) = Version AndAlso reg.GetValue("Run") = True Then
            Me.IsFirstRun = False
            Me.IsBackTip = False
        Else                           '第一次运行
            Me.IsFirstRun = True
            Me.IsBackTip = True
            reg.SetValue("Version", Version)
            reg.SetValue("Run", True)
        End If
        reg.Close()

        '检测是否开机启动
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", SoftName, Nothing) Is Nothing Then
            Me.开机启动ToolStripMenuItem.Checked = False
        Else
            Me.开机启动ToolStripMenuItem.Checked = True
        End If

        NowWeek = GetWeek()                   '获取周次

        '获取基本信息：用户名，学号，组别，手机号，座右铭
        If Not GetInfo() OrElse NowWeek < 0 Then
            MsgBox("出现未知错误！程序将退出！", MsgBoxStyle.Critical, SoftName)
            Application.Exit() : Exit Sub
        End If

        StartDate = ServerTime()

        '检测上次是否正常退出(今天范围内)，如果不是，将上次未签退的记录以0小时退掉，并将离开字段=登入字段(因为智能考核系统是以离开字段=0获取在线用户的)
        If sql("update 时间统计 set 离开=登入 where 离开='0' and 日期='" & StartDate.Year & "-" & StartDate.Month & "-" & StartDate.Day & "' and 学号='" & StuNum & "'") Then
        Else
            MsgBox("出现致命错误！程序将强制退出！", MsgBoxStyle.Exclamation, SoftName)
            IsSignIn = False
            Application.Exit()
            Exit Sub
        End If
        sql_rele(conn, cmd)

        '签到
        If StartDate.Year <> 1991 Then
            Dim str As String = String.Empty
            str = "insert into 时间统计(学号,姓名,组别,日期,周次,登入,离开,合计时间,学期) values ('" _
            & StuNum & "','" & UserName & "','" & Team & "','" & StartDate.Year & "-" & StartDate.Month _
            & "-" & StartDate.Day & "','" & NowWeek & "','" & StartDate.ToString("T") & "','" & "0" & "','" & "0" & "','" & schoolcalendar & "')" _
            & vbCrLf & "select scope_identity() as id"
            Try
                sql(str)
                If myreader.Read = True Then            '获取Identity
                    Sign_Identity = myreader.Item("id").ToString
                    Me.IsSignIn = True
                End If
                sql_rele(conn, cmd)
            Catch ex As Exception
                MsgBox("出现未知错误！程序将退出！", MsgBoxStyle.Critical, SoftName)
                Application.Exit() : Exit Sub
            End Try
        End If

        Me.UpdataInfo()

        '第一次运行，显示帮助信息
        If IsFirstRun Then
            Me.版本特性ToolStripMenuItem.PerformClick()
        End If

        With Me.NotifyIcon
            .Visible = True
            .BalloonTipIcon = ToolTipIcon.Info
            .BalloonTipTitle = TimeStat(StartDate) & "好！ " & Team & " " & UserName
            If HappyMotto = "" Then              'BalloonTip不允许显示为空
                .BalloonTipText = "已签到！"
            Else
                .BalloonTipText = HappyMotto
            End If
            If IsFirstRun Then
                .BalloonTipText &= vbCrLf & "如果显示得不是你的名字，请找软件组组长更改！"
            End If

            .ShowBalloonTip(30)          '显示小气球
        End With

        '计时器
        'info_notify()
        Timer.Interval = 1000
        Timer.Start()
    End Sub

    'Esc键隐藏窗口
    Private Sub Main_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.ShowOrHide(False)
        End If
    End Sub

    '显示/隐藏 窗口
    Sub ShowOrHide(ByVal isshow As Boolean)
        Me.详细信息ToolStripMenuItem.Checked = isshow
        If isshow Then
            NowTime = ServerTime()
            If NowTime.Year = 1991 Then
                '年份1991年表示获取服务器时间出错
                Me.ToolStripStatusLabel2.Text = "获取失败"
            Else
                Me.ToolStripStatusLabel2.Text = NowTime.ToShortDateString & " " & NowTime.ToLongTimeString
                NowTime = NowTime.AddSeconds(1)
            End If
            'info_notify()
        End If
        Me.Visible = isshow
    End Sub

    '还给其他窗口焦点
    Private Sub Main_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Hide()
        Me.Opacity = 1
        Me.详细信息ToolStripMenuItem.Checked = False
    End Sub

#End Region

#Region "右下角事件"

    '双击右下角
    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.ShowOrHide(Not Me.Visible)
    End Sub

    Private Sub 详细信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 详细信息ToolStripMenuItem.Click
        Me.ShowOrHide(Not Me.Visible)
    End Sub

    '注册表实现
    Private Sub 开机启动ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 开机启动ToolStripMenuItem.Click
        Me.开机启动ToolStripMenuItem.Checked = Not Me.开机启动ToolStripMenuItem.Checked
        If Me.开机启动ToolStripMenuItem.Checked Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", SoftName, """" & Application.StartupPath & "\" & SoftName & ".exe" & """")
        Else
            My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(SoftName, False)
        End If
    End Sub

    Private Sub 版本特性ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 版本特性ToolStripMenuItem.Click
        MsgBox("考核系统数据库结构更新" & vbCrLf & vbCrLf _
             & "注意：旧版本已停用，须重新从共享上下载！", , "新版功能")
    End Sub

    Private Sub 使用须知ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 使用须知ToolStripMenuItem.Click
        MsgBox("1.程序运行后就会自动签到，不过别忘了添加开机启动" & vbCrLf & vbCrLf _
             & "2.本客户端支持签到和值班，更多功能请打开""科中管理系统""" & vbCrLf & vbCrLf _
             & "3.值班信息：下午时段为12:30-17:30，晚上时段为17:30-22:00，允许半小时的迟到早退。请大家按时值班" & vbCrLf & vbCrLf _
             & "以上                                                              by Vigi, Zhao", , "使用须知")
    End Sub

    Private Sub 退出程序ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出程序ToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub 科中管理系统ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 科中管理系统ToolStripMenuItem.Click
        Call ElabManagement()
    End Sub

#End Region

#Region "个人信息控制及按钮事件"

    '对手机号文本框的约束
    Private Sub TextB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBPhone.TextChanged, TextBMotto.TextChanged
        Me.ButChange.Enabled = True
        Me.ButChange.Text = "应用设置"
    End Sub

    '更新详细信息
    Sub UpdataInfo()
        Me.TextBName.Text = UserName
        Me.TextBNum.Text = StuNum
        Me.TextBTeam.Text = Team
        Me.TextBGrade.Text = Grade
        Me.TextBSign.Text = StartDate.ToString("T")
        Me.TextBPhone.Text = Phone
        Me.TextBMotto.Text = HappyMotto
        Me.ButChange.Enabled = False
    End Sub

    '应用设置（保存手机号码和座右铭）
    Private Sub ButChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButChange.Click
        Dim i As Short : Dim islegal As Boolean = True   '标识检测文本是否合法
        For i = 1 To Me.TextBPhone.Text.Length
            If Not Char.IsNumber(Me.TextBPhone.Text, i - 1) Then
                islegal = False
            End If
        Next
        If islegal Then
            Me.TextBPhone.Text = StrConv(Me.TextBPhone.Text, VbStrConv.Narrow)
            Me.ButChange.Enabled = False
            Me.ButChange.Text = "稍后...."
            If Not sql("update [member] set [电话]='" & Me.TextBPhone.Text.Trim & "',[座右铭]='" & Me.TextBMotto.Text.Trim & "' where [学号]='" & StuNum & "'") Then
                MsgBox("更新失败！请检查网络连接", MsgBoxStyle.Critical, SoftName)
                Me.ButChange.Enabled = True
                Me.ButChange.Text = "应用设置"
                Me.ButChange.Focus()
            Else
                Phone = Me.TextBPhone.Text.Trim
                HappyMotto = Me.TextBMotto.Text.Trim
                Me.ButChange.Text = "设置成功"
                Me.TextBMotto.Focus()
            End If
            sql_rele(conn, cmd)
        Else
            Me.ErrorProvider.SetError(Me.TextBPhone, "只允许使用数字！")
            Me.TextBPhone.Focus()
        End If
    End Sub

    '我要替值班
    Private Sub ButDuty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDuty.Click
        If MsgBox("现在不该你值班，你确定要替值班么？", MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, SoftName) = MsgBoxResult.Ok Then
            Relay_Duty()
        End If
    End Sub

    '值班签到
    Private Sub Sign_In_Duty()
        Dim str As String
        Dim Status As String = String.Empty  '值班签到状态
        Dim Status_1 As String = String.Empty

        If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 12, 15, 0) Then
            Status_1 = "上午"
        ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 12, 15, 0) AndAlso NowTime < New Date(NowTime.Year, NowTime.Month, NowTime.Day, 17, 15, 0) Then
            Status_1 = "下午"
        ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 17, 15, 0) Then
            Status_1 = "晚上"
        End If

        'MyDutyTimeStatus = DutyTimeStatus
        If DutyTimeStatus <> Status_1 Then
            DutyTimeStatus = Status_1
        ElseIf IsOnDuty = True Then
            Exit Sub
        ElseIf IsSignOut = True Then
            Exit Sub
        End If

        str = "select * from [sduty] where 登离时间='0' and 时段='" & DutyTimeStatus & "' and 日期='" & NowTime.ToShortDateString & "'"
        sql(str)
        If myreader.Read Then
            If myreader.Item("是否替班").ToString = "True" Then
                If myreader.Item("替班人学号").ToString = StuNum Then
                    IsOnDuty = True
                End If
                ButDuty.Enabled = False
                sql_rele(conn, cmd)
                Exit Sub
            End If
        Else
            ButDuty.Enabled = True
        End If
        sql_rele(conn, cmd)

        str = "select * from [duty] where 时段='" & DutyTimeStatus & "' and 单双周='" & 单双周() & "' and 星期=datepart(weekday,getdate())-1"  '星期日为第一天，-1后为0
        Try

            sql(str)
            If myreader.Read = True Then           '判断当前时间是谁值班
                If myreader.Item("学号").ToString = StuNum Then    '判断是否是该人值班

                    IsDuty = True
                    str = "select * from [sduty] where 时段='" & DutyTimeStatus & "' and 日期='" & NowTime.ToShortDateString & "'"
                    Try
                        sql_1(str)                         '判断是否已在值班
                        If myreader_1.Read = True Then
                            If myreader_1.Item("登离时间") = "0" Then
                                IsOnDuty = True
                                IsSignOut = False
                            Else
                                IsOnDuty = False
                                IsSignOut = True
                            End If
                        Else
                            If DutyTimeStatus = "上午" Then
                                If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 8, 15, 0) Then
                                    Status = "值班正常未签退"
                                ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 8, 15, 0) Then
                                    Status = "迟到未签退"
                                End If
                            ElseIf DutyTimeStatus = "下午" Then
                                If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 13, 15, 0) Then
                                    Status = "值班正常未签退"
                                ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 13, 15, 0) Then
                                    Status = "迟到未签退"
                                End If
                            ElseIf DutyTimeStatus = "晚上" Then
                                If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 18, 15, 0) Then
                                    Status = "值班正常未签退"
                                ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 18, 15, 0) Then
                                    Status = "迟到未签退"
                                End If
                            End If

                            str = "insert into sduty(学号,姓名,登录时间,登离时间,日期,周,天,时段,是否替班,替班人学号,替班人姓名,迟到早退,备注,学期) values('" & _
                               StuNum & "','" & myreader.Item("姓名") & "','" & NowTime.ToLongTimeString & "','0','" & NowTime.ToShortDateString & "','" & NowWeek & _
                               "',DatePart(Weekday, getdate()) - 1,'" & DutyTimeStatus & "',0,NULL,NULL,'" & Status & "',NULL,'" & schoolcalendar & "')"
                            sql_2(str)
                            sql_rele(conn_2, cmd_2)

                            IsOnDuty = True
                            ButDuty.Enabled = False
                        End If
                        sql_rele(conn_1, cmd_1)
                    Catch ex As Exception
                        sql_rele(conn_1, cmd_1)
                        sql_rele(conn_2, cmd_2)
                        IsOnDuty = False
                    End Try
                Else

                    IsDuty = False
                End If
            End If
            sql_rele(conn, cmd)
        Catch ex As Exception
            sql_rele(conn, cmd)
            IsDuty = False
        End Try
    End Sub

    '值班签退
    Private Sub Sign_Out_Duty()
        Dim str As String
        Dim Status As String = String.Empty  '值班签到状态
        If IsSignOut = False Then
            If IsOnDuty = True Then
                If DutyTimeStatus = "上午" Then
                    If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 11, 45, 0) Then
                        str = "select * from [sduty] where 日期='" & NowTime.ToShortDateString & "' and 时段='" & DutyTimeStatus & "'"
                        sql_1(str)
                        If myreader_1.Read Then
                            If myreader_1.Item("是否替班") = True Then
                                str = "select * from [sduty] where 替班人学号='" & StuNum & "' and 日期='" & _
                       NowTime.ToShortDateString & "' and 周='" & NowWeek & "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("迟到早退") = "迟到未签退" Then
                                        Status = "迟到已签退"
                                    ElseIf myreader.Item("迟到早退") = "值班正常未签退" Then
                                        Status = "值班正常"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set 登离时间='" & NowTime.ToLongTimeString & "',迟到早退='" & Status.ToString & _
                               "' where 替班人学号='" & StuNum & "' and 日期='" & NowTime.ToShortDateString & "' and 周='" & NowWeek & _
                               "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            Else
                                str = "select * from [sduty] where 学号='" & StuNum & "' and 日期='" & _
                       NowTime.ToShortDateString & "' and 周='" & NowWeek & "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("迟到早退") = "迟到未签退" Then
                                        Status = "迟到已签退"
                                    ElseIf myreader.Item("迟到早退") = "值班正常未签退" Then
                                        Status = "值班正常"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set 登离时间='" & NowTime.ToLongTimeString & "',迟到早退='" & Status.ToString & _
                                "' where 学号='" & StuNum & "' and 日期='" & NowTime.ToShortDateString & "' and 周='" & NowWeek & _
                                "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            End If
                        End If
                        sql_rele(conn_1, cmd_1)

                        If NowTime.ToLongTimeString = "11:50:00" Then
                            With Me.NotifyIcon
                                .Visible = True
                                .BalloonTipIcon = ToolTipIcon.Info
                                .BalloonTipTitle = UserName
                                .BalloonTipText = "时间已到，系统已值班签退！"
                                .ShowBalloonTip(30)
                            End With
                        End If
                    End If
                End If

                If DutyTimeStatus = "下午" Then
                    'If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 16, 45, 0) Then
                    If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 16, 45, 0) Then
                        str = "select * from [sduty] where 日期='" & NowTime.ToShortDateString & "' and 时段='" & DutyTimeStatus & "'"
                        sql_1(str)
                        If myreader_1.Read Then
                            If myreader_1.Item("是否替班") = True Then
                                str = "select * from [sduty] where 替班人学号='" & StuNum & "' and 日期='" & _
                       NowTime.ToShortDateString & "' and 周='" & NowWeek & "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("迟到早退") = "迟到未签退" Then
                                        Status = "迟到已签退"
                                    ElseIf myreader.Item("迟到早退") = "值班正常未签退" Then
                                        Status = "值班正常"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set 登离时间='" & NowTime.ToLongTimeString & "',迟到早退='" & Status.ToString & _
                               "' where 替班人学号='" & StuNum & "' and 日期='" & NowTime.ToShortDateString & "' and 周='" & NowWeek & _
                               "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            Else
                                str = "select * from [sduty] where 学号='" & StuNum & "' and 日期='" & _
                       NowTime.ToShortDateString & "' and 周='" & NowWeek & "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("迟到早退") = "迟到未签退" Then
                                        Status = "迟到已签退"
                                    ElseIf myreader.Item("迟到早退") = "值班正常未签退" Then
                                        Status = "值班正常"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set 登离时间='" & NowTime.ToLongTimeString & "',迟到早退='" & Status.ToString & _
                                "' where 学号='" & StuNum & "' and 日期='" & NowTime.ToShortDateString & "' and 周='" & NowWeek & _
                                "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            End If
                        End If
                        sql_rele(conn_1, cmd_1)

                        If NowTime.ToLongTimeString = "16:50:00" Then
                            With Me.NotifyIcon
                                .Visible = True
                                .BalloonTipIcon = ToolTipIcon.Info
                                .BalloonTipTitle = UserName
                                .BalloonTipText = "时间已到，系统已值班签退！"
                                .ShowBalloonTip(30)
                            End With
                        End If
                    End If
                End If

                If DutyTimeStatus = "晚上" Then
                    'If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 21, 45, 0) Then
                    If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 21, 45, 0) Then
                        str = "select * from [sduty] where 日期='" & NowTime.ToShortDateString & "' and 时段='" & DutyTimeStatus & "'"
                        sql_1(str)
                        If myreader_1.Read Then
                            If myreader_1.Item("是否替班") = True Then
                                str = "select * from [sduty] where 替班人学号='" & StuNum & "' and 日期='" & _
                       NowTime.ToShortDateString & "' and 周='" & NowWeek & "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("迟到早退") = "迟到未签退" Then
                                        Status = "迟到已签退"
                                    ElseIf myreader.Item("迟到早退") = "值班正常未签退" Then
                                        Status = "值班正常"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set 登离时间='" & NowTime.ToLongTimeString & "',迟到早退='" & Status.ToString & _
                               "' where 替班人学号='" & StuNum & "' and 日期='" & NowTime.ToShortDateString & "' and 周='" & NowWeek & _
                               "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            Else
                                str = "select * from [sduty] where 学号='" & StuNum & "' and 日期='" & _
                       NowTime.ToShortDateString & "' and 周='" & NowWeek & "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("迟到早退") = "迟到未签退" Then
                                        Status = "迟到已签退"
                                    ElseIf myreader.Item("迟到早退") = "值班正常未签退" Then
                                        Status = "值班正常"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set 登离时间='" & NowTime.ToLongTimeString & "',迟到早退='" & Status.ToString & _
                                "' where 学号='" & StuNum & "' and 日期='" & NowTime.ToShortDateString & "' and 周='" & NowWeek & _
                                "' and 天=DatePart(Weekday, getdate()) - 1 and 时段='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            End If
                        End If
                        sql_rele(conn_1, cmd_1)

                        If NowTime.ToLongTimeString = "21:50:00" Then
                            With Me.NotifyIcon
                                .Visible = True
                                .BalloonTipIcon = ToolTipIcon.Info
                                .BalloonTipTitle = UserName
                                .BalloonTipText = "时间已到，系统已值班签退！"
                                .ShowBalloonTip(30)
                            End With
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ElabManagement()
        Me.ShowOrHide(False)
    End Sub

    Private Sub Relay_Duty()
        Dim str As String
        Dim Status As String = String.Empty  '值班签到状态

        str = "select * from [duty] where 时段='" & DutyTimeStatus & "' and 单双周='" & 单双周() & "' and 星期=datepart(weekday,getdate())-1"  '星期日为第一天，-1后为0
        Try
            sql(str)
            If myreader.Read = True Then           '判断当前时间是谁值班

                str = "select * from [sduty] where 时段='" & DutyTimeStatus & "' and 日期='" & NowTime.ToShortDateString & "'"
                Try
                    sql_1(str)                         '判断是否已在值班
                    If myreader_1.Read = True Then
                        MsgBox("已有人在值班，或者已退班")
                    Else
                        If DutyTimeStatus = "上午" Then
                            If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 8, 15, 0) Then
                                Status = "值班正常未签退"
                            ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 8, 15, 0) Then
                                Status = "迟到未签退"
                            End If
                        ElseIf DutyTimeStatus = "下午" Then
                            If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 13, 15, 0) Then
                                Status = "值班正常未签退"
                            ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 13, 15, 0) Then
                                Status = "迟到未签退"
                            End If
                        ElseIf DutyTimeStatus = "晚上" Then
                            If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 18, 15, 0) Then
                                Status = "值班正常未签退"
                            ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 18, 15, 0) Then
                                Status = "迟到未签退"
                            End If
                        End If

                        str = "insert into sduty(学号,姓名,登录时间,登离时间,日期,周,天,时段,是否替班,替班人学号,替班人姓名,迟到早退,备注,学期) values('" & _
                              myreader.Item("学号") & "','" & myreader.Item("姓名") & "','" & NowTime.ToLongTimeString & "','0','" & NowTime.ToShortDateString & _
                              "','" & NowWeek & "',DatePart(Weekday, getdate()) - 1,'" & DutyTimeStatus & "',1,'" & StuNum & "','" & UserName & "','" & Status & "',NULL,'" & _
                              schoolcalendar & "')"
                        sql_2(str)
                        sql_rele(conn_2, cmd_2)

                        IsOnDuty = True
                        ButDuty.Enabled = False
                    End If
                    sql_rele(conn_1, cmd_1)
                Catch ex As Exception
                    sql_rele(conn_1, cmd_1)
                    sql_rele(conn_2, cmd_2)
                    IsOnDuty = False
                End Try
            Else
                MsgBox("当前时段未安排值班。")
            End If
            sql_rele(conn, cmd)
        Catch ex As Exception
            sql_rele(conn, cmd)
        End Try
    End Sub

#End Region

    Private Sub ElabManagement()
        Try
            Dim AppPath As String
            AppPath = Application.StartupPath
            Process.Start(AppPath & "\科中管理系统.exe", StuNum)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        NowTime = ServerTime()
        If NowTime.Year = 1991 Then
            '年份1991年表示获取服务器时间出错
            MsgBox("请求失败！请先检查网络连接", MsgBoxStyle.Critical, SoftName)
            Exit Sub
        End If

        '检测是否跨天运行，如果跨天了，值班信息需初始化
        If NowTime.Year <> 1991 AndAlso NowTime.ToLongTimeString = "0:00:00" Then
            Me.ButDuty.ForeColor = SystemColors.ControlText
            Me.ButDuty.Enabled = True
            Me.IsOnDuty = False
            Me.IsDuty = True
            Me.IsSignOut = False
        End If

        Sign_In_Duty()
        Sign_Out_Duty()

        If NowTime = New Date(NowTime.Year, NowTime.Month, NowTime.Day, 21, 55, 0) Then
            With Me.NotifyIcon
                .Visible = True
                .BalloonTipIcon = ToolTipIcon.Info
                .BalloonTipTitle = UserName
                .BalloonTipText = "下机时间到，请尽快关电脑离开科中！"
                .ShowBalloonTip(30)          '显示小气球
            End With
        End If
    End Sub

End Class