using System.Data.SQLite;

namespace Club_Organizer.Class
{
	internal class CL_userdata
	{
		// - Обращения и команды к БД - \\
		static string conn_users = @"Data Source=DB/users.db;Version=3;";
		static string query_datauser = "SELECT id, Фамилия, " +
			"Имя, Отчество, Пол, Должность, Права, Логин " +
			"FROM userdata WHERE @id=id";

		// - Переменные - \\
		public static int id = CL_auth.id;
		public static string lastname = null;
		public static string name = null;
		public static string secondname = null;
		public static string gender = null;
		public static string position = null;
		public static int root = 0;
		public static string login = null;

		// - Получение данных текущего пользователя - \\
		public static void getdatauser()
		{
			SQLiteConnection conn = new SQLiteConnection(conn_users);
			conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_datauser, conn);
			cmd.Parameters.AddWithValue("@id", id);
			SQLiteDataReader dr = null;
			dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				id = dr.GetInt32(dr.GetOrdinal("id"));
				lastname = dr.GetString(dr.GetOrdinal("Фамилия"));
				name = dr.GetString(dr.GetOrdinal("Имя"));
				secondname = dr.GetString(dr.GetOrdinal("Отчество"));
				gender = dr.GetString(dr.GetOrdinal("Пол"));
				position = dr.GetString(dr.GetOrdinal("Должность"));
				root = dr.GetInt32(dr.GetOrdinal("Права"));
				login = dr.GetString(dr.GetOrdinal("Логин"));
			}

			conn.Close();
		}

		// - Очистка данных текущего пользователя - \\
		public static void clerdatauser()
		{
			id = CL_auth.id;
			lastname = null;
			name = null;
			secondname = null;
			gender = null;
			position = null;
			root = 0;
			login = null;
		}
	}
}
