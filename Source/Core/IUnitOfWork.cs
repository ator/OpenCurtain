using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCurtain.Core.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork Start();
        void Commit();
        void Rollback();
    }
}
