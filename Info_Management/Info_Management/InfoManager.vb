Imports System.Windows.Forms
Imports System.Drawing

Public Class infomanager
    Public biao As String
    Public biao2 As String = "member"
    Public line As Integer = 0

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Try
            line = Me.ListView1.Items.IndexOf(Me.ListView1.SelectedItems.Item(0))
            member()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Info_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Info.SelectedIndexChanged
        If Info.SelectedTab.Text = "所有成员" Then
            switch("allmember")
        ElseIf Info.SelectedTab.Text = "上课同学" Then
            switch("allclass")
        ElseIf Info.SelectedTab.Text = "搜索结果" Then
            switch("result")
        End If
    End Sub

    Public Sub switch(ByVal act As String)
        Select Case act
            Case "allmember"
                GroupBox2.Visible = True
                GroupBox2.Enabled = True
                RadioButton2.Checked = True
                member()
            Case "result"
                If RadioButton1.Checked = True Then
                    GroupBox2.Visible = False
                    GroupBox2.Enabled = False
                Else
                    GroupBox2.Visible = True
                    GroupBox2.Enabled = True
                End If
            Case "allclass"
                GroupBox2.Visible = False
                GroupBox2.Enabled = False
                RadioButton1.Checked = True
                allclass()
        End Select
    End Sub '界面切换

#Region "窗体事件"

    Private Sub InfoManagerPanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles InfoManagerPanel.HandleCreated

        'init()      '调试时使用
        'get_info()

        biao = schoolcalendar & "计算机安装与调试技术"
        allclass()
        member()
        Info.SelectedIndex = 0
        If authority = 0 Then
            GroupBox2.Visible = False
            GroupBox2.Enabled = False
            RadioButton2.Visible = False
            RadioButton2.Enabled = False
            RadioButton1.Checked = True
        ElseIf authority = 9 Then
            GroupBox2.Visible = False
            GroupBox2.Enabled = False
            RadioButton2.Checked = True
        ElseIf authority = 8 Then
            RadioButton2.Checked = True
        End If

        Me.ComboBDept.Items.Clear()
        Try
            strSql = "select distinct 院系 from [" & biao & "]"
            sql(strSql, False)
            While myreader.Read
                If Asc(myreader("院系").ToString) = 63 Then Continue While
                ComboBDept.Items.Add(myreader("院系"))
            End While
            conn.Close()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Public Sub member()
        Dim i As Integer = 0
        ListView1.Items.Clear()
        strSql = "select * from member"
        ColumnHeader1.Width = 78
        ColumnHeader2.Width = 72
        ColumnHeader3.Width = 72
        ColumnHeader4.Width = 45
        ColumnHeader5.Width = 72
        ColumnHeader6.Width = 72
        ColumnHeader7.Width = 150
        ColumnHeader8.Width = 45
        ColumnHeader17.Width = 95
        ColumnHeader18.Width = 80
        ColumnHeader30.Width = 82
        Try
            If sqlnoerr(strSql, True) Then
                Do While myreader.Read '**********************查询成员************************
                    Me.ListView1.Items.Add((myreader("学号").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("USERNAME").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("姓名").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("性别").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("主讲").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("助课").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("院系").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("年级").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("电话").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("职务").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("组别").ToString))
                    i += 1
                Loop
            End If
            ListView1.Items(line).Selected = True
            conn.Close()
        Catch ex As Exception
            MsgBox("读取不到助教同学信息，请联系管理员")
            conn.Close()
        End Try
    End Sub '读取member表，科中成员信息

    Public Sub allclass()
        Dim i As Integer = 0
        ListView3.Items.Clear()
        strSql = "select * from [" & biao & "]"
        ColumnHeader21.Width = 78
        ColumnHeader22.Width = 72
        ColumnHeader23.Width = 150
        ColumnHeader24.Width = 72
        ColumnHeader25.Width = 72
        ColumnHeader26.Width = 72
        ColumnHeader27.Width = 72
        ColumnHeader28.Width = 72
        ColumnHeader29.Width = 95
        Try
            If sqlnoerr(strSql, False) Then
                Do While myreader.Read '**********************查询成员************************
                    Me.ListView3.Items.Add((myreader("学号").ToString))
                    Me.ListView3.Items(i).SubItems.Add((myreader("姓名").ToString))
                    Me.ListView3.Items(i).SubItems.Add((myreader("院系").ToString))
                    Me.ListView3.Items(i).SubItems.Add((myreader("硬件时间").ToString))
                    Me.ListView3.Items(i).SubItems.Add((myreader("软件时间").ToString))
                    Me.ListView3.Items(i).SubItems.Add(Trim(myreader("硬件成绩").ToString))
                    Me.ListView3.Items(i).SubItems.Add((myreader("软件成绩").ToString))
                    Me.ListView3.Items(i).SubItems.Add((myreader("试卷成绩").ToString))
                    Me.ListView3.Items(i).SubItems.Add((myreader("联系电话").ToString))
                    i += 1
                Loop
            End If
            ListView3.Items(line).Selected = True
            conn.Close()
        Catch ex As Exception
            MsgBox("读取不到上课同学信息，请联系管理员")
            conn.Close()
        End Try
    End Sub '读取class表，科中成员信息

