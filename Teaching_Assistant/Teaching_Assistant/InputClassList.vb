Public Class InputClassList

    Private Sub guanbi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guanbi.Click
        Me.Close()
    End Sub

    Private Sub daoru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles daoru.Click
        Dim filename As String
        OpenFileDialog1.ShowDialog()
        filename = OpenFileDialog1.FileName
        If filename = "" Then
            Exit Sub
        Else
            input(filename)
        End If
    End Sub

#Region "EXCEL导入数据库"
    Public Sub input(ByVal filename)
        Dim str As String
        Dim A(4) As String
        Dim i As Integer
        Dim j As Integer
        Dim semester As String
        Dim xlsApp As Microsoft.Office.Interop.Excel.Application
        Dim xlsWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlssheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim num As String
        Dim name As String
        Dim depart As String

        semester = InputBox("请输入创建数据库的学期（例：" & schoolcalendar.Substring(0, 5) & "）：", "创建数据库", schoolcalendar.Substring(0, 5))
        If semester = "" Then
            Exit Sub
        Else
            str = "use class"
            str &= " CREATE TABLE [" & semester & "_计算机安装与调试技术] (学号 varchar(50) not null,姓名 nvarchar(20),院系 nvarchar(20),理论课 smallint,硬件时间 smallint,软件时间 smallint,硬件成绩 float,软件成绩 float,试卷成绩 float,邮箱 varchar(50),联系电话 varchar(11),密码 varchar(32),补课 bit,选课时间 datetime,备注 nvarchar(10))"
            sql(str, False)
            conn.Close()
        End If

        Try
            xlsApp = CreateObject("Excel.Application")
            xlsWorkbook = xlsApp.Workbooks.Open(filename)
            xlsApp.Range("a1").Select()
            For j = 1 To xlsWorkbook.Sheets.Count
                xlssheet = xlsWorkbook.Sheets(j)
                For i = 2 To xlssheet.UsedRange.Rows.Count
                    'xlssheet.UsedRange.Columns.Count最大列数
                    num = "b" & i
                    name = "c" & i
                    depart = "f" & i
                    A(1) = Trim(xlssheet.Range(num).Value.ToString)
                    A(2) = Trim(xlssheet.Range(name).Value.ToString)
                    A(3) = Trim(xlssheet.Range(depart).Value.ToString)
                    A(4) = Trim(xlssheet.Name.ToString)
                    str = "insert into [" & semester & "_计算机安装与调试技术] VALUES('" & A(1) & "','" & A(2) & "','" & A(3) & "','" & A(4) & "','1801','1901',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'正常')"
                    sql(str, False)
                    conn.Close()
                Next
                conn.Close()
            Next
            MsgBox("导入成功！")
            xlssheet = Nothing
            xlsWorkbook.Close()
            xlsWorkbook = Nothing
            xlsApp.Quit()
            xlsApp = Nothing
            conn.Close()
            'InputClassList.Close()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("导入错误，请重试。")
            conn.Close()
        End Try
    End Sub
#End Region

End Class