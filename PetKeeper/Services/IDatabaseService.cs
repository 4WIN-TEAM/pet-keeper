using PetKeeper.Common;
using PetKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetKeeper.Services
{
    public interface IDatabaseService
    {
        Result<List<PodaciViewModel>> GetData(string currentUserId);
        Result<List<PodaciViewModel>> GetAllData(string currentUserId);
        IResult<NoValue> AddData(PodaciViewModel model, string currentUserId,string userName);
        IResult<PodaciViewModel> GetEdit(long id, string currentUserId);
        IResult<PodaciViewModel> Update(PodaciViewModel model, string currentUserId, IList<string> roles);
        IResult<PodaciViewModel> GetDetails(long id, string currentUserId);
        IResult<NoValue> Delete(long id, string currentUserId);
    }
}
