using Club_Organizer.Class.C_PG_services;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace Club_Organizer.Pages
{
	public partial class PG_services : Page
	{
		// - Переменные - \\
		string conn = @"Data Source=DB/services.db;Version=3;";
		public static DataTable dt_service = new DataTable();

		public PG_services()
		{
			InitializeComponent();
			data_update();
		}

		// - Получение и вывод данных из БД - \\
		private void data_update()
		{
			dt_service = new DataTable();
			CL_services_info.get_info();
			data_service.ItemsSource = dt_service.AsDataView();
		}

		// - Обновление данных в таблице - \\
		private void service_update_Click(object sender, RoutedEventArgs e)
		{
			dt_service = new DataTable();
			data_update();
		}

		// - Запись обновленных данных в БД - \\
		private void service_check_Click(object sender, RoutedEventArgs e)
		{
			CL_services_update.update_services_info();
			dt_service = new DataTable();
			data_update();
		}

		// - Удаление записей из БД - \\
		private void service_delete_Click(object sender, RoutedEventArgs e)
		{
			if (data_service.SelectedItem == null)
			{
				return;
			}
			else
			{
				DataRowView rowView = (DataRowView)data_service.SelectedItem;
				SQLiteConnection conn_data_del = new SQLiteConnection(conn);
				conn_data_del.Open();
				using (SQLiteCommand mCmd = new SQLiteCommand("DELETE FROM " +
					"servicesdata WHERE ID=" + rowView["ID"], conn_data_del))
				{
					mCmd.ExecuteNonQuery();
				}
				conn_data_del.Close();
				dt_service = new DataTable();
				data_update();
			}
		}
	}
}
