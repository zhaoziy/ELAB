Imports System.Net
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Threading
Imports System.Net.Sockets
Imports System.Text

Public Class Computer_Remote

    Public udp1 As New UdpClient(11001)
    Public GroupAddress(10, 5) As IPAddress  '远程控制，udp协议相关

    Dim str_address(10, 5) As String
    Dim image_list(10, 5) As PictureBox
    Private CB(10, 5) As CheckBox
    Dim thread1, thread2, thread3, thread4, thread5, thread6 As Thread
    Dim LocalIP As Integer = 0
    Dim ToolTip1 As New ToolTip

    Private Sub Computer_Remote_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Computer_Remote_Panel.HandleCreated

        initialize()

    End Sub

#Region "初始化"

    Private Sub initialize()

        'checkip()
        Dim local As Array
        local = localIPv4.Split(".")
        If local.Length = 4 And Val(local(2)) = 1 Then
            LocalIP = Val(local(3))
        End If

        Dim str As String = "select * from [IP_MAC] where USERNAME='学生_外屋' or USERNAME='学生_里屋'"
        Dim table As DataTable
        table = gettable("IP_MAC", str, True)

        Dim COUNT, Col, Row As Integer
        For COUNT = 0 To table.Rows.Count - 1
            If table.Rows(COUNT).Item("USERNAME") = "学生_外屋" Then
                Col = Val(table.Rows(COUNT).Item("IP")) Mod 10
                Row = (Val(table.Rows(COUNT).Item("IP")) - Col) / 10
                str_address(Row - 1, Col - 1) = table.Rows(COUNT).Item("IP")
            ElseIf table.Rows(COUNT).Item("USERNAME") = "学生_里屋" Then
                Col = Val(table.Rows(COUNT).Item("IP")) Mod 10
                Row = (Val(table.Rows(COUNT).Item("IP")) - Col) / 10
                str_address(Row - 5, Col - 1) = table.Rows(COUNT).Item("IP")
            End If
        Next
        table.Dispose()

        Dim Width As Integer = PB_Standard1.Width
        Dim Height As Integer = PB_Standard1.Height
        PB_Standard1.Visible = False
        PB_Standard1.Enabled = False
        PB_Standard2.Visible = False
        PB_Standard2.Enabled = False
        CB_Standard1.Visible = False
        CB_Standard1.Enabled = False
        CB_Standard2.Visible = False
        CB_Standard2.Enabled = False
        For Row = 0 To 5
            For Col = 0 To 5
                image_list(Row, Col) = New PictureBox
                image_list(Row, Col).Height = Height
                image_list(Row, Col).Width = Width
                image_list(Row, Col).Top = PB_Standard1.Top + Row * Height * 1.5
                image_list(Row, Col).Left = PB_Standard1.Left + Col * Width * 1.5
                image_list(Row, Col).BackgroundImage = My.Resources.close
                image_list(Row, Col).BackgroundImageLayout = ImageLayout.Stretch
                image_list(Row, Col).TabIndex = 100 + Row * 10 + Col
                image_list(Row, Col).Cursor = Cursors.Hand
                Outter.Controls.Add(image_list(Row, Col))
                AddHandler image_list(Row, Col).Click, New System.EventHandler(AddressOf Me.image_click)
                AddHandler image_list(Row, Col).MouseEnter, New System.EventHandler(AddressOf Me.image_MouseEnter)

                CB(Row, Col) = New CheckBox
                CB(Row, Col).AutoSize = True
                CB(Row, Col).Top = CB_Standard1.Top + Row * Height * 1.5
                CB(Row, Col).Left = CB_Standard1.Left + Col * Width * 1.5
                CB(Row, Col).TextAlign = ContentAlignment.MiddleCenter
                CB(Row, Col).Text = str_address(Row, Col)
                CB(Row, Col).TabIndex = 300 + Row * 10 + Col
                CB(Row, Col).Cursor = Cursors.Hand
                Outter.Controls.Add(CB(Row, Col))
                AddHandler CB(Row, Col).MouseEnter, New System.EventHandler(AddressOf Me.image_MouseEnter)

            Next
        Next
        For Row = 6 To 10
            For Col = 0 To 5
                image_list(Row, Col) = New PictureBox
                image_list(Row, Col).Height = Height
                image_list(Row, Col).Width = Width
                image_list(Row, Col).Top = PB_Standard2.Top + (Row - 6) * Height * 1.5
                image_list(Row, Col).Left = PB_Standard2.Left + Col * Width * 1.5
                image_list(Row, Col).BackgroundImage = My.Resources.close
                image_list(Row, Col).BackgroundImageLayout = ImageLayout.Stretch
                image_list(Row, Col).TabIndex = 100 + Row * 10 + Col
                image_list(Row, Col).Cursor = Cursors.Hand
                Inner.Controls.Add(image_list(Row, Col))
                AddHandler image_list(Row, Col).Click, New System.EventHandler(AddressOf Me.image_click)
                AddHandler image_list(Row, Col).MouseEnter, New System.EventHandler(AddressOf Me.image_MouseEnter)

                CB(Row, Col) = New CheckBox
                CB(Row, Col).AutoSize = True
                CB(Row, Col).Top = CB_Standard2.Top + (Row - 6) * Height * 1.5
                CB(Row, Col).Left = CB_Standard2.Left + Col * Width * 1.5
                CB(Row, Col).TextAlign = ContentAlignment.MiddleCenter
                CB(Row, Col).Text = str_address(Row, Col)
                CB(Row, Col).TabIndex = 300 + Row * 10 + Col
                CB(Row, Col).Cursor = Cursors.Hand
                Inner.Controls.Add(CB(Row, Col))
                AddHandler CB(Row, Col).MouseEnter, New System.EventHandler(AddressOf Me.image_MouseEnter)
            Next
        Next
        For Row = 0 To 10
            For Col = 0 To 5
                GroupAddress(Row, Col) = IPAddress.Parse("192.168.1." & str_address(Row, Col))
            Next
        Next

        If authority = 0 Then
            BT_Close.Enabled = False
            BT_Close.Visible = False
            BT_Logoff.Enabled = False
            BT_Logoff.Visible = False
            BT_Restart.Enabled = False
            BT_Restart.Visible = False
        End If

        thread1 = New Thread(New ThreadStart(AddressOf check_open_1))
        thread1.Start()
        thread2 = New Thread(New ThreadStart(AddressOf check_open_2))
        thread2.Start()
        thread3 = New Thread(New ThreadStart(AddressOf check_open_3))
        thread3.Start()
        thread4 = New Thread(New ThreadStart(AddressOf check_open_4))
        thread4.Start()
        thread5 = New Thread(New ThreadStart(AddressOf check_open_5))
        thread5.Start()
        thread6 = New Thread(New ThreadStart(AddressOf check_open_6))
        thread6.Start()

    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        Panel1.Focus()
    End Sub

    Private Sub Outter_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Outter.MouseEnter
        Panel1.Focus()
    End Sub

    Private Sub Inner_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Inner.MouseEnter
        Panel1.Focus()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim Col, Row As Integer
        If CheckBox1.Checked = True Then
            For Row = 0 To 5
                For Col = 0 To 5
                    CB(Row, Col).Checked = True
                Next
            Next
        Else
            For Row = 0 To 5
                For Col = 0 To 5
                    CB(Row, Col).Checked = False
                Next
            Next
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim Col, Row As Integer
        If CheckBox2.Checked = True Then
            For Row = 6 To 10
                For Col = 0 To 5
                    CB(Row, Col).Checked = True
                Next
            Next
        Else
            For Row = 6 To 10
                For Col = 0 To 5
                    CB(Row, Col).Checked = False
                Next
            Next
        End If
    End Sub

    Private Sub image_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim row, col As Integer
        col = sender.TabIndex Mod 10
        row = (sender.TabIndex - col - 100) / 10
        If CB(row, col).Checked = False Then
            CB(row, col).Checked = True
        Else
            CB(row, col).Checked = False
        End If
    End Sub

    Private Sub image_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim row, col As Integer
            If sender.tabindex >= 100 And sender.tabindex <= 300 Then
                col = Val(sender.tabindex) Mod 10
                row = (Val(sender.tabindex) - col - 100) / 10
            ElseIf sender.tabindex >= 300 Then
                col = Val(sender.tabindex) Mod 10
                row = (Val(sender.tabindex) - col - 300) / 10
            End If

            Dim str As String
            Dim name As String = ""
            Dim num As String = ""
            str = "select * from [IP_MAC] where IP='" & str_address(row, col) & "'"
            Try
                sql(str, True)
                If myreader.Read Then
                    num = myreader.Item("NUM")
                    str = "select 姓名 from [member] where 学号='" & num & "'"
                    sql(str, True)
                    If myreader.Read Then
                        name = myreader.Item("姓名")
                    End If
                End If
                conn.Close()
            Catch ex As Exception
                'ex.ToString()
                conn.Close()
            End Try
            If num <> "" And name <> "" Then
                ToolTip1.SetToolTip(sender, num & vbCrLf & name)
            End If
        Catch ex As Exception
            'ex.ToString()
        End Try
    End Sub

