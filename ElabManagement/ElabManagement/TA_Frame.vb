Imports System.Threading

Public Class TA_Frame

    Dim Current_Tab As Integer = 0

    Private Sub TA_TBE_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TA_TBE.HandleCreated

        Try
            If authority = 1 Then

                TabPage1.Text = "选课"
                TabPage1.Controls.Add(selectcourses.SelectCoursesPanel)
                TA_TBE.TabPages.Remove(TabPage2)
                TA_TBE.TabPages.Remove(TabPage3)
                TA_TBE.TabPages.Remove(TabPage4)
                TA_TBE.TabPages.Remove(TabPage5)
                TA_TBE.TabPages.Remove(TabPage6)
                TA_TBE.TabPages.Remove(TabPage7)

            ElseIf authority = 2 Then

                TabPage2.Text = "查看选课信息"
                TabPage2.Controls.Add(coursesinfo.CoursesInfoPanel)

                TabPage1.Text = "选课"
                TabPage1.Controls.Add(selectcourses.SelectCoursesPanel)

                TA_TBE.TabPages.Remove(TabPage3)
                TA_TBE.TabPages.Remove(TabPage4)
                TA_TBE.TabPages.Remove(TabPage5)
                TA_TBE.TabPages.Remove(TabPage6)
                TA_TBE.TabPages.Remove(TabPage7)

                TA_TBE.SelectTab("TabPage2")

            ElseIf authority = 0 Then

                TabPage1.Text = "查看选课情况"
                TabPage1.Controls.Add(selectcourses.SelectCoursesPanel)

                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Teaching_Assistant.dll") = True Then
                    TabPage3.Text = "成绩录入"
                    If DLL_Import(Application.StartupPath & "\Teaching_Assistant.dll", "Teaching_Assistant.inputscore", TabPage3, "InputScorePanel") = True Then
                    Else
                        TA_TBE.TabPages.Remove(TabPage3)
                    End If
                Else
                    TA_TBE.TabPages.Remove(TabPage3)
                End If

                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Teaching_Assistant.dll") = True Then
                    TabPage4.Text = "助教出勤统计"
                    If DLL_Import(Application.StartupPath & "\Teaching_Assistant.dll", "Teaching_Assistant.TAAttendance", TabPage4, "TAAttendancePanel") = True Then
                    Else
                        TA_TBE.TabPages.Remove(TabPage4)
                    End If
                Else
                    TA_TBE.TabPages.Remove(TabPage4)
                End If

                TA_TBE.TabPages.Remove(TabPage2)
                TA_TBE.TabPages.Remove(TabPage5)
                TA_TBE.TabPages.Remove(TabPage6)
                TA_TBE.TabPages.Remove(TabPage7)

            ElseIf authority = 8 Then

                TabPage1.Text = "查看选课情况"
                TabPage1.Controls.Add(selectcourses.SelectCoursesPanel)

                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Teaching_Assistant.dll") = True Then
                    TabPage3.Text = "成绩录入"
                    If DLL_Import(Application.StartupPath & "\Teaching_Assistant.dll", "Teaching_Assistant.inputscore", TabPage3, "InputScorePanel") = True Then
                        TA_TBE.SelectTab(TabPage3)
                    Else
                        TA_TBE.TabPages.Remove(TabPage3)
                    End If
                Else
                    TA_TBE.TabPages.Remove(TabPage3)
                End If

                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Teaching_Assistant.dll") = True Then
                    TabPage4.Text = "助教出勤统计"
                    If DLL_Import(Application.StartupPath & "\Teaching_Assistant.dll", "Teaching_Assistant.TAAttendance", TabPage4, "TAAttendancePanel") = True Then
                    Else
                        TA_TBE.TabPages.Remove(TabPage4)
                    End If
                Else
                    TA_TBE.TabPages.Remove(TabPage4)
                End If

                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Teaching_Assistant.dll") = True Then
                    TabPage5.Text = "数据处理"
                    If DLL_Import(Application.StartupPath & "\Teaching_Assistant.dll", "Teaching_Assistant.Data_IO", TabPage5, "Data_IO_Panel") = True Then
                    Else
                        TA_TBE.TabPages.Remove(TabPage5)
                    End If
                Else
                    TA_TBE.TabPages.Remove(TabPage5)
                End If

                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Teaching_Assistant.dll") = True Then
                    TabPage7.Text = "自动填表上成绩"
                    If DLL_Import(Application.StartupPath & "\Teaching_Assistant.dll", "Teaching_Assistant.Auto_Submit", TabPage7, "Auto_Submit_Panel") = True Then
                    Else
                        TA_TBE.TabPages.Remove(TabPage7)
                    End If
                Else
                    TA_TBE.TabPages.Remove(TabPage7)
                End If

                TA_TBE.TabPages.Remove(TabPage2)

            End If
        Catch ex As Exception
            ex.ToString()
        End Try

    End Sub

    Private Sub TA_TBE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TA_TBE.SelectedIndexChanged
        If TA_TBE.TabPages.IndexOf(TabPage6) <> -1 Then
            If TA_TBE.SelectedIndex = TA_TBE.TabPages.IndexOf(TabPage6) Then
                TA_TBE.SelectTab(Current_Tab)
                Dim theory As New TheoryCourses
                theory.ShowDialog()
                theory.Dispose()
            ElseIf TA_TBE.SelectedIndex <> -1 Then
                Current_Tab = TA_TBE.SelectedIndex
            End If
        End If
    End Sub

    Private Sub TA_Frame_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If authority = 1 Then
            TA_TBE.SelectedTab = TabPage1
        ElseIf authority = 2 Then
            TA_TBE.SelectedTab = TabPage2
        End If
    End Sub

End Class