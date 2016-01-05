Public Class selectcourses

    Private weekno As Integer
    Private Lbl(6, 9) As Label   '**************����Ϊ70��7*10��������**************
    Private LblWeek(9) As Label  '**************����Ϊ10������**************
    Private LblTime(6) As Label  '**************����Ϊ7������**************

#Region "�����¼�"

    Private Sub SelectCoursesPanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectCoursesPanel.HandleCreated
        'connection()   '**************����ʱʹ��***************
        initialize()
        searchclass()
    End Sub

    Private Sub searchclass()   '*************��ѯĳͬѧ��ѡ��ʱ��*************

        Dim tableclass1 As String = "[" & schoolcalendar & "�������װ����Լ���]"

        Dim sqlstr As String

        lblinfo.Text = username & "ͬѧ��" & "����ѡ�����¿γ̣�"

        sqlstr = "select ѧ��,����,Ӳ��ʱ��,���ʱ�� from " & tableclass1 & " where ѧ�� =" & usernum

        Dim classtable As New DataTable
        classtable = gettable("��ѡ���Կ�", sqlstr, False)

        If classtable.Rows.Count > 0 Then
            Dim weekstr As String
            Dim week, time As Integer
            If classtable.Rows(0).Item("Ӳ��ʱ��").ToString <> "" And classtable.Rows(0).Item("Ӳ��ʱ��").ToString <> "1801" Then
                week = classtable.Rows(0).Item("Ӳ��ʱ��") \ 100
                time = classtable.Rows(0).Item("Ӳ��ʱ��") Mod 10
                Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.Green
                lblhard.Text = "Ӳ����װ"
                lblhard.Text &= vbCrLf & " �� " & week & " �� "
                lblhard.Visible = True
                lblhard.Text = lblhard.Text & GetDay(time) & vbCrLf & "���� 1:30 - 9:00"
            End If

            If classtable.Rows(0).Item("���ʱ��").ToString <> "" And classtable.Rows(0).Item("���ʱ��").ToString <> "1901" Then
                week = classtable.Rows(0).Item("���ʱ��") \ 100
                time = classtable.Rows(0).Item("���ʱ��") Mod 10
                Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.Green
                lblsoft.Text = "�����װ"
                lblsoft.Text &= vbCrLf & " �� " & week & " �� "
                weekstr = ""
                lblsoft.Visible = True
                lblsoft.Text = lblsoft.Text & GetDay(time) & vbCrLf & "���� 1:30 - 9:00"
            End If
        End If
        classtable.Dispose()
    End Sub

#End Region

