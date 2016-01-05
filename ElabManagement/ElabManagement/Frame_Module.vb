Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Sockets
Imports System.Resources            '用于释放资源
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Text
Imports System.IO
Imports System.Xml

Module Frame_Module

    Public connstr As String = "server=192.168.1.252;database=class;uid=ta;pwd=elab2013;connection timeout=5;"
    Public connstrini As String = "server=192.168.1.252;database=student;uid=ta;pwd=elab2013;connection timeout=5;"  '连接远程服务器
    'Public connstr As String = "Data Source=.;Integrated Security=True;Database=class"
    'Public connstrini As String = "Data Source=.;Integrated Security=True;Database=student"              '连接本地

    Public conn As SqlConnection, cmd As SqlCommand, myreader As SqlDataReader  '数据库连接读取等相关变量
    Public strSql, selectcmd, insertcmd, updatecmd, delcmd As String            '数据库字符串储存变量

    Public schoolday As String         '校历（第几周周几）
    Public servertime As Date          '服务器时间
    Public startday As Date            '开学日期

    Public udp1 As New UdpClient(11000)
    Public revip As String
    Public localIPv4 As String         '网络接收
    Public thread1 As Thread
    Public thread_Login As Thread
    
    Public disable As Boolean = True   '检查版本是否可用
    Public Version As String = 1       '程序版本
    Public IsErrorUpdate As Boolean = False
    Public ErrorUpdateName As String = String.Empty
    Public Finish_Update As Boolean = True

#Region "连接服务器语句，用于切换连接本机与远程服务器，调试时使用"
    Public Sub connection()  '**********调试时连接服务器（正常使用不用开启）************
        connstr = "server=192.168.1.252;database=class;uid=ta;pwd=elab2013;connection timeout=5;"
        connstrini = "server=192.168.1.252;database=student;uid=ta;pwd=elab2013;connection timeout=5;"
        'connstr = "Data Source=.;Integrated Security=True;Database=" & database & ""
        'connstrini = "Data Source=.;Integrated Security=True;Database=" & databaseini & ""
    End Sub
#End Region

#Region "多线程操作"

    Public Sub thread_init()
        Try
            thread1 = New Thread(New ThreadStart(AddressOf GroupReceive))
            thread1.IsBackground = True   '使该线程为后台线程，在application.exit后能够随程序一块关闭退出
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

#Region "记录用于信息，并判断权限"
    Public usernum As String = "000000000"
    Public username As String = "ELAB"
    Public authority As Integer = 0
    'authority=0代表助教登录
    'authority=1代表普通用户第一次登录
    'authority=2代表普通用户非第一次登录
    'authority=8代表助课组组长，班长，值班班长登录
    'authority=9代表999999999登录
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

#Region "MD5加密"

    Function MD5(ByVal strSource As String, ByVal Code As Int16) As String   '正确的MD5加密
        Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(strSource)
        Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)
        Dim ATR As String = ""
        Dim i As Integer
        Select Case Code
            Case 16      '选择16位字符的加密结果   
                For i = 4 To 11
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
            Case 32      '选择32位字符的加密结果   
                For i = 0 To 15
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
            Case Else       'Code错误时，返回全部字符串，即32位字符   
                For i = 0 To 15
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
        End Select
        Return ATR
    End Function

#End Region

#Region "获取校历"

    Public Function GetDay(ByVal i As Integer)
        Select Case i
            Case 1
                Return "周一"
            Case 2
                Return "周二"
            Case 3
                Return "周三"
            Case 4
                Return "周四"
            Case 5
                Return "周五"
            Case 6
                Return "周六"
            Case 7
                Return "周日"
            Case Else
                Return ""
        End Select
    End Function

    Public Sub Getschoolday()

        Dim weeks As Integer
        Dim days As Integer

        selectcmd = "select 开学日期 from [开学日期]"
        If sql(selectcmd, True) Then
            If myreader.Read Then
                startday = myreader.Item(0)
            End If
        End If
        conn.Close()

        weeks = DateDiff(DateInterval.DayOfYear, startday, GetServerTime()) \ 7 + 1
        days = DateDiff(DateInterval.DayOfYear, startday, GetServerTime()) Mod 7 + 1

        schoolday = "第" & weeks & "周 " & GetDay(days)

    End Sub

#End Region

