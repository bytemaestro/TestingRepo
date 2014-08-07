using System;
using System.Collections.Generic;
using System.Linq;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    public class Diner
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
