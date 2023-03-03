using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public class DbContextAdapter : IUnitOfWork, IDisposable
    {
        private readonly SoftteckContext _context;

        public DbContextAdapter(SoftteckContext context)
        {
            _context = context;
        }

        protected SoftteckContext Context
        {
            get { return _context; }
        }


        public async Task<int> Save(bool validate = true)
        {
            //if (!validate)
            //    _context.Configuration.ValidateOnSaveEnabled = false;

            try
            {
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //catch (DbEntityValidationException ex)
            //{
            //    throw ex;
            //}
        }


        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                if (_context != null)
                    _context.Dispose();

            _disposed = true;
        }

        //public int Save(bool validate = true)
        //{
        //    try
        //    {
        //        var result = _context.SaveChanges();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

    }
}
