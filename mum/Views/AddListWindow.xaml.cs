using System;
using System.Windows;
using mum.Helpers;
using mum.Models;

namespace mum.Views
{
	/// <summary>
	/// Interaction logic for AddListWindow.xaml
	/// </summary>
	public partial class AddListWindow
	{
		public AddListWindow()
		{
			InitializeComponent();
			MonthsComboBox.ItemsSource = Enum.GetValues(typeof (Months));
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			Months month;
			int year;
			int rate;
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
			var owner = OwnerTextBox.Text;
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
				return;
			}
			catch (OverflowException)
			{
				ErrorTextBlock.Text = "Podana stawka jest zbyt dużą liczbą";
				return;
			}

			using (var context = new Context())
			{
				var examinationsList = new ExaminationsList {Month = month, Year = year, Owner = owner, Rate = rate};

				context.ExaminationsLists.Add(examinationsList);
				context.SaveChanges();

				Close();
			}
		}
	}
}
