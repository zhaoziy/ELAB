Public Class password

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        prepwd = "invaildpassword"
        Me.Dispose()
    End Sub '���ȡ��ʱ����������prepwd��ֵinvaildpassword�����ں����ж�

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        prepwd = TextBox1.Text
        Me.Dispose()
    End Sub 'ȷ����ť��ֱ�ӽ��ı������ݸ�ֵ����������prepwd

    Private Sub password_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TextBox1.Focus()
    End Sub
End Class