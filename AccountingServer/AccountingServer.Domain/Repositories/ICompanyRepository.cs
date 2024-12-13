using AccountingServer.Domain.Entities;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingServer.Domain.Repositories;

public interface ICompanyRepository:IRepository<Company>
{
}
