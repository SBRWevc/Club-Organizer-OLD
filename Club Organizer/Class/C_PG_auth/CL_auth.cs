using System.Data.SQLite;
using System.Data;
using Club_Organizer.Pages;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Club_Organizer.Class
{
	internal class CL_auth
	{
		// - Обращения и команды к БД - \\
		static string conn_users = @"Data Source=DB/users.db;Version=3;";
		static string query_users = "SELECT * FROM userdata WHERE login=@login AND pass=@pass";
		
		// - Переменные - \\
		static string login = null;
		static string pass = null;
		public static int id = 0;

		public static bool ok;

		// - Авторизация - \\
		public static void auth()
		{
			login = PG_auth.login_text;
			pass = hashPass(PG_auth.pass_text);

			SQLiteConnection conn = new SQLiteConnection(conn_users);
			conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_users, conn);
			cmd.Parameters.AddWithValue("@login", login);
			cmd.Parameters.AddWithValue("@pass", pass);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);

			if (dt.Rows.Count > 0)
			{
				SQLiteDataReader dr = null;
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					id = dr.GetInt32(dr.GetOrdinal("id"));
				}

				ok = true;
				dt.Rows.Clear();
				conn.Close();
			}
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
