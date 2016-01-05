Module TA_Module

    Public CloseXuanke As Boolean      '选课是否关闭开关
    Public schoolcalendar As String    '学期（例：2013秋）

    Public Totalnum(6, 9) As Integer   '课程总量(设定初始值，防止数据库信息错误导致软件异常)
    Public YJ(), RJ() As String        '硬件、软件周次
   
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
        conn.Close()
    End Sub

    Public Function getweek() As Boolean
        selectcmd = "select 硬件周次,软件周次 from [开学日期]"
        If Sql(selectcmd, True) Then
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

#Region "读取课容量"

    Public Sub gettotalnum()
        Dim i, j As Integer
        For i = 0 To RJ(1) - YJ(0)       '第i+YJ(0)周
            For j = 0 To 6               '周j+1
                strSql = "select 课容量 from [上课日期] "
                strSql &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "' and 是否可选='是'"
                sql(strSql, True)
                If myreader.Read Then
                    Totalnum(j, i) = myreader.Item(0)
                End If
                conn.Close()
            Next
        Next
    End Sub

#End Region

End Module
