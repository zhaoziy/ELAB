Imports System.Net
Imports System.Net.Sockets
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Module ModuleShared

    Public connstr As String = "server=192.168.1.252;database=class;uid=ta;pwd=elab2013;connection timeout=5;"
    Public connstrini As String = "server=192.168.1.252;database=student;uid=ta;pwd=elab2013;connection timeout=5;"  '连接远程服务器
    'Public connstr As String = "Data Source=.;Integrated Security=True;Database=class"
    'Public connstrini As String = "Data Source=.;Integrated Security=True;Database=student"              '连接本地

    Public schoolcalendar As String    '学期（例：2013秋）
    Public startday As Date            '开学日期
    Public servertime As Date

    Public YJ(), RJ() As String        '硬件、软件周次

    Public conn As SqlConnection, cmd As SqlCommand, myreader As SqlDataReader  '数据库连接读取等相关变量
    Public strSql, selectcmd, insertcmd, updatecmd, delcmd As String            '数据库字符串储存变量

    Public localIPv4 As String        '网络接收
    Public Version As Integer = 0

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

#Region "读取学期信息"

    Public Sub init()
        selectcmd = "select 学期 from [开学日期]"
        If sql(selectcmd, True) Then
            If myreader.Read Then
                schoolcalendar = myreader.Item(0).ToString.Trim & "_"
            End If
        End If
        conn.Close()
    End Sub

    Public Function getweek() As Boolean
        selectcmd = "select 硬件周次,软件周次 from [开学日期]"
        If sql(selectcmd, True) Then
            If myreader.Read Then
                YJ = myreader.Item("硬件周次").ToString.Trim.Split("~")
                RJ = myreader.Item("软件周次").ToString.Trim.Split("~")
            Else
                Return False
                Exit Function
            End If
        Else
            Return False
            Exit Function
        End If
        conn.Close()
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

#End Region

#Region "远程唤醒"
    Public Sub Wol(ByVal MAC As String)

        Dim sck As Socket
        Dim ip As IPEndPoint

        sck = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        ip = New IPEndPoint(IPAddress.Broadcast, 10000)
        sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1)

        Dim DataBuff(101) As Byte
        Dim byt(5) As Byte
        Dim i As Int16
        Dim j As Int16

        byt(0) = Val("&H" & MAC.Substring(0, 2))
        byt(1) = Val("&H" & MAC.Substring(2, 2))
        byt(2) = Val("&H" & MAC.Substring(4, 2))
        byt(3) = Val("&H" & MAC.Substring(6, 2))
        byt(4) = Val("&H" & MAC.Substring(8, 2))
        byt(5) = Val("&H" & MAC.Substring(10, 2))

        For i = 0 To 5
            DataBuff(i) = &HFF
        Next
        For i = 1 To 16
            For j = 0 To 5
                DataBuff(i * 6 + j) = byt(j)
            Next
        Next
        sck.SendTo(DataBuff, ip)
        ip = Nothing
        sck = Nothing
    End Sub

    Public Sub WakeUp(ByVal ip As Integer)
        'selectcmd = "select MAC from [IP_MAC] where (MAC LIKE '00-23-AE-93%')"    '********外屋机器**********
        selectcmd = "select MAC from [IP_MAC] where (ip = '" & ip & "')"  '********32机器**********
        If sql(selectcmd, True) Then
            Dim mac As String
            Do While myreader.Read
                Dim s = myreader.Item(0).ToString.Split("-")
                mac = s(0) & s(1) & s(2) & s(3) & s(4) & s(5)
                Call Wol(mac)
            Loop
        End If
        conn.Close()
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

