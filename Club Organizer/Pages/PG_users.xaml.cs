using Club_Organizer.Class;
using Club_Organizer.Class.C_PG_users;
using Club_Organizer.Class.PG_users;
using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Club_Organizer.Pages
{
	public partial class PG_users : Page
	{
		public static string lastname_text = null;
		public static string name_text = null;
		public static string secondname_text = null;
		public static string gender_text = "муж";
		public static string position_text = null;
		public static string login_text = null;
		public static string pass_text = null;
		public static int root_text = 0;

		string conn = @"Data Source=DB/users.db;Version=3;";
		public static DataTable dt_users = new DataTable();

		public PG_users()
		{
			InitializeComponent();
			data_update();
			datatext();
			InputLanguageManager.SetInputLanguage(login, CultureInfo.CreateSpecificCulture("en"));
			InputLanguageManager.SetInputLanguage(pass, CultureInfo.CreateSpecificCulture("en"));
			InputLanguageManager.SetInputLanguage(lastname, CultureInfo.CreateSpecificCulture("ru"));
			InputLanguageManager.SetInputLanguage(name, CultureInfo.CreateSpecificCulture("ru"));
			InputLanguageManager.SetInputLanguage(secondname, CultureInfo.CreateSpecificCulture("ru"));
			InputLanguageManager.SetInputLanguage(position, CultureInfo.CreateSpecificCulture("ru"));
		}

		private async void datatext()
		{
			while (true)
			{
				await Task.Delay(1);
				name_left.Text = name.Text.Trim();
				lastname_left.Text = lastname.Text.Trim();
				secondname_left.Text = secondname.Text.Trim();
				position_left.Text = position.Text.Trim();
			}
		}

		public void data_update()
		{
			dt_users = new DataTable();
			CL_users_info.get_info();
			data_users.ItemsSource = dt_users.AsDataView();
		}

		private void users_update_Click(object sender, RoutedEventArgs e)
		{
			dt_users = new DataTable();
			data_update();
		}

		private void users_check_Click(object sender, RoutedEventArgs e)
		{
			CL_users_info_update.update_users_info();
			dt_users = new DataTable();
			data_update();
		}

		private void gender_man_Click(object sender, RoutedEventArgs e)
		{
			avatar_left.Source = new BitmapImage(new Uri("/res/avatar/man.png", UriKind.Relative));
			gender_text = "муж";
		}

		private void gender_woman_Click(object sender, RoutedEventArgs e)
		{
			avatar_left.Source = new BitmapImage(new Uri("/res/avatar/woman.png", UriKind.Relative));
			gender_text = "жен";
		}

		private async void add_user_Click(object sender, RoutedEventArgs e)
		{
			lastname_text = lastname.Text.Trim();
			name_text = name.Text.Trim();
			secondname_text = secondname.Text.Trim();
			position_text = position.Text.Trim();
			login_text = login.Text.Trim();
			pass_text = pass.Password.Trim();

			if (position_text == "Управляющий" || position_text == "Директор")
			{
				root_text = 1;
			}

			else
			{
				root_text = 0;
			}

			if (lastname_text == "")
			{
				lastname.Foreground = Brushes.Red;

				await Task.Delay(2000);

				lastname.Foreground = Brushes.Black;
			}

			else if (name_text == "")
			{
				name.Foreground = Brushes.Red;

				await Task.Delay(2000);

				name.Foreground = Brushes.Black;
			}

			else if (secondname_text == "")
			{
				secondname.Foreground = Brushes.Red;

				await Task.Delay(2000);

				secondname.Foreground = Brushes.Black;
			}

			else if (position_text == "")
			{
				position.Foreground = Brushes.Red;

				await Task.Delay(2000);

				position.Foreground = Brushes.Black;
			}

			else if (login_text == "")
			{
				login.Foreground = Brushes.Red;

				await Task.Delay(2000);

				login.Foreground = Brushes.Black;
			}

			else if (pass_text == "")
			{
				pass.Foreground = Brushes.Red;

				await Task.Delay(2000);

				pass.Foreground = Brushes.Black;
			}

			else
			{
				CL_users_info_check.checkinfo();

				if (CL_users_info_check.ok == false)
				{
					login.Foreground = Brushes.Red;
					login.Text = "Такой логин уже используется";

					await Task.Delay(2000);

					login.Foreground = Brushes.Black;
					login.Text = null;
				}
				else
				{
					add_user_dialog.IsOpen = false;

					dt_users = new DataTable();

					data_update();
				}
			}
		}

		private void users_delete_Click(object sender, RoutedEventArgs e)
		{
			if (data_users.SelectedItem == null)
			{
				return;
			}
			else
			{
				DataRowView rowView = (DataRowView)data_users.SelectedItem;
				SQLiteConnection conn_data_del = new SQLiteConnection(conn);
				conn_data_del.Open();
				using (SQLiteCommand mCmd = new SQLiteCommand("DELETE FROM userdata WHERE ID=" + rowView["ID"], conn_data_del))
				{
					mCmd.ExecuteNonQuery();
				}
				conn_data_del.Close();
				dt_users = new DataTable();
				data_update();
			}
		}

		private void add_user_dialog_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
		{
			lastname.Text = "";
			name.Text = "";
			secondname.Text = "";
			position.Text = "";
			login.Text = "";
			pass.Password = "";
		}
	}
}
