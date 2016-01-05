Imports System.Windows.Forms

Public Class Appoint_Admin

    Public zhujiang As String = ""
    Public info As String = ""
    Public myarray, dqmyarray As Array
    Public currentdate As Date
    Dim nzhujiao As Boolean = True '判断是否相同，相同为true，不同为false

#Region "初始化"

    Private Sub TAAttendancePanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Appoint_Admin_Panel.HandleCreated

        init()

        Dim i As Integer = 0
        Dim str_name As String = ""

        strSql = "select * from [member] where 职务='班委'"
        Dim admin As DataTable
        admin = gettable("admin", strSql, True)
        For i = 0 To admin.Rows.Count - 1
            str_name &= Trim(admin.Rows(i).Item("姓名")) & " "
        Next
        admin.Dispose()
        myarray = Split(Trim(str_name))

        For i = 0 To myarray.Length - 1
            If myarray(i) <> "" Then
                ListBox3.Items.Add(myarray(i))
            End If
        Next

        list()

    End Sub

    Private Sub TAAttendancePanel_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Appoint_Admin_Panel.HandleDestroyed
        saveadmin()
    End Sub

#End Region

#Region "指定管理员"

    Private Sub list()
        Me.ListBox1.Items.Clear()
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

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Dim flag1 As Boolean = False

        If ListBox1.SelectedItem = "" Then
            Exit Sub
        Else
            For i = 0 To ListBox3.Items.Count - 1
                If ListBox1.SelectedItem.ToString() = ListBox3.Items(i) Then
                    flag1 = True
                End If
            Next
        End If
        If flag1 = False Then
            ListBox3.Items.Add(ListBox1.SelectedItem.ToString())
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

    Private Sub ListBox3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.DoubleClick
        Try
            If ListBox3.SelectedIndex <> -1 Then
                If ListBox3.SelectedItem.ToString = "" Then
                    Exit Sub
                Else
                    If MessageBox.Show("确定要移除？", "提示", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        ListBox3.Items.Remove(ListBox3.SelectedItem.ToString())
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub '移除姓名

    Private Sub saveadmin()

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
            Dim str As String

            str = "update [member] set 职务=NULL"
            sql(str, True)
            conn.Close()

            For i = 0 To ListBox3.Items.Count - 1
                If ListBox3.Items(i) <> "" Then
                    str = "update [member] set 职务='班委' where 姓名='" & ListBox3.Items(i).ToString & "'"
                    sql(str, True)
                    conn.Close()
                    logwrite("admin", ListBox3.Items(i), "修改管理员")
                End If
            Next

        End If
        Array.Clear(dqmyarray, 0, dqmyarray.Length)
    End Sub '保存同学

#End Region

    Private Sub ListBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.MouseEnter
        ListBox1.Focus()
    End Sub

    Private Sub ListBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.MouseEnter
        ListBox3.Focus()
    End Sub

End Class