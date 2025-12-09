using DungBeatle.PluginGrasshopper.Objects;
using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace PluginTemplate.PluginGrasshopper
{
    public class ApartmentDataNode : GH_Component
    {
        /// <summary>
        /// Creates user data node 
        /// </summary>
        public ApartmentDataNode()
          : base("ApartmentData", "Pattern",
            "Shape of the circulation path",
            "DungBeatle", "Inputs")
        {

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
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("Spine", "\"Spine\""));
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("L-Shape", "\"L-Shape\""));
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("T-Shape", "\"T-Shape\""));
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("H-Shape", "\"H-Shape\""));
            valueList.ListItems.Add(new Grasshopper.Kernel.Special.GH_ValueListItem("U-Shape", "\"U-Shape\""));

            valueList.NickName = "Pattern";
            valueList.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - 120, this.Attributes.Pivot.Y);

            document.AddObject(valueList, false);
        }
        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Pattern", "P", "Select a circulation pattern", GH_ParamAccess.item);
            pManager.AddIntegerParameter("NumberOfBedrooms", "NB", "Select number of bedrooms", GH_ParamAccess.item);
            pManager.AddIntegerParameter("NumberOfEnsuites", "NE", "Select number of ensuite bathrooms", GH_ParamAccess.item);
            pManager.AddNumberParameter("ApartmentArea", "A", "Desired apartment area", GH_ParamAccess.item);
            pManager.AddNumberParameter("MinimumHallwayWidth", "HW", "Minimum hallway width", GH_ParamAccess.item);

            // Optionally, set default value or description to guide the user
            pManager[0].Optional = false;
            pManager[0].Description = "Options: Spine, L-Shape, T-Shape, H-Shape, U-Shape";

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ApartmentData", "AD", "Information about apartment", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string pattern = null;
            var numberOfBedrooms= 0;
            var numberOfEnsuites= 0;
            var apartmentArea = 0.0;
            var minimumHallwayWidth = 0.0;

            if (!DA.GetData(0, ref pattern)) return;
            if (!DA.GetData(1, ref numberOfBedrooms)) return;
            if (!DA.GetData(2, ref numberOfEnsuites)) return;
            if (!DA.GetData(3, ref apartmentArea)) return;
            if (!DA.GetData(4, ref minimumHallwayWidth)) return;

            var apartmentData = new ApartmentData()
            {
                Pattern = pattern,
                NumberOfBedrooms = numberOfBedrooms,
                NumberOfEnsuites = numberOfEnsuites,
                ApartmentArea = (int)apartmentArea,
                MinimumHallwayWidth = (int)minimumHallwayWidth,
            };
            DA.SetData(0,apartmentData);
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
        public override Guid ComponentGuid => new Guid("7931863A-8954-42DB-9653-4ACC479161B8");
    }
}