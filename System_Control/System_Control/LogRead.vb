Public Class LogRead

    Public line As Integer = 0

    Public Sub log()
        Dim i As Integer
        ColumnHeader1.Width = 38
        ColumnHeader2.Width = 72
        ColumnHeader3.Width = 120
        ColumnHeader4.Width = 90
        ColumnHeader5.Width = 84
        ColumnHeader6.Width = 60
        ColumnHeader7.Width = 60
        ColumnHeader8.Width = 60
        ColumnHeader9.Width = 97
        ColumnHeader10.Width = 24

        If Sql(strSql, True) Then
            Do While myreader.Read '**********************��ѯ��Ա************************
                Me.ListView1.Items.Add((myreader("ID").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("������ѧ��").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("����ʱ��").ToString))
                Me.ListView1.Items(i).SubItems.Add(Trim(myreader("������IP").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("���޸���ѧ��").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("Ӳ���ɼ�").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("����ɼ�").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("�Ծ�ɼ�").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("��¼��Ϣ").ToString))
                Me.ListView1.Items(i).SubItems.Add((myreader("�汾��").ToString))
                i += 1
            Loop
        End If
        If Me.ListView1.Items.Count <> 0 Then
            ListView1.Items(line).Selected = True
        End If
        conn.Close()
        Label1.Text = "��" & i & "����¼"
    End Sub '��ȡlog��¼

    Public Sub ComboBoxInfo()
        Try
            Me.ComboBox1.Items.Clear()
            strSql = "select distinct ��¼��Ϣ from [Log] where ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
            sql(strSql, True)
            ComboBox1.Items.Add("������Ϣ")
            While myreader.Read
                ComboBox1.Items.Add(myreader("��¼��Ϣ"))
            End While
            conn.Close()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub '��½��Ϣ

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.ListView1.Items.Clear()
        If ComboBox1.Text = "������Ϣ" Then
            strSql = "select * from [Log] where ��¼��Ϣ like '%%' and ѧ��='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        Else
            strSql = "select * from [Log] where ��¼��Ϣ like '%" & Me.ComboBox1.Text & "%' and ѧ��='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        End If
        log()
    End Sub '�����б��޸�

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim month As String
        Dim day As String
        ListView1.Items.Clear()
        If Me.DateTimePicker1.Value.Month < 10 Then
            month = "0" & Me.DateTimePicker1.Value.Month
        Else : month = Me.DateTimePicker1.Value.Month
        End If
        If Me.DateTimePicker1.Value.Day < 10 Then
            day = "0" & Me.DateTimePicker1.Value.Day
        Else : day = Me.DateTimePicker1.Value.Day
        End If
        strSql = "select * from [log] where Convert(varchar(100),����ʱ��,111) = '" & Me.DateTimePicker1.Value.Year & "/" & month & "/" & day & "' and ѧ��='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        log()
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox2.Clear()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub '����textbox1ֻ����������

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.TextLength <> 9 Then
            Exit Sub
        Else
            ListView1.Items.Clear()
            strSql = "select * from [log] where ������ѧ�� = '" & TextBox1.Text & "' and ѧ��='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
            log()
        End If
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox1.Clear()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub '����textbox2ֻ����������

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength <> 9 Then
            Exit Sub
        Else
            ListView1.Items.Clear()
            strSql = "select * from [log] where ���޸���ѧ�� = '" & TextBox2.Text & "' and ѧ��='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
            log()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If My.Computer.Network.Ping("192.168.1.252", 2000) = True Then
            strSql = "EXEC sp_configure 'show advanced options',1; RECONFIGURE; EXEC sp_configure 'xp_cmdshell',1;RECONFIGURE;"
            sql(strSql, True)
            strSql = "exec master..xp_cmdshell'bcp student.dbo.Log out d:\log.txt -c -S 192.168.1.252 -U sa -P elab2012'"
            sql(strSql, True)
            strSql = "EXEC sp_configure 'show advanced options',1; RECONFIGURE; EXEC sp_configure 'xp_cmdshell',0;RECONFIGURE;"
            sql(strSql, True)
            conn.Close()
            MsgBox("�����ɹ����뵽252��������D:\log.txtȡ���ļ�")
        Else
            MsgBox("192.168.1.252���粻ͨ������ϵ���ͬѧ")
        End If
    End Sub '������txt�������ڷ�������

    Private Sub Refreshbt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Refreshbt.Click
        strSql = "select * from Log where ѧ��='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        log()
        ComboBoxInfo()
        ComboBox1.Text = "������Ϣ"
    End Sub 'ˢ�°�ť

    Private Sub LogReadPanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles LogReadPanel.HandleCreated

        'init()     '**************����ʱʹ��************
        strSql = "select * from Log where ѧ��='" & schoolcalendar.Substring(0, 5) & "' order by id desc"
        log()
        ComboBoxInfo()
        ComboBox1.Text = "������Ϣ"
    End Sub

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

End Class