#End Region

#Region "扫描计算机开机状态"

    Private Sub check_open_1()
        Try
            Dim Col, Row As Integer
            For Row = 0 To 1
                For Col = 0 To 5
                    If My.Computer.Network.Ping("192.168.1." & str_address(Row, Col), 30) = True Then
                        image_list(Row, Col).BackgroundImage = My.Resources.open
                    Else
                        image_list(Row, Col).BackgroundImage = My.Resources.close
                    End If
                Next
            Next
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub check_open_2()
        Try
            Dim Col, Row As Integer
            For Row = 2 To 3
                For Col = 0 To 5
                    If My.Computer.Network.Ping("192.168.1." & str_address(Row, Col), 30) = True Then
                        image_list(Row, Col).BackgroundImage = My.Resources.open
                    Else
                        image_list(Row, Col).BackgroundImage = My.Resources.close
                    End If
                Next
            Next
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub check_open_3()
        Try
            Dim Col, Row As Integer
            For Row = 4 To 5
                For Col = 0 To 5
                    If My.Computer.Network.Ping("192.168.1." & str_address(Row, Col), 30) = True Then
                        image_list(Row, Col).BackgroundImage = My.Resources.open
                    Else
                        image_list(Row, Col).BackgroundImage = My.Resources.close
                    End If
                Next
            Next
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub check_open_4()
        Try
            Dim Col, Row As Integer
            For Row = 6 To 7
                For Col = 0 To 5
                    If My.Computer.Network.Ping("192.168.1." & str_address(Row, Col), 30) = True Then
                        image_list(Row, Col).BackgroundImage = My.Resources.open
                    Else
                        image_list(Row, Col).BackgroundImage = My.Resources.close
                    End If
                Next
            Next
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub check_open_5()
        Try
            Dim Col, Row As Integer
            For Row = 8 To 9
                For Col = 0 To 5
                    If My.Computer.Network.Ping("192.168.1." & str_address(Row, Col), 30) = True Then
                        image_list(Row, Col).BackgroundImage = My.Resources.open
                    Else
                        image_list(Row, Col).BackgroundImage = My.Resources.close
                    End If
                Next
            Next
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub check_open_6()
        Try
            Dim Col, Row As Integer
            Row = 10
            For Col = 0 To 5
                If My.Computer.Network.Ping("192.168.1." & str_address(Row, Col), 30) = True Then
                    image_list(Row, Col).BackgroundImage = My.Resources.open
                Else
                    image_list(Row, Col).BackgroundImage = My.Resources.close
                End If
            Next
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

