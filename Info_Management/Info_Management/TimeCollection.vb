Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class TimeCollection

    Private Clb(6, 19) As CheckedListBox   '**************容量为140（7*20）的数组**************
    Private LblWeek(19) As Label  '**************容量为20的数组**************
    Private LblTime(6) As Label  '**************容量为7的数组**************
    Private day_Checkbox(6) As CheckedListBox
    Private week_Checkbox(19) As CheckedListBox
    Dim numtemp, nametemp As String
    Dim init_status As Boolean = False  '未修改则为false，有过改动则为true

    Dim Info_Time(6, 19) As Info_Time_Node

#Region "初始化，绘制表格"

    Public Sub initialize()



        Dim i, j As Integer
        Dim Width As Integer = LblStandard.Width
        Dim Height As Integer = LblStandard.Height

        Label1.Text = "选中时间即为空闲时间，"
        Label1.Text &= vbNewLine
        Label1.Text &= vbNewLine
        Label1.Text &= "最左的选项可选择一行相"
        Label1.Text &= vbNewLine
        Label1.Text &= vbNewLine
        Label1.Text &= "对应的选项，最上的选项"
        Label1.Text &= vbNewLine
        Label1.Text &= vbNewLine
        Label1.Text &= "可选择一列相对应的选项。"

        '*******************时间栏*****************
        For i = 0 To 6

            LblTime(i) = New Label
            LblTime(i).AutoSize = False
            LblTime(i).Height = Height
            LblTime(i).Width = Width
            LblTime(i).Top = LblStandard.Top
            LblTime(i).Left = LblStandard.Left + (i + 2) * Width + 10
            LblTime(i).BorderStyle = BorderStyle.FixedSingle
            LblTime(i).BackColor = Color.DodgerBlue
            LblTime(i).Font = New Font("宋体", 12)
            If i < 7 Then LblTime(i).Text = GetDay(i + 1)
            LblTime(i).TextAlign = ContentAlignment.MiddleCenter
            Panel1.Controls.Add(LblTime(i))

            day_Checkbox(i) = New CheckedListBox
            day_Checkbox(i).AutoSize = False
            day_Checkbox(i).Height = Height
            day_Checkbox(i).Width = Width
            day_Checkbox(i).Top = LblStandard.Top + Height
            day_Checkbox(i).Left = LblStandard.Left + (i + 2) * Width + 10
            day_Checkbox(i).Items.Add("早上")
            day_Checkbox(i).Items.Add("下午")
            day_Checkbox(i).Items.Add("晚上")
            day_Checkbox(i).BorderStyle = BorderStyle.FixedSingle
            day_Checkbox(i).TabIndex = 80 + i
            Panel1.Controls.Add(day_Checkbox(i))
            day_Checkbox(i).CheckOnClick = True
            day_Checkbox(i).BackColor = Color.FromArgb(249, 188, 108)
            AddHandler day_Checkbox(i).SelectedIndexChanged, New System.EventHandler(AddressOf Me.column)
            AddHandler day_Checkbox(i).MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.clb_MouseUp)
            AddHandler day_Checkbox(i).SelectedIndexChanged, New System.EventHandler(AddressOf Me.allchecked)
        Next
        '***********************周次栏***********************
        For j = 0 To 19
            LblWeek(j) = New Label
            LblWeek(j).AutoSize = False
            LblWeek(j).Height = Height
            LblWeek(j).Width = Width
            LblWeek(j).Top = LblStandard.Top + (j) * Height
            LblWeek(j).Left = LblStandard.Left
            LblWeek(j).BorderStyle = BorderStyle.FixedSingle
            LblWeek(j).BackColor = Color.DodgerBlue
            LblWeek(j).Font = New Font("宋体", 12)
            LblWeek(j).Text = "第" & j + 1 & "周"
            LblWeek(j).TextAlign = ContentAlignment.MiddleCenter
            PanelTime.Controls.Add(LblWeek(j))

            week_Checkbox(j) = New CheckedListBox
            week_Checkbox(j).AutoSize = False
            week_Checkbox(j).Height = Height
            week_Checkbox(j).Width = Width
            week_Checkbox(j).Top = LblStandard.Top + (j) * Height
            week_Checkbox(j).Left = LblStandard.Left + Width
            week_Checkbox(j).Items.Add("早上")
            week_Checkbox(j).Items.Add("下午")
            week_Checkbox(j).Items.Add("晚上")
            week_Checkbox(j).BorderStyle = BorderStyle.FixedSingle
            PanelTime.Controls.Add(week_Checkbox(j))
            week_Checkbox(j).TabIndex = 90 + j
            week_Checkbox(j).CheckOnClick = True
            week_Checkbox(j).BackColor = Color.FromArgb(249, 188, 108)

            AddHandler week_Checkbox(j).SelectedIndexChanged, New System.EventHandler(AddressOf Me.line)
            AddHandler week_Checkbox(j).MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.clb_MouseUp)
            AddHandler week_Checkbox(j).SelectedIndexChanged, New System.EventHandler(AddressOf Me.allchecked)
        Next

        For j = 0 To 19
            For i = 0 To 6     'i代表周几，j代表第几周
                Info_Time(i, j) = New Info_Time_Node(False, False, False)

                Clb(i, j) = New CheckedListBox
                Clb(i, j).Name = "lbl" & i.ToString & j.ToString
                Clb(i, j).AutoSize = False
                Clb(i, j).Width = Width
                Clb(i, j).Height = Height
                Clb(i, j).Top = LblStandard.Top + (j) * Height
                Clb(i, j).Left = LblStandard.Left + (i + 2) * Width + 10
                Clb(i, j).BorderStyle = BorderStyle.Fixed3D
                Clb(i, j).BackColor = Color.FloralWhite
                Clb(i, j).Items.Add("早上")
                Clb(i, j).Items.Add("下午")
                Clb(i, j).Items.Add("晚上")
                Clb(i, j).BorderStyle = BorderStyle.FixedSingle
                Clb(i, j).CheckOnClick = True
                PanelTime.Controls.Add(Clb(i, j))
                Clb(i, j).TabIndex = 1000 + (j + 1) * 10 + i + 1
                If j Mod 2 = 0 Then
                    Clb(i, j).BackColor = Color.LightBlue
                End If
                AddHandler Clb(i, j).MouseEnter, New System.EventHandler(AddressOf Me.clb_MouseEnter)
                AddHandler Clb(i, j).MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.clb_MouseUp)
                AddHandler Clb(i, j).SelectedIndexChanged, New System.EventHandler(AddressOf Me.allchecked)
            Next
        Next
    End Sub

