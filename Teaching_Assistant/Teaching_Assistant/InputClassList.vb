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

#Region "EXCEL�������ݿ�"
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

        semester = InputBox("�����봴�����ݿ��ѧ�ڣ�����" & schoolcalendar.Substring(0, 5) & "����", "�������ݿ�", schoolcalendar.Substring(0, 5))
        If semester = "" Then
            Exit Sub
        Else
            str = "use class"
            str &= " CREATE TABLE [" & semester & "_�������װ����Լ���] (ѧ�� varchar(50) not null,���� nvarchar(20),Ժϵ nvarchar(20),���ۿ� smallint,Ӳ��ʱ�� smallint,���ʱ�� smallint,Ӳ���ɼ� float,����ɼ� float,�Ծ�ɼ� float,���� varchar(50),��ϵ�绰 varchar(11),���� varchar(32),���� bit,ѡ��ʱ�� datetime,��ע nvarchar(10))"
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
                    'xlssheet.UsedRange.Columns.Count�������
                    num = "b" & i
                    name = "c" & i
                    depart = "f" & i
                    A(1) = Trim(xlssheet.Range(num).Value.ToString)
                    A(2) = Trim(xlssheet.Range(name).Value.ToString)
                    A(3) = Trim(xlssheet.Range(depart).Value.ToString)
                    A(4) = Trim(xlssheet.Name.ToString)
                    str = "insert into [" & semester & "_�������װ����Լ���] VALUES('" & A(1) & "','" & A(2) & "','" & A(3) & "','" & A(4) & "','1801','1901',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'����')"
                    sql(str, False)
                    conn.Close()
                Next
                conn.Close()
            Next
            MsgBox("����ɹ���")
            xlssheet = Nothing
            xlsWorkbook.Close()
            xlsWorkbook = Nothing
            xlsApp.Quit()
            xlsApp = Nothing
            conn.Close()
            'InputClassList.Close()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("������������ԡ�")
            conn.Close()
        End Try
    End Sub
#End Region

End Class