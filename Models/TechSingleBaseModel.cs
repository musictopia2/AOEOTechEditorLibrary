﻿namespace AOEOTechEditorLibrary.Models;
public abstract class TechSingleBaseModel : BasicEffectModel
{
    protected override string Action => "";
    protected override string Relativity => "Percent";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string EffectType => "Data";
    protected override string TargetType => "Tech";
    protected override string Status => "";
    protected override void Start()
    {
        if (Content == "")
        {
            throw new CustomBasicException("Must have the tech that will be affected");
        }
        if (ProtoUnit != "")
        {
            ProtoUnit = ""; //never a unit this time.
        }
        base.Start();
    }
}