using FluentNHibernate.Mapping;
using OpenCurtain.Core.Domain;

namespace OpenCurtain.Infrastructure.NHibernate
{
    public class SceneMap : ClassMap<Scene>
    {
        public SceneMap()
        {
            Id(x => x.Id);
            References<Act>(x => x.Act);
            HasManyToMany<Character>(x => x.Characters);
        }
    }
}
