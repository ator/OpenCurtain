using FluentNHibernate.Mapping;
using OpenCurtain.Core.Domain;

namespace OpenCurtain.Infrastructure.NHibernate
{
    public class ActMap : ClassMap<Act>
    {
        public ActMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            HasMany<Scene>(x => x.Scenes);
        }
    }
}
