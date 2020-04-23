using System;
using System.Collections.Generic;

namespace PetKeeper.Data
{
    public partial class Sterilisan
    {
        public Sterilisan()
        {
            Podaci = new HashSet<Podaci>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Podaci> Podaci { get; set; }
    }
}
