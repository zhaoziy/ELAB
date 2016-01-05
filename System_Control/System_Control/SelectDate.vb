Imports System.Windows.Forms
Imports System.Drawing

Public Class SelectDate

    Private weekno As Integer
    Private Lbl(6, 9) As Label   '**************容量为70（7*10）的数组**************
    Private LblWeek(9) As Label  '**************容量为10的数组**************
    Private LblTime(6) As Label  '**************容量为7的数组**************
    Private Txt(6, 9) As TextBox  '**************容量为70（7*10）的数组**************
    Private Txt_Assist(6, 9) As TextBox  '**************容量为70（7*10）的数组**************

#Region "初始化，绘制表格"

    Public Sub initialize()

        'init()
        getweek()
        weekno = CInt(RJ(1)) - CInt(YJ(0)) + 1

        Dim Width As Integer = LblStandard.Width
        Dim Height As Integer = LblStandard.Height
        Dim i, j As Integer
        '*******************时间栏*****************
        For i = 0 To 7 - 1 Step 1
            LblTime(i) = New Label
            LblTime(i).AutoSize = False
            LblTime(i).Height = Height
            LblTime(i).Width = Width
            LblTime(i).Top = LblStandard.Top
            LblTime(i).Left = LblStandard.Left + (i + 1) * Width
            LblTime(i).BorderStyle = BorderStyle.FixedSingle
            LblTime(i).BackColor = Color.FromArgb(128, 255, 255)
            LblTime(i).Font = New Font("宋体", 12)
            If i < 7 Then LblTime(i).Text = GetDay(i + 1)
            LblTime(i).TextAlign = ContentAlignment.MiddleCenter
            PanelTime.Controls.Add(LblTime(i))
        Next
        '***********************周次栏***********************
        For j = 0 To weekno - 1 Step 1
            LblWeek(j) = New Label
            LblWeek(j).AutoSize = False
            LblWeek(j).Height = Height
            LblWeek(j).Width = Width
            LblWeek(j).Top = LblStandard.Top + (j + 1) * Height + (j + 1) * (TextStandard.Height + 2)
            LblWeek(j).Left = LblStandard.Left
            LblWeek(j).BorderStyle = BorderStyle.FixedSingle
            LblWeek(j).BackColor = Color.FromArgb(128, 255, 255)
            LblWeek(j).Font = New Font("宋体", 12)

            Dim Decade As Integer = j + CInt(YJ(0))
            If Decade < 10 Then
                LblWeek(j).Text = "第 " & "0" & (j + CInt(YJ(0))).ToString & " 周"
            Else
                LblWeek(j).Text = "第 " & (j + CInt(YJ(0))).ToString & " 周"
            End If
            LblWeek(j).TextAlign = ContentAlignment.MiddleCenter
            PanelTime.Controls.Add(LblWeek(j))
        Next
        '*********************表格区********************
        For j = 0 To weekno - 1
            For i = 0 To 6     'i代表周几，j代表第几周
                Lbl(i, j) = New Label
                Lbl(i, j).Name = "lbl" & i.ToString & j.ToString
                Lbl(i, j).AutoSize = False
                Lbl(i, j).Width = Width
                Lbl(i, j).Height = Height
                Lbl(i, j).Top = LblStandard.Top + (j + 1) * Height + (j + 1) * (TextStandard.Height + 2)
                Lbl(i, j).Left = LblStandard.Left + (i + 1) * Width
                Lbl(i, j).BorderStyle = BorderStyle.Fixed3D
                Lbl(i, j).BackColor = Color.FloralWhite
                Lbl(i, j).TextAlign = ContentAlignment.MiddleCenter
                Lbl(i, j).Font = New Font("宋体", 12)
                PanelTime.Controls.Add(Lbl(i, j))
                Lbl(i, j).TabIndex = 1000 + (j + 1) * 10 + i + 1
                AddHandler Lbl(i, j).DoubleClick, New System.EventHandler(AddressOf Me.lbl_doubleclick)
                AddHandler Lbl(i, j).MouseEnter, New System.EventHandler(AddressOf Me.lbl_MouseEnter)
            Next
        Next

        '***********************文本框栏***********************
        TextStandard.Enabled = False
        TextStandard.Visible = False
        For j = 0 To weekno - 1
            For i = 0 To 6     'i代表周几，j代表第几周
                Txt(i, j) = New TextBox
                Txt(i, j).MaxLength = 2
                Txt(i, j).Name = "txt" & i.ToString & j.ToString
                Txt(i, j).Width = TextStandard.Width
                Txt(i, j).Height = TextStandard.Height
                Txt(i, j).Top = TextStandard.Top + (j + 1) * Height + (j + 1) * (TextStandard.Height + 2)
                Txt(i, j).Left = TextStandard.Left + (i + 1) * Width
                PanelTime.Controls.Add(Txt(i, j))
                Txt(i, j).TabIndex = 2000 + (j + 1) * 10 + i + 1
                AddHandler Txt(i, j).TextChanged, New System.EventHandler(AddressOf Me.Txt_TextChanged)
            Next
        Next

        TextStandard_Assist.Enabled = False
        TextStandard_Assist.Visible = False
        For j = 0 To weekno - 1
            For i = 0 To 6     'i代表周几，j代表第几周
                Txt_Assist(i, j) = New TextBox
                Txt_Assist(i, j).MaxLength = 1
                Txt_Assist(i, j).Name = "txt" & i.ToString & j.ToString
                Txt_Assist(i, j).Width = TextStandard_Assist.Width
                Txt_Assist(i, j).Height = TextStandard_Assist.Height
                Txt_Assist(i, j).Top = TextStandard_Assist.Top + (j + 1) * Height + (j + 1) * (TextStandard_Assist.Height + 2)
                Txt_Assist(i, j).Left = TextStandard_Assist.Left + (i + 1) * Width
                PanelTime.Controls.Add(Txt_Assist(i, j))
                Txt_Assist(i, j).TabIndex = 3000 + (j + 1) * 10 + i + 1
                AddHandler Txt_Assist(i, j).TextChanged, New System.EventHandler(AddressOf Me.Txt_Assist_TextChanged)
            Next
        Next
        gettime()
        getremain()
    End Sub

    Private Function gettime() As Boolean     '***************填充表格****************
        Dim i, j As Integer
        For i = 0 To CInt(YJ(1)) - CInt(YJ(0))
            For j = 0 To 6
                Lbl(j, i).Text = "硬件拆装"
                Lbl(j, i).BackColor = Color.LightGreen
            Next
        Next
        For i = CInt(RJ(0)) - CInt(YJ(0)) To CInt(RJ(1)) - CInt(YJ(0))
            For j = 0 To 6
                Lbl(j, i).Text = "软件安装"
                Lbl(j, i).BackColor = Color.Pink
            Next
        Next
    End Function

    Private Sub getremain()    '**************读取可选课区域****************
        Application.DoEvents()
        Dim i, j As Integer
        Dim sqlstr As String
        For i = 0 To YJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select 是否可选 from [上课日期] "
                sqlstr &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "'"
                If sql(sqlstr, True) And myreader.Read Then
                    If myreader.Item(0) = "否" Then
                        Lbl(j, i).Text = "禁止选课"
                        Lbl(j, i).BackColor = Color.Red
                    End If
                End If
                conn.Close()
            Next
        Next
        For i = RJ(0) - YJ(0) To RJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select 是否可选 from [上课日期] "
                sqlstr &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "'"
                If sql(sqlstr, True) And myreader.Read Then
                    If myreader.Item(0) = "否" Then
                        Lbl(j, i).Text = "禁止选课"
                        Lbl(j, i).BackColor = Color.Red
                    End If
                End If
                conn.Close()
            Next
        Next
    End Sub

    Private Sub Txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)   '**************读取课容量区域****************

        Dim week, time As Integer
        week = (sender.tabindex - 2000) \ 10 + YJ(0) - 1
        time = sender.tabindex Mod 10

        updatecmd = "update 上课日期 set 课容量='" & Txt(time - 1, week - CInt(YJ(0))).Text & "' where 周次='" & week & "' and 星期='" & time & "'"
        sql(updatecmd, True)
        conn.Close()

    End Sub

    Private Sub Txt_Assist_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)   '**************读取助教容量区域****************

        Dim week, time As Integer
        week = (sender.tabindex - 3000) \ 10 + YJ(0) - 1
        time = sender.tabindex Mod 10

        updatecmd = "update 上课日期 set 助教容量='" & Txt_Assist(time - 1, week - CInt(YJ(0))).Text & "' where 周次='" & week & "' and 星期='" & time & "'"
        sql(updatecmd, True)
        conn.Close()

    End Sub

    Private Sub gettotal()            '**************读取课容量，助教容量区域****************
        Application.DoEvents()
        Dim i, j As Integer
        Dim sqlstr As String
        For i = 0 To YJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select 课容量 from [上课日期] "
                sqlstr &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "' and 是否可选='是'"
                If sql(sqlstr, True) AndAlso myreader.Read Then

                    If IsDBNull(myreader.Item("课容量")) = True Then
                        Txt(j, i).Text = 0
                    Else
                        Txt(j, i).Text = myreader.Item("课容量")
                    End If

                End If
                conn.Close()
                conn.Dispose()

                sqlstr = "select 助教容量 from [上课日期] "
                sqlstr &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "' and 是否可选='是'"
                If sql(sqlstr, True) AndAlso myreader.Read Then

                    If IsDBNull(myreader.Item("助教容量")) = True Then
                        Txt_Assist(j, i).Text = 0
                    Else
                        Txt_Assist(j, i).Text = myreader.Item("助教容量")
                    End If

                End If
                conn.Close()
                conn.Dispose()
            Next
        Next
        For i = RJ(0) - YJ(0) To RJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select 课容量 from [上课日期] "
                sqlstr &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "' and 是否可选='是'"
                If sql(sqlstr, True) AndAlso myreader.Read Then

                    If IsDBNull(myreader.Item("课容量")) = True Then
                        Txt(j, i).Text = 0
                    Else
                        Txt(j, i).Text = myreader.Item("课容量")
                    End If

                End If
                conn.Close()
                conn.Dispose()

                sqlstr = "select 助教容量 from [上课日期] "
                sqlstr &= "where 星期 = '" & j + 1 & "' and 周次 ='" & i + YJ(0) & "' and 是否可选='是'"
                If sql(sqlstr, True) AndAlso myreader.Read Then

                    If IsDBNull(myreader.Item("助教容量")) = True Then
                        Txt_Assist(j, i).Text = 0
                    Else
                        Txt_Assist(j, i).Text = myreader.Item("助教容量")
                    End If

                End If
                conn.Close()
                conn.Dispose()
            Next
        Next
        For i = 0 To RJ(1) - YJ(0)
            For j = 0 To 6
                If Lbl(j, i).BackColor = Color.Red Then
                    Txt(j, i).Visible = False
                    Txt(j, i).Enabled = False

                    Txt_Assist(j, i).Visible = False
                    Txt_Assist(j, i).Enabled = False
                Else
                    Txt(j, i).Visible = True
                    Txt(j, i).Enabled = True

                    Txt_Assist(j, i).Visible = True
                    Txt_Assist(j, i).Enabled = True
                End If
            Next
        Next
    End Sub

