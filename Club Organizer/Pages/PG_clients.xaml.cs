using Club_Organizer.Class.C_PG_clients;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace Club_Organizer.Pages
{
	public partial class PG_clients : Page
	{
		string conn = @"Data Source=DB/clients.db;Version=3;";
		public static DataTable dt_client = new DataTable();

		public PG_clients()
		{
			InitializeComponent();
			data_update();
		}

		private void data_update()
		{
			dt_client = new DataTable();
			CL_clients_info.get_info();
			data_client.ItemsSource = dt_client.AsDataView();
		}

		private void client_update_Click(object sender, RoutedEventArgs e)
		{
			dt_client = new DataTable();
			data_update();
		}

		private void client_check_Click(object sender, RoutedEventArgs e)
		{
			CL_clients_info_update.update_clients_info();
			dt_client = new DataTable();
			data_update();
		}

		private void client_delete_Click(object sender, RoutedEventArgs e)
		{
			if (data_client.SelectedItem == null)
			{
				return;
			}
			else
			{
				DataRowView rowView = (DataRowView)data_client.SelectedItem;
				SQLiteConnection conn_data_del = new SQLiteConnection(conn);
				conn_data_del.Open();
				using (SQLiteCommand mCmd = new SQLiteCommand("DELETE FROM " +
					"clients_data WHERE ID=" + rowView["ID"], conn_data_del))
				{
					mCmd.ExecuteNonQuery();
				}
				conn_data_del.Close();
				dt_client = new DataTable();
				data_update();
			}
		}
	}
}
