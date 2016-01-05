namespace ElabSignIn
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.TextBNum = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.LabNum = new System.Windows.Forms.Label();
			this.TextBSign = new System.Windows.Forms.TextBox();
			this.LabSign = new System.Windows.Forms.Label();
			this.TextBMotto = new System.Windows.Forms.TextBox();
			this.TextBPhone = new System.Windows.Forms.TextBox();
			this.TextBGrade = new System.Windows.Forms.TextBox();
			this.LabMotto = new System.Windows.Forms.Label();
			this.TextBTeam = new System.Windows.Forms.TextBox();
			this.ButChange = new System.Windows.Forms.Button();
			this.LabGrade = new System.Windows.Forms.Label();
			this.TextBName = new System.Windows.Forms.TextBox();
			this.LabPhone = new System.Windows.Forms.Label();
			this.LabTeam = new System.Windows.Forms.Label();
			this.LabName = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.详细信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.开机启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.科中管理系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.版本特性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.使用须知ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.button_Hide = new System.Windows.Forms.Button();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// TextBNum
			// 
			this.TextBNum.Enabled = false;
			this.TextBNum.Location = new System.Drawing.Point(119, 55);
			this.TextBNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBNum.MaxLength = 9;
			this.TextBNum.Name = "TextBNum";
			this.TextBNum.Size = new System.Drawing.Size(152, 25);
			this.TextBNum.TabIndex = 18;
			this.TextBNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(116, 426);
			this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(55, 15);
			this.Label1.TabIndex = 32;
			this.Label1.Text = "Label1";
			// 
			// LabNum
			// 
			this.LabNum.AutoSize = true;
			this.LabNum.Location = new System.Drawing.Point(49, 59);
			this.LabNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabNum.Name = "LabNum";
			this.LabNum.Size = new System.Drawing.Size(52, 15);
			this.LabNum.TabIndex = 26;
			this.LabNum.Text = "学号：";
			this.LabNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextBSign
			// 
			this.TextBSign.Enabled = false;
			this.TextBSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TextBSign.Location = new System.Drawing.Point(119, 161);
			this.TextBSign.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBSign.Name = "TextBSign";
			this.TextBSign.Size = new System.Drawing.Size(152, 25);
			this.TextBSign.TabIndex = 21;
			this.TextBSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// LabSign
			// 
			this.LabSign.AutoSize = true;
			this.LabSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LabSign.Location = new System.Drawing.Point(17, 165);
			this.LabSign.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabSign.Name = "LabSign";
			this.LabSign.Size = new System.Drawing.Size(82, 15);
			this.LabSign.TabIndex = 29;
			this.LabSign.Text = "签到时间：";
			this.LabSign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextBMotto
			// 
			this.TextBMotto.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TextBMotto.Location = new System.Drawing.Point(119, 235);
			this.TextBMotto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBMotto.MaxLength = 1000;
			this.TextBMotto.Multiline = true;
			this.TextBMotto.Name = "TextBMotto";
			this.TextBMotto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBMotto.Size = new System.Drawing.Size(152, 110);
			this.TextBMotto.TabIndex = 23;
			// 
			// TextBPhone
			// 
			this.TextBPhone.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TextBPhone.Location = new System.Drawing.Point(119, 199);
			this.TextBPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBPhone.MaxLength = 11;
			this.TextBPhone.Name = "TextBPhone";
			this.TextBPhone.Size = new System.Drawing.Size(152, 25);
			this.TextBPhone.TabIndex = 22;
			this.TextBPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TextBPhone.TextChanged += new System.EventHandler(this.TextBPhone_TextChanged);
			// 
			// TextBGrade
			// 
			this.TextBGrade.Enabled = false;
			this.TextBGrade.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TextBGrade.Location = new System.Drawing.Point(119, 124);
			this.TextBGrade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBGrade.Name = "TextBGrade";
			this.TextBGrade.Size = new System.Drawing.Size(152, 25);
			this.TextBGrade.TabIndex = 20;
			this.TextBGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// LabMotto
			// 
			this.LabMotto.AutoSize = true;
			this.LabMotto.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LabMotto.Location = new System.Drawing.Point(33, 239);
			this.LabMotto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabMotto.Name = "LabMotto";
			this.LabMotto.Size = new System.Drawing.Size(67, 15);
			this.LabMotto.TabIndex = 31;
			this.LabMotto.Text = "座右铭：";
			this.LabMotto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextBTeam
			// 
			this.TextBTeam.Enabled = false;
			this.TextBTeam.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TextBTeam.Location = new System.Drawing.Point(119, 89);
			this.TextBTeam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBTeam.Name = "TextBTeam";
			this.TextBTeam.Size = new System.Drawing.Size(152, 25);
			this.TextBTeam.TabIndex = 19;
			this.TextBTeam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ButChange
			// 
			this.ButChange.Location = new System.Drawing.Point(52, 366);
			this.ButChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ButChange.Name = "ButChange";
			this.ButChange.Size = new System.Drawing.Size(91, 35);
			this.ButChange.TabIndex = 24;
			this.ButChange.Text = "应用设置";
			this.ButChange.UseVisualStyleBackColor = true;
			this.ButChange.Click += new System.EventHandler(this.ButChange_Click);
			// 
			// LabGrade
			// 
			this.LabGrade.AutoSize = true;
			this.LabGrade.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LabGrade.Location = new System.Drawing.Point(49, 128);
			this.LabGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabGrade.Name = "LabGrade";
			this.LabGrade.Size = new System.Drawing.Size(52, 15);
			this.LabGrade.TabIndex = 28;
			this.LabGrade.Text = "年级：";
			this.LabGrade.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextBName
			// 
			this.TextBName.Enabled = false;
			this.TextBName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TextBName.Location = new System.Drawing.Point(119, 21);
			this.TextBName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TextBName.Name = "TextBName";
			this.TextBName.Size = new System.Drawing.Size(152, 25);
			this.TextBName.TabIndex = 17;
			this.TextBName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// LabPhone
			// 
			this.LabPhone.AutoSize = true;
			this.LabPhone.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LabPhone.Location = new System.Drawing.Point(33, 202);
			this.LabPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabPhone.Name = "LabPhone";
			this.LabPhone.Size = new System.Drawing.Size(67, 15);
			this.LabPhone.TabIndex = 30;
			this.LabPhone.Text = "手机号：";
			this.LabPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LabTeam
			// 
			this.LabTeam.AutoSize = true;
			this.LabTeam.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LabTeam.Location = new System.Drawing.Point(49, 92);
			this.LabTeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabTeam.Name = "LabTeam";
			this.LabTeam.Size = new System.Drawing.Size(52, 15);
			this.LabTeam.TabIndex = 27;
			this.LabTeam.Text = "组别：";
			this.LabTeam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LabName
			// 
			this.LabName.AutoSize = true;
			this.LabName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LabName.Location = new System.Drawing.Point(49, 25);
			this.LabName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabName.Name = "LabName";
			this.LabName.Size = new System.Drawing.Size(52, 15);
			this.LabName.TabIndex = 25;
			this.LabName.Text = "姓名：";
			this.LabName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon1.BalloonTipText = "123";
			this.notifyIcon1.BalloonTipTitle = "456";
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.详细信息ToolStripMenuItem,
            this.开机启动ToolStripMenuItem,
            this.科中管理系统ToolStripMenuItem,
            this.版本特性ToolStripMenuItem,
            this.使用须知ToolStripMenuItem,
            this.退出程序ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(175, 160);
			// 
			// 详细信息ToolStripMenuItem
			// 
			this.详细信息ToolStripMenuItem.Name = "详细信息ToolStripMenuItem";
			this.详细信息ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
			this.详细信息ToolStripMenuItem.Text = "详细信息";
			this.详细信息ToolStripMenuItem.Click += new System.EventHandler(this.详细信息ToolStripMenuItem_Click);
			// 
			// 开机启动ToolStripMenuItem
			// 
			this.开机启动ToolStripMenuItem.Name = "开机启动ToolStripMenuItem";
			this.开机启动ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
			this.开机启动ToolStripMenuItem.Text = "开机启动";
			// 
			// 科中管理系统ToolStripMenuItem
			// 
			this.科中管理系统ToolStripMenuItem.Name = "科中管理系统ToolStripMenuItem";
			this.科中管理系统ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
			this.科中管理系统ToolStripMenuItem.Text = "科中管理系统";
			// 
			// 版本特性ToolStripMenuItem
			// 
			this.版本特性ToolStripMenuItem.Name = "版本特性ToolStripMenuItem";
			this.版本特性ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
			this.版本特性ToolStripMenuItem.Text = "版本特性";
			// 
			// 使用须知ToolStripMenuItem
			// 
			this.使用须知ToolStripMenuItem.Name = "使用须知ToolStripMenuItem";
			this.使用须知ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
			this.使用须知ToolStripMenuItem.Text = "使用须知";
			// 
			// 退出程序ToolStripMenuItem
			// 
			this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
			this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
			this.退出程序ToolStripMenuItem.Text = "退出程序";
			this.退出程序ToolStripMenuItem.Click += new System.EventHandler(this.退出程序ToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Location = new System.Drawing.Point(0, 469);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip1.Size = new System.Drawing.Size(309, 22);
			this.statusStrip1.TabIndex = 34;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(161, 17);
			this.toolStripStatusLabel1.Spring = true;
			this.toolStripStatusLabel1.Text = "服务器时间：";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
			this.toolStripStatusLabel2.Text = "00:00:00";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// button_Hide
			// 
			this.button_Hide.Location = new System.Drawing.Point(172, 366);
			this.button_Hide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button_Hide.Name = "button_Hide";
			this.button_Hide.Size = new System.Drawing.Size(91, 35);
			this.button_Hide.TabIndex = 35;
			this.button_Hide.Text = "隐藏";
			this.button_Hide.UseVisualStyleBackColor = true;
			this.button_Hide.Click += new System.EventHandler(this.button_Hide_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 491);
			this.ControlBox = false;
			this.Controls.Add(this.button_Hide);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.TextBNum);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.LabNum);
			this.Controls.Add(this.TextBSign);
			this.Controls.Add(this.LabSign);
			this.Controls.Add(this.TextBMotto);
			this.Controls.Add(this.TextBPhone);
			this.Controls.Add(this.TextBGrade);
			this.Controls.Add(this.LabMotto);
			this.Controls.Add(this.TextBTeam);
			this.Controls.Add(this.ButChange);
			this.Controls.Add(this.LabGrade);
			this.Controls.Add(this.TextBName);
			this.Controls.Add(this.LabPhone);
			this.Controls.Add(this.LabTeam);
			this.Controls.Add(this.LabName);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Main";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "科中管理系统_签到";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.Shown += new System.EventHandler(this.Main_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.TextBox TextBNum;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label LabNum;
		internal System.Windows.Forms.TextBox TextBSign;
		internal System.Windows.Forms.Label LabSign;
		internal System.Windows.Forms.TextBox TextBMotto;
		internal System.Windows.Forms.TextBox TextBPhone;
		internal System.Windows.Forms.TextBox TextBGrade;
		internal System.Windows.Forms.Label LabMotto;
		internal System.Windows.Forms.TextBox TextBTeam;
		internal System.Windows.Forms.Button ButChange;
		internal System.Windows.Forms.Label LabGrade;
		internal System.Windows.Forms.TextBox TextBName;
		internal System.Windows.Forms.Label LabPhone;
		internal System.Windows.Forms.Label LabTeam;
		internal System.Windows.Forms.Label LabName;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.ToolStripMenuItem 详细信息ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 开机启动ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 科中管理系统ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 版本特性ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 使用须知ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.Button button_Hide;
	}
}