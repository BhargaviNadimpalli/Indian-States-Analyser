using IndianStatesAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IndianStatesAnalyser
{
   public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country , string csvFilePath, string dataHeaders)
        {
            dataMap = new CsvAdaptorFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }

        public void LoadCensusData(string wrongDataFilePath, object iNDIA, string indianStateCensusHeaders)
        {
            throw new NotImplementedException();
        }

        
    }
}
