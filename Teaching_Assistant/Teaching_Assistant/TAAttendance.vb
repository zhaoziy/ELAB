Imports System.Windows.Forms

Public Class TAAttendance

    Public zhujiang As String = ""
    Public info As String = ""
    Public myarray, dqmyarray As Array
    Public currentdate As Date
    Dim nzhujiang As Integer
    Dim nzhujiao As Boolean = True '�ж��Ƿ���ͬ����ͬΪtrue����ͬΪfalse

#Region "��ʼ��"

    Private Sub TAAttendancePanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TAAttendancePanel.HandleCreated
        'connection() '��������ʱʹ�ã���ʹ�ã����޷��������ڣ�
        init()
        get_info()
        �Ͽ���Ϣͳ��.Enabled = True
        PictureBox1.Image = Teaching_Assistant.My.Resources.Resources.back
        PictureBox2.Image = Teaching_Assistant.My.Resources.Resources.pre
        authcollect()
        list()
        loadinfo()
    End Sub

    Private Sub TAAttendancePanel_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles TAAttendancePanel.HandleDestroyed
        save()
    End Sub

#End Region

#Region "�Ͽ����ͳ��"

    Public Sub collection()
        Dim zhuke(300) As String
        Dim str1, str2 As String
        Dim table1, table2, table3, table4 As DataTable
        Dim i, j, k As Integer
        Dim m As Integer = 0
        Dim MyArray As Array
        Dim number As Integer = 0
        str1 = "select ���������� from ������Ա��Ϣ where ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
        table1 = gettable("������Ա��Ϣ", str1, False)
        str2 = "select ���� from member"
        table2 = gettable("member", str2, True)
        For i = 0 To table2.Rows.Count - 1
            For j = 0 To table1.Rows.Count - 1
                If Trim(table1.Rows(j).Item("����������")) = Trim(table2.Rows(i).Item("����")) Then
                    number = number + 1
                End If
            Next
            str1 = "update member set ����=" & number & "where ����='" & Trim(table2.Rows(i).Item("����")) & "'"
            sql(str1, True)
            conn.Close()
            number = 0
        Next
        table1.Dispose()
        table2.Dispose()

        str1 = "select ����ͬѧ���� from ������Ա��Ϣ where ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
        table3 = gettable("������Ա��Ϣ1", str1, False)
        str2 = "select ���� from member"
        table4 = gettable("member1", str2, True)

        For j = 0 To table3.Rows.Count - 1
            If IsDBNull(table3.Rows(j).Item("����ͬѧ����")) = False Then
                MyArray = Split(Trim(table3.Rows(j).Item("����ͬѧ����")), , )
                For k = 0 To MyArray.Length - 1
                    zhuke(m) = MyArray(k)
                    m = m + 1
                Next
            End If
        Next

        For i = 0 To table4.Rows.Count - 1
            For k = 0 To m - 1
                If zhuke(k) = Trim(table4.Rows(i).Item("����")) Then
                    number = number + 1
                End If
            Next
            str1 = "update member set ����=" & number & "where ����='" & Trim(table4.Rows(i).Item("����")) & "'"
            sql(str1, True)
            conn.Close()
            number = 0
        Next
        table3.Dispose()
        table4.Dispose()

    End Sub 'ͳ�������������������δ���

    Public Sub authcollect()
        If GetServerTime().Date = DateTimePicker1.Value.Date Then
            �Ͽ���Ϣͳ��.Enabled = True
        ElseIf authority = 8 Then
            �Ͽ���Ϣͳ��.Enabled = True
        Else
            �Ͽ���Ϣͳ��.Enabled = False
        End If
    End Sub '�ж�Ȩ�ޣ���ͨ����ֻ�����޸ĵ����Ͽ����ͳ�ƣ�����Ա�����޸�������

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, DateTimePicker1.Value.Date)
    End Sub 'ǰһ�찴ť

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        DateTimePicker1.Value = DateAdd(DateInterval.Day, 1, DateTimePicker1.Value.Date)
    End Sub '��һ�찴ť

    Private Sub ListBox3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.DoubleClick
        Try
            If ListBox3.SelectedItem.ToString = "" Then
                Exit Sub
            Else
                If MessageBox.Show("ȷ��Ҫ�Ƴ���", "��ʾ", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    ListBox3.Items.Remove(ListBox3.SelectedItem.ToString())
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub '�Ƴ�����

    Private Sub ListBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.DoubleClick
        Try
            If ListBox2.SelectedItem.ToString = "" Then
                Exit Sub
            Else
                If MessageBox.Show("ȷ��Ҫ�Ƴ���", "��ʾ", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    ListBox2.Items.Remove(ListBox2.SelectedItem.ToString())
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub '�Ƴ�����

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Dim i As Integer
        Dim flag1 As Boolean = False
        Dim flag2 As Boolean = False
        If ListBox1.SelectedItem = "" Then
            Exit Sub
        ElseIf rb4.Checked = True Then
            For i = 0 To ListBox3.Items.Count - 1
                If ListBox1.SelectedItem.ToString() = ListBox3.Items(i) Then
                    flag1 = True
                End If
            Next
            If flag1 = False Then
                ListBox2.Items.Clear()
                ListBox2.Items.Add(ListBox1.SelectedItem.ToString())
            End If
        ElseIf rb5.Checked = True Then
            For i = 0 To ListBox3.Items.Count - 1
                If ListBox1.SelectedItem.ToString() = ListBox3.Items(i) Then
                    flag2 = True
                ElseIf ListBox2.Items.Count = 0 Then
                    flag2 = False
                ElseIf ListBox1.SelectedItem.ToString() = ListBox2.Items(0) Then
                    flag2 = True
                End If
            Next
            If flag2 = False Then
                ListBox3.Items.Add(ListBox1.SelectedItem.ToString())
            End If
        End If
    End Sub 'ѡ������

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim str As String = ""
        Dim names(170), fa(170) As String  '��������ĸ
        ListBox1.Items.Clear()

        strSql = "select distinct ���� from [member]"
        sql(strSql, True)
        While myreader.Read
            names(j) = myreader("����").ToString
            fa(j) = IndexCode(myreader("����").ToString)

            For k = 1 To Len(fa(j))
                If Asc(Mid(fa(j), k, 1)) < 91 Then
                    str = str & Chr(Asc(Mid(fa(j), k, 1)) + 32)
                Else : str = str & Mid(fa(j), k, 1)
                End If
            Next

            If TextBox4.Text = Mid(str, 1, Len(TextBox4.Text)) Then
                ListBox1.Items.Add(names(j))
            End If
            j = j + 1
            str = ""

        End While
        conn.Close()
    End Sub '��������ĸ��ѯ

    Private Sub list()
        Me.ListBox1.Items.Clear()
        Me.ListBox2.Items.Clear()
        Me.ListBox3.Items.Clear()
        Try
            strSql = "select distinct ���� from [member]"
            sql(strSql, True)
            While myreader.Read
                If Asc(myreader("����").ToString) = 63 Then Continue While
                ListBox1.Items.Add(myreader("����"))
            End While
            conn.Close()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub 'listbox1�б�

    Private Sub loadinfo()
        Dim month As String
        Dim day As String

        currentdate = Me.DateTimePicker1.Value

        If Me.DateTimePicker1.Value.Month < 10 Then
            month = "0" & Me.DateTimePicker1.Value.Month
        Else : month = Me.DateTimePicker1.Value.Month
        End If
        If Me.DateTimePicker1.Value.Day < 10 Then
            day = "0" & Me.DateTimePicker1.Value.Day
        Else : day = Me.DateTimePicker1.Value.Day
        End If

        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        rb4.Checked = True

        strSql = "select * from [������Ա��Ϣ] where Convert(varchar(100),�Ͽ�����,111) = '" & Me.DateTimePicker1.Value.Year & "/" & month & "/" & day & "'"
        sql(strSql, False)
        If myreader.Read = True Then
            ListBox2.Items.Add(myreader.Item("����������"))
            myarray = Split(Trim(myreader.Item("����ͬѧ����")), , )
            zhujiang = myreader.Item("����������")

            Dim i As Integer
            For i = 0 To myarray.Length - 1
                If myarray(i) <> "" Then
                    ListBox3.Items.Add(myarray(i))
                End If
            Next

            If IsDBNull(myreader.Item("�Ͽ����")) Then
                TextBox3.Text = ""
            Else
                TextBox3.Text = myreader.Item("�Ͽ����")
                info = myreader.Item("�Ͽ����")
            End If
        Else
            Dim str2 As String = ""
            myarray = Split(Trim(str2), , )
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            TextBox3.Text = ""
        End If
        conn.Close()
    End Sub '��ȡ�Ͽ����ͳ����Ϣ

    Private Sub savezhujiang()

        Dim listbox As String
        If ListBox2.Items.Count = 0 Then
            listbox = ""
        Else
            listbox = ListBox2.Items(0).ToString
        End If
        nzhujiang = String.Compare(zhujiang, listbox)
        If nzhujiang = 0 Then
            zhujiang = ""
            Exit Sub
        Else
            Dim month As String
            Dim day As String
            Dim str As String = ""

            If currentdate.Month < 10 Then
                month = "0" & currentdate.Month
            Else : month = currentdate.Month
            End If
            If currentdate.Day < 10 Then
                day = "0" & currentdate.Day
            Else : day = currentdate.Day
            End If

            strSql = "select ���������� from [������Ա��Ϣ] where Convert(varchar(100),�Ͽ�����,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
            sql(strSql, False)
            If myreader.Read = True Then
                str = "update ������Ա��Ϣ set ѧ��='" & schoolcalendar.Substring(0, 5) & "', ����������='" & listbox & "' where Convert(varchar(100),�Ͽ�����,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
                sql(str, False)
            ElseIf listbox <> "" Then
                str = "insert into ������Ա��Ϣ (����������,����ͬѧ����,�Ͽ����,�Ͽ�����,ѧ��) values ('"
                str &= listbox & "','','','" & currentdate.Year & "/" & month & "/" & day & "','" & schoolcalendar.Substring(0, 5) & "')"
                sql(str, False)
            End If
            conn.Close()

            If listbox <> "" Then
                logwrite("zhujiang", listbox, "������")
            End If

        End If
        zhujiang = ""
    End Sub '����������

    Private Sub savezhujiao()

        Dim i, j As Integer
        Dim m As Boolean = False
        Dim str1 As String = ""

        nzhujiao = True

        For i = 0 To ListBox3.Items.Count - 1
            str1 = str1 & ListBox3.Items(i) & " "
        Next

        dqmyarray = Split(Trim(str1), , )

        If dqmyarray.Length = myarray.Length Then
            For i = 0 To myarray.Length - 1
                m = False   'û��m�����޸�ǰ��������ͬʱ���޷��ύ���ݣ�2014-4-26��
                For j = 0 To dqmyarray.Length - 1
                    If myarray(i) = dqmyarray(j) Then
                        m = True
                        Exit For
                    End If
                Next
                If m = False Then
                    nzhujiao = False   'nzhujiao=falseʱ����������ύ��Ϊtrueʱ����Ϊǰ������û�б仯����2014-4-26��
                    Exit For
                End If
            Next
        Else
            nzhujiao = False
        End If

        If nzhujiao = True Then
            Array.Clear(dqmyarray, 0, dqmyarray.Length)
            Exit Sub
        Else
            Dim month As String
            Dim day As String
            Dim str As String
            Dim str2 As String = ""

            If currentdate.Month < 10 Then
                month = "0" & currentdate.Month
            Else : month = currentdate.Month
            End If
            If currentdate.Day < 10 Then
                day = "0" & currentdate.Day
            Else : day = currentdate.Day
            End If

            For i = 0 To ListBox3.Items.Count - 1
                str2 = str2 & ListBox3.Items(i) & " "
            Next

            strSql = "select ���������� from [������Ա��Ϣ] where Convert(varchar(100),�Ͽ�����,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
            sql(strSql, False)
            If myreader.Read = True Then
                str = "update ������Ա��Ϣ set ѧ��='" & schoolcalendar.Substring(0, 5) & "', ����ͬѧ����='" & Trim(str2) & "' where Convert(varchar(100),�Ͽ�����,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
                sql(str, False)
            ElseIf Trim(str2) <> "" Then
                str = "insert into ������Ա��Ϣ (����������,����ͬѧ����,�Ͽ����,�Ͽ�����,ѧ��) values ('"
                str &= "','" & Trim(str2) & "','','" & currentdate.Year & "/" & month & "/" & day & "','" & schoolcalendar.Substring(0, 5) & "')"
                sql(str, False)
            End If
            conn.Close()

            For i = 0 To ListBox3.Items.Count - 1
                If ListBox3.Items(i) <> "" Then
                    logwrite("zhujiao", ListBox3.Items(i), "����ͬѧ")
                End If
            Next

        End If
        Array.Clear(dqmyarray, 0, dqmyarray.Length)
    End Sub '��������ͬѧ

    Private Sub saveinfo()
        Dim ninfo As Integer
        ninfo = String.Compare(info, TextBox3.Text)
        If ninfo = 0 Then
            info = ""
            Exit Sub
        Else
            Dim month As String
            Dim day As String
            Dim str As String = ""

            If currentdate.Month < 10 Then
                month = "0" & currentdate.Month
            Else : month = currentdate.Month
            End If
            If currentdate.Day < 10 Then
                day = "0" & currentdate.Day
            Else : day = currentdate.Day
            End If

            strSql = "select * from [������Ա��Ϣ] where Convert(varchar(100),�Ͽ�����,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
            sql(strSql, False)
            If myreader.Read = True Then
                str = "update ������Ա��Ϣ set ѧ��='" & schoolcalendar.Substring(0, 5) & "', �Ͽ����='" & TextBox3.Text & "' where Convert(varchar(100),�Ͽ�����,111) = '" & currentdate.Year & "/" & month & "/" & day & "'"
                sql(str, False)
            ElseIf TextBox3.Text <> "" Then
                str = "insert into ������Ա��Ϣ (����������,����ͬѧ����,�Ͽ����,�Ͽ�����,ѧ��) values ('"
                str &= "','','" & TextBox3.Text & "','" & currentdate.Year & "/" & month & "/" & day & "','" & schoolcalendar.Substring(0, 5) & "')"
                sql(str, False)
            End If
            conn.Close()
        End If
        info = ""
    End Sub  '�����Ͽ����

    Public Sub save()
        savezhujiang()
        savezhujiao()
        saveinfo()
        loadinfo()
        If nzhujiang <> 0 Or nzhujiao <> True Then
            collection()
        End If
    End Sub '������̣�����ˢ��

#End Region

#Region "����ǰ�����˰�ťͼ���仯"

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.Image = Teaching_Assistant.My.Resources.Resources.back_1
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = Teaching_Assistant.My.Resources.Resources.back
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.Image = Teaching_Assistant.My.Resources.Resources.pre_1
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = Teaching_Assistant.My.Resources.Resources.pre
    End Sub

#End Region

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        authcollect()
        save()
    End Sub

    Private Sub ListBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.MouseEnter
        ListBox1.Focus()
    End Sub

    Private Sub ListBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.MouseEnter
        ListBox3.Focus()
    End Sub

End Class