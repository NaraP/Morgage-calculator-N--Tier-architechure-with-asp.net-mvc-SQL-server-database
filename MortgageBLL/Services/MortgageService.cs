using MortgageBLL.IServices;
using MortgageCalculator.Dto;
using MortgageDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageBLL.Services
{
   public class MortgageService : IMortgageService
    {
        private IMortgageRepository _mortgageRepository; 

        public MortgageService(IMortgageRepository mortgageRepository)
        {
            _mortgageRepository = mortgageRepository;
        }

        public IQueryable<MortgageDto> GetAllMortgages()
        {
            return _mortgageRepository.GetAllMortgages();
        }

        public void ExceptionLogs(ExceptionLoggerDto exceptionLoggerDto)
        {
             _mortgageRepository.ExceptionLogs(exceptionLoggerDto);
        }
    }
}
