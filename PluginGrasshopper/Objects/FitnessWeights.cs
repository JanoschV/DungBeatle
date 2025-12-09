using Rhino.Geometry;
using Rhino.Input.Custom;
using System.Collections.Generic;

namespace DungBeatle.PluginGrasshopper.Objects
{

    public class FitnessWeights
    {

        public double MandatoryAdjacency{ get; set; }
        public double Circulation{ get; set; }
        public double Compactness { get; set; }
        public double Overlap { get; set; }
        public double OptionalAdjacency { get; set; }
        public double AspectRatio { get; set; }

        public FitnessWeights(double mandatoryAdjacency, double circulation, double compactness, double overlap, double optionalAdjacency, double aspectRatio)
        {
            var adjustmentRatio = 1/(mandatoryAdjacency + circulation + compactness + overlap + optionalAdjacency + aspectRatio);
            AspectRatio = aspectRatio*adjustmentRatio;
            MandatoryAdjacency = mandatoryAdjacency * adjustmentRatio;
            Circulation = circulation * adjustmentRatio;
            Compactness = compactness * adjustmentRatio;
            Overlap = overlap * adjustmentRatio;
            OptionalAdjacency = optionalAdjacency * adjustmentRatio;
            AspectRatio = aspectRatio*adjustmentRatio;
        }
    }

}
