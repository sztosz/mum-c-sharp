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
        private TypesOfExaminationViewModel _viewModel;

        public TypesOfExaminationWindow()
        {
            InitializeComponent();
            _viewModel = new TypesOfExaminationViewModel();
            TypesOfExaminationsDataGrid.ItemsSource = _viewModel.TypesOfExamination;
            
        }

        private void AddNewTypeButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.TypesOfExamination.Add(new TypeOfExamination {Name = NewTypeTextBox.Text });
        }

        private void TypesOfExaminationsDataGrid_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            _viewModel.ChangeTypeOfExaminationInDatabse((TextBox)e.TargetObject);
        }
    }
}