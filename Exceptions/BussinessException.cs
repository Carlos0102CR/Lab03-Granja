using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class BussinessException : Exception
    {
        public int ExceptionId;
        public string ExceptionMessage;

        public BussinessException()
        {

        }

        public BussinessException(int exceptionId)
        {

        }

        public BussinessException(int exceptionId, Exception innerException)
        {


        }
    }
}
