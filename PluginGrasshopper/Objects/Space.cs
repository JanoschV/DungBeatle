using Rhino.Geometry;
using System.Collections.Generic;

namespace DungBeatle.PluginGrasshopper.Objects
{

    public class Space
    {
        public string Name { get; set; }
        public List<string> MandatoryAdjacencies { get; set; }
        public List<string> Adjacencies { get; set; }
        public Interval AspectRange { get; set; }
        public Interval AreaRange { get; set; }
        public List<string> SpaceType { get; set; }

        public Space(string name, List<string> mandatoryAdjacencies, List<string> adjacencies, Interval aspectRange, Interval areaRange, List<string> spaceType)
        {
            Name = name;
            MandatoryAdjacencies = mandatoryAdjacencies;
            Adjacencies = adjacencies;
            AspectRange = aspectRange;
            AreaRange = areaRange;
            SpaceType = spaceType;
        }
    }

}
