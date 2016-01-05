Imports System.Windows.Forms

Public Class Notice

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str1 As String
        str1 = "update [Notice] set 是否过期='True'"
        sql(str1, True)
        conn.Close()
        str1 = "insert into Notice (程序名,是否过期,通知,日期) values ('科中管理系统','False','" & TextBox1.Text & "','" & GetServerTime() & "')"
        sql(str1, True)
        conn.Close()
        MsgBox("保存成功！")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("确认取消前台消息通知？", "警告", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim str1 As String
            str1 = "update [Notice] set 是否过期='True'"
            sql(str1, True)
            conn.Close()
        End If
        Me.Close()
    End Sub

    Private Sub Notice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str1 As String
        str1 = "select 通知 from [Notice] where 是否过期='False'"
        sql(str1, True)
        If myreader.Read Then
            If IsDBNull(myreader.Item("通知")) Then
                TextBox1.Text = ""
            Else
                TextBox1.Text = myreader.Item("通知")
            End If
        End If
        conn.Close()
    End Sub

End Class