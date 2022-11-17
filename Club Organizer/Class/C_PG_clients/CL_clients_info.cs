using System.Data.SQLite;

namespace Club_Organizer.Class.C_PG_clients
{
	internal class CL_clients_info
	{
		public static void get_info()
		{
			string conn = @"Data Source=DB/clients.db;Version=3;";
			string query = "SELECT id, Фамилия," +
				"Имя, Отчество, Паспорт, Отдел," +
				"Телефон, Email, ДР," +
				"Зарегестрирован, Администратор FROM clients_data";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			da.Fill(Pages.PG_clients.dt_client);
			db_conn.Close();
		}
	}
}
