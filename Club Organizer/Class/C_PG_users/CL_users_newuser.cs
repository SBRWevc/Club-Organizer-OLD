using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace Club_Organizer.Class.C_PG_users
{
	internal class CL_users_newuser
	{
		// - Переменные - \\
		public static int id = 0;

		// - Запись данных нового пользователя - \\
		public static void newuser()
		{
			string db_conn = @"Data Source=DB/users.db;Version=3;";
			string query_newuser = "INSERT INTO userdata (id, Логин, Пароль, Имя, " +
				"Фамилия, Отчество, Должность, Пол, Права) " +
				"VALUES (@id, @login, @pass, @name, @lastname, @secondname, @position, " +
				"@gender, @root)";

			string login = Pages.PG_users.login_text;
			string pass = hashPass(Pages.PG_users.pass_text);
			string name = Pages.PG_users.name_text;
			string lastname = Pages.PG_users.lastname_text;
			string secondname = Pages.PG_users.secondname_text;
			string position = Pages.PG_users.position_text;
			string gender = Pages.PG_users.gender_text;
			int root = Pages.PG_users.root_text;

			newid();

			SQLiteConnection conn_add = new SQLiteConnection(db_conn);
			conn_add.Open();
			SQLiteCommand cmd_add = new SQLiteCommand(query_newuser, conn_add);
			cmd_add.Parameters.AddWithValue("@login", login);
			cmd_add.Parameters.AddWithValue("@pass", pass);
			cmd_add.Parameters.AddWithValue("@name", name);
			cmd_add.Parameters.AddWithValue("@lastname", lastname);
			cmd_add.Parameters.AddWithValue("@secondname", secondname);
			cmd_add.Parameters.AddWithValue("@position", position);
			cmd_add.Parameters.AddWithValue("@gender", gender);
			cmd_add.Parameters.AddWithValue("@root", root);
			cmd_add.Parameters.AddWithValue("@id", id + 1);
			cmd_add.ExecuteNonQuery();
			conn_add.Close();
		}

		// - Получение последнего ID - \\
		public static void newid()
		{
			string db_conn = @"Data Source=DB/users.db;Version=3;";
			string query_newid = "SELECT id FROM userdata ORDER BY id DESC LIMIT 1";

			SQLiteConnection conn_id = new SQLiteConnection(db_conn);
			conn_id.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_newid, conn_id);
			SQLiteDataReader dr = null;
			dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				id = dr.GetInt32(dr.GetOrdinal("id"));
			}

			conn_id.Close();
		}

		// - Хеширование пароля - \\
		public static string hashPass(string password)
		{
			MD5 md5 = MD5.Create();

			byte[] b = Encoding.ASCII.GetBytes(password);
			byte[] hash = md5.ComputeHash(b);

			StringBuilder sb = new StringBuilder();
			foreach (var a in hash)
			{
				sb.Append(a.ToString("X2"));
			}

			return Convert.ToString(sb);
		}
	}
}
