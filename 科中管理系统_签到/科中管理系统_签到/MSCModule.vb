Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Resources
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Net.Sockets
Imports System.Text

Module MSCModule

    '需要写入注册表的常量
    Public Const Version As Integer = 1
    Public Const SoftName = "科中管理系统_签到"

    '数据库相关
    Public Sign_Identity As String = String.Empty               '本次签到在数据库上对应的ID值

    Public connstr As String = "server=192.168.1.252;database=student;uid=ta;pwd=elab2013;connection timeout=5;"  '连接远程服务器
    'Public connstr As String = "Data Source=.;Integrated Security=True;Database=student"              '连接本地
    Public conn As SqlConnection, cmd As SqlCommand, myreader As SqlDataReader  '数据库连接读取等相关变量
    Public conn_1 As SqlConnection, cmd_1 As SqlCommand, myreader_1 As SqlDataReader  '数据库连接读取等相关变量
    Public conn_2 As SqlConnection, cmd_2 As SqlCommand, myreader_2 As SqlDataReader  '数据库连接读取等相关变量

    Public strSql, selectcmd, insertcmd, updatecmd, delcmd As String            '数据库字符串储存变量

    Public StartDate As Date                 '程序启动时间
    Public EndDate As Date                   '程序退出时间

    Public disable As Boolean = True   '检查版本是否可用
    Public schoolcalendar As String    '学期（例：2013秋）

    '获取基本信息：用户名，学号，组别，手机号，座右铭，年级
    Public UserName As String = String.Empty
    Public StuNum As String = String.Empty
    Public Team As String = String.Empty
    Public Phone As String = String.Empty
    Public HappyMotto As String = String.Empty
    Public Grade As String = String.Empty

    Public thread1 As Thread
    Public udp1 As New UdpClient(11002)
    Public revip As String
    Public localIPv4 As String         '网络接收

#Region "多线程操作"

    Public Sub thread_init()
        Try
            thread1 = New Thread(New ThreadStart(AddressOf GroupReceive))
            thread1.Start()
        Catch ex As Exception
            Environment.Exit(0)
        End Try
    End Sub

    Public Sub thread_end()
        Try
            udp1.Close()
            thread1.Abort()
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "udp广播信息接收"
    Public Sub GroupReceive()
        Dim udpendpoint As IPEndPoint = Nothing
        Dim bytes As Byte()
        Dim returnData As String

        While True
            Try
                bytes = udp1.Receive(udpendpoint)
                returnData = Encoding.Unicode.GetString(bytes)
                revip = udpendpoint.Address.ToString
                checkip()
                'MsgBox(returnData)
                'MsgBox(revip)
                If revip <> "" And revip <> localIPv4 Then
                    Select Case returnData
                        Case "zx"
                            LogoOff()
                            'MsgBox("zx")
                        Case "cq"
                            Reboot()
                            'MsgBox("cq")
                        Case "gj"
                            PowerOff()
                            'MsgBox("gj")
                    End Select
                End If
            Catch ex As Exception
            End Try
        End While
    End Sub
#End Region

