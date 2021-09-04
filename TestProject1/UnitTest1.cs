using NUnit.Framework;
using IndianStatesAnalyser;
using IndianStatesAnalyser.DTO;
using System.Collections.Generic;
using static IndianStatesAnalyser.CensusAnalyser;

namespace TestProject1
{
    public class Tests
    {

        //File Paths
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndiaStateCensusData.csv";
        static string wrongDataFilePath = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndianData.csv";
        static string IndianStateCensus = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndianStateCensus.txt";
        static string wrongIndianStateCensusFileHeader = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\WrongIndiaStateCensusData.csv";
        static string IndianStateCesusFilePathWithWrongDelimeter = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndianStateCesusDelimeter.csv";

        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";
        static string indianStateCodePath = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\IndiaStateCodes.csv";
        static string WrongIndianStateCodeFilePath = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\WrongIndiaStateCodes.csv";
        static string WrongIndianStateCodeFileTypePath = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\WrongTypeIndiaStateCodes.txt";
        static string IndianStateCodeFilePathWrongDelimeter = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\DelimiterIndiaStateCodes.csv";
        static string IndianStateCodeFilePathWrongHeader = @"C:\Users\HP\source\repos\IndianStatesAnalyser\TestProject1\CsvFiles\WrongHeaderIndiaStateCodes.csv";

        //Object and Dictionary
        IndianStatesAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }
       
        
        [Test]
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
        
        [Test]
        public void GivenWrongStateCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFileTypePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongDelimeter, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusException.ExceptionType.INVALID_DELIMITER, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongHeader, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusException.ExceptionType.INCORECT_HEADER, stateException.eType);
        }

    }
}