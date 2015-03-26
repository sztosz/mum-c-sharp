using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace mum.Models
{
	internal class Context : DbContext
	{
		public Context() : base()
		{
		}

		public DbSet<Examination> Examinations { get; set; }
		public DbSet<ExaminationsList> ExaminationsLists { get; set; }
		public DbSet<TypeOfExamination> TypeOfExaminations { get; set; }
	}
}