#Region "获取汉字首字母"
    '返回给定字符串的首字母
    Function IndexCode(ByVal IndexTxt As String) As String
        Dim i As Integer
        Dim IndexCode1 As String = ""
        If IndexTxt = "逯瑶" Then
            IndexCode1 = "LY"
            Return IndexCode1
            Exit Function
        ElseIf IndexTxt = "杨晟" Then
            IndexCode1 = "YS"
            Return IndexCode1
            Exit Function
        ElseIf IndexTxt = "汶东震" Then
            IndexCode1 = "WDZ"
            Return IndexCode1
            Exit Function
        ElseIf IndexTxt = "赵飒" Then
            IndexCode1 = "ZS"
            Return IndexCode1
            Exit Function
        ElseIf IndexTxt = "李子祎" Then
            IndexCode1 = "LZY"
            Return IndexCode1
            Exit Function
        End If
        For i = 1 To IndexTxt.Length
            IndexCode1 = IndexCode1 & GetOneIndex(Mid(IndexTxt, i, 1))
        Next
        Return IndexCode1
    End Function
    '得到单个字符的首字母
    Private Function GetOneIndex(ByVal OneIndexTxt As String) As String
        If Asc(OneIndexTxt) >= 0 And Asc(OneIndexTxt) < 256 Then
            GetOneIndex = OneIndexTxt
        Else
            GetOneIndex = GetX(CInt(Format((Asc(OneIndexTxt) + 65536) \ 256 - 160, "00") & Format((Asc(OneIndexTxt) + 65536) Mod 256 - 160, "00")))
        End If
    End Function
    '根据区位得到首字母
    Private Function GetX(ByVal GBCode As Integer) As String
        '判断一级汉字
        If GBCode >= 1601 And GBCode < 1637 Then GetX = "A"
        If GBCode >= 1637 And GBCode < 1833 Then GetX = "B"
        If GBCode >= 1833 And GBCode < 2078 Then GetX = "C"
        If GBCode >= 2078 And GBCode < 2274 Then GetX = "D"
        If GBCode >= 2274 And GBCode < 2302 Then GetX = "E"
        If GBCode >= 2302 And GBCode < 2433 Then GetX = "F"
        If GBCode >= 2433 And GBCode < 2594 Then GetX = "G"
        If GBCode >= 2594 And GBCode < 2787 Then GetX = "H"
        If GBCode >= 2787 And GBCode < 3106 Then GetX = "J"
        If GBCode >= 3106 And GBCode < 3212 Then GetX = "K"
        If GBCode >= 3212 And GBCode < 3472 Then GetX = "L"
        If GBCode >= 3472 And GBCode < 3635 Then GetX = "M"
        If GBCode >= 3635 And GBCode < 3722 Then GetX = "N"
        If GBCode >= 3722 And GBCode < 3730 Then GetX = "O"
        If GBCode >= 3730 And GBCode < 3858 Then GetX = "P"
        If GBCode >= 3858 And GBCode < 4027 Then GetX = "Q"
        If GBCode >= 4027 And GBCode < 4086 Then GetX = "R"
        If GBCode >= 4086 And GBCode < 4390 Then GetX = "S"
        If GBCode >= 4390 And GBCode < 4558 Then GetX = "T"
        If GBCode >= 4558 And GBCode < 4684 Then GetX = "W"
        If GBCode >= 4684 And GBCode < 4925 Then GetX = "X"
        If GBCode >= 4925 And GBCode < 5249 Then GetX = "Y"
        If GBCode >= 5249 And GBCode <= 5589 Then GetX = "Z"
        '判断二级汉字
        If GBCode >= 5601 And GBCode <= 8794 Then
            Dim CodeData As String
            CodeData = "cjwgnspgcenegypbtwxzdxykygtpjnmjqmbsgzscyjsyyfpggbzgydywjkgaljswkbjqhyjwpdzlsgmrybywwccgznkydgttngjeyekzydcjnmcylqlypyqbqrpzslwbdgkjfyxjwcltbncxjjjjcxdtqsqzycdxxhgckbphffsspybgmxjbbyglbhlssmzmpjhsojnghdzcdklgjhsgqzhxqgkezzwymcscjnyetxadzpmdssmzjjqjyzcjjfwqjbdzbjgdnzcbwhgxhqkmwfbpbqdtjjzkqhylcgxfptyjyyzpsjlfchmqshgmmxsxjpkdcmbbqbefsjwhwwgckpylqbgldlcctnmaeddksjngkcsgxlhzaybdbtsdkdylhgymylcxpycjndqjwxqxfyyfjlejbzrwccqhqcsbzkymgplbmcrqcflnymyqmsqtrbcjthztqfrxchxmcjcjlxqgjmshzkbswxemdlckfsydsglycjjssjnqbjctyhbftdcyjdgwyghqfrxwckqkxebpdjpxjqsrmebwgjlbjslyysmdxlclqkxlhtjrjjmbjhxhwywcbhtrxxglhjhfbmgykldyxzpplggpmtcbbajjzyljtyanjgbjflqgdzyqcaxbkclecjsznslyzhlxlzcghbxzhznytdsbcjkdlzayffydlabbgqszkggldndnyskjshdlxxbcghxyggdjmmzngmmccgwzszxsjbznmlzdthcqydbdllscddnlkjyhjsycjlkohqasdhnhcsgaehdaashtcplcpqybsdmpjlpcjaqlcdhjjasprchngjnlhlyyqyhwzpnccgwwmzffjqqqqxxaclbhkdjxdgmmydjxzllsygxgkjrywzwyclzmcsjzldbndcfcxyhlschycjqppqagmnyxpfrkssbjlyxyjjglnscmhcwwmnzjjlhmhchsyppttxrycsxbyhcsmxjsxnbwgpxxtaybgajcxlypdccwqocwkccsbnhcpdyznbcyytyckskybsqkkytqqxfcwchcwkelcqbsqyjqcclmthsywhmktlkjlychwheqjhtjhppqpqscfymmcmgbmhglgsllysdllljpchmjhwljcyhzjxhdxjlhxrswlwzjcbxmhzqxsdzpmgfcsglsdymjshxpjxomyqknmyblrthbcftpmgyxlchlhlzylxgsssscclsldclepbhshxyyfhbmgdfycnjqwlqhjjcywjztejjdhfblqxtqkwhdchqxagtlxljxmsljhdzkzjecxjcjnmbbjcsfywkbjzghysdcpqyrsljpclpwxsdwejbjcbcnaytmgmbapclyqbclzxcbnmsggfnzjjbzsfqyndxhpcqkzczwalsbccjxpozgwkybsgxfcfcdkhjbstlqfsgdslqwzkxtmhsbgzhjcrglyjbpmljsxlcjqqhzmjczydjwbmjklddpmjegxyhylxhlqyqhkycwcjmyhxnatjhyccxzpcqlbzwwwtwbqcmlbmynjcccxbbsnzzljpljxyztzlgcldcklyrzzgqtgjhhgjljaxfgfjzslcfdqzlclgjdjcsnclljpjqdcclcjxmyzftsxgcgsbrzxjqqcczhgyjdjqqlzxjyldlbcyamcstylbdjbyregklzdzhldszchznwczcllwjqjjjkdgjcolbbzppglghtgzcygezmycnqcycyhbhgxkamtxyxnbskyzzgjzlqjdfcjxdygjqjjpmgwgjjjpkjsbgbmmcjssclpqpdxcdyykypcjddyygywchjrtgcnyqldkljczzgzccjgdyksgpzmdlcphnjafyzdjcnmwescsglbtzcgmsdllyxqsxsbljsbbsgghfjlwpmzjnlyywdqshzxtyywhmcyhywdbxbtlmswyyfsbjcbdxxlhjhfpsxzqhfzmqcztqcxzxrdkdjhnnyzqqfnqdmmgnydxmjgdhcdycbffallztdltfkmxqzdngeqdbdczjdxbzgsqqddjcmbkxffxmkdmcsychzcmljdjynhprsjmkmpcklgdbqtfzswtfgglyplljzhgjjgypzltcsmcnbtjbhfkdhbyzgkpbbymtdlsxsbnpdkleycjnycdykzddhqgsdzsctarlltkzlgecllkjljjaqnbdggghfjtzqjsecshalqfmmgjnlyjbbtmlycxdcjpldlpcqdhsycbzsckbzmsljflhrbjsnbrgjhxpdgdjybzgdlgcsezgxlblgyxtwmabchecmwyjyzlljjshlgndjlslygkdzpzxjyyzlpcxszfgwyydlyhcljscmbjhblyjlycblydpdqysxktbytdkdxjypcnrjmfdjgklccjbctbjddbblblcdqrppxjcglzcshltoljnmdddlngkaqakgjgyhheznmshrphqqjchgmfprxcjgdychghlyrzqlcngjnzsqdkqjymszswlcfqjqxgbggxmdjwlmcrnfkkfsyyljbmqammmycctbshcptxxzzsmphfshmclmldjfyqxsdyjdjjzzhqpdszglssjbckbxyqzjsgpsxjzqznqtbdkwxjkhhgflbcsmdldgdzdblzkycqnncsybzbfglzzxswmsccmqnjqsbdqsjtxxmbldxcclzshzcxrqjgjylxzfjphymzqqydfqjjlcznzjcdgzygcdxmzysctlkphtxhtlbjxjlxscdqccbbqjfqzfsltjbtkqbsxjjljchczdbzjdczjccprnlqcgpfczlclcxzdmxmphgsgzgszzqjxlwtjpfsyaslcjbtckwcwmytcsjjljcqlwzmalbxyfbpnlschtgjwejjxxglljstgshjqlzfkcgnndszfdeqfhbsaqdgylbxmmygszldydjmjjrgbjgkgdhgkblgkbdmbylxwcxyttybkmrjjzxqjbhlmhmjjzmqasldcyxyqdlqcafywyxqhz"
            GetX = Mid(CodeData, (Microsoft.VisualBasic.Left(CStr(GBCode), 2) - 56) * 94 + (Microsoft.VisualBasic.Right(CStr(GBCode), 2)), 1)
        End If

    End Function
#End Region

#Region "log信息写入"

    Public Sub logwrite(ByVal act As String, ByVal num As String, ByVal score As String)
        Dim strlog As String = ""
        Dim strtemp As String
        Dim table1 As DataTable
        Try
            Select Case act

                Case "admin"

                    strtemp = "select 学号 from member where 姓名='" & num & "'"
                    table1 = gettable("member", strtemp, True)

                    strlog = "insert into log (操作人学号,操作时间,操作人IP,被修改人学号,登录信息,版本号,学期) values ("
                    strlog &= usernum & ",'" & GetServerTime() & "','" & localIPv4 & "','"
                    strlog &= table1.Rows(0).Item("学号") & "', '修改管理员','" & Version & "','" & schoolcalendar.Substring(0, 5) & "')"
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
                    Version = xe.SelectSingleNode("//Version").InnerText
                End If
            Next xn
        Catch ex As Exception

        End Try

        'MsgBox(usernum & username & authority)
    End Sub

#End Region

End Module