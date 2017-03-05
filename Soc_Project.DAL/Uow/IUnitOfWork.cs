using Soc_Project.DAL.Entities;
using Soc_Project.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.DAL.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> Persons { get; }

        IRepository<Job> Jobs { get; }

        IRepository<Organization> Organizations { get; }

        void Save();
    }
}
