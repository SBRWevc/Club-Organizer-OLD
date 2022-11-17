using System.Data.SQLite;
using System.Data;

namespace Club_Organizer.Class.C_PG_users
{
	internal class CL_users_info_check
	{
		public static bool ok;

		public static void checkinfo()
		{
			string conn = @"Data Source=DB/users.db;Version=3;";
			string query = "SELECT Логин FROM userdata WHERE Логин=@login";
			string login = Pages.PG_users.login_text;

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			cmd.Parameters.AddWithValue("@login", login);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			if (dt.Rows.Count > 0)
			{
				ok = false;
			}

			else
			{
				ok= true;
				CL_users_newuser.newuser();
			}
		}
	}
}
