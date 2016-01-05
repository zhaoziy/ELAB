using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ElabSignIn
{
	public partial class Register : Form
	{
		public Register()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("是否将本机绑定为签到机器？", "绑定MAC",
				MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				string Pwd = UserFunction.Md5(TextBox_pwd.Text.ToString());
				string selectcmd = "select 学号 from [member] where 学号 = '" +
					TextBox_num.Text.ToString() + "' and 密码 = '" +
					Pwd + "'";
				DatabaseCmd database = new DatabaseCmd();
				SqlDataReader myreader;
				database.SqlExecuteReader(selectcmd, out myreader);
				if(myreader.Read())
				{
					string updatestr = "update [member] set MAC = '" +
						UserFunction.GetMacByNetworkInterface() + 
						"' where 学号 = '" + myreader.GetString(0) + "'";
					DatabaseCmd database2 = new DatabaseCmd();
					database2.SqlExecuteNonQuery(updatestr);
				}
				else
				{
					MessageBox.Show("学号或密码错误！");
				}
				database.SqlReaderClose();
				MessageBox.Show("绑定成功！ MAC地址为：" +
					UserFunction.GetMacByNetworkInterface());
				this.Close();
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
