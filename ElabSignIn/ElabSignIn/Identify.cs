using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ElabSignIn
{
	class Identify
	{
		private string PublicIP = string.Empty;
		private int UserType = 0;      //1代表内网用户，2代表Dlut用户，0代表非法用户

		public Identify()
		{
			PublicIP = UserFunction.GetIP();
			UserType = GetUserType();
			if (UserType == 0)
			{
				MessageBox.Show("请进入科中范围使用");
				Environment.Exit(0);
			}
		}

		private int GetUserType()
		{
			string[] IPArrray = new string[4];
			IPArrray = PublicIP.Split('.');
			if (IPArrray[0] == "202" && IPArrray[1] == "118" && 
				IPArrray[2] == "74" && IPArrray[3] == "160")
			{
				return 1;
			}
			//else if (IPArrray[0] == "111" && IPArrray[1] == "117" &&
			// IPArrray[2] == "112" && IPArrray[3] == "118")
			else if (IPArrray[0] == "202" && IPArrray[1] == "118" &&
				IPArrray[2] == "111" && IPArrray[3] == "2")
			{
				return 2;
			}
			else
			{
				return 0;
			}
		}

		public bool GetInfo(ref UserInfo userinfo)
		{
			string str = string.Empty;
			if (UserType == 1)
			{
				str = @"select UserName,学号,姓名,组别,电话,座右铭,年级 from [member] where USERNAME='" +
					Environment.GetEnvironmentVariable("username") + "'";
			}
			else if (UserType == 2)
			{
				str = @"select UserName,学号,姓名,组别,电话,座右铭,年级 from [member] where MAC='" +
					UserFunction.GetMacByNetworkInterface() + "'";
			}

			DatabaseCmd databasecmd = new DatabaseCmd();
			SqlDataReader myreader;
			databasecmd.SqlExecuteReader(str, out myreader);
			if (myreader.Read())
			{
				userinfo.UserName = myreader.GetString(0).ToString();
				userinfo.StuNum = myreader.GetString(1).ToString();
				userinfo.user = myreader.GetString(2).ToString();
				userinfo.Team = myreader.GetString(3).ToString();
				userinfo.Phone = myreader.GetString(4).ToString();
				userinfo.HappyMotto = myreader.GetString(5).ToString();
				userinfo.Grade = myreader.GetString(6).ToString();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
