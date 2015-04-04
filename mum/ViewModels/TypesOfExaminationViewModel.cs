using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mum.Models;
using System.Windows.Controls;

namespace mum.ViewModels
{
    class TypesOfExaminationViewModel
    {
        public ObservableCollection<TypeOfExamination> TypesOfExamination { get; }

        public TypesOfExaminationViewModel()
        {
            using (var contex = new Context())
            {
                TypesOfExamination = new ObservableCollection<TypeOfExamination>(contex.TypeOfExaminations.ToList());
            }
            TypesOfExamination.CollectionChanged += OnTypesOfExaminationChanged; 
        }

        private void OnTypesOfExaminationChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action.Equals(NotifyCollectionChangedAction.Remove))
            {
                foreach (TypeOfExamination item in args.OldItems)
                {
                    Console.Write(item);
                }
            }
            if (args.Action.Equals(NotifyCollectionChangedAction.Add))
            {
                foreach (TypeOfExamination item in args.NewItems)
                {
                    AddTypeOfExaminationToDatabase(item);
                }
            }
        }

        private void AddTypeOfExaminationToDatabase(TypeOfExamination item)
        {
            using (var context = new Context())
            {
                context.TypeOfExaminations.Add(item);
                context.SaveChanges();
            }
        }

        public void ChangeTypeOfExaminationInDatabse(TextBox item)
        {
            TypeOfExamination typeOfExamination;
            try
            {
                typeOfExamination = (TypeOfExamination)item.DataContext;
            }
            catch (InvalidCastException)
            {
                throw;
            }

            using (var context = new Context())
            {
                context.TypeOfExaminations.Add(typeOfExamination);
                context.Entry(typeOfExamination).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
