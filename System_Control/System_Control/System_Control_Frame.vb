Imports System.Windows.Forms

Public Class System_Control_Frame

    Dim Current_Tab As Integer = 0

    Private Sub System_Control_Tab_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles System_Control_Tab.HandleCreated

        get_info()
        initialize()

    End Sub

    Private Sub initialize()
        init()
        checkip()

        If authority = 0 Then

            Dim Log_Read As New LogRead
            Dim comouter_remote_form As New Computer_Remote

            TabPage1.Controls.Add(Log_Read.LogReadPanel)
            TabPage4.Controls.Add(comouter_remote_form.Computer_Remote_Panel)

            Log_Read.Dispose()
            comouter_remote_form.Dispose()

            System_Control_Tab.TabPages.Remove(TabPage2)
            System_Control_Tab.TabPages.Remove(TabPage3)
            System_Control_Tab.TabPages.Remove(TabPage5)
         
        ElseIf authority = 8 Then

            Dim Log_Read As New LogRead
            Dim appoint As New Appoint_Admin
            Dim comouter_remote_form As New Computer_Remote
            Dim Notice As New Notice

            TabPage1.Controls.Add(Log_Read.LogReadPanel)
            TabPage3.Controls.Add(appoint.Appoint_Admin_Panel)
            TabPage4.Controls.Add(comouter_remote_form.Computer_Remote_Panel)
            TabPage5.Controls.Add(Notice.Notice_Panel)

            Log_Read.Dispose()
            comouter_remote_form.Dispose()
            Notice.Dispose()
            appoint.Dispose()
        End If
        
    End Sub

    Private Sub System_Control_Tab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles System_Control_Tab.SelectedIndexChanged
        If System_Control_Tab.TabPages.IndexOf(TabPage2) <> -1 Then
            If System_Control_Tab.SelectedIndex = System_Control_Tab.TabPages.IndexOf(TabPage2) Then
                System_Control_Tab.SelectTab(Current_Tab)
                Dim selectdate As New SelectDate
                selectdate.ShowDialog()
                selectdate.Dispose()
            ElseIf System_Control_Tab.SelectedIndex <> -1 Then
                Current_Tab = System_Control_Tab.SelectedIndex
            End If
        End If
    End Sub
End Class