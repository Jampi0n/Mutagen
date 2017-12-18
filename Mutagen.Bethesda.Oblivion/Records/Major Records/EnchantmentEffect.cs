﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Oblivion.Internals;

namespace Mutagen.Bethesda.Oblivion
{
    public partial class EnchantmentEffect
    {
        public enum EffectType
        {
            Self = 0,
            Touch = 1,
            Target = 2
        }

        static partial void SpecialParse_MagicEffectInitial(EnchantmentEffect item, MutagenFrame frame, Func<EnchantmentEffect_ErrorMask> errorMask)
        {
            var recType = HeaderTranslation.ReadNextSubRecordType(frame, out var contentLen);
            if (contentLen.Value != 4)
            {
                throw new ArgumentException($"Magic effect name must be length 4.  Was: {contentLen.Value}");
            }
            var magicEffName = frame.Reader.ReadString(4);
            var pos = frame.Position;
            var efit = HeaderTranslation.ReadNextSubRecordType(frame, out var efitLength);
            if (efitLength.Value < 4)
            {
                throw new ArgumentException($"Magic effect ref length was less than 4.  Was: {efitLength.Value}");
            }
            var magicEffName2 = frame.Reader.ReadString(4);
            if (!magicEffName.Equals(magicEffName2))
            {
                throw new ArgumentException($"Magic effect names did not match. {magicEffName} != {magicEffName2}");
            }
            frame.Position = pos;
        }

        static partial void SpecialWrite_MagicEffectInitial(IEnchantmentEffectGetter item, MutagenWriter writer, Func<EnchantmentEffect_ErrorMask> errorMask)
        {
            using (HeaderExport.ExportSubRecordHeader(writer, EnchantmentEffect_Registration.EFID_HEADER))
            {
                writer.Write(item.MagicEffect);
            }
        }
    }
}
