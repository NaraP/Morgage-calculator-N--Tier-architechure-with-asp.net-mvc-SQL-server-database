using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
  public  class ExceptionLoggerDto
    {
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ExceptionStackTrack { get; set; }
        public Nullable<System.DateTime> ExceptionLogTime { get; set; }
    }
}
