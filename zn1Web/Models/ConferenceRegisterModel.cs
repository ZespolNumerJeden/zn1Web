using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace zn1Web.Models
{
	public class ConferenceRegisterModel
	{
			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			[Required]
			[EmailAddress]
			[Display(Name = "ConfirmEmail")]
			[Compare("Email", ErrorMessage = "The emails do not match.")]
			public string ConfirmEmail { get; set; }

			[Required]
			[DataType(DataType.Text)]
			[Display(Name = "Name")]
			public string Name { get; set; }

			[Required]
			[DataType(DataType.Text)]
			[Display(Name = "Surname")]
			public string Surname { get; set; }


			[Phone]
			[Display(Name = "Phone")]
			public string Phone { get; set; }
		}
}