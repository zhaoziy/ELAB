Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Login

    Public form1, form2 As Boolean    '邮箱和手机格式判断

#Region "窗体操作"

#Region "拖动窗体"
    Dim MousePos As Point           '记录鼠标指针落下时的坐标(相对窗体)
    Dim bMouseDown As Boolean       '记录鼠标按键是否按下
    '处理窗体MouseDown事件，取得“落下时的位置”
    Private Sub Main_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.MousePos.X = e.X
            Me.MousePos.Y = e.Y
            Me.bMouseDown = True  '设置鼠标状态变量
        End If
        Me.Opacity = 0.7
    End Sub
    Private Sub Main_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        If Me.bMouseDown Then
            Dim MyPos As Point = Control.MousePosition  '取得当前窗体上的鼠标，在屏幕坐标系统下的坐标
            MyPos.Offset(-Me.MousePos.X, -Me.MousePos.Y)  '计算，窗体左上角，应以当前鼠标屏幕位置，向回的“偏移量”，是鼠标落下时鼠标位置，相对于当时窗体的坐标值
            Me.Location = MyPos  '设置窗口的“新位置”
        End If
    End Sub
    Private Sub Main_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Cursor = Cursors.Default
            Me.bMouseDown = False  '清置鼠标变量
        End If
        Me.Opacity = 1
    End Sub
#End Region

#Region "登录窗口界面变化"

    Public Sub membertf()
        With Me
            .Label3.Visible = False
            .Label6.Visible = False
            .Label7.Visible = False
            .Label10.Visible = False
            .Label11.Visible = False
            .Label12.Visible = False
            .txtpwdqr.Visible = False
            .txtphone.Visible = False
            .txtmail.Visible = False
            .PictureBox1.Visible = False
            .PictureBox2.Visible = False

            Dim changeposition As Integer
            For changeposition = 10 To 60 Step 10
                .txtnum.Location = New Point(142, 35 + changeposition)
                .txtpwd.Location = New Point(142, 75 + changeposition)
                .Label1.Location = New Point(32, 35 + changeposition)
                .Label2.Location = New Point(32, 75 + changeposition)
                .Label8.Location = New Point(23, 40 + changeposition)
                .Label9.Location = New Point(23, 80 + changeposition)
                .Groupinfo.Refresh()
                Threading.Thread.Sleep(2)
            Next
        End With
    End Sub

    Public Sub remembertf()
        With Me
            Dim changeposition As Integer
            For changeposition = 10 To 60 Step 10
                .txtnum.Location = New Point(142, 95 - changeposition)
                .txtpwd.Location = New Point(142, 135 - changeposition)
                .Label1.Location = New Point(32, 95 - changeposition)
                .Label2.Location = New Point(32, 135 - changeposition)
                .Label8.Location = New Point(23, 100 - changeposition)
                .Label9.Location = New Point(23, 140 - changeposition)

                .Groupinfo.Refresh()
                Threading.Thread.Sleep(2)
            Next

            .Label3.Visible = True
            .Label6.Visible = True
            .Label7.Visible = True
            .Label10.Visible = True
            .Label11.Visible = True
            .Label12.Visible = True
            .txtpwdqr.Visible = True
            .txtphone.Visible = True
            .txtmail.Visible = True
            .PictureBox1.Visible = True
            .PictureBox2.Visible = True
            .Label13.Visible = True
            .txtname.ResetText()
            .txtdepart.ResetText()
            .txtpwd.Text = ""
        End With
    End Sub

    Public Sub classtf()
        With Me
            .Label3.Visible = False
            .Label6.Visible = True
            .Label7.Visible = True
            .Label10.Visible = False
            .Label11.Visible = True
            .Label12.Visible = True
            .txtpwdqr.Visible = False
            .txtphone.Visible = True
            .txtmail.Visible = True
            .txtmail.ReadOnly = True
            .txtphone.ReadOnly = True
            .PictureBox1.Visible = False
            .PictureBox2.Visible = False

            Dim changeposition As Integer
            For changeposition = 0 To 21 Step 3
                .txtnum.Location = New Point(142, 35 + changeposition)
                .txtpwd.Location = New Point(142, 75 + changeposition)
                .Label1.Location = New Point(32, 35 + changeposition)
                .Label2.Location = New Point(32, 75 + changeposition)
                .Label8.Location = New Point(23, 40 + changeposition)
                .Label9.Location = New Point(23, 80 + changeposition)

                .txtmail.Location = New Point(142, 155 - changeposition)
                .txtphone.Location = New Point(142, 195 - changeposition)
                .Label6.Location = New Point(32, 155 - changeposition)
                .Label7.Location = New Point(32, 195 - changeposition)
                .Label11.Location = New Point(23, 160 - changeposition)
                .Label12.Location = New Point(23, 200 - changeposition)

                .Groupinfo.Refresh()
                Threading.Thread.Sleep(30)
            Next
        End With
    End Sub

    Public Sub reclasstf()
        With Me
            Dim changeposition As Integer
            For changeposition = 0 To 21 Step 3
                .txtnum.Location = New Point(142, 56 - changeposition)
                .txtpwd.Location = New Point(142, 96 - changeposition)
                .Label1.Location = New Point(32, 56 - changeposition)
                .Label2.Location = New Point(32, 96 - changeposition)
                .Label8.Location = New Point(23, 61 - changeposition)
                .Label9.Location = New Point(23, 101 - changeposition)

                .txtmail.Location = New Point(142, 134 + changeposition)
                .txtphone.Location = New Point(142, 174 + changeposition)
                .Label6.Location = New Point(32, 134 + changeposition)
                .Label7.Location = New Point(32, 174 + changeposition)
                .Label11.Location = New Point(23, 139 + changeposition)
                .Label12.Location = New Point(23, 179 + changeposition)

                .Groupinfo.Refresh()
                Threading.Thread.Sleep(30)
            Next

            .Label3.Visible = True
            .Label6.Visible = True
            .Label7.Visible = True
            .Label10.Visible = True
            .Label11.Visible = True
            .Label12.Visible = True
            .txtpwdqr.Visible = True
            .txtphone.Visible = True
            .txtmail.Visible = True
            .txtmail.ReadOnly = False
            .txtphone.ReadOnly = False
            .Label13.Visible = True
            .txtname.ResetText()
            .txtdepart.ResetText()
            .txtmail.Text = ""
            .txtphone.Text = ""
            .PictureBox1.Visible = False
            .PictureBox2.Visible = False
        End With
    End Sub

