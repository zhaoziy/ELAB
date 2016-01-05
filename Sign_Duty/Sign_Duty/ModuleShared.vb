Imports System.Data.SqlClient

Module ModuleShared

    Public StartDay As Date
    Public schoolcalendar As String    '学期（例：2015秋）
    Public NowWeek As Integer

    Public connstr As String = "server=192.168.1.252;database=student;uid=ta;pwd=elab2013;connection timeout=5;"  '连接远程服务器
    'Public connstr As String = "Data Source=.;Integrated Security=True;Database=student"

    Public conn As SqlConnection, cmd As SqlCommand, myreader As SqlDataReader
    Public selectcmd As String
    Public adapter As New SqlDataAdapter

#Region "SQl连接_w"
    Public Sub sql_w(ByVal connstr As String, ByVal sqlcmd As String)
        conn = New SqlConnection(connstr)
        Try
            conn.Open()
            cmd = New SqlCommand(sqlcmd, conn)
            myreader = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn.Close()
        End Try
    End Sub

    Public Function gettable_w(ByVal connstr As String, ByVal sqlstr As String) As DataTable
        conn = New SqlConnection(connstr)
        adapter = New SqlDataAdapter(sqlstr, conn)
        Dim timeds = New DataSet
        Try
            conn.Open()
            timeds.Clear()
            adapter.Fill(timeds, "duty")

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn.Close()
        End Try
        Return timeds.Tables("duty")
    End Function

#End Region

#Region "SQL连接"

    Public Sub sql(ByVal sqlcmd As String)
        conn = New SqlConnection(connstr)
        Try
            conn.Open()
            cmd = New SqlCommand(sqlcmd, conn)
            myreader = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.ToString)
            conn.Close()
        End Try
    End Sub

    Public Function gettable(ByVal tablename As String, ByVal sqlstr As String) As DataTable
        conn = New SqlConnection(connstr)
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

#Region "获取当前校历第几周以及学期"

    Public Function GetWeek() As Integer

        selectcmd = "select * from 开学日期"
        sql(selectcmd)
        If myreader.Read Then
            Try
                StartDay = myreader.Item("开学日期")
                schoolcalendar = myreader.Item("学期").ToString.Trim
            Catch ex As Exception
                MsgBox("请先设定开学日期")
                Exit Function
            End Try
        Else
            MsgBox("请先设定开学日期!")
            Exit Function
        End If
        conn.Close()

        Dim days As Integer = DateDiff("d", StartDay, Now.ToShortDateString)
        GetWeek = days \ 7 + 1

    End Function

#End Region

#Region "获取服务器时间"

    '返回当前服务器时间，错误返回"1991-01-01 00:00:00"
    Public Function ServerTime() As Date
        Dim nowtime As Date
        sql("select convert(varchar(20),getdate(),20) as date")
        If myreader.Read = True Then
            nowtime = myreader.Item("date")
        Else
            nowtime = New Date(1991, 1, 1, 0, 0, 0)
        End If
        conn.Close()
        conn.Dispose()
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

#End Region

End Module