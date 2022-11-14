using System.Data.SQLite;
using System.Data;

namespace Club_Organizer.Class.C_PG_users
{
	internal class CL_users_info_check
	{
		// - Переменные - \\
		public static bool ok;

		// - Проверка свободного логина - \\
		public static void checkinfo()
		{
			string db_conn = @"Data Source=DB/users.db;Version=3;";
			string query_test = "SELECT login FROM userdata WHERE login=@login";
			string login = Pages.PG_users.login_text;

			SQLiteConnection conn = new SQLiteConnection(db_conn);
			conn.Open();
			SQLiteCommand cmd_test = new SQLiteCommand(query_test, conn);
			cmd_test.Parameters.AddWithValue("@login", login);
			SQLiteDataAdapter da_test = new SQLiteDataAdapter(cmd_test);
			DataTable dt_test = new DataTable();
			da_test.Fill(dt_test);

			if (dt_test.Rows.Count > 0)
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
