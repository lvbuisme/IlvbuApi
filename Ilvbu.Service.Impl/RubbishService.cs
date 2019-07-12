using AutoMapper;
using Ilvbu;
using Ilvbu.DataBase;
using Ilvbu.DataBase.Models;
using Ilvbu.Interface.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilvbu.Service.Impl
{
    public class RubbishService : IRubbishService
    {

        private readonly ILogger<RubbishService> _logger;
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public RubbishService(ILogger<RubbishService> logger, MyDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResult> AddRubish(RubbishData model)
        {
            try
            {
                Rubbish rubbish = _mapper.Map<Rubbish>(model);
                _context.Rubbish.Add(rubbish);
                _context.SaveChanges();
                return new BaseResult();
            }catch(Exception e)
            {
                _logger.LogError(e, "");
                return new BaseResult(-1,e.Message);
            }
        }
        public async Task<BaseResult<RubbishData[]>> GetRubbish()
        {
            try
            {
                Rubbish[] rubbishes = _context.Rubbish.Include(c=>c.RubbishType).ToArray();
                RubbishData[] rubbishData = _mapper.Map<RubbishData[]>(rubbishes);
                return BaseResult<RubbishData[]>.From(rubbishData);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");
                return new BaseResult<RubbishData[]>(-1,e.Message);
            }
        }
    }
}
