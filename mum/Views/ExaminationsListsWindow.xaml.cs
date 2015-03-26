using System.Windows;

namespace mum.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnAddNewList(object sender, RoutedEventArgs e)
		{
			var addListWindow = new AddListWindow();
			addListWindow.Show();
		}
	}
}
