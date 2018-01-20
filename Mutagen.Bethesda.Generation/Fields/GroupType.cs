﻿using Loqui.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mutagen.Bethesda.Generation
{
    public class GroupType : LoquiType
    {
        public override Task Load(XElement node, bool requireName = true)
        {
            XElement convert = new XElement(XName.Get("Ref", LoquiGenerator.Namespace));
            convert.Add(node.Attribute("name"));
            var dir = new XElement(XName.Get("Direct", LoquiGenerator.Namespace));
            dir.Add(new XAttribute("refName", "Bethesda.Group"));
            convert.Add(dir);
            var gen = new XElement(XName.Get("GenericSpecification", LoquiGenerator.Namespace));
            var nameKey = ObjectNamedKey.Factory(node.GetAttribute("refName"), this.ObjectGen.ProtoGen.Protocol);
            gen.Add(new XAttribute("Definition", nameKey.ToString()));
            gen.Add(new XAttribute("TypeToSpecify", "T"));
            dir.Add(gen);
            return base.Load(convert, requireName);
        }
    }
}