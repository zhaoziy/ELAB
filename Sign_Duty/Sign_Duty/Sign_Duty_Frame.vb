Public Class Sign_Duty_Frame

    Private Sub Sign_Duty_Tab_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sign_Duty_Tab.HandleCreated

        Dim sign_ins As New Sign
        TabPage1.Controls.Add(sign_ins.Sign_Panel)
        sign_ins.Dispose()

        Dim sign_time As New Sign_Time
        TabPage2.Controls.Add(sign_time.Sign_Time_Panel)
        sign_time.Dispose()

        Dim Duty As New Duty
        TabPage3.Controls.Add(Duty.Duty_Panel)
        Duty.Dispose()

        Dim Duty_Table As New Duty_Table
        TabPage4.Controls.Add(Duty_Table.Duty_Table_Panel)

    End Sub
End Class