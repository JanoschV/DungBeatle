using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginTemplate.PluginGrasshopper
{
    /// <summary>
    /// Load and convert embedded assembly resources
    /// </summary>
    internal static class ResourceLoader
    {
        static string GetResourcePath(string resourceName)
        {
            return $"{typeof(ResourceLoader).Namespace}.EmbeddedResources.{resourceName}";
        }

        public static Bitmap LoadBitmap(string resourceName)
        {
            var assembly = typeof(ResourceLoader).Assembly;
            using (var stream = assembly.GetManifestResourceStream(GetResourcePath(resourceName)))
            {
                var streamString = @"C:\Users\julia\AppData\Roaming\Grasshopper\Libraries\net48\" + resourceName;
                if (streamString == null)
                    throw new Exception($"Failed to load resource {resourceName}");
                return new Bitmap(streamString);
            }
        }

        public static Icon LoadIcon (string resourceName)
        {
            var assembly = typeof(ResourceLoader).Assembly;
            using (var stream = assembly.GetManifestResourceStream(GetResourcePath(resourceName)))
            {
                if (stream == null)
                    throw new Exception($"Failed to load resource {resourceName}");
                return new Icon(stream);
            }
        }

    }
}