#Region "计算机事件"

    <DllImport("kernel32.dll", ExactSpelling:=True)> _
       Friend Function GetCurrentProcess() As IntPtr
    End Function
    <DllImport("advapi32.dll", ExactSpelling:=True, SetLastError:=True)> _
     Friend Function OpenProcessToken(ByVal h As IntPtr, ByVal acc As Integer, ByRef phtok As IntPtr) As Boolean
    End Function
    <DllImport("advapi32.dll", SetLastError:=True)> _
    Friend Function LookupPrivilegeValue(ByVal host As String, ByVal name As String, ByRef pluid As Long) As Boolean
    End Function
    <DllImport("advapi32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Friend Function AdjustTokenPrivileges(ByVal htok As IntPtr, ByVal disall As Boolean, ByRef newst As TokPriv1Luid, ByVal len As Integer, ByVal prev As IntPtr, ByVal relen As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Friend Function ExitWindowsEx(ByVal flg As Integer, ByVal rea As Integer) As Boolean
    End Function
    Friend Const SE_PRIVILEGE_ENABLED As Integer = &H2
    Friend Const TOKEN_QUERY As Integer = &H8
    Friend Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20
    Friend Const SE_SHUTDOWN_NAME As String = "SeShutdownPrivilege"
    Friend Const EWX_LOGOFF As Integer = &H0 '注销计算机
    Friend Const EWX_REBOOT As Integer = &H2 '重新启动计算机
    Friend Const EWX_FORCE As Integer = &H4 '关闭所有进程，注销计算机
    Friend Const EWX_POWEROFF As Integer = &H8 '关闭计算机
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Friend Structure TokPriv1Luid
        Public Count As Integer
        Public Luid As Long
        Public Attr As Integer
    End Structure
    Private Sub DoExitWin(ByVal flg As Integer)
        Dim xc As Boolean '判断语句
        Dim tp As TokPriv1Luid
        Dim hproc As IntPtr = GetCurrentProcess() '调用进程值
        Dim htok As IntPtr = IntPtr.Zero
        xc = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, htok)
        tp.Count = 1
        tp.Luid = 0
        tp.Attr = SE_PRIVILEGE_ENABLED
        xc = LookupPrivilegeValue(Nothing, SE_SHUTDOWN_NAME, tp.Luid)
        xc = AdjustTokenPrivileges(htok, False, tp, 0, IntPtr.Zero, IntPtr.Zero)
        xc = ExitWindowsEx(flg, 0)
    End Sub
    Public Sub Reboot()
        DoExitWin((EWX_FORCE Or EWX_REBOOT)) '重新启动计算机
    End Sub
    Public Sub PowerOff()
        DoExitWin((EWX_FORCE Or EWX_POWEROFF)) '关闭计算机
    End Sub
    Public Sub LogoOff()
        DoExitWin((EWX_FORCE Or EWX_LOGOFF)) '注销计算机
    End Sub

#End Region

#Region "检测IP地址"

    Public Sub checkip()
        Dim i As Integer = 0
        localIPv4 = "192.168.0.0" '如未获得正确的ipv4地址，则使用默认的地址。此地址为异常地址
        For i = 0 To Dns.GetHostEntry(Dns.GetHostName).AddressList.Length - 1
            If (Dns.GetHostEntry(Dns.GetHostName).AddressList(i).ToString.Length > 10) Then
                If (Dns.GetHostEntry(Dns.GetHostName).AddressList(i).ToString.Substring(0, 10) = "192.168.1.") Then
                    localIPv4 = Dns.GetHostEntry(Dns.GetHostName).AddressList(i).ToString
                    Exit For
                End If
            End If
        Next
    End Sub

#End Region

