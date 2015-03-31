using System.Collections;
using System.Collections.Generic;

namespace mum.Models
{
	public class TypeOfExamination
	{
		public int TypeOfExaminationId { get; set; }
		public string Name { get; set; }

		public IList<Examination> Examinations { get; set; }
	}
}