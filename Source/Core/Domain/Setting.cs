using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCurtain.Core.Domain
{
    public class Setting
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
