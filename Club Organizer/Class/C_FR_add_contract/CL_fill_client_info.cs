using Club_Organizer.Frames;
using System.Data.SQLite;

namespace Club_Organizer.Class.C_FR_add_contract
{
	internal class CL_fill_client_info
	{
		public static string lastname = null;
		public static string name = null;
		public static string secondname = null;
		public static string passport = null;
		public static string passport_date = null;
		public static string passport_who = null;
		public static string city = null;
		public static string street = null;
		public static int house = 0;
		public static string subhouse = null;
		public static int flat = 0;
		public static string phone = null;
		public static string email = null;
		public static string birthday = null;

		public static void get_info()
		{
			string conn = @"Data Source=DB/clients.db;Version=3;";
			string query = "SELECT * FROM clients_data " +
				"WHERE fullname=@fullname";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd = new SQLiteCommand(query, db_conn);
			cmd.Parameters.AddWithValue("@fullname", 
				FR_add_contract.fullname);
			SQLiteDataReader dr = null;
			dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				lastname = dr.GetString(dr.GetOrdinal("Фамилия")); 
				name = dr.GetString(dr.GetOrdinal("Имя"));
				secondname = dr.GetString(dr.GetOrdinal("Отчество"));
				passport = dr.GetString(dr.GetOrdinal("Паспорт"));
				passport_date = dr.GetString(dr.GetOrdinal("Выдан"));
				passport_who = dr.GetString(dr.GetOrdinal("Отдел"));
				city = dr.GetString(dr.GetOrdinal("Город"));
				street = dr.GetString(dr.GetOrdinal("Улица"));
				house = dr.GetInt32(dr.GetOrdinal("Дом"));
				subhouse = dr.GetString(dr.GetOrdinal("Корпус"));
				flat = dr.GetInt32(dr.GetOrdinal("Квартира"));
				phone = dr.GetString(dr.GetOrdinal("Телефон"));
				email = dr.GetString(dr.GetOrdinal("Email"));
				birthday = dr.GetString(dr.GetOrdinal("ДР"));
			}

		}
	}
}
