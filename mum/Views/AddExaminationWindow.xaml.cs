using System.Windows;

namespace mum.Views
{
	/// <summary>
	/// Interaction logic for AddExaminationWindow.xaml
	/// </summary>
	public partial class AddExaminationWindow : Window
	{
		public AddExaminationWindow()
		{
			InitializeComponent();
		}

		private void ExaminationTypeButton_Click(object sender, RoutedEventArgs e)
		{
			var typesOfExaminationsWindow = new TypesOfExaminationsWindow() { Owner = this };
			typesOfExaminationsWindow.ShowDialog();
		}
	}
}
