Imports System.Windows.Forms

Public Class TAAttendance

    Public zhujiang As String = ""
    Public info As String = ""
    Public myarray, dqmyarray As Array
    Public currentdate As Date
    Dim nzhujiang As Integer
    Dim nzhujiao As Boolean = True '判断是否相同，相同为true，不同为false

#Region "初始化"

    Private Sub TAAttendancePanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TAAttendancePanel.HandleCreated
        'connection() '单独调试时使用（不使用，则无法开启窗口）
        init()
        get_info()
        上课信息统计.Enabled = True
        PictureBox1.Image = Teaching_Assistant.My.Resources.Resources.back
        PictureBox2.Image = Teaching_Assistant.My.Resources.Resources.pre
        authcollect()
        list()
        loadinfo()
    End Sub

    Private Sub TAAttendancePanel_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles TAAttendancePanel.HandleDestroyed
        save()
    End Sub

#End Region

#Region "上课情况统计"

    Public Sub collection()
        Dim zhuke(300) As String
        Dim str1, str2 As String
        Dim table1, table2, table3, table4 As DataTable
        Dim i, j, k As Integer
        Dim m As Integer = 0
        Dim MyArray As Array
        Dim number As Integer = 0
        str1 = "select 主讲人姓名 from 助课人员信息 where 学期='" & schoolcalendar.Substring(0, 5) & "'"
        table1 = gettable("助课人员信息", str1, False)
        str2 = "select 姓名 from member"
        table2 = gettable("member", str2, True)
        For i = 0 To table2.Rows.Count - 1
            For j = 0 To table1.Rows.Count - 1
                If Trim(table1.Rows(j).Item("主讲人姓名")) = Trim(table2.Rows(i).Item("姓名")) Then
                    number = number + 1
                End If
            Next
            str1 = "update member set 主讲=" & number & "where 姓名='" & Trim(table2.Rows(i).Item("姓名")) & "'"
            sql(str1, True)
            conn.Close()
            number = 0
        Next
        table1.Dispose()
        table2.Dispose()

        str1 = "select 助课同学姓名 from 助课人员信息 where 学期='" & schoolcalendar.Substring(0, 5) & "'"
        table3 = gettable("助课人员信息1", str1, False)
        str2 = "select 姓名 from member"
        table4 = gettable("member1", str2, True)

        For j = 0 To table3.Rows.Count - 1
            If IsDBNull(table3.Rows(j).Item("助课同学姓名")) = False Then
                MyArray = Split(Trim(table3.Rows(j).Item("助课同学姓名")), , )
                For k = 0 To MyArray.Length - 1
                    zhuke(m) = MyArray(k)
                    m = m + 1
                Next
            End If
        Next

        For i = 0 To table4.Rows.Count - 1
            For k = 0 To m - 1
                If zhuke(k) = Trim(table4.Rows(i).Item("姓名")) Then
                    number = number + 1
                End If
            Next
            str1 = "update member set 助课=" & number & "where 姓名='" & Trim(table4.Rows(i).Item("姓名")) & "'"
            sql(str1, True)
            conn.Close()
            number = 0
        Next
        table3.Dispose()
        table4.Dispose()

    End Sub '统计所有助教主讲和助课次数

    Public Sub authcollect()
        If GetServerTime().Date = DateTimePicker1.Value.Date Then
            上课信息统计.Enabled = True
        ElseIf authority = 8 Then
            上课信息统计.Enabled = True
        Else
            上课信息统计.Enabled = False
        End If
    End Sub '判断权限，普通助教只可以修改当天上课情况统计，管理员可以修改所有天

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, DateTimePicker1.Value.Date)
    End Sub '前一天按钮

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, 1, DateTimePicker1.Value.Date)
    End Sub '后一天按钮

    Private Sub ListBox3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.DoubleClick
        Try
            If ListBox3.SelectedItem.ToString = "" Then
                Exit Sub
            Else
                If MessageBox.Show("确定要移除？", "提示", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    ListBox3.Items.Remove(ListBox3.SelectedItem.ToString())
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub '移除姓名

    Private Sub ListBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.DoubleClick
        Try
            If ListBox2.SelectedItem.ToString = "" Then
                Exit Sub
            Else
                If MessageBox.Show("确定要移除？", "提示", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    ListBox2.Items.Remove(ListBox2.SelectedItem.ToString())
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub '移除姓名

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Dim i As Integer
        Dim flag1 As Boolean = False
        Dim flag2 As Boolean = False
        If ListBox1.SelectedItem = "" Then
            Exit Sub
        ElseIf rb4.Checked = True Then
            For i = 0 To ListBox3.Items.Count - 1
                If ListBox1.SelectedItem.ToString() = ListBox3.Items(i) Then
                    flag1 = True
                End If
            Next
            If flag1 = False Then
                ListBox2.Items.Clear()
                ListBox2.Items.Add(ListBox1.SelectedItem.ToString())
            End If
        ElseIf rb5.Checked = True Then
            For i = 0 To ListBox3.Items.Count - 1
                If ListBox1.SelectedItem.ToString() = ListBox3.Items(i) Then
                    flag2 = True
                ElseIf ListBox2.Items.Count = 0 Then
                    flag2 = False
                ElseIf ListBox1.SelectedItem.ToString() = ListBox2.Items(0) Then
                    flag2 = True
                End If
            Next
            If flag2 = False Then
                ListBox3.Items.Add(ListBox1.SelectedItem.ToString())
            End If
        End If
    End Sub '选择姓名

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim str As String = ""
        Dim names(170), fa(170) As String  '汉字首字母
        ListBox1.Items.Clear()

        strSql = "select distinct 姓名 from [member]"
        sql(strSql, True)
        While myreader.Read
            names(j) = myreader("姓名").ToString
            fa(j) = IndexCode(myreader("姓名").ToString)

            For k = 1 To Len(fa(j))
                If Asc(Mid(fa(j), k, 1)) < 91 Then
                    str = str & Chr(Asc(Mid(fa(j), k, 1)) + 32)
                Else : str = str & Mid(fa(j), k, 1)
                End If
            Next

            If TextBox4.Text = Mid(str, 1, Len(TextBox4.Text)) Then
                ListBox1.Items.Add(names(j))
            End If
            j = j + 1
            str = ""

        End While
        conn.Close()
    End Sub '姓名首字母查询

    Private Sub list()
        Me.ListBox1.Items.Clear()
        Me.ListBox2.Items.Clear()
        Me.ListBox3.Items.Clear()
        Try
            strSql = "select distinct 姓名 from [member]"
            sql(strSql, True)
            While myreader.Read
                If Asc(myreader("姓名").ToString) = 63 Then Continue While
                ListBox1.Items.Add(myreader("姓名"))
            End While
            conn.Close()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub 'listbox1列表

    Private Sub loadinfo()
        Dim month As String
        Dim day As String

        currentdate = Me.DateTimePicker1.Value

        If Me.DateTimePicker1.Value.Month < 10 Then
            month = "0" & Me.DateTimePicker1.Value.Month
        Else : month = Me.DateTimePicker1.Value.Month
        End If
        If Me.DateTimePicker1.Value.Day < 10 Then
            day = "0" & Me.DateTimePicker1.Value.Day
        Else : day = Me.DateTimePicker1.Value.Day
        End If

        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        rb4.Checked = True

        strSql = "select * from [助课人员信息] where Convert(varchar(100),上课日期,111) = '" & Me.DateTimePicker1.Value.Year & "/" & month & "/" & day & "'"
        sql(strSql, False)
        If myreader.Read = True Then
            ListBox2.Items.Add(myreader.Item("主讲人姓名"))
            myarray = Split(Trim(myreader.Item("助课同学姓名")), , )
            zhujiang = myreader.Item("主讲人姓名")

            Dim i As Integer
            For i = 0 To myarray.Length - 1
                If myarray(i) <> "" Then
                    ListBox3.Items.Add(myarray(i))
                End If
            Next

            If IsDBNull(myreader.Item("上课情况")) Then
                TextBox3.Text = ""
            Else
                TextBox3.Text = myreader.Item("上课情况")
                info = myreader.Item("上课情况")
            End If
        Else
            Dim str2 As String = ""
            myarray = Split(Trim(str2), , )
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            TextBox3.Text = ""
        End If
        conn.Close()
    End Sub '读取上课情况统计信息

    Private Sub savezhujiang()

        Dim listbox As String
        If ListBox2.Items.Count = 0 Then
            listbox = ""
        Else
            listbox = ListBox2.Items(0).ToString
        End If
        nzhujiang = String.Compare(zhujiang, listbox)
        If nzhujiang = 0 Then
            zhujiang = ""
            Exit Sub
        Else
            Dim month As String
            Dim day As String
            Dim str As String = ""

            If currentdate.Month < 10 Then
                month = "0" & currentdate.Month
            Else : month = currentdate.Month
            End If
            If currentdate.Day < 10 Then
                day = "0" & currentdate.Day
            Else : day = currentdate.Day
            End If

            strSql = "select 主讲人姓名 from [助课人员信息] where Convert(varchar(100),上课日期,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
            sql(strSql, False)
            If myreader.Read = True Then
                str = "update 助课人员信息 set 学期='" & schoolcalendar.Substring(0, 5) & "', 主讲人姓名='" & listbox & "' where Convert(varchar(100),上课日期,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
                sql(str, False)
            ElseIf listbox <> "" Then
                str = "insert into 助课人员信息 (主讲人姓名,助课同学姓名,上课情况,上课日期,学期) values ('"
                str &= listbox & "','','','" & currentdate.Year & "/" & month & "/" & day & "','" & schoolcalendar.Substring(0, 5) & "')"
                sql(str, False)
            End If
            conn.Close()

            If listbox <> "" Then
                logwrite("zhujiang", listbox, "主讲人")
            End If

        End If
        zhujiang = ""
    End Sub '保存主讲人

    Private Sub savezhujiao()

        Dim i, j As Integer
        Dim m As Boolean = False
        Dim str1 As String = ""

        nzhujiao = True

        For i = 0 To ListBox3.Items.Count - 1
            str1 = str1 & ListBox3.Items(i) & " "
        Next

        dqmyarray = Split(Trim(str1), , )

        If dqmyarray.Length = myarray.Length Then
            For i = 0 To myarray.Length - 1
                m = False   '没有m，则修改前后人数相同时，无法提交数据（2014-4-26）
                For j = 0 To dqmyarray.Length - 1
                    If myarray(i) = dqmyarray(j) Then
                        m = True
                        Exit For
                    End If
                Next
                If m = False Then
                    nzhujiao = False   'nzhujiao=false时则进行数据提交，为true时则认为前后数据没有变化。（2014-4-26）
                    Exit For
                End If
            Next
        Else
            nzhujiao = False
        End If

        If nzhujiao = True Then
            Array.Clear(dqmyarray, 0, dqmyarray.Length)
            Exit Sub
        Else
            Dim month As String
            Dim day As String
            Dim str As String
            Dim str2 As String = ""

            If currentdate.Month < 10 Then
                month = "0" & currentdate.Month
            Else : month = currentdate.Month
            End If
            If currentdate.Day < 10 Then
                day = "0" & currentdate.Day
            Else : day = currentdate.Day
            End If

            For i = 0 To ListBox3.Items.Count - 1
                str2 = str2 & ListBox3.Items(i) & " "
            Next

            strSql = "select 主讲人姓名 from [助课人员信息] where Convert(varchar(100),上课日期,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
            sql(strSql, False)
            If myreader.Read = True Then
                str = "update 助课人员信息 set 学期='" & schoolcalendar.Substring(0, 5) & "', 助课同学姓名='" & Trim(str2) & "' where Convert(varchar(100),上课日期,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
                sql(str, False)
            ElseIf Trim(str2) <> "" Then
                str = "insert into 助课人员信息 (主讲人姓名,助课同学姓名,上课情况,上课日期,学期) values ('"
                str &= "','" & Trim(str2) & "','','" & currentdate.Year & "/" & month & "/" & day & "','" & schoolcalendar.Substring(0, 5) & "')"
                sql(str, False)
            End If
            conn.Close()

            For i = 0 To ListBox3.Items.Count - 1
                If ListBox3.Items(i) <> "" Then
                    logwrite("zhujiao", ListBox3.Items(i), "助教同学")
                End If
            Next

        End If
        Array.Clear(dqmyarray, 0, dqmyarray.Length)
    End Sub '保存助课同学

    Private Sub saveinfo()
        Dim ninfo As Integer
        ninfo = String.Compare(info, TextBox3.Text)
        If ninfo = 0 Then
            info = ""
            Exit Sub
        Else
            Dim month As String
            Dim day As String
            Dim str As String = ""

            If currentdate.Month < 10 Then
                month = "0" & currentdate.Month
            Else : month = currentdate.Month
            End If
            If currentdate.Day < 10 Then
                day = "0" & currentdate.Day
            Else : day = currentdate.Day
            End If

            strSql = "select * from [助课人员信息] where Convert(varchar(100),上课日期,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
            sql(strSql, False)
            If myreader.Read = True Then
                str = "update 助课人员信息 set 学期='" & schoolcalendar.Substring(0, 5) & "', 上课情况='" & TextBox3.Text & "' where Convert(varchar(100),上课日期,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
                sql(str, False)
            ElseIf TextBox3.Text <> "" Then
                str = "insert into 助课人员信息 (主讲人姓名,助课同学姓名,上课情况,上课日期,学期) values ('"
                str &= "','','" & TextBox3.Text & "','" & currentdate.Year & "/" & month & "/" & day & "','" & schoolcalendar.Substring(0, 5) & "')"
                sql(str, False)
            End If
            conn.Close()
        End If
        info = ""
    End Sub  '保存上课情况

    Public Sub save()
        savezhujiang()
        savezhujiao()
        saveinfo()
        loadinfo()
        If nzhujiang <> 0 Or nzhujiao <> True Then
            collection()
        End If
    End Sub '保存过程，包含刷新

#End Region

#Region "日期前进后退按钮图案变化"

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.Image = Teaching_Assistant.My.Resources.Resources.back_1
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = Teaching_Assistant.My.Resources.Resources.back
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.Image = Teaching_Assistant.My.Resources.Resources.pre_1
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = Teaching_Assistant.My.Resources.Resources.pre
    End Sub

#End Region

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        authcollect()
        save()
    End Sub

    Private Sub ListBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.MouseEnter
        ListBox1.Focus()
    End Sub

    Private Sub ListBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.MouseEnter
        ListBox3.Focus()
    End Sub

End Class