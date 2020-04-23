using Microsoft.EntityFrameworkCore;
using PetKeeper.Common;
using PetKeeper.Data;
using PetKeeper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static PetKeeper.Common.PolEnum;
using static PetKeeper.Common.RasaEnum;
using static PetKeeper.Common.StatusEnum;
using static PetKeeper.Common.SterilisanEnum;
using static PetKeeper.Common.VakcinisanEnum;

namespace PetKeeper.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly PetKeeperContext _entity;

        public DatabaseService(PetKeeperContext entity)
        {
            _entity = entity;
        }

        public Result<List<PodaciViewModel>> GetData()
        {
            var result = new Result<List<PodaciViewModel>>();

            try {
                result.Value = _entity.Podaci.Select(m => new PodaciViewModel
                {
                    Id = m.Id,
                    Ime = m.Ime,
                    Starost = m.Starost,
                    DatumPrijema = m.DatumPrijema,
                    Rasa = (RasaEnums)m.RasaId,
                    Pol = (PolEnums)m.PolId,
                    Sterilisan = (SterilisanEnums)m.SterilisanId,
                    Vakcinisan = (VakcinisanEnums)m.VakcinisanId,
                    User = m.UserId,
                    Status = (StatusEnums)m.StatusId
                }).ToList();
                result.Succedded = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
                result.Succedded = false;
            }
            return result;
        }
        public IResult<NoValue> AddData(PodaciViewModel model, string currentUserId)
        {
            var result = new Result<NoValue>();
            var podaci = new Podaci();

            try
            {
                podaci.Ime = model.Ime;
                podaci.Starost = model.Starost;
                podaci.DatumPrijema = model.DatumPrijema;
                podaci.StatusId = (int)StatusEnums.Na_čekanju;
                podaci.RasaId = (int)model.Rasa;
                podaci.PolId = (int)model.Pol;
                podaci.SterilisanId = (int)model.Sterilisan;
                podaci.VakcinisanId = (int)model.Vakcinisan;
                podaci.UserId = currentUserId;

                _entity.Podaci.Add(podaci);
                _entity.SaveChanges();
                result.Succedded = true;
            }


            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
                result.Succedded = false;

            }
            return result;
        }

        public IResult<PodaciViewModel> GetEdit(long id, string currentUserId)
        {
            var result = new Result<PodaciViewModel>();
            var podaci = _entity.Podaci.Find(id);
            try
            {
                result.Value = _entity.Podaci.Include("Pol").Include("Rasa").Include("Status").Include("Vakcinisan").Include("Sterilisan").Where(m => m.Id == id).Select(m => new PodaciViewModel
                {
                    Id = m.Id,
                    Ime = m.Ime,
                    Starost = m.Starost,
                    DatumPrijema = m.DatumPrijema,
                    Rasa = (RasaEnums)m.RasaId,
                    Pol = (PolEnums)m.PolId,
                    Sterilisan = (SterilisanEnums)m.SterilisanId,
                    Vakcinisan = (VakcinisanEnums)m.VakcinisanId,
                    User = m.UserId,
                    Status = (StatusEnums)m.StatusId
                }).Single();
                result.Succedded = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
                result.Succedded = false;
            }
            return result;

        }

        public IResult<PodaciViewModel> Update(PodaciViewModel model, string currentUserId)
        {
            var result = new Result<PodaciViewModel>();
            var podaci = _entity.Podaci.Where(m => m.Id == model.Id).FirstOrDefault();
            try
            {
                podaci.Ime = model.Ime;
                podaci.Starost = model.Starost;
                podaci.DatumPrijema = model.DatumPrijema;
                podaci.StatusId = (int)model.Status;
                podaci.RasaId = (int)model.Rasa;
                podaci.PolId = (int)model.Pol;
                podaci.SterilisanId = (int)model.Sterilisan;
                podaci.VakcinisanId = (int)model.Vakcinisan;
                podaci.UserId = currentUserId;

                _entity.SaveChanges();

                result.Succedded = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
                result.Succedded = false;
            }

            return result;
        }




    }

}
