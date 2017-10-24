using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zn1Web.Utils;

namespace zn1Web.Models
{
	public class AgendaViewModel
	{
		public IEnumerable<AgendaClass> Agenda { get; set; }

		public List<IGrouping<int, AgendaClass>>Grouped => Agenda.GroupBy(x => x.DayTime.Day).ToList();
	}
}