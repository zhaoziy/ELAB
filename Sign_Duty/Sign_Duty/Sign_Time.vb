Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text.RegularExpressions

Public Class Sign_Time

    Public Shared filename As String
    Public Shared mydataview As DataView
    Dim i As Integer

    Private Sub Sign_Time_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sign_Time_Panel.HandleCreated
        Dim i As Integer
        Me.RadioButton3.Checked = True
        Me.RadioButton5.Checked = True
        Me.ComboBox1.Text = GetWeek()
        Me.ComboBox2.Text = Month(Now)
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        For i = 1 To 25
            ComboBox1.Items.Add(i)
        Next
        For i = 1 To 12
            ComboBox2.Items.Add(i)
        Next
        For i = 1 To 25
            ckd_dw.Items.Add("第 " + i.ToString + " 周")
        Next
        For i = 1 To 12
            ckd_dm.Items.Add(i.ToString + " 月")
        Next

        Me.ckd_dw.SelectedIndex = GetWeek() - 1
        Me.ckd_dm.SelectedIndex = Month(Now) - 1
        '秋季学期的话月份会跨年
        selectcmd = "select * from newmember"
        sql(selectcmd)
        While (myreader.Read)
            ComboBox3.Items.Add(Trim(myreader("姓名").ToString))
        End While
        conn.Close()

        selectcmd = "select * from member"
        sql(selectcmd)
        While (myreader.Read)
            ComboBox3.Items.Add(Trim(myreader("姓名").ToString))
        End While
        conn.Close()

        ChaXun()
    End Sub

    Private Sub ComboBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox3.MouseDown
        Me.RadioButton4.Checked = True
        ChaXun()
    End Sub

    Private Sub ComboBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseDown
        Me.RadioButton5.Checked = True
        ChaXun()
    End Sub

    Private Sub ComboBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox2.MouseDown
        Me.RadioButton6.Checked = True
        ChaXun()
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click, RadioButton2.Click, RadioButton5.Click, RadioButton6.Click, RadioButton3.Click, RadioButton4.Click, ComboBox1.SelectedValueChanged, ComboBox2.SelectedValueChanged, ComboBox3.SelectedValueChanged
        ChaXun()
    End Sub

    Sub ChaXun()
        Dim selectcmd As String
        Dim flag As Integer = 0
        selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计"
        If Me.RadioButton1.Checked = True Then
            If selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计" Then
                selectcmd += " where 组别 = '软件组'"
            Else
                selectcmd += " and 组别 = '软件组'"
            End If
            flag = 0
        End If
        If Me.RadioButton2.Checked = True Then
            If selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计" Then
                selectcmd += " where 组别 = '电子组'"
            Else
                selectcmd += " and 组别 = '电子组'"
            End If
            flag = 0
        End If
        If Me.RadioButton5.Checked = True Then
            If selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计" Then
                selectcmd += " where 周次 = '" & ComboBox1.Text & "'"
            Else
                selectcmd += " and 周次 = '" & ComboBox1.Text & "'"
            End If
            flag = 0
        End If
        If Me.RadioButton6.Checked = True Then
            If selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计" Then
                selectcmd += " where MONTH(日期) = " & ComboBox2.Text
            Else
                selectcmd += " and MONTH(日期) = " & ComboBox2.Text
            End If
            flag = 0
        End If
        If Me.RadioButton4.Checked = True Then
            If selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计" Then
                selectcmd += " where 姓名 = '" & ComboBox3.Text & "'"
            Else
                selectcmd += " and 姓名 = '" & ComboBox3.Text & "'"
            End If
            flag = 0
        End If

        '万嘉庆加的东西_________________________________
        ''日期之间统计
        If Me.Rdo_dd.Checked Then
            Dim t1 As String = DateTimePicker1.Text
            Dim t2 As String = DateTimePicker2.Text
            If selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计" Then
                selectcmd += " where convert(char(10),日期,20) between convert(char(10),'" & t1 & "',20) and convert(char(10),'" & t2 & "',20)"
            Else
                selectcmd += " and convert(char(10),日期,20) between convert(char(10),'" & t1 & "',20) and convert(char(10),'" & t2 & "',20)"
            End If
            flag = 1
        End If
        ''周次之间统计
        If Me.Rdo_dw.Checked Then
            Dim wk As String = ""
            For Each i As Integer In ckd_dw.SelectedIndices
                wk += (i + 1).ToString + ","
            Next
            If selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计" Then
                selectcmd += " where 周次 in (" & wk.Substring(0, wk.Length - 1) & ") "
            Else
                selectcmd += " and 周次 in (" & wk.Substring(0, wk.Length - 1) & ") "
            End If
            flag = 1
        End If
        ''月份之间统计
        If Me.Rdo_dm.Checked Then
            Dim mt As String = ""
            For Each x As Integer In ckd_dm.SelectedIndices
                mt += (x + 1).ToString + ","
            Next
            If selectcmd = "select 学号,姓名,周次,组别,sum(合计时间) as 合计时间 from 时间统计" Then
                selectcmd += " where MONTH(日期) in (" & mt.Substring(0, mt.Length - 1) & ") "
            Else
                selectcmd += " and MONTH(日期) in (" & mt.Substring(0, mt.Length - 1) & ") "
            End If
            flag = 1
        End If

        '______________________________________________

        If flag = 0 Then
            selectcmd &= " and 学期='" & schoolcalendar & "' group by 学号,姓名,周次,组别"
        Else
            selectcmd &= " and 学期='" & schoolcalendar & "' group by 学号,姓名,组别"
            selectcmd = Regex.Replace(selectcmd, ",周次", "")
        End If


        Dim conn As sqlConnection, myadapter As sqlDataAdapter
        Dim mydataset As New DataSet
        conn = New SqlConnection(connstr)
        Try
            conn.Open()
            myadapter = New sqlDataAdapter(selectcmd, conn)
            myadapter.Fill(mydataset, "biao1")
            mydataview = mydataset.Tables(0).DefaultView
            DataGrid1.DataSource = mydataview
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myexcel As New Microsoft.Office.Interop.Excel.Application
        Dim mycol As New DataColumn
        myexcel.Visible = True
        myexcel.Workbooks.Add()
        Dim col As Integer
        Dim row As Integer
        col = 1
        Try
            For Each mycol In mydataview.ToTable.Columns
                myexcel.Worksheets("sheet1").activate()
                myexcel.Cells(1, col).value = mycol.ColumnName
                col = col + 1
            Next
            For col = 0 To mydataview.ToTable.Columns.Count - 1
                For row = 0 To mydataview.ToTable.Rows.Count - 1
                    myexcel.Cells(row + 2, col + 1).value = mydataview.ToTable.Rows(row)(col)
                Next
                myexcel.ActiveSheet.columns(col + 1).autofit()
            Next
        Catch ex As Exception
            MsgBox("错误", MsgBoxStyle.OkOnly, "警告")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox1.TextChanged, ComboBox2.TextChanged, ComboBox2.SelectedIndexChanged
        ChaXun()
    End Sub

    Private Sub DataGrid1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.MouseEnter
        DataGrid1.Focus()
    End Sub

    Private Sub Rdo_dm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_dm.CheckedChanged

        If Rdo_dm.Checked Then
            Grp_dm.Visible = True
            Grp_dd.Visible = False
            Grp_dw.Visible = False
            Grp_dm.Location = New Point(5, 215)
        End If

    End Sub
    Private Sub Rdo_dd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_dd.CheckedChanged
        If Rdo_dd.Checked Then
            Grp_dd.Visible = True
            Grp_dm.Visible = False
            Grp_dw.Visible = False
            Grp_dd.Location = New Point(5, 215)
        End If
    End Sub
    Private Sub Rdo_dw_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_dw.CheckedChanged
        If Rdo_dw.Checked Then
            Grp_dw.Visible = True
            Grp_dd.Visible = False
            Grp_dm.Visible = False
            Grp_dw.Location = New Point(5, 215)
        End If
    End Sub

   
    Private Sub but_dd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but_dd.Click, but_dm.Click, but_dw.Click

        ChaXun()

    End Sub

 
End Class