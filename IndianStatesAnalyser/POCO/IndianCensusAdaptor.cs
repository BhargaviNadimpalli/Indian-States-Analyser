using IndianStatesAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStatesAnalyser.POCO
{
    public class IndianCensusAdaptor : CensusAdaptor
    {
        string[] censusdata;
        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(string csvfilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusdata = GetCensusData(csvfilePath, dataHeaders);
            foreach (string data in censusdata.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusException("File contains wrong delimiter",CensusException.ExceptionType.INVALID_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvfilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new Statecode(column[0], column[1], column[2], column[3])));
                if (csvfilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new POCO.CensusData(column[0], column[1], column[2], column[3])));

            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