#Region "版本检查，更新程序"

    Public Sub CheckVerList()
        Dim QuickUpdate As Boolean = False
        selectcmd = "select 屏蔽使用,快速升级 from [VerList] where 程序名 = '科中管理系统_签到' and 版本号 = " & Version
        If sql(selectcmd) Then
            If myreader.Read Then
                QuickUpdate = myreader.Item("快速升级")
                If myreader.Item("屏蔽使用") = "是" Then
                    disable = True
                Else : disable = False
                End If
            End If
        End If
        sql_rele(conn, cmd)

        update_info()
        If QuickUpdate = True And disable = False Then
            check()
        End If
    End Sub '检查当前版本是否屏蔽，确定是否启动快速升级

    Public Sub update_info()

        If disable = True Then
            selectcmd = "select 程序特点 from [VerList] where 程序名 = '科中管理系统_签到' and 屏蔽使用 = '否'"
            If sql(selectcmd) Then
                If myreader.Read Then
                    If IsDBNull(myreader.Item("程序特点")) = False And myreader.Item("程序特点").ToString <> "" Then
                        MessageBox.Show(myreader.Item("程序特点"), "更新信息", MessageBoxButtons.OK)
                    End If
                End If
            End If
            sql_rele(conn, cmd)
            update()
        Else : Exit Sub
        End If

    End Sub '新版本更新信息，并更新

    Public Sub check()
        Dim reso As String = Application.ExecutablePath
        Dim dest As String = "\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统_签到.exe"
        Try
            If MD5CalcFile(reso) <> MD5CalcFile(dest) Then
                update()
            End If
        Catch ex As Exception
        End Try
    End Sub   '检查本程序与网络程序MD5，不相同则启动快速升级更新

    Public Sub update()
        Dim AppPath As String
        AppPath = Application.StartupPath
        ReleRes(AppPath, "SetupPack", "exe")
        'MsgBox("-auto " & AppPath & "\")
        Process.Start(AppPath & "\SetupPack.exe", "-auto_Sign " & AppPath & "\")
        Environment.Exit(0)
    End Sub   '更新

    Function ReleRes(ByVal ReleLevel As String, ByVal ReleFile As String, ByVal Exten As String) As Boolean

        '检测RelePath目录是否存在，不存在则创建
        If Not Directory.Exists(ReleLevel) Then
            Directory.CreateDirectory(ReleLevel)
        Else
            '检测是否已经安装
            If File.Exists(ReleLevel & "\" & ReleFile & "." & Exten) Then
                My.Computer.FileSystem.DeleteFile(ReleLevel & "\" & ReleFile & "." & Exten)
            End If
        End If
        Try
            '释放
            Dim resources As ResourceManager = My.Resources.ResourceManager
            Dim bytes() As Byte
            Dim recfs As FileStream
            Dim newfilestr As BinaryWriter
            'SoftName
            bytes = resources.GetObject(ReleFile)
            recfs = New FileStream(ReleLevel & "\" & ReleFile & "." & Exten, FileMode.OpenOrCreate)
            newfilestr = New BinaryWriter(recfs)
            newfilestr.Write(bytes)
            '关闭
            newfilestr.Close()
            recfs.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function '释放资源（管理系统下载器，释放到程序所在目录，并自动更新到当前目录。下载器可以单独_使用，单独使用时，默认全新安装）

#End Region

#Region "执行SQL语句函数"

    Public Function sql(ByVal sqlcmd As String) As Boolean
        conn = New SqlConnection(connstr)
        Try
            conn.Open()
            cmd = New SqlCommand(sqlcmd, conn)
            myreader = cmd.ExecuteReader
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn.Close()
            Return False
        End Try
    End Function

    Public Function sql_1(ByVal sqlcmd As String) As Boolean
        conn_1 = New SqlConnection(connstr)
        Try
            conn_1.Open()
            cmd_1 = New SqlCommand(sqlcmd, conn_1)
            myreader_1 = cmd_1.ExecuteReader
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn_1.Close()
            Return False
        End Try
    End Function

    Public Function sql_2(ByVal sqlcmd As String) As Boolean
        conn_2 = New SqlConnection(connstr)
        Try
            conn_2.Open()
            cmd_2 = New SqlCommand(sqlcmd, conn_2)
            myreader_2 = cmd_2.ExecuteReader
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn_2.Close()
            Return False
        End Try
    End Function

    Public Function gettable(ByVal tablename As String, ByVal sqlstr As String) As DataTable
        conn = New SqlConnection(connstr)
        Dim adapter As New SqlDataAdapter(sqlstr, conn)
        Dim newtable As New DataTable
        Dim timeds As New DataSet
        Try
            conn.Open()
            timeds.Clear()
            adapter.Fill(timeds, tablename)
            newtable = timeds.Tables(tablename)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn.Close()
        End Try
        Return timeds.Tables(tablename)
    End Function

    Public Sub sql_rele(ByVal SqlCon As SqlConnection, ByVal SqlCmd As SqlCommand)              '释放数据库占用资源
        If Not SqlCmd Is Nothing Then
            SqlCmd.Dispose()
            SqlCmd = Nothing
        End If
        If Not SqlCon Is Nothing Then
            If SqlCon.State <> ConnectionState.Closed Then
                SqlCon.Close()
            End If
            SqlCon.Dispose()
            SqlCon = Nothing
        End If
    End Sub

#End Region

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

#Region "读取上课学期信息"

    Public Sub init()
        selectcmd = "select 学期 from [开学日期]"
        If sql(selectcmd) Then
            If myreader.Read Then
                schoolcalendar = myreader.Item(0).ToString.Trim
            End If
        End If
        sql_rele(conn, cmd)
    End Sub

#End Region

#Region "软件提示"
    Public Sub info_notify()
        Dim now_time As Date = ServerTime()
        Dim i As Integer
        i = DateDiff(DateInterval.Day, now_time, New Date(2015, 6, 8, 0, 0, 0))
        Dim str As String
        Dim a As Boolean = False
        str = "select * from [member] where 学号='" & StuNum & "'"
        sql(str)
        If myreader.Read Then
            If myreader.Item("职务").ToString = "班委" Then
                a = True
            End If
        End If
        sql_rele(conn, cmd)
        If Team = "软件组" AndAlso Grade <> "大一" AndAlso Grade <> "大三" AndAlso i > 0 Then
            MsgBox("提醒软件组高年级同学，请在15周之前更新管理系统，届时将无法签到。更新完成后，找班长验收.还有" & i & "天")
        ElseIf a = True Then
            MsgBox("提醒软件组高年级同学，请在15周之前更新管理系统，届时将无法签到。更新完成后，找班长验收.还有" & i & "天")
        End If
        If i <= 0 Then
            MsgBox("时间已到，请立即更换模块，并找班长解决。")
            Application.Exit()
        End If
    End Sub
#End Region

    Public Function GetInfo() As Boolean
        '******用一次请求完成，获取基本信息
        Dim year As Integer
        Dim mac As String = String.Empty
        Dim ip As String = String.Empty

        sql("select * from [member] where USERNAME='" & Environment.GetEnvironmentVariable("username") & "'")
        While myreader.Read()
            StuNum = myreader("学号")
        End While
        sql_rele(conn, cmd)

        sql("select * from [member] where [学号]=" & StuNum)
        While myreader.Read
            UserName = myreader("姓名")
            year = DateTime.Today.Year() - 1000 * CType(Val(StuNum(0)), Integer) - 100 * CType(Val(StuNum(1)), Integer) - 10 * CType(Val(StuNum(2)), Integer) - CType(Val(StuNum(3)), Integer)
            If IsDBNull(myreader("组别")) Then
                Phone = String.Empty
            Else
                Team = myreader("组别")
            End If
            If IsDBNull(myreader("电话")) Then
                Phone = String.Empty
            Else
                Phone = myreader("电话")
            End If
            If DateTime.Today.Month > 8 Then
                year = year + 1
            End If
            If year = 1 Then
                Grade = "大一"
            ElseIf year = 2 Then
                Grade = "大二"
            ElseIf year = 3 Then
                Grade = "大三"
            ElseIf year = 4 Then
                Grade = "大四"
            Else
                Grade = "往届"
            End If
            If IsDBNull(myreader("座右铭")) Then
                HappyMotto = String.Empty
            Else
                HappyMotto = myreader("座右铭")
            End If
        End While
        sql_rele(conn, cmd)
        Return True
    End Function

    '获取周次(这周是这学期的第几周)
    Public NowWeek As Integer
    Public Function GetWeek() As Integer
        Dim week As Integer
        Dim str As String
        str = "select top 1 datediff(day,[开学日期],getdate())/7+1 as cache from [开学日期]"
        sql(str)
        If myreader.Read Then
            week = myreader.Item("cache")
        Else
            week = -1
        End If
        sql_rele(conn, cmd)
        Return week
    End Function

    '返回当前服务器时间，错误返回"1991-01-01 00:00:00"
    Public Function ServerTime() As Date
        Dim nowtime As Date
        sql("select convert(varchar(20),getdate(),20) as date")
        If myreader.Read = True Then
            nowtime = myreader.Item("date")
        Else
            nowtime = New Date(1991, 1, 1, 0, 0, 0)
        End If
        sql_rele(conn, cmd)
        Return nowtime
    End Function
    '返回单双周
    Public Function 单双周() As String
        If NowWeek Mod 2 = 0 Then
            Return "双周"
        Else
            Return "单周"
        End If
    End Function

    '返回两个时间的差值，以小时为单位，用了系统内置的函数DateDiff
    Public Function TimeDiff(ByVal time1 As Date, ByVal time2 As Date) As String
        If time1.Year = time2.Year And time1.Month = time2.Month And time1.Day = time2.Day Then
            Return Format(DateDiff(DateInterval.Minute, time1, time2) / 60, "0.00")
        Else
            Return "0"
        End If
    End Function

    '返回指定时间状态，早上，中午。。。
    Public Function TimeStat(ByVal cachetime As Date) As String
        Select Case cachetime.Hour
            Case 5 To 7
                Return "早上"
            Case 8 To 10
                Return "上午"
            Case 11 To 12
                Return "中午"
            Case 13 To 16
                Return "下午"
            Case 17 To 23
                Return "晚上"
            Case Else
                Return "凌晨"
        End Select
    End Function

End Module
