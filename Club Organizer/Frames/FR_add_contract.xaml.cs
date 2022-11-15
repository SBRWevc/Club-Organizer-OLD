using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Club_Organizer.Frames
{
	public partial class FR_add_contract : Page
	{
		public FR_add_contract()
		{
			InitializeComponent();
			BindComboBox(search_client);
		}

		private void BindComboBox(ComboBox comboBoxName)
		{
			string conn = @"Data Source=DB/clients.db;Version=3;";
			string query_client_name = "SELECT id, fullname " +
				"FROM clients";

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
	}
}
