Public Class SheetOut

    Dim head(6) As Integer
    Dim test As Integer = 1
    Public kongxian(20) As Integer
    Public jishu As Integer = 0
    Public formal(6) As Integer

    Public Structure Arrangement     '值班和助课安排数组  
        Dim num As Integer
        Dim info As Integer
    End Structure

    Public Function decode(ByVal num) As Boolean
        formal(6) = num Mod 10
        formal(5) = (num - formal(6)) / 10 Mod 10
        formal(4) = (num - formal(6) - formal(5) * 10) / 100 Mod 10
        formal(3) = (num - formal(6) - formal(5) * 10 - formal(4) * 100) / 1000 Mod 10
        formal(2) = (num - formal(6) - formal(5) * 10 - formal(4) * 100 - formal(3) * 1000) / 10000 Mod 10
        formal(1) = (num - formal(6) - formal(5) * 10 - formal(4) * 100 - formal(3) * 1000 - formal(2) * 10000) / 100000 Mod 10
        formal(0) = (num - formal(6) - formal(5) * 10 - formal(4) * 100 - formal(3) * 1000 - formal(2) * 10000 - formal(1) * 100000) / 1000000 Mod 10
        Return True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            MsgBox("请调整输出范围")
            Exit Sub
        End If

        Dim i, j, z As Integer
        Dim str, strname(2) As String

        exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        For j = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
            exbook.Sheets.Add()
            exsheet = exbook.Sheets(1)
            exsheet.Name = j + 1
            exsheet.Range("a1:i2").WrapText = True
            printe(2, 1, "下午")
            printe(1, 2, "周一")
            printe(1, 3, "周二")
            printe(1, 4, "周三")
            printe(1, 5, "周四")
            printe(1, 6, "周五")
            printe(1, 7, "周六")
            printe(1, 8, "周日")

            For i = 0 To 6
                str = "select distinct * from [空闲时间统计] where 周次='" & j + 1 & "' and 信息<>0 and 学期='" & schoolcalendar.Substring(0, 5) & "'"
                sql(str, True)

                strname(1) = ""

                While myreader.Read
                    decode(myreader.Item("信息"))
                    For z = 0 To 6
                        head(z) = formal(z)
                    Next
                    If head(i) = 1 Then

                    ElseIf head(i) = 2 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 3 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 4 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 5 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 6 Then

                    ElseIf head(i) = 7 Then

                    End If
                End While
                printe(2, i + 2, Trim(strname(1)))
                conn.Close()
            Next
        Next
        exsto("d:\助课空闲时间输出（分工作簿）.xlsx")
    End Sub
    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            MsgBox("请调整输出范围")
            Exit Sub
        End If

        Dim i, p, q, m As Integer

        Dim doubi(5, 6) As Integer
        Dim str, strname(5, 6), shabi(100) As String
        Dim sb, sb2 As DataTable

        exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        exbook.Sheets.Add()
        exsheet = exbook.Sheets(1)
        exsheet.Name = "空闲时间"
        exsheet.Range("a1:i9").WrapText = True
        exsheet.Range("a1:i1").Merge()
        exsheet.Range("a3:a5").Merge()
        exsheet.Range("a7:a9").Merge()
        printe(1, 1, "空闲时间")
        printe(3, 1, "单周")
        printe(7, 1, "双周")
        printe(3, 2, "早上")
        printe(4, 2, "下午")
        printe(5, 2, "晚上")
        printe(7, 2, "早上")
        printe(8, 2, "下午")
        printe(9, 2, "晚上")
        printe(2, 3, "周一")
        printe(2, 4, "周二")
        printe(2, 5, "周三")
        printe(2, 6, "周四")
        printe(2, 7, "周五")
        printe(2, 8, "周六")
        printe(2, 9, "周日")
        str = "select distinct 学号 from [空闲时间统计] where 信息<>0 and 学期='" & schoolcalendar.Substring(0, 5) & "'"
        sb = gettable("sb", str, True)
        For p = 0 To 5
            For q = 0 To 6
                strname(p, q) = ""
            Next
        Next
        For m = 0 To sb.Rows.Count - 1
            str = "select distinct * from [空闲时间统计] where 学号='" & sb.Rows(m).Item("学号") & "' and 学期='" & schoolcalendar.Substring(0, 5) & "'"
            sql(str, True)
            If myreader.Read Then

                For p = 0 To 5
                    For q = 0 To 6
                        doubi(p, q) = 1
                    Next
                Next

                For i = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
                    str = "select * from [空闲时间统计] where 学号='" & sb.Rows(m).Item("学号") & "' and 周次=" & i + 1 & " and 学期='" & schoolcalendar.Substring(0, 5) & "'"
                    sb2 = gettable("sb", str, True)
                    If i Mod 2 = 1 Then
                        p = 3
                    Else
                        p = 0
                    End If
                    If sb2.Rows.Count = 0 Then
                        test = 0
                    Else
                        decode(sb2.Rows(0).Item("信息"))
                        test = 1
                    End If

                    For q = 0 To 6
                        If (formal(q) Mod 2 = 0 Or test = 0) Then
                            doubi(p + 0, q) *= 0
                        End If
                        If (formal(q) < 2 Or formal(q) > 5 Or test = 0) Then
                            doubi(p + 1, q) *= 0
                        End If
                        If (formal(q) < 4 Or test = 0) Then
                            doubi(p + 2, q) *= 0
                        End If
                    Next
                Next

                For p = 0 To 5
                    For q = 0 To 6
                        If doubi(p, q) = 1 Then
                            strname(p, q) &= myreader.Item("姓名") & " "
                        End If
                    Next
                Next
            End If
            conn.Close()
        Next

        For p = 0 To 2
            For q = 0 To 6
                printe(p + 3, q + 3, strname(p, q))
            Next
        Next
        For p = 3 To 5
            For q = 0 To 6
                printe(p + 4, q + 3, strname(p, q))
            Next
        Next

        exsto("d:\值班空闲时间输出.xlsx")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            MsgBox("请调整输出范围")
            Exit Sub
        End If

        Dim i, j, z As Integer
        Dim str, strname(2) As String

        exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        exbook.Sheets.Add()
        exsheet = exbook.Sheets(1)
        For j = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
            exsheet.Range("a1:i80").WrapText = True
            exsheet.Range("a" & 1 + j * 4 & ":h" & 1 + j * 4).Merge()
            printe(1 + j * 4, 1, "第" & j + 1 & "周空闲时间")
            printe(3 + j * 4, 1, "下午")
            printe(2 + j * 4, 2, "周一")
            printe(2 + j * 4, 3, "周二")
            printe(2 + j * 4, 4, "周三")
            printe(2 + j * 4, 5, "周四")
            printe(2 + j * 4, 6, "周五")
            printe(2 + j * 4, 7, "周六")
            printe(2 + j * 4, 8, "周日")
            For i = 0 To 6
                str = "select distinct * from [空闲时间统计] where 周次='" & j + 1 & "' and 信息<>0 and 学期='" & schoolcalendar.Substring(0, 5) & "'"
                sql(str, True)
                strname(1) = ""
                While myreader.Read
                    decode(myreader.Item("信息"))
                    For z = 0 To 6
                        head(z) = formal(z)
                    Next
                    If head(i) = 1 Then

                    ElseIf head(i) = 2 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 3 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 4 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 5 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 6 Then
                    ElseIf head(i) = 7 Then
                    End If
                End While
                printe(3 + j * 4, i + 2, Trim(strname(1)))
                conn.Close()
            Next
        Next
        exsto("d:\助课空闲时间输出（不分工作簿）.xlsx")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            MsgBox("请调整输出范围")
            Exit Sub
        End If

        Dim i, j, z As Integer
        Dim str, strname(2) As String

        exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        For j = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
            exbook.Sheets.Add()
            exsheet = exbook.Sheets(1)
            exsheet.Name = j + 1
            exsheet.Range("a1:i4").WrapText = True
            printe(2, 1, "早上")
            printe(3, 1, "下午")
            printe(4, 1, "晚上")
            printe(1, 2, "周一")
            printe(1, 3, "周二")
            printe(1, 4, "周三")
            printe(1, 5, "周四")
            printe(1, 6, "周五")
            printe(1, 7, "周六")
            printe(1, 8, "周日")

            For i = 0 To 6
                str = "select distinct * from [空闲时间统计] where 周次='" & j + 1 & "' and 信息<>0 and 学期='" & schoolcalendar.Substring(0, 5) & "'"
                sql(str, True)
                strname(0) = ""
                strname(1) = ""
                strname(2) = ""
                While myreader.Read
                    decode(myreader.Item("信息"))
                    For z = 0 To 6
                        head(z) = formal(z)
                    Next
                    If head(i) = 1 Then
                        strname(0) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 2 Then
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 3 Then
                        strname(0) &= myreader.Item("姓名") & " "
                        strname(1) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 4 Then
                        strname(1) &= myreader.Item("姓名") & " "
                        strname(2) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 5 Then
                        strname(0) &= myreader.Item("姓名") & " "
                        strname(1) &= myreader.Item("姓名") & " "
                        strname(2) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 6 Then
                        strname(2) &= myreader.Item("姓名") & " "
                    ElseIf head(i) = 7 Then
                        strname(0) &= myreader.Item("姓名") & " "
                        strname(2) &= myreader.Item("姓名") & " "
                    End If
                End While
                printe(2, i + 2, Trim(strname(0)))
                printe(3, i + 2, Trim(strname(1)))
                printe(4, i + 2, Trim(strname(2)))
                conn.Close()
            Next
        Next
        exsto("d:\总空闲时间输出.xlsx")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim i, j, k, up, down As Integer
        Dim str As String

        str = "select count(distinct 学号) from [空闲时间统计] where 信息<>0 and 学期='" & schoolcalendar.Substring(0, 5) & "'"
        sql(str, True)
        If myreader.Read Then
            k = myreader.Item(0)
        End If

        Dim arrangement((NumericUpDown2.Value - NumericUpDown1.Value + 1) * 21 * k - 1) As Arrangement
        '动态定义结构体数量，k为在数据库中总共有多少人，一周最大空闲时间为21个时间段


        '*******************测试用************************
        exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        exbook.Sheets.Add()
        exsheet = exbook.Sheets(1)
        '*******************测试用************************


        up = 0
        Try
            For j = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
                str = "select * from [空闲时间统计] where 周次='" & j + 1 & "' and 信息<>0"
                sql(str, True)
                While myreader.Read
                    Transcoding(myreader.Item("信息"))
                    down = up + jishu - 1
                    For i = up To down
                        arrangement(i).num = myreader.Item("学号")
                        arrangement(i).info = kongxian(i - up) + (j - NumericUpDown1.Value + 1) * 21
                    Next
                    up = down + 1
                End While
                conn.Close()
            Next



            '*******************测试用************************
            For i = 0 To down
                printe(i + 1, 1, arrangement(i).num)
                printe(i + 1, 2, arrangement(i).info)
            Next
            exsto("d:\总.xlsx")
            '*******************测试用************************



        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

    End Sub

    Private Function Transcoding(ByVal info As String)    '将数据库中储存的关于空闲信息的编码数据转码成自动排班程序所需的编码
        Dim i, z As Integer
        Dim flag(21) As Boolean


        '****************************清除临时数据********************************
        For i = 0 To 20
            flag(i) = False
            kongxian(i) = 0
        Next
        jishu = 0
        '****************************清除临时数据********************************

        '****************************解码********************************
        decode(info)
        For z = 0 To 6
            head(z) = formal(z)
        Next
        '****************************解码********************************

        '****************************读码及重新编码********************************
        For i = 0 To 6
            If head(i) = 1 Then

                flag(3 * i) = True
            ElseIf head(i) = 2 Then
                flag(3 * i + 1) = True
            ElseIf head(i) = 3 Then
                flag(3 * i) = True
                flag(3 * i + 1) = True
            ElseIf head(i) = 4 Then
                flag(3 * i + 1) = True
                flag(3 * i + 2) = True
            ElseIf head(i) = 5 Then
                flag(3 * i) = True
                flag(3 * i + 1) = True
                flag(3 * i + 2) = True
            ElseIf head(i) = 6 Then
                flag(3 * i + 2) = True
            ElseIf head(i) = 7 Then
                flag(3 * i) = True
                flag(3 * i + 2) = True
            End If
        Next

        For i = 0 To 20
            If flag(i) = True Then
                kongxian(jishu) = i + 1
                jishu += 1
            End If
        Next
        '****************************读码及重新编码********************************

        Return 0
    End Function

End Class