#End Region

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim STR As String
        STR = Application.StartupPath
        If STR.Substring(0, 2) = "\\" Then
            MsgBox("请不要在服务器上运行，请安装到本地后再运行。")
            Application.Exit()
            Exit Sub
        End If

        Timer1.Interval = 100
        Timer1.Start()
        init()
        checkip()
        thread_Login = New Thread(New ThreadStart(AddressOf Start))
        thread_Login.Start()

        Label4.Text = "Elab-Zhao　版本号：1." & Version

        txtname.Text = ""
        txtdepart.Text = ""

        Me.Width = 992
        Me.Height = 808
        Me.ActiveControl = Me.txtnum '进入窗口txtnum获得焦点
        Me.BackColor = Color.LightSkyBlue
        Me.TransparencyKey = Me.BackColor

        thread_init()  '启动多线程，用于远程监听

    End Sub

    Private Sub Start()

        CheckVerList()   '检查版本
        noticeread()
        thread_Login.Abort()

    End Sub

    Private Sub Login_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\" & txtname.Text & ".jpg") = True Then
            My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\" & txtname.Text & ".jpg")
        End If

    End Sub

    Private Sub Login_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Qucik_Start()

    End Sub

#End Region

#Region "按钮事件"

#Region "重置按钮"
    Private Sub reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset.Click
        With Me
            If .txtnum.Text = "" And .txtpwd.Text = "" And .txtpwdqr.Text = "" And .txtname.Text = "" And .txtdepart.Text = "" And .txtmail.Text = "" And .txtphone.Text = "" And .PictureUser.ImageLocation = Nothing Then
                Exit Sub
            Else
                .txtnum.Clear()
                .txtpwd.Clear()
                .txtpwdqr.Clear()
                .txtname.ResetText()
                .txtdepart.ResetText()
                .txtmail.Clear()
                .txtphone.Clear()
                .PictureUser.Image = ElabManagement.My.Resources.Resources.person

                txtpwdqr.Visible = True
                txtphone.Visible = True
                txtmail.Visible = True
                Label1.Visible = True
                Label2.Visible = True
                Label3.Visible = True
                Label6.Visible = True
                Label7.Visible = True
                Label8.Visible = True
                Label9.Visible = True
                Label10.Visible = True
                Label11.Visible = True
                Label12.Visible = True
                PictureBox1.Visible = False
                PictureBox2.Visible = False
                Label13.Visible = True

                txtnum.Location = New Point(142, 30)
                txtpwd.Location = New Point(142, 70)
                txtpwdqr.Location = New Point(142, 110)
                txtmail.Location = New Point(142, 150)
                txtphone.Location = New Point(142, 190)

                Label1.Location = New Point(32, 35)
                Label2.Location = New Point(32, 75)
                Label3.Location = New Point(32, 115)
                Label6.Location = New Point(32, 155)
                Label7.Location = New Point(32, 195)
                Label8.Location = New Point(23, 40)
                Label9.Location = New Point(23, 80)
                Label10.Location = New Point(23, 120)
                Label11.Location = New Point(23, 160)
                Label12.Location = New Point(23, 200)

                Me.ActiveControl = Me.txtnum '进入窗口txtnum获得焦点
            End If
        End With
    End Sub
