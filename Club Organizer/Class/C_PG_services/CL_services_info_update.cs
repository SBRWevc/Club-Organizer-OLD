using System.Data.SQLite;

namespace Club_Organizer.Class.C_PG_services
{
	internal class CL_services_info_update
	{
		public static void update_services_info()
		{
			string conn = @"Data Source=DB/services.db;Version=3;";
			string query = "SELECT id, Название, " +
				"ФИО, Тип, Начало, Конец," +
				"Корт, Цена, Скидка, Итого FROM servicesdata";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query, db_conn);
			SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(da);
			da.Update(Pages.PG_services.dt_service);
			db_conn.Close();
		}
	}
}
