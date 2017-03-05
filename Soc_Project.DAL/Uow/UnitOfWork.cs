using Soc_Project.DAL.EF;
using Soc_Project.DAL.Entities;
using Soc_Project.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.DAL.Uow
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly SocContext _context;

        private IRepository<Person> _persons;
        public IRepository<Person> Persons
        {
            get { return _persons ?? (_persons = new Repository<Person>(_context)); }
        }

        private IRepository<Job> _jobs;
        public IRepository<Job> Jobs
        {
            get { return _jobs ?? (_jobs = new Repository<Job>(_context)); }
        }

        private IRepository<Organization> _organizations;
        public IRepository<Organization> Organizations
        {
            get { return _organizations ?? (_organizations = new Repository<Organization>(_context)); }
        }

        #region Constructor 

        public UnitOfWork(SocContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion

        #region Disposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        #endregion
    }
}
