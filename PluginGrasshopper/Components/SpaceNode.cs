using DungBeatle.PluginGrasshopper.Objects;
using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace PluginTemplate.PluginGrasshopper
{
    public class SpaceNode : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public SpaceNode()
          : base("SpaceNode", "Space",
            "Represents a room or space",
            "DungBeatle", "Inputs")
        {

        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Function Name", GH_ParamAccess.item);
            pManager.AddTextParameter("MandatoryAdjacencies", "MAdj", "Mandatory Adjacencies", GH_ParamAccess.list);
            pManager.AddTextParameter("Adjacencies", "Adj", "Potential Adjacencies", GH_ParamAccess.list);
            pManager.AddIntervalParameter("AspectRange", "AspR", "Aspect Ratio Range", GH_ParamAccess.item);
            pManager.AddIntervalParameter("AreaRange", "AreaR", "Area Range", GH_ParamAccess.item);
            pManager.AddTextParameter("SpaceType", "SpcTyp", "Space Type", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Space", "SN", "The created Space", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = null;
            var mandatoryAdjacencies = new List<string>();
            var adjacencies = new List<string>();
            Interval aspectRange = new Interval();
            Interval areaRange = new Interval();
            var spaceType = new List<string>();

            if (!DA.GetData(0, ref name)) return;
            if (!DA.GetDataList(1, mandatoryAdjacencies)) return;
            if (!DA.GetDataList(2, adjacencies)) return;
            if (!DA.GetData(3, ref aspectRange)) return;
            if (!DA.GetData(4, ref areaRange)) return;
            if (!DA.GetDataList(5, spaceType)) return;

            var space = new Space(name, mandatoryAdjacencies, adjacencies, aspectRange, areaRange, spaceType);
            DA.SetData(0, space);
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
        public override Guid ComponentGuid => new Guid("028BC491-12D9-4B01-9E87-01947840D1C6");
    }
}