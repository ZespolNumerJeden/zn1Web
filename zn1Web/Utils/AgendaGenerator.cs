using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Ajax.Utilities;
using Microsoft.Office.Interop.Excel;


namespace zn1Web.Utils
{
	public class AgendaGenerator
	{

		private const string fileName = "Agenda.xlsx";
		private string filePath => Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files"), fileName);
		private byte[] FileBytes { get; set; }
		private Application ExcelApp { get; set; }
		private Workbook ExcelWorkbook { get; set; }
		private Worksheet ExcelWorksheet { get; set; }
		private Range ExcelRange { get; set; }
		private List<AgendaClass> Agenda { get; set; } = new List<AgendaClass>();

		public AgendaGenerator()
		{

			ExcelApp = new Application();
			ExcelWorkbook = ExcelApp.Workbooks.Open(filePath);
			ExcelWorksheet = (Worksheet) ExcelWorkbook.Worksheets.get_Item(1);

		}

		public IEnumerable<AgendaClass> GetAgenda()
		{
			var rows = ExcelWorksheet.UsedRange.Rows.Count;
			var columns = ExcelWorksheet.UsedRange.Columns.Count;
			var attributes = typeof(AgendaClass).GetProperties().Where(p => Attribute.IsDefined(p, typeof(DescriptionAttribute)));
			if (columns < attributes.Count())
			{
				throw new Exception("Wrong number of columns");
			}
			var columnsOrder =  new Dictionary<int, string>();

			for (var i = 0; i < columns; i++)
			{

				columnsOrder.Add(i + 1, ExcelWorksheet.Cells[1, i + 1].Text);
			}
			

			for (var i = 1; i < rows; i++)
			{
				var ag = new AgendaClass();
				foreach (var propertyInfo in ag.GetType().GetProperties().Where(p=> Attribute.IsDefined(p,typeof(DescriptionAttribute))))
				{
					var att = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;
					var columnNumber = columnsOrder.FirstOrDefault(x => x.Value == att.Description);
					if (null == propertyInfo || !propertyInfo.CanWrite)
					{
						continue;
					}

					var val = ExcelWorksheet.Cells[i + 1, columnNumber.Key].Text;
					propertyInfo.SetValue(ag, val, null);
				}
				Agenda.Add(ag);
			}
			Agenda.Sort((a, b) => a.DateTime.CompareTo(b.DateTime));
			return Agenda;
		}

		public void Close()
		{
			ExcelWorkbook.Close();
			ExcelApp.Quit();
		}
	}

	public class AgendaClass
	{
		[Description("Data")]
		public string Date { get; set; }
		[Description("Godzina")]
		public string Time { get; set; }
		[Description("Opis")]
		public string Description { get; set; }
		[Description("Prelegent")]
		public string Presenter { get; set; }
		[Description("Tytuł")]
		public string Title { get; set; }

		public DateTime DateTime
		{
			get
			{
				DateTime.TryParse($"{Date} {Time}", out DateTime dt);
				return dt;
			}
		}
	}
}