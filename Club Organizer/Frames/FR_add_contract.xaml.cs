using System.Data.SQLite;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using Club_Organizer.Class.C_FR_add_contract;
using System;
using System.Windows.Media;
using System.Threading.Tasks;

namespace Club_Organizer.Frames
{
	public partial class FR_add_contract : Page
	{
		public static string fullname = null;
		public static string lastname_text = null;
		public static string name_text = null;
		public static string secondname_text = null;
		public static string fullname_text = null;
		public static string passport_num_text = null;
		public static string passport_date_text = null;
		public static string passport_who_text = null;
		public static string city_text = null;
		public static string street_text = null;
		public static string house_text = null;
		public static string subhouse_text = null;
		public static string flat_text = null;
		public static string phone_text = null;
		public static string email_text = null;
		public static string birthday_text = null;

		public FR_add_contract()
		{
			InitializeComponent();
			BindComboBox(search_client);
			frame_service_info.Navigate(new FR_service_tennis());
		}

		private void BindComboBox(ComboBox comboBoxName)
		{
			string conn = @"Data Source=DB/clients.db;Version=3;";
			string query_client_name = "SELECT id, fullname " +
				"FROM clients_data";

			SQLiteConnection db_conn = new SQLiteConnection(conn);
			db_conn.Open();
			SQLiteDataAdapter da = new SQLiteDataAdapter(query_client_name, db_conn);
			DataTable dt = new DataTable();
			da.Fill(dt);
			search_client.ItemsSource = dt.AsDataView();
			search_client.DisplayMemberPath = "fullname";
			search_client.SelectedValuePath = "id";
			db_conn.Close();
		}

		private void search_client_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			BindComboBox(search_client);
		}

		private async void client_check_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (search_client.Text != "")
			{
				if (search_client.Text != "Вы не выбрали клиента")
				{
					fullname = search_client.Text.Trim();
					CL_fill_client_info.get_info();

					lastname.Text = CL_fill_client_info.lastname;
					name.Text = CL_fill_client_info.name;
					secondname.Text = CL_fill_client_info.secondname;
					passport_num.Text = CL_fill_client_info.passport;
					passport_date.Text = CL_fill_client_info.passport_date;
					passport_who.Text = CL_fill_client_info.passport_who;
					city.Text = CL_fill_client_info.city;
					street.Text = CL_fill_client_info.street;
					house.Text = Convert.ToString(CL_fill_client_info.house);
					subhouse.Text = CL_fill_client_info.subhouse;
					flat.Text = Convert.ToString(CL_fill_client_info.flat);
					phone.Text = CL_fill_client_info.phone;
					email.Text = CL_fill_client_info.email;
					birthday.Text = CL_fill_client_info.birthday;
				}
				else
				{
					// pass
				}
			}
			else
			{
				search_client.Foreground = Brushes.Red;
				search_client.Text = "Вы не выбрали клиента";

				await Task.Delay(4000);

				search_client.Foreground = Brushes.Black;
				search_client.Text = "";
			}
		}

		private void client_clear_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			lastname.Text = "";
			name.Text = "";
			secondname.Text = "";
			passport_num.Text = "";
			passport_date.Text = "";
			passport_who.Text = "";
			city.Text = "";
			street.Text = "";
			house.Text = "";
			subhouse.Text = "";
			flat.Text = "";
			phone.Text = "";
			email.Text = "";
			birthday.Text = "";
		}

		private void write_new_client_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			lastname_text = lastname.Text.Trim();
			name_text = name.Text.Trim();
			secondname_text = secondname.Text.Trim();
			fullname_text = lastname.Text.Trim() + " " +
				name.Text.Substring(0, name.Text.Length - name.Text.Length + 1) + "." +
				secondname.Text.Substring(0, secondname.Text.Length - secondname.Text.Length + 1) + ".";
			passport_num_text = passport_num.Text.Trim();
			passport_date_text = passport_date.Text.Trim();
			passport_who_text = passport_who.Text.Trim();
			city_text = city.Text.Trim();
			street_text = street.Text.Trim();
			house_text = house.Text.Trim();
			subhouse_text = subhouse.Text.Trim();
			flat_text = flat.Text.Trim();
			phone_text = phone.Text.Trim();
			email_text = email.Text.Trim();
			birthday_text = birthday.Text.Trim();

			CL_new_client.new_client();
			BindComboBox(search_client);
		}
	}
}
