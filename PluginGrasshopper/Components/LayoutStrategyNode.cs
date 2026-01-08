using DungBeatle.PluginGrasshopper.Objects;
using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace PluginTemplate.PluginGrasshopper
{
    public class LayoutStrategyNode : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public LayoutStrategyNode()
          : base("LayoutStrategyNode", "Space",
            "Represents a room or space",
            "DungBeatle", "Inputs")
        {

        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("EntrancePosition", "EP", "Entrance Position", GH_ParamAccess.item);
            pManager.AddIntegerParameter("ZoneBufferCount", "ZBF", "Zone Buffer Count", GH_ParamAccess.item);
            pManager.AddIntegerParameter("ContractionTolerance", "CT", "Contraction Tolerance", GH_ParamAccess.item);
        }
        /// <summary>
        /// Causes list of circulation types to appear when component is added to document
        /// </summary>
        /// <param name="document"></param>
        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            var valueList = new Grasshopper.Kernel.Special.GH_ValueList();
            valueList.CreateAttributes();

            valueList.ListItems.Clear();
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("North", "\"North\""));
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("South", "\"South\""));
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("West", "\"West\""));
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("East", "\"East\""));

            valueList.NickName = "EntrancePosition";
            valueList.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - 120, this.Attributes.Pivot.Y);

            document.AddObject(valueList, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("LayoutStrategy", "LS", "The Layout Strategy", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var entrancePosition = string.Empty;
            int zoneBufferCount = 0;
            int contractionTolerance = 0;

            if (!DA.GetData(0, ref entrancePosition)) return;
            if (!DA.GetData(1,ref zoneBufferCount)) return;
            if (!DA.GetData(2,ref contractionTolerance)) return;

            var layoutStrategy= new LayoutStrategy()
            {
                EntrancePostion = entrancePosition,
                ZoneBufferCount = zoneBufferCount,
                ContractionTolerance = contractionTolerance,
            };

            DA.SetData(0, layoutStrategy);
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
        public override Guid ComponentGuid => new Guid("A75C80D1-5CD2-493A-816B-49CEEBC0F8EA");
    }
}