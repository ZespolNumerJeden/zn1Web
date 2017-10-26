using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace zn1Web.Utils
{
	public class AgendaGenerator
	{

		private const string fileName = "Agenda.xlsx";
		private string FilePath => Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files"), fileName);
		private List<AgendaClass> Agenda { get; set; } = new List<AgendaClass>();
		private XSSFWorkbook NpoiWorkbook { get; set; }
		private ISheet NpoiSheet { get; set; }
		public AgendaGenerator()
		{
			try
			{
				using (FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
				{
					NpoiWorkbook = new XSSFWorkbook(file);
				}
				NpoiSheet = NpoiWorkbook.GetSheetAt(0);
			}
			catch
			{
				throw new HttpException(404, "Cannot open/find a file :(");
			}


		}

		public IEnumerable<AgendaClass> GetAgenda()
		{
			try
			{
				var rows = NpoiSheet.LastRowNum;
				var columns = NpoiSheet.GetRow(0).LastCellNum;
				var attributes = typeof(AgendaClass).GetProperties()
					.Where(p => Attribute.IsDefined(p, typeof(DescriptionAttribute)));
				if (columns < attributes.Count())
				{
					throw new Exception("Wrong number of columns");
				}
				var columnsOrder = new Dictionary<int, string>();

				for (var i = 0; i < columns; i++)
				{

					columnsOrder.Add(i, NpoiSheet.GetRow(0).GetCell(i).StringCellValue);
				}
				for (var i = 1; i < rows; i++)
				{
					var ag = new AgendaClass();
					foreach (var propertyInfo in ag.GetType().GetProperties()
						.Where(p => Attribute.IsDefined(p, typeof(DescriptionAttribute))))
					{
						var att = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;
						var columnNumber = columnsOrder.FirstOrDefault(x => x.Value == att.Description);
						if (!propertyInfo.CanWrite)
						{
							continue;
						}
						string val = string.Empty;
						try
						{
							var type = NpoiSheet.GetRow(i).GetCell(columnNumber.Key).CellType;
							switch (type)
							{
								case CellType.String:
									val = NpoiSheet.GetRow(i).GetCell(columnNumber.Key).StringCellValue;
									break;
								case CellType.Numeric:
									val = NpoiSheet.GetRow(i).GetCell(columnNumber.Key).DateCellValue.ToString();
									break;
							}
						}
						catch
						{
							continue;
						}
						propertyInfo.SetValue(ag, val, null);
					}
					Agenda.Add(ag);
				}
			}
			catch
			{
				throw new HttpException(404," :(");
			}
			return Agenda;
		}

		public void Close()
		{
			NpoiWorkbook.Close();
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

		public DateTime DayTime
		{
			get
			{
				
				DateTime.TryParse(Time, out DateTime t);
				DateTime.TryParse(Date, out DateTime d);
				return d.Date + t.TimeOfDay;
			}
		}
	}
}