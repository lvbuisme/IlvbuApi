using Ilvbu.Interface.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ilvbu.Service
{
    public interface IRubbishService 
    {
        Task<BaseResult<RubbishData[]>> GetRubbish();
        Task<BaseResult> AddRubish(RubbishData model);
    }
}
