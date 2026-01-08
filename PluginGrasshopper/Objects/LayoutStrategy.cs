using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungBeatle.PluginGrasshopper.Objects
{
    public class LayoutStrategy
    {
        public string EntrancePostion { get; set; }
        public int ZoneBufferCount {  get; set; } 
        public int ContractionTolerance { get; set; }
        public LayoutStrategy() { }
    }
}
