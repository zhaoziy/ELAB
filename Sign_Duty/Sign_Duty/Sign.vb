Public Class Sign

    Public Online_Num As Integer = 0  '在线人数
    Dim count As Integer
    Dim fn_pre As String = "0:0:1"  '记录前一次离去人的离去时间，与新数据比较，如有变化，则b改为false

#Region "自定义事件"

    Sub ShuaXin()

        Dim selectcmd As String
        ListView1.Items.Clear()
        Me.Lb显示在线.Clear()
        Lb显示在线.View = Windows.Forms.View.List

        Online_Num = 0                 '在线人数
        '*******************查询是否存在该成员***********************
        selectcmd = "select * from 时间统计 where 日期='" & DateTimePicker1.Value.Date & "'"
        sql(selectcmd)
        Try
            Dim fnext As Boolean = True  '判断是否有下一个结果，如果没有则跳出循环
            Dim n As Integer = 0
            Do Until Not fnext
                Do While myreader.Read '**********************加载到listview************************
                    Dim name As String = myreader.Item("姓名").ToString()
                    Me.ListView1.Items.Add(myreader.Item("学号"))
                    Me.ListView1.Items(n).SubItems.Add(myreader.Item("姓名"))
                    Me.ListView1.Items(n).SubItems.Add(myreader.Item("组别"))
                    Me.ListView1.Items(n).SubItems.Add(myreader.Item("日期"))
                    Me.ListView1.Items(n).SubItems.Add(myreader.Item("周次"))
                    Me.ListView1.Items(n).SubItems.Add(myreader.Item("登入"))
                    Me.ListView1.Items(n).SubItems.Add(myreader.Item("离开"))
                    Me.ListView1.Items(n).SubItems.Add(myreader.Item("合计时间"))
                    n += 1
                    If myreader.Item("离开").ToString.Trim = "0" Then
                        Me.Lb显示在线.Items.Add(name)
                        Online_Num += 1
                    End If
                Loop
                fnext = myreader.NextResult
            Loop
            conn.Close()
        Catch ex As Exception
            conn.Close()
        End Try

    End Sub

    Private Sub renewsemester()
        Dim selectcmd, Sem As String
        selectcmd = "select distinct 日期 from 时间统计 where 学期 is null"
        Dim table As New DataTable
        table = gettable("时间统计", selectcmd)
        Dim i As Integer
        For i = 0 To table.Rows.Count - 1
            If DateDiff(DateInterval.Day, CDate(table.Rows(i).Item(0).ToString.Substring(0, 4) & "-8-1"), CDate(table.Rows(i).Item(0).ToString)) < 20 Then
                Sem = table.Rows(i).Item(0).ToString.Substring(0, 4) & "春"
            Else
                Sem = table.Rows(i).Item(0).ToString.Substring(0, 4) & "秋"
            End If
            selectcmd = "update 时间统计 set 学期='" & Sem & "' where 日期='" & table.Rows(i).Item(0).ToString & "'"
            sql(selectcmd)
            conn.Close()
        Next
        table.Dispose()

        selectcmd = "select distinct 日期 from sduty where 学期 is null"
        Dim table1 As New DataTable
        table1 = gettable("sduty", selectcmd)
        For i = 0 To table1.Rows.Count - 1
            If DateDiff(DateInterval.Day, CDate(table1.Rows(i).Item(0).ToString.Substring(0, 4) & "-8-1"), CDate(table1.Rows(i).Item(0).ToString)) < 20 Then
                Sem = table1.Rows(i).Item(0).ToString.Substring(0, 4) & "春"
            Else
                Sem = table1.Rows(i).Item(0).ToString.Substring(0, 4) & "秋"
            End If
            selectcmd = "update sduty set 学期='" & Sem & "' where 日期='" & table1.Rows(i).Item(0).ToString & "'"
            sql(selectcmd)
            conn.Close()
        Next
        table1.Dispose()
    End Sub

    Private Sub lognew()

        Dim a As Boolean = False   '判断新到信息是否与之前相同，相同为true
        Dim b As Boolean = False   '判断离开信息是否与之前相同，相同为true
        Dim c As Boolean = False   '判断数据条数与之前是否相同，相同则为true
        Dim count_temp As Integer = 0
        Dim fn As String = "0:0:0"

        Dim xm As String = ""
        Dim array1 As Array
        Dim array2 As Array

        Try
            selectcmd = "select top 1 * from 时间统计 where 日期='" & DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day & "' order by id desc"
            sql(selectcmd)
            If myreader.Read = True Then
                xm = Trim(myreader.Item("姓名").ToString)
                If Me.Label2.Text = xm Then
                    a = True
                Else
                    Me.Label2.Text = xm
                End If
            End If
            conn.Close()

            selectcmd = "select * from 时间统计 where 日期='" & DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day & "'"
            sql(selectcmd)

            Dim fnext As Boolean = True
            Do Until Not fnext
                Do While myreader.Read '**********************加载到listview***********************
                    count_temp += 1
                    array1 = Split(fn, ":")
                    array2 = Split(myreader.Item("离开"), ":")
                    If array2.Length = 1 Then
                        Continue Do
                    ElseIf CInt(array2(0)) > CInt(array1(0)) Then
                        fn = myreader.Item("离开")
                        xm = Trim(myreader.Item("姓名").ToString)
                    ElseIf CInt(array2(0)) = CInt(array1(0)) Then

                        If CInt(array2(1)) > CInt(array1(1)) Then
                            fn = myreader.Item("离开")
                            xm = Trim(myreader.Item("姓名").ToString)
                        ElseIf CInt(array2(1)) = CInt(array1(1)) Then

                            If CInt(array2(2)) >= CInt(array1(2)) Then
                                fn = myreader.Item("离开")
                                xm = Trim(myreader.Item("姓名").ToString)
                            Else
                                Continue Do
                            End If
                        Else
                            Continue Do
                        End If
                    Else
                        Continue Do
                    End If
                Loop
                fnext = myreader.NextResult
            Loop
            conn.Close()
            If count = count_temp Then
                c = True
            Else
                count = count_temp
            End If

            If fn <> "0:0:0" Then
                If Me.Label3.Text = xm Then
                    b = True
                Else
                    Me.Label3.Text = xm
                End If
            Else
                b = True
            End If

            If fn <> "0:0:0" Then
                If fn_pre = fn Then
                    b = True
                Else
                    fn_pre = fn
                    b = False
                End If
            Else
                b = True
            End If

            If a = True And b = True And c = True Then
            Else
                ShuaXin()
            End If
        Catch ex As Exception
            conn.Close()
        End Try
    End Sub

#End Region

#Region "窗体事件"

    Private Sub Sign_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sign_Panel.HandleCreated

        Label2.Text = String.Empty
        Label3.Text = String.Empty
        Lb显示在线.Clear()
        Lb显示在线.View = Windows.Forms.View.List

        lognew()
        ShuaXin()

        Timer1.Interval = 5000
        Timer1.Start()

        renewsemester()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lognew()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Me.Label2.Text = String.Empty
        Me.Label3.Text = String.Empty
        lognew()
    End Sub

    Private Sub Lb显示在线_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lb显示在线.MouseEnter
        Lb显示在线.Focus()
    End Sub

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

#End Region

End Class
