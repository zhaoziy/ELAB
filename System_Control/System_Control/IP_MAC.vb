Imports System.Windows.Forms
Imports System.Drawing

Public Class IP_MAC

    Dim IP(65) As String
    Dim str_IP(10, 5) As String
    Dim num(65) As String
    Dim str_num(10, 5) As String
    Dim names(65) As String
    Dim str_names(10, 5) As String
    Dim MAC(65) As String
    Dim str_MAC(10, 5) As String
    Dim line As Integer

    Private Sub IP_MAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, ListView1.KeyDown
        line = Me.ListView1.Items.IndexOf(Me.ListView1.SelectedItems.Item(0))
        If e.KeyCode = Keys.Up Then
            If line = 0 Then
                display_info()
            Else
                line = line - 1
                display_info()
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If line = 65 Then
                display_info()
            Else
                line = line + 1
                display_info()
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        liebiao()

    End Sub

    Sub liebiao()

        ListView1.Items.Clear()
        Dim str As String = "select * from [IP_MAC] where USERNAME='学生_外屋' or USERNAME='学生_里屋'"
        Dim table As DataTable
        table = gettable("IP_MAC", str, True)

        Dim COUNT, Col, Row As Integer
        For COUNT = 0 To table.Rows.Count - 1
            If table.Rows(COUNT).Item("USERNAME") = "学生_外屋" Then
                Col = Val(table.Rows(COUNT).Item("IP")) Mod 10
                Row = (Val(table.Rows(COUNT).Item("IP")) - Col) / 10
                str_IP(Row - 1, Col - 1) = table.Rows(COUNT).Item("IP")
                str_num(Row - 1, Col - 1) = table.Rows(COUNT).Item("NUM")
                str_MAC(Row - 1, Col - 1) = table.Rows(COUNT).Item("MAC")
            ElseIf table.Rows(COUNT).Item("USERNAME") = "学生_里屋" Then
                Col = Val(table.Rows(COUNT).Item("IP")) Mod 10
                Row = (Val(table.Rows(COUNT).Item("IP")) - Col) / 10
                str_IP(Row - 5, Col - 1) = table.Rows(COUNT).Item("IP")
                str_num(Row - 5, Col - 1) = table.Rows(COUNT).Item("NUM")
                str_MAC(Row - 5, Col - 1) = table.Rows(COUNT).Item("MAC")
            End If
        Next
        table.Dispose()

        For COUNT = 0 To 65
            IP(COUNT) = String.Empty
            num(COUNT) = String.Empty
            names(COUNT) = String.Empty
            MAC(COUNT) = String.Empty
        Next

        Dim i As Integer = 0
        For Row = 0 To 10
            For Col = 0 To 5
                IP(i) = str_IP(Row, Col)
                num(i) = str_num(Row, Col)
                MAC(i) = str_MAC(Row, Col)
                str = "select 姓名 from [member] where 学号='" & num(i) & "'"
                Try
                    sql(str, True)
                    If myreader.Read Then
                        names(i) = myreader.Item("姓名")
                    End If
                    conn.Close()
                Catch ex As Exception
                    conn.Close()
                End Try

                i = i + 1
            Next
        Next

        For i = 0 To 65
            Me.ListView1.Items.Add(IP(i))
            Me.ListView1.Items(i).SubItems.Add(num(i))
            Me.ListView1.Items(i).SubItems.Add(names(i))
            Me.ListView1.Items(i).SubItems.Add(MAC(i))
        Next

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        line = Me.ListView1.Items.IndexOf(Me.ListView1.SelectedItems.Item(0))
        display_info()
    End Sub

    Private Sub display_info()
        TextBox1.Text = ListView1.Items(line).Text
        Dim i As Integer
        For i = 0 To 65
            If IP(i) = ListView1.Items(line).Text Then
                Exit For
            End If
        Next
        TB_num.Text = num(i)
        TextBox3.Text = names(i)
        TextBox4.Text = MAC(i)
    End Sub

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

    Private Sub TB_num_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_num.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TB_num.Text.Length = 9 Or TB_num.Text.Length = 0 Then
                Dim str As String
                Try
                    str = "update [IP_MAC] set NUM='" & TB_num.Text & "', MAC='" & TextBox4.Text & "' where IP='" & TextBox1.Text & "'"
                    sql(str, True)
                    conn.Close()
                Catch ex As Exception
                    conn.Close()
                End Try
                liebiao()
            Else
                MsgBox("学号输入有误")
            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_num.TextChanged
        Dim str As String
        If TB_num.Text.Length < 9 Then
            TextBox3.Text = ""
            Exit Sub
        Else
            str = "select 姓名 from [member] where 学号='" & TB_num.Text & "'"
            sql(str, True)
            If myreader.Read Then
                TextBox3.Text = myreader.Item(0)
            End If
            conn.Close()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String
            Try
                str = "update [IP_MAC] set NUM='" & TB_num.Text & "', MAC='" & TextBox4.Text & "' where IP='" & TextBox1.Text & "'"
                sql(str, True)
                conn.Close()
            Catch ex As Exception
                conn.Close()
            End Try
            liebiao()
        End If
    End Sub

End Class
