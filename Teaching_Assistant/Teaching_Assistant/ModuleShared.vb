Imports System.Net
Imports System.Data.SqlClient
Imports System.Windows.Forms

Module ModuleShared

    Public connstr As String = "server=192.168.1.252;database=class;uid=ta;pwd=elab2013;connection timeout=5;"
    Public connstrini As String = "server=192.168.1.252;database=student;uid=ta;pwd=elab2013;connection timeout=5;"  '连接远程服务器
    'Public connstr As String = "Data Source=.;Integrated Security=True;Database=class"
    'Public connstrini As String = "Data Source=.;Integrated Security=True;Database=student"              '连接本地

    Public CloseXuanke As Boolean      '选课是否关闭开关
    Public schoolcalendar As String    '学期（例：2013秋）
    Public startday As Date            '开学日期
    Public schoolday As String         '校历（第几周周几）
    Public servertime As Date

    Public YJ(), RJ() As String        '硬件、软件周次

    Public conn As SqlConnection, cmd As SqlCommand, myreader As SqlDataReader  '数据库连接读取等相关变量
    Public strSql, selectcmd, insertcmd, updatecmd, delcmd As String            '数据库字符串储存变量

    Public localIPv4 As String        '网络接收

    Public Version As String = 0     '程序版本

#Region "读取上课学期，开始日期，软硬件上课时间等信息"

    Public Sub init()
        selectcmd = "select 学期,开学日期,关闭选课,课容量 from [开学日期]"
        If sql(selectcmd, True) Then
            If myreader.Read Then
                schoolcalendar = myreader.Item(0).ToString.Trim & "_"
                startday = myreader.Item(1)
                CloseXuanke = myreader.Item(2)
            End If
        End If
        checkip()
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

    Public Sub Getschoolday()
        Dim weeks As Integer
        Dim days As Integer

        weeks = DateDiff(DateInterval.DayOfYear, startday, DateTime.Now) \ 7 + 1
        days = DateDiff(DateInterval.DayOfYear, startday, DateTime.Now) Mod 7 + 1

        schoolday = "第" & weeks & "周 " & GetDay(days)

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

    Public Function gettable(ByVal tablename As String, ByVal sqlstr As String, ByVal ini As Boolean) As DataTable
        If ini = True Then
            conn = New SqlConnection(connstrini)
        Else
            conn = New SqlConnection(connstr)
        End If
        Dim adapter As New SqlDataAdapter(sqlstr, conn)
        Dim timeds As New DataSet
        Try
            conn.Open()
            timeds.Clear()
            adapter.Fill(timeds, tablename)
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