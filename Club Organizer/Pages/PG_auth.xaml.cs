using Club_Organizer.Class;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Club_Organizer.Pages
{
	public partial class PG_auth : Page
	{
		public static string login_text = null;
		public static string pass_text = null;

		public PG_auth()
		{
			InitializeComponent();

			InputLanguageManager.SetInputLanguage(auth_login, CultureInfo.CreateSpecificCulture("en"));
			InputLanguageManager.SetInputLanguage(auth_pass, CultureInfo.CreateSpecificCulture("en"));
		}

		private async void auth_enter_Click(object sender, RoutedEventArgs e)
		{
			if (auth_login.Text == "" && auth_pass.Password == "")
			{
				dialog_auth.IsOpen = true;

				auth_login.IsEnabled = false;
				auth_pass.IsEnabled = false;

				auth_login.Foreground = Brushes.Red;
				auth_pass.Foreground = Brushes.Red;

				error_text.Text = "Вы не ввели данные";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;

				await Task.Delay(2500);

				auth_login.Foreground = Brushes.Black;
				auth_pass.Foreground = Brushes.Black;

				auth_login.IsEnabled = true;
				auth_pass.IsEnabled = true;
			}

			else if (auth_login.Text == "" && auth_pass.Password != "")
			{
				dialog_auth.IsOpen = true;

				auth_login.IsEnabled = false;

				auth_login.Foreground = Brushes.Red;

				error_text.Text = "Вы не ввели логин";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;

				await Task.Delay(2500);

				auth_login.Foreground = Brushes.Black;

				auth_login.IsEnabled = true;
			}

			else if (auth_login.Text != "" && auth_pass.Password == "")
			{
				dialog_auth.IsOpen = true;

				auth_pass.IsEnabled = false;

				auth_pass.Foreground = Brushes.Red;

				error_text.Text = "Вы не ввели пароль";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;

				await Task.Delay(2500);

				auth_pass.Foreground = Brushes.Black;

				auth_pass.IsEnabled = true;
			}

			else if (auth_login.Text != "" && auth_pass.Password != "")
			{
				auth_data();
			}

			else
			{
				dialog_auth.IsOpen = true;

				auth_login.IsEnabled = false;
				auth_pass.IsEnabled = false;

				error_text.Text = "Слишком много попыток входа";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;

				auth_login.IsEnabled = true;
				auth_pass.IsEnabled = true;
			}
		}

		private async void auth_data()
		{
			CL_auth.ok = false;

			login_text = auth_login.Text.Trim().ToLower();
			pass_text = auth_pass.Password.Trim().ToLower();

			CL_auth.auth();

			if (CL_auth.ok == true)
			{
				MainWindow.suc_auth();

				auth_login.Text = null;
				auth_pass.Password = null;

				login_text = null;
				pass_text = null;
			}

			else
			{
				dialog_auth.IsOpen = true;

				auth_login.IsEnabled = false;
				auth_pass.IsEnabled = false;

				auth_login.Foreground = Brushes.Red;
				auth_pass.Foreground = Brushes.Red;

				error_text.Text = "Вы ввели неверные данные";

				await Task.Delay(3000);

				dialog_auth.IsOpen = false;
				auth_pass.Password = null;

				await Task.Delay(2500);

				auth_login.Foreground = Brushes.Black;
				auth_pass.Foreground = Brushes.Black;

				auth_login.IsEnabled = true;
				auth_pass.IsEnabled = true;
			}
		}
	}
}
