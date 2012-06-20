using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCurtain.Core.Domain
{
    public class Character
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IList<Direction> Directions { get; protected set; }

        public Character()
        {
            Directions = new List<Direction>();
        }

        public virtual void Add(Direction direction)
        {
            direction.Character = this;
            Directions.Add(direction);
        }

        public virtual void Remove(Direction direction)
        {
            direction.Character = null;
            Directions.Remove(direction);
        }
    }
}
