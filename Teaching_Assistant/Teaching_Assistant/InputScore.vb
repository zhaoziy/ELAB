Imports System.Drawing
Imports System.Windows.Forms

Public Class inputscore
    Public line As Byte
    Public Getweek, semester As String
    Public std As Date, soft() As String, hard() As String
    Public selectcmd As String

#Region "��ʼ��"

    Private Sub ini()
        Dim i As Byte = 0
        selectcmd = "select * from [��ѧ����] "
        If sql(selectcmd, True) And myreader.Read Then
            semester = Trim(myreader.Item("ѧ��").ToString)
            std = Trim(myreader.Item("��ѧ����").ToString)
            soft = Trim(myreader.Item("����ܴ�").ToString).Split("~")
            hard = Trim(myreader.Item("Ӳ���ܴ�").ToString).Split("~")
        End If
        conn.Close()
    End Sub

    Private Function getw()
        ini()
        Dim days As Integer = DateDiff("d", std, Me.DateTimePicker1.Value.Date)
        Getweek = days \ 7 + 1
        Dim getday = days Mod 7 + 1
        Dim gbday() As Char = "��һ����������"
        Me.Label1.Text = "��" & Getweek & "�� ��" & gbday(getday Mod 7)
        Return Trim(Str(Getweek * 100 + getday))
    End Function

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Try
            getw()
        Catch ex As Exception
            Exit Sub
        End Try
        liebiao()
        seline()
        TxtScore.Focus()
    End Sub

    Private Sub InputScorePanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles InputScorePanel.HandleCreated

        getw()
        init()
        get_info()
        If Val(Getweek) <= Val(hard(1).Trim) Or Val(Getweek) = 18 Then
            CBmoshi.Text = "�ɼ�/�ɼ�"
            Me.CbCourse.Text = "Ӳ����"
            liebiao()
            seline()
            TxtScore.Focus()
        ElseIf Val(Getweek) >= Val(soft(0).Trim) And Val(Getweek) <= Val(soft(1).Trim) Or Val(Getweek) = 19 Then
            CBmoshi.Text = "�ɼ�/�ɼ�"
            Me.CbCourse.Text = "�����"
            liebiao()
            seline()
            TxtScore.Focus()
        Else
            CBmoshi.Text = "ѧ��/�ɼ�"
            liebiao()
            seline()
            TxtNum.Focus()
        End If
       
    End Sub

#End Region

#Region "�����¼�"

    Private Sub InputScore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown, TxtNum.KeyDown, TxtScore.KeyDown
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

    Private Sub TxtScore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtScore.KeyDown
        If e.KeyCode = Keys.Enter Then
            Submit_Score()
        End If
    End Sub  '�ɼ��ı���س�����

    Private Sub TxtNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call schid(sender, e)
            If Me.CBmoshi.Text = "ѧ��/ѧ��" Then
                Me.TxtNum.Focus()
                Me.TxtNum.Text = ""
            Else
                Me.TxtScore.Focus()
                Me.TxtName.Text = ""
            End If
        End If
    End Sub  '��ѧ������

    Private Sub TxtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call schid(sender, e)
            Me.TxtScore.Focus()
            Me.TxtNum.Text = ""
        End If
    End Sub '����������

#End Region

