﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Skyrim
{
    /// <summary>
    /// Common interface for records that physical bounds
    /// </summary>
    public interface IObjectBounded : IObjectBoundedGetter
    {
        new ObjectBounds ObjectBounds { get; set; }
    }

    /// <summary>
    /// Common interface for records that physical bounds
    /// </summary>
    public interface IObjectBoundedGetter
    {
        IObjectBoundsGetter? ObjectBounds { get; }
    }
}