#End Region

#Region "选择日期"

    Private Sub lbl_doubleclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lblback As Color = sender.backcolor
        Dim week, time As Integer
        week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
        time = sender.tabindex Mod 10

        If lblback = Color.Red Then
            If week <= CInt(YJ(1)) Then
                Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.LightGreen
                Lbl(time - 1, week - CInt(YJ(0))).Text = "硬件拆装"
                updatecmd = "update 上课日期 set 是否可选='是',上课类型='硬件课' where 周次='" & week & "' and 星期='" & time & "'"
                sql(updatecmd, True)
                conn.Close()
            ElseIf week >= CInt(RJ(0)) Then
                Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.Pink
                Lbl(time - 1, week - CInt(YJ(0))).Text = "软件安装"
                updatecmd = "update 上课日期 set 是否可选='是',上课类型='软件课' where 周次='" & week & "' and 星期='" & time & "'"
                sql(updatecmd, True)
                conn.Close()
            End If

        ElseIf lblback = Color.LightGreen Or lblback = Color.Pink Then
            updatecmd = "update 上课日期 set 是否可选='否',上课类型=NULL where 周次='" & week & "' and 星期='" & time & "'"
            sql(updatecmd, True)
            conn.Close()
            Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.Red
            Lbl(time - 1, week - CInt(YJ(0))).Text = "禁止选课"
        End If
        gettime()
        getremain()
        gettotal()
    End Sub

    Private Sub lbl_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.backcolor <> Color.FloralWhite Then
            Try
                Dim week, time As Integer
                week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
                time = sender.tabindex Mod 10
                Dim d As Date = DateAdd(DateInterval.Day, (week - 1) * 7 + time - 1, startday)
                Dim course As String = ""
                If week >= YJ(0) And week <= YJ(1) Then course = "安装与调试(硬件部分)"
                If week >= RJ(0) And week <= RJ(1) Then course = "安装与调试(软件部分)"
                Me.ToolTip1.SetToolTip(sender, "第" & week & "周 " & GetDay(time) & vbCrLf & d & vbCrLf & course & vbCrLf)
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

    Private Sub SelectDate_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        initialize()
        gettotal()
        LblStandard.BackColor = Color.FloralWhite
        PanelTime.Height = 650
        Me.Height = 813
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class