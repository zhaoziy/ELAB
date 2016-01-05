Imports System.Drawing

Public Class ChangeInfo
    Public transpwd As String
    Dim m_GetNum As String
    Dim m_GetRole As Boolean

#Region "按钮事件"

    Private Sub quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quit.Click
        Me.Close()
    End Sub

    Private Sub reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset.Click
        If flag = "update" Then
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            ComboBox1.Text = ""
            gentleman.Checked = True
        Else
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            ComboBox1.Text = ""
            gentleman.Checked = True
        End If

    End Sub

    Private Sub AddInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddInfo.Click
        Dim gender As String
        If TextBox1.Text = "" Then
            MsgBox("学号不能为空，请继续输入。")
            Exit Sub
        ElseIf TextBox1.TextLength < 9 Then
            MsgBox("输入学号位数不够，请继续输入。")
            Exit Sub
        ElseIf TextBox2.Text = "" Then
            MsgBox("姓名不能为空，请继续输入。")
            Exit Sub
        ElseIf TextBox3.Text = "" Then
            MsgBox("院系不能为空，请继续输入。")
            Exit Sub
        ElseIf TextBox4.Text = "" Then
            MsgBox("电话不能为空，请继续输入。")
            Exit Sub
        ElseIf TextBox5.Text = "" Then
            MsgBox("密码不能为空，请继续输入。")
            Exit Sub
        ElseIf TextBox6.Text = "" Then
            MsgBox("确认密码不能为空，请继续输入。")
            Exit Sub
        ElseIf TextBox7.Text = "" Then
            MsgBox("登录用户名不能为空，请继续输入。")
            Exit Sub
        End If

        '***********密码复杂度判断***********
        If TextBox5.Text.Length < 6 Then
            MsgBox("密码长度必须大于等于6")
            Exit Sub
        ElseIf IsNumeric(TextBox5.Text) = True Then
            MsgBox("不能使用纯数字作为密码")
            Exit Sub
        End If
        '***********密码复杂度判断***********

        strSql = "select 学号 from [member] where 学号=" & TextBox1.Text
        sql(strSql, True)
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("输入信息不全，请继续输入。")
            Exit Sub
        ElseIf TextBox5.Text <> TextBox6.Text Then
            MsgBox("两次输入密码不同。")
            Exit Sub
        Else
            If myreader.Read Then
                MsgBox("用户已存在！")
                Exit Sub
            Else
                TextBox5.Text = MD5(TextBox5.Text, 32)
                If gentleman.Checked Then
                    gender = "男"
                Else : gender = "女"
                End If
                insertcmd = "insert into member (USERNAME,学号,姓名,性别,院系,组别,电话,密码,主讲,助课) values ('" & TextBox7.Text & "','"
                insertcmd &= TextBox1.Text & "','" & TextBox2.Text & "','" & gender & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "',0,0)"
                Try
                    sql(insertcmd, True)
                    Grade(TextBox1.Text.ToString)
                    MsgBox("添加用户成功")
                    conn.Close()
                    Me.Close()
                Catch ex As Exception
                End Try
            End If
        End If
        conn.Close()
    End Sub

    Private Sub UpdateInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateInfo.Click

        Dim infomanager As New infomanager

        '***********密码复杂度判断**********
        If TextBox5.Text.Length < 6 Then
            If TextBox5.Text <> "" Then
                MsgBox("密码长度必须大于等于6")
                Exit Sub
            End If
        ElseIf IsNumeric(TextBox5.Text) = True Then
            MsgBox("不能使用纯数字作为密码")
            Exit Sub
        End If
        '***********密码复杂度判断**********
        Dim password1 As New password
        password1.Label1.Text = "请输入原密码："
        password1.ShowDialog()
        password1.Dispose()

        Try
            prepwd = MD5(prepwd, 32)
        Catch ex As Exception
            Exit Sub
        End Try

        If TextBox7.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("信息不全")
        ElseIf transpwd = prepwd Then
            If TextBox5.Text = "" Then   '**************判断是否修改密码***************
                If gentleman.Checked = True Then
                    If authority = 8 Or authority = 9 Then
                        updatecmd = "update member set USERNAME='" & TextBox7.Text & "', 姓名='" & Me.TextBox2.Text & "', 院系='" & Me.TextBox3.Text & "',组别='" & Me.ComboBox1.Text & "',电话='" & Me.TextBox4.Text & "',性别= '男' where 学号= '" & m_GetNum & "'"
                        Grade(m_GetNum)
                    Else
                        updatecmd = "update member set USERNAME='" & TextBox7.Text & "', 姓名='" & Me.TextBox2.Text & "', 院系='" & Me.TextBox3.Text & "',组别='" & Me.ComboBox1.Text & "',电话='" & Me.TextBox4.Text & "',性别= '男' where 学号= '" & usernum & "'"
                        Grade(usernum)
                    End If
                Else
                    If authority = 8 Or authority = 9 Then
                        updatecmd = "update member set USERNAME='" & TextBox7.Text & "', 姓名='" & Me.TextBox2.Text & "', 院系='" & Me.TextBox3.Text & "',组别='" & Me.ComboBox1.Text & "',电话='" & Me.TextBox4.Text & "',性别= '女' where 学号= '" & m_GetNum & "'"
                        Grade(m_GetNum)
                    ElseIf authority = 0 Then
                        updatecmd = "update member set USERNAME='" & TextBox7.Text & "', 姓名='" & Me.TextBox2.Text & "', 院系='" & Me.TextBox3.Text & "',组别='" & Me.ComboBox1.Text & "',电话='" & Me.TextBox4.Text & "',性别= '女' where 学号= '" & usernum & "'"
                        Grade(usernum)
                    End If
                End If
            Else
                TextBox5.Text = MD5(TextBox5.Text, 32)
                If gentleman.Checked = True Then
                    If authority = 8 Or authority = 9 Then
                        updatecmd = "update member set USERNAME='" & TextBox7.Text & "', 姓名='" & Me.TextBox2.Text & "', 院系='" & Me.TextBox3.Text & "',组别='" & Me.ComboBox1.Text & "',电话='" & Me.TextBox4.Text & "',性别= '男'" & ",密码='" & TextBox5.Text & "' where 学号= '" & m_GetNum & "'"
                        Grade(m_GetNum)
                    ElseIf authority = 0 Then
                        updatecmd = "update member set USERNAME='" & TextBox7.Text & "', 姓名='" & Me.TextBox2.Text & "', 院系='" & Me.TextBox3.Text & "',组别='" & Me.ComboBox1.Text & "',电话='" & Me.TextBox4.Text & "',性别= '男'" & ",密码='" & TextBox5.Text & "' where 学号= '" & usernum & "'"
                        Grade(usernum)
                    End If
                Else
                    If authority = 8 Or authority = 9 Then
                        updatecmd = "update member set USERNAME='" & TextBox7.Text & "', 姓名='" & Me.TextBox2.Text & "', 院系='" & Me.TextBox3.Text & "',组别='" & Me.ComboBox1.Text & "',电话='" & Me.TextBox4.Text & "',性别= '女'" & ",密码='" & TextBox5.Text & "' where 学号= '" & m_GetNum & "'"
                        Grade(m_GetNum)
                    ElseIf authority = 0 Then
                        updatecmd = "update member set USERNAME='" & TextBox7.Text & "', 姓名='" & Me.TextBox2.Text & "', 院系='" & Me.TextBox3.Text & "',组别='" & Me.ComboBox1.Text & "',电话='" & Me.TextBox4.Text & "',性别= '女'" & ",密码='" & TextBox5.Text & "' where 学号= '" & usernum & "'"
                        Grade(usernum)
                    End If
                End If
            End If
            sql(updatecmd, True)
            conn.Close()
            TextBox5.Text = ""
            TextBox6.Text = ""
            MsgBox("修改成功！")
            Me.Close()
        Else
            MsgBox("密码错误，无法修改信息")
        End If
    End Sub

    Private Sub ReWP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReWP.Click
        Dim str As String
        Dim strpwjm, strpwjm1 As String
        Dim table1 As DataTable
        Dim i As Integer
        Dim password1 As New password
        password1.Label1.Text = "请输入任一班委的密码："
        password1.ShowDialog()
        password1.Dispose()
        If prepwd = "invaildpassword" Then
            Exit Sub
        Else
            strpwjm = MD5(prepwd, 32)
        End If
        str = "select 密码 from member where 职务 ='班委'"
        table1 = gettable("member", str, True)
        For i = 0 To table1.Rows.Count
            If i = table1.Rows.Count Then
                MsgBox("密码输入错误")
                Exit Sub
            End If
            If strpwjm = table1.Rows(i).Item("密码") Then
                Dim password2 As New password
                password2.Text = "新密码"
                password2.Label1.Text = "请输入新密码："
                password2.ShowDialog()
                password2.Dispose()
                If prepwd = "invaildpassword" Then
                    Exit Sub
                ElseIf prepwd = "" Then
                    MsgBox("密码不能为空")
                    Exit Sub
                End If
                strpwjm1 = MD5(prepwd, 32)
                updatecmd = "update member set 密码= '" & strpwjm1 & "' where 学号= '" & TextBox1.Text & "'"
                sql(updatecmd, True)
                conn.Close()
                MsgBox("修改成功")
                Exit For
            End If
        Next
        table1.Dispose()
    End Sub

    Private Sub Grade(ByVal num As String)
        Dim str As String = String.Empty
        Dim str_grade As String = String.Empty
        Dim grade As Integer

        Try
            grade = CInt(Now.Year.ToString) - CInt(num.ToString().Substring(0, 4))
            If Now.Month >= 8 Then
                If grade = 0 Then
                    str_grade = "大一"
                ElseIf grade = 1 Then
                    str_grade = "大二"
                ElseIf grade = 2 Then
                    str_grade = "大三"
                ElseIf grade = 3 Then
                    str_grade = "大四"
                ElseIf grade > 3 Then
                    str_grade = "往届"
                End If
            Else
                If grade = 1 Then
                    str_grade = "大一"
                ElseIf grade = 2 Then
                    str_grade = "大二"
                ElseIf grade = 3 Then
                    str_grade = "大三"
                ElseIf grade = 4 Then
                    str_grade = "大四"
                ElseIf grade > 4 Then
                    str_grade = "往届"
                End If
            End If
            str = "update [member] set 年级='" & str_grade & "' where 学号='" & num.ToString() & "'"
            sql(str, True)
            conn.Close()
        Catch ex As Exception
            MsgBox("更新学生年级设定出错，请重新更新")
        End Try
    End Sub

