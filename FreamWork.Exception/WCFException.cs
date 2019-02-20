using System;
using System.ServiceModel;

namespace FreamWork.Exception
{
    public class WCFException : FaultException
    {
        public WCFException(string ExceptionCode)
            : base(ExceptionCode)
        {
        }
    }
}
