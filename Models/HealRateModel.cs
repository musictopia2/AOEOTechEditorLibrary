﻿namespace AOEOTechEditorLibrary.Models;
public class HealRateModel : UnitModel
{
    protected override string Action => "Heal";
    protected override string SubType => "WorkRate";
    protected override string Relativity => "Percent";
    protected override string UnitType => "LogicalTypeHealed";
    protected override string Resource => "";
    protected override string DamageType => "";
}