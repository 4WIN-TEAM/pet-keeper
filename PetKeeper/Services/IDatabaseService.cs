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
        Result<List<PodaciViewModel>> GetData();
        IResult<NoValue> AddData(PodaciViewModel model, string currentUserId);
        IResult<PodaciViewModel> GetEdit(long id, string currentUserId);
        IResult<PodaciViewModel> Update(PodaciViewModel model, string currentUserId);
    }
}
