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
			GetExaminationLists();
		}
		private void GetExaminationLists()
		{
			using (var context = new Context())
			{
				ExaminationsListsDataGrid.ItemsSource = context.ExaminationsLists.ToList(); 
			}
		}

		private void OnMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var examinationsList = ExaminationsListsDataGrid?.SelectedItem as ExaminationsList;
			if (examinationsList == null) return;
			var selectedListId = examinationsList.ExaminationsListId;
			var examinationsListsWindow = new ExaminationListWindow(selectedListId) {Owner = this};
			examinationsListsWindow.ShowDialog();
		}
	}
}
