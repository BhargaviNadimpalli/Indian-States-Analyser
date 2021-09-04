using IndianStatesAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesAnalyser.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;


        public CensusDTO(Statecode stateCodesDAO)
        {
            this.serialNumber = stateCodesDAO.serialNumber;
            this.stateName = stateCodesDAO.stateName;
            this.stateCode = stateCodesDAO.stateCode;
            this.tin = stateCodesDAO.tin;
        }
        public CensusDTO(CensusData censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }
        
    }
}