#Region "执行SQL语句函数"

    Public Sub executesql(ByVal tablename As String, ByVal sqlstr As String)

        Dim conn As New SqlConnection(connstr)
        Dim cmd As New SqlCommand(sqlstr, conn)
        Dim myreader As SqlDataReader
        Dim newtable As New DataTable
        Try
            conn.Open()
            myreader = cmd.ExecuteReader
            myreader.Read()
            conn.Close()
            conn.Dispose()
            cmd.Dispose()
            newtable.Dispose()
            conn = Nothing
            cmd = Nothing
            myreader = Nothing
            newtable = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function sql(ByVal sqlcmd As String, ByVal ini As Boolean) As Boolean
        If ini = True Then
            conn = New SqlConnection(connstrini)
        Else
            conn = New SqlConnection(connstr)
        End If
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

    Public Function sqlnoerr(ByVal sqlcmd As String, ByVal ini As Boolean) As Boolean   '同函数sql，区别是本函数不返回错误信息。
        If ini = True Then
            conn = New SqlConnection(connstrini)
        Else
            conn = New SqlConnection(connstr)
        End If
        Try
            conn.Open()
            cmd = New SqlCommand(sqlcmd, conn)
            myreader = cmd.ExecuteReader
            Return True
        Catch ex As Exception
            conn.Close()
            Return False
        End Try
    End Function

    Public Function gettable(ByVal tablename As String, ByVal sqlstr As String, ByVal ini As Boolean) As DataTable
        If ini = True Then
            conn = New SqlConnection(connstrini)
        Else
            conn = New SqlConnection(connstr)
        End If
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

#End Region

#Region "获取服务器时间"
    Public Function GetServerTime() As Date
        Dim str As String
        str = "select ServerDateTime = getdate() "
        sql(str, True)      '得到数据库服务器时间
        If myreader.Read() Then
            servertime = myreader.Item(0)
        End If
        Return servertime
        conn.Close()
    End Function
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
                If revip <> "" And revip <> localIPv4 Then
                    Select Case returnData
                        Case "zx"
                            LogoOff()
                        Case "cq"
                            Reboot()
                        Case "gj"
                            PowerOff()
                    End Select
                End If
            Catch ex As Exception
            End Try
        End While
    End Sub
#End Region

#Region "log信息写入"

    Public Sub logwrite(ByVal act As String, ByVal num As String, ByVal score As String)
        Dim strlog As String = ""
        Dim strtemp As String
        Dim table1 As DataTable
        Try
            Select Case act
                Case "hard"      '硬件课log

                    strlog = "insert into log (操作人学号,操作时间,操作人IP,被修改人学号,硬件成绩,登录信息,版本号,学期) values ("
                    strlog &= usernum & ",'" & GetServerTime() & "','" & localIPv4 & "',"
                    strlog &= num & "," & score & ",'修改成绩','" & Version & "','" & schoolcalendar.Substring(0, 5) & "')"

                Case "soft"      '软件课log

                    strlog = "insert into log (操作人学号,操作时间,操作人IP,被修改人学号,软件成绩,登录信息,版本号,学期) values ("
                    strlog &= usernum & ",'" & GetServerTime() & "','" & localIPv4 & "',"
                    strlog &= num & "," & score & ",'修改成绩','" & Version & "','" & schoolcalendar.Substring(0, 5) & "')"

                Case "paper"     '试卷log

                    strlog = "insert into log (操作人学号,操作时间,操作人IP,被修改人学号,试卷成绩,登录信息,版本号,学期) values ("
                    strlog &= usernum & ",'" & GetServerTime() & "','" & localIPv4 & "',"
                    strlog &= num & "," & score & ",'修改成绩','" & Version & "','" & schoolcalendar.Substring(0, 5) & "')"

                Case "login"     '登录日志

                    strlog = "insert into log (操作人学号,操作时间,操作人IP,登录信息,版本号,学期) values ("
                    strlog &= usernum & ",'" & GetServerTime() & "','" & localIPv4 & "','"
                    strlog &= score & "','" & Version & "','" & schoolcalendar.Substring(0, 5) & "')"

                Case "quit"      '退出日志

                    strlog = "insert into log (操作人学号,操作时间,操作人IP,登录信息,版本号,学期) values ("
                    strlog &= usernum & ",'" & GetServerTime() & "','" & localIPv4 & "','"
                    strlog &= score & "','" & Version & "','" & schoolcalendar.Substring(0, 5) & "')"

                Case "zhujiang"

                    strtemp = "select 学号 from member where 姓名='" & num & "'"
                    table1 = gettable("member", strtemp, True)

                    strlog = "insert into log (操作人学号,操作时间,操作人IP,被修改人学号,登录信息,版本号,学期) values ("
                    strlog &= usernum & ",'" & GetServerTime() & "','" & localIPv4 & "','"
                    strlog &= table1.Rows(0).Item("学号") & "', '主讲人','" & Version & "','" & schoolcalendar.Substring(0, 5) & "')"
                    table1.Dispose()

                Case "zhujiao"

                    strtemp = "select 学号 from member where 姓名='" & num & "'"
                    table1 = gettable("member", strtemp, True)

                    strlog = "insert into log (操作人学号,操作时间,操作人IP,被修改人学号,登录信息,版本号,学期) values ("
                    strlog &= usernum & ",'" & GetServerTime() & "','" & localIPv4 & "','"
                    strlog &= table1.Rows(0).Item("学号") & "', '助教同学','" & Version & "','" & schoolcalendar.Substring(0, 5) & "')"
                    table1.Dispose()

            End Select
            If strlog <> "" Then
                sql(strlog, True)
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox("Log写入错误")
        End Try
    End Sub

