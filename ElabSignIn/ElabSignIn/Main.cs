using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ElabSignIn
{
	public partial class Main : Form
	{
		static private int Version = 1;
		static public string SoftName = "科中管理系统_签到";

		static private bool IsFirstRun = true;
		static private bool IsBackTip = true;
				
		static private float OnlineTime = 0.0f;
		static private DateTime NowTime;

		UserInfo userinfo = new UserInfo();
		Identify UserIdentity = new Identify();
		Sign UserSignInOrSignOut = new Sign();

		public Main()
		{
			InitializeComponent();
			
			Initialization();
		
			UserSignInOrSignOut.SignIn(ref userinfo);
			OnlineTime = UserSignInOrSignOut.SumOnlineTime(userinfo);

			UpdateInfo();
		}

		private void Initialization()
		{
			this.Opacity = 0;
			this.TextBMotto.Focus();
			this.Label1.Text = "版本号：" + Version;
			string startupPath = Application.StartupPath;

			if (startupPath.Substring(0, 2) == @"\\")
			{
				MessageBox.Show("请不要在服务器上运行，请安装到本地后再运行。");
				Environment.Exit(0);
			}

			//检测程序是否已经在运行
			if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
			{
				MessageBox.Show("检测到程序正在运行！");
				Environment.Exit(0);
			}

			if (!UserIdentity.GetInfo(ref userinfo))
			{
				MessageBox.Show("未获取到用户信息，请先注册！");
				Register newRegister = new Register();
				newRegister.ShowDialog();
				Application.Restart();
				Environment.Exit(0);
			}
		}

		#region "窗体事件"

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.ApplicationExitCall)
			{
				UserSignInOrSignOut.SignOut(userinfo);
			}
			else if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				ShowOrHide(false);
				if (IsFirstRun && IsBackTip)
				{
					notifyIcon1.Visible = true;
					notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
					notifyIcon1.BalloonTipTitle = userinfo.UserName;
					notifyIcon1.BalloonTipText = "我在后台运行呢~~嘿嘿";
					notifyIcon1.ShowBalloonTip(30);
					IsBackTip = false;
				}
			}
			else
			{
				UserSignInOrSignOut.SignOut(userinfo);
			}
			notifyIcon1.Visible = false;
		}

		private void Main_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				ShowOrHide(false);
			}
		}

		private void ShowOrHide(bool IsShow)
		{
			详细信息ToolStripMenuItem.Checked = IsShow;
			if (IsShow)
			{
				NowTime = UserFunction.GetServerTime();
				if (NowTime.Year == 1991)
				{
					toolStripStatusLabel2.Text = "获取失败";
				}
				else
				{
					toolStripStatusLabel2.Text = NowTime.ToShortDateString() + " " +
						NowTime.ToLongTimeString();
					NowTime = NowTime.AddSeconds(1);
				}
			}
			this.Visible = IsShow;
		}

		private void Main_Shown(object sender, EventArgs e)
		{
			this.Hide();
			this.Opacity = 1;
			详细信息ToolStripMenuItem.Checked = false;
		}

		#endregion

		#region "右下角事件"

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			this.ShowOrHide(!this.Visible);
		}

		private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowOrHide(!this.Visible);
		}

		private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
		{
			notifyIcon1.Text = "当前在线时间为：" + OnlineTime + "小时";
		}

		#endregion

		#region "个人信息控制及按钮事件"

		private void TextBPhone_TextChanged(object sender, EventArgs e)
		{
			this.ButChange.Enabled = true;
			this.ButChange.Text = "应用设置";
		}

		private void UpdateInfo()
		{
			this.TextBName.Text = userinfo.user;
			this.TextBNum.Text = userinfo.StuNum;
			this.TextBTeam.Text = userinfo.Team;
			this.TextBGrade.Text = userinfo.Grade;
			this.TextBSign.Text = UserSignInOrSignOut.GetSignInTime().ToString("T");
			this.TextBPhone.Text = userinfo.Phone;
			this.TextBMotto.Text = userinfo.HappyMotto;
			this.ButChange.Enabled = false;
		}

		private void ButChange_Click(object sender, EventArgs e)
		{
			bool islegal = true;
			for (int i = 0; i < TextBPhone.Text.Length; ++i)
			{
				if (!Char.IsNumber(TextBPhone.Text, i))
				{
					islegal = false;
				}
			}
			if (islegal)
			{
				ButChange.Enabled = false;
				ButChange.Text = "稍后....";
				string str = @"update [member] set [电话]='" + TextBPhone.Text.Trim() +
					"',[座右铭]='" + TextBMotto.Text.Trim() + "' where [学号]='" +
					userinfo.StuNum + "'";
				DatabaseCmd database = new DatabaseCmd();
				if (!database.SqlExecuteNonQuery(str))
				{
					MessageBox.Show("更新失败！请检查网络连接");
					ButChange.Enabled = true;
					ButChange.Text = "应用设置";
					ButChange.Focus();
				}
				else
				{
					userinfo.Phone = TextBPhone.Text.Trim();
					userinfo.HappyMotto = TextBMotto.Text.Trim();
					ButChange.Text = "设置成功";
					TextBMotto.Focus();
				}
			}
			else
			{
				errorProvider1.SetError(TextBPhone, "只允许使用数字！");
				TextBPhone.Focus();
			}
		}

		private void button_Hide_Click(object sender, EventArgs e)
		{
			ShowOrHide(false);
		}

		#endregion
	}
}