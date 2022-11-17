using System;
using System.Text;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace Club_Organizer.Class
{
	internal class CL_update_cur_user
	{
		static string conn = @"Data Source=DB/users.db;Version=3;";
		static string query_login = "UPDATE userdata SET Логин=@login WHERE id=@id";
		static string query_pass = "UPDATE userdata SET Пароль=@pass WHERE id=@id";
		static string query_all = "UPDATE userdata SET Пароль=@pass, Логин=@login WHERE id=@id";
		
		public static void login_update()
		{
			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_login, db_conn);
			cmd.Parameters.AddWithValue("@login", MainWindow.prof_login);
			cmd.Parameters.AddWithValue("@id", CL_userdata.id);
			cmd.ExecuteNonQuery();
			db_conn.Close();
		}

		public static void pass_update()
		{
			string pass = hashPass(MainWindow.prof_pass);

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_pass, db_conn);
			cmd.Parameters.AddWithValue("@pass", pass);
			cmd.Parameters.AddWithValue("@id", CL_userdata.id);
			cmd.ExecuteNonQuery();
			db_conn.Close();
		}

		public static void all_update()
		{
			string pass = hashPass(MainWindow.prof_pass);

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query_all, db_conn);
			cmd.Parameters.AddWithValue("@login", MainWindow.prof_login);
			cmd.Parameters.AddWithValue("@pass", pass);
			cmd.Parameters.AddWithValue("@id", CL_userdata.id);
			cmd.ExecuteNonQuery();
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
