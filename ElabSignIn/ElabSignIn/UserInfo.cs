namespace ElabSignIn
{
	class UserInfo
	{
		public string UserName;
		public string StuNum;
		public string user;
		public string Team;
		public string Phone;
		public string HappyMotto;
		public string Grade;
		public string Sign_Identity;

		public UserInfo()
		{
			UserName = string.Empty;
			StuNum = string.Empty;
			user = string.Empty;
			Team = string.Empty;
			Phone = string.Empty;
			HappyMotto = string.Empty;
			Grade = string.Empty;
			Sign_Identity = string.Empty;
		}

		public UserInfo( string UserName, string StuNum,	string user, string Team, string Phone, string HappyMotto, string Grade, string Sign_Identity)
		{
			this.UserName = UserName;
			this.StuNum = StuNum;
			this.user = user;
			this.Team = Team;
			this.Phone = Phone;
			this.HappyMotto = HappyMotto;
			this.Grade = Grade;
			this.Sign_Identity = Sign_Identity;
		}
	}
}
