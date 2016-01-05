Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class ClearInfo

    Dim Info_Time(6, 19) As Info_Time_Node

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String
        Dim table_num As DataTable
        Dim i, j As Integer
        Dim day As Integer
        Try
            Grade()
            Init_Info_Time()

            str = "select distinct 学号 from [空闲时间统计] where 学期='" & ListBox1.SelectedItem & "'"
            table_num = gettable("num", str, True)

            For i = 0 To table_num.Rows.Count - 1

                If CInt(table_num.Rows(i).Item("学号").Substring(0, 4)) = Grade_To_Num(CheckBox1.Text.ToString, ListBox1.SelectedItem) Then
                    If CheckBox1.Checked = True Then
                        loadinfo(table_num.Rows(i).Item("学号"))
                        For j = NumericUpDown1.Value To NumericUpDown2.Value
                            For day = 0 To 6
                                Info_Time(day, j - 1).setMorning(False)
                                Info_Time(day, j - 1).setAfternoon(False)
                                Info_Time(day, j - 1).setNight(False)
                            Next
                        Next
                        Serialize_Info(table_num.Rows(i).Item("学号"))
                    End If
                End If

                If CInt(table_num.Rows(i).Item("学号").Substring(0, 4)) = Grade_To_Num(CheckBox2.Text.ToString, ListBox1.SelectedItem) Then
                    If CheckBox2.Checked = True Then
                        loadinfo(table_num.Rows(i).Item("学号"))
                        For j = NumericUpDown1.Value To NumericUpDown2.Value
                            For day = 0 To 6
                                Info_Time(day, j - 1).setMorning(False)
                                Info_Time(day, j - 1).setAfternoon(False)
                                Info_Time(day, j - 1).setNight(False)
                            Next
                        Next
                        Serialize_Info(table_num.Rows(i).Item("学号"))
                    End If
                End If

                If CInt(table_num.Rows(i).Item("学号").Substring(0, 4)) = Grade_To_Num(CheckBox3.Text.ToString, ListBox1.SelectedItem) Then
                    If CheckBox3.Checked = True Then
                        loadinfo(table_num.Rows(i).Item("学号"))
                        For j = NumericUpDown1.Value To NumericUpDown2.Value
                            For day = 0 To 6
                                Info_Time(day, j - 1).setMorning(False)
                                Info_Time(day, j - 1).setAfternoon(False)
                                Info_Time(day, j - 1).setNight(False)
                            Next
                        Next
                        Serialize_Info(table_num.Rows(i).Item("学号"))
                    End If
                End If

                If CInt(table_num.Rows(i).Item("学号").Substring(0, 4)) = Grade_To_Num(CheckBox4.Text.ToString, ListBox1.SelectedItem) Then
                    If CheckBox4.Checked = True Then
                        loadinfo(table_num.Rows(i).Item("学号"))
                        For j = NumericUpDown1.Value To NumericUpDown2.Value
                            For day = 0 To 6
                                Info_Time(day, j - 1).setMorning(False)
                                Info_Time(day, j - 1).setAfternoon(False)
                                Info_Time(day, j - 1).setNight(False)
                            Next
                        Next
                        Serialize_Info(table_num.Rows(i).Item("学号"))
                    End If
                End If

                loadinfo(table_num.Rows(i).Item("学号"))
                Dim isEmpty As Boolean = True
                For time = 0 To 2
                    For day = 0 To 6
                        For week = 0 To 19
                            If Info_Time(day, week).getMorning = True OrElse Info_Time(day, week).getAfternoon = True OrElse Info_Time(day, week).getNight = True Then
                                isEmpty = False
                                Exit For
                            End If
                        Next
                        If isEmpty = False Then
                            Exit For
                        End If
                    Next
                    If isEmpty = False Then
                        Exit For
                    End If
                Next

                If isEmpty = True Then
                    str = "if exists(select * from [空闲时间统计] where 学号 = '" & table_num.Rows(i).Item("学号") & "' and 学期='" & schoolcalendar.Substring(0, 5) & "') " & _
                          "begin update [空闲时间统计] set 信息 =NULL where 学号 = '" & table_num.Rows(i).Item("学号") & "' and 学期='" & schoolcalendar.Substring(0, 5) & "' end else " & _
                          "begin select * from [空闲时间统计] where 学号 = '" & table_num.Rows(i).Item("学号") & "' and 学期='" & schoolcalendar.Substring(0, 5) & "' end"
                    Try
                        sql(str, True)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Close()
                        conn.Dispose()
                    End Try
                End If
            Next

            MsgBox("清除成功")
        Catch ex As Exception
            MsgBox("清除失败，请重试")
        End Try
    End Sub

    Private Sub Serialize_Info(ByVal numtemp As String)

        Dim formatter As New BinaryFormatter
        Dim rems As MemoryStream = New MemoryStream()
        formatter.Serialize(rems, Info_Time)
        rems.Position = 0
        Dim descBytes(rems.Length) As Byte

        rems.Read(descBytes, 0, descBytes.Length)
        rems.Flush()
        rems.Close()

        Dim result As String = Convert.ToBase64String(descBytes)

        rems.Close()

        Dim str As String = "update [空闲时间统计] set 信息 ='" & result & "' where 学号 = '" & numtemp & "' and 学期='" & schoolcalendar.Substring(0, 5) & "'"

        Try
            sql(str, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub Grade()
        Dim str As String = String.Empty
        Dim str_grade As String = String.Empty
        Dim num_table As DataTable
        Dim grade As Integer
        Dim i As Integer

        Try
            str = "select distinct 学号 from [member]"
            num_table = gettable("num_table", str, True)

            For i = 0 To num_table.Rows.Count - 1
                If num_table.Rows(i).Item("学号").ToString.Count = 9 Then
                    grade = CInt(Now.Year.ToString) - CInt(num_table.Rows(i).Item("学号").ToString().Substring(0, 4))
                    If Now.Month >= 8 Then
                        If grade = 0 Then
                            str_grade = "大一"
                        ElseIf grade = 1 Then
                            str_grade = "大二"
                        ElseIf grade = 2 Then
                            str_grade = "大三"
                        ElseIf grade = 3 Then
                            str_grade = "大四"
                        ElseIf grade > 3 Then
                            str_grade = "往届"
                        End If
                    Else
                        If grade = 1 Then
                            str_grade = "大一"
                        ElseIf grade = 2 Then
                            str_grade = "大二"
                        ElseIf grade = 3 Then
                            str_grade = "大三"
                        ElseIf grade = 4 Then
                            str_grade = "大四"
                        ElseIf grade > 4 Then
                            str_grade = "往届"
                        End If
                    End If
                    str = "update [member] set 年级='" & str_grade & "' where 学号='" & num_table.Rows(i).Item("学号").ToString() & "'"
                    sql(str, True)
                    conn.Close()
                End If
            Next
            num_table.Dispose()
        Catch ex As Exception
        End Try

    End Sub

    Private Function Grade_To_Num(ByVal str As String, ByVal xueqi As String) As Integer

        If xueqi.Substring(4, 1) = "秋" Then

            If str = "大一" Then
                Return CInt(xueqi.Substring(0, 4))
            ElseIf str = "大二" Then
                Return CInt(xueqi.Substring(0, 4)) - 1
            ElseIf str = "大三" Then
                Return CInt(xueqi.Substring(0, 4)) - 2
            ElseIf str = "大四" Then
                Return CInt(xueqi.Substring(0, 4)) - 3
            End If

        Else

            If str = "大一" Then
                Return CInt(xueqi.Substring(0, 4)) - 1
            ElseIf str = "大二" Then
                Return CInt(xueqi.Substring(0, 4)) - 2
            ElseIf str = "大三" Then
                Return CInt(xueqi.Substring(0, 4)) - 3
            ElseIf str = "大四" Then
                Return CInt(xueqi.Substring(0, 4)) - 4
            End If

        End If

    End Function


#Region "窗体事件"

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ClearInfo_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        List()
    End Sub

    Private Sub List()
        Dim str As String
        ListBox1.Items.Clear()
        str = "select distinct 学期 from [空闲时间统计]"
        sql(str, True)
        While myreader.Read
            ListBox1.Items.Add(myreader.Item("学期"))
        End While
        conn.Close()
        If ListBox1.Items.Count > 0 Then
            ListBox1.SetSelected(0, True)
        End If
    End Sub

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

#End Region

    Private Sub Init_Info_Time()
        Dim day As Integer = 0
        Dim week As Integer = 0

        For day = 0 To 6
            For week = 0 To 19
                Info_Time(day, week) = New Info_Time_Node(False, False, False)
            Next
        Next
    End Sub

    Private Sub loadinfo(ByVal numtemp As String)

        Dim day As Integer = 0
        Dim week As Integer = 0

        For day = 0 To 6
            For week = 0 To 19
                Info_Time(day, week).setMorning(False)
                Info_Time(day, week).setAfternoon(False)
                Info_Time(day, week).setNight(False)
            Next
        Next

        Dim str As String = "select 信息 from [空闲时间统计] where 学号 = '" & numtemp & "' and 学期='" & schoolcalendar.Substring(0, 5) & "'"
        Try
            sql(str, True)
            If myreader.Read Then
                If myreader.Item(0).ToString = "" Then
                    Exit Try
                End If
                Dim formatter As IFormatter = New BinaryFormatter()
                Dim buffer() As Byte = Convert.FromBase64String(myreader.Item(0).ToString)
                Dim stream As MemoryStream = New MemoryStream(buffer)
                Info_Time = formatter.Deserialize(stream)
                stream.Flush()
                stream.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

End Class