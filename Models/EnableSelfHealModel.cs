﻿namespace AOEOTechEditorLibrary.Models;
public class EnableSelfHealModel : UnitModel
{
    protected override string Action => "SelfHeal";
    protected override string SubType => "ActionEnable";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string Relativity => "Assign";
}