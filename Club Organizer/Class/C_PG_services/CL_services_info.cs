using System.Data.SQLite;

namespace Club_Organizer.Class.C_PG_services
{
	internal class CL_services_info
	{
		public static void get_info()
		{
			string conn = @"Data Source=DB/services.db;Version=3;";
			string query = "SELECT id, Название, " +
				"ФИО, Тип, Начало, Конец," +
				"Корт, Цена, Скидка, Итого FROM servicesdata";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			da.Fill(Pages.PG_services.dt_service);
			db_conn.Close();
		}
	}
}
