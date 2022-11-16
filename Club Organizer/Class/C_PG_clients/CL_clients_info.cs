using System.Data.SQLite;

namespace Club_Organizer.Class.C_PG_clients
{
	internal class CL_clients_info
	{
		// - Получение данных всех пользователей -\\
		public static void get_info()
		{
			// -Подключение БД- \\
			string conn = @"Data Source=DB/clients.db;Version=3;";

			// -Запросы к БД- \\
			string query_data_clientsdata = "SELECT id, Фамилия," +
				"Имя, Отчество, Паспорт, Отдел," +
				"Телефон, Email, ДР," +
				"Зарегестрирован, Администратор FROM clients_data";

			SQLiteConnection conn_data = new SQLiteConnection(conn);
			conn_data.Open();
			SQLiteCommand cmd_userdata = new SQLiteCommand(query_data_clientsdata, conn_data);
			SQLiteDataAdapter da_userdata = new SQLiteDataAdapter(cmd_userdata);
			da_userdata.Fill(Pages.PG_clients.dt_client);
			conn_data.Close();
		}
	}
}
