﻿using Loqui;
using Loqui.Generation;
using Loqui.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Generation
{
    public class MutagenXmlModule : XmlTranslationModule
    {
        public MutagenXmlModule(LoquiGenerator gen)
            : base(gen)
        {
        }

        public override void GenerateWriteToNode(ObjectGeneration obj, FileGeneration fg)
        {
            using (var args = new FunctionWrapper(fg,
                $"public static void WriteToNode_{ModuleNickname}{obj.GetGenericTypes(MaskType.Normal)}",
                obj.GenericTypeMaskWheres(MaskType.Normal)))
            {
                args.Add($"this {(this.ExportWithIGetter ? obj.Getter_InterfaceStr : obj.ObjectName)} item");
                args.Add($"XElement {XmlTranslationModule.XElementLine.GetParameterName(obj)}");
                args.Add($"ErrorMaskBuilder errorMask");
                args.Add($"{nameof(TranslationCrystal)} translationMask");
            }
            using (new BraceWrapper(fg))
            {
                if (obj.HasLoquiBaseObject)
                {
                    using (var args = new ArgsWrapper(fg,
                        $"{obj.BaseClass.ExtCommonName}.WriteToNode_{ModuleNickname}"))
                    {
                        args.Add($"item: item");
                        args.Add($"{XmlTranslationModule.XElementLine.GetParameterName(obj)}: {XmlTranslationModule.XElementLine.GetParameterName(obj)}");
                        args.Add($"errorMask: errorMask");
                        args.Add($"translationMask: translationMask");
                    }
                }

                void generateNormal(XmlTranslationGeneration generator, TypeGeneration field)
                {
                    if (!generator.ShouldGenerateWrite(field)) return;

                    List<string> conditions = new List<string>();
                    if (field.HasBeenSet)
                    {
                        conditions.Add($"{field.HasBeenSetAccessor(new Accessor(field, "item."))}");
                    }
                    if (this.TranslationMaskParameter)
                    {
                        conditions.Add(generator.GetTranslationIfAccessor(field, "translationMask"));
                    }
                    if (conditions.Count > 0)
                    {
                        using (var args = new IfWrapper(fg, ANDs: true))
                        {
                            foreach (var item in conditions)
                            {
                                args.Add(item);
                            }
                        }
                    }
                    using (new BraceWrapper(fg, doIt: conditions.Count > 0))
                    {
                        var maskType = this.Gen.MaskModule.GetMaskModule(field.GetType()).GetErrorMaskTypeStr(field);
                        generator.GenerateWrite(
                            fg: fg,
                            objGen: obj,
                            typeGen: field,
                            writerAccessor: $"{XmlTranslationModule.XElementLine.GetParameterName(obj)}",
                            itemAccessor: new Accessor(field, "item."),
                            maskAccessor: $"errorMask",
                            translationMaskAccessor: "translationMask",
                            nameAccessor: $"nameof(item.{field.Name})");
                    }
                }

                foreach (var field in obj.IterateFields(expandSets: SetMarkerType.ExpandSets.FalseAndInclude, nonIntegrated: true))
                {
                    if (!this.TryGetTypeGeneration(field.GetType(), out var generator))
                    {
                        throw new ArgumentException("Unsupported type generator: " + field);
                    }

                    if (field is DataType dataType)
                    {
                        fg.AppendLine($"if (item.{dataType.StateName}.HasFlag({obj.Name}.{dataType.EnumName}.Has))");
                        using (new BraceWrapper(fg))
                        {
                            bool isInRange = false;
                            int encounteredBreakIndex = 0;
                            foreach (var subField in dataType.IterateFieldsWithMeta())
                            {
                                if (!this.TryGetTypeGeneration(subField.Field.GetType(), out var subGenerator))
                                {
                                    throw new ArgumentException("Unsupported type generator: " + subField.Field);
                                }

                                var subData = subField.Field.GetFieldData();
                                if (!subGenerator.ShouldGenerateCopyIn(subField.Field)) continue;
                                if (subField.BreakIndex != -1)
                                {
                                    fg.AppendLine($"if (!item.{dataType.StateName}.HasFlag({obj.Name}.{dataType.EnumName}.Break{subField.BreakIndex}))");
                                    fg.AppendLine("{");
                                    fg.Depth++;
                                    encounteredBreakIndex++;
                                }
                                if (subField.Range != null && !isInRange)
                                {
                                    isInRange = true;
                                    fg.AppendLine($"if (item.{dataType.StateName}.HasFlag({obj.Name}.{dataType.EnumName}.Range{subField.RangeIndex}))");
                                    fg.AppendLine("{");
                                    fg.Depth++;
                                }
                                if (subField.Range == null && isInRange)
                                {
                                    isInRange = false;
                                    fg.Depth--;
                                    fg.AppendLine("}");
                                }
                                generateNormal(subGenerator, subField.Field);
                            }
                            for (int i = 0; i < encounteredBreakIndex; i++)
                            {
                                fg.Depth--;
                                fg.AppendLine("}");
                            }
                        }
                    }
                    else
                    {
                        generateNormal(generator, field);
                    }
                }
            }
            fg.AppendLine();
        }

        private void HandleDataTypeParsing(ObjectGeneration obj, FileGeneration fg, DataType set, DataType.DataTypeIteration subField, ref bool isInRange)
        {
            if (subField.BreakIndex != -1)
            {
                fg.AppendLine($"item.{set.StateName} &= ~{obj.Name}.{set.EnumName}.Break{subField.BreakIndex};");
            }
            if (subField.Range != null && !isInRange)
            {
                isInRange = true;
                fg.AppendLine($"item.{set.StateName} &= ~{obj.Name}.{set.EnumName}.Range{subField.RangeIndex};");
            }
            if (subField.Range == null && isInRange)
            {
                isInRange = false;
            }
        }

        protected override async Task GenerateCreateSnippet(ObjectGeneration obj, FileGeneration fg)
        {
            if (obj.Abstract)
            {
                fg.AppendLine($"{obj.Name}{obj.GetGenericTypes(MaskType.Normal)} ret;");
            }
            else
            {
                fg.AppendLine($"var ret = new {obj.Name}{obj.GetGenericTypes(MaskType.Normal)}();");
            }
            if (obj.Abstract)
            {
                fg.AppendLine("if (!LoquiXmlTranslation.Instance.TryCreate(node, out ret, errorMask, translationMask))");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine($"throw new ArgumentException($\"Unknown {obj.Name} subclass: {{node.Name.LocalName}}\");");
                }
            }
            else
            {
                fg.AppendLine("try");
                using (new BraceWrapper(fg))
                {
                    foreach (var field in obj.IterateFields(nonIntegrated: true, expandSets: SetMarkerType.ExpandSets.FalseAndInclude))
                    {
                        if (!(field is DataType set)) continue;
                        for (int i = 0; i < set.BreakIndices.Count; i++)
                        {
                            fg.AppendLine($"ret.{set.StateName} |= {obj.Name}.{set.EnumName}.Break{i};");
                        }
                        for (int i = 0; i < set.RangeIndices.Count; i++)
                        {
                            fg.AppendLine($"ret.{set.StateName} |= {obj.Name}.{set.EnumName}.Range{i};");
                        }
                    }

                    fg.AppendLine($"foreach (var elem in {XmlTranslationModule.XElementLine.GetParameterName(obj)}.Elements())");
                    using (new BraceWrapper(fg))
                    {
                        if (obj.IterateFields(includeBaseClass: true).Any(f => f.ReadOnly))
                        {
                            using (var args = new ArgsWrapper(fg,
                                $"FillPrivateElement_{ModuleNickname}"))
                            {
                                args.Add("item: ret");
                                args.Add($"{XmlTranslationModule.XElementLine.GetParameterName(obj)}: elem");
                                args.Add("name: elem.Name.LocalName");
                                args.Add("errorMask: errorMask");
                                if (this.TranslationMaskParameter)
                                {
                                    args.Add("translationMask: translationMask");
                                }
                            }
                        }
                        using (var args = new ArgsWrapper(fg,
                            $"{obj.ExtCommonName}.FillPublicElement_{ModuleNickname}"))
                        {
                            args.Add("item: ret");
                            args.Add($"{XmlTranslationModule.XElementLine.GetParameterName(obj)}: elem");
                            args.Add("name: elem.Name.LocalName");
                            args.Add("errorMask: errorMask");
                            if (this.TranslationMaskParameter)
                            {
                                args.Add("translationMask: translationMask");
                            }
                        }
                    }
                    BinaryTranslationModule.GenerateModLinking(obj, fg);
                }
                fg.AppendLine("catch (Exception ex)");
                fg.AppendLine("when (errorMask != null)");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine("errorMask.ReportException(ex);");
                    if (obj.Abstract)
                    {
                        fg.AppendLine("return null;");
                    }
                }
            }
            fg.AppendLine("return ret;");
        }

        protected override void FillPrivateElement(ObjectGeneration obj, FileGeneration fg)
        {
            if (obj.IterateFields(includeBaseClass: true).Any(f => f.ReadOnly))
            {
                using (var args = new FunctionWrapper(fg,
                    $"protected static void FillPrivateElement_{ModuleNickname}"))
                {
                    args.Add($"{obj.ObjectName} item");
                    args.Add($"XElement {XmlTranslationModule.XElementLine.GetParameterName(obj)}");
                    args.Add("string name");
                    args.Add($"ErrorMaskBuilder errorMask");
                    args.Add($"{nameof(TranslationCrystal)} translationMask");
                }
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine("switch (name)");
                    using (new BraceWrapper(fg))
                    {
                        bool isInRange = false;
                        foreach (var field in obj.IterateFields(expandSets: SetMarkerType.ExpandSets.FalseAndInclude, nonIntegrated: true))
                        {
                            if (field is DataType set)
                            {
                                foreach (var subField in set.IterateFieldsWithMeta())
                                {
                                    if (subField.Field.Derivative) continue;
                                    if (!subField.Field.ReadOnly) continue;
                                    if (!subField.Field.IntegrateField) continue;
                                    if (!this.TryGetTypeGeneration(subField.Field.GetType(), out var generator))
                                    {
                                        throw new ArgumentException("Unsupported type generator: " + subField.Field);
                                    }
                                    fg.AppendLine($"case \"{subField.Field.Name}\":");
                                    using (new DepthWrapper(fg))
                                    {
                                        if (generator.ShouldGenerateCopyIn(subField.Field))
                                        {
                                            generator.GenerateCopyIn(
                                                fg: fg,
                                                objGen: obj,
                                                typeGen: subField.Field,
                                                nodeAccessor: XmlTranslationModule.XElementLine.GetParameterName(obj).Result,
                                                itemAccessor: new Accessor(subField.Field, "item."),
                                                translationMaskAccessor: "translationMask",
                                                maskAccessor: $"errorMask");
                                        }
                                        HandleDataTypeParsing(obj, fg, set, subField, ref isInRange);
                                        fg.AppendLine("break;");
                                    }
                                }
                            }
                            else if (field.IntegrateField)
                            {
                                if (field.Derivative) continue;
                                if (!field.ReadOnly) continue;
                                if (!this.TryGetTypeGeneration(field.GetType(), out var generator))
                                {
                                    throw new ArgumentException("Unsupported type generator: " + field);
                                }

                                fg.AppendLine($"case \"{field.Name}\":");
                                using (new DepthWrapper(fg))
                                {
                                    if (generator.ShouldGenerateCopyIn(field))
                                    {
                                        generator.GenerateCopyIn(
                                            fg: fg,
                                            objGen: obj,
                                            typeGen: field,
                                            nodeAccessor: XmlTranslationModule.XElementLine.GetParameterName(obj).Result,
                                            itemAccessor: new Accessor(field, "item."),
                                            translationMaskAccessor: "translationMask",
                                            maskAccessor: $"errorMask");
                                    }
                                    fg.AppendLine("break;");
                                }
                            }
                        }

                        fg.AppendLine("default:");
                        using (new DepthWrapper(fg))
                        {
                            if (obj.HasLoquiBaseObject)
                            {
                                using (var args = new ArgsWrapper(fg,
                                    $"{obj.BaseClassName}.FillPrivateElement_" +
                                    $"{ModuleNickname}{obj.GetBaseMask_GenericTypes(MaskType.Error)}"))
                                {
                                    args.Add("item: item");
                                    args.Add($"{XmlTranslationModule.XElementLine.GetParameterName(obj)}: {XmlTranslationModule.XElementLine.GetParameterName(obj)}");
                                    args.Add("name: name");
                                    args.Add("errorMask: errorMask");
                                    if (this.TranslationMaskParameter)
                                    {
                                        args.Add($"translationMask: translationMask");
                                    }
                                }
                            }
                            fg.AppendLine("break;");
                        }
                    }
                }
                fg.AppendLine();
            }
        }

        protected override void FillPublicElement(ObjectGeneration obj, FileGeneration fg)
        {
            using (var args = new FunctionWrapper(fg,
                $"public static void FillPublicElement_{ModuleNickname}{obj.GetGenericTypes(MaskType.Normal)}",
                obj.GenericTypeMaskWheres(MaskType.Normal)))
            {
                args.Add($"this {obj.ObjectName} item");
                args.Add($"XElement {XmlTranslationModule.XElementLine.GetParameterName(obj)}");
                args.Add("string name");
                args.Add($"ErrorMaskBuilder errorMask");
                args.Add($"{nameof(TranslationCrystal)} translationMask");
            }
            using (new BraceWrapper(fg))
            {
                fg.AppendLine("switch (name)");
                using (new BraceWrapper(fg))
                {
                    bool isInRange = false;
                    foreach (var field in obj.IterateFields(expandSets: SetMarkerType.ExpandSets.FalseAndInclude, nonIntegrated: true))
                    {
                        if (field is DataType set)
                        {
                            foreach (var subField in set.IterateFieldsWithMeta())
                            {
                                if (subField.Field.Derivative) continue;
                                if (subField.Field.ReadOnly) continue;
                                if (!subField.Field.IntegrateField) continue;
                                if (!this.TryGetTypeGeneration(subField.Field.GetType(), out var generator))
                                {
                                    throw new ArgumentException("Unsupported type generator: " + subField.Field);
                                }

                                fg.AppendLine($"case \"{subField.Field.Name}\":");
                                using (new DepthWrapper(fg))
                                {
                                    if (generator.ShouldGenerateCopyIn(subField.Field))
                                    {
                                        generator.GenerateCopyIn(
                                            fg: fg,
                                            objGen: obj,
                                            typeGen: subField.Field,
                                            nodeAccessor: XmlTranslationModule.XElementLine.GetParameterName(obj).Result,
                                            itemAccessor: new Accessor(subField.Field, "item."),
                                            translationMaskAccessor: "translationMask",
                                            maskAccessor: $"errorMask");
                                    }
                                    HandleDataTypeParsing(obj, fg, set, subField, ref isInRange);
                                    fg.AppendLine("break;");
                                }
                            }
                        }
                        else if (field.IntegrateField)
                        {
                            if (field.Derivative) continue;
                            if (field.ReadOnly) continue;
                            if (!this.TryGetTypeGeneration(field.GetType(), out var generator))
                            {
                                throw new ArgumentException("Unsupported type generator: " + field);
                            }

                            fg.AppendLine($"case \"{field.Name}\":");
                            using (new DepthWrapper(fg))
                            {
                                if (generator.ShouldGenerateCopyIn(field))
                                {
                                    generator.GenerateCopyIn(
                                        fg: fg,
                                        objGen: obj,
                                        typeGen: field,
                                        nodeAccessor: XmlTranslationModule.XElementLine.GetParameterName(obj).Result,
                                        itemAccessor: new Accessor(field, "item."),
                                        translationMaskAccessor: "translationMask",
                                        maskAccessor: $"errorMask");
                                }
                                fg.AppendLine("break;");
                            }
                        }
                    }

                    fg.AppendLine("default:");
                    using (new DepthWrapper(fg))
                    {
                        if (obj.HasLoquiBaseObject)
                        {
                            using (var args = new ArgsWrapper(fg,
                                $"{obj.BaseClass.ExtCommonName}.FillPublicElement_{ModuleNickname}{obj.GetBaseMask_GenericTypes(MaskType.Error)}"))
                            {
                                args.Add("item: item");
                                args.Add($"{XmlTranslationModule.XElementLine.GetParameterName(obj)}: {XmlTranslationModule.XElementLine.GetParameterName(obj)}");
                                args.Add("name: name");
                                args.Add("errorMask: errorMask");
                                if (this.TranslationMaskParameter)
                                {
                                    args.Add($"translationMask: translationMask");
                                }
                            }
                        }
                        fg.AppendLine("break;");
                    }
                }
            }
            fg.AppendLine();
        }
    }
}
