Public Class password

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        prepwd = "invaildpassword"
        Me.Dispose()
    End Sub '点击取消时给公共变量prepwd赋值invaildpassword，用于后续判断

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        prepwd = TextBox1.Text
        Me.Dispose()
    End Sub '确定按钮，直接将文本框内容赋值给公共变量prepwd

    Private Sub password_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TextBox1.Focus()
    End Sub
End Class