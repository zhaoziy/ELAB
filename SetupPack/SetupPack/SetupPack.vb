Public Class SetupPack

    Const SoftName_Elab = "科中管理系统"                      '*****************
    Const SoftName_Sign = "科中管理系统_签到"
    Const AppPath = "D:\Program Files\" & SoftName_Elab & "\"

    Dim SetupPath As String = String.Empty       '文件的安装路径（包含可执行程序文件名），用于启动程序
    Dim DeskTop As String = String.Empty
    Dim myArg(1) As String                        '接收主程序传过来的参数

    Dim IsSuccess As Boolean = False             '标识是否安装成功，程序结束时，成功则删除自身
    Dim IsWebConnection As Boolean = True

    '快捷方式是否存在
    Dim isExists_Elab As Boolean = IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & SoftName_Elab & ".lnk")
    Dim isExists_Sign As Boolean = IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & SoftName_Sign & ".lnk")

    '判断exe是否存在
    Dim isExists_Elab_Exe As Boolean = False
    Dim isExists_Sign_Exe As Boolean = False

    '判断网络端文件是否存在
    Dim isExists_Web_Elab_Exe As Boolean = My.Computer.FileSystem.FileExists("\\192.168.1.5\upload\安装文件\科中管理系统\" & SoftName_Elab & ".exe")
    Dim isExists_Web_Sign_Exe As Boolean = My.Computer.FileSystem.FileExists("\\192.168.1.5\upload\安装文件\科中管理系统\" & SoftName_Sign & ".exe")

#Region "窗体事件"

    Private Sub SetupPack_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.IsSuccess Then
            delmyself()
        End If
    End Sub

    Private Sub SetupPack_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SoftName_Elab & "--安装"
        Me.CheckStart.Checked = True
        If isExists_Web_Elab_Exe = False Then
            CheckDeskTop_Elab.Checked = False
            CheckDeskTop_Elab.Enabled = False
            CheckDeskTop_Elab.Visible = False
        End If
        If isExists_Web_Sign_Exe = False Then
            CheckDeskTop_Sign.Checked = False
            CheckDeskTop_Sign.Enabled = False
            CheckDeskTop_Sign.Visible = False
        End If
    End Sub

    Private Sub SetupPack_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Dim str As String = Microsoft.VisualBasic.Command
        str = Trim(str)
        'str = "-auto_Sign D:\Program Files\科中管理系统\"
        'MsgBox(str)

        If str <> "" Then
            myArg(0) = str.Substring(0, 10)
            'MsgBox(myArg(0))
            myArg(1) = Trim(str.Substring(11, str.Length - 11))
            'MsgBox(myArg(1))
        End If
        If isExists_Web_Elab_Exe = True Then
            If isExists_Elab = False Then
                Me.CheckDeskTop_Elab.Checked = True
            Else
                Me.CheckDeskTop_Elab.Checked = False
            End If
        End If

        If isExists_Web_Sign_Exe = True Then
            If isExists_Sign = False Then
                Me.CheckDeskTop_Sign.Checked = True
            Else
                Me.CheckDeskTop_Sign.Checked = False
            End If
        End If

        If myArg(0) Is Nothing Then
            Me.LabState.Text = ""
            Me.Panel.Enabled = True
            Me.But_Fin.Hide()
        ElseIf myArg(0).Substring(0, 5) = "-auto" Then
            Me.LabState.Text = "正在准备安装"
            Label1.Visible = False
            Timer.Start()
        End If
    End Sub
#End Region

#Region "按钮事件"

    '安装程序
    Private Sub ButSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSetup.Click
        Me.LabState.Text = "正在安装"
        Me.ButSetup.Enabled = False
        If Setup() Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", SoftName_Sign, """" & SetupPath & SoftName_Sign & ".exe" & """")
            Me.LabState.Text = "安装成功！"
            Me.ButExit.Text = "安装完成"
            Me.IsSuccess = True
            Me.CheckStart.Enabled = True
            Me.ButExit.Enabled = True
        Else
            Me.LabState.Text = "安装失败！请查找原因后重试。"
            Me.ButSetup.Text = "重新安装"
        End If
    End Sub

    '退出安装
    Private Sub ButExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButExit.Click
        If Me.LabState.Text = "正在安装" Then
        Else
            If Me.ButExit.Text = "安装完成" Then
                If Me.CheckStart.Checked Then
                    If isExists_Web_Sign_Exe = True Then
                        System.Diagnostics.Process.Start(AppPath & SoftName_Sign & ".exe")
                    End If
                    If isExists_Web_Elab_Exe = True Then
                        System.Diagnostics.Process.Start(AppPath & SoftName_Elab & ".exe")
                    End If
                End If
            ElseIf Me.ButExit.Text = "退出安装" Then
            End If
            Application.Exit()
        End If
    End Sub

#End Region

    '检查冲突进程，自动安装软件
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick

        Dim SoftName As String = ""
        If myArg(0) = "-auto_Elab" Then
            SoftName = SoftName_Elab
        ElseIf myArg(0) = "-auto_Sign" Then
            SoftName = SoftName_Sign
        End If

        If Process.GetProcessesByName(SoftName).Length = 0 Then
            LabState.Text = "正在安装"
            If Setup() Then
                If myArg(0) = "-auto_Sign" Then
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", SoftName, """" & SetupPath & SoftName & ".exe" & """")
                End If
                LabState.Text = "安装成功！"
                IsSuccess = True
                CheckStart.Enabled = True
                But_Fin.Text = "完成"
                Timer.Stop()
                Me.LabState.Text = "两秒后将自动关闭并运行程序。"
                Threading.Thread.Sleep(2000)
                System.Diagnostics.Process.Start(SetupPath & SoftName & ".exe")
                Application.Exit()
            Else
                LabState.Text = "安装失败！"
                But_Fin.Text = "重试"
                Panel.Enabled = True
            End If
            Timer.Stop()
        Else
            Me.LabState.Text = " " & SoftName & " 关闭后，安装程序将自动继续"
        End If
    End Sub

    '安装函数
    Function Setup() As Boolean
        Try
            '开始安装
            Me.DeskTop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            Me.ButExit.Enabled = False

            Check_Download_WebFiles()
            If IsWebConnection = False Then
                Return False
            End If

            If myArg(0) = "-auto_Sign" Then
                If isExists_Web_Sign_Exe = False Then
                    Return False
                End If
            End If

            If Me.CheckDeskTop_Elab.Checked Then
                If isExists_Web_Elab_Exe = True Then
                    If isExists_Elab = False Then
                        Me.CreateShortcut(SetupPath, DeskTop, SoftName_Elab)
                    End If
                End If
            End If

            If Me.CheckDeskTop_Sign.Checked Then
                If isExists_Web_Sign_Exe = True Then
                    If isExists_Sign = False Then
                        Me.CreateShortcut(SetupPath, DeskTop, SoftName_Sign)
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '添加快捷方式
    Sub CreateShortcut(ByVal FromDir As String, ByVal ToDir As String, ByVal filename As String)
        ' 直接调用COM对象
        Dim wsh As Object = CreateObject("WScript.Shell")
        Dim lnk As Object = wsh.CreateShortcut(ToDir & "\" & filename & ".lnk")
        With lnk
            .Arguments = "" '传递参数
            .Description = filename
            .IconLocation = FromDir & "\" & filename & ".exe"
            .TargetPath = FromDir & "\" & filename & ".exe"
            .WindowStyle = 1       '打开窗体的风格
            .WorkingDirectory = FromDir     '工作路径
            .Save()         '保存快捷方式
        End With
    End Sub

    '调用bat删除自身
    Function delmyself() As Boolean
        Try
            Dim batfile As IO.StreamWriter = New IO.StreamWriter(Application.StartupPath & "\" & "Zhao.bat", False, System.Text.Encoding.Default)
            batfile.Write("@echo off")
            batfile.WriteLine()
            batfile.Write("ping 127.1 -n 5 >nul")
            batfile.WriteLine()
            batfile.Write("del """ & Application.ExecutablePath & """" & " && del %0")
            batfile.Close()
            batfile = Nothing
            Shell(Application.StartupPath & "\" & "Zhao.bat", AppWinStyle.Hide)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub Check_Download_WebFiles()
        Dim i As Integer
        Try
            If myArg(0) Is Nothing Then
                isExists_Elab_Exe = My.Computer.FileSystem.FileExists(AppPath & SoftName_Elab & ".exe")
                isExists_Sign_Exe = My.Computer.FileSystem.FileExists(AppPath & SoftName_Sign & ".exe")
            ElseIf myArg(0).Substring(0, 5) = "-auto" Then
                isExists_Elab_Exe = My.Computer.FileSystem.FileExists(myArg(1) & SoftName_Elab & ".exe")
                isExists_Sign_Exe = My.Computer.FileSystem.FileExists(myArg(1) & SoftName_Sign & ".exe")
            End If

            'If My.Computer.Network.Ping("192.168.1.5") = True Then

            Dim str As String
            If myArg(0) Is Nothing Then
                SetupPath = AppPath
                If isExists_Web_Elab_Exe = True Then   '如果网上存在源文件，则进行下一步；如不存在源文件，则跳过下载，进行下一个文件下载
                    If isExists_Elab_Exe = True Then   '如果本地也存在文件，则进行MD5校验，否则直接复制
                        If MD5CalcFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统.exe") <> MD5CalcFile(AppPath & SoftName_Elab & ".exe") Then
                            My.Computer.FileSystem.DeleteFile(AppPath & SoftName_Elab & ".exe")
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统.exe", AppPath & SoftName_Elab & ".exe")

                        End If
                    Else
                        My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统.exe", AppPath & SoftName_Elab & ".exe")

                    End If
                End If

                If isExists_Web_Sign_Exe = True Then   '如果网上存在源文件，则进行下一步；如不存在源文件，则跳过下载，进行下一个文件下载
                    If isExists_Sign_Exe = True Then   '如果本地也存在文件，则进行MD5校验，否则直接复制
                        If MD5CalcFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统_签到.exe") <> MD5CalcFile(AppPath & SoftName_Sign & ".exe") Then
                            My.Computer.FileSystem.DeleteFile(AppPath & SoftName_Sign & ".exe")
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统_签到.exe", AppPath & SoftName_Sign & ".exe")

                        End If
                    Else
                        My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统_签到.exe", AppPath & SoftName_Sign & ".exe")

                    End If
                End If

                For i = 0 To My.Computer.FileSystem.GetFiles("\\192.168.1.5\upload\安装文件\科中管理系统").Count - 1
                    str = Trim(My.Computer.FileSystem.GetFiles("\\192.168.1.5\upload\安装文件\科中管理系统").Item(i))
                    If Microsoft.VisualBasic.Right(str, 4) = ".dll" Then
                        If My.Computer.FileSystem.FileExists(AppPath & My.Computer.FileSystem.GetName(str)) = True Then
                            If MD5CalcFile(str) <> MD5CalcFile(AppPath & My.Computer.FileSystem.GetName(str)) Then
                                My.Computer.FileSystem.DeleteFile(AppPath & My.Computer.FileSystem.GetName(str))
                                My.Computer.FileSystem.CopyFile(str, AppPath & My.Computer.FileSystem.GetName(str))

                            End If
                        Else
                            My.Computer.FileSystem.CopyFile(str, AppPath & My.Computer.FileSystem.GetName(str))

                        End If
                    End If
                Next

            ElseIf myArg(0) = "-auto_Elab" Then
                SetupPath = myArg(1)
                If isExists_Web_Elab_Exe = True Then   '如果网上存在源文件，则进行下一步；如不存在源文件，则跳过下载，进行下一个文件下载
                    If isExists_Elab_Exe = True Then   '如果本地也存在文件，则进行MD5校验，否则直接复制
                        If MD5CalcFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统.exe") <> MD5CalcFile(myArg(1) & SoftName_Elab & ".exe") Then
                            My.Computer.FileSystem.DeleteFile(myArg(1) & SoftName_Elab & ".exe")
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统.exe", myArg(1) & SoftName_Elab & ".exe")

                        End If
                    Else
                        My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统.exe", myArg(1) & SoftName_Elab & ".exe")

                    End If
                End If

                For i = 0 To My.Computer.FileSystem.GetFiles("\\192.168.1.5\upload\安装文件\科中管理系统").Count - 1
                    str = Trim(My.Computer.FileSystem.GetFiles("\\192.168.1.5\upload\安装文件\科中管理系统").Item(i))
                    If Microsoft.VisualBasic.Right(str, 4) = ".dll" Then
                        If My.Computer.FileSystem.FileExists(myArg(1) & My.Computer.FileSystem.GetName(str)) = True Then
                            If MD5CalcFile(str) <> MD5CalcFile(myArg(1) & My.Computer.FileSystem.GetName(str)) Then
                                My.Computer.FileSystem.DeleteFile(myArg(1) & My.Computer.FileSystem.GetName(str))
                                My.Computer.FileSystem.CopyFile(str, myArg(1) & My.Computer.FileSystem.GetName(str))

                            End If
                        Else
                            My.Computer.FileSystem.CopyFile(str, myArg(1) & My.Computer.FileSystem.GetName(str))

                        End If
                    End If
                Next

            ElseIf myArg(0) = "-auto_Sign" Then
                SetupPath = myArg(1)
                If isExists_Web_Sign_Exe = True Then   '如果网上存在源文件，则进行下一步；如不存在源文件，则跳过下载，进行下一个文件下载
                    If isExists_Sign_Exe = True Then   '如果本地也存在文件，则进行MD5校验，否则直接复制
                        If MD5CalcFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统_签到.exe") <> MD5CalcFile(myArg(1) & SoftName_Sign & ".exe") Then
                            My.Computer.FileSystem.DeleteFile(myArg(1) & SoftName_Sign & ".exe")
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统_签到.exe", myArg(1) & SoftName_Sign & ".exe")

                        End If
                    Else
                        My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统_签到.exe", myArg(1) & SoftName_Sign & ".exe")
                    End If
                End If
            End If
            'Else
            'IsWebConnection = False
            'End If

        Catch ex As Exception
        End Try
    End Sub

#Region "计算文件md5值"

    Public Function MD5CalcFile(ByVal filepath As String) As String

        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider

                Dim hash() As Byte = md5.ComputeHash(reader)
                Return ByteArrayToString(hash)

            End Using
        End Using

    End Function

    Private Function ByteArrayToString(ByVal arrInput() As Byte) As String

        Dim BAT As New System.Text.StringBuilder(arrInput.Length * 2)

        For i As Integer = 0 To arrInput.Length - 1
            BAT.Append(arrInput(i).ToString("X2"))
        Next

        Return BAT.ToString().ToLower

    End Function

#End Region

End Class