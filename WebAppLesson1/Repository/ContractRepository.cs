﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Context;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repository
{
	public class ContractRepository : Repository<Contract>, IContractRepository
	{
		private readonly AppDbContext _appDbContext;
		public ContractRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}
		
	}
}
