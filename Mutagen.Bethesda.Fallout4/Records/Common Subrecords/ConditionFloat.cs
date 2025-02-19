using System.Diagnostics;

namespace Mutagen.Bethesda.Fallout4;

public partial class ConditionFloat
{
    #region Data
    public override ConditionData Data { get; set; } = new FunctionConditionData();
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IConditionDataGetter IConditionFloatGetter.Data => Data;
    #endregion
}

partial class ConditionFloatBinaryOverlay
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IConditionDataGetter IConditionFloatGetter.Data => Data;
}