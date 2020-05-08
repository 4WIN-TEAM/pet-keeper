using System;
using System.Collections.Generic;

namespace PetKeeper.Data
{
    public partial class Podaci : Rasa
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public int Starost { get; set; }
        public DateTime DatumPrijema { get; set; }
        public int RasaId { get; set; }
        public int PolId { get; set; }
        public int SterilisanId { get; set; }
        public int VakcinisanId { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime DatumOdjave { get; set; }
        public string UserName { get; set; }

        public virtual Pol Pol { get; set; }
        public virtual Status Status { get; set; }
        public virtual Sterilisan Sterilisan { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual Vakcinisan Vakcinisan { get; set; }

        public Vakcinisan Vakcinisan1
        {
            get => default;
            set
            {
            }
        }

        public Sterilisan Sterilisan1
        {
            get => default;
            set
            {
            }
        }

        public Pol Pol1
        {
            get => default;
            set
            {
            }
        }

        public AspNetUsers AspNetUsers
        {
            get => default;
            set
            {
            }
        }

        public AspNetUsers AspNetUsers1
        {
            get => default;
            set
            {
            }
        }
    }
}
