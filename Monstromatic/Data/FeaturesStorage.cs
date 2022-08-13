using System;
using Monstromatic.Models;
using Monstromatic.Utils;

namespace Monstromatic.Data;

public class FeaturesStorage : AppDataFileStorageBase<MonsterFeature[]>
{
    public FeaturesStorage() : base(StorageHelper.FeaturesFileName, "Features.json")
    {
    }

    protected override MonsterFeature[] GetDefaultValue()
    {
        return Array.Empty<MonsterFeature>();
    }
}