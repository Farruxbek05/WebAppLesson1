using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
	public class WorkTable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[ForeignKey("GroupId")]
		public Group? Group { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("SubjectId")]
		public Subject? Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
