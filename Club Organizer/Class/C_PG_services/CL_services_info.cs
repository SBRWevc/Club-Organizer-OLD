using System.Data.SQLite;

namespace Club_Organizer.Class.C_PG_services
{
	internal class CL_services_info
	{
		// - Получение данных всех пользователей -\\
		public static void get_info()
		{
			// -Подключение БД- \\
			string conn = @"Data Source=DB/services.db;Version=3;";

			// -Запросы к БД- \\
			string query_data_userdata = "SELECT id, Название, " +
				"ФИО, Тип, Начало, Конец," +
				"Корт, Цена, Скидка, Итого FROM servicesdata";


			SQLiteConnection conn_data = new SQLiteConnection(conn);
			conn_data.Open();
			SQLiteCommand cmd_userdata = new SQLiteCommand(query_data_userdata, conn_data);
			SQLiteDataAdapter da_userdata = new SQLiteDataAdapter(cmd_userdata);

			da_userdata.Fill(Pages.PG_services.dt_service);

			conn_data.Close();
		}
	}
}
