using System.Data.SQLite;

namespace Club_Organizer.Class.PG_users
{
	internal class CL_users_info_update
	{
		// - Обновление данных пользователей - \\
		public static void update_users_info()
		{
			string db_conn = @"Data Source=DB/users.db;Version=3;";
			string query_data = "SELECT id, Фамилия," +
				"Имя, Отчество, Пол, Должность," +
				"Права, Логин FROM userdata";

			SQLiteConnection conn = new SQLiteConnection(db_conn);
			conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query_data, conn);
			SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(da);
			da.Update(Pages.PG_users.dt_users);
			conn.Close();
		}
	}
}
