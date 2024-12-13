using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using AccountingServer.Infrastructure.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingServer.Infrastructure.Repositories
{
    internal sealed class CompanyRepository: Repository<Company, ApplicationDbContext>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
