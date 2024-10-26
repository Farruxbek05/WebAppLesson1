﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
	public class Student
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
        public string Name { get; set; }
		[ForeignKey("GroupId")]
		public Group? Group { get; set; }
		public int GroupId { get; set; }
		[ForeignKey("ContractId")]
		public Contract? Contract { get; set; }
        public int ContractId { get; set; }
    }
}
