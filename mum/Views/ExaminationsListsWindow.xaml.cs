using System;
using System.Linq;
using System.Windows;
using mum.Models;

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
			GetExaminationLists();
			
		}

		private void OnAddNewList(object sender, RoutedEventArgs e)
		{
			var addListWindow = new AddListWindow {Owner = this};
			addListWindow.ShowDialog();
		}
		private void GetExaminationLists()
		{
			using (var context = new Context())
			{
				var query = context.ExaminationsLists;
				var results = query.ToList();

				Console.Write(results);

				ExaminationsListsDataGrid.ItemsSource = results;

			}
		}
	}
}
