﻿namespace AOEOTechEditorLibrary.Models;
public class ShrineAutoGatherModel(EnumResource resource) : AutoGatherModel(resource)
{
    protected override string Action => "ShrineGather";
}