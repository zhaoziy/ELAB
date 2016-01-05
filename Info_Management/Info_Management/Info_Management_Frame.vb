Public Class Info_Management_Frame

    Dim Current_Tab As Integer = 0

    Private Sub Info_Management_Tab_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Info_Management_Tab.HandleCreated
        initialize()
    End Sub

    Private Sub initialize()
        init()
        get_info()

        Dim Info_manager As New infomanager
        TabPage1.Controls.Add(Info_manager.InfoManagerPanel)
        Info_manager.Dispose()

        Dim Change_info As New ChangeInfo
        Change_info.GetNum = usernum
        Change_info.GetRole = False
        TabPage2.Controls.Add(Change_info.Change_Info_Panel)
        Change_info.Dispose()

        If authority = 9 Then
            Info_Management_Tab.TabPages.Remove(TabPage2)
            Info_Management_Tab.TabPages.Remove(TabPage3)
        End If

    End Sub

    Private Sub Info_Management_Tab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Info_Management_Tab.SelectedIndexChanged
        If Info_Management_Tab.TabPages.IndexOf(TabPage3) <> -1 Then
            If Info_Management_Tab.SelectedIndex = Info_Management_Tab.TabPages.IndexOf(TabPage3) Then
                Info_Management_Tab.SelectTab(Current_Tab)
                Dim Time_Collection As New TimeCollection
                Time_Collection.ShowDialog()
                Time_Collection.Dispose()
            ElseIf Info_Management_Tab.SelectedIndex <> -1 Then
                Current_Tab = Info_Management_Tab.SelectedIndex
            End If
        End If
    End Sub
End Class