using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesAnalyser.POCO
{
    public class CensusData
    {
        public string state;
        public long population;
        public long area;
        public long density;

        public CensusData(string state, long population, long area, long density)
        {
            this.state = state;
            this.population = Convert.ToInt64(population);
            this.area = Convert.ToInt64(area);
            this.density = Convert.ToInt64(density);
        }

        public CensusData(string v1, string v2, string v3, string v4)
        {
        }
    }
}
