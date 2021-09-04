using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesAnalyser
{
    public class CensusException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INVALID_DELIMITER, INCORECT_HEADER,NO_SUCH_COUNTRY
        }
        public ExceptionType eType;
        public CensusException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }
    }
}
