using Club_Organizer.Frames;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