#Region "��ʼ��"

    Public Sub initialize()

        lblinfo.Text = username & "ͬѧ��" & "����ѡ�����¿γ̣�"
        lblhard.BackColor = Color.LightGreen
        lblsoft.BackColor = Color.Pink

        'init()
        getweek()
        weekno = CInt(RJ(1)) - CInt(YJ(0)) + 1

        Dim Width As Integer = LblStandard.Width
        Dim Height As Integer = LblStandard.Height
        Dim i, j As Integer
        '*******************ʱ����*****************
        For i = 0 To 7 - 1 Step 1
            LblTime(i) = New Label
            LblTime(i).AutoSize = False
            LblTime(i).Height = Height
            LblTime(i).Width = Width
            LblTime(i).Top = LblStandard.Top
            LblTime(i).Left = LblStandard.Left + (i + 1) * Width
            LblTime(i).BorderStyle = BorderStyle.FixedSingle
            LblTime(i).BackColor = Color.FromArgb(128, 255, 255)
            LblTime(i).Font = New Font("����", 12)
            If i < 7 Then LblTime(i).Text = GetDay(i + 1)
            LblTime(i).TextAlign = ContentAlignment.MiddleCenter
            PanelTime.Controls.Add(LblTime(i))
        Next
        '***********************�ܴ���***********************
        For j = 0 To weekno - 1 Step 1
            LblWeek(j) = New Label
            LblWeek(j).AutoSize = False
            LblWeek(j).Height = Height
            LblWeek(j).Width = Width
            LblWeek(j).Top = LblStandard.Top + (j + 1) * Height
            LblWeek(j).Left = LblStandard.Left
            LblWeek(j).BorderStyle = BorderStyle.FixedSingle
            LblWeek(j).BackColor = Color.FromArgb(128, 255, 255)
            LblWeek(j).Font = New Font("����", 12)

            Dim Decade As Integer = j + CInt(YJ(0))
            If Decade < 10 Then
                LblWeek(j).Text = "�� " & "0" & (j + CInt(YJ(0))).ToString & " ��"
            Else
                LblWeek(j).Text = "�� " & (j + CInt(YJ(0))).ToString & " ��"
            End If
            LblWeek(j).TextAlign = ContentAlignment.MiddleCenter
            PanelTime.Controls.Add(LblWeek(j))
        Next
        '*********************�����********************
        For j = 0 To weekno - 1
            For i = 0 To 6     'i�����ܼ���j����ڼ���
                Lbl(i, j) = New Label
                Lbl(i, j).Name = "lbl" & i.ToString & j.ToString
                Lbl(i, j).AutoSize = False
                Lbl(i, j).Width = Width
                Lbl(i, j).Height = Height
                Lbl(i, j).Top = LblStandard.Top + (j + 1) * Height
                Lbl(i, j).Left = LblStandard.Left + (i + 1) * Width
                Lbl(i, j).BorderStyle = BorderStyle.Fixed3D
                Lbl(i, j).BackColor = Color.FloralWhite
                Lbl(i, j).TextAlign = ContentAlignment.MiddleCenter
                Lbl(i, j).Font = New Font("����", 12)
                PanelTime.Controls.Add(Lbl(i, j))
                Lbl(i, j).TabIndex = 1000 + (j + 1) * 10 + i + 1
                AddHandler Lbl(i, j).DoubleClick, New System.EventHandler(AddressOf Me.lbl_doubleclick)
                AddHandler Lbl(i, j).MouseEnter, New System.EventHandler(AddressOf Me.lbl_MouseEnter)
            Next
        Next
        gettime()
        getremain()
    End Sub

    Private Function gettime() As Boolean     '***************�����****************
        Dim i, j As Integer
        For i = 0 To CInt(YJ(1)) - CInt(YJ(0))
            For j = 0 To 6
                Lbl(j, i).Text = "Ӳ����װ"
                Lbl(j, i).BackColor = Color.LightGreen
            Next
        Next
        For i = CInt(RJ(0)) - CInt(YJ(0)) To CInt(RJ(1)) - CInt(YJ(0))
            For j = 0 To 6
                Lbl(j, i).Text = "�����װ"
                Lbl(j, i).BackColor = Color.Pink
            Next
        Next
    End Function

    Private Sub getremain()    '**************��ȡѡ������****************
        Application.DoEvents()
        gettotalnum()
        Dim i, j As Integer
        Dim sqlstr As String
        For i = 0 To YJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select count(*) from [" & schoolcalendar & "�������װ����Լ���] "
                sqlstr &= "where Ӳ��ʱ�� = " & (i + YJ(0)) & "0" & (j + 1)
                If sql(sqlstr, False) And myreader.Read Then
                    Lbl(j, i).Text = "Ӳ��" & "(" & (Totalnum(j, i) - CInt(myreader.Item(0).ToString.Trim)) & "/" & Totalnum(j, i) & ")"
                    If CInt(myreader.Item(0).ToString.Trim) >= Totalnum(j, i) Then
                        Lbl(j, i).BackColor = Color.Red
                        'Else : Lbl(j, i).BackColor = Color.LightGreen
                    End If
                End If
                conn.Close()
                sqlstr = "select �Ƿ��ѡ from [�Ͽ�����]"
                sqlstr &= "where ���� = '" & j + 1 & "' and �ܴ� ='" & i + YJ(0) & "'"
                If sql(sqlstr, True) And myreader.Read Then
                    If myreader.Item(0) = "��" Then
                        Lbl(j, i).Text = "��ֹѡ��"
                        Lbl(j, i).BackColor = Color.Gray
                    End If
                End If
                conn.Close()
            Next
        Next
        For i = RJ(0) - YJ(0) To RJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select count(*) from [" & schoolcalendar & "�������װ����Լ���] "
                sqlstr &= "where ���ʱ�� = " & (i + YJ(0)) & "0" & (j + 1)
                If sql(sqlstr, False) And myreader.Read Then
                    Lbl(j, i).Text = "���" & "(" & (Totalnum(j, i) - CInt(myreader.Item(0).ToString.Trim)) & "/" & Totalnum(j, i) & ")"
                    If CInt(myreader.Item(0).ToString.Trim) >= Totalnum(j, i) Then Lbl(j, i).BackColor = Color.Red
                End If
                conn.Close()
                sqlstr = "select �Ƿ��ѡ from [�Ͽ�����]"
                sqlstr &= "where ���� = '" & j + 1 & "' and �ܴ� ='" & i + YJ(0) & "'"
                If sql(sqlstr, True) And myreader.Read Then
                    If myreader.Item(0) = "��" Then
                        Lbl(j, i).Text = "��ֹѡ��"
                        Lbl(j, i).BackColor = Color.Gray
                    End If
                End If
                conn.Close()
            Next
        Next
    End Sub

