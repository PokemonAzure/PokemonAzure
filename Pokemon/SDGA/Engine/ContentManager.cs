using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static class ContentManager
    {
        private static Dictionary<string, object> contentBase = new Dictionary<string, object>();

        public static string ASSETS_PATH;

        public static void Setup()
        {
            if (ASSETS_PATH == null)
            {
                ASSETS_PATH = Environment.CurrentDirectory + "/Assets/";
            }
        }

        public static void LoadContent(string contentName, object content)
        {
            contentBase.Add(contentName, content);
        }
    }
}