#Region "�ɼ�¼��"

    Private Function cj()
        If Me.RadioButton1.Checked = True Then
            cj = Me.RadioButton1.Text & "1"
        ElseIf Me.RadioButton2.Checked = True Then
            cj = Me.RadioButton2.Text & "2"
        ElseIf Me.RadioButton3.Checked = True Then
            cj = Me.RadioButton3.Text & "3"
        Else : Return ""
        End If
    End Function  '�ж�����Ŀ�Ŀ

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        Me.TxtScore.Focus()
    End Sub

    Private Sub CbCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCourse.SelectedIndexChanged
        Call schid(sender, e)
    End Sub 'ѡ��γ������б�

    Private Sub Submit_Score()
        Try
            If TxtScore.Text = "" OrElse Num_Tb.Text = "" Then
                MsgBox("δ����ɼ�����δѡ��ѧ����")
                Exit Sub
            End If

            If cj() = "" Then MsgBox("��ѡ��ɼ�ѡ�") : Exit Sub
            If TxtScore.Text = "" Then TxtScore.Text = "NULL"
            '**********************�޸ĺ�ĳɼ�¼��************************
            If (Val(TxtScore.Text) < 60 And TxtScore.Text <> "NULL") Then
                If MsgBox("ȷ�ϳɼ�Ϊ" & TxtScore.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    TxtScore.Clear()
                    Exit Sub
                End If
            End If
            '*************************************************************************************

            If Val(Me.ListView1.Items(line).SubItems(CInt(Mid(cj, 5, 1)) + 2).Text) <> 0 Then 'CInt(Mid(cj,5,1))+2��ʾ�ڼ�������
                If MsgBox("ȷ�ϸ��£�", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    If line < Me.ListView1.Items.Count - 1 Then
                        Me.ListView1.Items(line).Selected = False
                        Me.ListView1.Items(line).BackColor = Color.White
                        Me.ListView1.Items(line).ForeColor = Color.Black
                        line += 1
                    End If
                    liebiao()
                    seline()
                    TxtScore.Clear()
                    Me.TxtScore.Focus()
                    Exit Sub
                End If
            End If

            Dim updatecmd As String
            updatecmd = "update [" & semester & "_�������װ����Լ���] set  " & Mid(cj, 1, 4) & "=" & TxtScore.Text & " where ѧ��=" & Me.ListView1.Items(line).Text
            If Me.RadioButton1.Checked Then
                logwrite("hard", Me.ListView1.Items(line).Text, TxtScore.Text)
            ElseIf Me.RadioButton2.Checked Then
                logwrite("soft", Me.ListView1.Items(line).Text, TxtScore.Text)
            ElseIf Me.RadioButton3.Checked Then
                logwrite("paper", Me.ListView1.Items(line).Text, TxtScore.Text)
            End If
            sql(updatecmd, False)
            conn.Close()

            If line < Me.ListView1.Items.Count - 1 Then
                Me.ListView1.Items(line).Selected = False
                Me.ListView1.Items(line).BackColor = Color.White
                Me.ListView1.Items(line).ForeColor = Color.Black
                line += 1
            End If
            liebiao()
            seline()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        TxtScore.Clear()
        If Me.CBmoshi.Text = "�ɼ�/�ɼ�" Then
            Me.TxtScore.Focus()
        Else
            Me.TxtNum.Focus()
        End If
    End Sub

    Private Sub BtSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSubmit.Click
        Submit_Score()
    End Sub

#End Region

#Region "ѧ����ѯ"

    Public Sub schid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.TxtNum.Text = "" And TxtName.Text = "" Then
            Exit Sub
        Else
            Try
                Dim i As Byte = 0
                If sender.name.ToString = "TxtNum" Or sender.name.ToString = "TxtName" Then
                    If TxtNum.Text <> "" And TxtNum.Focused = True And TxtName.Focused = False Then
                        selectcmd = "select * from [" & Me.semester & "_�������װ����Լ���] where ѧ��=" & Val(TxtNum.Text)
                    ElseIf TxtName.Text <> "" And TxtName.Focused = True And TxtNum.Focused = False Then
                        selectcmd = "select * from [" & Me.semester & "_�������װ����Լ���] where ���� like '%" & TxtName.Text & "%'"
                    End If
                ElseIf sender.name.ToString = "CbCourse" Then
                    If Me.ListView1.SelectedItems.Count <> 0 Then
                        selectcmd = "select * from [" & Me.semester & "_�������װ����Լ���] where ѧ��=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
                    Else
                        selectcmd = "select * from [" & Me.semester & "_�������װ����Լ���] where ѧ��=" & Val(Me.ListView1.Items(0).Text)
                    End If
                End If

                If sql(selectcmd, False) And myreader.Read Then
                    Dim selday As String
                    If Me.CbCourse.Text = "�����" Then
                        selday = myreader("���ʱ��").ToString
                        selectcmd = "select * from [" & Me.semester & "_�������װ����Լ���] where ���ʱ��=" & selday
                    Else
                        selday = myreader("Ӳ��ʱ��").ToString
                        selectcmd = "select * from [" & Me.semester & "_�������װ����Լ���] where Ӳ��ʱ��=" & selday
                    End If

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
                    Dim nd As Date = DateAdd("d", CInt(Mid(selday, 1, selday.Length - 2)) * 7 - 8 + CInt(Mid(selday, selday.Length - 1)), std)
                    If Me.DateTimePicker1.Text = nd Then
                        Call DateTimePicker1_ValueChanged(sender, e)
                    Else
                        Me.DateTimePicker1.Value = nd
                    End If
                    TxtScore.Focus()
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
    End Sub  '��������

    Private Sub seline()  '��ʾ������Ϣ
        Try
            If ListView1.Items.Count <> 0 Then
                If ListView1.Items.Count < line Then
                    Me.ListView1.Items(0).Selected = True
                    Me.ListView1.Items(0).BackColor = SystemColors.Highlight
                    Me.ListView1.Items(0).ForeColor = Color.White
                    Me.ListView1.Items(0).EnsureVisible()
                Else
                    Me.ListView1.Items(line).Selected = True
                    Me.ListView1.Items(line).BackColor = SystemColors.Highlight
                    Me.ListView1.Items(line).ForeColor = Color.White
                    Me.ListView1.Items(line).EnsureVisible()
                End If
            End If

            '**************��ʾ������Ϣ***************
            Dim tableinfo As New DataTable
            If Me.ListView1.SelectedItems.Count = 0 Then
                selectcmd = "select * from [" & Me.semester & "_�������װ����Լ���] where ѧ��=" & Val(Me.ListView1.Items(0).Text)
            Else
                selectcmd = "select * from [" & Me.semester & "_�������װ����Լ���] where ѧ��=" & Val(Me.ListView1.SelectedItems.Item(0).Text)
            End If
            tableinfo = gettable("��ʾ������Ϣ", selectcmd, False)
            Me.TxtNum.Text = tableinfo.Rows(0).Item("ѧ��").ToString.Trim
            Me.TxtName.Text = tableinfo.Rows(0).Item("����").ToString.Trim

            Me.Num_Tb.Text = tableinfo.Rows(0).Item("ѧ��").ToString.Trim
            Me.Name_Tb.Text = tableinfo.Rows(0).Item("����").ToString.Trim
            Me.Maillb.Text = tableinfo.Rows(0).Item("����").ToString.Trim
            Me.phonelb.Text = tableinfo.Rows(0).Item("��ϵ�绰").ToString.Trim
            Me.liluntime.Text = decode_lilun(tableinfo.Rows(0).Item("���ۿ�").ToString.Trim)
            Me.selecttime.Text = tableinfo.Rows(0).Item("ѡ��ʱ��").ToString.Trim
            tableinfo.Dispose()
            '**************��ʾ������Ϣ***************

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        TxtScore.Focus()
    End Sub

    Private Function decode_lilun(ByVal str As String)
        Dim day, week As Integer
        day = Val(str) Mod 10
        week = (Val(str) - day) / 100
        Return "��" & week & "�� " & GetDay(day)
    End Function

    Private Sub TxtNum_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNum.GotFocus
        TxtName.Clear()
        TxtNum.Clear()
    End Sub

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        TxtNum.Clear()
        TxtName.Clear()
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Try
            line = Me.ListView1.Items.IndexOf(Me.ListView1.SelectedItems.Item(0))
            liebiao()
            seline()
            TxtScore.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ListView1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.MouseEnter
        ListView1.Focus()
    End Sub

    Private Sub liebiao() '�б���

        Me.ListView1.Items.Clear()
        Try
            Dim i As Byte = 0
            If Val(Getweek) <= Val(hard(1).Trim) Then
                selectcmd = "select * from [" & semester & "_�������װ����Լ���] where Ӳ��ʱ��='" & getw() & "'"
                Me.Label1.Text += "     Ӳ����"
                Me.CbCourse.Text = "Ӳ����"
                Me.RadioButton1.Enabled = True
                Me.RadioButton1.Checked = True
                Me.RadioButton2.Enabled = False
                Me.RadioButton3.Enabled = False
            ElseIf Val(Getweek) <= Val(soft(1).Trim) And Val(Getweek) >= Val(soft(0).Trim) Then
                selectcmd = "select * from [" & semester & "_�������װ����Լ���] where ���ʱ��='" & getw() & "'"
                Me.Label1.Text += "     �����"
                Me.CbCourse.Text = "�����"
                Me.RadioButton2.Enabled = True
                Me.RadioButton3.Enabled = True
                Me.RadioButton2.Checked = True
                Me.RadioButton1.Checked = False
                Me.RadioButton1.Enabled = False
            ElseIf Val(Getweek) = 18 Then
                selectcmd = "select * from [" & semester & "_�������װ����Լ���] where Ӳ��ʱ��='" & getw() & "'"
                Me.Label1.Text += "     Ӳ����"
                Me.CbCourse.Text = "Ӳ����"
                Me.RadioButton1.Enabled = True
                Me.RadioButton1.Checked = True
                Me.RadioButton2.Enabled = False
                Me.RadioButton3.Enabled = False
            ElseIf Val(Getweek) = 19 Then
                selectcmd = "select * from [" & semester & "_�������װ����Լ���] where ���ʱ��='" & getw() & "'"
                Me.Label1.Text += "     �����"
                Me.CbCourse.Text = "�����"
                Me.RadioButton2.Enabled = True
                Me.RadioButton3.Enabled = True
                Me.RadioButton2.Checked = True
                Me.RadioButton1.Checked = False
                Me.RadioButton1.Enabled = False
            Else
                Exit Sub
            End If

            If sql(selectcmd, False) Then
                Do While myreader.Read '**********************��ѯ�Ͽγ�Ա************************
                    Me.ListView1.Items.Add((myreader("ѧ��").ToString))
                    Me.ListView1.Items(i).SubItems.Add((myreader("����").ToString))
                    Me.ListView1.Items(i).SubItems.Add(Trim(myreader("Ժϵ").ToString))
                    Me.ListView1.Items(i).SubItems.Add(myreader(Me.RadioButton1.Text).ToString)
                    Me.ListView1.Items(i).SubItems.Add(myreader(Me.RadioButton2.Text).ToString)
                    Me.ListView1.Items(i).SubItems.Add(myreader(Me.RadioButton3.Text).ToString)
                    i += 1
                Loop
            End If
            conn.Close()
            Me.Label1.Text &= "      �� " & i & " ��"
            Me.TxtScore.Focus()
        Catch ex As Exception
            Me.ListView1.Items.Clear()
            'MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

End Class