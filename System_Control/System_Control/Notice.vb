Imports System.Windows.Forms

Public Class Notice

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str1 As String
        str1 = "update [Notice] set �Ƿ����='True'"
        sql(str1, True)
        conn.Close()
        str1 = "insert into Notice (������,�Ƿ����,֪ͨ,����) values ('���й���ϵͳ','False','" & TextBox1.Text & "','" & GetServerTime() & "')"
        sql(str1, True)
        conn.Close()
        MsgBox("����ɹ���")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("ȷ��ȡ��ǰ̨��Ϣ֪ͨ��", "����", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim str1 As String
            str1 = "update [Notice] set �Ƿ����='True'"
            sql(str1, True)
            conn.Close()
        End If
        Me.Close()
    End Sub

    Private Sub Notice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str1 As String
        str1 = "select ֪ͨ from [Notice] where �Ƿ����='False'"
        sql(str1, True)
        If myreader.Read Then
            If IsDBNull(myreader.Item("֪ͨ")) Then
                TextBox1.Text = ""
            Else
                TextBox1.Text = myreader.Item("֪ͨ")
            End If
        End If
        conn.Close()
    End Sub

End Class