#End Region

#Region "表格控制"

    Private Sub line(ByVal sender As Object, ByVal e As System.EventArgs) '一行全选
        Dim i As Integer
        If week_Checkbox(sender.tabindex - 90).GetItemChecked(week_Checkbox(sender.tabindex - 90).SelectedIndex) = True Then
            For i = 0 To 6
                Clb(i, sender.tabindex - 90).SetItemChecked(week_Checkbox(sender.tabindex - 90).SelectedIndex, True)
            Next
        Else
            For i = 0 To 6
                Clb(i, sender.tabindex - 90).SetItemChecked(week_Checkbox(sender.tabindex - 90).SelectedIndex, False)
            Next
        End If
    End Sub

    Private Sub column(ByVal sender As Object, ByVal e As System.EventArgs)  '一列全选
        Dim j As Integer
        If day_Checkbox(sender.tabindex - 80).GetItemChecked(day_Checkbox(sender.tabindex - 80).SelectedIndex) = True Then
            For j = 0 To 19
                Clb(sender.tabindex - 80, j).SetItemChecked(day_Checkbox(sender.tabindex - 80).SelectedIndex, True)
            Next
        Else
            For j = 0 To 19
                Clb(sender.tabindex - 80, j).SetItemChecked(day_Checkbox(sender.tabindex - 80).SelectedIndex, False)
            Next
        End If
    End Sub

    Private Sub clb_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)  '悬浮标签
        PanelTime.Focus()
        Try
            Dim week, time As Integer
            week = (sender.tabindex - 1000) \ 10
            time = sender.tabindex Mod 10
            Me.ToolTip1.SetToolTip(sender, "第" & week & "周 " & GetDay(time))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub clb_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        init_status = True
    End Sub

    Private Sub allchecked(ByVal sender As Object, ByVal e As System.EventArgs)  '判断是否一行或一列全选

        Dim week, day As Integer
        Dim i, j, k As Integer

        Try
            day = (sender.tabindex - 1000) Mod 10
            week = (sender.tabindex - 1000 - day) / 10
        Catch ex As Exception

        End Try

        Dim m As Boolean = False
        For k = 0 To 2
            For j = 0 To 19
                For i = 0 To 6
                    If Clb(i, j).GetItemChecked(k) = True Then
                        m = True
                    Else
                        m = False
                        Exit For
                    End If
                Next
                If m = True Then
                    week_Checkbox(j).SetItemChecked(k, True)
                Else
                    week_Checkbox(j).SetItemChecked(k, False)
                End If
            Next
        Next
        For k = 0 To 2
            For i = 0 To 6
                For j = 0 To 19
                    If Clb(i, j).GetItemChecked(k) = True Then
                        m = True
                    Else
                        m = False
                        Exit For
                    End If
                Next
                If m = True Then
                    day_Checkbox(i).SetItemChecked(k, True)
                Else
                    day_Checkbox(i).SetItemChecked(k, False)
                End If
            Next
        Next
    End Sub

