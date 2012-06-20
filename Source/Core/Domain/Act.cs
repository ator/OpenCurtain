using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCurtain.Core.Domain
{
    public class Act
    {
        public virtual int Id { get; protected set; }
        public virtual string Title { get; set; }
        public virtual IList<Scene> Scenes { get; protected set; }

        public Act()
        {
            Scenes = new List<Scene>();
        }

        public virtual void Add(Scene scene)
        {
            scene.Act = this;
            Scenes.Add(scene);
        }

        public virtual void Remove(Scene scene)
        {
            scene.Act = null;
            Scenes.Remove(scene);
        }
    }
}
