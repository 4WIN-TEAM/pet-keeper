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

        public Result<List<PodaciViewModel>> GetData(string currentUserId)
        {
            var result = new Result<List<PodaciViewModel>>();

            try {
                result.Value = _entity.Podaci.Where(m => m.User.Id == currentUserId).Select(m => new PodaciViewModel
                {
                    Id = m.Id,
                    Ime = m.Ime,
                    Starost = m.Starost,
                    DatumPrijema = m.DatumPrijema,
                    DatumOdjave = m.DatumOdjave,
                    Rasa = (RasaEnums)m.RasaId,
                    Pol = (PolEnums)m.PolId,
                    Sterilisan = (SterilisanEnums)m.SterilisanId,
                    Vakcinisan = (VakcinisanEnums)m.VakcinisanId,
                    User = m.UserId,
                    Status = (StatusEnums)m.StatusId,
                    UserName = m.UserName
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
        public Result<List<PodaciViewModel>> GetAllData(string currentUserId)
        {
            var result = new Result<List<PodaciViewModel>>();

            try
            {
                result.Value = _entity.Podaci.Select(m => new PodaciViewModel
                {
                    Id = m.Id,
                    Ime = m.Ime,
                    Starost = m.Starost,
                    DatumPrijema = m.DatumPrijema,
                    DatumOdjave = m.DatumOdjave,
                    Rasa = (RasaEnums)m.RasaId,
                    Pol = (PolEnums)m.PolId,
                    Sterilisan = (SterilisanEnums)m.SterilisanId,
                    Vakcinisan = (VakcinisanEnums)m.VakcinisanId,
                    User = m.UserId,
                    Status = (StatusEnums)m.StatusId,
                    UserName = m.UserName
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

        public IResult<NoValue> AddData(PodaciViewModel model, string currentUserId, string userName)
        {
            var result = new Result<NoValue>();
            var podaci = new Podaci();

            try
            {
                podaci.Ime = model.Ime;
                podaci.Starost = model.Starost;
                podaci.DatumPrijema = model.DatumPrijema;
                podaci.DatumOdjave = model.DatumOdjave;
                podaci.StatusId = (int)StatusEnums.Na_čekanju;
                podaci.RasaId = (int)model.Rasa;
                podaci.PolId = (int)model.Pol;
                podaci.SterilisanId = (int)model.Sterilisan;
                podaci.VakcinisanId = (int)model.Vakcinisan;
                podaci.UserId = currentUserId;
                podaci.UserName = userName;

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
                    DatumOdjave = m.DatumOdjave,
                    Rasa = (RasaEnums)m.RasaId,
                    Pol = (PolEnums)m.PolId,
                    Sterilisan = (SterilisanEnums)m.SterilisanId,
                    Vakcinisan = (VakcinisanEnums)m.VakcinisanId,
                    User = m.UserId,
                    Status = (StatusEnums)m.StatusId,
                    UserName = m.UserName
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

        public IResult<PodaciViewModel> Update(PodaciViewModel model, string currentUserId, IList<string> roles)
        {
            var result = new Result<PodaciViewModel>();
            var podaci = _entity.Podaci.Where(m => m.Id == model.Id).FirstOrDefault();
            try
            {
                foreach (var role in roles)
                {
                    if (role == "Admin")
                    {
                        podaci.Ime = model.Ime;
                        podaci.Starost = model.Starost;
                        podaci.DatumPrijema = model.DatumPrijema;
                        podaci.DatumOdjave = model.DatumOdjave;
                        podaci.StatusId = (int)model.Status;
                        podaci.RasaId = (int)model.Rasa;
                        podaci.PolId = (int)model.Pol;
                        podaci.SterilisanId = (int)model.Sterilisan;
                        podaci.VakcinisanId = (int)model.Vakcinisan;
                        podaci.UserId = model.User;
                        podaci.UserName = model.UserName;

                        _entity.SaveChanges();

                        result.Succedded = true;
                    }
                    else if(podaci.UserId == currentUserId)
                    {
                        podaci.Ime = model.Ime;
                        podaci.Starost = model.Starost;
                        podaci.DatumPrijema = model.DatumPrijema;
                        podaci.DatumOdjave = model.DatumOdjave;
                        podaci.StatusId = (int)StatusEnums.Na_čekanju;
                        podaci.RasaId = (int)model.Rasa;
                        podaci.PolId = (int)model.Pol;
                        podaci.SterilisanId = (int)model.Sterilisan;
                        podaci.VakcinisanId = (int)model.Vakcinisan;
                        podaci.UserId = model.User;
                        podaci.UserName = model.UserName;

                        _entity.SaveChanges();

                        result.Succedded = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
                result.Succedded = false;
            }

            return result;
        }
        public IResult<PodaciViewModel> GetDetails(long id, string currentUserId)
        {
            var result = new Result<PodaciViewModel>();
            var podaci = _entity.Podaci.Find(id);

            try
            {
                result.Value = _entity.Podaci.Where(m => m.Id == id).Select(m => new PodaciViewModel
                {
                    Id = m.Id,
                    Ime = m.Ime,
                    Starost = m.Starost,
                    DatumPrijema = m.DatumPrijema,
                    DatumOdjave = m.DatumOdjave,
                    Rasa = (RasaEnums)m.RasaId,
                    Pol = (PolEnums)m.PolId,
                    Sterilisan = (SterilisanEnums)m.SterilisanId,
                    Vakcinisan = (VakcinisanEnums)m.VakcinisanId,
                    User = m.UserId,
                    Status = (StatusEnums)m.StatusId,
                    UserName = m.UserName
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
        public IResult<NoValue> Delete(long id, string currentUserId)
        {
            var result = new Result<NoValue>();
            var podaci = _entity.Podaci.Find(id);

            try
            {
                _entity.Podaci.Remove(podaci);
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