#End Region

#Region "进入按钮"

    Private Sub LoginEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginEnter.Click
        Dim enter As Boolean = False
        Dim pwdjm As String

        If Trim(txtnum.Text) & Trim(txtpwd.Text) = String.Empty Then '判断学号和密码是否未填
            MessageBox.Show("信息填写不完整", "提示")
        ElseIf Trim(txtnum.Text) = String.Empty Then
            MessageBox.Show("信息填写不完整", "提示")
        ElseIf Trim(txtpwd.Text) = String.Empty Then
            MessageBox.Show("信息填写不完整", "提示")
        ElseIf txtnum.TextLength <> 9 Then
            MessageBox.Show("信息填写不完整", "提示")   '判断学号和密码是否未填
        Else
            
            Dim a As Boolean = False
            Dim b As Boolean = False
            Dim str1 As String

            Try

                str1 = "select * from member where 学号='" & Trim(txtnum.Text) & "'"
                sql(str1, True)
                If myreader.Read Then
                    a = True   '属于member
                End If
                conn.Close()

                str1 = "select * from " & "[" & schoolcalendar & "计算机安装与调试技术]" & " where 学号='" & Trim(txtnum.Text) & "'"
                sqlnoerr(str1, False)
                If myreader.Read Then
                    b = True   '属于class
                End If
                conn.Close()

            Catch ex As Exception
                MsgBox("读取【" & schoolcalendar & "计算机安装与调试技术】出错，请先导入上课名单")
            End Try

            If a = True And b = True Then     '都属于的话，判断时间进入不同功能（助教同学同时选了微机安装与调试）
                Dim weeks As Integer
                getweek()
                init()
                weeks = DateDiff(DateInterval.DayOfYear, startday, GetServerTime().Date) \ 7 + 1
                If weeks < YJ(0) Then
                    pwdjm = MD5(txtpwd.Text, 32)
                    strSql = "Select * From [member] Where 学号='" & txtnum.Text & "' And 密码 = '" & pwdjm & "'"
                    sql(strSql, True)
                    If myreader.Read = True Then  '判断一条记录为真
                        authority = 1
                        usernum = txtnum.Text
                        username = myreader.Item("姓名")
                        logwrite("login", usernum, "助教同学选课")
                        MainForm.Show() '显示下个窗体
                        PictureUser.Image = ElabManagement.My.Resources.Resources.person
                        conn.Close()
                        Me.Close()
                        Me.Dispose()
                    End If
                    conn.Close()
                    Exit Sub
                Else
                    strSql = "member"
                End If
            End If

            enter = InStr(strSql, "member")  '判断所填学号是属于哪个表的
            pwdjm = MD5(txtpwd.Text, 32)
            If enter = True Then   '属于member表

                strSql = "Select * From [member] Where 学号='" & txtnum.Text & "' And 密码 = '" & pwdjm & "'"
                sql(strSql, True)
                If myreader.Read = True Then  '判断一条记录为真
                    Dim change As String
                    If IsDBNull(myreader.Item("职务")) Then
                        change = ""
                    Else
                        change = myreader.Item("职务")
                    End If
                    If change <> "班委" Then
                        authority = 0
                        usernum = txtnum.Text
                        username = myreader.Item("姓名")
                        logwrite("login", usernum, "科中成员登录")
                        MainForm.Show() '显示下个窗体
                        PictureUser.Image = ElabManagement.My.Resources.Resources.person
                        conn.Close()   '**********添加***********
                        Me.Close()
                        Me.Dispose()
                    Else
                        authority = 8
                        usernum = txtnum.Text
                        username = myreader.Item("姓名")
                        logwrite("login", usernum, "班委登录")
                        MainForm.Show()
                        PictureUser.Image = ElabManagement.My.Resources.Resources.person
                        conn.Close()   '**********添加***********
                        Me.Close()
                        Me.Dispose()
                    End If
                Else
                    MessageBox.Show("输入信息有误！", "提示")
                    usernum = txtnum.Text
                    logwrite("login", usernum, "密码错误")
                    txtpwd.Text = ""
                    conn.Close()
                End If
            Else '属于class表
                If Trim(txtmail.Text) = String.Empty Then
                    MessageBox.Show("信息填写不完整", "提示")
                    Exit Sub
                ElseIf Trim(txtphone.Text) = String.Empty Then
                    MessageBox.Show("信息填写不完整", "提示")
                    Exit Sub
                Else
                    Dim tablename As String = "[" & schoolcalendar & "计算机安装与调试技术]"
                    Dim tableinfo As New DataTable
                    Dim num As String = Trim(txtnum.Text)

                    Try
                        strSql = "select 学号,密码,姓名 from " & tablename & " where 学号 = " & num
                        tableinfo = gettable(num, strSql, False)
                        Txtinvisible.Text = tableinfo.Rows(0).Item("密码").ToString.Trim   '判断选课同学是否第一次进入系统
                        If Txtinvisible.Text = "" Then        '第一次进入系统，更新各种信息
                            If CloseXuanke = False Then
                                If txtpwd.Text = txtpwdqr.Text Then    '确认密码和密码确认是否相同
                                    If form1 = True And form2 = True Then   '判断电话、邮箱格式是否正确
                                        strSql = "update [" & schoolcalendar & "计算机安装与调试技术] set 密码='" & pwdjm & "' , 邮箱='" & txtmail.Text & "' , 联系电话='" & txtphone.Text & "' where 学号='" & txtnum.Text & "' "
                                        sql(strSql, False)
                                        authority = 1
                                        usernum = txtnum.Text
                                        username = tableinfo.Rows(0).Item("姓名")
                                        logwrite("login", usernum, "第一次登录")
                                        MainForm.Show() '显示下个窗体
                                        conn.Close() '**********添加***********
                                        Me.Close()
                                        Me.Dispose()
                                    Else : MessageBox.Show("邮箱或电话格式不正确！", "提示")
                                    End If
                                Else : MessageBox.Show("两次密码输入不一致", "提示")
                                End If
                            Else
                                MsgBox("选课系统已关闭，只能修改选课信息，不能新加选课信息！")
                                Exit Sub
                            End If

                        Else   '非第一次进入系统，则判断学号和密码是否符合
                            strSql = "Select * From [" & schoolcalendar & "计算机安装与调试技术] Where 学号='" & txtnum.Text & "' And 密码 = '" & pwdjm & "'"
                            sql(strSql, False)
                            If myreader.Read = True Then  '判断一条记录为真
                                authority = 2
                                username = txtnum.Text
                                usernum = txtnum.Text
                                username = tableinfo.Rows(0).Item("姓名")
                                logwrite("login", usernum, "查询或修改选课信息")
                                MainForm.Show() '显示下个窗体
                                conn.Close() '**********添加***********
                                Me.Close()
                                Me.Dispose()
                            Else
                                MessageBox.Show("输入信息有误！", "提示")
                                usernum = txtnum.Text
                                logwrite("login", usernum, "密码错误")
                                txtpwd.Text = ""
                                conn.Close() '**********添加***********
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tableinfo.Dispose()
                End If
            End If
        End If

    End Sub

