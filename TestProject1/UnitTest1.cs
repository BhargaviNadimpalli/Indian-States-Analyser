using NUnit.Framework;
using IndianStatesAnalyser;
using IndianStatesAnalyser.DTO;
using System.Collections.Generic;
using static IndianStatesAnalyser.CensusAnalyser;

namespace TestProject1
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndiaStateCensusData.csv";
        static string wrongDataFilePath = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndiaStateCensusData.csv";
        static string IndianStateCensus = @"C:C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndiaStateCensusData.txt";
        static string wrongIndianStateCensusFileHeader = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\WrongIndiaStateCode.csv";
        static string IndianStateCesusFilePathWithWrongDelimeter = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndianStateCensusDelimeter.csv";
        IndianStatesAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        private object country;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        //public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        //{
        //    totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, country.INDIA, indianStateCensusHeaders);
        //    Assert.AreEqual(5, totalRecord.Count);
        //}
        //[Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(wrongDataFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(IndianStateCensus, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileHeader, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusException.ExceptionType.INCORECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(IndianStateCesusFilePathWithWrongDelimeter, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusException.ExceptionType.INVALID_DELIMITER, censusException.eType);
        }
    }
}