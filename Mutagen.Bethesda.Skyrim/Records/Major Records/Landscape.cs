using Mutagen.Bethesda.Plugins.Binary.Streams;
using Noggog;
using System;

namespace Mutagen.Bethesda.Skyrim
{
    public partial class Landscape
    {
        [Flags]
        public enum Flag
        {
            VertexNormalsHightMap = 0x0001,
            VertexColors = 0x0002,
            Layers = 0x0004,
            MPCD = 0x0400,
        }
    }
}