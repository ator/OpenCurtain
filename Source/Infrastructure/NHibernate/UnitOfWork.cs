using System;
using NHibernate;
using OpenCurtain.Core.Services;

namespace OpenCurtain.Infrastructure.NHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private static ISession session;
        private static ITransaction transaction;
        private bool isTransactionStarter = false;
        private static bool flagCommit = false;
        private static bool flagRollback = false;
        
        public ISession Session { get { return session; } }

        public UnitOfWork(ISession session)
        {
            UnitOfWork.session = session;
        }

        protected UnitOfWork()
        {
            if (transaction == null)
            {
                transaction = Session.BeginTransaction();
                isTransactionStarter = true;
            }
        }

        public IUnitOfWork Start()
        {
            return new UnitOfWork();
        }
        
        public void Commit()
        {
            if (transaction != null)
            {
                flagCommit = true;
            }
            else
            {
                throw new InvalidOperationException("Unit of work not started");
            }
        }
        
        public void Rollback()
        {
            if (transaction != null)
            {
                flagRollback = true;
            }
            else
            {
                throw new InvalidOperationException("Unit of work not started");
            }
        }

        public void Dispose()
        {
            if (isTransactionStarter)
            {
                if (flagCommit && !flagRollback)
                {
                    // Someone has actively committed and no-one has rollbacked
                    transaction.Commit();
                }
                else
                {
                    // Either no-one committed, or someone actively rollbacked
                    transaction.Rollback();
                }
                transaction = null;
            }
        }
    }
}
