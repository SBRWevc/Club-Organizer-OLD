using Club_Organizer.Class;
using Club_Organizer.Pages;
using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Club_Organizer
{
	public partial class MainWindow : MetroWindow
	{
		public static string prof_login = null;
		public static string prof_pass = null;

		public MainWindow()
		{
			InitializeComponent();

			// - Основные вкладки - \\
			main_page.Visibility = Visibility.Collapsed;
			contracts_page.Visibility = Visibility.Collapsed;
			clients_page.Visibility = Visibility.Collapsed;
			reports_page.Visibility = Visibility.Collapsed;
			settings_page.Visibility = Visibility.Collapsed;
			profile.Visibility = Visibility.Collapsed;
			exit.Visibility = Visibility.Collapsed;

			// - Вкладки настроек - \\
			users_page.Visibility = Visibility.Collapsed;
			services_page.Visibility = Visibility.Collapsed;

			// - Вкладки клиентов - \\
			blacklist_page.Visibility = Visibility.Collapsed;

			frame_main.Navigate(new PG_auth());

			// - Языковые настройки для полей - \\
			InputLanguageManager.SetInputLanguage(profile_login, CultureInfo.CreateSpecificCulture("en"));
			InputLanguageManager.SetInputLanguage(profile_pass, CultureInfo.CreateSpecificCulture("en"));
		}

		// - Отображение интерфейса при успешной авторизации - \\
		public static void suc_auth()
		{
			MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

			if (main.profile_host.IsBottomDrawerOpen != false)
			{
				main.profile_host.IsBottomDrawerOpen = false;
			}

			CL_userdata.clerdatauser();

			CL_userdata.getdatauser();

			// - Основные вкладки - \\
			main.main_page.Visibility = Visibility.Visible;
			main.contracts_page.Visibility = Visibility.Visible;
			main.clients_page.Visibility = Visibility.Visible;
			main.reports_page.Visibility = Visibility.Visible;
			main.settings_page.Visibility = Visibility.Visible;
			main.profile.Visibility = Visibility.Visible;
			main.exit.Visibility = Visibility.Visible;

			// - Вкладки настроек - \\
			main.users_page.Visibility = Visibility.Collapsed;
			main.services_page.Visibility = Visibility.Collapsed;

			// - Вывод данных пользователя - \\
			main.profile.Content = CL_userdata.lastname + " " + 
				CL_userdata.name.Substring(0, CL_userdata.name.Length - 
				CL_userdata.name.Length + 1) + "." +
				CL_userdata.secondname.Substring(0, 
				CL_userdata.secondname.Length - 
				CL_userdata.secondname.Length + 1) + ".";
			main.fullname.Text = CL_userdata.lastname + " " + 
				CL_userdata.name + " " + CL_userdata.secondname;
			main.profile_login.Text = CL_userdata.login;
			main.profile_position.Text = CL_userdata.position;

			if (CL_userdata.gender == "жен")
			{
				main.avatar.Source = new BitmapImage(new Uri
					("/res/avatar/woman.png", UriKind.Relative));
			}
			else if (CL_userdata.gender == "муж")
			{
				if (main.fullname.Text == "Ляхов Дмитрий Сергеевич")
				{
					main.avatar.Source = new BitmapImage(new Uri
					("/res/avatar/dev.png", UriKind.Relative));
				}
				else
				{
					main.avatar.Source = new BitmapImage(new Uri
						("/res/avatar/man.png", UriKind.Relative));
				}
			}
			else
			{
				main.avatar.Source = new BitmapImage(new Uri
					("/res/avatar/neutral.png", UriKind.Relative));
			}

			main.frame_main.Navigate(new PG_main());
		}

		// - Кнопка вызова главной вкладки - \\
		private void main_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
			
			// - Основные вкладки - \\
			main.main_page.Visibility = Visibility.Visible;
			main.contracts_page.Visibility = Visibility.Visible;
			main.clients_page.Visibility = Visibility.Visible;
			main.reports_page.Visibility = Visibility.Visible;
			main.settings_page.Visibility = Visibility.Visible;
			main.profile.Visibility = Visibility.Visible;
			main.exit.Visibility = Visibility.Visible;

			// - Вкладки настроек - \\
			users_page.Visibility = Visibility.Collapsed;
			services_page.Visibility = Visibility.Collapsed;

			// - Вкладки клиентов - \\
			blacklist_page.Visibility = Visibility.Collapsed;

			main.frame_main.Navigate(new PG_main());
		}

		// - Кнопка вызова вкладки договоров - \\
		private void contracts_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

			// - Основные вкладки - \\
			main.main_page.Visibility = Visibility.Visible;
			main.contracts_page.Visibility = Visibility.Visible;
			main.clients_page.Visibility = Visibility.Visible;
			main.reports_page.Visibility = Visibility.Visible;
			main.settings_page.Visibility = Visibility.Visible;
			main.profile.Visibility = Visibility.Visible;
			main.exit.Visibility = Visibility.Visible;

			// - Вкладки настроек - \\
			users_page.Visibility = Visibility.Collapsed;
			services_page.Visibility = Visibility.Collapsed;

			// - Вкладки клиентов - \\
			blacklist_page.Visibility = Visibility.Collapsed;

			main.frame_main.Navigate(new PG_contracts());
		}

		// - Кнопка вызова вкладки клиентов - \\
		private void clients_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

			// - Основные вкладки - \\
			main.contracts_page.Visibility = Visibility.Collapsed;
			main.reports_page.Visibility = Visibility.Collapsed;

			// - Вкладки настроек - \\
			users_page.Visibility = Visibility.Collapsed;
			services_page.Visibility = Visibility.Collapsed;

			// = Вкладки клиентов - \\
			blacklist_page.Visibility = Visibility.Visible;

			main.frame_main.Navigate(new PG_clients());
		}

		// - Кнопка вызова вкладки отчётов - \\
		private void reports_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}
		}

		// - Кнопка вызова настроек - \\
		private void settings_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

			// - Основные вкладки - \\
			main.contracts_page.Visibility = Visibility.Collapsed;
			main.clients_page.Visibility = Visibility.Collapsed;
			main.reports_page.Visibility = Visibility.Collapsed;

			// - Вкладки настроек - \\
			users_page.Visibility = Visibility.Visible;
			services_page.Visibility = Visibility.Visible;

			// = Вкладки клиентов - \\
			blacklist_page.Visibility = Visibility.Collapsed;

			main.frame_main.Navigate(new PG_users());
		}

		// - Кнопка вызова окна профиля - \\
		private void profile_Click(object sender, RoutedEventArgs e)
		{
			CL_userdata.clerdatauser();

			CL_userdata.getdatauser();

			profile_login.Text = CL_userdata.login;

			profile.Content = CL_userdata.lastname + " " + 
				CL_userdata.name.Substring(0, CL_userdata.name.Length - 
				CL_userdata.name.Length + 1) + "." +
				CL_userdata.secondname.Substring(0, 
				CL_userdata.secondname.Length - 
				CL_userdata.secondname.Length + 1) + ".";

			fullname.Text = CL_userdata.lastname + " " +
				CL_userdata.name + " " + CL_userdata.secondname;

			profile_position.Text = CL_userdata.position;

			if (CL_userdata.gender == "жен")
			{
				avatar.Source = new BitmapImage(new Uri
					("/res/avatar/woman.png", UriKind.Relative));
			}
			else if (CL_userdata.gender == "муж")
			{
				if (fullname.Text == "Ляхов Дмитрий Сергеевич")
				{
					avatar.Source = new BitmapImage(new Uri
					("/res/avatar/dev.png", UriKind.Relative));
				}
				else
				{
					avatar.Source = new BitmapImage(new Uri
						("/res/avatar/man.png", UriKind.Relative));
				}
			}
			else
			{
				avatar.Source = new BitmapImage(new Uri
					("/res/avatar/neutral.png", UriKind.Relative));
			}

			profile_host.IsBottomDrawerOpen = true;
		}

		// - Кнопка выхода из текущего профиля - \\
		private void exit_Click(object sender, RoutedEventArgs e)
		{
			MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			// - Основные вкладки - \\
			main.main_page.Visibility = Visibility.Collapsed;
			main.contracts_page.Visibility = Visibility.Collapsed;
			main.clients_page.Visibility = Visibility.Collapsed;
			main.reports_page.Visibility = Visibility.Collapsed;
			main.settings_page.Visibility = Visibility.Collapsed;
			main.profile.Visibility = Visibility.Collapsed;
			main.exit.Visibility = Visibility.Collapsed;

			// - Вкладки настроек - \\
			users_page.Visibility = Visibility.Collapsed;
			services_page.Visibility = Visibility.Collapsed;

			// = Вкладки клиентов - \\
			blacklist_page.Visibility = Visibility.Collapsed;

			main.frame_main.Navigate(new PG_auth());
			CL_userdata.clerdatauser();
		}

		// - Вкладка пользователей - \\
		private void users_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
			main.frame_main.Navigate(new PG_users());
		}

		// - Вкладка услуг - \\
		private void services_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
			main.frame_main.Navigate(new PG_services());
		}

		// - Вкладка чёрного списка - \\
		private void blacklist_page_Click(object sender, RoutedEventArgs e)
		{
			if (profile_host.IsBottomDrawerOpen != false)
			{
				profile_host.IsBottomDrawerOpen = false;
			}
		}

		// - Кнопка обновления данных пользователя - \\
		private void profile_save_button_Click(object sender, RoutedEventArgs e)
		{
			if (PG_auth.login_text == profile_login.Text && profile_pass.Password.Trim().ToLower() == "")
			{
				profile_host.IsBottomDrawerOpen = false;
			}

			else if (PG_auth.login_text != profile_login.Text && profile_pass.Password.Trim().ToLower() == "")
			{
				prof_login = profile_login.Text.Trim().ToLower();
				CL_update_cur_user.login_update();
				CL_userdata.getdatauser();
				profile_host.IsBottomDrawerOpen = false;
			}

			else if (PG_auth.login_text == profile_login.Text && profile_pass.Password.Trim().ToLower() != "")
			{
				prof_pass = profile_pass.Password.Trim().ToLower();
				CL_update_cur_user.pass_update();
				CL_userdata.getdatauser();
				profile_host.IsBottomDrawerOpen = false;
			}

			else
			{
				prof_login = profile_login.Text.Trim().ToLower();
				prof_pass = profile_pass.Password.Trim().ToLower();
				CL_update_cur_user.all_update();
				CL_userdata.getdatauser();
				profile_host.IsBottomDrawerOpen = false;
			}
		}
	}
}
