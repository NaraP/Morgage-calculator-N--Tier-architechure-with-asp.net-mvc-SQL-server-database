using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageBLL.IServices
{
    public interface IMortgageService
    {
        IQueryable<MortgageDto> GetAllMortgages();
        void ExceptionLogs(ExceptionLoggerDto exceptionLoggerDto);
    }
}
