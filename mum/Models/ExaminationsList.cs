using System.Collections.Generic;
using mum.Helpers;

namespace mum.Models
{
	public class ExaminationsList
	{
		public int ExaminationsListId { get; set; }
		public Months Month { get; set; }
		public int Year { get; set; }
		public string Owner { get; set; }
		public int Rate { get; set; }
		public IList<Examination> Examinations { get; set; }

	}
}