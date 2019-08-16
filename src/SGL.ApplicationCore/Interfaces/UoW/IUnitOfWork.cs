using System;
using System.Collections.Generic;
using System.Text;

namespace SGL.ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
