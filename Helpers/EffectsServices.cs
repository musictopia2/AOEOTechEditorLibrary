﻿namespace AOEOTechEditorLibrary.Helpers;
public static class EffectsServices
{
    public static BasicList<BasicEffectModel> GetRangeTechOnShips(string value)
    {
        BasicList<BasicEffectModel> output = new();
        BasicEffectModel effect = new MaximumRange1Model()
        {
            ProtoUnit = uu1.Ship,
            Value = value
        };
        output.Add(effect);
        effect = new MaximumRange2Model()
        {
            Value = value
        };
        output.Add(effect);
        return output;
    }
    public static BasicList<BasicEffectModel> GetAllConvertTechs(string value)
    {
        return GetAllConvertTechs(uu1.Priest, value);
    }
    public static BasicList<BasicEffectModel> GetAllConvertTechs(string protoUnit, string value)
    {
        BasicList<EnumConvertCategory> categories = new()
        {
            EnumConvertCategory.StandardConvertable,
            EnumConvertCategory.ConvertableCavalry,
            EnumConvertCategory.ConvertableInfantry,
            EnumConvertCategory.ConvertableBuilding,
            EnumConvertCategory.ConvertableBuilding
        };
        BasicList<BasicEffectModel> output = new();
        foreach (var item in categories)
        {
            BasicList<BasicEffectModel> list = GetConvertTechs(item, protoUnit, value);
            output.AddRange(list);
        }
        return output;
    }
    public static BasicList<BasicEffectModel> GetConvertTechs(EnumConvertCategory category, string protoUnit, string value)
    {
        BasicList<BasicEffectModel> output = new();
        BasicEffectModel effect = new Convert1Model(category);
        effect.ProtoUnit = protoUnit;
        effect.Value = value;
        output.Add(effect);
        effect = new Convert2Model(category);
        effect.ProtoUnit = protoUnit;
        effect.Value = value;
        output.Add(effect);
        return output;
    }
    public static BasicList<BasicEffectModel> GetConvertTechs(EnumConvertCategory category, string value)
    {
        return GetConvertTechs(category, uu1.Priest, value);
    }
    public static BasicList<BasicEffectModel> GetStartingResources(string value)
    {
        BasicList<BasicEffectModel> output = new()
        {
            GetStartingResources(EnumResource.Food, value),
            GetStartingResources(EnumResource.Wood, value),
            GetStartingResources(EnumResource.Gold, value),
            GetStartingResources(EnumResource.Stone, value)
        };
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
    public static BasicList<BasicEffectModel> GetHousesIncreasePop(string house, string value, int popIncreaseBy = 5)
    {
        BasicList<BasicEffectModel> output = new();
        BasicEffectModel effect = new BuildLimitModel()
        {
            ProtoUnit = house,
            Value = value
        };
        output.Add(effect);
        int starts = int.Parse(value); //hopefully okay (?)
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
        BasicList<BasicEffectModel> output = new()
        {
            GetBasicResource(EnumResource.Food, value),
            GetBasicResource(EnumResource.Wood, value),
            GetBasicResource(EnumResource.Gold, value),
            GetBasicResource(EnumResource.Stone, value)
        };
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
        BasicList<BasicEffectModel> output = new();
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
        BasicList<BasicEffectModel> output = new();
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
        BasicList<BasicEffectModel> output = new();
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
    public static BasicList<BasicEffectModel> GetVillagerCarryEffects(string value)
    {
        BasicList<BasicEffectModel> output = new();
        BasicList<EnumResource> resources = new()
        {
            EnumResource.Food,
            EnumResource.Wood,
            EnumResource.Gold,
            EnumResource.Stone
        };
        foreach (EnumResource resource in resources)
        {
            VillagerCarryModel carry = new(resource);
            carry.ProtoUnit = "UnitTypeVillager1";
            carry.Value = value;
            output.Add(carry);
        }
        return output;
    }
    public static BasicList<BasicEffectModel> GetVillagerGatherEffects(string value)
    {
        BasicList<BasicEffectModel> output = new();
        BasicList<EnumGatherCategory> categories = new()
        {
            EnumGatherCategory.AbstractFarm,
            EnumGatherCategory.AbstractFish,
            EnumGatherCategory.AbstractFruit,
            EnumGatherCategory.Herdable,
            EnumGatherCategory.Huntable,
            EnumGatherCategory.Tree,
            EnumGatherCategory.Gold,
            EnumGatherCategory.Stone
        };
        foreach (EnumGatherCategory category in categories)
        {
            VillagerGatherModel gather = new(category);
            gather.ProtoUnit = "UnitTypeVillager1";
            gather.Value = value;
            output.Add(gather);
        }
        return output;
    }
    public static BasicList<XElement> GetEffects(BasicList<BasicEffectModel> effects)
    {
        BasicList<XElement> output = new();
        foreach (BasicEffectModel effect in effects)
        {
            XElement xml = effect.GetElement();
            output.Add(xml);
        }
        return output;
    }
    public static BasicList<TechValuePairModel> GetPairs(XElement tech)
    {
        BasicList<TechValuePairModel> output = new();
        var list = tech.Elements("Effects").Single().Elements().ToBasicList();
        foreach (var item in list)
        {
            if (IsProperElement(item))
            {
                string value = item.Attribute("amount")!.Value;
                if (output.Any(x => x.OriginalValue == value) == false)
                {
                    TechValuePairModel pair = new()
                    {
                        OriginalValue = value,
                        ModifiedValue = value
                    };
                    output.Add(pair);
                }
            }
        }
        return output;
    }
    internal static bool IsProperElement(XElement source)
    {
        var item = source.Attribute("subtype");
        if (item is null)
        {
            return false;
        }
        if (source.Attribute("subtype")!.Value == "ActionEnable")
        {
            return false;
        }
        return true;
    }
}