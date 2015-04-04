using mum.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity;
using System.Linq;

namespace mum.Views
{
    /// <summary>
    /// Interaction logic for AddExaminationWindow.xaml
    /// </summary>
    public partial class AddExaminationWindow : Window
    {
        public List<TypeOfExamination> TypesOfExamination { get ; } = new List<TypeOfExamination>(); 
        public AddExaminationWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            PopulateTypesOfExaminationComboBox();
        }

        private void PopulateTypesOfExaminationComboBox()
        {
            TypesOfExamination.Clear();
            using (var contex = new Context())
            {
                TypesOfExamination.AddRange(contex.TypeOfExaminations.ToList());
            }
            TypesOfExamiantionComboBox.Items.Refresh();

        }

        private void ExaminationTypeButton_Click(object sender, RoutedEventArgs e)
        {
            var typesOfExaminationsWindow = new TypesOfExaminationWindow() { Owner = this };
            typesOfExaminationsWindow.ShowDialog();
            PopulateTypesOfExaminationComboBox();
        }
    }
}
