using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLogger
{
    public interface ILogger
    {
        void Info(Object message);
        void Debug(Object message);
        void Error(Object message, Exception exception);
        void Error(Object message);
        void Fatal(Object message, Exception exception);
        void Fatal(Object message);
    }
}
