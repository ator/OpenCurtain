using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCurtain.Core.Domain
{
    public class Direction
    {
        public virtual int Id { get; protected set; }
        public virtual Scene Scene { get; set; }
        public virtual Character Character { get; set; }
        public virtual string Description { get; set; }
    }
}
