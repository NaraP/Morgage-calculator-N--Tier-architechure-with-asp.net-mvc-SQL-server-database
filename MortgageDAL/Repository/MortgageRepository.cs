using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageCalculator.Dto;
using MortgageDAL.Models;
using MortgageLogger;

namespace MortgageDAL.Repository
{
    public class MortgageRepository : IMortgageRepository
    {
        public IQueryable<MortgageDto> GetAllMortgages()
        {
            List<MortgageDto> mortgages = new List<MortgageDto>();

            try
            {
                SingletonLogger.Instance.Debug("GetAllMortgages method is started");

                using (MortgageEntities _mortgageEntities = new MortgageEntities())
                {
                    var mortgaesList = _mortgageEntities.Mortgages.ToList();

                    if (mortgaesList != null && mortgaesList.Any())
                    {
                        foreach (var item in mortgaesList)
                        {
                            mortgages.Add(new MortgageDto()
                            {
                                MortgageId = item.MortgageId,
                                Name = item.Name,
                                EffectiveStartDate = item.EffectiveStartDate.Value,
                                EffectiveEndDate = item.EffectiveEndDate.Value,
                                CancellationFee = item.CancellationFee.Value,
                                EstablishmentFee = item.CancellationFee.Value,
                                InterestRepayment = (InterestRepayment)Enum.Parse(typeof(InterestRepayment), item.InterestRepayment.ToString()),
                                MortgageType = (MortgageType)Enum.Parse(typeof(MortgageType), item.MortgageType.ToString()),
                                TermsInMonths = item.TermsInMonths.Value
                            });
                        }
                        SingletonLogger.Instance.Debug("GetAllMortgages method is ended");
                    }
                }
            }
            catch (Exception ex)
            {
                SingletonLogger.Instance.Error("GetAllMortgages method is error", ex.InnerException);
            }
            return mortgages.AsQueryable();
        }

        public void ExceptionLogs(ExceptionLoggerDto exceptionLoggerDto)
        {
            try
            {
                SingletonLogger.Instance.Debug("ExceptionLogs method is started");

                using (MortgageEntities _mortgageEntities = new MortgageEntities())
                {
                    ExceptionLogger exceptionLoggers = new ExceptionLogger()
                    {
                        ExceptionMessage = exceptionLoggerDto.ExceptionMessage,
                        ExceptionStackTrack = exceptionLoggerDto.ExceptionStackTrack,
                        ControllerName = exceptionLoggerDto.ControllerName,
                        ActionName = exceptionLoggerDto.ActionName,
                        ExceptionLogTime = DateTime.Now
                    };
                    _mortgageEntities.ExceptionLoggers.Add(exceptionLoggers);
                    _mortgageEntities.SaveChanges();
                    SingletonLogger.Instance.Debug("ExceptionLogs method is ended");
                }
            }
            catch (Exception ex)
            {
                SingletonLogger.Instance.Error("ExceptionLogs method is error", ex.InnerException);
            }
        }
    }
}
