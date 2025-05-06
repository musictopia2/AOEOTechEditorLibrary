namespace AOEOTechEditorLibrary.Helpers;
public static class EffectsSerialization
{
    // Helper method 1: Convert a serialized string to BasicList<BasicEffectModel>
    public static BasicList<BasicEffectModel> CreateBasicEffectsFromString(string modelString)
    {
        BasicList<BasicEffectModel> effectModels = new BasicList<BasicEffectModel>();

        // Split the modelString into individual effect strings using '\n' as a delimiter
        var properties = modelString.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var property in properties)
        {
            var model = BasicEffectModel.CreateFromString(property);
            if (model != null)
            {
                effectModels.Add(model);
            }
            else
            {
                // Handle the case if no model is created for an unknown effect
                throw new CustomBasicException($"Unable to create model from string: {property}");
            }
        }

        return effectModels;
    }

    // Helper method 2: Convert BasicList<BasicEffectModel> to serialized string
    public static string GetStringFromBasicEffects(BasicList<BasicEffectModel> models)
    {
        StringBuilder result = new StringBuilder();

        foreach (var model in models)
        {
            // Get the serialized string of the model
            string modelString = model.ToString();

            // Append the model string with '\n' as the delimiter
            result.AppendLine(modelString);  // This will automatically add a newline after each model
        }

        // Return the final string with the serialized models
        return result.ToString();
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
