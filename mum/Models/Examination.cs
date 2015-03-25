using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mum.Models
{
	public class Examination
	{
		public int ExaminationId  { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public int Quantity { get; set; }
		public int TypeOfExaminationId { get; set; }
        public TypeOfExamination Type { get; set; }
		public int ExaminationsListId { get; set; }
		public ExaminationsList ExaminationsList { get; set; }

	}
}
