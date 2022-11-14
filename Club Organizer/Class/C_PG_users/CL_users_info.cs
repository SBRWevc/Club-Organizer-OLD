using Club_Organizer.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			string query_data_userdata = "SELECT id, lastname," +
				"name, secondname, gender, position," +
				"root, login FROM userdata";


			SQLiteConnection conn_data = new SQLiteConnection(conn);
			conn_data.Open();
			SQLiteCommand cmd_userdata = new SQLiteCommand(query_data_userdata, conn_data);
			SQLiteDataAdapter da_userdata = new SQLiteDataAdapter(cmd_userdata);

			da_userdata.Fill(Pages.PG_users.dt_users);

			conn_data.Close();
		}
	}
}
