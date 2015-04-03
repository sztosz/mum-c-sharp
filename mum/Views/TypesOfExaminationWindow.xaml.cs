using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using mum.Models;
using mum.ViewModels;

namespace mum.Views
{
    /// <summary>
    /// Interaction logic for TypesOfExaminationWindow.xaml
    /// </summary>
    public partial class TypesOfExaminationWindow : Window
    {
        private ObservableCollection<TypeOfExamination> _typesOfExaminationvViewModel;

        public TypesOfExaminationWindow()
        {
            InitializeComponent();
            _typesOfExaminationvViewModel = new TypesOfExaminationViewModel().TypesOfExamination;
            TypesOfExaminationsDataGrid.ItemsSource = _typesOfExaminationvViewModel;
            
        }

        private void AddNewTypeButton_Click(object sender, RoutedEventArgs e)
        {
            _typesOfExaminationvViewModel.Add(new TypeOfExamination {Name = NewTypeTextBox.Text });
        }
    }
}