using FluentNHibernate.Mapping;
using OpenCurtain.Core.Domain;

namespace OpenCurtain.Infrastructure.NHibernate
{
    public class DirectionMap : ClassMap<Direction>
    {
        public DirectionMap()
        {
            Id(x => x.Id);
            References<Scene>(x => x.Scene);
            References<Character>(x => x.Character);
            Map(x => x.Description);
        }
    }
}
