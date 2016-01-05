Public Class SheetOut

    Dim head(6) As Integer
    Dim test As Integer = 1
    Public kongxian(20) As Integer
    Public jishu As Integer = 0
    Public formal(6) As Integer

    Public Structure Arrangement     'ֵ������ΰ�������  
        Dim num As Integer
        Dim info As Integer
    End Structure

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            MsgBox("����������Χ")
            Exit Sub
        End If

        Dim i, j, z As Integer
        Dim str, strname(2) As String

        exapp = New Microsoft.Office.Interop.Excel.Application '����excelӦ�ó���
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        For j = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
            exbook.Sheets.Add()
            exsheet = exbook.Sheets(1)
            exsheet.Name = j + 1
            exsheet.Range("a1:i2").WrapText = True
            printe(2, 1, "����")
            printe(1, 2, "��һ")
            printe(1, 3, "�ܶ�")
            printe(1, 4, "����")
            printe(1, 5, "����")
            printe(1, 6, "����")
            printe(1, 7, "����")
            printe(1, 8, "����")

            For i = 0 To 6
                str = "select distinct * from [����ʱ��ͳ��] where �ܴ�='" & j + 1 & "' and ��Ϣ<>0 and ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
                sql(str, True)

                strname(1) = ""

                While myreader.Read
                    decode(myreader.Item("��Ϣ"))
                    For z = 0 To 6
                        head(z) = formal(z)
                    Next
                    If head(i) = 1 Then

                    ElseIf head(i) = 2 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 3 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 4 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 5 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 6 Then

                    ElseIf head(i) = 7 Then

                    End If
                End While
                printe(2, i + 2, Trim(strname(1)))
                conn.Close()
            Next
        Next
        exsto("d:\���ο���ʱ��������ֹ�������.xlsx")
    End Sub
    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            MsgBox("����������Χ")
            Exit Sub
        End If

        Dim i, p, q, m As Integer

        Dim doubi(5, 6) As Integer
        Dim str, strname(5, 6), shabi(100) As String
        Dim sb, sb2 As DataTable

        exapp = New Microsoft.Office.Interop.Excel.Application '����excelӦ�ó���
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        exbook.Sheets.Add()
        exsheet = exbook.Sheets(1)
        exsheet.Name = "����ʱ��"
        exsheet.Range("a1:i9").WrapText = True
        exsheet.Range("a1:i1").Merge()
        exsheet.Range("a3:a5").Merge()
        exsheet.Range("a7:a9").Merge()
        printe(1, 1, "����ʱ��")
        printe(3, 1, "����")
        printe(7, 1, "˫��")
        printe(3, 2, "����")
        printe(4, 2, "����")
        printe(5, 2, "����")
        printe(7, 2, "����")
        printe(8, 2, "����")
        printe(9, 2, "����")
        printe(2, 3, "��һ")
        printe(2, 4, "�ܶ�")
        printe(2, 5, "����")
        printe(2, 6, "����")
        printe(2, 7, "����")
        printe(2, 8, "����")
        printe(2, 9, "����")
        str = "select distinct ѧ�� from [����ʱ��ͳ��] where ��Ϣ<>0 and ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
        sb = gettable("sb", str, True)
        For p = 0 To 5
            For q = 0 To 6
                strname(p, q) = ""
            Next
        Next
        For m = 0 To sb.Rows.Count - 1
            str = "select distinct * from [����ʱ��ͳ��] where ѧ��='" & sb.Rows(m).Item("ѧ��") & "' and ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
            sql(str, True)
            If myreader.Read Then

                For p = 0 To 5
                    For q = 0 To 6
                        doubi(p, q) = 1
                    Next
                Next

                For i = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
                    str = "select * from [����ʱ��ͳ��] where ѧ��='" & sb.Rows(m).Item("ѧ��") & "' and �ܴ�=" & i + 1 & " and ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
                    sb2 = gettable("sb", str, True)
                    If i Mod 2 = 1 Then
                        p = 3
                    Else
                        p = 0
                    End If
                    If sb2.Rows.Count = 0 Then
                        test = 0
                    Else
                        decode(sb2.Rows(0).Item("��Ϣ"))
                        test = 1
                    End If

                    For q = 0 To 6
                        If (formal(q) Mod 2 = 0 Or test = 0) Then
                            doubi(p + 0, q) *= 0
                        End If
                        If (formal(q) < 2 Or formal(q) > 5 Or test = 0) Then
                            doubi(p + 1, q) *= 0
                        End If
                        If (formal(q) < 4 Or test = 0) Then
                            doubi(p + 2, q) *= 0
                        End If
                    Next
                Next

                For p = 0 To 5
                    For q = 0 To 6
                        If doubi(p, q) = 1 Then
                            strname(p, q) &= myreader.Item("����") & " "
                        End If
                    Next
                Next
            End If
            conn.Close()
        Next

        For p = 0 To 2
            For q = 0 To 6
                printe(p + 3, q + 3, strname(p, q))
            Next
        Next
        For p = 3 To 5
            For q = 0 To 6
                printe(p + 4, q + 3, strname(p, q))
            Next
        Next

        exsto("d:\ֵ�����ʱ�����.xlsx")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            MsgBox("����������Χ")
            Exit Sub
        End If

        Dim i, j, z As Integer
        Dim str, strname(2) As String

        exapp = New Microsoft.Office.Interop.Excel.Application '����excelӦ�ó���
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        exbook.Sheets.Add()
        exsheet = exbook.Sheets(1)
        For j = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
            exsheet.Range("a1:i80").WrapText = True
            exsheet.Range("a" & 1 + j * 4 & ":h" & 1 + j * 4).Merge()
            printe(1 + j * 4, 1, "��" & j + 1 & "�ܿ���ʱ��")
            printe(3 + j * 4, 1, "����")
            printe(2 + j * 4, 2, "��һ")
            printe(2 + j * 4, 3, "�ܶ�")
            printe(2 + j * 4, 4, "����")
            printe(2 + j * 4, 5, "����")
            printe(2 + j * 4, 6, "����")
            printe(2 + j * 4, 7, "����")
            printe(2 + j * 4, 8, "����")
            For i = 0 To 6
                str = "select distinct * from [����ʱ��ͳ��] where �ܴ�='" & j + 1 & "' and ��Ϣ<>0 and ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
                sql(str, True)
                strname(1) = ""
                While myreader.Read
                    decode(myreader.Item("��Ϣ"))
                    For z = 0 To 6
                        head(z) = formal(z)
                    Next
                    If head(i) = 1 Then

                    ElseIf head(i) = 2 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 3 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 4 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 5 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 6 Then
                    ElseIf head(i) = 7 Then
                    End If
                End While
                printe(3 + j * 4, i + 2, Trim(strname(1)))
                conn.Close()
            Next
        Next
        exsto("d:\���ο���ʱ����������ֹ�������.xlsx")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            MsgBox("����������Χ")
            Exit Sub
        End If

        Dim i, j, z As Integer
        Dim str, strname(2) As String

        exapp = New Microsoft.Office.Interop.Excel.Application '����excelӦ�ó���
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        For j = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
            exbook.Sheets.Add()
            exsheet = exbook.Sheets(1)
            exsheet.Name = j + 1
            exsheet.Range("a1:i4").WrapText = True
            printe(2, 1, "����")
            printe(3, 1, "����")
            printe(4, 1, "����")
            printe(1, 2, "��һ")
            printe(1, 3, "�ܶ�")
            printe(1, 4, "����")
            printe(1, 5, "����")
            printe(1, 6, "����")
            printe(1, 7, "����")
            printe(1, 8, "����")

            For i = 0 To 6
                str = "select distinct * from [����ʱ��ͳ��] where �ܴ�='" & j + 1 & "' and ��Ϣ<>0 and ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
                sql(str, True)
                strname(0) = ""
                strname(1) = ""
                strname(2) = ""
                While myreader.Read
                    decode(myreader.Item("��Ϣ"))
                    For z = 0 To 6
                        head(z) = formal(z)
                    Next
                    If head(i) = 1 Then
                        strname(0) &= myreader.Item("����") & " "
                    ElseIf head(i) = 2 Then
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 3 Then
                        strname(0) &= myreader.Item("����") & " "
                        strname(1) &= myreader.Item("����") & " "
                    ElseIf head(i) = 4 Then
                        strname(1) &= myreader.Item("����") & " "
                        strname(2) &= myreader.Item("����") & " "
                    ElseIf head(i) = 5 Then
                        strname(0) &= myreader.Item("����") & " "
                        strname(1) &= myreader.Item("����") & " "
                        strname(2) &= myreader.Item("����") & " "
                    ElseIf head(i) = 6 Then
                        strname(2) &= myreader.Item("����") & " "
                    ElseIf head(i) = 7 Then
                        strname(0) &= myreader.Item("����") & " "
                        strname(2) &= myreader.Item("����") & " "
                    End If
                End While
                printe(2, i + 2, Trim(strname(0)))
                printe(3, i + 2, Trim(strname(1)))
                printe(4, i + 2, Trim(strname(2)))
                conn.Close()
            Next
        Next
        exsto("d:\�ܿ���ʱ�����.xlsx")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim i, j, k, up, down As Integer
        Dim str As String

        str = "select count(distinct ѧ��) from [����ʱ��ͳ��] where ��Ϣ<>0 and ѧ��='" & schoolcalendar.Substring(0, 5) & "'"
        sql(str, True)
        If myreader.Read Then
            k = myreader.Item(0)
        End If

        Dim arrangement((NumericUpDown2.Value - NumericUpDown1.Value + 1) * 21 * k - 1) As Arrangement
        '��̬����ṹ��������kΪ�����ݿ����ܹ��ж����ˣ�һ��������ʱ��Ϊ21��ʱ���


        '*******************������************************
        exapp = New Microsoft.Office.Interop.Excel.Application '����excelӦ�ó���
        exapp.Visible = True
        exbook = exapp.Workbooks.Add()
        exbook.Sheets.Add()
        exsheet = exbook.Sheets(1)
        '*******************������************************


        up = 0
        Try
            For j = NumericUpDown1.Value - 1 To NumericUpDown2.Value - 1
                str = "select * from [����ʱ��ͳ��] where �ܴ�='" & j + 1 & "' and ��Ϣ<>0"
                sql(str, True)
                While myreader.Read
                    Transcoding(myreader.Item("��Ϣ"))
                    down = up + jishu - 1
                    For i = up To down
                        arrangement(i).num = myreader.Item("ѧ��")
                        arrangement(i).info = kongxian(i - up) + (j - NumericUpDown1.Value + 1) * 21
                    Next
                    up = down + 1
                End While
                conn.Close()
            Next



            '*******************������************************
            For i = 0 To down
                printe(i + 1, 1, arrangement(i).num)
                printe(i + 1, 2, arrangement(i).info)
            Next
            exsto("d:\��.xlsx")
            '*******************������************************



        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

    End Sub

    Private Function Transcoding(ByVal info As String)    '�����ݿ��д���Ĺ��ڿ�����Ϣ�ı�������ת����Զ��Ű��������ı���
        Dim i, z As Integer
        Dim flag(21) As Boolean


        '****************************�����ʱ����********************************
        For i = 0 To 20
            flag(i) = False
            kongxian(i) = 0
        Next
        jishu = 0
        '****************************�����ʱ����********************************

        '****************************����********************************
        decode(info)
        For z = 0 To 6
            head(z) = formal(z)
        Next
        '****************************����********************************

        '****************************���뼰���±���********************************
        For i = 0 To 6
            If head(i) = 1 Then

                flag(3 * i) = True
            ElseIf head(i) = 2 Then
                flag(3 * i + 1) = True
            ElseIf head(i) = 3 Then
                flag(3 * i) = True
                flag(3 * i + 1) = True
            ElseIf head(i) = 4 Then
                flag(3 * i + 1) = True
                flag(3 * i + 2) = True
            ElseIf head(i) = 5 Then
                flag(3 * i) = True
                flag(3 * i + 1) = True
                flag(3 * i + 2) = True
            ElseIf head(i) = 6 Then
                flag(3 * i + 2) = True
            ElseIf head(i) = 7 Then
                flag(3 * i) = True
                flag(3 * i + 2) = True
            End If
        Next

        For i = 0 To 20
            If flag(i) = True Then
                kongxian(jishu) = i + 1
                jishu += 1
            End If
        Next
        '****************************���뼰���±���********************************

        Return 0
    End Function

End Class