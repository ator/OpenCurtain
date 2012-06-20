using FluentNHibernate.Mapping;
using OpenCurtain.Core.Domain;

namespace OpenCurtain.Infrastructure.NHibernate
{
    public class CharacterMap : ClassMap<Character>
    {
        public CharacterMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany<Direction>(x => x.Directions);
        }
    }
}
