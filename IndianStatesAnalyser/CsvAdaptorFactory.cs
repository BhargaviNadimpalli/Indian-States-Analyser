using IndianStatesAnalyser.DTO;
using IndianStatesAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesAnalyser
{
    public class CsvAdaptorFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilepath, string dataHeaders)
        {
            switch (country)
            {
                //Check countries
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdaptor().LoadCensusData( csvFilepath, dataHeaders);
                //case (CensusAnalyser.Country.US):
                //    return new USCensusAdapter().LoadUSCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusException("No such country present", CensusException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
