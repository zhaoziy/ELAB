Public Class coursesinfo

    Private Sub CoursesInfoPanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CoursesInfoPanel.HandleCreated
        Timer1.Start()
        Timer1.Interval = 100
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        check()
    End Sub

    Sub check()
        welcomeinfo.Text = "" & username & "ͬѧ�����¼���ѡ����Ϣ"
        Dim tableinfo As New DataTable
        Dim num As String = usernum
        Dim yj As Integer
        Dim rj As Integer
        Dim yjweek As Integer
        Dim yjday As Integer
        Dim rjweek As Integer
        Dim rjday As Integer
        strSql = "select ѧ��,����,Ժϵ,Ӳ��ʱ��,���ʱ�� from [" & schoolcalendar & "�������װ����Լ���] where ѧ�� = " & num  '
        tableinfo = gettable(num, strSql, False)
        Label6.Text = tableinfo.Rows(0).Item("����").ToString.Trim
        Label7.Text = tableinfo.Rows(0).Item("ѧ��").ToString.Trim
        Label8.Text = tableinfo.Rows(0).Item("Ժϵ").ToString.Trim
        If tableinfo.Rows(0).Item("Ӳ��ʱ��").ToString.Trim() = "" Or tableinfo.Rows(0).Item("���ʱ��").ToString.Trim() = "" Then
            Label9.Text = "����δ���ѡ��"
            Label10.Text = "����δ���ѡ��"
        Else
            yj = tableinfo.Rows(0).Item("Ӳ��ʱ��").ToString.Trim()
            rj = tableinfo.Rows(0).Item("���ʱ��").ToString.Trim()
            yjday = yj Mod 100
            yjweek = (yj - yjday) / 100
            rjday = rj Mod 100
            rjweek = (rj - rjday) / 100
            Label9.Text = "��" & yjweek & "�ܣ���" & yjday & "������1:30"
            Label10.Text = "��" & rjweek & "�ܣ���" & rjday & "������1:30"
        End If
        tableinfo.Dispose()
    End Sub

End Class