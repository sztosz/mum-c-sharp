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
using System.Windows.Navigation;
using System.Windows.Shapes;
using mum.Helpers;
using mum.Models;

namespace mum.Views
{
	/// <summary>
	/// Interaction logic for AddListWindow.xaml
	/// </summary>
	public partial class AddListWindow : Window
	{
		public AddListWindow()
		{
			InitializeComponent();
			MonthsComboBox.ItemsSource = Enum.GetValues(typeof (Months));
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			Months month = 0;
			int year = 0;
			string owner = null;
			int rate = 0;
			// Month validation
			try
			{
				month = (Months)MonthsComboBox.SelectedItem;
			}
			catch (Exception)
			{
				ErrorTextBlock.Text = "Proszę wybrać miesiąć";
				return;
			}
			
			// Year validation
			try
			{
				year = Convert.ToInt32(YearTextBox.Text);
			}
			catch (FormatException)
			{
				ErrorTextBlock.Text = "Rok musi się składać z samych cyfr";
				return;
			}
			catch (OverflowException)
			{
				ErrorTextBlock.Text = "Podany rok jest zbyt dużą liczbą";
				return;
			}
			
			// Owner Validation
			owner = OwnerTextBox.Text;
			if (string.IsNullOrEmpty(owner))
			{
				ErrorTextBlock.Text = "Proszę podać Imię i Nazwisko Lekarza";
			}

			// Rate Validation
			try
			{
				rate = Convert.ToInt32(RateTextBox.Text);
			}
			catch (FormatException)
			{
				ErrorTextBlock.Text = "Stawka musi się składać z samych cyfr";
			}
			catch (OverflowException)
			{
				ErrorTextBlock.Text = "Podana stawka jest zbyt dużą liczbą";
			}
			using (var context = new Context())
			{
				ExaminationsList examinationsList = new ExaminationsList();
				examinationsList.Month = month;
				examinationsList.Year = year;
				examinationsList.Owner = owner;
				examinationsList.Rate = rate;

				context.ExaminationsLists.Add(examinationsList);
				context.SaveChanges();

				this.Close();
			}
		}
	}
}