#End Region

#Region "按钮事件"

    Private Sub Addmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Addmember.Click
        flag = "add"
        Dim add As New ChangeInfo
        add.ShowDialog()
        member()
        add.Dispose()
    End Sub

    Private Sub Upmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Upmember.Click
        flag = "update"
        Dim updatemem As New ChangeInfo
        Try
            If Info.SelectedIndex = Info.TabPages.IndexOf(Searchresult) Then
                updatemem.GetNum = ListView2.SelectedItems.Item(0).Text
            ElseIf Info.SelectedIndex = Info.TabPages.IndexOf(AllMemeber) Then
                updatemem.GetNum = ListView1.SelectedItems.Item(0).Text
            End If
            updatemem.ShowDialog()
            member()
        Catch ex As Exception
        End Try
        updatemem.Dispose()
    End Sub

    Private Sub Delmember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delmember.Click
        If MsgBox("确认删除么？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                If Info.SelectedIndex = Info.TabPages.IndexOf(Searchresult) Then
                    delcmd = "delete from member where 学号 = " & ListView2.SelectedItems.Item(0).Text
                    sql(delcmd, True)
                    Call searchone()
                ElseIf Info.SelectedIndex = Info.TabPages.IndexOf(AllMemeber) Then
                    delcmd = "delete from member where 学号 = " & ListView1.SelectedItems.Item(0).Text
                    sql(delcmd, True)
                End If
            Catch ex As Exception
            End Try
            conn.Close()
            member()
        End If
    End Sub

#End Region

#Region "列表获取焦点"

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

    Private Sub ListView3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView3.MouseEnter
        ListView3.Focus()
    End Sub

    Private Sub ListView2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.MouseEnter
        ListView2.Focus()
    End Sub

#End Region

#Region "查询"

    Private Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click

        searchone()

    End Sub '查询按钮

    Private Sub searchone()
        Dim i As Integer = 0

        If RadioButton1.Checked = True Then

            GroupBox2.Visible = False
            GroupBox2.Enabled = False

            ListView2.Items.Clear()

            If Info.TabCount = 3 Then
                Info.SelectedIndex = 2
            Else
                Info.SelectedIndex = 1
            End If

            ColumnHeader9.Width = 65
            ColumnHeader9.Text = "学号"

            ColumnHeader10.Width = 55
            ColumnHeader10.Text = "姓名"

            ColumnHeader11.Width = 135
            ColumnHeader11.Text = "院系"

            ColumnHeader12.Width = 120
            ColumnHeader12.Text = "选课时间"

            ColumnHeader13.Width = 63
            ColumnHeader13.Text = "硬件时间"

            ColumnHeader14.Width = 63
            ColumnHeader14.Text = "软件时间"

            ColumnHeader15.Width = 63
            ColumnHeader15.Text = "硬件成绩"

            ColumnHeader16.Width = 63
            ColumnHeader16.Text = "软件成绩"

            ColumnHeader19.Width = 63
            ColumnHeader19.Text = "试卷成绩"

            ColumnHeader20.Width = 95
            ColumnHeader20.Text = "联系电话"

            If Me.TextBNum.Text <> "" Then
                strSql = "select 学号,姓名,院系,选课时间,硬件时间,软件时间,硬件成绩,软件成绩,试卷成绩,联系电话 from [" & biao & "] where 学号='" & Me.TextBNum.Text & "'"
            ElseIf Me.TextBName.Text <> "" Then
                strSql = "select 学号,姓名,院系,选课时间,硬件时间,软件时间,硬件成绩,软件成绩,试卷成绩,联系电话 from [" & biao & "] where 姓名 like '%" & Me.TextBName.Text & "%'"
            Else
                strSql = "select 学号,姓名,院系,选课时间,硬件时间,软件时间,硬件成绩,软件成绩,试卷成绩,联系电话 from [" & biao & "] where 院系 like '%" & Me.ComboBDept.Text & "%'"
            End If

            If sqlnoerr(strSql, False) Then
                Do While myreader.Read '**********************查询成员************************
                    ListView2.Items.Add((myreader("学号").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("姓名").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("院系").ToString))
                    ListView2.Items(i).SubItems.Add(Trim(myreader("选课时间").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("硬件时间").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("软件时间").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("硬件成绩").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("软件成绩").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("试卷成绩").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("联系电话").ToString))
                    i += 1
                Loop
            End If
            conn.Close()
        Else
            ListView2.Items.Clear()

            GroupBox2.Visible = True
            GroupBox2.Enabled = True

            If Info.TabCount = 3 Then
                Info.SelectedIndex = 2
            Else
                Info.SelectedIndex = 1
            End If

            ColumnHeader9.Width = 80
            ColumnHeader9.Text = "学号"

            ColumnHeader10.Width = 75
            ColumnHeader10.Text = "姓名"

            ColumnHeader11.Width = 52
            ColumnHeader11.Text = "性别"

            ColumnHeader12.Width = 75
            ColumnHeader12.Text = "主讲次数"

            ColumnHeader13.Width = 75
            ColumnHeader13.Text = "助教次数"

            ColumnHeader14.Width = 150
            ColumnHeader14.Text = "院系"

            ColumnHeader15.Width = 61
            ColumnHeader15.Text = "年级"

            ColumnHeader16.Width = 95
            ColumnHeader16.Text = "电话"

            ColumnHeader19.Width = 64
            ColumnHeader19.Text = "登录用户名"

            ColumnHeader20.Width = 86
            ColumnHeader20.Text = "组别"

            If Me.TextBNum.Text <> "" Then
                strSql = "select USERNAME,学号,姓名,性别,院系,年级,电话,职务,组别,主讲,助课 from [" & biao2 & "] where 学号='" & Me.TextBNum.Text & "'"
            ElseIf Me.TextBName.Text <> "" Then
                strSql = "select USERNAME,学号,姓名,性别,院系,年级,电话,职务,组别,主讲,助课 from [" & biao2 & "] where 姓名 like '%" & Me.TextBName.Text & "%'"
            Else
                strSql = "select USERNAME,学号,姓名,性别,院系,年级,电话,职务,组别,主讲,助课 from [" & biao2 & "] where 院系 like '%" & Me.ComboBDept.Text & "%'"
            End If

            If sqlnoerr(strSql, True) Then
                Do While myreader.Read '**********************查询成员************************
                    ListView2.Items.Add((myreader("学号").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("姓名").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("性别").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("主讲").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("助课").ToString))
                    ListView2.Items(i).SubItems.Add(Trim(myreader("院系").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("年级").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("电话").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("USERNAME").ToString))
                    ListView2.Items(i).SubItems.Add((myreader("组别").ToString))
                    i += 1
                Loop
            End If
            conn.Close()
        End If
    End Sub

    Private Sub TextBNum_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBNum.GotFocus
        Me.AcceptButton = Me.Search
        TextBName.Text = ""
        ComboBDept.Text = ""
    End Sub

    Private Sub TextBName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBName.GotFocus
        Me.AcceptButton = Me.Search
        TextBNum.Text = ""
        ComboBDept.Text = ""
    End Sub

    Private Sub ComboBDept_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBDept.TextChanged
        Me.AcceptButton = Me.Search
        TextBNum.Text = ""
        TextBName.Text = ""
    End Sub '下拉列表内容修改后触发事件

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Try
            Me.ComboBDept.Items.Clear()
            strSql = "select distinct 院系 from [" & biao2 & "]"
            sql(strSql, True)
            While myreader.Read
                If Asc(myreader("院系").ToString) = 63 Then Continue While
                ComboBDept.Items.Add(myreader("院系"))
            End While
            conn.Close()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub 'radiobutton2内容修改后触发事件

    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Try
            Me.ComboBDept.Items.Clear()
            strSql = "select distinct 院系 from [" & biao & "]"
            sql(strSql, False)
            While myreader.Read
                If Asc(myreader("院系").ToString) = 63 Then Continue While
                ComboBDept.Items.Add(myreader("院系"))
            End While
            conn.Close()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub 'radiobutton1内容修改后触发事件

    Private Sub TextBNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBNum.KeyDown
        If e.KeyValue = Keys.Enter Then
            searchone()
        End If
    End Sub

    Private Sub TextBName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBName.KeyDown
        If e.KeyValue = Keys.Enter Then
            searchone()
        End If
    End Sub

#End Region

End Class