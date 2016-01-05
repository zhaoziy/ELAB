Public Class Data_IO

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim inputclasslist As New InputClassList
            inputclasslist.ShowDialog()
            inputclasslist.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim outputdate As Date
        Dim outputdatestr As String
        Dim outputdatenow As Date = Now.Date
        Try
            outputdate = InputBox("请输入导出信息日期（例：2012/12/12）：", "选课信息导出", outputdatenow)
            outputdatestr = Format(outputdate, "yyyy-MM-dd")
            daochu(outputdatestr)
        Catch
        End Try
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        outputsignpaper()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        chuqin()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim scorecaculate As New scorecaculate
        scorecaculate.ShowDialog()
        scorecaculate.Dispose()
    End Sub

    Private Sub Data_IO_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Data_IO_Panel.HandleCreated

        init()

    End Sub

#Region "上课同学信息导出"
    Public Sub daochu(ByVal datenowstr)
        'init()    '程序必须函数，前边过程中已经读取了（调试时使用）
        Dim datenow As Date = Now.Date
        Dim i As Integer
        Dim hardware, software As String
        Dim yj As Integer
        Dim rj As Integer
        Dim yjweek As Integer
        Dim yjday As Integer
        Dim rjweek As Integer
        Dim rjday As Integer
        Dim tablename1 As String = "[" & schoolcalendar & "计算机安装与调试技术]"
        Dim searchsql As String
        searchsql = "select 学号,姓名,院系,硬件时间,软件时间 from " & tablename1 & " where CONVERT(varchar(10),选课时间, 23)='" & datenowstr & "'"
        Dim tablexuanke As New DataTable
        Try            '选课名单表
            MsgBox("请不要在运行过程中操作Excel！")
            tablexuanke = gettable("选课", searchsql, False)
            If tablexuanke.Rows.Count > 0 Then
                exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
                exsta()
                printe(1, 1, "学号")
                printe(1, 2, "姓名")
                printe(1, 3, "院系")
                printe(1, 4, "硬件时间")
                printe(1, 5, "软件时间")
                printe(1, 6, "签到")
                exsheet.Range("a1:a41").ColumnWidth = 12
                exsheet.Range("b1:b41").ColumnWidth = 11
                exsheet.Range("c1:c41").ColumnWidth = 25
                exsheet.Range("d1:d41").ColumnWidth = 11.7
                exsheet.Range("e1:e41").ColumnWidth = 11.7
                exsheet.Range("f1:f41").ColumnWidth = 12
                exsheet.Range("a1:f1").Font.Bold = True
                exsheet.Range("a1:f65").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                exsheet.Range("a1:f65").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                exsheet.Range("a1:f65").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                exsheet.Range("a1:f65").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                exsheet.Range("a1:f65").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).Weight = 2
                exsheet.Range("a1:f65").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).Weight = 2
                exsheet.Range("a1:f65").HorizontalAlignment = 3
                For i = 1 To tablexuanke.Rows.Count
                    If tablexuanke.Rows(i - 1).Item("硬件时间").ToString.Trim() <> "" Then
                        yj = tablexuanke.Rows(i - 1).Item("硬件时间").ToString.Trim()
                        yjday = yj Mod 100
                        yjweek = (yj - yjday) / 100
                        hardware = "第" & yjweek & "周，" & GetDay(yjday)
                    Else
                        hardware = "未选课"
                    End If
                    If tablexuanke.Rows(i - 1).Item("软件时间").ToString.Trim() <> "" Then
                        rj = tablexuanke.Rows(i - 1).Item("软件时间").ToString.Trim()
                        rjday = rj Mod 100
                        rjweek = (rj - rjday) / 100
                        software = "第" & rjweek & "周，" & GetDay(rjday)
                    Else
                        software = "未选课"
                    End If

                    printe(i + 1, 1, tablexuanke.Rows(i - 1).Item("学号").ToString.Trim())
                    printe(i + 1, 2, tablexuanke.Rows(i - 1).Item("姓名").ToString.Trim())
                    printe(i + 1, 3, tablexuanke.Rows(i - 1).Item("院系").ToString.Trim())
                    printe(i + 1, 4, hardware)
                    printe(i + 1, 5, software)
                Next
            Else
                MsgBox("本天无数据")
                Exit Sub
            End If

            Dim sFileName As String
            Try
                datenow = (Convert.ToDateTime(datenowstr))
                Dim datestr As String = datenow.Year.ToString & "年" & datenow.Month.ToString & "月" & datenow.Day.ToString & "日选课名单"
                sFileName = "D:\" & datestr & ".xlsx"    '文件位置及名称
                exsto(sFileName)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "系统提示")
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        tablexuanke.Dispose()
    End Sub
