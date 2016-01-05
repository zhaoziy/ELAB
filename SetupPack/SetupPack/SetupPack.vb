Public Class SetupPack

    Const SoftName_Elab = "���й���ϵͳ"                      '*****************
    Const SoftName_Sign = "���й���ϵͳ_ǩ��"
    Const AppPath = "D:\Program Files\" & SoftName_Elab & "\"

    Dim SetupPath As String = String.Empty       '�ļ��İ�װ·����������ִ�г����ļ�������������������
    Dim DeskTop As String = String.Empty
    Dim myArg(1) As String                        '���������򴫹����Ĳ���

    Dim IsSuccess As Boolean = False             '��ʶ�Ƿ�װ�ɹ����������ʱ���ɹ���ɾ������
    Dim IsWebConnection As Boolean = True

    '��ݷ�ʽ�Ƿ����
    Dim isExists_Elab As Boolean = IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & SoftName_Elab & ".lnk")
    Dim isExists_Sign As Boolean = IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & SoftName_Sign & ".lnk")

    '�ж�exe�Ƿ����
    Dim isExists_Elab_Exe As Boolean = False
    Dim isExists_Sign_Exe As Boolean = False

    '�ж�������ļ��Ƿ����
    Dim isExists_Web_Elab_Exe As Boolean = My.Computer.FileSystem.FileExists("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\" & SoftName_Elab & ".exe")
    Dim isExists_Web_Sign_Exe As Boolean = My.Computer.FileSystem.FileExists("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\" & SoftName_Sign & ".exe")

#Region "�����¼�"

    Private Sub SetupPack_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.IsSuccess Then
            delmyself()
        End If
    End Sub

    Private Sub SetupPack_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SoftName_Elab & "--��װ"
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
        'str = "-auto_Sign D:\Program Files\���й���ϵͳ\"
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
            Me.LabState.Text = "����׼����װ"
            Label1.Visible = False
            Timer.Start()
        End If
    End Sub
#End Region

#Region "��ť�¼�"

    '��װ����
    Private Sub ButSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSetup.Click
        Me.LabState.Text = "���ڰ�װ"
        Me.ButSetup.Enabled = False
        If Setup() Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", SoftName_Sign, """" & SetupPath & SoftName_Sign & ".exe" & """")
            Me.LabState.Text = "��װ�ɹ���"
            Me.ButExit.Text = "��װ���"
            Me.IsSuccess = True
            Me.CheckStart.Enabled = True
            Me.ButExit.Enabled = True
        Else
            Me.LabState.Text = "��װʧ�ܣ������ԭ������ԡ�"
            Me.ButSetup.Text = "���°�װ"
        End If
    End Sub

    '�˳���װ
    Private Sub ButExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButExit.Click
        If Me.LabState.Text = "���ڰ�װ" Then
        Else
            If Me.ButExit.Text = "��װ���" Then
                If Me.CheckStart.Checked Then
                    If isExists_Web_Sign_Exe = True Then
                        System.Diagnostics.Process.Start(AppPath & SoftName_Sign & ".exe")
                    End If
                    If isExists_Web_Elab_Exe = True Then
                        System.Diagnostics.Process.Start(AppPath & SoftName_Elab & ".exe")
                    End If
                End If
            ElseIf Me.ButExit.Text = "�˳���װ" Then
            End If
            Application.Exit()
        End If
    End Sub

#End Region

    '����ͻ���̣��Զ���װ���
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick

        Dim SoftName As String = ""
        If myArg(0) = "-auto_Elab" Then
            SoftName = SoftName_Elab
        ElseIf myArg(0) = "-auto_Sign" Then
            SoftName = SoftName_Sign
        End If

        If Process.GetProcessesByName(SoftName).Length = 0 Then
            LabState.Text = "���ڰ�װ"
            If Setup() Then
                If myArg(0) = "-auto_Sign" Then
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", SoftName, """" & SetupPath & SoftName & ".exe" & """")
                End If
                LabState.Text = "��װ�ɹ���"
                IsSuccess = True
                CheckStart.Enabled = True
                But_Fin.Text = "���"
                Timer.Stop()
                Me.LabState.Text = "������Զ��رղ����г���"
                Threading.Thread.Sleep(2000)
                System.Diagnostics.Process.Start(SetupPath & SoftName & ".exe")
                Application.Exit()
            Else
                LabState.Text = "��װʧ�ܣ�"
                But_Fin.Text = "����"
                Panel.Enabled = True
            End If
            Timer.Stop()
        Else
            Me.LabState.Text = " " & SoftName & " �رպ󣬰�װ�����Զ�����"
        End If
    End Sub

    '��װ����
    Function Setup() As Boolean
        Try
            '��ʼ��װ
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

    '��ӿ�ݷ�ʽ
    Sub CreateShortcut(ByVal FromDir As String, ByVal ToDir As String, ByVal filename As String)
        ' ֱ�ӵ���COM����
        Dim wsh As Object = CreateObject("WScript.Shell")
        Dim lnk As Object = wsh.CreateShortcut(ToDir & "\" & filename & ".lnk")
        With lnk
            .Arguments = "" '���ݲ���
            .Description = filename
            .IconLocation = FromDir & "\" & filename & ".exe"
            .TargetPath = FromDir & "\" & filename & ".exe"
            .WindowStyle = 1       '�򿪴���ķ��
            .WorkingDirectory = FromDir     '����·��
            .Save()         '�����ݷ�ʽ
        End With
    End Sub

    '����batɾ������
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
                If isExists_Web_Elab_Exe = True Then   '������ϴ���Դ�ļ����������һ�����粻����Դ�ļ������������أ�������һ���ļ�����
                    If isExists_Elab_Exe = True Then   '�������Ҳ�����ļ��������MD5У�飬����ֱ�Ӹ���
                        If MD5CalcFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ.exe") <> MD5CalcFile(AppPath & SoftName_Elab & ".exe") Then
                            My.Computer.FileSystem.DeleteFile(AppPath & SoftName_Elab & ".exe")
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ.exe", AppPath & SoftName_Elab & ".exe")

                        End If
                    Else
                        My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ.exe", AppPath & SoftName_Elab & ".exe")

                    End If
                End If

                If isExists_Web_Sign_Exe = True Then   '������ϴ���Դ�ļ����������һ�����粻����Դ�ļ������������أ�������һ���ļ�����
                    If isExists_Sign_Exe = True Then   '�������Ҳ�����ļ��������MD5У�飬����ֱ�Ӹ���
                        If MD5CalcFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ_ǩ��.exe") <> MD5CalcFile(AppPath & SoftName_Sign & ".exe") Then
                            My.Computer.FileSystem.DeleteFile(AppPath & SoftName_Sign & ".exe")
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ_ǩ��.exe", AppPath & SoftName_Sign & ".exe")

                        End If
                    Else
                        My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ_ǩ��.exe", AppPath & SoftName_Sign & ".exe")

                    End If
                End If

                For i = 0 To My.Computer.FileSystem.GetFiles("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ").Count - 1
                    str = Trim(My.Computer.FileSystem.GetFiles("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ").Item(i))
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
                If isExists_Web_Elab_Exe = True Then   '������ϴ���Դ�ļ����������һ�����粻����Դ�ļ������������أ�������һ���ļ�����
                    If isExists_Elab_Exe = True Then   '�������Ҳ�����ļ��������MD5У�飬����ֱ�Ӹ���
                        If MD5CalcFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ.exe") <> MD5CalcFile(myArg(1) & SoftName_Elab & ".exe") Then
                            My.Computer.FileSystem.DeleteFile(myArg(1) & SoftName_Elab & ".exe")
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ.exe", myArg(1) & SoftName_Elab & ".exe")

                        End If
                    Else
                        My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ.exe", myArg(1) & SoftName_Elab & ".exe")

                    End If
                End If

                For i = 0 To My.Computer.FileSystem.GetFiles("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ").Count - 1
                    str = Trim(My.Computer.FileSystem.GetFiles("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ").Item(i))
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
                If isExists_Web_Sign_Exe = True Then   '������ϴ���Դ�ļ����������һ�����粻����Դ�ļ������������أ�������һ���ļ�����
                    If isExists_Sign_Exe = True Then   '�������Ҳ�����ļ��������MD5У�飬����ֱ�Ӹ���
                        If MD5CalcFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ_ǩ��.exe") <> MD5CalcFile(myArg(1) & SoftName_Sign & ".exe") Then
                            My.Computer.FileSystem.DeleteFile(myArg(1) & SoftName_Sign & ".exe")
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ_ǩ��.exe", myArg(1) & SoftName_Sign & ".exe")

                        End If
                    Else
                        My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\��װ�ļ�\���й���ϵͳ\���й���ϵͳ_ǩ��.exe", myArg(1) & SoftName_Sign & ".exe")
                    End If
                End If
            End If
            'Else
            'IsWebConnection = False
            'End If

        Catch ex As Exception
        End Try
    End Sub

#Region "�����ļ�md5ֵ"

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