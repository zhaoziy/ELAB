Public Class coursesinfo

    Private Sub CoursesInfoPanel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CoursesInfoPanel.HandleCreated
        Timer1.Start()
        Timer1.Interval = 100
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        check()
    End Sub

    Sub check()
        welcomeinfo.Text = "" & username & "同学，请记录你的选课信息"
        Dim tableinfo As New DataTable
        Dim num As String = usernum
        Dim yj As Integer
        Dim rj As Integer
        Dim yjweek As Integer
        Dim yjday As Integer
        Dim rjweek As Integer
        Dim rjday As Integer
        strSql = "select 学号,姓名,院系,硬件时间,软件时间 from [" & schoolcalendar & "计算机安装与调试技术] where 学号 = " & num  '
        tableinfo = gettable(num, strSql, False)
        Label6.Text = tableinfo.Rows(0).Item("姓名").ToString.Trim
        Label7.Text = tableinfo.Rows(0).Item("学号").ToString.Trim
        Label8.Text = tableinfo.Rows(0).Item("院系").ToString.Trim
        If tableinfo.Rows(0).Item("硬件时间").ToString.Trim() = "" Or tableinfo.Rows(0).Item("软件时间").ToString.Trim() = "" Then
            Label9.Text = "您还未完成选课"
            Label10.Text = "您还未完成选课"
        Else
            yj = tableinfo.Rows(0).Item("硬件时间").ToString.Trim()
            rj = tableinfo.Rows(0).Item("软件时间").ToString.Trim()
            yjday = yj Mod 100
            yjweek = (yj - yjday) / 100
            rjday = rj Mod 100
            rjweek = (rj - rjday) / 100
            Label9.Text = "第" & yjweek & "周，周" & yjday & "，下午1:30"
            Label10.Text = "第" & rjweek & "周，周" & rjday & "，下午1:30"
        End If
        tableinfo.Dispose()
    End Sub

End Class