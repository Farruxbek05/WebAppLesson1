using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Context;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repository
{
	public class GroupRepository : Repository<Group>, IGroupRepository
	{
		private readonly AppDbContext _appDbContext;
		public GroupRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}

	}
}
