using MortgageCalculator.Dto;
using MortgageDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Exceptions
{
    public class MartgageExceptionFilter : IExceptionFilter
    {
        private IMortgageRepository _mortgageRepository;

        public MartgageExceptionFilter()
        {
            _mortgageRepository = new MortgageRepository();
        }

        public void OnException(ExceptionContext filterContext)
        {
            ExceptionLoggerDto exceptionLoggerDto = new ExceptionLoggerDto()
            {
                ExceptionMessage = filterContext.Exception.Message,
                ExceptionStackTrack = filterContext.Exception.StackTrace,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ExceptionLogTime = DateTime.Now
            };

            _mortgageRepository.ExceptionLogs(exceptionLoggerDto);

            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = filterContext.Exception.Message
            };
        }
    }
}