#End Region

#Region "助课出勤次数统计"
    Public Sub chuqin()
        Dim table As DataTable
        Dim i As Integer
        Try
            'inputscore.collection()
            exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
            exsta()
            printe(1, 1, "助教出勤次数统计")
            printe(2, 1, "学号")
            printe(2, 2, "姓名")
            printe(2, 3, "院系")
            printe(2, 4, "组别")
            printe(2, 5, "年级")
            printe(2, 6, "主讲次数")
            printe(2, 7, "助课次数")
            printe(2, 8, "总次数")
            exsheet.Range("a1:h1").Merge()
            strSql = "select 学号,姓名,院系,组别,年级,主讲,助课 from member"
            table = gettable("member", strSql, True)
            For i = 0 To table.Rows.Count - 1
                printe(i + 3, 1, table.Rows(i).Item("学号"))
                printe(i + 3, 2, table.Rows(i).Item("姓名"))
                printe(i + 3, 3, table.Rows(i).Item("院系"))
                printe(i + 3, 4, table.Rows(i).Item("组别"))
                printe(i + 3, 5, table.Rows(i).Item("年级"))
                printe(i + 3, 6, table.Rows(i).Item("主讲"))
                printe(i + 3, 7, table.Rows(i).Item("助课"))
                printe(i + 3, 8, CInt(table.Rows(i).Item("主讲")) + CInt(table.Rows(i).Item("助课")))
            Next
            table.Dispose()
        Catch ex As Exception

        End Try
        exsto("d:\助教出勤次数统计.xlsx")
    End Sub
#End Region

