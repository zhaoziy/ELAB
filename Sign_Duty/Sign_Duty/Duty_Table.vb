Imports System.IO
Imports System.Windows
Imports System.Data.SqlClient
Public Class Duty_Table

    'Public connstr As String = "Data Source=ELAB-62\SQLEXPRESS;Initial Catalog=YJTJ_elab;Integrated Security=True;Pooling=False"
    'Public selectcmd As String = ""
    Public comBox As New Windows.Forms.ComboBox
    Public flag As Boolean = False


    Private Sub Duty_Table_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Duty_Table_Panel.HandleCreated
        fill_Data()
        Duty_Table_show.SelectionMode = Forms.DataGridViewSelectionMode.CellSelect
        Duty_Table_show.ReadOnly = True
        Dim cMenu As New Windows.Forms.ContextMenuStrip
        cMenu.Items.Add("编辑")
        cMenu.Items.Add("提交")
        'Me.Controls.Add(cMenu)
        Duty_Table_show.ContextMenuStrip = cMenu
        AddHandler cMenu.Items(0).Click, AddressOf 编辑ToolStripMenuItem_Click
        AddHandler cMenu.Items(1).Click, AddressOf 提交ToolStripMenuItem_Click

        Duty_Table_Panel.Controls.Add(comBox)
        AddHandler comBox.SelectedValueChanged, AddressOf comBox_SelectedIndexChanged
        AddHandler comBox.KeyDown, AddressOf comBox_KeyDown
        AddHandler comBox.Leave, AddressOf comBox_Leave
        comBox.Visible = False

    End Sub

    Private Sub 编辑ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '学号和姓名可以输入，其他的必须下拉选择
        If Duty_Table_show.CurrentCell.ColumnIndex = 1 Then

            selectcmd = "select 学号 from member where 学号>201300000"
            fill_comBox("学号")
            pos_comBox()
            comBox.DropDownStyle = Forms.ComboBoxStyle.DropDown
        ElseIf Duty_Table_show.CurrentCell.ColumnIndex = 2 Then
            selectcmd = "select 姓名 from member where 学号>201300000"
            fill_comBox("姓名")
            pos_comBox()
            comBox.DropDownStyle = Forms.ComboBoxStyle.DropDown
        ElseIf Duty_Table_show.CurrentCell.ColumnIndex = 3 Then
            'selectcmd = "select distinct 组别 from member "
            'fill_comBox("组别")
            'pos_comBox()
            'comBox.DropDownStyle = Forms.ComboBoxStyle.DropDownList
            Return
        ElseIf Duty_Table_show.CurrentCell.ColumnIndex = 4 Then
            'comBox.Items.Clear()
            'comBox.Items.Add("下午")
            'comBox.Items.Add("晚上")
            'comBox.DropDownStyle = Forms.ComboBoxStyle.DropDownList
            'pos_comBox()
            Return
        ElseIf Duty_Table_show.CurrentCell.ColumnIndex = 5 Then
            'comBox.Items.Clear()
            'comBox.Items.Add("单周")
            'comBox.Items.Add("双周")
            'pos_comBox()
            'comBox.DropDownStyle = Forms.ComboBoxStyle.DropDownList
            Return
        ElseIf Duty_Table_show.CurrentCell.ColumnIndex = 6 Then
            'comBox.Items.Clear()
            'For i As Integer = 0 To 6
            '    comBox.Items.Add(i)
            'Next
            'pos_comBox()
            'comBox.DropDownStyle = Forms.ComboBoxStyle.DropDownList
            Return
        ElseIf Duty_Table_show.CurrentCell.ColumnIndex = 0 Then
            Return
        End If

        flag = True
        If Duty_Table_show.CurrentCell.Value IsNot DBNull.Value Then
            comBox.Text = Duty_Table_show.CurrentCell.Value
        End If

        flag = False
        comBox.Visible = True
        comBox.BringToFront()
        comBox.Focus()
        '更新combox


    End Sub
    Private Sub 提交ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each row As Forms.DataGridViewRow In Duty_Table_show.Rows
            'selectcmd = "update Duty_w set 学号='" & row.Cells("学号").Value & "', 姓名='" & row.Cells("姓名").Value & "', 组别='" & row.Cells("组别").Value & "', 时段='" & row.Cells("时段").Value & "', 单双周='" & row.Cells("单双周").Value & "', 星期='" & row.Cells("星期").Value & "' where ID='" & row.Cells("ID").Value & "'"
            selectcmd = "update duty set 学号='" & row.Cells("学号").Value & "', 姓名='" & row.Cells("姓名").Value & "', 组别='" & row.Cells("组别").Value & "', 时段='" & row.Cells("时段").Value & "', 单双周='" & row.Cells("单双周").Value & "', 星期='" & row.Cells("星期").Value & "' where ID='" & row.Cells("ID").Value & "'"

            sql_w(connstr, selectcmd)
        Next

        Duty_Table_show.ReadOnly = True
        fill_Data()
        MsgBox("提交成功")

    End Sub
    Private Sub comBox_Leave(ByVal sender As Object, ByVal e As EventArgs)
        belong_comBox()
    End Sub

    Private Sub comBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        If Not flag Then
            update_comBox()
        End If
    End Sub
    Private Sub comBox_KeyDown(ByVal sender As Object, ByVal e As Forms.KeyEventArgs)

        If e.KeyCode = Forms.Keys.Enter Then
            belong_comBox()
        End If
    End Sub

    Sub fill_Data()
        '        selectcmd = "select ID,学号, 姓名, 组别, 时段, 单双周, 星期 from Duty_w"
        selectcmd = "select ID,学号, 姓名, 组别, 时段, 单双周, 星期 from duty"

        Duty_Table_show.DataSource = gettable_w(connstr, selectcmd)
        For i As Integer = 0 To Duty_Table_show.Columns.Count - 1
            Duty_Table_show.Columns(i).SortMode = Forms.DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Sub fill_comBox(ByVal name As String)
        comBox.Items.Clear()
        sql_w(connstr, selectcmd)
        comBox.Items.Add("") '添加空选项
        Do While myreader.Read
            comBox.Items.Add(myreader(name))
        Loop

    End Sub

    Sub pos_comBox()
        Dim rect As Drawing.Rectangle = Duty_Table_show.GetCellDisplayRectangle(Duty_Table_show.CurrentCell.ColumnIndex, Duty_Table_show.CurrentCell.RowIndex, False)
        comBox.Left = rect.Left
        comBox.Width = rect.Width
        comBox.Top = rect.Top
        comBox.Height = rect.Height

    End Sub


    Sub belong_comBox()
        If comBox.Items.Contains(comBox.Text) Then
            update_comBox()
        Else
            MsgBox("i don't know who you are")
            comBox.Text = Duty_Table_show.CurrentCell.Value
        End If
    End Sub


    Sub update_comBox()
        Duty_Table_show.ReadOnly = False

        Duty_Table_show.CurrentCell.Value = comBox.Text
        '同步更新学号、姓名、组别
        If comBox.Text = "" Then
            Duty_Table_show.Rows(Duty_Table_show.CurrentCell.RowIndex).Cells("姓名").Value = ""
            Duty_Table_show.Rows(Duty_Table_show.CurrentCell.RowIndex).Cells("组别").Value = ""
            Duty_Table_show.Rows(Duty_Table_show.CurrentCell.RowIndex).Cells("学号").Value = ""
        Else

            If Duty_Table_show.CurrentCell.ColumnIndex = 1 Then
                selectcmd = "select 姓名,组别 from member where 学号='" & comBox.Text.Trim & "'"
                sql_w(connstr, selectcmd)

                If myreader.Read Then
                    Duty_Table_show.Rows(Duty_Table_show.CurrentCell.RowIndex).Cells("姓名").Value = myreader("姓名")
                    Duty_Table_show.Rows(Duty_Table_show.CurrentCell.RowIndex).Cells("组别").Value = myreader("组别")
                End If


            ElseIf Duty_Table_show.CurrentCell.ColumnIndex = 2 Then
                selectcmd = "select 学号,组别 from member where 姓名='" & comBox.Text.Trim & "'"
                sql_w(connstr, selectcmd)

                If myreader.Read Then
                    Duty_Table_show.Rows(Duty_Table_show.CurrentCell.RowIndex).Cells("学号").Value = myreader("学号")
                    Duty_Table_show.Rows(Duty_Table_show.CurrentCell.RowIndex).Cells("组别").Value = myreader("组别")
                End If


            End If
        End If
        comBox.Visible = False
        comBox.SendToBack()
        Duty_Table_show.ReadOnly = True
    End Sub



End Class