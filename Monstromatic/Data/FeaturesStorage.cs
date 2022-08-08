using Monstromatic.Models;

namespace Monstromatic.Data;

public class FeaturesStorage : AppDataFileStorageBase<MonsterFeature[]>
{
    public FeaturesStorage() : base("features.json", "Features.json")
    {
    }
}