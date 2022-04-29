using Loqui;
using Loqui.Generation;
using Noggog;
using System.Xml.Linq;
using Mutagen.Bethesda.Plugins.Records.Mapping;

namespace Mutagen.Bethesda.Generation.Modules.Plugin;

public class LinkInterfaceModule : GenerationModule
{
    public static Dictionary<ProtocolKey, Dictionary<string, List<ObjectGeneration>>> ObjectMappings = new();

    public override async Task PreLoad(ObjectGeneration obj)
    {
        await base.PreLoad(obj);
        foreach (var item in obj.Node.Elements(XName.Get("LinkInterface", LoquiGenerator.Namespace)))
        {
            obj.Interfaces.Add(LoquiInterfaceDefinitionType.Dual, item.Value);
        }
    }

    public override async Task PrepareGeneration(ProtocolGeneration proto)
    {
        await base.PrepareGeneration(proto);

        // Compile interfaces implementing interfaces mapping data
        var interfaceInheritenceMappings = new Dictionary<string, HashSet<string>>();

        foreach (var obj in proto.ObjectGenerationsByID.Values)
        {
            foreach (var item in obj.Node.Elements(XName.Get("LinkInterface", LoquiGenerator.Namespace)))
            {
                ObjectMappings.GetOrAdd(proto.Protocol).GetOrAdd(item.Value).Add(obj);
            }
        }

        // Generate interface files themselves
        if (!ObjectMappings.TryGetValue(proto.Protocol, out var mappings)) return;
        foreach (var interf in mappings)
        {
            StructuredStringBuilder sb = new StructuredStringBuilder();
            ObjectGeneration.AddAutogenerationComment(sb);

            sb.AppendLine("using Mutagen.Bethesda;");
            sb.AppendLine();

            var implementedObjs = new HashSet<ObjectGeneration>();

            void AddObjs(string interfKey)
            {
                implementedObjs.Add(ObjectMappings[proto.Protocol][interfKey]);
                if (interfaceInheritenceMappings.TryGetValue(interfKey, out var parents))
                {
                    foreach (var parent in parents)
                    {
                        AddObjs(parent);
                    }
                }
            }
            AddObjs(interf.Key);

            using (sb.Namespace(proto.DefaultNamespace, fileScoped: false))
            {
                sb.AppendLine("/// <summary>");
                sb.AppendLine($"/// Implemented by: [{string.Join(", ", implementedObjs.Select(o => o.ObjectName))}]");
                sb.AppendLine("/// </summary>");
                using (var c = sb.Class(interf.Key))
                {
                    c.Type = Class.ObjectType.@interface;
                    c.Interfaces.Add($"I{proto.Protocol.Namespace}MajorRecordInternal");
                    c.Interfaces.Add($"{interf.Key}Getter");
                    if (interfaceInheritenceMappings.TryGetValue(interf.Key, out var impls))
                    {
                        c.Interfaces.Add(impls);
                    }
                    c.Partial = true;
                }
                using (sb.CurlyBrace())
                {
                }
                sb.AppendLine();

                sb.AppendLine("/// <summary>");
                sb.AppendLine($"/// Implemented by: [{string.Join(", ", implementedObjs.Select(o => o.ObjectName))}]");
                sb.AppendLine("/// </summary>");
                using (var c = sb.Class($"{interf.Key}Getter"))
                {
                    c.Type = Class.ObjectType.@interface;
                    c.Interfaces.Add($"I{proto.Protocol.Namespace}MajorRecordGetter");
                    if (interfaceInheritenceMappings.TryGetValue(interf.Key, out var impls))
                    {
                        c.Interfaces.Add(impls.Select(i => $"{i}Getter"));
                    }
                    c.Partial = true;
                }
                using (sb.CurlyBrace())
                {
                }
            }
                
            var path = Path.Combine(proto.DefFileLocation.FullName, $"../Interfaces/Link/{interf.Key}{Loqui.Generation.Constants.AutogeneratedMarkerString}.cs");
            sb.Generate(path);
            proto.GeneratedFiles.Add(path, ProjItemType.Compile);
        }

        GenerateLinkInterfaceMapping(proto, mappings);
    }

    private static void GenerateLinkInterfaceMapping(ProtocolGeneration proto, Dictionary<string, List<ObjectGeneration>> mappings)
    {
        // Generate interface to major record mapping registry
        StructuredStringBuilder mappingGen = new StructuredStringBuilder();
        ObjectGeneration.AddAutogenerationComment(mappingGen);
        mappingGen.AppendLine($"using System;");
        mappingGen.AppendLine($"using System.Collections.Generic;");
        mappingGen.AppendLine($"using Mutagen.Bethesda.Plugins.Records.Mapping;");
        mappingGen.AppendLine($"using Loqui;");
        mappingGen.AppendLine();
        using (mappingGen.Namespace(proto.DefaultNamespace))
        {
            using (var c = mappingGen.Class($"{proto.Protocol.Namespace}LinkInterfaceMapping"))
            {
                c.Public = PermissionLevel.@internal;
                c.Interfaces.Add(nameof(IInterfaceMapping));
            }

            using (mappingGen.CurlyBrace())
            {
                mappingGen.AppendLine(
                    $"public IReadOnlyDictionary<Type, {nameof(InterfaceMappingResult)}> InterfaceToObjectTypes {{ get; }}");
                mappingGen.AppendLine();
                mappingGen.AppendLine(
                    $"public {nameof(GameCategory)} GameCategory => {nameof(GameCategory)}.{proto.Protocol.Namespace};");
                mappingGen.AppendLine();

                mappingGen.AppendLine($"public {proto.Protocol.Namespace}LinkInterfaceMapping()");
                using (mappingGen.CurlyBrace())
                {
                    mappingGen.AppendLine($"var dict = new Dictionary<Type, {nameof(InterfaceMappingResult)}>();");
                    foreach (var interf in mappings)
                    {
                        mappingGen.AppendLine($"dict[typeof({interf.Key})] = new {nameof(InterfaceMappingResult)}(true, new {nameof(ILoquiRegistration)}[]");
                        using (mappingGen.CurlyBrace(appendParenthesis: true, appendSemiColon: true))
                        {
                            foreach (var obj in interf.Value)
                            {
                                mappingGen.AppendLine($"{obj.RegistrationName}.Instance,");
                            }
                        }

                        mappingGen.AppendLine($"dict[typeof({interf.Key}Getter)] = dict[typeof({interf.Key})] with {{ Setter = false }};");
                    }

                    mappingGen.AppendLine($"InterfaceToObjectTypes = dict;");
                }
            }
        }

        mappingGen.AppendLine();
        var mappingPath = Path.Combine(proto.DefFileLocation.FullName,
            $"../Interfaces/Link/LinkInterfaceMapping{Loqui.Generation.Constants.AutogeneratedMarkerString}.cs");
        mappingGen.Generate(mappingPath);
        proto.GeneratedFiles.Add(mappingPath, ProjItemType.Compile);
    }
}