#End Region

#Region "远程控制"

    Private Sub BT_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Start.Click
        Try
            If MsgBox("确认唤醒？", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Dim row, col As Integer
                For row = 0 To 10
                    For col = 0 To 5
                        If CB(row, col).Checked = True And Val(CB(row, col).Text) <> LocalIP Then
                            WakeUp(str_address(row, col))
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BT_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        If MsgBox("确认关机？", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim bytes As Byte() = Encoding.Unicode.GetBytes("gj")
            Dim row, col As Integer
            For row = 0 To 10
                For col = 0 To 5
                    If CB(row, col).Checked = True And Val(CB(row, col).Text) <> LocalIP Then
                        Dim EndPoint As New IPEndPoint(GroupAddress(row, col), 11000)
                        udp1.Send(bytes, bytes.Length, EndPoint)
                        Dim EndPoint1 As New IPEndPoint(GroupAddress(row, col), 11002)
                        udp1.Send(bytes, bytes.Length, EndPoint1)
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub BT_Restart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Restart.Click
        If MsgBox("确认重启？", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim bytes As Byte() = Encoding.Unicode.GetBytes("cq")
            Dim row, col As Integer
            For row = 0 To 10
                For col = 0 To 5
                    If CB(row, col).Checked = True And Val(CB(row, col).Text) <> LocalIP Then
                        Dim EndPoint As New IPEndPoint(GroupAddress(row, col), 11000)
                        udp1.Send(bytes, bytes.Length, EndPoint)
                        Dim EndPoint1 As New IPEndPoint(GroupAddress(row, col), 11002)
                        udp1.Send(bytes, bytes.Length, EndPoint1)
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub BT_Logoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Logoff.Click
        If MsgBox("确认注销？", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim bytes As Byte() = Encoding.Unicode.GetBytes("zx")
            Dim row, col As Integer
            For row = 0 To 10
                For col = 0 To 5
                    If CB(row, col).Checked = True And Val(CB(row, col).Text) <> LocalIP Then
                        Dim EndPoint As New IPEndPoint(GroupAddress(row, col), 11000)
                        udp1.Send(bytes, bytes.Length, EndPoint)
                        Dim EndPoint1 As New IPEndPoint(GroupAddress(row, col), 11002)
                        udp1.Send(bytes, bytes.Length, EndPoint1)
                    End If
                Next
            Next
        End If
    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IP_MAC.Click
        Dim ip_mac As New IP_MAC
        ip_mac.ShowDialog()
        ip_mac.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        check()
    End Sub

    Private Sub check()
        If thread1.IsAlive = False Then
            thread1 = New Thread(New ThreadStart(AddressOf check_open_1))
            thread1.Start()
        End If
        If thread2.IsAlive = False Then
            thread2 = New Thread(New ThreadStart(AddressOf check_open_2))
            thread2.Start()
        End If
        If thread3.IsAlive = False Then
            thread3 = New Thread(New ThreadStart(AddressOf check_open_3))
            thread3.Start()
        End If
        If thread4.IsAlive = False Then
            thread4 = New Thread(New ThreadStart(AddressOf check_open_4))
            thread4.Start()
        End If
        If thread5.IsAlive = False Then
            thread5 = New Thread(New ThreadStart(AddressOf check_open_5))
            thread5.Start()
        End If
        If thread6.IsAlive = False Then
            thread6 = New Thread(New ThreadStart(AddressOf check_open_6))
            thread6.Start()
        End If
    End Sub

End Class