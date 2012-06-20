using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentNHibernate;
using FluentNHibernate.Utils;
using OpenCurtain.Core.Services;

namespace OpenCurtain.Infrastructure.NHibernate
{
    public class Repository<TObj> : IRepository<TObj> where TObj : class
    {
        private readonly UnitOfWork unitOfWork;
        private readonly Member idMember;

        protected Repository(UnitOfWork unitOfWork, Expression<Func<TObj, object>> idMemberExpression)
        {
            this.unitOfWork = unitOfWork;
            idMember = idMemberExpression.ToMember();
        }

        public void Save(ref TObj obj)
        {
            using (var uow = unitOfWork.Start())
            {
                var inDb = unitOfWork.Session.Get<TObj>(idMember.GetValue(obj));
                if (inDb != null)
                {
                    obj = unitOfWork.Session.Merge<TObj>(obj);
                }
                else
                {
                    unitOfWork.Session.Save(obj);
                }
                uow.Commit();
            }
        }
        
        public TObj FindById(object id)
        {
            using (unitOfWork.Start())
            {
                return unitOfWork.Session.Get<TObj>(id);
            }
        }
        
        public TObj FindById<TId>(TId id)
        {
            using (unitOfWork.Start())
            {
                return unitOfWork.Session.Get<TObj>(id);
            }
        }
        
        public IEnumerable<TObj> FindAll()
        {
            using (unitOfWork.Start())
            {
                return unitOfWork.Session.CreateCriteria<TObj>().Future<TObj>();
            }
        }
    }
}