#End Region

#Region "程序过程控制"

    Private Sub save()

        If numtemp = "" Then
            Exit Sub
        End If

        If Serialize_Info() = True Then

            Dim str As String = "if exists(select * from [空闲时间统计] where 学号 = '" & numtemp & "' and 学期='" & schoolcalendar.Substring(0, 5) & "') " & _
              "begin update [空闲时间统计] set 信息 =NULL where 学号 = '" & numtemp & "' and 学期='" & schoolcalendar.Substring(0, 5) & "' end else " & _
              "begin select * from [空闲时间统计] where 学号 = '" & numtemp & "' and 学期='" & schoolcalendar.Substring(0, 5) & "' end"
            Try
                sql(str, True)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try

        Else

            Dim formatter As New BinaryFormatter
            Dim rems As MemoryStream = New MemoryStream()
            formatter.Serialize(rems, Info_Time)
            rems.Position = 0
            Dim descBytes(rems.Length) As Byte

            rems.Read(descBytes, 0, descBytes.Length)
            rems.Flush()
            rems.Close()

            Dim result As String = Convert.ToBase64String(descBytes)

            rems.Close()

            Dim str As String = "if exists(select * from [空闲时间统计] where 学号 = '" & numtemp & "' and 学期='" & schoolcalendar.Substring(0, 5) & "') " & _
             "begin update [空闲时间统计] set 信息 ='" & result & "' where 学号 = '" & numtemp & "' and 学期='" & schoolcalendar.Substring(0, 5) & "' end else " & _
             "begin insert into [空闲时间统计] values ('" & numtemp & "', '" & nametemp & "','" & result & "','" & schoolcalendar.Substring(0, 5) & "',NULL,'" & GetServerTime() & "') end"
            Try
                sql(str, True)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        End If

    End Sub

    Private Sub loadinfo()
        Dim day As Integer = 0
        Dim week As Integer = 0
        Dim obj(6, 19) As Info_Time_Node

        For day = 0 To 6
            For week = 0 To 19
                obj(day, week) = New Info_Time_Node(False, False, False)
            Next
        Next

        Dim str As String = "select 信息 from [空闲时间统计] where 学号 = '" & numtemp & "' and 学期='" & schoolcalendar.Substring(0, 5) & "'"
        Try
            sql(str, True)
            If myreader.Read Then
                Dim formatter As IFormatter = New BinaryFormatter()

                If myreader.Item(0).ToString = "" Then
                    Exit Try
                End If

                Dim buffer() As Byte = Convert.FromBase64String(myreader.Item(0).ToString)
                Dim stream As MemoryStream = New MemoryStream(buffer)
                obj = formatter.Deserialize(stream)
                stream.Flush()
                stream.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Deserialize_Info(obj)
        Label4.Text = "当前显示：" & nametemp
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            save()
            MsgBox("保存成功！")
            list()
        Catch ex As Exception
            MsgBox("数据提交出错，请检查网络连接")
        End Try
    End Sub

    Private Function Serialize_Info() As Boolean
        Dim week As Integer = 0
        Dim day As Integer = 0
        Dim time As Integer = 0
        Dim isEmpty As Boolean = True

        For time = 0 To 2
            For day = 0 To 6
                For week = 0 To 19
                    If Clb(day, week).GetItemChecked(time) = True Then
                        isEmpty = False
                        Exit For
                    End If
                Next
                If isEmpty = False Then
                    Exit For
                End If
            Next
            If isEmpty = False Then
                Exit For
            End If
        Next

        If isEmpty = False Then
            For day = 0 To 6
                For week = 0 To 19
                    Info_Time(day, week).setMorning(IIf(Clb(day, week).GetItemChecked(0) = True, True, False))
                    Info_Time(day, week).setAfternoon(IIf(Clb(day, week).GetItemChecked(1) = True, True, False))
                    Info_Time(day, week).setNight(IIf(Clb(day, week).GetItemChecked(2) = True, True, False))
                Next
            Next
            Return False
        Else
            For day = 0 To 6
                For week = 0 To 19
                    clean_Info_Time(day, week)
                Next
            Next
            Return True
        End If
    End Function

    Private Sub Deserialize_Info(ByVal obj As Info_Time_Node(,))
        Dim week As Integer = 0
        Dim day As Integer = 0
        For day = 0 To 6
            For week = 0 To 19
                Clb(day, week).SetItemChecked(0, IIf(obj(day, week).getMorning(), True, False))
                Clb(day, week).SetItemChecked(1, IIf(obj(day, week).getAfternoon(), True, False))
                Clb(day, week).SetItemChecked(2, IIf(obj(day, week).getNight(), True, False))
            Next
        Next
    End Sub

    Private Sub clean_Info_Time(ByVal day As Integer, ByVal week As Integer)
        Info_Time(day, week).setMorning(False)
        Info_Time(day, week).setAfternoon(False)
        Info_Time(day, week).setNight(False)
    End Sub

