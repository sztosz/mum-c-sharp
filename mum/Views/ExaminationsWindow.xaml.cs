using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using System.Windows.Shapes;
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
	}
}
