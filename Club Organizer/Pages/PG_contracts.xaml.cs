using Club_Organizer.Frames;
using System;
using System.Collections.Generic;
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

namespace Club_Organizer.Pages
{
	public partial class PG_contracts : Page
	{
		public PG_contracts()
		{
			InitializeComponent();
			frame_new_contract.Navigate(new FR_add_contract());
		}

		public static void close_dialog()
		{
			PG_contracts contract = Application.Current.Windows.OfType<PG_contracts>().FirstOrDefault();
			contract.add_contract_dialog.IsOpen= false;
		}
	}
}
