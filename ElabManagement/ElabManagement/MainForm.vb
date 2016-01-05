Imports System.Threading

Public Class MainForm

    Public tabpage3_init As Boolean = False

#Region "拖动窗体"

    Dim MousePos As Point           '记录鼠标指针落下时的坐标(相对窗体)
    Dim bMouseDown As Boolean        '记录鼠标按键是否按下
    '处理窗体MouseDown事件，取得“落下时的位置”

    Public Sub Main_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_Top.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.MousePos.X = e.X
            Me.MousePos.Y = e.Y
            Me.bMouseDown = True  '设置鼠标状态变量
        End If
        Me.Opacity = 1
    End Sub

    Public Sub Main_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_Top.MouseMove

        If Me.bMouseDown Then
            Dim MyPos As Point = Control.MousePosition  '取得当前窗体上的鼠标，在屏幕坐标系统下的坐标
            MyPos.Offset(-Me.MousePos.X, -Me.MousePos.Y)  '计算，窗体左上角，应以当前鼠标屏幕位置，向回的“偏移量”，是鼠标落下时鼠标位置，相对于当时窗体的坐标值
            Me.Location = MyPos  '设置窗口的“新位置”
        End If
    End Sub

    Public Sub Main_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_Top.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Cursor = Cursors.Default
            Me.bMouseDown = False  '清置鼠标变量
        End If
        Me.Opacity = 1
    End Sub
#End Region

#Region "最小化和关闭按钮"

    Private Sub Exit_Bt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Exit_Bt.Click
        If authority = 1 Or authority = 2 Then
            Application.Restart()
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub Exit_Bt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Exit_Bt.MouseEnter
        Exit_Bt.BackColor = Color.Red
    End Sub

    Private Sub Exit_Bt_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Exit_Bt.MouseLeave
        Exit_Bt.BackColor = Color.Transparent
    End Sub

    Private Sub Min_Bt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Min_Bt.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Min_Bt_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Min_Bt.MouseLeave
        Min_Bt.BackColor = Color.Transparent
    End Sub

    Private Sub Min_Bt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Min_Bt.MouseEnter
        Min_Bt.BackColor = Color.Red
    End Sub

