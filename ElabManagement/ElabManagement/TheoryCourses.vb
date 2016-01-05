Public Class TheoryCourses

    Dim line As Integer

    Private Sub liebiao()
        Me.ListView1.Items.Clear()
        Try
            Dim i As Integer
            Dim outputdatestr As String
            Dim outputdatenow As Date = Now.Date
            Try
                outputdatestr = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            Catch
                outputdatestr = Format(outputdatenow, "yyyy-MM-dd")
            End Try

            Dim tablename1 As String = "[" & schoolcalendar & "�������װ����Լ���]"
            selectcmd = "select ѧ��,����,Ժϵ,ѡ��ʱ��,Ӳ��ʱ��,���ʱ��,��ע from " & tablename1 & " where CONVERT(varchar(10),ѡ��ʱ��, 23)='" & outputdatestr & "'"
            If sql(selectcmd, False) Then
                Do While myreader.Read '**********************��ѯ�Ͽγ�Ա************************
                    Me.ListView1.Items.Add((myreader("ѧ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("����").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("Ժϵ").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("ѡ��ʱ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("Ӳ��ʱ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("���ʱ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("��ע").ToString))
                    i += 1
                Loop
            End If
            conn.Close()
            Label1.Text = "�� " & i & " ��"
        Catch ex As Exception
            Me.ListView1.Items.Clear()
            MsgBox(ex.ToString)
        End Try
    End Sub '�б�

    Private Sub seline()
        Try
            If ListView1.Items.Count <> 0 Then
                Me.ListView1.Items(line).Selected = True
            End If

            Me.ListView1.Items(line).BackColor = SystemColors.Highlight
            Me.ListView1.Items(line).ForeColor = Color.White
            Me.ListView1.Items(line).EnsureVisible()

            '**************��ʾ������Ϣ***************
            selectcmd = "select * from [" & schoolcalendar & "�������װ����Լ���] where ѧ��=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
            Dim tableinfo As New DataTable
            tableinfo = gettable(Val(Me.ListView1.SelectedItems.Item(0).Text), selectcmd, False)
            Me.TxtNum.Text = tableinfo.Rows(0).Item("ѧ��").ToString.Trim
            Me.TxtName.Text = tableinfo.Rows(0).Item("����").ToString.Trim
            Me.Maillb.Text = tableinfo.Rows(0).Item("����").ToString.Trim
            Me.phonelb.Text = tableinfo.Rows(0).Item("��ϵ�绰").ToString.Trim
            Me.liluntime.Text = tableinfo.Rows(0).Item("���ۿ�").ToString.Trim
            Me.selecttime.Text = tableinfo.Rows(0).Item("ѡ��ʱ��").ToString.Trim
            If tableinfo.Rows(0).Item("��ע").ToString.Trim = "����" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            Else
                RadioButton1.Checked = False
                RadioButton2.Checked = True
            End If
            '**************��ʾ������Ϣ***************
        Catch ex As Exception
        End Try
    End Sub '��ʾ������Ϣ

    Private Sub TheoryCourses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'connection()
        'init()        '*************����ʱʹ��*************
        Dim strsql As String
        CBTime.Items.Clear()
        strsql = "select distinct CONVERT(varchar(100), ѡ��ʱ��, 23) from [" & schoolcalendar & "�������װ����Լ���]"
        sql(strsql, False)
        While myreader.Read
            If IsDBNull(myreader.Item(0)) = True Then
                CBTime.Items.Add("δѡ��")
            Else
                CBTime.Items.Add(myreader.Item(0))
            End If
        End While
        change()
        liebiao()
        seline()
        Me.TxtNum.Focus()
    End Sub

    Private Sub InputScore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Up Then
                If line > 0 And line < Me.ListView1.Items.Count Then
                    Me.ListView1.Items(line).Selected = False
                    Me.ListView1.Items(line).BackColor = Color.White
                    Me.ListView1.Items(line).ForeColor = Color.Black
                    line -= 1
                    seline()
                ElseIf line >= Me.ListView1.Items.Count Then
                    If Me.ListView1.Items.Count - 1 < 0 Then
                        Exit Sub
                    End If
                    line = Me.ListView1.Items.Count - 1
                    seline()
                End If
            ElseIf e.KeyCode = Keys.Down Then
                If line < Me.ListView1.Items.Count - 1 Then
                    Me.ListView1.Items(line).Selected = False
                    Me.ListView1.Items(line).BackColor = Color.White
                    Me.ListView1.Items(line).ForeColor = Color.Black
                    line += 1
                End If
                seline()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub  'listview�����¼�����

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        TxtName.Clear()
        TxtNum.Clear()
    End Sub

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call schid(sender, e)
        End If
    End Sub '��������ѯ

    Private Sub TxtNum_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNum.GotFocus
        TxtName.Clear()
        TxtNum.Clear()
    End Sub

    Private Sub TxtNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call schid(sender, e)
        End If
    End Sub '��ѧ�Ų�ѯ

    Public Sub schid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtNum.Text = "" And TxtName.Text = "" Then
            Exit Sub
        Else
            Try
                Dim i As Byte = 0

                If sender.name.ToString = "TxtNum" Or sender.name.ToString = "TxtName" Then
                    If TxtNum.Text <> "" And TxtNum.Focused = True And TxtName.Focused = False Then
                        selectcmd = "select * from [" & schoolcalendar & "�������װ����Լ���] where ѧ��=" & Val(TxtNum.Text)
                    ElseIf TxtName.Text <> "" And TxtName.Focused = True And TxtNum.Focused = False Then
                        selectcmd = "select * from [" & schoolcalendar & "�������װ����Լ���] where ���� like '%" & TxtName.Text & "%'"
                    End If
                ElseIf sender.name.ToString = "CbCourse" Then
                    selectcmd = "select * from [" & schoolcalendar & "�������װ����Լ���] where ѧ��=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
                End If

                If sql(selectcmd, False) And myreader.Read Then
                    Dim selday As String
                    selday = Format(Convert.ToDateTime(myreader("ѡ��ʱ��").ToString), "yyyy-MM-dd")
                    selectcmd = "select * from [" & schoolcalendar & "�������װ����Լ���] where CONVERT(varchar(10),ѡ��ʱ��, 23) = '" & selday & "'"
                    conn.Close()

                    If selday = "" Then
                        MsgBox("��ѧ��δ�����ۿΣ����û��ѡ����Σ�")
                        Exit Sub
                    End If

                    If sql(selectcmd, False) Then
                        Do While myreader.Read
                            If myreader("ѧ��").ToString = TxtNum.Text Or myreader("����").ToString = TxtName.Text Then
                                line = i
                                Exit Do
                            End If
                            i += 1
                        Loop
                    End If
                    conn.Close()

                    If Me.DateTimePicker1.Text = selday Then
                        Call DateTimePicker1_ValueChanged(sender, e)
                    Else
                        Me.DateTimePicker1.Value = selday
                    End If
                Else
                    conn.Close()
                    MsgBox("δ��������ѧ��������������")
                    Me.ListView1.Items.Clear()
                    TxtNum.Text = ""
                    TxtName.Text = ""
                End If
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
        End If
    End Sub '����

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        updatecmd = "update [" & schoolcalendar & "�������װ����Լ���] set ��ע = '����' where ѧ��=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
        sql(updatecmd, False)
        conn.Close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        updatecmd = "update [" & schoolcalendar & "�������װ����Լ���] set ��ע = 'δǩ��' where ѧ��=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
        sql(updatecmd, False)
        conn.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        liebiao()
        seline()
    End Sub

    Private Sub change()
        Dim str1 As String
        Dim table1 As DataTable
        Dim i, j As Integer
        str1 = "select * from [" & schoolcalendar & "�������װ����Լ���] where ��ע is null or ��ע=''"
        table1 = gettable("�������װ����Լ���", str1, False)
        i = table1.Rows.Count
        For j = 0 To i - 1
            str1 = "update [" & schoolcalendar & "�������װ����Լ���] set ��ע = '����' where ѧ��='" & table1.Rows(j).Item("ѧ��") & "'"
            sql(str1, False)
            conn.Close()
        Next
    End Sub '�����б�עΪ�յ���Ϣ��ֵΪ������ѡ�ι������а�ʱ�丳ֵ���ܣ�ʵ�����ڼ��Ͽ��Զ���ֵΪδǩ�������಻Ӱ�졣

    Private Sub CBTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBTime.SelectedIndexChanged
        If CBTime.SelectedItem = "δѡ��" Then
            Me.ListView1.Items.Clear()
            Dim strsql As String
            Dim i As Integer
            strsql = "select ѧ��,����,Ժϵ,ѡ��ʱ��,Ӳ��ʱ��,���ʱ��,��ע from [" & schoolcalendar & "�������װ����Լ���] where ѡ��ʱ�� is NULL"
            If sql(strsql, False) Then
                Do While myreader.Read '**********************��ѯ�Ͽγ�Ա************************
                    Me.ListView1.Items.Add((myreader("ѧ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("����").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("Ժϵ").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("ѡ��ʱ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("Ӳ��ʱ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("���ʱ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("��ע").ToString))
                    i += 1
                Loop
            End If
            conn.Close()
            Label1.Text = "�� " & i & " ��"
        Else
            DateTimePicker1.Value = CDate(CBTime.SelectedItem)
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Try
            line = Me.ListView1.Items.IndexOf(Me.ListView1.SelectedItems.Item(0))
            liebiao()
            seline()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quit.Click
        Me.Close()
    End Sub

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

End Class