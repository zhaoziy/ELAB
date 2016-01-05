Public Class scorecaculate

#Region "重置按钮"
    Private Sub chongzhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chongzhi.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub
#End Region

#Region "导出按钮"
    Private Sub daochuwj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles daochuwj.Click

        init()

        If (TextBox1.Text.ToString = "" Or TextBox2.Text.ToString = "" Or TextBox3.Text.ToString = "" Or TextBox4.Text.ToString = "") Then
            MsgBox("成绩比例输入有空项！")
        ElseIf (TextBox1.Text.ToString < 0 Or TextBox2.Text.ToString < 0 Or TextBox3.Text.ToString < 0 Or TextBox4.Text.ToString < 0 Or TextBox1.Text.ToString > 100 Or TextBox2.Text.ToString > 100 Or TextBox3.Text.ToString > 100 Or TextBox4.Text.ToString > 100) Then
            MsgBox("成绩比例输入超限！")
        ElseIf (CInt(TextBox1.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text) + CInt(TextBox4.Text) <> 100) Then
            MsgBox("成绩不为100%！")
        Else
            MsgBox("请不要在运行过程中操作Excel！")
            exapp = New Microsoft.Office.Interop.Excel.Application '定义excel应用程序
            exsta()
            printe(1, 1, "微机安装与调试成绩单")
            exapp.ActiveSheet.Range("A1:J1").Merge()
            printe(2, 1, "学号")
            printe(2, 2, "姓名")
            printe(2, 3, "理论课时间")
            printe(2, 4, "理论课成绩")
            printe(2, 5, "硬件课")
            printe(2, 6, "硬件课加权")
            printe(2, 7, "软件课")
            printe(2, 8, "软件课加权")
            printe(2, 9, "试卷")
            printe(2, 10, "试卷加权")
            printe(2, 11, "总分")
            Dim j As Integer
            Dim line As Integer
            Dim strnum As String
            Dim strname As String
            Dim strlilun As Integer
            Dim strhard As Single
            Dim strhardc As Single
            Dim strsoft As Integer
            Dim strsoftc As Integer
            Dim strtest As Integer
            Dim strtestc As Integer
            Dim strsum As Integer
            Dim softtime As String
            Dim hardtime As String
            Dim liluntime As String
            Try
                sql("SELECT COUNT (*) FROM [" & schoolcalendar & "计算机安装与调试技术]", False)
                myreader.Read()
                j = myreader.Item(0)
                conn.Close()

                For line = 1 To j
                    strSql = "Select top (1) * From [" & schoolcalendar & "计算机安装与调试技术] Where 学号 not in (select top ("
                    strSql &= CStr(line - 1) & ") 学号 from [" & schoolcalendar & "计算机安装与调试技术])"

                    sql(strSql, False)
                    myreader.Read()

                    strnum = myreader.Item(0)  '学号

                    strname = myreader.Item(1) '姓名

                    If (myreader.Item(4).ToString <> "") Then  '硬件时间
                        hardtime = myreader.Item(4)
                    Else
                        hardtime = 1801
                    End If

                    If (myreader.Item(5).ToString <> "") Then  '软件时间
                        softtime = myreader.Item(5)
                    Else
                        softtime = 1901
                    End If

                    If (myreader.Item(3).ToString <> "") Then  '理论时间
                        liluntime = myreader.Item(3)
                    Else
                        liluntime = 0
                    End If

                    If (hardtime <> 1801 And softtime <> 1901) Then  '理论成绩
                        If myreader.Item("备注") = "正常" Then
                            strlilun = TextBox1.Text
                        Else
                            strlilun = CInt(TextBox1.Text) / 2
                        End If
                    Else
                        strlilun = 0
                    End If

                    If (myreader.Item(6).ToString <> "") Then   '硬件成绩
                        strhard = myreader.Item(6)
                    Else
                        strhard = 0
                    End If

                    If (myreader.Item(7).ToString <> "") Then  '软件成绩
                        strsoft = myreader.Item(7)
                    Else
                        strsoft = 0
                    End If

                    If (myreader.Item(8).ToString <> "") Then   '试卷成绩
                        strtest = myreader.Item(8)
                    Else
                        strtest = 0
                    End If

                    strhardc = strhard * TextBox2.Text / 100
                    strsoftc = strsoft * TextBox3.Text / 100
                    strtestc = strtest * TextBox4.Text / 100
                    strsum = strlilun + strsoftc + strhardc + strtestc

                    printe(line + 2, 1, strnum)
                    printe(line + 2, 2, strname)
                    printe(line + 2, 3, liluntime)
                    printe(line + 2, 4, strlilun)
                    printe(line + 2, 5, strhard)
                    printe(line + 2, 6, strhardc)
                    'printe(line + 2, 5, "=d" & line + 2 & "*" & TextBox2.Text & "/100")    '********excel公式**********

                    printe(line + 2, 7, strsoft)
                    printe(line + 2, 8, strsoftc)
                    'printe(line + 2, 7, "=f" & line + 2 & "*" & TextBox2.Text & "/100")    '********excel公式**********

                    printe(line + 2, 9, strtest)
                    printe(line + 2, 10, strtestc)
                    'printe(line + 2, 9, "=h" & line + 2 & "*" & TextBox2.Text & "/100")    '********excel公式**********

                    printe(line + 2, 11, strsum)
                    'printe(line + 2, 10, "=e" & line + 2 & "+g" & line + 2 & "+i" & line + 2 & "")    '********excel公式**********

                    conn.Close()
                Next
                MsgBox("导出成功", MsgBoxStyle.MsgBoxSetForeground)
                Me.Close()
            Catch ex As Exception
                MsgBox("操作被中断！")
                Exit Sub
            End Try
            exsto("d:\" & schoolcalendar & "计算机安装与调试技术成绩单.xlsx")
        End If
        Me.Close()
    End Sub
#End Region

#Region "窗体事件"
    Private Sub ScoreCaculate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub ScoreCaculate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'init()    '调试时使用
    End Sub
#End Region

#Region "退出按钮"
    Private Sub Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quit.Click
        Me.Close()
    End Sub
#End Region
    
End Class