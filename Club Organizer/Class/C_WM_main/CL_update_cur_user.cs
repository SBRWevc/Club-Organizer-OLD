using System;
using System.Text;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace Club_Organizer.Class
{
	internal class CL_update_cur_user
	{
		static string db_conn = @"Data Source=DB/users.db;Version=3;";
		static string inc_login = "UPDATE userdata SET login=@login WHERE id=@id";
		static string inc_pass = "UPDATE userdata SET pass=@pass WHERE id=@id";
		static string inc_all = "UPDATE userdata SET pass=@pass, login=@login WHERE id=@id";
		
		// - Обновление логина пользователя - \\
		public static void login_update()
		{
			SQLiteConnection conn = new SQLiteConnection(db_conn);
			conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(inc_login, conn);
			cmd.Parameters.AddWithValue("@login", MainWindow.prof_login);
			cmd.Parameters.AddWithValue("@id", CL_userdata.id);
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		// - Обновление пароля пользователя - \\
		public static void pass_update()
		{
			string pass = hashPass(MainWindow.prof_pass);

			SQLiteConnection conn = new SQLiteConnection(db_conn);
			conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(inc_pass, conn);
			cmd.Parameters.AddWithValue("@pass", pass);
			cmd.Parameters.AddWithValue("@id", CL_userdata.id);
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		// - Обновление всех данных пользователя - \\
		public static void all_update()
		{
			string pass = hashPass(MainWindow.prof_pass);

			SQLiteConnection conn = new SQLiteConnection(db_conn);
			conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(inc_all, conn);
			cmd.Parameters.AddWithValue("@login", MainWindow.prof_login);
			cmd.Parameters.AddWithValue("@pass", pass);
			cmd.Parameters.AddWithValue("@id", CL_userdata.id);
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		// - Хеширование пароля пользователя - \\
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