#End Region

#Region "退出按钮"
    Private Sub quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quit.Click
       
        Application.Exit()  'exit后程序仍在后台为关闭，再次打开程序时会出错，解决方法：把有程序启动的另一进程设为后台进程，thread.Isbackground=true
    End Sub
#End Region

#Region "按钮图案变化"

    Private Sub LoginEnter_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginEnter.MouseEnter
        LoginEnter.Image = ElabManagement.My.Resources.Resources.enterselected
    End Sub

    Private Sub LoginEnter_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginEnter.MouseLeave
        LoginEnter.Image = ElabManagement.My.Resources.Resources.enter
    End Sub

    Private Sub reset_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles reset.MouseEnter
        reset.Image = ElabManagement.My.Resources.Resources.resetselected
    End Sub

    Private Sub reset_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles reset.MouseLeave
        reset.Image = ElabManagement.My.Resources.Resources.reset
    End Sub

#End Region

#End Region

#Region "防止学号、手机输入字母"

    Private Sub txtnum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnum.KeyPress, txtphone.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#End Region

#Region "显示登录用户信息"
    Private Sub txtnum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnum.TextChanged
        Dim tablename As String
        Dim tableinfo As New DataTable
        Dim num As String

        PictureUser.Image = ElabManagement.My.Resources.Resources.person
        If txtnum.TextLength <> 9 Then
            If Label1.Location.Y = 95 Then
                remembertf() '助课同学登录界面反变化，变回原样
            ElseIf Label1.Location.Y = 56 Then
                reclasstf() '上课同学登录界面反变化，变回原样
            End If
            Exit Sub
        Else
            Try
                Label13.Visible = False
                tablename = "[member]"
                num = Trim(txtnum.Text)

                strSql = "select 学号,姓名,院系,电话 from " & tablename & " where 学号 = " & num
                tableinfo = gettable(num, strSql, True)
                If tableinfo.Rows.Count > 0 Then  '显示member表信息
                    txtname.Text = tableinfo.Rows(0).Item("姓名").ToString.Trim
                    txtdepart.Text = tableinfo.Rows(0).Item("院系").ToString.Trim

                    downloadpic()   '******************从网络下载照片******************
                    membertf()   '*************界面变化**************

                Else : tablename = "[" & schoolcalendar & "计算机安装与调试技术]"   '显示class表信息
                    strSql = "select 学号,姓名,院系,邮箱,联系电话,密码 from " & tablename & " where 学号 = " & num
                    tableinfo = gettable(num, strSql, False)

                    If tableinfo.Rows.Count > 0 Then
                        txtnum.Text = Trim(tableinfo.Rows(0).Item("学号").ToString)
                        txtname.Text = Trim(tableinfo.Rows(0).Item("姓名").ToString)
                        txtdepart.Text = Trim(tableinfo.Rows(0).Item("院系").ToString)
                        txtmail.Text = Trim(tableinfo.Rows(0).Item("邮箱").ToString)
                        txtphone.Text = Trim(tableinfo.Rows(0).Item("联系电话").ToString)
                        txtpwdqr.ReadOnly = False
                        txtmail.ReadOnly = False
                        txtphone.ReadOnly = False
                        Txtinvisible.Text = Trim(tableinfo.Rows(0).Item("密码").ToString)  '判断是否第一次进入，控制只读文本框的只读与否
                        If Txtinvisible.Text <> "" Then
                            classtf()  '*************界面变化**************
                        End If
                    End If
                End If
                tableinfo.Dispose()
            Catch ex As Exception
                'MsgBox("错误!", MsgBoxStyle.OkOnly, "警告")
            End Try
        End If
    End Sub
