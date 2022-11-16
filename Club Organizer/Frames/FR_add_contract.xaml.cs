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

		public FR_add_contract()
		{
			InitializeComponent();
			BindComboBox(search_client);
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
					secontname.Text = CL_fill_client_info.secondname;
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
			secontname.Text = "";
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

		}
	}
}