#End Region

    Public Sub initialize()

        Label_Auth.Text = username & "同学，欢迎你使用本系统"

        XML_Authority()
        Getschoolday()
        Try
            TabPage1.Controls.Add(TA_Frame.TA_TBE)   '助课模块在此载入
        Catch ex As Exception
        End Try

        If authority = 0 Then
            Config_Lbl.Enabled = False
            Config_Lbl.Visible = False
            
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Info_Management.dll") = True Then
                TabPage2.Text = "成员管理"
                If DLL_Import(Application.StartupPath & "\Info_Management.dll", "Info_Management.Info_Management_Frame", TabPage2, "Info_Management_Tab") = True Then
                Else
                    Main_TAB.TabPages.Remove(TabPage2)
                End If
            Else
                Main_TAB.TabPages.Remove(TabPage2)
            End If

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Sign_Duty.dll") = True Then
                TabPage3.Text = "签到与值班"
                If DLL_Import(Application.StartupPath & "\Sign_Duty.dll", "Sign_Duty.Sign_Duty_Frame", TabPage3, "Sign_Duty_Tab") = True Then
                    tabpage3_init = True
                Else
                    Main_TAB.TabPages.Remove(TabPage3)
                End If
            Else
                Main_TAB.TabPages.Remove(TabPage3)
            End If

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\System_Control.dll") = True Then
                TabPage4.Text = "系统控制"
                If DLL_Import(Application.StartupPath & "\System_Control.dll", "System_Control.System_Control_Frame", TabPage4, "System_Control_Tab") = True Then
                Else
                    Main_TAB.TabPages.Remove(TabPage4)
                End If
            Else
                Main_TAB.TabPages.Remove(TabPage4)
            End If

        ElseIf authority = 8 Then

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Info_Management.dll") = True Then
                TabPage2.Text = "成员管理"
                If DLL_Import(Application.StartupPath & "\Info_Management.dll", "Info_Management.Info_Management_Frame", TabPage2, "Info_Management_Tab") = True Then
                Else
                    Main_TAB.TabPages.Remove(TabPage2)
                End If
            Else
                Main_TAB.TabPages.Remove(TabPage2)
            End If

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Sign_Duty.dll") = True Then
                TabPage3.Text = "签到与值班"
                If DLL_Import(Application.StartupPath & "\Sign_Duty.dll", "Sign_Duty.Sign_Duty_Frame", TabPage3, "Sign_Duty_Tab") = True Then
                    tabpage3_init = True
                Else
                    Main_TAB.TabPages.Remove(TabPage3)
                End If
            Else
                Main_TAB.TabPages.Remove(TabPage3)
            End If

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\System_Control.dll") = True Then
                TabPage4.Text = "系统控制"
                If DLL_Import(Application.StartupPath & "\System_Control.dll", "System_Control.System_Control_Frame", TabPage4, "System_Control_Tab") = True Then
                Else
                    Main_TAB.TabPages.Remove(TabPage4)
                End If
            Else
                Main_TAB.TabPages.Remove(TabPage4)
            End If

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Hard_Group.dll") = True Then
                TabPage5.Text = "硬件组"
                If DLL_Import(Application.StartupPath & "\Hard_Group.dll", "Hard_Group.Hard_Group_Frame", TabPage5, "Hard_Group_Tab") = True Then
                Else
                    Main_TAB.TabPages.Remove(TabPage5)
                End If
            Else
                Main_TAB.TabPages.Remove(TabPage5)
            End If

        Else
            Config_Lbl.Enabled = False
            Config_Lbl.Visible = False
            Main_TAB.TabPages.Remove(TabPage2)
            Main_TAB.TabPages.Remove(TabPage3)
            Main_TAB.TabPages.Remove(TabPage4)
            Main_TAB.TabPages.Remove(TabPage5)
            Panel_Top.Enabled = False
           
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        initialize()
        Timer1.Start()
        Timer1.Interval = 1000
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Timer1.Stop()
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\elab.xml") = True Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\elab.xml")
            End If
        Catch ex As Exception

        End Try

        If authority = 0 Then
            logwrite("quit", usernum, "科中成员退出")
        ElseIf authority = 8 Then
            logwrite("quit", usernum, "管理员退出")
        ElseIf authority = 1 Or authority = 2 Then
            logwrite("quit", usernum, "上课同学退出")
        End If

        If IsErrorUpdate = True Then
            Cmd_Update(ErrorUpdateName)
            'Cmd_Update("System_Control.dll")
        End If

        thread_end()  '结束多线程，结束监听

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label_Time.Text = schoolday & " " & Now.TimeOfDay.Hours & ":" & Now.TimeOfDay.Minutes & ":" & Now.TimeOfDay.Seconds
    End Sub

    Private Sub Config_Lbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Config_Lbl.Click
        Config.ShowDialog()
    End Sub

    Private Sub Config_Lbl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Config_Lbl.MouseLeave
        Dim LabelFont As Font = New Font(Config_Lbl.Font.Name, Config_Lbl.Font.Size, FontStyle.Regular)
        Config_Lbl.Font.Dispose()
        Config_Lbl.Font = LabelFont
        Config_Lbl.BackColor = Color.Transparent
    End Sub

    Private Sub Config_Lbl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Config_Lbl.MouseMove
        Dim LabelFont As Font = New Font(Config_Lbl.Font.Name, Config_Lbl.Font.Size, FontStyle.Underline)
        Config_Lbl.Font.Dispose()
        Config_Lbl.Font = LabelFont
        Config_Lbl.BackColor = Color.FromArgb(104, 173, 219)
    End Sub

    Private Sub XML_Authority()
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\elab.xml") = True Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\elab.xml")
                XML_Create(Application.StartupPath & "\elab.xml")
                XML_Insert(Application.StartupPath & "\elab.xml")
            Else
                XML_Create(Application.StartupPath & "\elab.xml")
                XML_Insert(Application.StartupPath & "\elab.xml")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If authority = 1 Or authority = 2 Then
            Main_TAB.SelectedTab = TabPage1
        ElseIf authority = 0 Or authority = 8 Then
            If tabpage3_init = True Then
                Main_TAB.SelectedTab = TabPage3
            Else
                Main_TAB.SelectedTab = TabPage1
            End If
        End If
    End Sub

End Class