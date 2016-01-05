Imports System.Windows.Forms

Public Class AutoArrangeDuty

    Dim LB_All_Singular(6) As ListBox
    Dim LB_Auto_Singular(6) As ListBox
    Dim LB_All_Dual(6) As ListBox
    Dim LB_Auto_Dual(6) As ListBox

    Public formal(6) As Integer

    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            NumericUpDown1.Value = NumericUpDown2.Value - 1
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        If NumericUpDown2.Value <= NumericUpDown1.Value Then
            NumericUpDown2.Value = NumericUpDown1.Value + 1
        End If
    End Sub

    Private Sub initialize()

        Dim i As Integer
        Dim Width As Integer = LB_All_Singular_Standard.Width
        Dim Height As Integer = LB_All_Singular_Standard.Height

        LB_All_Singular_Standard.Visible = False
        LB_All_Singular_Standard.Enabled = False
        LB_Auto_Singular_Standard.Visible = False
        LB_Auto_Singular_Standard.Enabled = False
        LB_All_Dual_Standard.Visible = False
        LB_All_Dual_Standard.Enabled = False
        LB_Auto_Dual_Standard.Visible = False
        LB_Auto_Dual_Standard.Enabled = False

        For i = 0 To 6

            LB_All_Singular(i) = New ListBox
            LB_All_Singular(i).AutoSize = False
            LB_All_Singular(i).Height = Height
            LB_All_Singular(i).Width = Width
            LB_All_Singular(i).Top = LB_All_Singular_Standard.Top
            LB_All_Singular(i).Left = LB_All_Singular_Standard.Left + i * (Width + 15)
            GB_Singular.Controls.Add(LB_All_Singular(i))
            AddHandler LB_All_Singular(i).MouseEnter, New System.EventHandler(AddressOf Me.GetFocus)

            LB_Auto_Singular(i) = New ListBox
            LB_Auto_Singular(i).AutoSize = False
            LB_Auto_Singular(i).Height = Height
            LB_Auto_Singular(i).Width = Width
            LB_Auto_Singular(i).Top = LB_Auto_Singular_Standard.Top
            LB_Auto_Singular(i).Left = LB_Auto_Singular_Standard.Left + i * (Width + 15)
            GB_Singular.Controls.Add(LB_Auto_Singular(i))
            AddHandler LB_Auto_Singular(i).MouseEnter, New System.EventHandler(AddressOf Me.GetFocus)

            LB_All_Dual(i) = New ListBox
            LB_All_Dual(i).AutoSize = False
            LB_All_Dual(i).Height = Height
            LB_All_Dual(i).Width = Width
            LB_All_Dual(i).Top = LB_All_Dual_Standard.Top
            LB_All_Dual(i).Left = LB_All_Dual_Standard.Left + i * (Width + 15)
            GB_Dual.Controls.Add(LB_All_Dual(i))
            AddHandler LB_All_Dual(i).MouseEnter, New System.EventHandler(AddressOf Me.GetFocus)

            LB_Auto_Dual(i) = New ListBox
            LB_Auto_Dual(i).AutoSize = False
            LB_Auto_Dual(i).Height = Height
            LB_Auto_Dual(i).Width = Width
            LB_Auto_Dual(i).Top = LB_Auto_Dual_Standard.Top
            LB_Auto_Dual(i).Left = LB_Auto_Dual_Standard.Left + i * (Width + 15)
            GB_Dual.Controls.Add(LB_Auto_Dual(i))
            AddHandler LB_Auto_Dual(i).MouseEnter, New System.EventHandler(AddressOf Me.GetFocus)
        Next

    End Sub

    Private Sub AutoArrangeDuty_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        initialize()
    End Sub

    Private Sub GetFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.focus()
    End Sub

    Private Sub GetAlternate()
        Dim str As String
        Dim num As DataTable
        str = "select distinct 学号 from [空闲时间统计] where 周次 % 2 =1 and 周次 > " & NumericUpDown1.Value & " and 周次 < " & NumericUpDown2.Value
        num = gettable("Num_Alternate", str, True)

        Dim week, day, people As Integer
        If NumericUpDown1.Value Mod 2 = 1 Then
            For people = 0 To num.Rows.Count - 1
                For week = NumericUpDown1.Value To NumericUpDown2.Value Step 2
                    str = "select * from [空闲时间统计] where 周次 = " & week & " and 学号='" & num.Rows(people).Item("学号")
                    If myreader.Read Then
                        decode(myreader.Item("信息"))
                    End If


                Next
            Next

        End If
        


    End Sub

    Public Function decode(ByVal num) As Boolean
        formal(6) = num Mod 10
        formal(5) = (num - formal(6)) / 10 Mod 10
        formal(4) = (num - formal(6) - formal(5) * 10) / 100 Mod 10
        formal(3) = (num - formal(6) - formal(5) * 10 - formal(4) * 100) / 1000 Mod 10
        formal(2) = (num - formal(6) - formal(5) * 10 - formal(4) * 100 - formal(3) * 1000) / 10000 Mod 10
        formal(1) = (num - formal(6) - formal(5) * 10 - formal(4) * 100 - formal(3) * 1000 - formal(2) * 10000) / 100000 Mod 10
        formal(0) = (num - formal(6) - formal(5) * 10 - formal(4) * 100 - formal(3) * 1000 - formal(2) * 10000 - formal(1) * 100000) / 1000000 Mod 10
        Return True
    End Function

End Class