using Rhino.Geometry;
using Rhino.Input.Custom;
using System.Collections.Generic;

namespace DungBeatle.PluginGrasshopper.Objects
{

    public class ApartmentData
    {

        public string Pattern { get; set; }
        public int NumberOfBedrooms  { get; set; }
        public int NumberOfEnsuites { get; set; }
        public int ApartmentArea { get; set; }
        public int MinimumHallwayWidth { get; set; }

        public ApartmentData(){ }
    }

}
