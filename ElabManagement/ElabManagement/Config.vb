Public Class Config

    Private Sub Config_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        selectcmd = "select * from ��ѧ����"
        sql(selectcmd, True)
        Try
            If myreader.Read Then
                Me.DateTimePicker1.Value = Trim(myreader.Item("��ѧ����").ToString)
                Dim hard() As String = myreader.Item("Ӳ���ܴ�").ToString.Trim.Split("~")
                Dim soft() As String = myreader.Item("����ܴ�").ToString.Trim.Split("~")
                Dim closexuanke As Boolean = myreader.Item("�ر�ѡ��")
                With Me
                    .NumericUpDown1.Value = hard(0)
                    .NumericUpDown2.Value = hard(1)
                    .NumericUpDown3.Value = soft(0)
                    .NumericUpDown4.Value = soft(1)
                    If closexuanke = False Then
                        RBno.Checked = True
                    Else
                        RByes.Checked = True
                    End If
                    Total.Text = myreader.Item("������")
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()

        If authority <> 8 Then                '�������鳤�Ͱ೤���㰴ť����ʾ
            ReturnZero.Visible = False
            ReturnZero.Enabled = False
        End If

    End Sub  '�����ȡ

    Private Sub Save1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save1.Click
        If MsgBox("ȷ�ϸ��£�", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim semester As String
            Dim i As Integer
            If DateDiff(DateInterval.Month, CDate(Me.DateTimePicker1.Value.Year & "-3-1"), CDate(Me.DateTimePicker1.Value)) <= 1 Then
                semester = Me.DateTimePicker1.Value.Year.ToString & "��"
            Else
                semester = Me.DateTimePicker1.Value.Year.ToString & "��"
            End If

            updatecmd = "update ��ѧ���� set  ��ѧ����='" & Me.DateTimePicker1.Value.ToShortDateString & "', ѧ��='" & semester & "', Ӳ���ܴ�='" & Me.NumericUpDown1.Value & "~" & Me.NumericUpDown2.Value & "',����ܴ�='" & Me.NumericUpDown3.Value & "~" & Me.NumericUpDown4.Value & "',������= '" & Total.Text & "'"
            sql(updatecmd, True)
            conn.Close()

            If Me.NumericUpDown3.Value - Me.NumericUpDown2.Value >= 1 Then

                For i = Me.NumericUpDown1.Value To Me.NumericUpDown2.Value
                    updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = 'Ӳ����' ,��������='1',������='" & Total.Text & "' where �ܴ�='" & i & "' and �Ͽ����� is not null"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = Me.NumericUpDown3.Value To Me.NumericUpDown4.Value
                    updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = '�����' ,��������='1',������='" & Total.Text & "' where �ܴ�='" & i & "' and �Ͽ����� is not null"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = 6 To Me.NumericUpDown1.Value - 1
                    updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = NULL ,�������� = NULL ,������ = NULL where �ܴ�='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = Me.NumericUpDown4.Value + 1 To 18
                    updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = NULL ,�������� = NULL ,������ = NULL where �ܴ�='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                If Me.NumericUpDown3.Value - Me.NumericUpDown2.Value > 1 Then
                    For i = Me.NumericUpDown2.Value + 1 To Me.NumericUpDown3.Value - 1
                        updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = NULL ,�������� = NULL ,������ = NULL where �ܴ�='" & i & "'"
                        sql(updatecmd, True)
                        conn.Close()
                    Next
                End If
            Else
                MsgBox("ʱ����������")
                Exit Sub
            End If

            Grade()
            MsgBox("��ǰ�����ѱ��棡" & vbCrLf & vbCrLf & "��������������")
        End If
    End Sub  '��ʼ�趨���水ť

    Private Sub Save1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Save1.MouseEnter
        Me.ToolTip1.SetToolTip(sender, "���汾���ڵ�ǰ���ã����޸���������")
    End Sub

    Private Sub Save2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save2.Click
        If RBno.Checked = True Then
            updatecmd = "update ��ѧ���� set �ر�ѡ��= 'False'"
        Else
            updatecmd = "update ��ѧ���� set �ر�ѡ��= 'True'"
        End If
        sql(updatecmd, True)
        conn.Close()
        MsgBox("ѡ�������趨�ɹ���")
    End Sub  'ѡ�ο��ر��水ť

    Private Sub quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quit.Click
        Me.Close()
    End Sub   '�رհ�ť

    Private Sub ReturnZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnZero.Click
        
        If MsgBox("ȷ�ϸ��£�", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            Dim str As String
            str = "update member set ����=0 ,����=0"
            sql(str, True)
            conn.Close()
            MsgBox("���������̴��������������")

            Dim semester As String
            Dim i As Integer
            If DateDiff(DateInterval.Month, CDate(Me.DateTimePicker1.Value.Year & "-3-1"), CDate(Me.DateTimePicker1.Value)) <= 1 Then
                semester = Me.DateTimePicker1.Value.Year.ToString & "��"
            Else
                semester = Me.DateTimePicker1.Value.Year.ToString & "��"
            End If

            updatecmd = "update ��ѧ���� set  ��ѧ����='" & Me.DateTimePicker1.Value.ToShortDateString & "', ѧ��='" & semester & "', Ӳ���ܴ�='" & Me.NumericUpDown1.Value & "~" & Me.NumericUpDown2.Value & "',����ܴ�='" & Me.NumericUpDown3.Value & "~" & Me.NumericUpDown4.Value & "',������= '" & Total.Text & "'"
            sql(updatecmd, True)
            conn.Close()

            If Me.NumericUpDown3.Value - Me.NumericUpDown2.Value >= 1 Then

                For i = Me.NumericUpDown1.Value To Me.NumericUpDown2.Value
                    updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = 'Ӳ����' ,��������='1',������='" & Total.Text & "' where �ܴ�='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = Me.NumericUpDown3.Value To Me.NumericUpDown4.Value
                    updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = '�����' ,��������='1',������='" & Total.Text & "' where �ܴ�='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = 6 To Me.NumericUpDown1.Value - 1
                    updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = NULL ,�������� = NULL ,������ = NULL where �ܴ�='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                For i = Me.NumericUpDown4.Value + 1 To 18
                    updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = NULL ,�������� = NULL ,������ = NULL where �ܴ�='" & i & "'"
                    sql(updatecmd, True)
                    conn.Close()
                Next

                If Me.NumericUpDown3.Value - Me.NumericUpDown2.Value > 1 Then
                    For i = Me.NumericUpDown2.Value + 1 To Me.NumericUpDown3.Value - 1
                        updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��' ,�Ͽ����� = NULL ,�������� = NULL ,������ = NULL where �ܴ�='" & i & "'"
                        sql(updatecmd, True)
                        conn.Close()
                    Next
                End If
            Else
                MsgBox("ʱ����������")
                Exit Sub
            End If

            Grade()
            MsgBox("��ʼ���趨�ɹ���" & vbCrLf & vbCrLf & "��������������")
        End If
    End Sub  '��ȫ��ʼ��

    Private Sub ReturnZero_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReturnZero.MouseEnter
        Me.ToolTip1.SetToolTip(sender, "�������ݳ�ʼ�������鿪ѧ���趨")
    End Sub

    Private Sub Grade()
        Dim str As String = String.Empty
        Dim str_grade As String = String.Empty
        Dim num_table As DataTable
        Dim grade As Integer
        Dim i As Integer

        Try
            str = "select distinct ѧ�� from [member]"
            num_table = gettable("num_table", str, True)

            For i = 0 To num_table.Rows.Count - 1
                If num_table.Rows(i).Item("ѧ��").ToString.Count = 9 Then
                    grade = CInt(Now.Year.ToString) - CInt(num_table.Rows(i).Item("ѧ��").ToString().Substring(0, 4))
                    If Now.Month >= 8 Then
                        If grade = 0 Then
                            str_grade = "��һ"
                        ElseIf grade = 1 Then
                            str_grade = "���"
                        ElseIf grade = 2 Then
                            str_grade = "����"
                        ElseIf grade = 3 Then
                            str_grade = "����"
                        ElseIf grade > 3 Then
                            str_grade = "����"
                        End If
                    Else
                        If grade = 1 Then
                            str_grade = "��һ"
                        ElseIf grade = 2 Then
                            str_grade = "���"
                        ElseIf grade = 3 Then
                            str_grade = "����"
                        ElseIf grade = 4 Then
                            str_grade = "����"
                        ElseIf grade > 4 Then
                            str_grade = "����"
                        End If
                    End If
                    str = "update [member] set �꼶='" & str_grade & "' where ѧ��='" & num_table.Rows(i).Item("ѧ��").ToString() & "'"
                    sql(str, True)
                    conn.Close()
                End If
            Next
            num_table.Dispose()
            MsgBox("ѧ���꼶�Ѿ��趨�ɹ�")
        Catch ex As Exception
            MsgBox("ѧ���꼶�Ѿ��趨���������³�ʼ��")
        End Try
     
    End Sub

End Class