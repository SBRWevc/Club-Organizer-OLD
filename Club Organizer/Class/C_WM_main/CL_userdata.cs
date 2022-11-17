using System.Data.SQLite;

namespace Club_Organizer.Class
{
	internal class CL_userdata
	{
		static string conn = @"Data Source=DB/users.db;Version=3;";
		static string query = "SELECT id, Фамилия, " +
			"Имя, Отчество, Пол, Должность, Права, Логин " +
			"FROM userdata WHERE @id=id";

		public static int id = CL_auth.id;
		public static string lastname = null;
		public static string name = null;
		public static string secondname = null;
		public static string gender = null;
		public static string position = null;
		public static int root = 0;
		public static string login = null;

		public static void getdatauser()
		{
			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
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

			db_conn.Close();
		}

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
