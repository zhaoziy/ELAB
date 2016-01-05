<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TA_Frame
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TA_TBE = New ElabManagement.TabControlEx_2
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.TA_TBE.SuspendLayout()
        Me.SuspendLayout()
        '
        'TA_TBE
        '
        Me.TA_TBE.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TA_TBE.Controls.Add(Me.TabPage1)
        Me.TA_TBE.Controls.Add(Me.TabPage2)
        Me.TA_TBE.Controls.Add(Me.TabPage3)
        Me.TA_TBE.Controls.Add(Me.TabPage4)
        Me.TA_TBE.Controls.Add(Me.TabPage5)
        Me.TA_TBE.Controls.Add(Me.TabPage6)
        Me.TA_TBE.Controls.Add(Me.TabPage7)
        Me.TA_TBE.ItemSize = New System.Drawing.Size(40, 170)
        Me.TA_TBE.Location = New System.Drawing.Point(0, 0)
        Me.TA_TBE.Margin = New System.Windows.Forms.Padding(0)
        Me.TA_TBE.Multiline = True
        Me.TA_TBE.Name = "TA_TBE"
        Me.TA_TBE.Padding = New System.Drawing.Point(0, 0)
        Me.TA_TBE.SelectedIndex = 0
        Me.TA_TBE.Size = New System.Drawing.Size(905, 575)
        Me.TA_TBE.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TA_TBE.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Location = New System.Drawing.Point(174, 4)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(727, 567)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "选课"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Location = New System.Drawing.Point(174, 4)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(727, 567)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "查看选课情况"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Transparent
        Me.TabPage3.Location = New System.Drawing.Point(174, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(727, 567)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "成绩录入"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Transparent
        Me.TabPage4.Location = New System.Drawing.Point(174, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(727, 567)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "助教出勤登记"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.Transparent
        Me.TabPage5.Location = New System.Drawing.Point(174, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(727, 567)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "数据处理"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.Transparent
        Me.TabPage6.Location = New System.Drawing.Point(174, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(727, 567)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "理论课签到情况"
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.Transparent
        Me.TabPage7.Location = New System.Drawing.Point(174, 4)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(727, 567)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "自动填表上成绩"
        '
        'TA_Frame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 638)
        Me.Controls.Add(Me.TA_TBE)
        Me.DoubleBuffered = True
        Me.Name = "TA_Frame"
        Me.Text = "Form1"
        Me.TA_TBE.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TA_TBE As ElabManagement.TabControlEx_2
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage

End Class
