namespace ElabSignIn
{
	partial class Register
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.TextBox_pwd = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button2 = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.TextBox_num = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.TextBox_pwd);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.Button1);
			this.panel1.Controls.Add(this.Button2);
			this.panel1.Controls.Add(this.Label1);
			this.panel1.Controls.Add(this.TextBox_num);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(204, 132);
			this.panel1.TabIndex = 0;
			// 
			// TextBox_pwd
			// 
			this.TextBox_pwd.Location = new System.Drawing.Point(65, 51);
			this.TextBox_pwd.Name = "TextBox_pwd";
			this.TextBox_pwd.PasswordChar = '*';
			this.TextBox_pwd.Size = new System.Drawing.Size(100, 21);
			this.TextBox_pwd.TabIndex = 35;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 40;
			this.label2.Text = "密码";
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(15, 90);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 42;
			this.Button1.Text = "提交";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// Button2
			// 
			this.Button2.Location = new System.Drawing.Point(111, 90);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 43;
			this.Button2.Text = "退出";
			this.Button2.UseVisualStyleBackColor = true;
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(30, 20);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(29, 12);
			this.Label1.TabIndex = 25;
			this.Label1.Text = "学号";
			// 
			// TextBox_num
			// 
			this.TextBox_num.Location = new System.Drawing.Point(65, 17);
			this.TextBox_num.MaxLength = 9;
			this.TextBox_num.Name = "TextBox_num";
			this.TextBox_num.Size = new System.Drawing.Size(100, 21);
			this.TextBox_num.TabIndex = 26;
			// 
			// Register
			// 
			this.AcceptButton = this.Button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Button2;
			this.ClientSize = new System.Drawing.Size(202, 131);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Name = "Register";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "绑定MAC";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox TextBox_num;
		private System.Windows.Forms.TextBox TextBox_pwd;
		private System.Windows.Forms.Label label2;
	}
}

