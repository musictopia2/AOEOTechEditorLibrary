namespace AOEOTechEditorLibrary.Helpers;
public static class EffectsServices
{
    public static BasicList<BasicEffectModel> GetRangeTechOnRomanShips(string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicEffectModel effect = new MaximumRange1Model()
        {
            ProtoUnit = RomanUnits.Enneris,
            Value = value
        };
        output.Add(effect);
        effect = new MaximumRange2Model()
        {
            ProtoUnit = RomanUnits.Enneris,
            Value = value
        };
        output.Add(effect);
        return output;
    }
    public static BasicList<BasicEffectModel> GetAllArmorTechs(string protoUnit, string value, bool includeSiege)
    {
        BasicList<EnumDamageCategory> categories =
        [
            EnumDamageCategory.Cavalry,
            EnumDamageCategory.Hand,
            EnumDamageCategory.Ranged
        ];
        if (includeSiege)
        {
            categories.Add(EnumDamageCategory.Siege);
        }
        BasicList<BasicEffectModel> output = [];
        foreach (var item in categories)
        {
            BasicEffectModel effect = new ArmorModel(item)
            {
                ProtoUnit = protoUnit,
                Value = value
            };
            output.Add(effect);
        }
        return output;
    }
    public static BasicList<BasicEffectModel> GetAllConvertRateTechs(string value)
    {
        return GetAllConvertRateTechs(uu1.Priest, value);
    }
    public static BasicList<BasicEffectModel> GetAllConvertRateTechs(string protoUnit, string value)
    {
        BasicList<EnumConvertCategory> categories =
        [
            EnumConvertCategory.StandardConvertable,
            EnumConvertCategory.ConvertableCavalry,
            EnumConvertCategory.ConvertableInfantry,
            EnumConvertCategory.ConvertableBuilding,
            EnumConvertCategory.ConvertableBuilding
        ];
        BasicList<BasicEffectModel> output = [];
        foreach (var item in categories)
        {
            BasicList<BasicEffectModel> list = GetConvertRateTechs(item, protoUnit, value);
            output.AddRange(list);
        }
        return output;
    }
    public static BasicList<BasicEffectModel> GetConvertRateTechs(EnumConvertCategory category, string protoUnit, string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicEffectModel effect = new ConvertRate1Model(category);
        effect.ProtoUnit = protoUnit;
        effect.Value = value;
        output.Add(effect);
        effect = new ConvertRate2Model(category);
        effect.ProtoUnit = protoUnit;
        effect.Value = value;
        output.Add(effect);
        return output;
    }
    public static BasicList<BasicEffectModel> GetConvertRateTechs(EnumConvertCategory category, string value)
    {
        return GetConvertRateTechs(category, uu1.Priest, value);
    }
    public static BasicList<BasicEffectModel> GetConvertRangeTechs(string value)
    {
        return GetConvertRangeTechs(uu1.Priest, value);
    }
    public static BasicList<BasicEffectModel> GetConvertRangeTechs(string protoUnit, string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicEffectModel effect = new ConvertRange1Model()
        {
            ProtoUnit = protoUnit,
            Value = value
        };
        output.Add(effect);
        effect = new ConvertRange2Model()
        {
            ProtoUnit = protoUnit,
            Value = value
        };
        output.Add(effect);
        return output;
    }
    public static BasicList<BasicEffectModel> GetStartingResources(string value)
    {
        BasicList<BasicEffectModel> output =
        [
            GetStartingResources(EnumResource.Food, value),
            GetStartingResources(EnumResource.Wood, value),
            GetStartingResources(EnumResource.Gold, value),
            GetStartingResources(EnumResource.Stone, value)
        ];
        return output;
    }
    public static BasicEffectModel GetStartingResources(EnumResource resource, string value)
    {
        StartingResourceModel output = new(resource)
        {
            Value = value
        };
        return output;
    }
    public static BasicList<BasicEffectModel> GetBonusDamageAgainstKeyMilitaryUnits(string protoUnit, string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicList<string> against =
        [
            uu1.Archer,
            uu1.Infantry,
            uu1.Cavalry,
            uu1.Siege,
            uu1.Priest,
            uu1.Ship
        ];
        foreach (var unit in against)
        {
            BasicEffectModel effect = new BonusDamageAgainstUnitModel(unit)
            {
                ProtoUnit = protoUnit,
                Value = value
            };
            output.Add(effect);
        }
        return output;
    }
    public static BasicList<BasicEffectModel> GetHousesIncreasePop(string house, string value, int popIncreaseBy = 5)
    {
        BasicList<BasicEffectModel> output = [];
        BasicEffectModel effect = new BuildLimitModel()
        {
            ProtoUnit = house,
            Value = value
        };
        output.Add(effect);
        value = value.Replace(".0000", "");
        int starts = int.Parse(value);
        int popExtra = starts * popIncreaseBy;
        effect = new PopulationExtraModel()
        {
            Value = popExtra.ToString()
        };
        output.Add(effect);
        return output;
    }
    public static BasicList<BasicEffectModel> GetBasicResources(string value)
    {
        BasicList<BasicEffectModel> output =
        [
            GetBasicResource(EnumResource.Food, value),
            GetBasicResource(EnumResource.Wood, value),
            GetBasicResource(EnumResource.Gold, value),
            GetBasicResource(EnumResource.Stone, value)
        ];
        return output;
    }
    public static BasicEffectModel GetBasicResource(EnumResource resource, string value)
    {
        BasicTrickleResourceModel output = new(resource)
        {
            Value = value
        };
        return output;
    }
    public static BasicList<BasicEffectModel> GetMaximumResources(string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicList<BasicEffectModel> list = GetMaximumResources(EnumResource.Food, value);
        output.AddRange(list);
        list = GetMaximumResources(EnumResource.Wood, value);
        output.AddRange(list);
        list = GetMaximumResources(EnumResource.Gold, value);
        output.AddRange(list);
        list = GetMaximumResources(EnumResource.Stone, value);
        output.AddRange(list);
        return output;
    }
    public static BasicList<BasicEffectModel> GetMaximumResources(EnumResource resource, string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicTrickleResourceModel firsts = new(resource)
        {
            Value = value
        };
        output.Add(firsts);
        MaximumTrickleResourceModel seconds = new(resource)
        {
            Value = value
        };
        output.Add(seconds);
        return output;
    }
    public static BasicList<BasicEffectModel> GetHealingEffects(string protoName, string value)
    {
        BasicList<BasicEffectModel> output = [];
        EnableSelfHealModel firsts = new()
        {
            ProtoUnit = protoName,
            Value = "1.0000"
        };
        output.Add(firsts);
        ModifySelfHealModel seconds = new()
        {
            ProtoUnit = protoName,
            Value = value
        };
        output.Add(seconds);
        return output;
    }
    public static BasicList<BasicEffectModel> GetGatherElephantCarryEffects(string value)
    {
        return GetUnitCarryEffects(IndianUnits.GathererElephant, value);
    }
    private static BasicList<BasicEffectModel> GetUnitCarryEffects(string unit, string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicList<EnumResource> resources =
        [
            EnumResource.Food,
            EnumResource.Wood,
            EnumResource.Gold,
            EnumResource.Stone
        ];
        foreach (EnumResource resource in resources)
        {
            VillagerCarryModel carry = new(resource);
            carry.ProtoUnit = unit;
            carry.Value = value;
            output.Add(carry);
        }
        return output;
    }
    public static BasicList<BasicEffectModel> GetVillagerCarryEffects(string value)
    {
        return GetUnitCarryEffects(uu1.Villager, value);
    }
    private static BasicList<BasicEffectModel> GetUnitYieldEffects(string unit, string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicList<EnumGatherCategory> categories =
        [
            EnumGatherCategory.AbstractFish,
            EnumGatherCategory.AbstractFruit,
            EnumGatherCategory.Herdable,
            EnumGatherCategory.Huntable,
            EnumGatherCategory.Tree,
            EnumGatherCategory.Gold,
            EnumGatherCategory.Stone
        ];
        foreach (EnumGatherCategory category in categories)
        {
            VillagerYieldModel gather = new(category);
            gather.ProtoUnit = unit;
            gather.Value = value;
            output.Add(gather);
        }
        return output;
    }
    public static BasicList<BasicEffectModel> GetVillagerYieldEffects(string value)
    {
        return GetUnitYieldEffects(uu1.Villager, value);
    }
    public static BasicList<BasicEffectModel> GetGatherElephantYieldEffects(string value)
    {
        return GetUnitYieldEffects(IndianUnits.GathererElephant, value);
    }
    private static BasicList<BasicEffectModel> GetUnitGatherEffects(string unit, string value)
    {
        BasicList<BasicEffectModel> output = [];
        BasicList<EnumGatherCategory> categories =
        [
            EnumGatherCategory.AbstractFarm,
            EnumGatherCategory.AbstractFish,
            EnumGatherCategory.AbstractFruit,
            EnumGatherCategory.Herdable,
            EnumGatherCategory.Huntable,
            EnumGatherCategory.Tree,
            EnumGatherCategory.Gold,
            EnumGatherCategory.Stone
        ];
        foreach (EnumGatherCategory category in categories)
        {
            VillagerGatherModel gather = new(category);
            gather.ProtoUnit = unit;
            gather.Value = value;
            output.Add(gather);
        }
        return output;
    }
    public static BasicList<BasicEffectModel> GetVillagerGatherEffects(string value)
    {
        return GetUnitGatherEffects(uu1.Villager, value);
    }
    public static BasicList<BasicEffectModel> GetGatherElephantGatherEffects(string value)
    {
        return GetUnitGatherEffects(IndianUnits.GathererElephant, value);
    }
    public static BasicList<XElement> GetEffects(BasicList<BasicEffectModel> effects)
    {
        BasicList<XElement> output = [];
        foreach (BasicEffectModel effect in effects)
        {
            XElement xml = effect.GetElement();
            if (TechHelpers.EffectAllowed is null || TechHelpers.EffectAllowed.Invoke(xml))
            {
                output.Add(xml);
            }
        }
        return output;
    }
}