Imports Microsoft.Win32
Public Class Main

    Public IsFirstRun As Boolean             '�˳����Ƿ��һ���ڱ���������
    Public IsBackTip As Boolean             '�Ƿ��̨��ʾ

    Public NowTime As Date         '��ǰʱ�䣬��Ҫʱʱ���£����Բ�����ʼֵ

    Public IsSignIn As Boolean = False            '�Ƿ���ǩ��

    '�ҵ�ֵ����Ϣ
    Public DutyTimeStatus As String = String.Empty        'ֵ��ʱ��
    Public IsOnDuty As Boolean = False                    '���Ƿ�����ֵ��
    Public IsDuty As Boolean = True                     '�����ǲ�����ֵ��
    Public IsSignOut As Boolean = False

#Region "�����¼�"

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.ApplicationExitCall Then      '�˳�����
            If Me.IsSignIn Then
                If IsOnDuty Then                    '���ֵ����ǩ��,����ʧ�ܲ����ش�����Ϣ������������ǩ�˵�ʱ�򷵻�
                    If MsgBox("ϵͳ��⵽�㻹��ֵ�࣬�Ƿ���Ȼ�˳����򣿣��˳���Ӱ����¼��ֵ����Ϣ�����޷���¼ǩ����Ϣ��", MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, SoftName) = MsgBoxResult.Ok Then
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                EndDate = ServerTime()
                If EndDate.Year = 1991 OrElse Not sql("update ʱ��ͳ�� set �뿪='" & EndDate.ToString("T") & "',�ϼ�ʱ��='" & TimeDiff(StartDate, EndDate) & "' where ID=" & Sign_Identity) Then
                    If MsgBox("�޷�����ǩ�ˣ��������������ӹ��ϡ�" & vbCrLf _
                             & "��� ȷ�� ��ǿ���˳����˴�ǩ����¼���ϡ�" & vbCrLf _
                             & "��� ȡ�� �������˳������޸��������Ӻ��ٳ����˳���", _
                             MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, SoftName) = MsgBoxResult.Ok Then
                        'ǿ��ǩ��
                    Else
                        e.Cancel = True
                    End If
                End If
                sql_rele(conn, cmd)
            End If
        ElseIf e.CloseReason = CloseReason.UserClosing Then            '���ش���
            e.Cancel = True
            Me.ShowOrHide(False)
            If Me.IsFirstRun AndAlso Me.IsBackTip Then          '��һ�ε����ʾ��̨����
                With Me.NotifyIcon
                    .Visible = True
                    .BalloonTipIcon = ToolTipIcon.Info
                    .BalloonTipTitle = UserName
                    .BalloonTipText = "���ں�̨������~~�ٺ�"
                    .ShowBalloonTip(30)
                End With
                Me.IsBackTip = False
            End If
        Else                         '�ػ��Զ�ǩ�ˣ����ǩ��ʧ�ܲ���ʾ         ����e.CloseReason = CloseReason.WindowsShutDown
            If Me.IsSignIn Then
                EndDate = ServerTime()
                sql("update ʱ��ͳ�� set �뿪='" & EndDate.ToString("T") & "',�ϼ�ʱ��='" & TimeDiff(StartDate, EndDate) & "' where ID=" & Sign_Identity)
                sql_rele(conn, cmd)
            End If
        End If

        thread_end()  '�������̣߳���������

    End Sub

    Private Sub Main_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        Me.Opacity = 0
        Me.TextBMotto.Focus()
        Me.Label1.Text = "�汾�ţ�" & Version
        thread_init()  '�������̣߳�����Զ�̼���

        Dim STR1 As String
        STR1 = Application.StartupPath
        If STR1.Substring(0, 2) = "\\" Then
            MsgBox("�벻Ҫ�ڷ����������У��밲װ�����غ������С�")
            Application.Exit()
            Exit Sub
        End If

        '�������Ƿ��Ѿ�������
        If Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1 Then
            MsgBox("��⵽�����������У�", MsgBoxStyle.Critical, SoftName)
            Application.Exit()
            Exit Sub
        End If

        '�������
        If Not My.Computer.Network.IsAvailable Then
            MsgBox("���Բ���������������������", MsgBoxStyle.Critical, SoftName)
            Application.Exit()
            Exit Sub
        End If

        init()
        checkip()                       '��ȡLocalIP

        CheckVerList()
        NowTime = ServerTime()

        If disable = True Then
            MsgBox("�ð汾�����Σ��������°汾��")
            Application.Exit()
            Exit Sub
        End If

        '���������ע���ͳһ
        Dim reg As RegistryKey = My.Computer.Registry.CurrentUser
        reg = reg.CreateSubKey("Software\ELAB\" & SoftName)
        If CInt(reg.GetValue("Version")) = Version AndAlso reg.GetValue("Run") = True Then
            Me.IsFirstRun = False
            Me.IsBackTip = False
        Else                           '��һ������
            Me.IsFirstRun = True
            Me.IsBackTip = True
            reg.SetValue("Version", Version)
            reg.SetValue("Run", True)
        End If
        reg.Close()

        '����Ƿ񿪻�����
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", SoftName, Nothing) Is Nothing Then
            Me.��������ToolStripMenuItem.Checked = False
        Else
            Me.��������ToolStripMenuItem.Checked = True
        End If

        NowWeek = GetWeek()                   '��ȡ�ܴ�

        '��ȡ������Ϣ���û�����ѧ�ţ�����ֻ��ţ�������
        If Not GetInfo() OrElse NowWeek < 0 Then
            MsgBox("����δ֪���󣡳����˳���", MsgBoxStyle.Critical, SoftName)
            Application.Exit() : Exit Sub
        End If

        StartDate = ServerTime()

        '����ϴ��Ƿ������˳�(���췶Χ��)��������ǣ����ϴ�δǩ�˵ļ�¼��0Сʱ�˵��������뿪�ֶ�=�����ֶ�(��Ϊ���ܿ���ϵͳ�����뿪�ֶ�=0��ȡ�����û���)
        If sql("update ʱ��ͳ�� set �뿪=���� where �뿪='0' and ����='" & StartDate.Year & "-" & StartDate.Month & "-" & StartDate.Day & "' and ѧ��='" & StuNum & "'") Then
        Else
            MsgBox("�����������󣡳���ǿ���˳���", MsgBoxStyle.Exclamation, SoftName)
            IsSignIn = False
            Application.Exit()
            Exit Sub
        End If
        sql_rele(conn, cmd)

        'ǩ��
        If StartDate.Year <> 1991 Then
            Dim str As String = String.Empty
            str = "insert into ʱ��ͳ��(ѧ��,����,���,����,�ܴ�,����,�뿪,�ϼ�ʱ��,ѧ��) values ('" _
            & StuNum & "','" & UserName & "','" & Team & "','" & StartDate.Year & "-" & StartDate.Month _
            & "-" & StartDate.Day & "','" & NowWeek & "','" & StartDate.ToString("T") & "','" & "0" & "','" & "0" & "','" & schoolcalendar & "')" _
            & vbCrLf & "select scope_identity() as id"
            Try
                sql(str)
                If myreader.Read = True Then            '��ȡIdentity
                    Sign_Identity = myreader.Item("id").ToString
                    Me.IsSignIn = True
                End If
                sql_rele(conn, cmd)
            Catch ex As Exception
                MsgBox("����δ֪���󣡳����˳���", MsgBoxStyle.Critical, SoftName)
                Application.Exit() : Exit Sub
            End Try
        End If

        Me.UpdataInfo()

        '��һ�����У���ʾ������Ϣ
        If IsFirstRun Then
            Me.�汾����ToolStripMenuItem.PerformClick()
        End If

        With Me.NotifyIcon
            .Visible = True
            .BalloonTipIcon = ToolTipIcon.Info
            .BalloonTipTitle = TimeStat(StartDate) & "�ã� " & Team & " " & UserName
            If HappyMotto = "" Then              'BalloonTip��������ʾΪ��
                .BalloonTipText = "��ǩ����"
            Else
                .BalloonTipText = HappyMotto
            End If
            If IsFirstRun Then
                .BalloonTipText &= vbCrLf & "�����ʾ�ò���������֣�����������鳤���ģ�"
            End If

            .ShowBalloonTip(30)          '��ʾС����
        End With

        '��ʱ��
        'info_notify()
        Timer.Interval = 1000
        Timer.Start()
    End Sub

    'Esc�����ش���
    Private Sub Main_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.ShowOrHide(False)
        End If
    End Sub

    '��ʾ/���� ����
    Sub ShowOrHide(ByVal isshow As Boolean)
        Me.��ϸ��ϢToolStripMenuItem.Checked = isshow
        If isshow Then
            NowTime = ServerTime()
            If NowTime.Year = 1991 Then
                '���1991���ʾ��ȡ������ʱ�����
                Me.ToolStripStatusLabel2.Text = "��ȡʧ��"
            Else
                Me.ToolStripStatusLabel2.Text = NowTime.ToShortDateString & " " & NowTime.ToLongTimeString
                NowTime = NowTime.AddSeconds(1)
            End If
            'info_notify()
        End If
        Me.Visible = isshow
    End Sub

    '�����������ڽ���
    Private Sub Main_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Hide()
        Me.Opacity = 1
        Me.��ϸ��ϢToolStripMenuItem.Checked = False
    End Sub

#End Region

#Region "���½��¼�"

    '˫�����½�
    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.ShowOrHide(Not Me.Visible)
    End Sub

    Private Sub ��ϸ��ϢToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��ϸ��ϢToolStripMenuItem.Click
        Me.ShowOrHide(Not Me.Visible)
    End Sub

    'ע���ʵ��
    Private Sub ��������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��������ToolStripMenuItem.Click
        Me.��������ToolStripMenuItem.Checked = Not Me.��������ToolStripMenuItem.Checked
        If Me.��������ToolStripMenuItem.Checked Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", SoftName, """" & Application.StartupPath & "\" & SoftName & ".exe" & """")
        Else
            My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(SoftName, False)
        End If
    End Sub

    Private Sub �汾����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �汾����ToolStripMenuItem.Click
        MsgBox("����ϵͳ���ݿ�ṹ����" & vbCrLf & vbCrLf _
             & "ע�⣺�ɰ汾��ͣ�ã������´ӹ��������أ�", , "�°湦��")
    End Sub

    Private Sub ʹ����֪ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ʹ����֪ToolStripMenuItem.Click
        MsgBox("1.�������к�ͻ��Զ�ǩ����������������ӿ�������" & vbCrLf & vbCrLf _
             & "2.���ͻ���֧��ǩ����ֵ�࣬���๦�����""���й���ϵͳ""" & vbCrLf & vbCrLf _
             & "3.ֵ����Ϣ������ʱ��Ϊ12:30-17:30������ʱ��Ϊ17:30-22:00�������Сʱ�ĳٵ����ˡ����Ұ�ʱֵ��" & vbCrLf & vbCrLf _
             & "����                                                              by Vigi, Zhao", , "ʹ����֪")
    End Sub

    Private Sub �˳�����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �˳�����ToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ���й���ϵͳToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���й���ϵͳToolStripMenuItem.Click
        Call ElabManagement()
    End Sub

#End Region

#Region "������Ϣ���Ƽ���ť�¼�"

    '���ֻ����ı����Լ��
    Private Sub TextB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBPhone.TextChanged, TextBMotto.TextChanged
        Me.ButChange.Enabled = True
        Me.ButChange.Text = "Ӧ������"
    End Sub

    '������ϸ��Ϣ
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

    'Ӧ�����ã������ֻ��������������
    Private Sub ButChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButChange.Click
        Dim i As Short : Dim islegal As Boolean = True   '��ʶ����ı��Ƿ�Ϸ�
        For i = 1 To Me.TextBPhone.Text.Length
            If Not Char.IsNumber(Me.TextBPhone.Text, i - 1) Then
                islegal = False
            End If
        Next
        If islegal Then
            Me.TextBPhone.Text = StrConv(Me.TextBPhone.Text, VbStrConv.Narrow)
            Me.ButChange.Enabled = False
            Me.ButChange.Text = "�Ժ�...."
            If Not sql("update [member] set [�绰]='" & Me.TextBPhone.Text.Trim & "',[������]='" & Me.TextBMotto.Text.Trim & "' where [ѧ��]='" & StuNum & "'") Then
                MsgBox("����ʧ�ܣ�������������", MsgBoxStyle.Critical, SoftName)
                Me.ButChange.Enabled = True
                Me.ButChange.Text = "Ӧ������"
                Me.ButChange.Focus()
            Else
                Phone = Me.TextBPhone.Text.Trim
                HappyMotto = Me.TextBMotto.Text.Trim
                Me.ButChange.Text = "���óɹ�"
                Me.TextBMotto.Focus()
            End If
            sql_rele(conn, cmd)
        Else
            Me.ErrorProvider.SetError(Me.TextBPhone, "ֻ����ʹ�����֣�")
            Me.TextBPhone.Focus()
        End If
    End Sub

    '��Ҫ��ֵ��
    Private Sub ButDuty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDuty.Click
        If MsgBox("���ڲ�����ֵ�࣬��ȷ��Ҫ��ֵ��ô��", MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, SoftName) = MsgBoxResult.Ok Then
            Relay_Duty()
        End If
    End Sub

    'ֵ��ǩ��
    Private Sub Sign_In_Duty()
        Dim str As String
        Dim Status As String = String.Empty  'ֵ��ǩ��״̬
        Dim Status_1 As String = String.Empty

        If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 12, 15, 0) Then
            Status_1 = "����"
        ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 12, 15, 0) AndAlso NowTime < New Date(NowTime.Year, NowTime.Month, NowTime.Day, 17, 15, 0) Then
            Status_1 = "����"
        ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 17, 15, 0) Then
            Status_1 = "����"
        End If

        'MyDutyTimeStatus = DutyTimeStatus
        If DutyTimeStatus <> Status_1 Then
            DutyTimeStatus = Status_1
        ElseIf IsOnDuty = True Then
            Exit Sub
        ElseIf IsSignOut = True Then
            Exit Sub
        End If

        str = "select * from [sduty] where ����ʱ��='0' and ʱ��='" & DutyTimeStatus & "' and ����='" & NowTime.ToShortDateString & "'"
        sql(str)
        If myreader.Read Then
            If myreader.Item("�Ƿ����").ToString = "True" Then
                If myreader.Item("�����ѧ��").ToString = StuNum Then
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

        str = "select * from [duty] where ʱ��='" & DutyTimeStatus & "' and ��˫��='" & ��˫��() & "' and ����=datepart(weekday,getdate())-1"  '������Ϊ��һ�죬-1��Ϊ0
        Try

            sql(str)
            If myreader.Read = True Then           '�жϵ�ǰʱ����˭ֵ��
                If myreader.Item("ѧ��").ToString = StuNum Then    '�ж��Ƿ��Ǹ���ֵ��

                    IsDuty = True
                    str = "select * from [sduty] where ʱ��='" & DutyTimeStatus & "' and ����='" & NowTime.ToShortDateString & "'"
                    Try
                        sql_1(str)                         '�ж��Ƿ�����ֵ��
                        If myreader_1.Read = True Then
                            If myreader_1.Item("����ʱ��") = "0" Then
                                IsOnDuty = True
                                IsSignOut = False
                            Else
                                IsOnDuty = False
                                IsSignOut = True
                            End If
                        Else
                            If DutyTimeStatus = "����" Then
                                If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 8, 15, 0) Then
                                    Status = "ֵ������δǩ��"
                                ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 8, 15, 0) Then
                                    Status = "�ٵ�δǩ��"
                                End If
                            ElseIf DutyTimeStatus = "����" Then
                                If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 13, 15, 0) Then
                                    Status = "ֵ������δǩ��"
                                ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 13, 15, 0) Then
                                    Status = "�ٵ�δǩ��"
                                End If
                            ElseIf DutyTimeStatus = "����" Then
                                If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 18, 15, 0) Then
                                    Status = "ֵ������δǩ��"
                                ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 18, 15, 0) Then
                                    Status = "�ٵ�δǩ��"
                                End If
                            End If

                            str = "insert into sduty(ѧ��,����,��¼ʱ��,����ʱ��,����,��,��,ʱ��,�Ƿ����,�����ѧ��,���������,�ٵ�����,��ע,ѧ��) values('" & _
                               StuNum & "','" & myreader.Item("����") & "','" & NowTime.ToLongTimeString & "','0','" & NowTime.ToShortDateString & "','" & NowWeek & _
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

    'ֵ��ǩ��
    Private Sub Sign_Out_Duty()
        Dim str As String
        Dim Status As String = String.Empty  'ֵ��ǩ��״̬
        If IsSignOut = False Then
            If IsOnDuty = True Then
                If DutyTimeStatus = "����" Then
                    If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 11, 45, 0) Then
                        str = "select * from [sduty] where ����='" & NowTime.ToShortDateString & "' and ʱ��='" & DutyTimeStatus & "'"
                        sql_1(str)
                        If myreader_1.Read Then
                            If myreader_1.Item("�Ƿ����") = True Then
                                str = "select * from [sduty] where �����ѧ��='" & StuNum & "' and ����='" & _
                       NowTime.ToShortDateString & "' and ��='" & NowWeek & "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("�ٵ�����") = "�ٵ�δǩ��" Then
                                        Status = "�ٵ���ǩ��"
                                    ElseIf myreader.Item("�ٵ�����") = "ֵ������δǩ��" Then
                                        Status = "ֵ������"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set ����ʱ��='" & NowTime.ToLongTimeString & "',�ٵ�����='" & Status.ToString & _
                               "' where �����ѧ��='" & StuNum & "' and ����='" & NowTime.ToShortDateString & "' and ��='" & NowWeek & _
                               "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            Else
                                str = "select * from [sduty] where ѧ��='" & StuNum & "' and ����='" & _
                       NowTime.ToShortDateString & "' and ��='" & NowWeek & "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("�ٵ�����") = "�ٵ�δǩ��" Then
                                        Status = "�ٵ���ǩ��"
                                    ElseIf myreader.Item("�ٵ�����") = "ֵ������δǩ��" Then
                                        Status = "ֵ������"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set ����ʱ��='" & NowTime.ToLongTimeString & "',�ٵ�����='" & Status.ToString & _
                                "' where ѧ��='" & StuNum & "' and ����='" & NowTime.ToShortDateString & "' and ��='" & NowWeek & _
                                "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & DutyTimeStatus & "'"
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
                                .BalloonTipText = "ʱ���ѵ���ϵͳ��ֵ��ǩ�ˣ�"
                                .ShowBalloonTip(30)
                            End With
                        End If
                    End If
                End If

                If DutyTimeStatus = "����" Then
                    'If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 16, 45, 0) Then
                    If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 16, 45, 0) Then
                        str = "select * from [sduty] where ����='" & NowTime.ToShortDateString & "' and ʱ��='" & DutyTimeStatus & "'"
                        sql_1(str)
                        If myreader_1.Read Then
                            If myreader_1.Item("�Ƿ����") = True Then
                                str = "select * from [sduty] where �����ѧ��='" & StuNum & "' and ����='" & _
                       NowTime.ToShortDateString & "' and ��='" & NowWeek & "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("�ٵ�����") = "�ٵ�δǩ��" Then
                                        Status = "�ٵ���ǩ��"
                                    ElseIf myreader.Item("�ٵ�����") = "ֵ������δǩ��" Then
                                        Status = "ֵ������"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set ����ʱ��='" & NowTime.ToLongTimeString & "',�ٵ�����='" & Status.ToString & _
                               "' where �����ѧ��='" & StuNum & "' and ����='" & NowTime.ToShortDateString & "' and ��='" & NowWeek & _
                               "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            Else
                                str = "select * from [sduty] where ѧ��='" & StuNum & "' and ����='" & _
                       NowTime.ToShortDateString & "' and ��='" & NowWeek & "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("�ٵ�����") = "�ٵ�δǩ��" Then
                                        Status = "�ٵ���ǩ��"
                                    ElseIf myreader.Item("�ٵ�����") = "ֵ������δǩ��" Then
                                        Status = "ֵ������"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set ����ʱ��='" & NowTime.ToLongTimeString & "',�ٵ�����='" & Status.ToString & _
                                "' where ѧ��='" & StuNum & "' and ����='" & NowTime.ToShortDateString & "' and ��='" & NowWeek & _
                                "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & DutyTimeStatus & "'"
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
                                .BalloonTipText = "ʱ���ѵ���ϵͳ��ֵ��ǩ�ˣ�"
                                .ShowBalloonTip(30)
                            End With
                        End If
                    End If
                End If

                If DutyTimeStatus = "����" Then
                    'If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 21, 45, 0) Then
                    If NowTime >= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 21, 45, 0) Then
                        str = "select * from [sduty] where ����='" & NowTime.ToShortDateString & "' and ʱ��='" & DutyTimeStatus & "'"
                        sql_1(str)
                        If myreader_1.Read Then
                            If myreader_1.Item("�Ƿ����") = True Then
                                str = "select * from [sduty] where �����ѧ��='" & StuNum & "' and ����='" & _
                       NowTime.ToShortDateString & "' and ��='" & NowWeek & "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("�ٵ�����") = "�ٵ�δǩ��" Then
                                        Status = "�ٵ���ǩ��"
                                    ElseIf myreader.Item("�ٵ�����") = "ֵ������δǩ��" Then
                                        Status = "ֵ������"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set ����ʱ��='" & NowTime.ToLongTimeString & "',�ٵ�����='" & Status.ToString & _
                               "' where �����ѧ��='" & StuNum & "' and ����='" & NowTime.ToShortDateString & "' and ��='" & NowWeek & _
                               "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & DutyTimeStatus & "'"
                                sql(str)
                                sql_rele(conn, cmd)
                                IsOnDuty = False
                                IsSignOut = True
                                ButDuty.Enabled = True
                            Else
                                str = "select * from [sduty] where ѧ��='" & StuNum & "' and ����='" & _
                       NowTime.ToShortDateString & "' and ��='" & NowWeek & "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & _
                       DutyTimeStatus & "'"
                                sql(str)
                                If myreader.Read Then
                                    If myreader.Item("�ٵ�����") = "�ٵ�δǩ��" Then
                                        Status = "�ٵ���ǩ��"
                                    ElseIf myreader.Item("�ٵ�����") = "ֵ������δǩ��" Then
                                        Status = "ֵ������"
                                    End If
                                End If
                                sql_rele(conn, cmd)

                                str = "update [sduty] set ����ʱ��='" & NowTime.ToLongTimeString & "',�ٵ�����='" & Status.ToString & _
                                "' where ѧ��='" & StuNum & "' and ����='" & NowTime.ToShortDateString & "' and ��='" & NowWeek & _
                                "' and ��=DatePart(Weekday, getdate()) - 1 and ʱ��='" & DutyTimeStatus & "'"
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
                                .BalloonTipText = "ʱ���ѵ���ϵͳ��ֵ��ǩ�ˣ�"
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
        Dim Status As String = String.Empty  'ֵ��ǩ��״̬

        str = "select * from [duty] where ʱ��='" & DutyTimeStatus & "' and ��˫��='" & ��˫��() & "' and ����=datepart(weekday,getdate())-1"  '������Ϊ��һ�죬-1��Ϊ0
        Try
            sql(str)
            If myreader.Read = True Then           '�жϵ�ǰʱ����˭ֵ��

                str = "select * from [sduty] where ʱ��='" & DutyTimeStatus & "' and ����='" & NowTime.ToShortDateString & "'"
                Try
                    sql_1(str)                         '�ж��Ƿ�����ֵ��
                    If myreader_1.Read = True Then
                        MsgBox("��������ֵ�࣬�������˰�")
                    Else
                        If DutyTimeStatus = "����" Then
                            If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 8, 15, 0) Then
                                Status = "ֵ������δǩ��"
                            ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 8, 15, 0) Then
                                Status = "�ٵ�δǩ��"
                            End If
                        ElseIf DutyTimeStatus = "����" Then
                            If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 13, 15, 0) Then
                                Status = "ֵ������δǩ��"
                            ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 13, 15, 0) Then
                                Status = "�ٵ�δǩ��"
                            End If
                        ElseIf DutyTimeStatus = "����" Then
                            If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 18, 15, 0) Then
                                Status = "ֵ������δǩ��"
                            ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 18, 15, 0) Then
                                Status = "�ٵ�δǩ��"
                            End If
                        End If

                        str = "insert into sduty(ѧ��,����,��¼ʱ��,����ʱ��,����,��,��,ʱ��,�Ƿ����,�����ѧ��,���������,�ٵ�����,��ע,ѧ��) values('" & _
                              myreader.Item("ѧ��") & "','" & myreader.Item("����") & "','" & NowTime.ToLongTimeString & "','0','" & NowTime.ToShortDateString & _
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
                MsgBox("��ǰʱ��δ����ֵ�ࡣ")
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
            Process.Start(AppPath & "\���й���ϵͳ.exe", StuNum)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        NowTime = ServerTime()
        If NowTime.Year = 1991 Then
            '���1991���ʾ��ȡ������ʱ�����
            MsgBox("����ʧ�ܣ����ȼ����������", MsgBoxStyle.Critical, SoftName)
            Exit Sub
        End If

        '����Ƿ�������У���������ˣ�ֵ����Ϣ���ʼ��
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
                .BalloonTipText = "�»�ʱ�䵽���뾡��ص����뿪���У�"
                .ShowBalloonTip(30)          '��ʾС����
            End With
        End If
    End Sub

End Class