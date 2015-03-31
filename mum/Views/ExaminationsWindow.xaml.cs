using System.Linq;
using System.Windows;
using mum.Models;

namespace mum.Views
{
	/// <summary>
	/// Interaction logic for ExaminationListWindow.xaml
	/// </summary>
	public partial class ExaminationListWindow : Window
	{
		private readonly int _id;

		public ExaminationListWindow(int id)
		{
			InitializeComponent();
			this._id = id;
			SetExaminationsListDetails();
			GetExaminations();
		}
		private void SetExaminationsListDetails()
		{
			using (var context = new Context())
			{
				ExaminationsList examinationsList = context.ExaminationsLists.FirstOrDefault(e => e.ExaminationsListId == _id);
				if (examinationsList == null) return;
				OwnerLabel.Content = examinationsList.Owner;
				MonthLabel.Content = examinationsList.Month;
				YearLabel.Content = examinationsList.Year;
			}
		}
		private void GetExaminations()
		{
			using (var context = new Context())
			{
				var examinations = context.Examinations.Where(e => e.ExaminationsListId == _id).ToList();
				if (examinations.Any())
				{
					ExaminationsDataGrid.ItemsSource = examinations;
				}
			}
		}

		private void AddExaminationButton_Click(object sender, RoutedEventArgs e)
		{
			var addExaminationWindow = new AddExaminationWindow() { Owner = this };
			addExaminationWindow.ShowDialog();
			GetExaminations();
		}
	}
}
