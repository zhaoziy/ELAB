Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Auto_Submit
    Public myexcel As Excel.Application
    Public flag As Boolean = False
    Public kemu As String = "实践成绩"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("如果原先成绩已录或者人为更改过，本程序会直接覆盖掉，所以谨慎操作！", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        Else
            MsgBox("请导入A列为学号，B列为成绩的EXCEL表格，数据从第一行开始，不要加表头。")
            MsgBox("此过程大概需要5-10s左右的时间，期间可能出现暂时假死，属于正常情况！")
            Loadxls()
            Me.WebBrowser1.Navigate("http://zhjw.dlut.edu.cn/cjlrmxAction.do?oper=cjlrAllType")
            'Me.WebBrowser1.Navigate("C:\Users\codeme\Desktop\chengji.html")
            flag = True
        End If
    End Sub

    Private Sub Auto_Submit_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Auto_Submit_Panel.HandleCreated
        Me.WebBrowser1.Navigate("http://zhjw.dlut.edu.cn/")
        flag = False
        ComboBox1.Text = "实践成绩"
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If flag = False Then Exit Sub
        Dim s As HtmlElementCollection = Me.WebBrowser1.Document.GetElementsByTagName("input")
        Dim t As HtmlElementCollection = Me.WebBrowser1.Document.GetElementsByTagName("select")
        Dim i As Byte, j As Byte, cj As String
        For i = 0 To s.Count - 1
            If Mid(s.Item(i).Name, 10) = kemu Then           '实践成绩
                'If Mid(s.Item(i).Name, 10) = "_sj_qm" Then      '实验成绩
                cj = search(Mid(s.Item(i).Name, 1, 9))
                s.Item(i).InnerText = cj
                If cj Is Nothing Then GoTo l1
                If cj IsNot Nothing And (cj.Trim = "0" Or cj.Trim = "") Then
l1:                 For j = 0 To t.Count - 1
                        If Mid(t.Item(j).Name, 1, 9) = Mid(s.Item(i).Name, 1, 9) Then
                            t.Item(j).All(0).InnerText = "缺考"
                            Exit For
                        End If
                    Next
                End If
            End If
        Next
        MsgBox("done!")
        myexcel.Quit()
    End Sub

    Function search(ByVal num As String) As String
        Dim i As Integer, score As String
        score = ""
        Application.DoEvents()
        Try
            For i = 1 To 65535
                If CStr(myexcel.Cells(i, 1).value) = num Then
                    score = CStr(myexcel.Cells(i, 2).value)
                    Exit For
                ElseIf CStr(myexcel.Cells(i, 1).value) = "" Then
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
        Return score
    End Function

    Sub Loadxls()
        Try
            Dim strpath As String = ""
            Me.OpenFileDialog1.Title = "打开"
            Me.OpenFileDialog1.DefaultExt = "xls"
            Me.OpenFileDialog1.Filter = "Excel files (*.xls,*.xlsx)|*.xls;*.xlsx"
            If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strpath = Me.OpenFileDialog1.FileName
            Else
                Exit Sub
            End If
            If myexcel Is Nothing Then
                myexcel = New Excel.Application
            End If
            myexcel.Workbooks.Open(strpath)
            myexcel.Worksheets(1).activate()
        Catch ex As Exception
            myexcel.Quit()
            MsgBox("导入错误！" & vbCrLf & vbCrLf & "请参照A列为学号，B列为成绩的EXCEL表格，数据从第一行开始，不要加表头修改excel表格！")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        If ComboBox1.Text = "实验成绩" Then
            kemu = "_sy_qm"
        ElseIf ComboBox1.Text = "实践成绩" Then
            kemu = "_sj_qm"
        End If
    End Sub

#Region "刷新，前进，后退按钮"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        WebBrowser1.Refresh()
    End Sub
#End Region

End Class