#End Region

#Region "判断邮箱、电话格式"

    Private Sub txtphone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtphone.TextChanged
        Dim substr As String = ""
        If txtphone.TextLength <> 11 Then
            PictureBox2.Visible = True
            PictureBox2.Image = ElabManagement.My.Resources.Resources.wrong
            form2 = False
            Exit Sub
        End If
        '修改理由：电话号码更新换代，就不判断其开头了
        'substr = txtphone.Text.Substring(0, 3)
        'If substr = "134" Or substr = "135" Or substr = "136" Or substr = "137" Or substr = "138" Or substr = "139" _
        'Or substr = "147" Or substr = "150" Or substr = "151" Or substr = "152" Or substr = "157" Or substr = "158" _
        'Or substr = "159" Or substr = "182" Or substr = "183" Or substr = "184" Or substr = "187" Or substr = "188" _
        'Or substr = "130" Or substr = "131" Or substr = "132" Or substr = "133" Or substr = "145" Or substr = "155" _
        'Or substr = "156" Or substr = "185" Or substr = "186" Or substr = "134" Or substr = "152" Or substr = "180" _
        'Or substr = "181" Or substr = "189" Or substr = "140" Or substr = "141" Or substr = "142" Or substr = "143" _
        'Or substr = "144" Or substr = "146" Or substr = "148" Or substr = "149" Or substr = "154" Or substr = "153" Then
        PictureBox2.Image = ElabManagement.My.Resources.Resources.right
        form2 = True
        'End If

    End Sub

    Private Sub txtmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmail.TextChanged
        Dim FoundMatch As Boolean
        PictureBox1.Visible = True
        PictureBox1.Image = ElabManagement.My.Resources.Resources.wrong
        form1 = False
        Try
            FoundMatch = Regex.IsMatch(txtmail.Text, "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
            If FoundMatch = True Then
                PictureBox1.Image = ElabManagement.My.Resources.Resources.right
                form1 = True
            End If
        Catch ex As ArgumentException
            'MsgBox("邮箱格式不符，请重新输入。")
        End Try
    End Sub

#End Region

#Region "签到软件调用事件"

    Private Sub Qucik_Start()
        Dim strselect As String
        Dim myArg As String = Microsoft.VisualBasic.Command
        myArg = Trim(myArg)
        If myArg <> "" Then
            Me.Opacity = 0
            strselect = "select * from [member] where 学号='" & myArg & "'"
            Try
                sql(strselect, True)
                If myreader.Read Then
                    username = myreader.Item("姓名")
                    usernum = myArg
                    If myreader.Item("职务").ToString = "班委" Then
                        authority = 8
                        logwrite("login", usernum, "班委登录")
                        MainForm.Show()
                        Me.Close()
                        Me.Dispose()
                    Else
                        authority = 0
                        logwrite("login", usernum, "科中成员登录")
                        MainForm.Show()
                        Me.Close()
                        Me.Dispose()
                    End If
                Else
                    Me.Opacity = 1
                End If
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
                conn.Close()
                conn.Dispose()
            End Try
        End If
    End Sub

#End Region

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Finish_Update = False Then
            LoginEnter.Visible = False
            Label5.Visible = True
            Label5.Text = "正在检查更新，请稍后"
        Else
            LoginEnter.Visible = True
            Label5.Visible = False
            Label5.Text = ""
            Timer1.Stop()
        End If
    End Sub

End Class