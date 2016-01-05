<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputClassList
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.daoru = New System.Windows.Forms.Button
        Me.guanbi = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(765, 539)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "说明"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "程序从第二行开始读取"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(629, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "要求：B列是学号，C列是姓名，F列是系所，工作簿名称为上课时间（请一定按格式创建Excel文件）。其他列不读取。"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "请导入类似于下图中的格式的名单"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Teaching_Assistant.My.Resources.Resources.example
        Me.PictureBox1.Location = New System.Drawing.Point(15, 93)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(731, 433)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'daoru
        '
        Me.daoru.Location = New System.Drawing.Point(455, 568)
        Me.daoru.Name = "daoru"
        Me.daoru.Size = New System.Drawing.Size(75, 23)
        Me.daoru.TabIndex = 1
        Me.daoru.Text = "导入"
        Me.daoru.UseVisualStyleBackColor = True
        '
        'guanbi
        '
        Me.guanbi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.guanbi.Location = New System.Drawing.Point(237, 568)
        Me.guanbi.Name = "guanbi"
        Me.guanbi.Size = New System.Drawing.Size(75, 23)
        Me.guanbi.TabIndex = 2
        Me.guanbi.Text = "关闭"
        Me.guanbi.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx"
        '
        'InputClassList
        '
        Me.AcceptButton = Me.daoru
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.guanbi
        Me.ClientSize = New System.Drawing.Size(805, 604)
        Me.Controls.Add(Me.guanbi)
        Me.Controls.Add(Me.daoru)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(821, 643)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(821, 643)
        Me.Name = "InputClassList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "导入上课名单"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents daoru As System.Windows.Forms.Button
    Friend WithEvents guanbi As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
