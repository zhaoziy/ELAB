<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Status_Panel = New System.Windows.Forms.Panel
        Me.Label_Auth = New System.Windows.Forms.Label
        Me.Label_Time = New System.Windows.Forms.Label
        Me.Panel_Top = New System.Windows.Forms.Panel
        Me.Min_Bt = New System.Windows.Forms.Panel
        Me.Config_Lbl = New System.Windows.Forms.Label
        Me.Exit_Bt = New System.Windows.Forms.Panel
        Me.Main_TAB = New ElabManagement.TabControlEx
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Status_Panel.SuspendLayout()
        Me.Panel_Top.SuspendLayout()
        Me.Main_TAB.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Status_Panel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel_Top, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Main_TAB, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(905, 700)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Status_Panel
        '
        Me.Status_Panel.BackgroundImage = Global.ElabManagement.My.Resources.Resources.bottom
        Me.Status_Panel.Controls.Add(Me.Label_Auth)
        Me.Status_Panel.Controls.Add(Me.Label_Time)
        Me.Status_Panel.Location = New System.Drawing.Point(0, 675)
        Me.Status_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Status_Panel.Name = "Status_Panel"
        Me.Status_Panel.Size = New System.Drawing.Size(905, 25)
        Me.Status_Panel.TabIndex = 3
        '
        'Label_Auth
        '
        Me.Label_Auth.AutoSize = True
        Me.Label_Auth.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_Auth.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label_Auth.Location = New System.Drawing.Point(13, 3)
        Me.Label_Auth.Name = "Label_Auth"
        Me.Label_Auth.Size = New System.Drawing.Size(69, 19)
        Me.Label_Auth.TabIndex = 1
        Me.Label_Auth.Text = "Label1"
        '
        'Label_Time
        '
        Me.Label_Time.AutoSize = True
        Me.Label_Time.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_Time.ForeColor = System.Drawing.Color.White
        Me.Label_Time.Location = New System.Drawing.Point(704, 5)
        Me.Label_Time.Name = "Label_Time"
        Me.Label_Time.Size = New System.Drawing.Size(69, 19)
        Me.Label_Time.TabIndex = 0
        Me.Label_Time.Text = "Label1"
        '
        'Panel_Top
        '
        Me.Panel_Top.BackgroundImage = Global.ElabManagement.My.Resources.Resources.top
        Me.Panel_Top.Controls.Add(Me.Min_Bt)
        Me.Panel_Top.Controls.Add(Me.Config_Lbl)
        Me.Panel_Top.Controls.Add(Me.Exit_Bt)
        Me.Panel_Top.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Top.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel_Top.Name = "Panel_Top"
        Me.Panel_Top.Size = New System.Drawing.Size(905, 20)
        Me.Panel_Top.TabIndex = 5
        '
        'Min_Bt
        '
        Me.Min_Bt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Min_Bt.Location = New System.Drawing.Point(830, 0)
        Me.Min_Bt.Margin = New System.Windows.Forms.Padding(0)
        Me.Min_Bt.Name = "Min_Bt"
        Me.Min_Bt.Size = New System.Drawing.Size(29, 20)
        Me.Min_Bt.TabIndex = 1
        '
        'Config_Lbl
        '
        Me.Config_Lbl.AutoSize = True
        Me.Config_Lbl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Config_Lbl.ForeColor = System.Drawing.Color.White
        Me.Config_Lbl.Location = New System.Drawing.Point(783, 4)
        Me.Config_Lbl.Name = "Config_Lbl"
        Me.Config_Lbl.Size = New System.Drawing.Size(37, 14)
        Me.Config_Lbl.TabIndex = 2
        Me.Config_Lbl.Text = "设置"
        '
        'Exit_Bt
        '
        Me.Exit_Bt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Exit_Bt.Location = New System.Drawing.Point(857, 0)
        Me.Exit_Bt.Margin = New System.Windows.Forms.Padding(0)
        Me.Exit_Bt.Name = "Exit_Bt"
        Me.Exit_Bt.Size = New System.Drawing.Size(48, 20)
        Me.Exit_Bt.TabIndex = 0
        '
        'Main_TAB
        '
        Me.Main_TAB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Main_TAB.Controls.Add(Me.TabPage1)
        Me.Main_TAB.Controls.Add(Me.TabPage2)
        Me.Main_TAB.Controls.Add(Me.TabPage3)
        Me.Main_TAB.Controls.Add(Me.TabPage4)
        Me.Main_TAB.Controls.Add(Me.TabPage5)
        Me.Main_TAB.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Main_TAB.ItemSize = New System.Drawing.Size(75, 85)
        Me.Main_TAB.Location = New System.Drawing.Point(0, 20)
        Me.Main_TAB.Margin = New System.Windows.Forms.Padding(0)
        Me.Main_TAB.Name = "Main_TAB"
        Me.Main_TAB.SelectedIndex = 0
        Me.Main_TAB.Size = New System.Drawing.Size(905, 655)
        Me.Main_TAB.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.Main_TAB.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 89)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(897, 562)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "助课"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Location = New System.Drawing.Point(4, 89)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(897, 562)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "成员管理"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Transparent
        Me.TabPage3.Location = New System.Drawing.Point(4, 89)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(897, 562)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "签到与值班"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Transparent
        Me.TabPage4.Location = New System.Drawing.Point(4, 89)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(897, 562)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "系统控制"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.Transparent
        Me.TabPage5.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(4, 89)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(897, 562)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "硬件组"
        '
        'Timer1
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 700)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "科中管理系统"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Status_Panel.ResumeLayout(False)
        Me.Status_Panel.PerformLayout()
        Me.Panel_Top.ResumeLayout(False)
        Me.Panel_Top.PerformLayout()
        Me.Main_TAB.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Min_Bt As System.Windows.Forms.Panel
    Friend WithEvents Exit_Bt As System.Windows.Forms.Panel
    Friend WithEvents Status_Panel As System.Windows.Forms.Panel
    Friend WithEvents Label_Time As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Config_Lbl As System.Windows.Forms.Label
    Friend WithEvents Panel_Top As System.Windows.Forms.Panel
    Friend WithEvents Main_TAB As ElabManagement.TabControlEx
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label_Auth As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage

End Class