#Region "导出签到单"

    Public Sub outputsignpaper()
        Dim week, day, paper, line As Integer
        Dim hardtime, hardtime1, softtime, softtime1 As String
        Dim num, name, depart As String
        Dim tableinfo As New DataTable
        getweek()
        MsgBox("请不要在运行过程中操作Excel！")

        exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
        exsta()
        exsheet.Range("a1:a41").ColumnWidth = 4.38
        exsheet.Range("b1:b41").ColumnWidth = 10.13
        exsheet.Range("c1:c41").ColumnWidth = 9.25
        exsheet.Range("d1:d41").ColumnWidth = 30.5
        exsheet.Range("e1:e41").ColumnWidth = 15.5
        exsheet.Range("f1:f41").ColumnWidth = 11.38

        For week = 0 To CInt(YJ(1)) - CInt(YJ(0))   '第几周
            For day = 0 To 6
                paper = week * 7 + day
                hardtime = "第" & week + CInt(YJ(0)) & "周" & GetDay(day + 1)
                If CInt(YJ(0)) < 10 Then
                    hardtime1 = (week + CInt(YJ(0))) & "0" & (day + 1)
                Else
                    hardtime1 = (week + CInt(YJ(0))) & (day + 1)
                End If

                printe(paper * 42 + 1, 1, "硬件成绩签到单（" & hardtime & "）")
                exapp.ActiveSheet.cells(1, 1).font.size = 24
                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 2).Font.Bold = True
                exsheet.Range("a" & paper * 42 + 1 & ":a" & paper * 42 + 1).Font.Size = 24
                exsheet.Range("a" & paper * 42 + 2 & ":f" & paper * 42 + 2).Font.Size = 15
                exsheet.Range("a" & paper * 42 + 4 & ":f" & paper * 42 + 42).Font.Size = 11
                exsheet.Range("a" & paper * 42 + 3 & ":a" & paper * 42 + 42).Font.Size = 14

                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).Weight = 2

                setpaper(0.8, 0.8, 2.5, 1.9)
                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 1).Merge()
                exsheet.Range("a" & paper * 42 + 1 & ":f" & paper * 42 + 42).HorizontalAlignment = 3
                exsheet.Range("a" & paper * 42 + 1 & ":a" & paper * 42 + 1).RowHeight = 31.5
                exsheet.Range("a" & paper * 42 + 2 & ":f" & paper * 42 + 42).RowHeight = 18.5

                printe(paper * 42 + 2, 1, "序号")
                printe(paper * 42 + 2, 2, "学号")
                printe(paper * 42 + 2, 3, "姓名")
                printe(paper * 42 + 2, 4, "院系")
                printe(paper * 42 + 2, 5, "签到")
                printe(paper * 42 + 2, 6, "成绩")

                strSql = "select 学号,姓名,院系 from [" & schoolcalendar & "计算机安装与调试技术] Where 硬件时间 = " & hardtime1
                tableinfo = gettable("查询", strSql, False)
                If tableinfo.Rows.Count > 0 Then
                    For line = 3 To tableinfo.Rows.Count + 2
                        printe(paper * 42 + line, 1, line - 2)
                        num = tableinfo.Rows(line - 3).Item("学号").ToString.Trim
                        name = tableinfo.Rows(line - 3).Item("姓名").ToString.Trim
                        depart = tableinfo.Rows(line - 3).Item("院系").ToString.Trim
                        printe(paper * 42 + line, 2, num)
                        printe(paper * 42 + line, 3, name)
                        printe(paper * 42 + line, 4, depart)
                    Next
                    For line = tableinfo.Rows.Count + 3 To 42
                        printe(paper * 42 + line, 1, line - 2)
                    Next
                Else
                    For line = 3 To 42
                        printe(paper * 42 + line, 1, line - 2)
                    Next
                End If
            Next
        Next
        exsto("d:\硬件实验签到单.xlsx")

        exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
        exsta()
        exsheet.Range("a1:a41").ColumnWidth = 4.38
        exsheet.Range("b1:b41").ColumnWidth = 10.0
        exsheet.Range("c1:c41").ColumnWidth = 9.25
        exsheet.Range("d1:d41").ColumnWidth = 22
        exsheet.Range("e1:e41").ColumnWidth = 10
        exsheet.Range("f1:f41").ColumnWidth = 12
        exsheet.Range("g1:g41").ColumnWidth = 12
        For week = CInt(RJ(0)) - CInt(YJ(0)) To CInt(RJ(1)) - CInt(YJ(0))   '第几周
            For day = 0 To 6
                paper = week * 7 + day - 7 * (CInt(RJ(0)) - CInt(YJ(0)))
                softtime = "第" & week + CInt(YJ(0)) & "周" & GetDay(day + 1)
                If CInt(YJ(0)) < 10 Then
                    softtime1 = (week + CInt(YJ(0))) & "0" & (day + 1)
                Else
                    softtime1 = (week + CInt(YJ(0))) & (day + 1)
                End If

                printe(paper * 42 + 1, 1, "软件成绩签到单（" & softtime & "）")
                exapp.ActiveSheet.cells(1, 1).font.size = 24
                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 2).Font.Bold = True
                exsheet.Range("a" & paper * 42 + 1 & ":a" & paper * 42 + 1).Font.Size = 24
                exsheet.Range("a" & paper * 42 + 2 & ":g" & paper * 42 + 2).Font.Size = 15
                exsheet.Range("a" & paper * 42 + 4 & ":g" & paper * 42 + 42).Font.Size = 11
                exsheet.Range("a" & paper * 42 + 3 & ":a" & paper * 42 + 42).Font.Size = 14

                setpaper(0.8, 0.8, 2.5, 1.9)
                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 1).Merge()
                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 42).HorizontalAlignment = 3
                exsheet.Range("a" & paper * 42 + 1 & ":a" & paper * 42 + 1).RowHeight = 31.5
                exsheet.Range("a" & paper * 42 + 2 & ":g" & paper * 42 + 42).RowHeight = 18.5

                printe(paper * 42 + 2, 1, "序号")
                printe(paper * 42 + 2, 2, "学号")
                printe(paper * 42 + 2, 3, "姓名")
                printe(paper * 42 + 2, 4, "院系")
                printe(paper * 42 + 2, 5, "签到")
                printe(paper * 42 + 2, 6, "实验成绩")
                printe(paper * 42 + 2, 7, "报告成绩")

                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).Weight = 2
                exsheet.Range("a" & paper * 42 + 1 & ":g" & paper * 42 + 42).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).Weight = 2

                strSql = "select 学号,姓名,院系 from [" & schoolcalendar & "计算机安装与调试技术] Where 软件时间 = " & softtime1
                tableinfo = gettable("查询", strSql, False)
                If tableinfo.Rows.Count > 0 Then
                    For line = 3 To tableinfo.Rows.Count + 2
                        printe(paper * 42 + line, 1, line - 2)
                        num = tableinfo.Rows(line - 3).Item("学号").ToString.Trim
                        name = tableinfo.Rows(line - 3).Item("姓名").ToString.Trim
                        depart = tableinfo.Rows(line - 3).Item("院系").ToString.Trim
                        printe(paper * 42 + line, 2, num)
                        printe(paper * 42 + line, 3, name)
                        printe(paper * 42 + line, 4, depart)
                    Next
                    For line = tableinfo.Rows.Count + 3 To 42
                        printe(paper * 42 + line, 1, line - 2)
                    Next
                Else
                    For line = 3 To 42
                        printe(paper * 42 + line, 1, line - 2)
                    Next
                End If
                tableinfo.Dispose()
            Next
        Next
        exsto("d:\软件实验签到单.xlsx")
    End Sub

#End Region

End Class