#End Region

#Region "窗体事件"

    Private Sub Change_Info_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Change_Info_Panel.HandleCreated

        gentleman.Checked = True
        ComboBox1.Text = "电子组"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
        TextBox4.Text = String.Empty
        TextBox5.Text = String.Empty
        TextBox6.Text = String.Empty
        TextBox7.Text = String.Empty

        If flag = "add" Then
            Me.UpdateInfo.Visible = False
            Me.UpdateInfo.Enabled = False
            Me.AddInfo.Visible = True
            Me.AddInfo.Enabled = True
            Me.GroupBox1.Text = "添加成员信息"
            Me.TextBox1.ReadOnly = False
            Me.AcceptButton = AddInfo
            Me.CancelButton = quit
            Me.Label8.Visible = True
            Me.Label9.Visible = False
            Me.TextBox6.Visible = True
        ElseIf flag = "update" Then
            Me.UpdateInfo.Visible = True
            Me.UpdateInfo.Enabled = True
            Me.AddInfo.Visible = False
            Me.AddInfo.Enabled = False
            Me.GroupBox1.Text = "修改成员信息"
            Me.UpdateInfo.Location = New Point(198, 481)
            Me.Label8.Visible = False
            Me.Label9.Visible = True
            Me.TextBox6.Visible = False
            Me.TextBox1.ReadOnly = True
            Me.AcceptButton = UpdateInfo
            Me.CancelButton = quit

            strSql = "select USERNAME,学号,姓名,性别,院系,组别,电话,密码 from [member] where 学号=" & m_GetNum
            sql(strSql, True)
            If myreader.Read = True Then
                TextBox7.Text = myreader.Item("USERNAME")
                TextBox1.Text = myreader.Item("学号")
                TextBox2.Text = myreader.Item("姓名")
                TextBox3.Text = myreader.Item("院系")
                ComboBox1.Text = myreader.Item("组别")
                If IsDBNull(myreader.Item("电话")) Then
                    TextBox4.Text = ""
                Else
                    TextBox4.Text = myreader.Item("电话")
                End If

                If myreader.Item("性别") = "男" Then
                    gentleman.Checked = True
                Else
                    lady.Checked = True
                End If
                If IsDBNull(myreader.Item("密码")) Then
                    transpwd = ""
                Else
                    transpwd = myreader.Item("密码")
                End If
            End If
            conn.Close()
        End If
        If m_GetRole = False Then
            quit.Enabled = False
            quit.Visible = False
            Me.ReWP.Location = New Point(431, 481)
            GroupBox1.Text = "修改个人信息"
        End If
    End Sub

    Public Property GetNum() As String
        Get
            Return m_GetNum
        End Get
        Set(ByVal Value As String)
            m_GetNum = Value
        End Set
    End Property

    Public Property GetRole() As Boolean
        Get
            Return m_GetRole
        End Get
        Set(ByVal Value As Boolean)
            m_GetRole = Value
        End Set
    End Property

#End Region

End Class