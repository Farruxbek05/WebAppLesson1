using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Context;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repository
{
	public class StudentRepository : Repository<Student>, IStudentRepository
	{
		private readonly AppDbContext _appDbContext;
		public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}

	}
}