#End Region

#Region "读取通知"
    Public Sub noticeread()
        Dim str1 As String
        str1 = "select * from [Notice] where 是否过期='False' and 程序名='科中管理系统'"
        sql(str1, True)
        If myreader.Read Then
            If myreader.Item("通知") <> "" Then
                MsgBox(myreader.Item("通知") & vbNewLine & vbNewLine & myreader.Item("日期"))
            End If
        End If
        conn.Close()
    End Sub
#End Region

#Region "网络下载照片"
    Public Sub downloadpic()
        If My.Computer.Network.Ping("192.168.1.252", 1000) = True Then
            Try
                My.Computer.Network.DownloadFile("\\192.168.1.5\upload\安装文件\照片\" & Login.txtname.Text & ".jpg", Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\" & Login.txtname.Text & ".jpg", "elab\elab", "", False, 100, True)
                If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\" & Login.txtname.Text & ".jpg") = True Then
                    Login.PictureUser.ImageLocation = Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\" & Login.txtname.Text & ".jpg"
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
#End Region

#Region "版本检查，更新程序"

    Public Sub CheckVerList()

        Dim QuickUpdate As Boolean = False

        Finish_Update = False

        selectcmd = "select 屏蔽使用,快速升级 from [TAVerList] where 程序名 = '科中管理系统' and 版本号 = " & Version
        If sql(selectcmd, True) Then
            If myreader.Read Then
                QuickUpdate = myreader.Item("快速升级")
                If myreader.Item("屏蔽使用") = "是" Then
                    disable = True
                Else : disable = False
                End If
            End If
        End If
        conn.Close()
        update_info()
        If QuickUpdate = True And disable = False Then
            check()
        End If
        If QuickUpdate = False Then
            Finish_Update = True
        End If
    End Sub '检查当前版本是否屏蔽，确定是否启动快速升级

    Public Sub update_info()

        If disable = True Then
            selectcmd = "select 程序特点 from [TAVerList] where 程序名 = '科中管理系统' and 屏蔽使用 = '否'"
            If sql(selectcmd, True) Then
                If myreader.Read Then
                    If IsDBNull(myreader.Item("程序特点")) = False And myreader.Item("程序特点").ToString <> "" Then
                        MessageBox.Show(myreader.Item("程序特点"), "更新信息", MessageBoxButtons.OK)
                    End If
                End If
            End If
            conn.Close()
            update()
        Else : Exit Sub
        End If

    End Sub '新版本更新信息，并更新

    Public Sub check()
        Dim reso As String = Application.ExecutablePath
        Dim dest As String = "\\192.168.1.5\upload\安装文件\科中管理系统\科中管理系统.exe"
        Dim str As String = ""
        Try
            If MD5CalcFile(reso) <> MD5CalcFile(dest) Then
                update()
            Else
                For i = 0 To My.Computer.FileSystem.GetFiles(Application.StartupPath).Count - 1
                    str = Trim(My.Computer.FileSystem.GetFiles(Application.StartupPath).Item(i))
                    If Microsoft.VisualBasic.Right(str, 4) = ".dll" Then
                        If MD5CalcFile(str) <> MD5CalcFile("\\192.168.1.5\upload\安装文件\科中管理系统\" & My.Computer.FileSystem.GetName(str)) Then
                            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & My.Computer.FileSystem.GetName(str))
                            My.Computer.FileSystem.CopyFile("\\192.168.1.5\upload\安装文件\科中管理系统\" & My.Computer.FileSystem.GetName(str), str)
                        End If
                    End If
                Next
            End If

            Finish_Update = True

        Catch ex As Exception
            'MsgBox(My.Computer.FileSystem.GetName(str))
            IsErrorUpdate = True
            ErrorUpdateName = My.Computer.FileSystem.GetName(str)
        End Try
    End Sub   '检查本程序与网络程序MD5，不相同则启动快速升级更新

    Public Sub update()
        Dim AppPath As String
        AppPath = Application.StartupPath
        ReleRes(AppPath, "SetupPack", "exe")
        'MsgBox("-auto " & AppPath & "\")
        Process.Start(AppPath & "\SetupPack.exe", "-auto_Elab " & AppPath & "\")
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

    Public Sub Cmd_Update(ByVal str_name As String)
        Try
            Dim batfile As IO.StreamWriter = New IO.StreamWriter(Application.StartupPath & "\" & "Update_Dll.bat", False, System.Text.Encoding.Default)
            batfile.Write("@echo off")
            batfile.WriteLine()
            batfile.Write("ping 127.1 -n 5 >nul")
            batfile.WriteLine()
            batfile.Write("copy ""\\192.168.1.5\upload\安装文件\科中管理系统\" & str_name & """ """ & Application.StartupPath & "\" & str_name & """ && del %0")
            batfile.Close()
            batfile = Nothing
            Shell(Application.StartupPath & "\" & "Update_Dll.bat", AppWinStyle.Hide)
        Catch ex As Exception
        End Try
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

#Region "动态载入DLL"

    Public Function DLL_Import(ByVal Dll_From As String, ByVal Dll_Class As String, ByVal Panel_Father As Panel, ByVal Panel_Child As String)

        Try
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(Dll_From)
            Dim classtemp As Type = asm.GetType(Dll_Class)
            Dim obj As Form = asm.CreateInstance(classtemp.FullName)
            Panel_Father.Controls.Add(obj.Controls.Item(Panel_Child))
            obj.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "XML"

    '-- 创建 XML 文件 --
    Public Function XML_Create(ByVal XML_Path As String)
        Try
            Dim XmlWrite As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(XML_Path, System.Text.Encoding.UTF8)
            XmlWrite.WriteStartDocument() '开始一个文档
            XmlWrite.WriteStartElement("root") '开始一个元素,根元素
            XmlWrite.WriteEndElement() '关闭元素root
            XmlWrite.WriteEndDocument() '文档结束
            XmlWrite.Flush() '刷新
            XmlWrite.Close() '关闭
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '-- 插入节点及属性 --
    Public Function XML_Insert(ByVal XML_Path As String)
        Try
            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(XML_Path)
            Dim root As Xml.XmlNode = xmlDoc.SelectSingleNode("root") '查找<root> 

            Dim user_num As Xml.XmlElement = xmlDoc.CreateElement("user_num") '创建一个<num>节点 
            user_num.InnerText = usernum
            user_num.SetAttribute("id", 1) '设置该节点nextid的id属性为1

            Dim user_name As Xml.XmlElement = xmlDoc.CreateElement("user_name") '创建一个<str_name>节点 
            user_name.InnerText = username       '<str_name>节点内容为ABC
            user_name.SetAttribute("id", 2) '设置该节点nextid的id属性为1

            Dim user_authority As Xml.XmlElement = xmlDoc.CreateElement("user_authority") '创建一个<str_name>节点 
            user_authority.InnerText = authority       '<str_name>节点内容为ABC
            user_authority.SetAttribute("id", 3)

            Dim Version_App As Xml.XmlElement = xmlDoc.CreateElement("Version") '创建一个<str_name>节点 
            Version_App.InnerText = Version       '<str_name>节点内容为ABC
            Version_App.SetAttribute("id", 4)

            root.AppendChild(user_num) '将<nextid>添加到<root>节点中
            root.AppendChild(user_name) '将<str_name>添加到<nextid>节点中 
            root.AppendChild(user_authority)
            root.AppendChild(Version_App)

            xmlDoc.Save(XML_Path)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '-- 修改节点及属性 --
    Public Function XML_Edit(ByVal ID As String, ByVal node As String, ByVal content As String, ByVal XML_Path As String)
        Try
            If ID = "" Then
                MsgBox("请选择设置")
                Return False
            End If
            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(XML_Path)
            Dim nodeList As Xml.XmlNodeList = xmlDoc.SelectSingleNode("root").ChildNodes '获取root节点的所有子节点 
            Dim xn As Xml.XmlNode
            For Each xn In nodeList '遍历所有子节点 
                Dim xe As Xml.XmlElement = CType(xn, Xml.XmlElement) '将子节点类型转换为XmlElement类型
                If xe.GetAttribute("id") = ID Then
                    'xe.SetAttribute("id", 2) '则修改该属性 
                    xe.SelectSingleNode(node).InnerText = content
                End If
            Next xn
            xmlDoc.Save(XML_Path) '保存。 
            Return True
        Catch ex As Exception
            MsgBox("信息删除失败")
            Return False
        End Try
    End Function

#End Region

End Module