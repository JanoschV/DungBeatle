using DungBeatle.PluginGrasshopper.Objects;
using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace PluginTemplate.PluginGrasshopper
{
    public class FitnessWeightNode: GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public FitnessWeightNode()
          : base("FitnessWeightNode", "FitnessWeights",
            "Prioritise different fitness weights",
            "DungBeatle", "Inputs")
        {

        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("MandatoryAdjacency", "MA", "Mandatory Adjacency", GH_ParamAccess.item);
            pManager.AddNumberParameter("Circulation", "C", "Circulation", GH_ParamAccess.item);
            pManager.AddNumberParameter("Compactness", "Co", "Compactness", GH_ParamAccess.item);
            pManager.AddNumberParameter("Overlap", "O", "Overlap", GH_ParamAccess.item);
            pManager.AddNumberParameter("OptionAdjacency", "OA", "Optional Adjacency", GH_ParamAccess.item);
            pManager.AddNumberParameter("Aspect Ratio", "AR", "Aspect Ratio", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("FitnessWeight", "FW", "Fitness Weightings", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var mandatoryAdjacency= 0.0;
            var circulation = 0.0;
            var compactness = 0.0;
            var overlap = 0.0;
            var optionalAdjacency = 0.0;
            var aspectRatio = 0.0;

            if (!DA.GetData(0, ref mandatoryAdjacency)) return;
            if (!DA.GetData(1, ref circulation)) return;
            if (!DA.GetData(2, ref compactness)) return;
            if (!DA.GetData(3, ref overlap)) return;
            if (!DA.GetData(4, ref optionalAdjacency)) return;
            if (!DA.GetData(5, ref aspectRatio)) return;

            var weighting = new FitnessWeights(mandatoryAdjacency, circulation, compactness, overlap, optionalAdjacency, aspectRatio);
            DA.SetData(0, weighting);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => ResourceLoader.LoadBitmap("BeatleIcon_16.png");

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("E4A781B5-4905-4287-A5FE-622FE59536C9");
    }
}