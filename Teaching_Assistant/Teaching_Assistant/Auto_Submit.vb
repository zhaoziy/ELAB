Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Auto_Submit
    Public myexcel As Excel.Application
    Public flag As Boolean = False
    Public kemu As String = "ʵ���ɼ�"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("���ԭ�ȳɼ���¼������Ϊ���Ĺ����������ֱ�Ӹ��ǵ������Խ���������", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        Else
            MsgBox("�뵼��A��Ϊѧ�ţ�B��Ϊ�ɼ���EXCEL������ݴӵ�һ�п�ʼ����Ҫ�ӱ�ͷ��")
            MsgBox("�˹��̴����Ҫ5-10s���ҵ�ʱ�䣬�ڼ���ܳ�����ʱ�������������������")
            Loadxls()
            Me.WebBrowser1.Navigate("http://zhjw.dlut.edu.cn/cjlrmxAction.do?oper=cjlrAllType")
            'Me.WebBrowser1.Navigate("C:\Users\codeme\Desktop\chengji.html")
            flag = True
        End If
    End Sub

    Private Sub Auto_Submit_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Auto_Submit_Panel.HandleCreated
        Me.WebBrowser1.Navigate("http://zhjw.dlut.edu.cn/")
        flag = False
        ComboBox1.Text = "ʵ���ɼ�"
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If flag = False Then Exit Sub
        Dim s As HtmlElementCollection = Me.WebBrowser1.Document.GetElementsByTagName("input")
        Dim t As HtmlElementCollection = Me.WebBrowser1.Document.GetElementsByTagName("select")
        Dim i As Byte, j As Byte, cj As String
        For i = 0 To s.Count - 1
            If Mid(s.Item(i).Name, 10) = kemu Then           'ʵ���ɼ�
                'If Mid(s.Item(i).Name, 10) = "_sj_qm" Then      'ʵ��ɼ�
                cj = search(Mid(s.Item(i).Name, 1, 9))
                s.Item(i).InnerText = cj
                If cj Is Nothing Then GoTo l1
                If cj IsNot Nothing And (cj.Trim = "0" Or cj.Trim = "") Then
l1:                 For j = 0 To t.Count - 1
                        If Mid(t.Item(j).Name, 1, 9) = Mid(s.Item(i).Name, 1, 9) Then
                            t.Item(j).All(0).InnerText = "ȱ��"
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
            Me.OpenFileDialog1.Title = "��"
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
            MsgBox("�������" & vbCrLf & vbCrLf & "�����A��Ϊѧ�ţ�B��Ϊ�ɼ���EXCEL������ݴӵ�һ�п�ʼ����Ҫ�ӱ�ͷ�޸�excel���")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        If ComboBox1.Text = "ʵ��ɼ�" Then
            kemu = "_sy_qm"
        ElseIf ComboBox1.Text = "ʵ���ɼ�" Then
            kemu = "_sj_qm"
        End If
    End Sub

#Region "ˢ�£�ǰ�������˰�ť"
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
