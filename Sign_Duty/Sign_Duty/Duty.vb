Imports System.Net
Imports System.Environment
Imports System.Drawing
Public Class Duty

    Public NowTime As Date         '当前时间，需要时时更新，所以不给初始值

    Private Sub Duty_Panel_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Duty_Panel.HandleCreated
        NowWeek = GetWeek()
        Label3.Text = String.Empty
        Label2.Text = String.Empty
        Display()
        Timer1.Interval = 5000
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Display()

    End Sub

    Private Sub Display()
        Dim Status As String = String.Empty
        Dim ImgPerson As String = "Default"

        NowTime = ServerTime()
        If NowTime <= New Date(NowTime.Year, NowTime.Month, NowTime.Day, 12, 15, 0) Then
            Status = "上午"
        ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 12, 15, 0) AndAlso NowTime < New Date(NowTime.Year, NowTime.Month, NowTime.Day, 17, 15, 0) Then
            Status = "下午"
        ElseIf NowTime > New Date(NowTime.Year, NowTime.Month, NowTime.Day, 17, 15, 0) Then
            Status = "晚上"
        End If

        Dim str As String
        str = "select * from [duty] where 时段='" & Status & "' and 单双周='" & 单双周() & "' and 星期=datepart(weekday,getdate())-1"
        sql(str)
        If myreader.Read Then
            Label3.Text = "当前应为" & myreader.Item("姓名") & "值班"
        End If
        conn.Close()
        conn.Dispose()

        str = "select * from [sduty] where 时段='" & Status & "' and 日期='" & NowTime.ToShortDateString & "' and 登离时间='0'"
        sql(str)
        If myreader.Read Then
            If myreader.Item("是否替班").ToString = "True" Then
                Label2.Text = "当前为" & myreader.Item("替班人姓名").ToString & "值班"
                ImgPerson = myreader.Item("替班人姓名").ToString
            Else
                Label2.Text = "当前为" & myreader.Item("姓名").ToString & "值班"
                ImgPerson = myreader.Item("姓名").ToString
            End If

            Dim path As String = System.Environment.CurrentDirectory + "\\img"

            If Not My.Computer.FileSystem.FileExists(path + "\\" + ImgPerson + ".jpg") Then
                Try
                    My.Computer.Network.DownloadFile("\\192.168.1.5\\upload\\安装文件\\照片\\" + ImgPerson + ".jpg", path + "\\" + ImgPerson + ".jpg", "elab", "elab", False, 2000, True)
                Catch ex As Exception
                    'MsgBox("error")
                End Try

            End If

            PictureBox1.Image = Image.FromFile(path + "\\" + ImgPerson + ".jpg")
            PictureBox1.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage

        Else
            Label2.Text = "当前无人值班"
        End If
        conn.Close()
        conn.Dispose()

    End Sub

End Class
