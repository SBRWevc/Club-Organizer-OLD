using Club_Organizer.Frames;
using System;
using System.Data.SQLite;

namespace Club_Organizer.Class.C_FR_add_contract
{
	internal class CL_new_client
	{
		public static void new_client()
		{
			string conn = @"Data Source=DB/clients.db;Version=3;";
			string query = "INSERT INTO clients_data (Фамилия, Имя, Отчество, " +
				"fullname, Паспорт, Выдан, Отдел, Город, Улица, Дом," +
				"Корпус, Квартира, Телефон, Email, ДР, Зарегестрирован, Администратор) " +
				"VALUES (@lastname, @name, @secondname, @fullname, @passport, @passport_date, " +
				"@passport_who, @city, @street, @house, @subhouse, @flat, @phone," +
				"@email, @birthday, @registration, @admin)";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteCommand cmd_add = new SQLiteCommand(query, db_conn);
			cmd_add.Parameters.AddWithValue("@lastname", FR_add_contract.lastname_text);
			cmd_add.Parameters.AddWithValue("@name", FR_add_contract.name_text);
			cmd_add.Parameters.AddWithValue("@secondname", FR_add_contract.secondname_text);
			cmd_add.Parameters.AddWithValue("@fullname", FR_add_contract.fullname_text);
			cmd_add.Parameters.AddWithValue("@passport", FR_add_contract.passport_num_text);
			cmd_add.Parameters.AddWithValue("@passport_date", FR_add_contract.passport_date_text);
			cmd_add.Parameters.AddWithValue("@passport_who", FR_add_contract.passport_who_text);
			cmd_add.Parameters.AddWithValue("@city", FR_add_contract.city_text);
			cmd_add.Parameters.AddWithValue("@street", FR_add_contract.street_text);
			cmd_add.Parameters.AddWithValue("@house", Convert.ToInt32(FR_add_contract.house_text));
			cmd_add.Parameters.AddWithValue("@subhouse", FR_add_contract.subhouse_text);
			cmd_add.Parameters.AddWithValue("@flat", Convert.ToInt32(FR_add_contract.flat_text));
			cmd_add.Parameters.AddWithValue("@phone", FR_add_contract.phone_text);
			cmd_add.Parameters.AddWithValue("@email", FR_add_contract.email_text);
			cmd_add.Parameters.AddWithValue("@birthday", FR_add_contract.birthday_text);
			cmd_add.Parameters.AddWithValue("@registration", DateTime.Today.ToString("d.M.yyyy"));
			cmd_add.Parameters.AddWithValue("@admin", CL_userdata.lastname + " " +
				CL_userdata.name.Substring(0, CL_userdata.name.Length -
				CL_userdata.name.Length + 1) + "." +
				CL_userdata.secondname.Substring(0,
				CL_userdata.secondname.Length -
				CL_userdata.secondname.Length + 1) + ".");
			cmd_add.ExecuteNonQuery();
			db_conn.Close();
		}
	}
}
