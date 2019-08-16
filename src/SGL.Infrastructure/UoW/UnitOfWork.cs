using SGL.ApplicationCore.Interfaces;
using SGL.Infrastructure.Data;
using System;

namespace SGL.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SGLContext _context;
        private bool _disposed;

        public UnitOfWork(SGLContext context)
        {
            _context = context;
            _disposed = false;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
