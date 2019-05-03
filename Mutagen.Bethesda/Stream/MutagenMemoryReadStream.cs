﻿using Noggog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Binary
{
    public class MutagenMemoryReadStream : BinaryMemoryReadStream, IMutagenReadStream
    {
        public long OffsetReference { get; }

        public MutagenMemoryReadStream(byte[] data, long offsetReference = 0) 
            : base(data)
        {
            this.OffsetReference = offsetReference;
        }
    }
}