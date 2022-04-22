using MortgageCalculator.Dto;
using MortgageDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageDAL.Repository
{
    public interface IMortgageRepository
    {
        IQueryable<MortgageDto> GetAllMortgages();

        void ExceptionLogs(ExceptionLoggerDto exceptionLoggerDto);
    }
}
