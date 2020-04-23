using PetKeeper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PetKeeper.Common.PolEnum;
using static PetKeeper.Common.RasaEnum;
using static PetKeeper.Common.StatusEnum;
using static PetKeeper.Common.SterilisanEnum;
using static PetKeeper.Common.VakcinisanEnum;

namespace PetKeeper.Models
{
    public class PodaciViewModel
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public int Starost { get; set; }
        public DateTime DatumPrijema { get; set; }
        public RasaEnums Rasa { get; set; }
        public PolEnums Pol { get; set; }
        public SterilisanEnums Sterilisan { get; set; }
        public VakcinisanEnums Vakcinisan { get; set; }
        public string User { get; set; }
        public StatusEnums Status { get; set; }
    }
}
