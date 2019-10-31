using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunni.Resources.Modules
{
    public class BniTypes
    {
        public enum CollisionLayer
        {
            Background,
            Midground,
            Foreground
        }

        public enum Tag
        {
            Player,
            Enemy,
            Floor,
            Wall
        }
    }
}
