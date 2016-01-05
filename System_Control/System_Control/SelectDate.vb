Imports System.Windows.Forms
Imports System.Drawing

Public Class SelectDate

    Private weekno As Integer
    Private Lbl(6, 9) As Label   '**************����Ϊ70��7*10��������**************
    Private LblWeek(9) As Label  '**************����Ϊ10������**************
    Private LblTime(6) As Label  '**************����Ϊ7������**************
    Private Txt(6, 9) As TextBox  '**************����Ϊ70��7*10��������**************
    Private Txt_Assist(6, 9) As TextBox  '**************����Ϊ70��7*10��������**************

#Region "��ʼ�������Ʊ��"

    Public Sub initialize()

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
            LblWeek(j).Top = LblStandard.Top + (j + 1) * Height + (j + 1) * (TextStandard.Height + 2)
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
                Lbl(i, j).Top = LblStandard.Top + (j + 1) * Height + (j + 1) * (TextStandard.Height + 2)
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

        '***********************�ı�����***********************
        TextStandard.Enabled = False
        TextStandard.Visible = False
        For j = 0 To weekno - 1
            For i = 0 To 6     'i�����ܼ���j����ڼ���
                Txt(i, j) = New TextBox
                Txt(i, j).MaxLength = 2
                Txt(i, j).Name = "txt" & i.ToString & j.ToString
                Txt(i, j).Width = TextStandard.Width
                Txt(i, j).Height = TextStandard.Height
                Txt(i, j).Top = TextStandard.Top + (j + 1) * Height + (j + 1) * (TextStandard.Height + 2)
                Txt(i, j).Left = TextStandard.Left + (i + 1) * Width
                PanelTime.Controls.Add(Txt(i, j))
                Txt(i, j).TabIndex = 2000 + (j + 1) * 10 + i + 1
                AddHandler Txt(i, j).TextChanged, New System.EventHandler(AddressOf Me.Txt_TextChanged)
            Next
        Next

        TextStandard_Assist.Enabled = False
        TextStandard_Assist.Visible = False
        For j = 0 To weekno - 1
            For i = 0 To 6     'i�����ܼ���j����ڼ���
                Txt_Assist(i, j) = New TextBox
                Txt_Assist(i, j).MaxLength = 1
                Txt_Assist(i, j).Name = "txt" & i.ToString & j.ToString
                Txt_Assist(i, j).Width = TextStandard_Assist.Width
                Txt_Assist(i, j).Height = TextStandard_Assist.Height
                Txt_Assist(i, j).Top = TextStandard_Assist.Top + (j + 1) * Height + (j + 1) * (TextStandard_Assist.Height + 2)
                Txt_Assist(i, j).Left = TextStandard_Assist.Left + (i + 1) * Width
                PanelTime.Controls.Add(Txt_Assist(i, j))
                Txt_Assist(i, j).TabIndex = 3000 + (j + 1) * 10 + i + 1
                AddHandler Txt_Assist(i, j).TextChanged, New System.EventHandler(AddressOf Me.Txt_Assist_TextChanged)
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

    Private Sub getremain()    '**************��ȡ��ѡ������****************
        Application.DoEvents()
        Dim i, j As Integer
        Dim sqlstr As String
        For i = 0 To YJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select �Ƿ��ѡ from [�Ͽ�����] "
                sqlstr &= "where ���� = '" & j + 1 & "' and �ܴ� ='" & i + YJ(0) & "'"
                If sql(sqlstr, True) And myreader.Read Then
                    If myreader.Item(0) = "��" Then
                        Lbl(j, i).Text = "��ֹѡ��"
                        Lbl(j, i).BackColor = Color.Red
                    End If
                End If
                conn.Close()
            Next
        Next
        For i = RJ(0) - YJ(0) To RJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select �Ƿ��ѡ from [�Ͽ�����] "
                sqlstr &= "where ���� = '" & j + 1 & "' and �ܴ� ='" & i + YJ(0) & "'"
                If sql(sqlstr, True) And myreader.Read Then
                    If myreader.Item(0) = "��" Then
                        Lbl(j, i).Text = "��ֹѡ��"
                        Lbl(j, i).BackColor = Color.Red
                    End If
                End If
                conn.Close()
            Next
        Next
    End Sub

    Private Sub Txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)   '**************��ȡ����������****************

        Dim week, time As Integer
        week = (sender.tabindex - 2000) \ 10 + YJ(0) - 1
        time = sender.tabindex Mod 10

        updatecmd = "update �Ͽ����� set ������='" & Txt(time - 1, week - CInt(YJ(0))).Text & "' where �ܴ�='" & week & "' and ����='" & time & "'"
        sql(updatecmd, True)
        conn.Close()

    End Sub

    Private Sub Txt_Assist_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)   '**************��ȡ������������****************

        Dim week, time As Integer
        week = (sender.tabindex - 3000) \ 10 + YJ(0) - 1
        time = sender.tabindex Mod 10

        updatecmd = "update �Ͽ����� set ��������='" & Txt_Assist(time - 1, week - CInt(YJ(0))).Text & "' where �ܴ�='" & week & "' and ����='" & time & "'"
        sql(updatecmd, True)
        conn.Close()

    End Sub

    Private Sub gettotal()            '**************��ȡ��������������������****************
        Application.DoEvents()
        Dim i, j As Integer
        Dim sqlstr As String
        For i = 0 To YJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select ������ from [�Ͽ�����] "
                sqlstr &= "where ���� = '" & j + 1 & "' and �ܴ� ='" & i + YJ(0) & "' and �Ƿ��ѡ='��'"
                If sql(sqlstr, True) AndAlso myreader.Read Then

                    If IsDBNull(myreader.Item("������")) = True Then
                        Txt(j, i).Text = 0
                    Else
                        Txt(j, i).Text = myreader.Item("������")
                    End If

                End If
                conn.Close()
                conn.Dispose()

                sqlstr = "select �������� from [�Ͽ�����] "
                sqlstr &= "where ���� = '" & j + 1 & "' and �ܴ� ='" & i + YJ(0) & "' and �Ƿ��ѡ='��'"
                If sql(sqlstr, True) AndAlso myreader.Read Then

                    If IsDBNull(myreader.Item("��������")) = True Then
                        Txt_Assist(j, i).Text = 0
                    Else
                        Txt_Assist(j, i).Text = myreader.Item("��������")
                    End If

                End If
                conn.Close()
                conn.Dispose()
            Next
        Next
        For i = RJ(0) - YJ(0) To RJ(1) - YJ(0)
            For j = 0 To 6
                sqlstr = "select ������ from [�Ͽ�����] "
                sqlstr &= "where ���� = '" & j + 1 & "' and �ܴ� ='" & i + YJ(0) & "' and �Ƿ��ѡ='��'"
                If sql(sqlstr, True) AndAlso myreader.Read Then

                    If IsDBNull(myreader.Item("������")) = True Then
                        Txt(j, i).Text = 0
                    Else
                        Txt(j, i).Text = myreader.Item("������")
                    End If

                End If
                conn.Close()
                conn.Dispose()

                sqlstr = "select �������� from [�Ͽ�����] "
                sqlstr &= "where ���� = '" & j + 1 & "' and �ܴ� ='" & i + YJ(0) & "' and �Ƿ��ѡ='��'"
                If sql(sqlstr, True) AndAlso myreader.Read Then

                    If IsDBNull(myreader.Item("��������")) = True Then
                        Txt_Assist(j, i).Text = 0
                    Else
                        Txt_Assist(j, i).Text = myreader.Item("��������")
                    End If

                End If
                conn.Close()
                conn.Dispose()
            Next
        Next
        For i = 0 To RJ(1) - YJ(0)
            For j = 0 To 6
                If Lbl(j, i).BackColor = Color.Red Then
                    Txt(j, i).Visible = False
                    Txt(j, i).Enabled = False

                    Txt_Assist(j, i).Visible = False
                    Txt_Assist(j, i).Enabled = False
                Else
                    Txt(j, i).Visible = True
                    Txt(j, i).Enabled = True

                    Txt_Assist(j, i).Visible = True
                    Txt_Assist(j, i).Enabled = True
                End If
            Next
        Next
    End Sub