#End Region

#Region "ѡ��"

    Private Sub xuanke(ByVal tablename As String, ByVal columnname As String, ByVal columnvalue As Integer)

        Dim week, time As Integer
        If CInt(columnvalue) = 0 Then
            MsgBox("����", MsgBoxStyle.OkOnly, "����")
        End If
        week = columnvalue \ 100
        time = columnvalue Mod 10

        Try
            Dim datenow As Date = Now.Date
            Dim updatestr As String = "update " & tablename & " set ѡ��ʱ�� = '" & DateTime.Now & "'," & columnname & "=" & _
                          columnvalue.ToString & " where ѧ��= " & usernum & " and ѡ��ʱ�� is NULL;"
            updatestr &= "update " & tablename & " set " & columnname & "=" & _
                          columnvalue.ToString & " where ѧ��= " & usernum & " and ѡ��ʱ�� is not NULL"
            executesql(tablename, updatestr)        '���ѡ��ʱ��Ϊnull�������ѡ��ʱ����Ͽ�ʱ�䣬����ֻ�����Ͽ�ʱ�䣨��Ҫ֪����һ��ѡ�ε�ʱ�䣩

            Dim checknum As String = "select count(*) from " & tablename & " where " & columnname & "='" & columnvalue.ToString & "'"
            Dim num As Integer
            sql(checknum, False)
            If myreader.Read() Then
                num = myreader.Item(0)
                If num > Totalnum(CInt(time - 1), CInt(week - YJ(0))) Then
                    updatestr = "update " & tablename & " set ѡ��ʱ�� = NULL, " & columnname & "= NULL where ѧ��='" & usernum & "'"
                    sql(updatestr, False)
                    conn.Close()
                End If
            End If
            conn.Close()

            If num > Totalnum(CInt(time - 1), CInt(week - YJ(0))) Then
                MsgBox("�Բ����Ѿ�û�п������ˣ�")
                gettime()
                getremain()
                searchclass()
                Exit Sub
            End If


            Dim weeks As Integer
            weeks = DateDiff(DateInterval.DayOfYear, startday, GetServerTime()) \ 7 + 1    'У���ڼ���
            If weeks < YJ(0) Then  'ѡ��ʱ�������ۿ��ڼ�����ѡ�Σ���ע��¼����
                strSql = "update " & tablename & " set ��ע='����' where ѧ�� = '" & usernum & "'"
                sql(strSql, False)
                conn.Close()
                MsgBox("ѡ�γɹ������μ�ѡ��ʱ�䡣", MsgBoxStyle.OkOnly, "��Ϣ")
            ElseIf authority = 1 Then  'ѡ��ʱ����ʵ�����ڼ䣬���ǵ�һ�ν���ѡ�Σ���ע��¼δǩ��
                strSql = "update " & tablename & " set ��ע='δǩ��' where ѧ�� = '" & usernum & "'"
                sql(strSql, False)
                conn.Close()
                MsgBox("ѡ�γɹ���ѡ��ʱ�䲻�����ۿ��ڼ䣬��δǩ������")
            ElseIf authority = 2 Then  'ѡ��ʱ����ʵ�����ڼ䣬�ҷǵ�һ�ν���ѡ�Σ������пγ��޸ģ���ע��¼���޸ġ���Ӱ�������Ͽ�ʱ�Ǽǵı�ע��¼
                MsgBox("ѡ�γɹ������μ�ѡ��ʱ�䡣", MsgBoxStyle.OkOnly, "��Ϣ")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        gettime()
        getremain()
        searchclass()
    End Sub 'ѡ��

    Private Sub lbl_doubleclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If authority = 1 Then
            If CloseXuanke = True Then MsgBox("ѡ��ϵͳ�ѹرգ�") : Exit Sub
        ElseIf authority = 8 Then : Exit Sub '����Ա����ʱ������Ա�鿴ѡ����Ϣ���������Ͽ�����޸�
        End If

        getremain()  '**************��ȡѡ������,ȷ��������****************

        Dim lblback As Color = sender.backcolor
        If lblback = Color.Red Then
            MsgBox("��������Ϊ��!", MsgBoxStyle.OkOnly, "����")
            Exit Sub
        ElseIf lblback = Color.Gray Then
            MsgBox("���ʱ���Ϊ�ڼ��ջ�����ԭ�򣬲���ѡ�Σ���ѡ������ʱ�䣡", MsgBoxStyle.OkOnly, "����")
            Exit Sub
        ElseIf lblback = Color.Green Then
            MsgBox("����ѡ��˶�ʱ�䣡", MsgBoxStyle.OkOnly, "����")
            Exit Sub
        End If
        Dim week, time As Integer
        week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
        time = sender.tabindex Mod 10

        Dim tablename As String = "[" & schoolcalendar
        Dim columnname As String
        Dim columnvalue As Integer = week * 100 + time
        Dim sendertext As String = sender.text
        Dim lbltext As String = Microsoft.VisualBasic.Left(sendertext, 2)
        If lbltext = "" Then
            Exit Sub
        End If
        Select Case lbltext
            Case "Ӳ��"
                tablename = tablename & "�������װ����Լ���]"
                columnname = "Ӳ��ʱ��"
            Case "���"
                tablename = tablename & "�������װ����Լ���]"
                columnname = "���ʱ��"
            Case Else
                tablename = ""
                columnname = ""
                MsgBox("����", MsgBoxStyle.OkOnly, "����")
                Exit Sub
        End Select
        xuanke(tablename, columnname, columnvalue)

    End Sub '˫����ǩ

    Private Sub lbl_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.backcolor <> Color.FloralWhite Then
            If sender.backcolor <> Color.Gray Then
                Try
                    Dim week, time As Integer
                    week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
                    time = sender.tabindex Mod 10
                    Dim d As Date = DateAdd(DateInterval.Day, (week - 1) * 7 + time - 1, startday)
                    Dim course As String = ""
                    If week >= YJ(0) And week <= YJ(1) Then course = "��װ�����(Ӳ������)"
                    If week >= RJ(0) And week <= RJ(1) Then course = "��װ�����(�������)"
                    Dim remain As Integer = CInt(sender.text.ToString.Split("(")(1).Split("/")(0))
                    Me.ToolTip1.SetToolTip(sender, "��" & week & "�� " & GetDay(time) & vbCrLf & d & vbCrLf & course & vbCrLf & "ʣ��" & remain & "��")
                Catch ex As Exception
                End Try
            Else
                Try
                    Dim week, time As Integer
                    week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
                    time = sender.tabindex Mod 10
                    Dim d As Date = DateAdd(DateInterval.Day, (week - 1) * 7 + time - 1, startday)
                    Dim course As String = ""
                    If week >= YJ(0) And week <= YJ(1) Then course = "Ӳ�����֣��ڼ��գ�"
                    If week >= RJ(0) And week <= RJ(1) Then course = "������֣��ڼ��գ�"
                    Me.ToolTip1.SetToolTip(sender, "��" & week & "�� " & GetDay(time) & vbCrLf & d & vbCrLf & course & vbCrLf)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub '��������ڱ�ǩ����ʾ�γ���Ϣ

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quit.Click
        Me.Close()
    End Sub

    
End Class