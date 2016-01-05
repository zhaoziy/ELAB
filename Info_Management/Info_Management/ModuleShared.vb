Imports System.Net
Imports System.Data.SqlClient
Imports System.Windows.Forms

Module ModuleShared

    Public connstr As String = "server=192.168.1.252;database=class;uid=ta;pwd=elab2013;connection timeout=5;"
    Public connstrini As String = "server=192.168.1.252;database=student;uid=ta;pwd=elab2013;connection timeout=5;"  '连接远程服务器
    'Public connstr As String = "Data Source=.;Integrated Security=True;Database=class"
    'Public connstrini As String = "Data Source=.;Integrated Security=True;Database=student"              '连接本地

    Public prepwd As String            '密码对话框储存原密码变量

    Public schoolcalendar As String    '学期（例：2015秋）
    Public schoolday As String         '校历（第几周周几）
    Public startday As Date            '开学日期
    Public servertime As Date

    Public flag As String = "update"             '判断成员信息管理中是“添加用户”还是“更新用户”

    Public conn As SqlConnection, cmd As SqlCommand, myreader As SqlDataReader  '数据库连接读取等相关变量
    Public strSql, selectcmd, insertcmd, updatecmd, delcmd As String            '数据库字符串储存变量

    Public localIPv4 As String        '网络接收

    Public Version As String = 0     '程序版本

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

        weeks = DateDiff(DateInterval.DayOfYear, startday, DateTime.Now) \ 7 + 1
        days = DateDiff(DateInterval.DayOfYear, startday, DateTime.Now) Mod 7 + 1

        schoolday = "第" & weeks & "周 " & GetDay(days)

    End Sub
#End Region

#Region "检测ipv4"

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

#Region "连接服务器，读取上课学期，开始日期，软硬件上课时间等信息"

    Public Sub init()
        selectcmd = "select 学期,开学日期,关闭选课,课容量 from [开学日期]"
        If sql(selectcmd, True) Then
            If myreader.Read Then
                schoolcalendar = myreader.Item(0).ToString.Trim & "_"
            End If
        End If
        conn.Close()
    End Sub

#End Region

#Region "MD5加密"
    Public Function MD5(ByVal strSource As String, ByVal Code As Int16) As String
        Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(strSource)
        Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)
        Dim ATR As String = ""
        Dim i As Integer
        Select Case Code
            Case 16      '选择16位字符的加密结果
                For i = 4 To 11
                    ATR += Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
            Case 32      '选择32位字符的加密结果
                For i = 0 To 15
                    ATR += Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
            Case Else       'Code错误时，返回全部字符串，即32位字符
                For i = 0 To 15
                    ATR += Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
        End Select
        Return ATR
    End Function
#End Region

#Region "执行SQL语句函数"

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

#Region "Excel操作相关函数"

    Public exapp As Microsoft.Office.Interop.Excel.Application '定义excel应用程序
    Public exbook As Microsoft.Office.Interop.Excel.Workbook '定义工作簿
    Public exsheet As Microsoft.Office.Interop.Excel.Worksheet '定义工作表

    Function exsta() As Integer
        exapp.Visible = True     '显示excel 程序
        exbook = exapp.Workbooks.Add()    '添加新工作簿
        exsheet = exbook.Sheets(1)     '获得第n个工作表的控制句柄,后面就由它处理了
    End Function

    Function exsto(ByVal str As String) As Integer
        Try
            exbook.SaveAs(str)
            exsheet = Nothing
            exbook.Close()
            exbook = Nothing
            exapp.Quit()
            exapp = Nothing
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function

    Function printe(ByVal x As Integer, ByVal y As Integer, ByVal str As String) As Integer
        exsheet.Cells(x, y) = str      '对指定单元格赋值,这个操作大量出现哦
    End Function

    Public Sub setpaper(ByVal top As Single, ByVal bottom As Single, ByVal left As Single, ByVal right As Single)
        Try
            exsheet.PageSetup.TopMargin = top / 0.035
            exsheet.PageSetup.BottomMargin = bottom / 0.035
            exsheet.PageSetup.LeftMargin = left / 0.035
            exsheet.PageSetup.RightMargin = right / 0.035
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

#Region "获取服务器时间"
    Public Function GetServerTime() As Date
        Dim str As String
        str = "select ServerDateTime=getdate() "
        sql(str, True)      '得到数据库服务器时间
        If myreader.Read() Then
            servertime = myreader.Item(0)
        End If
        Return servertime
        conn.Close()
    End Function
#End Region

#Region "获取权限"

    Public Sub get_info()
        Try
            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(Application.StartupPath & "\elab.xml")
            Dim nodeList As Xml.XmlNodeList = xmlDoc.SelectSingleNode("root").ChildNodes '获取root节点的所有子节点 
            Dim xn As Xml.XmlNode
            For Each xn In nodeList '遍历所有子节点 
                Dim xe As Xml.XmlElement = CType(xn, Xml.XmlElement) '将子节点类型转换为XmlElement类型
                If xe.GetAttribute("id") = 1 Then
                    usernum = xe.SelectSingleNode("//user_num").InnerText
                End If
                If xe.GetAttribute("id") = 2 Then
                    username = xe.SelectSingleNode("//user_name").InnerText
                End If
                If xe.GetAttribute("id") = 3 Then
                    authority = xe.SelectSingleNode("//user_authority").InnerText
                End If
                If xe.GetAttribute("id") = 4 Then
                    Version = xe.SelectSingleNode("//Version_App").InnerText
                End If
            Next xn
        Catch ex As Exception

        End Try

        'MsgBox(usernum & username & authority)
    End Sub

#End Region

End Module