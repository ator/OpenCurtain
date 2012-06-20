using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCurtain.Core.Domain
{
    public class Scene
    {
        public virtual int Id { get; protected set; }
        public virtual Act Act { get; set; }
        public virtual IList<Character> Characters { get; protected set; }

        public Scene()
        {
            Characters = new List<Character>();
        }

        public virtual void Add(Character actor)
        {
            Characters.Add(actor);
        }

        public virtual void Remove(Character actor)
        {
            Characters.Remove(actor);
        }
    }
}
