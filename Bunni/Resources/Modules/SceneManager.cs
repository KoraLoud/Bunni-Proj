using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Modules
{
    public static class SceneManager
    {
        public static Scene CurrentScene { get; set; }
        
        public static void ChangeScene(Scene scene)
        {
            CurrentScene = scene;
            scene.Load();
        }
    }
}