#End Region

#Region "窗体事件"

    Private Sub TimeCollection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        save()
    End Sub

    Private Sub TimeCollection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        initialize()

        numtemp = usernum
        nametemp = username

        If authority = 0 Then
            Panel2.Visible = False
            Panel2.Enabled = False
            Me.Width = 785
        ElseIf authority = 8 Then
            list()
            Button1.Enabled = False
            Button1.Visible = False
        End If

        loadinfo()
        allchecked("", e)
    End Sub

    Private Sub ListBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.MouseEnter
        ListBox1.Focus()
    End Sub

    Private Sub ListBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedValueChanged
        Try
            save()
            numtemp = ListBox1.SelectedItem.ToString().Substring(0, 9)
            nametemp = ListBox1.SelectedItem.ToString().Substring(10, ListBox1.SelectedItem.ToString().Length - 10)
            loadinfo()
            allchecked("", e)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.MouseEnter
        ListBox2.Focus()
    End Sub

    Private Sub ListBox2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedValueChanged
        Try
            save()
            numtemp = ListBox2.SelectedItem.ToString().Substring(0, 9)
            nametemp = ListBox2.SelectedItem.ToString().Substring(10, ListBox2.SelectedItem.ToString().Length - 10)
            loadinfo()
            list()
            allchecked("", e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            save()
            MsgBox("保存成功！")
            list()
        Catch ex As Exception
            MsgBox("数据提交出错，请检查网络连接")
        End Try
    End Sub

    Private Sub Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTRefresh.Click
        loadinfo()
        allchecked("", e)
        list()
    End Sub

    Private Sub out_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles out.Click
        Dim sheet_out As New SheetOut
        sheet_out.ShowDialog()
        sheet_out.Dispose()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        Dim Clear_Info As New ClearInfo
        Clear_Info.ShowDialog()
        Clear_Info.Dispose()
        numtemp = String.Empty
        nametemp = String.Empty
        list()
    End Sub

    Private Sub btAutoArrangeDuty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAutoArrangeDuty.Click
        Dim Auto_Arrange_Duty As New AutoArrangeDuty
        Auto_Arrange_Duty.ShowDialog()
        Auto_Arrange_Duty.Dispose()
    End Sub

    Private Sub btAutoArrangeAssist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAutoArrangeAssist.Click
        Dim Auto_Arrange_Assist As New AutoArrangeAssist
        Auto_Arrange_Assist.ShowDialog()
        Auto_Arrange_Assist.Dispose()
    End Sub

#End Region

#Region "列表事件"

    Private Sub list()   '列表中读取学生信息
        Dim str As String
        Dim m As Boolean
        Dim i, j As Integer
        Dim tablelist1, tablelist2 As New DataTable
        Try
            str = "select distinct 学号,姓名 from [空闲时间统计] where (信息 <> '' or 信息 is not NULL) and 学期='" & schoolcalendar.Substring(0, 5) & "'"
            tablelist1 = gettable("1", str, True)
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            For i = 0 To tablelist1.Rows.Count - 1
                ListBox1.Items.Add(tablelist1.Rows(i).Item("学号") & " " & tablelist1.Rows(i).Item("姓名"))
            Next
            str = "select distinct 学号,姓名 from [member] where 年级='大一' or 年级='大二' or 年级='大三'"
            tablelist2 = gettable("2", str, True)
            For j = 0 To tablelist2.Rows.Count - 1
                m = True
                For i = 0 To tablelist1.Rows.Count - 1
                    If tablelist1.Rows(i).Item("学号") = tablelist2.Rows(j).Item("学号") Then
                        m = False
                        Continue For
                    End If
                Next
                If m = True Then
                    ListBox2.Items.Add(tablelist2.Rows(j).Item("学号") & " " & tablelist2.Rows(j).Item("姓名"))
                End If
            Next
            tablelist1.Dispose()
            tablelist2.Dispose()
        Catch ex As Exception
            MsgBox("数据传输较慢，请重试")
            conn.Close()
            Exit Sub
        End Try
        Threading.Thread.Sleep(100)
    End Sub

#End Region

End Class