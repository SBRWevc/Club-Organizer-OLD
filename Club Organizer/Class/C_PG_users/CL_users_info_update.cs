using System.Data.SQLite;

namespace Club_Organizer.Class.PG_users
{
	internal class CL_users_info_update
	{
		public static void update_users_info()
		{
			string conn = @"Data Source=DB/users.db;Version=3;";
			string query = "SELECT id, Фамилия," +
				"Имя, Отчество, Пол, Должность," +
				"Права, Логин FROM userdata";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query, db_conn);
			SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(da);
			da.Update(Pages.PG_users.dt_users);
			db_conn.Close();
		}
	}
}
