﻿namespace AOEOTechEditorLibrary.Effects;
public class VillagerGatherModel(EnumGatherCategory category) : UnitModel
{
    protected override string Action => "Gather";
    protected override string SubType => "WorkRate";
    protected override string UnitType => category.ToString();
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}