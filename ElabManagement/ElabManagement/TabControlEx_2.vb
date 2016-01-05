Public Class TabControlEx_2

    Inherits System.Windows.Forms.TabControl
    Dim backImage As Image

    Sub New() '构造,加入变量s 可要求强行赋值
        '初始化
        MyBase.New()                                                          '注意：这句话要放在sub内的第一句,基类带参数时要标明
        Try
            MyBase.SetStyle(ControlStyles.UserPaint, True)                        '控件将自行绘制，而不是通过操作系统来绘制
            MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)            '该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁
            MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)             '控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁
            MyBase.SetStyle(ControlStyles.ResizeRedraw, True)                     '在调整控件大小时重绘控件
            MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)     '控件接受 alpha 组件小于 255 的 BackColor 以模拟透明
            MyBase.UpdateStyles()

            MyBase.SizeMode = TabSizeMode.Fixed  '大小模式为固定
            MyBase.ItemSize = New Size(40, 170)
            backImage = New Bitmap(My.Resources.TabBackground)
        Catch ex As Exception

        End Try
    End Sub
    Protected Overrides Sub Finalize() '析构
        '收尾
        MyBase.Finalize()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Try
            Dim i As Integer = 0
            e.Graphics.DrawImage(My.Resources.middle, MyBase.ClientRectangle)

            For i = 0 To MyBase.TabCount - 1

                'e.Graphics.DrawRectangle(Pens.Red, MyBase.GetTabRect(i))
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias   '文字抗锯齿

                If (MyBase.SelectedIndex = i) Then
                    e.Graphics.DrawImage(backImage, MyBase.GetTabRect(i))
                End If

                'Calculate text position
                Dim bounds As Rectangle = MyBase.GetTabRect(i)
                Dim textPoint As PointF = New PointF()
                Dim new_font As Font = New Font("黑体", 20, FontStyle.Bold, GraphicsUnit.Pixel)
                Dim textSize As SizeF = TextRenderer.MeasureText(MyBase.TabPages(i).Text, new_font)
                '注意要加上每个标签的左偏移量X
                textPoint.X = bounds.X + (bounds.Width - textSize.Width) / 2
                textPoint.Y = bounds.Bottom - textSize.Height - 7

                'Draw highlights
                e.Graphics.DrawString(MyBase.TabPages(i).Text, new_font, SystemBrushes.ControlLightLight, textPoint.X, textPoint.Y)   '高光颜色

                '绘制正常文字
                textPoint.Y = textPoint.Y - 2
                e.Graphics.DrawString(MyBase.TabPages(i).Text, new_font, SystemBrushes.ControlText, textPoint.X, textPoint.Y)  '正常颜色

            Next
        Catch ex As Exception
            ex.ToString()
        End Try
        
    End Sub


    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)
    End Sub

End Class
