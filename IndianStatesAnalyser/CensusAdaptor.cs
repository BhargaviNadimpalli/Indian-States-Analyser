using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStatesAnalyser
{
   public abstract class CensusAdaptor
    {
        protected string[] GetCensusData(string csvFilePath, string dataHeader)
        {
            string[] CensusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusException("File not found", CensusException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusException("Invalid file type", CensusException.ExceptionType.INVALID_FILE_TYPE);
            }
            CensusData = File.ReadAllLines(csvFilePath);
            if (CensusData[0] != dataHeader)
            {
                throw new CensusException("Incorrect header in data", CensusException.ExceptionType.INCORECT_HEADER);
            }
            return CensusData;
        }
    }
}
