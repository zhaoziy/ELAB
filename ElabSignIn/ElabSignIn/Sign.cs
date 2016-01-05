using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ElabSignIn
{
	class Sign
	{
		private int NowWeek = 0;
		private string Semester = string.Empty;
		private DateTime SignInTime = DateTime.Now;
		private DateTime SignOutTime = DateTime.Now;
		private bool IsSignIn = false;            //是否已签到
		private string Sign_Identity = string.Empty;

		public Sign()
		{
			NowWeek = UserFunction.GetWeek();                   //获取周次
			Semester = UserFunction.GetSemester();
			SignInTime = UserFunction.GetServerTime();
		}

		public float SumOnlineTime(UserInfo userinfo)
		{
			float OnlineTime = -1;
			string str_time = "select SUM(合计时间) from 时间统计 where 学号 = '" +
				userinfo.StuNum + "' and 周次 = " + NowWeek + " and 学期 ='" + Semester + "'";
			DatabaseCmd databasecmd = new DatabaseCmd();
			SqlDataReader myreader;
			databasecmd.SqlExecuteReader(str_time, out myreader);
			if (myreader.Read())
			{
				OnlineTime = (float)myreader.GetDouble(0);
			}
			databasecmd.SqlReaderClose();
			return OnlineTime;
		}

		public void SignIn(ref UserInfo userinfo)
		{
			//检测上次是否正常退出(今天范围内)，如果不是，将上次未签退的记录以0小时退掉，并将离开字段=登入字段(因为智能考核系统是以离开字段=0获取在线用户的)
			DatabaseCmd databasecmd = new DatabaseCmd();
			string str = "update 时间统计 set 离开=登入 where 离开='0' and 日期='" +
				SignInTime.Year + "-" + SignInTime.Month + "-" + SignInTime.Day +
				"' and 学号='" + userinfo.StuNum + "'";
			if (!databasecmd.SqlExecuteNonQuery(str))
			{
				MessageBox.Show("出现致命错误！程序将强制退出！");
				IsSignIn = false;
				Environment.Exit(0);
			}

			if (SignInTime.Year != 1991)
			{
				string str1 = string.Empty;

				str1 = "insert into 时间统计(学号,姓名,组别,日期,周次,登入,离开,合计时间,学期) values ('" +
				 userinfo.StuNum + "','" + userinfo.user + "','" + userinfo.Team + "','" +
				 SignInTime.Year + "-" + SignInTime.Month + "-" + SignInTime.Day + "','" +
				 NowWeek + "','" + SignInTime.ToString("T") + "','" + "0" + "','" + "0" + "','" +
				 Semester + "')" + " select scope_identity() as id";

				try
				{
					object index;
					databasecmd.SqlExecuteScalar(str1, out index);
					Sign_Identity = index.ToString();
					userinfo.Sign_Identity = Sign_Identity;
					IsSignIn = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					Environment.Exit(0);
				}
			}
		}

		public void SignOut(UserInfo userinfo)
		{
			if (IsSignIn)
			{
				SignOutTime = UserFunction.GetServerTime();
				string str = "update 时间统计 set 离开='" + SignOutTime.ToString("T") +
					"',合计时间='" + UserFunction.TimeDiff(SignOutTime, SignInTime) +
					"' where ID=" + userinfo.Sign_Identity;
				DatabaseCmd database = new DatabaseCmd();
				if (SignOutTime.Year == 1991 || !database.SqlExecuteNonQuery(str))
				{
					MessageBox.Show("无法正常签退，可能是网络连接故障。\n"
						 + "点击 确定 将强行退出，此次签到记录作废。\n"
						 + "点击 取消 将不会退出，可修复网络连接后再尝试退出。", Main.SoftName,
						 MessageBoxButtons.OKCancel);
				}
			}
		}

		public DateTime GetSignInTime()
		{
			return SignInTime;
		}
	}
}
