using System.Data.SQLite;

namespace Club_Organizer.Class.C_PG_clients
{
	internal class CL_clients_info_update
	{
		// - Обновление данных пользователей - \\
		public static void update_clients_info()
		{
			// -Подключение БД- \\
			string conn = @"Data Source=DB/clients.db;Version=3;";

			// -Запросы к БД- \\
			string query_client_update = "SELECT id, Фамилия," +
				"Имя, Отчество, Паспорт, Отдел," +
				"Телефон, Email, ДР," +
				"Зарегестрирован, Администратор FROM clients";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query_client_update, db_conn);
			SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(da);
			da.Update(Pages.PG_clients.dt_client);
			db_conn.Close();
		}
	}
}
