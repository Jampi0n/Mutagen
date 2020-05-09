﻿using Loqui;
using Loqui.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mutagen.Bethesda.Generation
{
    public class VersioningModule : GenerationModule
    {
        public const string VersioningEnumName = "VersioningBreaks";
        public const string VersioningFieldName = "Versioning";

        public override async Task LoadWrapup(ObjectGeneration obj)
        {
            await base.LoadWrapup(obj);
            foreach (var field in obj.IterateFields(expandSets: SetMarkerType.ExpandSets.FalseAndInclude))
            {
                if (!(field is DataType dataType)) continue;
                XElement elem = new XElement("Enum");
                elem.Add(new XAttribute(Loqui.Generation.Constants.NAME, dataType.StateName));
                elem.Add(new XAttribute(Loqui.Generation.Constants.ENUM_NAME, $"{obj.ObjectName}.{dataType.EnumName}"));
                elem.Add(new XAttribute("binary", nameof(BinaryGenerationType.NoGeneration)));
                elem.Add(new XAttribute(Loqui.Generation.Constants.HAS_BEEN_SET, "false"));
                await obj.LoadField(elem, requireName: true, add: true);
            }

            // Add object level versioning enum
            if (obj.Fields.Any(f => f is BreakType))
            {
                XElement elem = new XElement("Enum");
                elem.Add(new XAttribute(Loqui.Generation.Constants.NAME, VersioningFieldName));
                elem.Add(new XAttribute(Loqui.Generation.Constants.ENUM_NAME, $"{obj.ObjectName}.{VersioningEnumName}"));
                elem.Add(new XAttribute("binary", nameof(BinaryGenerationType.NoGeneration)));
                elem.Add(new XAttribute(Loqui.Generation.Constants.HAS_BEEN_SET, "false"));
                var gen = await obj.LoadField(elem, requireName: true, add: false);
                if (gen.Failed) throw new ArgumentException();
                gen.Value.SetObjectGeneration(obj, setDefaults: true);
                obj.Fields.Insert(0, gen.Value);
            }
        }

        public override async Task GenerateInClass(ObjectGeneration obj, FileGeneration fg)
        {
            var enumTypes = new List<string>();
            var breaks = 0;
            foreach (var field in obj.Fields)
            {
                if (field is BreakType breakType)
                {
                    enumTypes.Add("Break" + breaks++);
                }
            }

            if (enumTypes.Count <= 0) return;
            fg.AppendLine("[Flags]");
            fg.AppendLine($"public enum {VersioningEnumName}");
            using (new BraceWrapper(fg))
            {
                using (var comma = new CommaWrapper(fg))
                {
                    var term = 1;
                    for (int i = 0; i < enumTypes.Count; i++)
                    {
                        comma.Add($"{enumTypes[i]} = {term}");
                        term *= 2;
                    }
                }
            }
        }

        public override async Task PostLoad(ObjectGeneration obj)
        {
            await base.PostLoad(obj);
            int breaks = 0;
            foreach (var field in obj.Fields)
            {
                if (field is BreakType breakType)
                {
                    breakType.Index = breaks++;
                }
            }
        }
    }
}
