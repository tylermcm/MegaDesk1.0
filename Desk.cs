using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    internal class Desk
    {
        public const int MINWIDTH = 24; // Minimum allowed width for the desk
        public const int MAXWIDTH = 96; // Maximum allowed width for the desk
        public const int MINDEPTH = 12; // Minimum allowed depth for the desk
        public const int MAXDEPT = 48; // Maximum allowed depth for the desk
        public const int MINDRAWER = 0;
        public const int MAXDRAWER = 7;
        

        public int Depth { get; internal set; }
        public int Width { get; internal set; }
        public int NumberOfDrawers { get; internal set; }
        public DesktopMaterials Material { get; internal set; }
    }
    public enum DesktopMaterials
    {
        Laminate,
        Oak,
        Rosewood,
        Veneer,
        Pine
    }

}