#End Region

#Region "ѡ������"

    Private Sub lbl_doubleclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lblback As Color = sender.backcolor
        Dim week, time As Integer
        week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
        time = sender.tabindex Mod 10

        If lblback = Color.Red Then
            If week <= CInt(YJ(1)) Then
                Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.LightGreen
                Lbl(time - 1, week - CInt(YJ(0))).Text = "Ӳ����װ"
                updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��',�Ͽ�����='Ӳ����' where �ܴ�='" & week & "' and ����='" & time & "'"
                sql(updatecmd, True)
                conn.Close()
            ElseIf week >= CInt(RJ(0)) Then
                Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.Pink
                Lbl(time - 1, week - CInt(YJ(0))).Text = "�����װ"
                updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��',�Ͽ�����='�����' where �ܴ�='" & week & "' and ����='" & time & "'"
                sql(updatecmd, True)
                conn.Close()
            End If

        ElseIf lblback = Color.LightGreen Or lblback = Color.Pink Then
            updatecmd = "update �Ͽ����� set �Ƿ��ѡ='��',�Ͽ�����=NULL where �ܴ�='" & week & "' and ����='" & time & "'"
            sql(updatecmd, True)
            conn.Close()
            Lbl(time - 1, week - CInt(YJ(0))).BackColor = Color.Red
            Lbl(time - 1, week - CInt(YJ(0))).Text = "��ֹѡ��"
        End If
        gettime()
        getremain()
        gettotal()
    End Sub

    Private Sub lbl_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.backcolor <> Color.FloralWhite Then
            Try
                Dim week, time As Integer
                week = (sender.tabindex - 1000) \ 10 + YJ(0) - 1
                time = sender.tabindex Mod 10
                Dim d As Date = DateAdd(DateInterval.Day, (week - 1) * 7 + time - 1, startday)
                Dim course As String = ""
                If week >= YJ(0) And week <= YJ(1) Then course = "��װ�����(Ӳ������)"
                If week >= RJ(0) And week <= RJ(1) Then course = "��װ�����(�������)"
                Me.ToolTip1.SetToolTip(sender, "��" & week & "�� " & GetDay(time) & vbCrLf & d & vbCrLf & course & vbCrLf)
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

    Private Sub SelectDate_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        initialize()
        gettotal()
        LblStandard.BackColor = Color.FloralWhite
        PanelTime.Height = 650
        Me.Height = 813
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class