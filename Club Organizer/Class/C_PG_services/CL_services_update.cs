using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_Organizer.Class.C_PG_services
{
	internal class CL_services_update
	{
		// - Обновление данных пользователей - \\
		public static void update_services_info()
		{
			// -Подключение БД- \\
			string conn = @"Data Source=DB/services.db;Version=3;";

			// -Запросы к БД- \\
			string query_data= "SELECT id, name, client_name," +
				"type, date_start, date_end," +
				"pref_court, sale, price, final_price FROM servicesdata";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query_data, db_conn);
			SQLiteCommandBuilder cmdb = new SQLiteCommandBuilder(da);
			da.Update(Pages.PG_services.dt_service);
			db_conn.Close();
		}
	}
}
