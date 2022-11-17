using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace Club_Organizer.Class.C_PG_users
{
	internal class CL_users_newuser
	{
		public static int id = 0;

		public static void newuser()
		{
			string conn = @"Data Source=DB/users.db;Version=3;";
			string query = "INSERT INTO userdata (id, Логин, Пароль, Имя, " +
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

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd_add = new SQLiteCommand(query, db_conn);
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
			db_conn.Close();
		}

		public static void newid()
		{
			string conn = @"Data Source=DB/users.db;Version=3;";
			string query = "SELECT id FROM userdata ORDER BY id DESC LIMIT 1";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			SQLiteDataReader dr = null;
			dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				id = dr.GetInt32(dr.GetOrdinal("id"));
			}

			db_conn.Close();
		}

		private static string hashPass(string password)
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
