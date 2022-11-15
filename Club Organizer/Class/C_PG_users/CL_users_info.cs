using System.Data.SQLite;

namespace Club_Organizer.Class
{
	internal class CL_users_info
	{
		// - Получение данных всех пользователей -\\
		public static void get_info()
		{
			// -Подключение БД- \\
			string conn = @"Data Source=DB/users.db;Version=3;";

			// -Запросы к БД- \\
			string query_data_userdata = "SELECT id, Фамилия," +
				"Имя, Отчество, Пол, Должность," +
				"Права, Логин FROM userdata";


			SQLiteConnection conn_data = new SQLiteConnection(conn);
			conn_data.Open();
			SQLiteCommand cmd_userdata = new SQLiteCommand(query_data_userdata, conn_data);
			SQLiteDataAdapter da_userdata = new SQLiteDataAdapter(cmd_userdata);

			da_userdata.Fill(Pages.PG_users.dt_users);

			conn_data.Close();
		}
	}
}
