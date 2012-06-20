using OpenCurtain.Core.Domain;

namespace OpenCurtain.Infrastructure.NHibernate
{
    public class ActRepository : Repository<Act>
    {
        public ActRepository(UnitOfWork unitOfWork)
            : base(unitOfWork, x => x.Id)
        {
        }
    }
}
