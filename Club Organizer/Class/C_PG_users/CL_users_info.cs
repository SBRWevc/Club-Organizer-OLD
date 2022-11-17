using System.Data.SQLite;

namespace Club_Organizer.Class
{
	internal class CL_users_info
	{
		public static void get_info()
		{
			string conn = @"Data Source=DB/users.db;Version=3;";
			string query = "SELECT id, Фамилия," +
				"Имя, Отчество, Пол, Должность," +
				"Права, Логин FROM userdata";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			da.Fill(Pages.PG_users.dt_users);
			db_conn.Close();
		}
	}
}
