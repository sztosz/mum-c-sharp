using System;
using System.Linq;
using System.Windows;
using mum.Models;

namespace mum.Views
{
	/// <summary>
	/// Interaction logic for TypesOfExaminationsWindow.xaml
	/// </summary>
	public partial class TypesOfExaminationsWindow : Window
	{
		public TypesOfExaminationsWindow()
		{
			InitializeComponent();
			GetTypesOfExaminations();
		}

		private void GetTypesOfExaminations()
		{
			using (var context = new Context())
			{
				var a = context.TypeOfExaminations.ToList();
				TypesOfExaminationsDataGrid.ItemsSource = a;
			}
		
		}

		private void AddNewTypeButton_Click(object sender, RoutedEventArgs e)
		{
			using (var context = new Context())
			{
				TypeOfExamination typeOfExamination = new TypeOfExamination {Name = NewTypeTextBox.Text};
				context.TypeOfExaminations.Add(typeOfExamination);
				int a = context.SaveChanges();
				Console.Write(a);
			}
			GetTypesOfExaminations();

		}
	}
}
